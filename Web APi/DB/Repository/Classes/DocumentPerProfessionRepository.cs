using DB.Model;
using DB.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DB.Repository.Classes
{
    public class DocumentPerProfessionRepository: IDocumentPerProfessionRepository
    {
        private readonly ExtraSchoolContext _context;

        public DocumentPerProfessionRepository(ExtraSchoolContext context)
        {
            _context = context;
        }

        public string DeleteDocumentPerProfession(int idDocumentPerProfession, int idProfession, int uniqueCodeDocumentId)
        {
            string s = "";

            if (idDocumentPerProfession != 0 && idDocumentPerProfession != null)
            {

                var x = _context.AppDocumentPerProfessions.Include(i => i.RequiredDocumentPerProfession).FirstOrDefault(f => f.IddocumentPerProfession == idDocumentPerProfession);
                if (x != null)
                {
                    s = x.RequiredDocumentPerProfession != null ? x.RequiredDocumentPerProfession.Name : x.Name;
                    if (uniqueCodeDocumentId != 0)
                    {
                        deleteDocumentsPerProfessionOfUniqueCode(uniqueCodeDocumentId);
                    }
                    else
                    {
                        _context.AppDocumentPerProfessions.Remove(x);
                        _context.SaveChanges();
                    }
                }
            }
            return s;
        }

        public AppDocumentPerProfession DeleteFewDocumentPerProfession(int idFolder, int requiredDocumentPerProfessionId, int idProfession, int uniqueCodeDocumentId)
        {
            AppDocumentPerProfession t = null;
            AppFolder appFolder = _context.AppFolders.Include(i => i.AppDocumentPerProfessions).FirstOrDefault(f => f.IdFolder == idFolder);
            List<AppDocumentPerProfession> AppDocumentPerProfession = new List<AppDocumentPerProfession>();
            if (appFolder != null && appFolder.AppDocumentPerProfessions != null)
            {
                appFolder.AppDocumentPerProfessions.ToList().ForEach(f =>
                {
                    if (f.UniqueCodeId != null && f.UniqueCodeId > 0)
                        deleteDocumentsPerProfessionOfUniqueCode((int)f.UniqueCodeId);
                    else
                    {
                        AppDocumentPerProfession.Add(f);
                    }

                });
                _context.AppFolders.Remove(appFolder);
                _context.SaveChanges();
                if (AppDocumentPerProfession.Count > 0)
                {
                    _context.AppDocumentPerProfessions.RemoveRange(AppDocumentPerProfession);
                    _context.SaveChanges();
                }
            }

            if (requiredDocumentPerProfessionId != null && requiredDocumentPerProfessionId > 0)
            {
                var tab = _context.TabRequiredDocumentPerProfessions.FirstOrDefault(f => f.IdrequiredDocumentPerProfession == requiredDocumentPerProfessionId);
                if (tab != null)
                {
                    t = new AppDocumentPerProfession();
                    t.RequiredDocumentPerProfessionId = tab.IdrequiredDocumentPerProfession;
                    t.Name = tab.Name;
                }
            }

            return t;
        }

        public List<AppDocumentPerProfession> GetLstDocumentPerProfession(int ProfessionId, int schollId)
        {
            List<AppDocumentPerProfession> lstDoc = new List<AppDocumentPerProfession>();
            var docPerProfession = _context.AppDocumentPerProfessions.Include(i => i.Folder).Where(w => w.ProfessionId == ProfessionId).ToList();
            var docRequiredPerProfession = _context.TabRequiredDocumentPerProfessions.Where(w => w.SchoolId == schollId);
            if (docPerProfession == null)
                docPerProfession = new List<AppDocumentPerProfession>();
            foreach (var doc in docRequiredPerProfession)
            {
                if (docPerProfession.FirstOrDefault(f => f.RequiredDocumentPerProfessionId == doc.IdrequiredDocumentPerProfession) == null)
                    docPerProfession.Add(new AppDocumentPerProfession() { Name = doc.Name, RequiredDocumentPerProfessionId = doc.IdrequiredDocumentPerProfession });
            }
            return docPerProfession;
        }

        public void SaveNameFile(int idfile, string nameFile, int uniqeId)
        {
            if (uniqeId != null && uniqeId > 0)
            {
                List<AppDocumentPerProfession> lst = _context.AppDocumentPerProfessions.Where(f => f.UniqueCodeId == uniqeId).ToList();
                if (lst != null && lst.Count > 0)
                {
                    lst.ForEach(f => f.Name = nameFile);
                    _context.SaveChanges();
                }
            }
            else
            {
                var x = _context.AppDocumentPerProfessions.FirstOrDefault(f => f.IddocumentPerProfession == idfile);
                if (x != null)
                {
                    x.Name = nameFile;
                    _context.SaveChanges();
                }
            }
        }

        public void deleteDocumentsPerProfessionOfUniqueCode(int uniqueCodeDocumentId)
        {
            if (uniqueCodeDocumentId != null && uniqueCodeDocumentId != 0)
            {
                var x = _context.AppUniqueCodes.Include(i => i.AppDocumentPerProfessions).FirstOrDefault(f => f.IduniqueCode == uniqueCodeDocumentId);
                if (x != null)
                {
                    if (x.AppDocumentPerProfessions != null)
                    {
                        _context.AppDocumentPerProfessions.RemoveRange(x.AppDocumentPerProfessions);
                        _context.SaveChanges();
                    }
                    _context.AppUniqueCodes.Remove(x);
                    _context.SaveChanges();

                }
            }
        }

        public AppDocumentPerProfession UploadDocumentPerProfession(AppDocumentPerProfession appDocumentPerProfession, int uniqueCodeID)
        {
            appDocumentPerProfession.Folder = null;
            //מסמך חדש
            if (appDocumentPerProfession.IddocumentPerProfession == 0)
            {
                appDocumentPerProfession.Folder = null;
                appDocumentPerProfession.FolderId = null;
                _context.AppDocumentPerProfessions.Add(appDocumentPerProfession);
            }
            //עידכון מסמך קיים
            else
            {
                var x = _context.AppDocumentPerProfessions.Include(i => i.Folder).FirstOrDefault(f => f.IddocumentPerProfession == appDocumentPerProfession.IddocumentPerProfession);
                if (x != null)
                {
                    x.DateUpdated = appDocumentPerProfession.DateUpdated;
                    x.UserUpdatedId = appDocumentPerProfession.UserUpdatedId;
                    x.Path = appDocumentPerProfession.Path;
                    x.Name = appDocumentPerProfession.Name;
                    x.Type = appDocumentPerProfession.Type;
                    appDocumentPerProfession = x;
                }
            }

            _context.SaveChanges();
            return appDocumentPerProfession;
        }

        public List<AppDocumentPerProfession> UploadFewDocumentsPerProfession(List<AppDocumentPerProfession> lists, string nameFolder, int uniqueCodeID, int userId, int? customerId)
        {
            int i = 0;
            string name = "";
            AppFolder f = null;

            if (uniqueCodeID != 0)
            {
                List<AppDocumentPerProfession> lst = new List<AppDocumentPerProfession>();
                AppDocumentPerProfession appDocumentPerProfession;
                int? appUserPerSchoolId;
                int? tabRequiredDocumentPerProfessionId = null;

                if (customerId == 0)
                    customerId = null;

                //היוזר פר סקול של הלקוח 
                List<AppUserPerSchool> appUserPerSchools = _context.AppUserPerSchools.Where(w => w.UserId == userId).ToList();
                //הדרוש של הקבצים המועלים
                TabRequiredDocumentPerProfession tabRequiredDocumentPerProfession = _context.TabRequiredDocumentPerProfessions.Include(i => i.UniqueCode.TabRequiredDocumentPerProfessions).FirstOrDefault(w => w.IdrequiredDocumentPerProfession == lists[0].RequiredDocumentPerProfessionId);
                //הקורסים התואמים אליהם צריך להעלות את הקבצים
                List<AppProfession> AppProfessions = _context.AppProfessions.Where(w => w.UniqueCodeId == uniqueCodeID).ToList();
                int? UniqueCode = null;
                bool isFirstTime = true;
                List<int?> ListUnique = new List<int?>();
                int index = 0;
                bool flag = false;

                //מעבר על הקורסים התואמים
                AppProfessions.ForEach(fe =>
                {
                    index = 0;
                    f = null;
                    //היוזר פר סקול של הסקול הנוכחי והלקוח
                    appUserPerSchoolId = appUserPerSchools.FirstOrDefault(f => f.SchoolId == fe.SchoolId)?.IduserPerSchool;
                    tabRequiredDocumentPerProfessionId = null;

                    //אם זה עידכון של קובץ בודד תואם / או עידכון של קובץ תואם מתיקיה
                    if (lists.Count == 1 && (lists[0].IddocumentPerProfession != null && lists[0].IddocumentPerProfession > 0))
                    {
                        appDocumentPerProfession = _context.AppDocumentPerProfessions.Include(i => i.Folder).FirstOrDefault(r => r.SchoolId == fe.SchoolId && r.ProfessionId == fe.Idprofession && r.UniqueCodeId == lists[0].UniqueCodeId);

                        if (appDocumentPerProfession != null)
                        {
                            if (appDocumentPerProfession.Folder != null)
                            {
                                f = appDocumentPerProfession.Folder;
                                if (f != null)
                                    f.IndexFile = f.IndexFile + lists.Count;
                            }
                            appDocumentPerProfession.Path = lists[0].Path;
                            appDocumentPerProfession.Type = lists[0].Type;
                            appDocumentPerProfession.DateUpdated = DateTime.Today;
                            appDocumentPerProfession.UserUpdatedId = appUserPerSchoolId;
                            appDocumentPerProfession.Name = lists[0].Name;
                            //appDocumentPerProfession.Folder = f;
                        }
                        _context.SaveChanges();
                        lst.Add(appDocumentPerProfession);
                    }

                    else
                    {


                        //חיפוש הדרוש של המוסד הנוכחי
                        if (tabRequiredDocumentPerProfession != null && tabRequiredDocumentPerProfession.SchoolId != fe.SchoolId && tabRequiredDocumentPerProfession.UniqueCode != null && tabRequiredDocumentPerProfession.UniqueCode.TabRequiredDocumentPerProfessions != null && tabRequiredDocumentPerProfession.UniqueCode.TabRequiredDocumentPerProfessions.Count > 0)
                        {
                            var tabRequired = tabRequiredDocumentPerProfession.UniqueCode.TabRequiredDocumentPerProfessions.FirstOrDefault(f => f.SchoolId == fe.SchoolId);
                            if (tabRequired != null)
                            {
                                tabRequiredDocumentPerProfessionId = tabRequired.IdrequiredDocumentPerProfession;
                                if (tabRequired.UniqueCodeId != tabRequiredDocumentPerProfession.UniqueCodeId)
                                {
                                    tabRequired.UniqueCodeId = tabRequiredDocumentPerProfession.UniqueCodeId;
                                    _context.SaveChanges();
                                }
                            }
                        }

                        //באם לא קיים הדרוש למוסד הנוכחי
                        if (tabRequiredDocumentPerProfession != null && (tabRequiredDocumentPerProfessionId == null || tabRequiredDocumentPerProfessionId == 0))
                        {
                            if (tabRequiredDocumentPerProfession.SchoolId == fe.SchoolId)
                                tabRequiredDocumentPerProfessionId = tabRequiredDocumentPerProfession.IdrequiredDocumentPerProfession;

                            else
                            {
                                if (tabRequiredDocumentPerProfession != null)
                                {
                                    if (tabRequiredDocumentPerProfession.UniqueCodeId == null || tabRequiredDocumentPerProfession.UniqueCodeId == 0)
                                    {
                                        var unique = new AppUniqueCode() { CustomerId = customerId, DateCreated = DateTime.Today };
                                        _context.AppUniqueCodes.Add(unique);
                                        _context.SaveChanges();
                                        tabRequiredDocumentPerProfession.UniqueCodeId = unique.IduniqueCode;


                                    }
                                    var tabRequired = new TabRequiredDocumentPerProfession()
                                    {
                                        DateCreated = DateTime.Today,
                                        Name = tabRequiredDocumentPerProfession.Name,
                                        SchoolId = fe.SchoolId,
                                        UniqueCodeId = tabRequiredDocumentPerProfession.UniqueCodeId,
                                        UserCreatedId = appUserPerSchoolId
                                    };
                                    _context.TabRequiredDocumentPerProfessions.Add(tabRequired);
                                    _context.SaveChanges();
                                    tabRequiredDocumentPerProfessionId = tabRequired.IdrequiredDocumentPerProfession;
                                }
                                else
                                    tabRequiredDocumentPerProfessionId = null;
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
                                folderId = _context.AppDocumentPerProfessions.FirstOrDefault(f => f.RequiredDocumentPerProfessionId == tabRequiredDocumentPerProfessionId && f.SchoolId == fe.SchoolId)?.FolderId;
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


                            appDocumentPerProfession = new AppDocumentPerProfession();
                            if (f != null)
                            {

                                appDocumentPerProfession.FolderId = f.IdFolder;
                                appDocumentPerProfession.Folder = f;
                            }
                            if (lists.Count() == 1 && lists[0].IddocumentPerProfession == 0)
                            {
                                if (f == null)
                                {
                                    var x = _context.AppDocumentPerProfessions.FirstOrDefault(f => f.RequiredDocumentPerProfessionId == tabRequiredDocumentPerProfessionId);
                                    if (x != null)
                                    {
                                        appDocumentPerProfession.FolderId = x.FolderId;
                                        flag = true;
                                    }
                                }
                            }
                            appDocumentPerProfession.SchoolId = fe.SchoolId;
                            appDocumentPerProfession.Path = fo.Path;
                            appDocumentPerProfession.ProfessionId = fe.Idprofession;
                            appDocumentPerProfession.DateCreated = DateTime.Today;
                            appDocumentPerProfession.UserCreatedId = appUserPerSchoolId;
                            //appDocumentPerProfession.DateUpdated = DateTime.Today;
                            //appDocumentPerProfession.UserUpdated = appUserPerSchoolId;
                            appDocumentPerProfession.Type = fo.Type;
                            appDocumentPerProfession.RequiredDocumentPerProfessionId = tabRequiredDocumentPerProfessionId;
                            appDocumentPerProfession.Name = fo.Name;
                            appDocumentPerProfession.UniqueCodeId = UniqueCode;
                            appDocumentPerProfession.ExsistDocumentId = fo.ExsistDocumentId;

                            i = fo.Name.IndexOf('.');
                            if (i > -1)
                            {
                                name = fo.Name.Substring(0, i);
                                if (name != null && name != "")
                                {
                                    appDocumentPerProfession.Name = name;
                                }
                            }

                            lst.Add(appDocumentPerProfession);
                            index++;
                        });
                    }

                    isFirstTime = false;

                });
                _context.AppDocumentPerProfessions.AddRange(lst.Where(w => w.IddocumentPerProfession == null || w.IddocumentPerProfession == 0));
                _context.SaveChanges();
                lists = lst.Where(w => w.SchoolId == lists[0].SchoolId).ToList();
                if (flag)
                {
                    lists[0].Folder = new AppFolder() { Name = nameFolder };
                }
            }
            else
            {

                if (lists[0].FolderId == null || lists[0].FolderId == 0)
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

                if (lists.Count == 1 && lists[0].IddocumentPerProfession > 0)
                {
                    var doc = _context.AppDocumentPerProfessions.FirstOrDefault(f => f.IddocumentPerProfession == lists[0].IddocumentPerProfession);
                    if (doc != null)
                    {
                        doc.Name = lists[0].Name;
                        doc.Type = lists[0].Type;
                        doc.UserUpdated = lists[0].UserUpdated;
                        doc.DateUpdated = lists[0].DateUpdated;
                        doc.Path = lists[0].Path;
                        doc.Folder = f;
                    }
                    lists = new List<AppDocumentPerProfession>() { doc };
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
                    _context.AppDocumentPerProfessions.AddRange(lists);
                }
                _context.SaveChanges();
            }


            return lists;
        }

    }
}
