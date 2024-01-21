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
    public class DocumentPerSchoolRepository : IDocumentPerSchoolRepository
    {
        private readonly ExtraSchoolContext _context;

        public DocumentPerSchoolRepository(ExtraSchoolContext context)
        {
            _context = context;
        }


        public string DeleteDocumentPerSchool(int idDocumentPerSchool, int idSchool, int uniqueCodeDocumentId)
        {
            string s = "";

            if (idDocumentPerSchool != 0 && idDocumentPerSchool != null)
            {

                var x = _context.AppDocumentPerSchools.Include(i => i.Folder.AppDocumentPerSchools).Include(i => i.RequiredDocumentPerSchool).FirstOrDefault(f => f.IddocumentPerSchool == idDocumentPerSchool);
                if (x != null)
                {
                    s = x.RequiredDocumentPerSchoolId != null ? x.RequiredDocumentPerSchool.Name : x.Name;
                    var fold = x.Folder;
                    if (uniqueCodeDocumentId != 0)
                    {
                        deleteDocumentsPerSchoolOfUniqueCode(uniqueCodeDocumentId);
                    }
                    else
                    {
                        _context.AppDocumentPerSchools.Remove(x);
                        _context.SaveChanges();
                        if (fold != null && fold.AppDocumentPerSchools.Count == 1)
                            fold.AppDocumentPerSchools.ToList()[0].FolderId = null;
                        _context.SaveChanges();
                    }
                }
            }
            return s;

        }
        public void deleteDocumentsPerSchoolOfUniqueCode(int uniqueCodeDocumentId)
        {
            if (uniqueCodeDocumentId != null && uniqueCodeDocumentId != 0)
            {
                var x = _context.AppUniqueCodes.Include(i => i.AppDocumentPerSchools).ThenInclude(t => t.Folder.AppDocumentPerSchools).FirstOrDefault(f => f.IduniqueCode == uniqueCodeDocumentId);
                if (x != null)
                {
                    if (x.AppDocumentPerSchools != null)
                    {
                        x.AppDocumentPerSchools.ToList().ForEach(f =>
                        {
                            AppFolder fold = f.Folder;

                            _context.AppDocumentPerSchools.Remove(f);
                            _context.SaveChanges();

                            if (fold != null && fold.AppDocumentPerSchools.Count == 1)
                                fold.AppDocumentPerSchools.ToList()[0].FolderId = null;
                        });
                        //_context.AppDocumentPerSchools.RemoveRange(x.AppDocumentPerSchools);
                        _context.SaveChanges();
                    }
                    _context.AppUniqueCodes.Remove(x);
                    _context.SaveChanges();

                }
            }
        }

        public AppDocumentPerSchool DeleteFewDocumentPerSchool(int idFolder, int requiredDocumentPerSchoolId, int idSchool, int uniqueCodeDocumentId)
        {
            AppDocumentPerSchool t = null;
            AppFolder appFolder = _context.AppFolders.Include(i => i.AppDocumentPerSchools).FirstOrDefault(f => f.IdFolder == idFolder);
            List<AppDocumentPerSchool> AppDocumentPerSchool = new List<AppDocumentPerSchool>();
            if (appFolder != null && appFolder.AppDocumentPerSchools != null)
            {
                appFolder.AppDocumentPerSchools.ToList().ForEach(f =>
                {
                    if (f.UniqueCodeId != null && f.UniqueCodeId > 0)
                        deleteDocumentsPerSchoolOfUniqueCode((int)f.UniqueCodeId);
                    else
                    {
                        AppDocumentPerSchool.Add(f);
                    }

                });
                _context.AppFolders.Remove(appFolder);
                _context.SaveChanges();
                if (AppDocumentPerSchool.Count > 0)
                {
                    _context.AppDocumentPerSchools.RemoveRange(AppDocumentPerSchool);
                    _context.SaveChanges();
                }
            }

            if (requiredDocumentPerSchoolId != null && requiredDocumentPerSchoolId > 0)
            {
                var tab = _context.TabRequiredDocumentPerSchools.FirstOrDefault(f => f.IdrequiredDocumentPerSchool == requiredDocumentPerSchoolId);
                if (tab != null)
                {
                    t = new AppDocumentPerSchool();
                    t.RequiredDocumentPerSchoolId = tab.IdrequiredDocumentPerSchool;
                    t.Name = tab.Name;
                }
            }

            return t;
        }

        public List<AppDocumentPerSchool> GetLstDocumentPerSchool(int SchoolId)
        {
            List<AppDocumentPerSchool> lstDoc = new List<AppDocumentPerSchool>();
            var docPerSchool = _context.AppDocumentPerSchools.Include(i => i.Folder).Where(w => w.SchoolId == SchoolId).ToList();
            var docRequiredPerSchool = _context.TabRequiredDocumentPerSchools.Where(w => w.SchoolId == SchoolId);
            if (docPerSchool == null)
                docPerSchool = new List<AppDocumentPerSchool>();
            foreach (var doc in docRequiredPerSchool)
            {
                if (docPerSchool.FirstOrDefault(f => f.RequiredDocumentPerSchoolId == doc.IdrequiredDocumentPerSchool) == null)
                    docPerSchool.Add(new AppDocumentPerSchool() { Name = doc.Name, RequiredDocumentPerSchoolId = doc.IdrequiredDocumentPerSchool });
            }
            return docPerSchool;
        }


        public void SaveNameFile(int idfile, string nameFile, int uniqeId)
        {
            if (uniqeId != null && uniqeId > 0)
            {
                List<AppDocumentPerSchool> lst = _context.AppDocumentPerSchools.Where(f => f.UniqueCodeId == uniqeId).ToList();
                if (lst != null && lst.Count > 0)
                {
                    lst.ForEach(f => f.Name = nameFile);
                    _context.SaveChanges();
                }
            }
            else
            {
                var x = _context.AppDocumentPerSchools.FirstOrDefault(f => f.IddocumentPerSchool == idfile);
                if (x != null)
                {
                    x.Name = nameFile;
                    _context.SaveChanges();
                }
            }
        }


        public AppDocumentPerSchool UploadDocumentPerSchool(AppDocumentPerSchool appDocumentPerSchool, int uniqueCodeID)
        {
            appDocumentPerSchool.Folder = null;
            //מסמך חדש
            if (appDocumentPerSchool.IddocumentPerSchool == 0)
            {
                appDocumentPerSchool.Folder = null;
                appDocumentPerSchool.FolderId = null;
                _context.AppDocumentPerSchools.Add(appDocumentPerSchool);
            }
            //עידכון מסמך קיים
            else
            {
                var x = _context.AppDocumentPerSchools.Include(i => i.Folder).FirstOrDefault(f => f.IddocumentPerSchool == appDocumentPerSchool.IddocumentPerSchool);
                if (x != null)
                {
                    x.DateUpdated = appDocumentPerSchool.DateUpdated;
                    x.UserUpdatedId = appDocumentPerSchool.UserUpdatedId;
                    x.Path = appDocumentPerSchool.Path;
                    x.Name = appDocumentPerSchool.Name;
                    x.Type = appDocumentPerSchool.Type;
                    appDocumentPerSchool = x;
                }
            }

            _context.SaveChanges();
            return appDocumentPerSchool;
        }

        public List<AppDocumentPerSchool> UploadFewDocumentsPerSchool(List<AppDocumentPerSchool> lists, string nameFolder, string uniqueCodeID, int userId, int? customerId)
        {
            int i = 0;
            string name = "";
            AppFolder f = null;

            if (uniqueCodeID != null && uniqueCodeID != "" && uniqueCodeID != "0")
            {
                List<AppDocumentPerSchool> lst = new List<AppDocumentPerSchool>();
                AppDocumentPerSchool appDocumentPerSchool;
                int? appUserPerSchoolId;
                int? tabRequiredDocumentPerSchoolId = null;

                if (customerId == 0)
                    customerId = null;

                //היוזר פר סקול של הלקוח 
                List<AppUserPerSchool> appUserPerSchools = _context.AppUserPerSchools.Where(w => w.UserId == userId).ToList();
                //הדרוש של הקבצים המועלים
                TabRequiredDocumentPerSchool tabRequiredDocumentPerSchool = _context.TabRequiredDocumentPerSchools.Include(i => i.UniqueCode.TabRequiredDocumentPerSchools).FirstOrDefault(w => w.IdrequiredDocumentPerSchool == lists[0].RequiredDocumentPerSchoolId);
                //המוסדות התואמים אליהם צריך להעלות את הקבצים
                List<AppSchool> AppSchools = _context.AppSchools.Where(w => w.CoordinationCode == uniqueCodeID).ToList();
                int? UniqueCode = null;
                bool isFirstTime = true;
                List<int?> ListUnique = new List<int?>();
                int index = 0;
                bool flag = false;

                //מעבר על הקורסים התואמים
                AppSchools.ForEach(fe =>
                {
                    index = 0;
                    f = null;
                    //היוזר פר סקול של הסקול הנוכחי והלקוח
                    appUserPerSchoolId = appUserPerSchools.FirstOrDefault(f => f.SchoolId == fe.Idschool)?.IduserPerSchool;
                    tabRequiredDocumentPerSchoolId = null;

                    //אם זה עידכון של קובץ בודד תואם / או עידכון של קובץ תואם מתיקיה
                    if (lists.Count == 1 && (lists[0].IddocumentPerSchool != null && lists[0].IddocumentPerSchool > 0))
                    {
                        appDocumentPerSchool = _context.AppDocumentPerSchools.Include(i => i.Folder).FirstOrDefault(r => r.SchoolId == fe.Idschool && r.UniqueCodeId == lists[0].UniqueCodeId);

                        if (appDocumentPerSchool != null)
                        {
                            if (appDocumentPerSchool.Folder != null)
                            {
                                f = appDocumentPerSchool.Folder;
                                if (f != null)
                                    f.IndexFile = f.IndexFile + lists.Count;
                            }
                            appDocumentPerSchool.Path = lists[0].Path;
                            appDocumentPerSchool.Type = lists[0].Type;
                            appDocumentPerSchool.DateUpdated = DateTime.Today;
                            appDocumentPerSchool.UserUpdatedId = appUserPerSchoolId;
                            appDocumentPerSchool.Name = lists[0].Name;
                            //appDocumentPerSchool.Folder = f;
                        }
                        _context.SaveChanges();
                        lst.Add(appDocumentPerSchool);
                    }

                    else
                    {


                        //חיפוש הדרוש של המוסד הנוכחי
                        if (tabRequiredDocumentPerSchool != null && tabRequiredDocumentPerSchool.SchoolId != fe.Idschool && tabRequiredDocumentPerSchool.UniqueCode != null && tabRequiredDocumentPerSchool.UniqueCode.TabRequiredDocumentPerSchools != null && tabRequiredDocumentPerSchool.UniqueCode.TabRequiredDocumentPerSchools.Count > 0)
                        {
                            var tabRequired = tabRequiredDocumentPerSchool.UniqueCode.TabRequiredDocumentPerSchools.FirstOrDefault(f => f.SchoolId == fe.Idschool);
                            if (tabRequired != null)
                            {
                                tabRequiredDocumentPerSchoolId = tabRequired.IdrequiredDocumentPerSchool;
                                if (tabRequired.UniqueCodeId != tabRequiredDocumentPerSchool.UniqueCodeId)
                                {
                                    tabRequired.UniqueCodeId = tabRequiredDocumentPerSchool.UniqueCodeId;
                                    _context.SaveChanges();
                                }
                            }
                        }

                        //באם לא קיים הדרוש למוסד הנוכחי
                        if (tabRequiredDocumentPerSchool != null && (tabRequiredDocumentPerSchoolId == null || tabRequiredDocumentPerSchoolId == 0))
                        {
                            if (tabRequiredDocumentPerSchool.SchoolId == fe.Idschool)
                                tabRequiredDocumentPerSchoolId = tabRequiredDocumentPerSchool.IdrequiredDocumentPerSchool;

                            else
                            {
                                if (tabRequiredDocumentPerSchool != null)
                                {
                                    if (tabRequiredDocumentPerSchool.UniqueCodeId == null || tabRequiredDocumentPerSchool.UniqueCodeId == 0)
                                    {
                                        var unique = new AppUniqueCode() { CustomerId = customerId, DateCreated = DateTime.Today };
                                        _context.AppUniqueCodes.Add(unique);
                                        _context.SaveChanges();
                                        tabRequiredDocumentPerSchool.UniqueCodeId = unique.IduniqueCode;


                                    }
                                    var tabRequired = new TabRequiredDocumentPerSchool()
                                    {
                                        DateCreated = DateTime.Today,
                                        Name = tabRequiredDocumentPerSchool.Name,
                                        SchoolId = fe.Idschool,
                                        UniqueCodeId = tabRequiredDocumentPerSchool.UniqueCodeId,
                                        UserCreatedId = appUserPerSchoolId
                                    };
                                    _context.TabRequiredDocumentPerSchools.Add(tabRequired);
                                    _context.SaveChanges();
                                    tabRequiredDocumentPerSchoolId = tabRequired.IdrequiredDocumentPerSchool;
                                }
                                else
                                    tabRequiredDocumentPerSchoolId = null;
                            }
                        }


                        {
                            //אם זה העלאה ראשונית לאותו דרוש
                            if (lists.Count > 1 && (lists[0].FolderId == null || lists[0].FolderId == 0))
                            {
                                f = new AppFolder() { SchoolId = fe.Idschool, Name = nameFolder, DateCreated = DateTime.UtcNow.AddHours(3), UserCreatedId = appUserPerSchoolId, IndexFile = lists.Count };
                                _context.AppFolders.Add(f);
                                _context.SaveChanges();
                            }

                            else
                            if (lists[0].FolderId != null && lists[0].FolderId > 0)
                            {
                                int? folderId = 0;
                                folderId = _context.AppDocumentPerSchools.FirstOrDefault(f => f.RequiredDocumentPerSchoolId == tabRequiredDocumentPerSchoolId && f.SchoolId == fe.Idschool && f.ExsistDocumentId == lists[0].ExsistDocumentId)?.FolderId;
                                if (folderId != null && folderId > 0)
                                {
                                    f = _context.AppFolders.FirstOrDefault(f => f.IdFolder == folderId);
                                    if (f != null)
                                        f.IndexFile = f.IndexFile + lists.Count;
                                }

                            }
                        }

                        //פתיחה הקבצים לכל המוסדות התואמים
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


                            appDocumentPerSchool = new AppDocumentPerSchool();
                            if (f != null)
                            {

                                appDocumentPerSchool.FolderId = f.IdFolder;
                                appDocumentPerSchool.Folder = f;
                            }
                            if (lists.Count() == 1 && lists[0].IddocumentPerSchool == 0)
                            {
                                if (f == null)
                                {
                                    var x = _context.AppDocumentPerSchools.FirstOrDefault(f => f.RequiredDocumentPerSchoolId == tabRequiredDocumentPerSchoolId);
                                    if (x != null)
                                    {
                                        appDocumentPerSchool.FolderId = x.FolderId;
                                        flag = true;
                                    }
                                }
                            }
                            appDocumentPerSchool.SchoolId = fe.Idschool;
                            appDocumentPerSchool.Path = fo.Path;
                            appDocumentPerSchool.DateCreated = DateTime.Today;
                            appDocumentPerSchool.UserCreatedId = appUserPerSchoolId;
                            //appDocumentPerSchool.DateUpdated = DateTime.Today;
                            //appDocumentPerSchool.UserUpdated = appUserPerSchoolId;
                            appDocumentPerSchool.Type = fo.Type;
                            appDocumentPerSchool.RequiredDocumentPerSchoolId = tabRequiredDocumentPerSchoolId;
                            appDocumentPerSchool.Name = fo.Name;
                            appDocumentPerSchool.UniqueCodeId = UniqueCode;
                            appDocumentPerSchool.ExsistDocumentId = fo.ExsistDocumentId;

                            i = fo.Name.IndexOf('.');
                            if (i > -1)
                            {
                                name = fo.Name.Substring(0, i);
                                if (name != null && name != "")
                                {
                                    appDocumentPerSchool.Name = name;
                                }
                            }

                            lst.Add(appDocumentPerSchool);
                            index++;
                        });
                    }

                    isFirstTime = false;

                });
                _context.AppDocumentPerSchools.AddRange(lst.Where(w => w.IddocumentPerSchool == null || w.IddocumentPerSchool == 0));
                _context.SaveChanges();
                lists = lst.Where(w => w.SchoolId == lists[0].SchoolId).ToList();
                if (flag)
                {
                    lists[0].Folder = new AppFolder() { Name = nameFolder };
                }
            }
            else
            {

                if (lists.Count > 1 && (lists[0].FolderId == null || lists[0].FolderId == 0))
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

                if (lists.Count == 1 && lists[0].IddocumentPerSchool > 0)
                {
                    var doc = _context.AppDocumentPerSchools.FirstOrDefault(f => f.IddocumentPerSchool == lists[0].IddocumentPerSchool);
                    if (doc != null)
                    {
                        doc.Name = lists[0].Name;
                        doc.Type = lists[0].Type;
                        doc.UserUpdatedId = lists[0].UserUpdatedId;
                        doc.DateUpdated = lists[0].DateUpdated;
                        doc.Path = lists[0].Path;
                        doc.Folder = f;
                    }
                    lists = new List<AppDocumentPerSchool>() { doc };
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
                    _context.AppDocumentPerSchools.AddRange(lists);
                }
                _context.SaveChanges();
            }


            return lists;
        }



    }
}
