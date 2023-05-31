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
    public class DocumentPerFatherCourseRepository : IDocumentPerFatherCourseRepository
    {
        private readonly ExtraSchoolContext _context;

        public DocumentPerFatherCourseRepository(ExtraSchoolContext context)
        {
            _context = context;
        }


        public string DeleteDocumentPerFatherCourse(int idDocumentPerFatherCourse, int idFatherCourse, int uniqueCodeDocumentId)
        {
            string s = "";

            if (idDocumentPerFatherCourse != 0 && idDocumentPerFatherCourse != null)
            {

                var x = _context.AppDocumentPerFatherCourses.Include(i => i.RequiredDocumentPerFatherCourse).FirstOrDefault(f => f.IddocumentPerFatherCourse == idDocumentPerFatherCourse);
                if (x != null)
                {

                    s = x.RequiredDocumentPerFatherCourse != null ? x.RequiredDocumentPerFatherCourse.Name : x.Name;
                    //---------
                    var fold = x.Folder;
                    if (uniqueCodeDocumentId != 0)
                    {
                        deleteDocumentsPerFatherCourseOfUniqueCode(uniqueCodeDocumentId);
                    }
                    else
                    {
                        //---------
                        _context.AppDocumentPerFatherCourses.Remove(x);
                        _context.SaveChanges();
                        if (fold != null && fold.AppDocumentPerFatherCourses.Count == 1)
                            fold.AppDocumentPerFatherCourses.ToList()[0].FolderId = null;
                        _context.SaveChanges();

                    }
                }
            }
            return s;
        }

        public AppDocumentPerFatherCourse DeleteFewDocumentPerFatherCourse(int idFolder, int requiredDocumentPerFatherCourseId, int idFatherCourse, int uniqueCodeDocumentId)
        {
            AppDocumentPerFatherCourse t = null;
            AppFolder appFolder = _context.AppFolders.Include(i => i.AppDocumentPerFatherCourses).FirstOrDefault(f => f.IdFolder == idFolder);
            List<AppDocumentPerFatherCourse> AppDocumentPerFatherCourse = new List<AppDocumentPerFatherCourse>();
            if (appFolder != null && appFolder.AppDocumentPerFatherCourses != null)
            {
                appFolder.AppDocumentPerFatherCourses.ToList().ForEach(f =>
                {
                    if (f.UniqueCodeId != null && f.UniqueCodeId > 0)
                        deleteDocumentsPerFatherCourseOfUniqueCode((int)f.UniqueCodeId);
                    else
                    {
                        AppDocumentPerFatherCourse.Add(f);
                    }

                });
                _context.AppFolders.Remove(appFolder);
                _context.SaveChanges();
                if (AppDocumentPerFatherCourse.Count > 0)
                {
                    _context.AppDocumentPerFatherCourses.RemoveRange(AppDocumentPerFatherCourse);
                    _context.SaveChanges();
                }
            }

            if (requiredDocumentPerFatherCourseId != null && requiredDocumentPerFatherCourseId > 0)
            {
                var tab = _context.TabRequiredDocumentPerFatherCourses.FirstOrDefault(f => f.IdrequiredDocumentPerFatherCourse == requiredDocumentPerFatherCourseId);
                if (tab != null)
                {
                    t = new AppDocumentPerFatherCourse();
                    t.RequiredDocumentPerFatherCourseId = tab.IdrequiredDocumentPerFatherCourse;
                    t.Name = tab.Name;
                }
            }

            return t;
        }

        public List<AppDocumentPerFatherCourse> GetLstDocumentPerFatherCourse(int FatherCourseId, int schollId)
        {
            List<AppDocumentPerFatherCourse> lstDoc = new List<AppDocumentPerFatherCourse>();
            var docPerFatherCourse = _context.AppDocumentPerFatherCourses.Include(i => i.Folder).Where(w => w.FatherCourseId == FatherCourseId).ToList();
            var docRequiredPerFatherCourse = _context.TabRequiredDocumentPerFatherCourses.Where(w => w.SchoolId == schollId);
            if (docPerFatherCourse == null)
                docPerFatherCourse = new List<AppDocumentPerFatherCourse>();
            foreach (var doc in docRequiredPerFatherCourse)
            {
                if (docPerFatherCourse.FirstOrDefault(f => f.RequiredDocumentPerFatherCourseId == doc.IdrequiredDocumentPerFatherCourse) == null)
                    docPerFatherCourse.Add(new AppDocumentPerFatherCourse() { Name = doc.Name, RequiredDocumentPerFatherCourseId = doc.IdrequiredDocumentPerFatherCourse });
            }
            return docPerFatherCourse;
        }

        public void SaveNameFile(int idfile, string nameFile, int uniqeId)
        {
            if (uniqeId != null && uniqeId > 0)
            {
                List<AppDocumentPerFatherCourse> lst = _context.AppDocumentPerFatherCourses.Where(f => f.UniqueCodeId == uniqeId).ToList();
                if (lst != null && lst.Count > 0)
                {
                    lst.ForEach(f => f.Name = nameFile);
                    _context.SaveChanges();
                }
            }
            else
            {
                var x = _context.AppDocumentPerFatherCourses.FirstOrDefault(f => f.IddocumentPerFatherCourse == idfile);
                if (x != null)
                {
                    x.Name = nameFile;
                    _context.SaveChanges();
                }
            }
        }

        public void deleteDocumentsPerFatherCourseOfUniqueCode(int uniqueCodeDocumentId)
        {
            if (uniqueCodeDocumentId != null && uniqueCodeDocumentId != 0)
            {
                var x = _context.AppUniqueCodes.Include(i => i.AppDocumentPerFatherCourses).FirstOrDefault(f => f.IduniqueCode == uniqueCodeDocumentId);
                if (x != null)
                {
                    //---------
                    if (x.AppDocumentPerFatherCourses != null)
                    {
                        x.AppDocumentPerFatherCourses.ToList().ForEach(f =>
                        {
                            AppFolder fold = f.Folder;

                            _context.AppDocumentPerFatherCourses.Remove(f);
                            _context.SaveChanges();

                            if (fold != null && fold.AppDocumentPerFatherCourses.Count == 1)
                                fold.AppDocumentPerFatherCourses.ToList()[0].FolderId = null;
                         });
                        _context.SaveChanges();
                    }
                    _context.AppUniqueCodes.Remove(x);
                    _context.SaveChanges();

                }
            }
        }

        public AppDocumentPerFatherCourse UploadDocumentPerFatherCourse(AppDocumentPerFatherCourse appDocumentPerFatherCourse, int uniqueCodeID)
        {
            appDocumentPerFatherCourse.Folder = null;
            //מסמך חדש
            if (appDocumentPerFatherCourse.IddocumentPerFatherCourse == 0)
                _context.AppDocumentPerFatherCourses.Add(appDocumentPerFatherCourse);
            //עידכון מסמך קיים
            else
            {
                var x = _context.AppDocumentPerFatherCourses.Include(i => i.Folder).FirstOrDefault(f => f.IddocumentPerFatherCourse == appDocumentPerFatherCourse.IddocumentPerFatherCourse);
                if (x != null)
                {
                    x.DateUpdated = appDocumentPerFatherCourse.DateUpdated;
                    x.UserUpdatedId = appDocumentPerFatherCourse.UserUpdatedId;
                    x.Path = appDocumentPerFatherCourse.Path;
                    x.Name = appDocumentPerFatherCourse.Name;
                    x.Type = appDocumentPerFatherCourse.Type;
                    appDocumentPerFatherCourse = x;
                }
            }

            _context.SaveChanges();
            return appDocumentPerFatherCourse;
        }

        public List<AppDocumentPerFatherCourse> UploadFewDocumentsPerFatherCourse(List<AppDocumentPerFatherCourse> lists, string nameFolder, int uniqueCodeID, int userId, int? customerId)
        {
            int i = 0;
            string name = "";
            AppFolder f = null;

            if (uniqueCodeID != 0)
            {
                List<AppDocumentPerFatherCourse> lst = new List<AppDocumentPerFatherCourse>();
                AppDocumentPerFatherCourse appDocumentPerFatherCourse;
                int? appUserPerSchoolId;
                int? tabRequiredDocumentPerFatherCourseId = null;

                if (customerId == 0)
                    customerId = null;

                //היוזר פר סקול של הלקוח 
                List<AppUserPerSchool> appUserPerSchools = _context.AppUserPerSchools.Where(w => w.UserId == userId).ToList();
                //הדרוש של הקבצים המועלים
                TabRequiredDocumentPerFatherCourse tabRequiredDocumentPerFatherCourse = _context.TabRequiredDocumentPerFatherCourses.Include(i => i.UniqueCode.TabRequiredDocumentPerFatherCourses).FirstOrDefault(w => w.IdrequiredDocumentPerFatherCourse == lists[0].RequiredDocumentPerFatherCourseId);
                //הקורסים התואמים אליהם צריך להעלות את הקבצים
                List<AppCourse> appCourses = _context.AppCourses.Where(w => w.UniqueCodeId == uniqueCodeID).ToList();
                int? UniqueCode = null;
                bool isFirstTime = true;
                List<int?> ListUnique = new List<int?>();
                int index = 0;
                bool flag = false;

                //מעבר על הקורסים התואמים
                appCourses.ForEach(fe =>
                {
                    index = 0;
                    f = null;
                    //היוזר פר סקול של הסקול הנוכחי והלקוח
                    appUserPerSchoolId = appUserPerSchools.FirstOrDefault(f => f.SchoolId == fe.SchoolId)?.IduserPerSchool;
                    tabRequiredDocumentPerFatherCourseId = null;

                    //אם זה עידכון של קובץ בודד תואם / או עידכון של קובץ תואם מתיקיה
                    if (lists.Count == 1 && (lists[0].IddocumentPerFatherCourse != null && lists[0].IddocumentPerFatherCourse > 0))
                    {
                        appDocumentPerFatherCourse = _context.AppDocumentPerFatherCourses.Include(i => i.Folder).FirstOrDefault(r => r.SchoolId == fe.SchoolId && r.FatherCourseId == fe.Idcourse && r.UniqueCodeId == lists[0].UniqueCodeId);

                        if (appDocumentPerFatherCourse != null)
                        {
                            if (appDocumentPerFatherCourse.Folder != null)
                            {
                                f = appDocumentPerFatherCourse.Folder;
                                if (f != null)
                                    f.IndexFile = f.IndexFile + lists.Count;
                            }
                            appDocumentPerFatherCourse.Path = lists[0].Path;
                            appDocumentPerFatherCourse.Type = lists[0].Type;
                            appDocumentPerFatherCourse.DateUpdated = DateTime.Today;
                            appDocumentPerFatherCourse.UserUpdatedId = appUserPerSchoolId;
                            appDocumentPerFatherCourse.Name = lists[0].Name;
                            //appDocumentPerFatherCourse.Folder = f;
                        }
                        _context.SaveChanges();
                        lst.Add(appDocumentPerFatherCourse);
                    }

                    else
                    {


                        //חיפוש הדרוש של המוסד הנוכחי
                        if (tabRequiredDocumentPerFatherCourse != null && tabRequiredDocumentPerFatherCourse.SchoolId != fe.SchoolId && tabRequiredDocumentPerFatherCourse.UniqueCode != null && tabRequiredDocumentPerFatherCourse.UniqueCode.TabRequiredDocumentPerFatherCourses != null && tabRequiredDocumentPerFatherCourse.UniqueCode.TabRequiredDocumentPerFatherCourses.Count > 0)
                        {
                            var tabRequired = tabRequiredDocumentPerFatherCourse.UniqueCode.TabRequiredDocumentPerFatherCourses.FirstOrDefault(f => f.SchoolId == fe.SchoolId);
                            if (tabRequired != null)
                            {
                                tabRequiredDocumentPerFatherCourseId = tabRequired.IdrequiredDocumentPerFatherCourse;
                                if (tabRequired.UniqueCodeId != tabRequiredDocumentPerFatherCourse.UniqueCodeId)
                                {
                                    tabRequired.UniqueCodeId = tabRequiredDocumentPerFatherCourse.UniqueCodeId;
                                    _context.SaveChanges();
                                }
                            }
                        }

                        //באם לא קיים הדרוש למוסד הנוכחי
                        if (tabRequiredDocumentPerFatherCourse != null && (tabRequiredDocumentPerFatherCourseId == null || tabRequiredDocumentPerFatherCourseId == 0))
                        {
                            if (tabRequiredDocumentPerFatherCourse.SchoolId == fe.SchoolId)
                                tabRequiredDocumentPerFatherCourseId = tabRequiredDocumentPerFatherCourse.IdrequiredDocumentPerFatherCourse;

                            else
                            {
                                if (tabRequiredDocumentPerFatherCourse != null)
                                {
                                    if (tabRequiredDocumentPerFatherCourse.UniqueCodeId == null || tabRequiredDocumentPerFatherCourse.UniqueCodeId == 0)
                                    {
                                        var unique = new AppUniqueCode() { CustomerId = customerId, DateCreated = DateTime.Today };
                                        _context.AppUniqueCodes.Add(unique);
                                        _context.SaveChanges();
                                        tabRequiredDocumentPerFatherCourse.UniqueCodeId = unique.IduniqueCode;


                                    }
                                    var tabRequired = new TabRequiredDocumentPerFatherCourse()
                                    {
                                        DateCreated = DateTime.Today,
                                        Name = tabRequiredDocumentPerFatherCourse.Name,
                                        SchoolId = fe.SchoolId,
                                        UniqueCodeId = tabRequiredDocumentPerFatherCourse.UniqueCodeId,
                                        UserCreatedId = appUserPerSchoolId
                                    };
                                    _context.TabRequiredDocumentPerFatherCourses.Add(tabRequired);
                                    _context.SaveChanges();
                                    tabRequiredDocumentPerFatherCourseId = tabRequired.IdrequiredDocumentPerFatherCourse;
                                }
                                else
                                    tabRequiredDocumentPerFatherCourseId = null;
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
                                folderId = _context.AppDocumentPerFatherCourses.FirstOrDefault(f => f.RequiredDocumentPerFatherCourseId == tabRequiredDocumentPerFatherCourseId && f.SchoolId == fe.SchoolId && f.ExsistDocumentId == lists[0].ExsistDocumentId)?.FolderId;
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


                                appDocumentPerFatherCourse = new AppDocumentPerFatherCourse();
                                if (f != null)
                                {

                                    appDocumentPerFatherCourse.FolderId = f.IdFolder;
                                    appDocumentPerFatherCourse.Folder = f;
                                }
                                if (lists.Count() == 1 && lists[0].IddocumentPerFatherCourse == 0)
                                {
                                    if (f == null)
                                    {
                                        var x = _context.AppDocumentPerFatherCourses.FirstOrDefault(f => f.RequiredDocumentPerFatherCourseId == tabRequiredDocumentPerFatherCourseId);
                                        if (x != null)
                                        {
                                            appDocumentPerFatherCourse.FolderId = x.FolderId;
                                            flag = true;
                                        }
                                    }
                                }
                                appDocumentPerFatherCourse.SchoolId = fe.SchoolId;
                                appDocumentPerFatherCourse.Path = fo.Path;
                                appDocumentPerFatherCourse.FatherCourseId = fe.Idcourse;
                                appDocumentPerFatherCourse.DateCreated = DateTime.Today;
                                appDocumentPerFatherCourse.UserCreatedId = appUserPerSchoolId;
                                //appDocumentPerFatherCourse.DateUpdated = DateTime.Today;
                                //appDocumentPerFatherCourse.UserUpdated = appUserPerSchoolId;
                                appDocumentPerFatherCourse.Type = fo.Type;
                                appDocumentPerFatherCourse.RequiredDocumentPerFatherCourseId = tabRequiredDocumentPerFatherCourseId;
                                appDocumentPerFatherCourse.Name = fo.Name;
                                appDocumentPerFatherCourse.UniqueCodeId = UniqueCode;
                                appDocumentPerFatherCourse.ExsistDocumentId = fo.ExsistDocumentId;

                                i = fo.Name.IndexOf('.');
                                if (i > -1)
                                {
                                    name = fo.Name.Substring(0, i);
                                    if (name != null && name != "")
                                    {
                                        appDocumentPerFatherCourse.Name = name;
                                    }
                                }

                                lst.Add(appDocumentPerFatherCourse);
                                index++;
                            });
                    }

                    isFirstTime = false;

                });
                _context.AppDocumentPerFatherCourses.AddRange(lst.Where(w => w.IddocumentPerFatherCourse == null || w.IddocumentPerFatherCourse == 0));
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

                if (lists.Count == 1 && lists[0].IddocumentPerFatherCourse > 0)
                {
                    var doc = _context.AppDocumentPerFatherCourses.FirstOrDefault(f => f.IddocumentPerFatherCourse == lists[0].IddocumentPerFatherCourse);
                    if (doc != null)
                    {
                        doc.Name = lists[0].Name;
                        doc.Type = lists[0].Type;
                        doc.UserUpdatedId = lists[0].UserUpdatedId;
                        doc.DateUpdated = lists[0].DateUpdated;
                        doc.Path = lists[0].Path;
                        doc.Folder = f;
                    }
                    lists = new List<AppDocumentPerFatherCourse>() { doc };
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
                    _context.AppDocumentPerFatherCourses.AddRange(lists);
                }
                _context.SaveChanges();
            }


            return lists;
        }
    }
}
