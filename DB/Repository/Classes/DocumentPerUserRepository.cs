using DB.Model;
using DB.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Classes
{
    public class DocumentPerUserRepository: IDocumentPerUserRepository
    {
        private readonly ExtraSchoolContext _context;

        public DocumentPerUserRepository(ExtraSchoolContext context)
        {
            _context = context;
        }


        public string DeleteDocumentPerUser(int idDocumentPerUser, int idUser, int uniqueCodeDocumentId)
        {
            string s = "";

            if (idDocumentPerUser != 0 && idDocumentPerUser != null)
            {

                var x = _context.AppDocumentPerUsers.Include(i => i.RequiredDocumentPerUser).FirstOrDefault(f => f.IddocumentPerUser == idDocumentPerUser);
                if (x != null)
                {
                    s = x.RequiredDocumentPerUser != null ? x.RequiredDocumentPerUser.Name : x.Name;
                    //---------
                    var fold = x.Folder;
                    if (uniqueCodeDocumentId != 0)
                    {
                        deleteDocumentsPerUserOfUniqueCode(uniqueCodeDocumentId);
                    }
                    else
                    {
                        //---------
                        _context.AppDocumentPerUsers.Remove(x);
                        _context.SaveChanges();
                        if (fold != null && fold.AppDocumentPerUsers.Count == 1)
                            fold.AppDocumentPerUsers.ToList()[0].FolderId = null;
                        _context.SaveChanges();

                    }
                }
            }
            return s;
        }

        public AppDocumentPerUser DeleteFewDocumentPerUser(int idFolder, int requiredDocumentPerUserId, int idUser, int uniqueCodeDocumentId)
        {
            AppDocumentPerUser t = null;
            AppFolder appFolder = _context.AppFolders.Include(i => i.AppDocumentPerUsers).FirstOrDefault(f => f.IdFolder == idFolder);
            List<AppDocumentPerUser> AppDocumentPerUser = new List<AppDocumentPerUser>();
            if (appFolder != null && appFolder.AppDocumentPerUsers != null)
            {
                appFolder.AppDocumentPerUsers.ToList().ForEach(f =>
                {
                    if (f.UniqueCodeId != null && f.UniqueCodeId > 0)
                        deleteDocumentsPerUserOfUniqueCode((int)f.UniqueCodeId);
                    else
                    {
                        AppDocumentPerUser.Add(f);
                    }

                });
                _context.AppFolders.Remove(appFolder);
                _context.SaveChanges();
                if (AppDocumentPerUser.Count > 0)
                {
                    _context.AppDocumentPerUsers.RemoveRange(AppDocumentPerUser);
                    _context.SaveChanges();
                }
            }

            if (requiredDocumentPerUserId != null && requiredDocumentPerUserId > 0)
            {
                var tab = _context.TabRequiredDocumentPerUsers.FirstOrDefault(f => f.IdrequiredDocumentPerUser == requiredDocumentPerUserId);
                if (tab != null)
                {
                    t = new AppDocumentPerUser();
                    t.RequiredDocumentPerUserId = tab.IdrequiredDocumentPerUser;
                    t.Name = tab.Name;
                }
            }

            return t;
        }

        public List<AppDocumentPerUser> GetLstDocumentPerUser(int UserId, int schollId)
        {
            List<AppDocumentPerUser> lstDoc = new List<AppDocumentPerUser>();
            var docPerUser = _context.AppDocumentPerUsers.Include(i => i.Folder).Where(w => w.UserId == UserId).ToList();
            var docRequiredPerUser = _context.TabRequiredDocumentPerUsers.Where(w => w.SchoolId == schollId);
            if (docPerUser == null)
                docPerUser = new List<AppDocumentPerUser>();
            foreach (var doc in docRequiredPerUser)
            {
                if (docPerUser.FirstOrDefault(f => f.RequiredDocumentPerUserId == doc.IdrequiredDocumentPerUser) == null)
                    docPerUser.Add(new AppDocumentPerUser() { Name = doc.Name, RequiredDocumentPerUserId = doc.IdrequiredDocumentPerUser });
            }
            return docPerUser;
        }

        public void SaveNameFile(int idfile, string nameFile, int uniqeId)
        {
            if (uniqeId != null && uniqeId > 0)
            {
                List<AppDocumentPerUser> lst = _context.AppDocumentPerUsers.Where(f => f.UniqueCodeId == uniqeId).ToList();
                if (lst != null && lst.Count > 0)
                {
                    lst.ForEach(f => f.Name = nameFile);
                    _context.SaveChanges();
                }
            }
            else
            {
                var x = _context.AppDocumentPerUsers.FirstOrDefault(f => f.IddocumentPerUser == idfile);
                if (x != null)
                {
                    x.Name = nameFile;
                    _context.SaveChanges();
                }
            }
        }

        public void deleteDocumentsPerUserOfUniqueCode(int uniqueCodeDocumentId)
        {
            if (uniqueCodeDocumentId != null && uniqueCodeDocumentId != 0)
            {
                var x = _context.AppUniqueCodes.Include(i => i.AppDocumentPerUsers).FirstOrDefault(f => f.IduniqueCode == uniqueCodeDocumentId);
                if (x != null)
                {
                    //---------
                    if (x.AppDocumentPerUsers != null)
                    {
                        x.AppDocumentPerUsers.ToList().ForEach(f =>
                        {
                            AppFolder fold = f.Folder;

                            _context.AppDocumentPerUsers.Remove(f);
                            _context.SaveChanges();

                            if (fold != null && fold.AppDocumentPerUsers.Count == 1)
                                fold.AppDocumentPerUsers.ToList()[0].FolderId = null;
                        });
                        _context.SaveChanges();
                    }
                    _context.AppUniqueCodes.Remove(x);
                    _context.SaveChanges();


                }
            }
        }

        public AppDocumentPerUser UploadDocumentPerUser(AppDocumentPerUser appDocumentPerUser, int uniqueCodeID)
        {
            appDocumentPerUser.Folder = null;
            //מסמך חדש
            if (appDocumentPerUser.IddocumentPerUser == 0)
                _context.AppDocumentPerUsers.Add(appDocumentPerUser);
            //עידכון מסמך קיים
            else
            {
                var x = _context.AppDocumentPerUsers.Include(i => i.Folder).FirstOrDefault(f => f.IddocumentPerUser == appDocumentPerUser.IddocumentPerUser);
                if (x != null)
                {
                    x.DateUpdated = appDocumentPerUser.DateUpdated;
                    x.UserUpdated = appDocumentPerUser.UserUpdated;
                    x.Path = appDocumentPerUser.Path;
                    x.Name = appDocumentPerUser.Name;
                    x.Type = appDocumentPerUser.Type;
                    appDocumentPerUser = x;
                }
            }

            _context.SaveChanges();
            return appDocumentPerUser;
        }

        public List<AppDocumentPerUser> UploadFewDocumentsPerUser(List<AppDocumentPerUser> lists, string nameFolder, int uniqueCodeID, int userId, int? customerId)
        {
            int i = 0;
            string name = "";
            AppFolder f = null;

            if (uniqueCodeID != 0)
            {
                List<AppDocumentPerUser> lst = new List<AppDocumentPerUser>();
                AppDocumentPerUser appDocumentPerUser;
                int? appUserPerSchoolId;
                int? tabRequiredDocumentPerUserId = null;

                if (customerId == 0)
                    customerId = null;

                //היוזר פר סקול של הלקוח 
                List<AppUserPerSchool> appUserPerSchools = _context.AppUserPerSchools.Where(w => w.UserId == userId).ToList();
                //הדרוש של הקבצים המועלים
                TabRequiredDocumentPerUser tabRequiredDocumentPerUser = _context.TabRequiredDocumentPerUsers.Include(i => i.UniqueCode.TabRequiredDocumentPerUsers).FirstOrDefault(w => w.IdrequiredDocumentPerUser == lists[0].RequiredDocumentPerUserId);
                //הקורסים התואמים אליהם צריך להעלות את הקבצים
                List<AppUserPerSchool> AppUserPerSchool = _context.AppUserPerSchools.Where(w => w.UniqueCodeId == uniqueCodeID).ToList();
                int? UniqueCode = null;
                bool isFirstTime = true;
                List<int?> ListUnique = new List<int?>();
                int index = 0;
                bool flag = false;

                //מעבר על הקורסים התואמים
                AppUserPerSchool.ForEach(fe =>
                {
                    index = 0;
                    f = null;
                    //היוזר פר סקול של הסקול הנוכחי והלקוח
                    appUserPerSchoolId = appUserPerSchools.FirstOrDefault(f => f.SchoolId == fe.SchoolId)?.IduserPerSchool;
                    tabRequiredDocumentPerUserId = null;

                    //אם זה עידכון של קובץ בודד תואם / או עידכון של קובץ תואם מתיקיה
                    if (lists.Count == 1 && (lists[0].IddocumentPerUser != null && lists[0].IddocumentPerUser > 0))
                    {
                        appDocumentPerUser = _context.AppDocumentPerUsers.Include(i => i.Folder).FirstOrDefault(r => r.SchoolId == fe.SchoolId && r.UserId == fe.IduserPerSchool && r.UniqueCodeId == lists[0].UniqueCodeId);

                        if (appDocumentPerUser != null)
                        {
                            if (appDocumentPerUser.Folder != null)
                            {
                                f = appDocumentPerUser.Folder;
                                if (f != null)
                                    f.IndexFile = f.IndexFile + lists.Count;
                            }
                            appDocumentPerUser.Path = lists[0].Path;
                            appDocumentPerUser.Type = lists[0].Type;
                            appDocumentPerUser.DateUpdated = DateTime.Today;
                            appDocumentPerUser.UserUpdatedId = appUserPerSchoolId;
                            appDocumentPerUser.Name = lists[0].Name;
                            //appDocumentPerUser.Folder = f;
                        }
                        _context.SaveChanges();
                        lst.Add(appDocumentPerUser);
                    }

                    else
                    {


                        //חיפוש הדרוש של המוסד הנוכחי
                        if (tabRequiredDocumentPerUser != null && tabRequiredDocumentPerUser.SchoolId != fe.SchoolId && tabRequiredDocumentPerUser.UniqueCode != null && tabRequiredDocumentPerUser.UniqueCode.TabRequiredDocumentPerUsers != null && tabRequiredDocumentPerUser.UniqueCode.TabRequiredDocumentPerUsers.Count > 0)
                        {
                            var tabRequired = tabRequiredDocumentPerUser.UniqueCode.TabRequiredDocumentPerUsers.FirstOrDefault(f => f.SchoolId == fe.SchoolId);
                            if (tabRequired != null)
                            {
                                tabRequiredDocumentPerUserId = tabRequired.IdrequiredDocumentPerUser;
                                if (tabRequired.UniqueCodeId != tabRequiredDocumentPerUser.UniqueCodeId)
                                {
                                    tabRequired.UniqueCodeId = tabRequiredDocumentPerUser.UniqueCodeId;
                                    _context.SaveChanges();
                                }
                            }
                        }

                        //באם לא קיים הדרוש למוסד הנוכחי
                        if (tabRequiredDocumentPerUser != null && (tabRequiredDocumentPerUserId == null || tabRequiredDocumentPerUserId == 0))
                        {
                            if (tabRequiredDocumentPerUser.SchoolId == fe.SchoolId)
                                tabRequiredDocumentPerUserId = tabRequiredDocumentPerUser.IdrequiredDocumentPerUser;

                            else
                            {
                                if (tabRequiredDocumentPerUser != null)
                                {
                                    if (tabRequiredDocumentPerUser.UniqueCodeId == null || tabRequiredDocumentPerUser.UniqueCodeId == 0)
                                    {
                                        var unique = new AppUniqueCode() { CustomerId = customerId, DateCreated = DateTime.Today };
                                        _context.AppUniqueCodes.Add(unique);
                                        _context.SaveChanges();
                                        tabRequiredDocumentPerUser.UniqueCodeId = unique.IduniqueCode;


                                    }
                                    var tabRequired = new TabRequiredDocumentPerUser()
                                    {
                                        DateCreated = DateTime.Today,
                                        Name = tabRequiredDocumentPerUser.Name,
                                        SchoolId = fe.SchoolId,
                                        UniqueCodeId = tabRequiredDocumentPerUser.UniqueCodeId,
                                        UserCreatedId = appUserPerSchoolId
                                    };
                                    _context.TabRequiredDocumentPerUsers.Add(tabRequired);
                                    _context.SaveChanges();
                                    tabRequiredDocumentPerUserId = tabRequired.IdrequiredDocumentPerUser;
                                }
                                else
                                    tabRequiredDocumentPerUserId = null;
                            }
                        }


                        {
                            //אם זה העלאה ראשונית לאותו דרוש
                            if (lists.Count > 1 && (lists[0].FolderId == null || lists[0].FolderId == 0))
                            {
                                f = new AppFolder() { SchoolId = fe.SchoolId, Name = nameFolder, DateCreated = DateTime.UtcNow.AddHours(3), UserCreatedId = appUserPerSchoolId, IndexFile = lists.Count };
                                _context.AppFolders.Add(f);
                                _context.SaveChanges();
                            }

                            else
                            if (lists[0].FolderId != null && lists[0].FolderId > 0)
                            {
                                int? folderId = 0;
                                //---------
                                folderId = _context.AppDocumentPerUsers.FirstOrDefault(f => f.RequiredDocumentPerUserId == tabRequiredDocumentPerUserId && f.SchoolId == fe.SchoolId && f.ExsistDocumentId == lists[0].ExsistDocumentId)?.FolderId;
                                if (folderId != null && folderId > 0)
                                {
                                    f = _context.AppFolders.FirstOrDefault(f => f.IdFolder == folderId);
                                    if (f != null)
                                        f.IndexFile = f.IndexFile + lists.Count;
                                }

                            }
                        }

                        //פתיחה הקבצים לכל הקורסים התואמים
                        lists.ForEach(fo =>
                        {
                            //אם פותחים מסמכים תואמים חדשים וזה המוסד הראשון שפותחים לו
                            if (isFirstTime)
                            {

                                var unique = new AppUniqueCode() { CustomerId = customerId, DateCreated = DateTime.Today };
                                _context.AppUniqueCodes.Add(unique);
                                _context.SaveChanges();
                                UniqueCode = unique.IduniqueCode;
                                ListUnique.Add(UniqueCode);
                            }
                            else
                            {
                                UniqueCode = ListUnique[index];
                            }


                            appDocumentPerUser = new AppDocumentPerUser();
                            if (f != null)
                            {

                                appDocumentPerUser.FolderId = f.IdFolder;
                                appDocumentPerUser.Folder = f;
                            }
                            if (lists.Count() == 1 && lists[0].IddocumentPerUser == 0)
                            {
                                if (f == null)
                                {
                                    var x = _context.AppDocumentPerUsers.FirstOrDefault(f => f.RequiredDocumentPerUserId == tabRequiredDocumentPerUserId);
                                    if (x != null)
                                    {
                                        appDocumentPerUser.FolderId = x.FolderId;
                                        flag = true;
                                    }
                                }
                            }
                            appDocumentPerUser.SchoolId = fe.SchoolId;
                            appDocumentPerUser.Path = fo.Path;
                            appDocumentPerUser.UserId = fe.IduserPerSchool;
                            appDocumentPerUser.DateCreated = DateTime.Today;
                            appDocumentPerUser.UserCreatedId = appUserPerSchoolId;
                            //appDocumentPerUser.DateUpdated = DateTime.Today;
                            //appDocumentPerUser.UserUpdated = appUserPerSchoolId;
                            appDocumentPerUser.Type = fo.Type;
                            appDocumentPerUser.RequiredDocumentPerUserId = tabRequiredDocumentPerUserId;
                            appDocumentPerUser.Name = fo.Name;
                            appDocumentPerUser.UniqueCodeId = UniqueCode;
                            appDocumentPerUser.ExsistDocumentId = fo.ExsistDocumentId;

                            i = fo.Name.IndexOf('.');
                            if (i > -1)
                            {
                                name = fo.Name.Substring(0, i);
                                if (name != null && name != "")
                                {
                                    appDocumentPerUser.Name = name;
                                }
                            }

                            lst.Add(appDocumentPerUser);
                            index++;
                        });
                    }

                    isFirstTime = false;

                });
                _context.AppDocumentPerUsers.AddRange(lst.Where(w => w.IddocumentPerUser == null || w.IddocumentPerUser == 0));
                _context.SaveChanges();
                lists = lst.Where(w => w.SchoolId == lists[0].SchoolId).ToList();
                if (flag)
                {
                    lists[0].Folder = new AppFolder() { Name = nameFolder };
                }
            }
            else
            {

                //---------
                if (lists.Count> 1&& (lists[0].FolderId == null || lists[0].FolderId == 0))
                {
                    f = new AppFolder() { SchoolId = lists[0].SchoolId, Name = nameFolder, DateCreated = DateTime.UtcNow.AddHours(3), UserCreated = lists[0].UserCreated, IndexFile = lists.Count };
                    _context.AppFolders.Add(f);
                    _context.SaveChanges();
                }
                else
                {
                    f = _context.AppFolders.FirstOrDefault(f => f.IdFolder == lists[0].FolderId);
                    if (f != null)
                        f.IndexFile = f.IndexFile + lists.Count;

                }

                if (lists.Count == 1 && lists[0].IddocumentPerUser > 0)
                {
                    var doc = _context.AppDocumentPerUsers.FirstOrDefault(f => f.IddocumentPerUser == lists[0].IddocumentPerUser);
                    if (doc != null)
                    {
                        doc.Name = lists[0].Name;
                        doc.Type = lists[0].Type;
                        doc.UserUpdated = lists[0].UserUpdated;
                        doc.DateUpdated = lists[0].DateUpdated;
                        doc.Path = lists[0].Path;
                        doc.Folder = f;
                    }
                    lists = new List<AppDocumentPerUser>() { doc };
                }
                else
                {
                    lists.ForEach(fo =>
                    {
                        fo.FolderId = f.IdFolder;
                        fo.Folder = f;
                        i = fo.Name.IndexOf('.');
                        if (i > -1)
                        {
                            name = fo.Name.Substring(0, i);
                            if (name != null && name != "")
                            {
                                fo.Name = name;
                            }
                        }
                    });
                    _context.AppDocumentPerUsers.AddRange(lists);
                }
                _context.SaveChanges();
            }


            return lists;
        }
    }
}
