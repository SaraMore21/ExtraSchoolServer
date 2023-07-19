using DB.Model;
using DB.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DB.Repository.Classes
{
    public class DocumentPerTaskRepository: IDocumentPerTaskRepository
    {
        private readonly ExtraSchoolContext _context;

        public DocumentPerTaskRepository(ExtraSchoolContext context)
        {
            _context = context;
        }

        public string DeleteDocumentPerTask(int idDocumentPerTask, int idTask, int uniqueCodeDocumentId)
        {
            string s = "";

            if (idDocumentPerTask != 0 && idDocumentPerTask != null)
            {

                var x = _context.AppDocumentPerTasks.Include(i => i.RequiredDocumentPerTask).FirstOrDefault(f => f.IddocumentPerTask == idDocumentPerTask);
     
                if (x != null)
                {
                    //---------
                    var fold = x.Folder;
                    s = x.RequiredDocumentPerTask != null ? x.RequiredDocumentPerTask.Name : x.Name;
                    if (uniqueCodeDocumentId != 0)
                    {
                        deleteDocumentsPerTaskOfUniqueCode(uniqueCodeDocumentId);
                    }
                    else
                    {
                        //---------
                        _context.AppDocumentPerTasks.Remove(x);
                        _context.SaveChanges();
                        if (fold != null && fold.AppDocumentPerTasks.Count == 1)
                            fold.AppDocumentPerTasks.ToList()[0].FolderId = null;
                        _context.SaveChanges();
                    }
                }
            }
            return s;
        }

        public AppDocumentPerTask DeleteFewDocumentPerTask(int idFolder, int requiredDocumentPerTaskId, int idTask, int uniqueCodeDocumentId)
        {
            AppDocumentPerTask t = null;
            AppFolder appFolder = _context.AppFolders.Include(i => i.AppDocumentPerTasks).FirstOrDefault(f => f.IdFolder == idFolder);
            List<AppDocumentPerTask> AppDocumentPerTask = new List<AppDocumentPerTask>();
            if (appFolder != null && appFolder.AppDocumentPerTasks != null)
            {
                appFolder.AppDocumentPerTasks.ToList().ForEach(f =>
                {
                    if (f.UniqueCodeId != null && f.UniqueCodeId > 0)
                        deleteDocumentsPerTaskOfUniqueCode((int)f.UniqueCodeId);
                    else
                    {
                        AppDocumentPerTask.Add(f);
                    }

                });
                _context.AppFolders.Remove(appFolder);
                _context.SaveChanges();
                if (AppDocumentPerTask.Count > 0)
                {
                    _context.AppDocumentPerTasks.RemoveRange(AppDocumentPerTask);
                    _context.SaveChanges();
                }
            }

            if (requiredDocumentPerTaskId != null && requiredDocumentPerTaskId > 0)
            {
                var tab = _context.TabRequiredDocumentPerTasks.FirstOrDefault(f => f.IdrequiredDocumentPerTask == requiredDocumentPerTaskId);
                if (tab != null)
                {
                    t = new AppDocumentPerTask();
                    t.RequiredDocumentPerTaskId = tab.IdrequiredDocumentPerTask;
                    t.Name = tab.Name;
                }
            }

            return t;
        }

        public List<AppDocumentPerTask> GetLstDocumentPerTask(int TaskId, int schollId)
        {
            List<AppDocumentPerTask> lstDoc = new List<AppDocumentPerTask>();
            var docPerTask = _context.AppDocumentPerTasks.Include(i => i.Folder).Where(w => w.TaskId == TaskId).ToList();
            var docRequiredPerTask = _context.TabRequiredDocumentPerTasks.Where(w => w.SchoolId == schollId);
            if (docPerTask == null)
                docPerTask = new List<AppDocumentPerTask>();
            foreach (var doc in docRequiredPerTask)
            {
                if (docPerTask.FirstOrDefault(f => f.RequiredDocumentPerTaskId == doc.IdrequiredDocumentPerTask) == null)
                    docPerTask.Add(new AppDocumentPerTask() { Name = doc.Name, RequiredDocumentPerTaskId = doc.IdrequiredDocumentPerTask });
            }
            return docPerTask;
        }

        public void SaveNameFile(int idfile, string nameFile, int uniqeId)
        {
            if (uniqeId != null && uniqeId > 0)
            {
                List<AppDocumentPerTask> lst = _context.AppDocumentPerTasks.Where(f => f.UniqueCodeId == uniqeId).ToList();
                if (lst != null && lst.Count > 0)
                {
                    lst.ForEach(f => f.Name = nameFile);
                    _context.SaveChanges();
                }
            }
            else
            {
                var x = _context.AppDocumentPerTasks.FirstOrDefault(f => f.IddocumentPerTask == idfile);
                if (x != null)
                {
                    x.Name = nameFile;
                    _context.SaveChanges();
                }
            }
        }

        public void deleteDocumentsPerTaskOfUniqueCode(int uniqueCodeDocumentId)
        {
            if (uniqueCodeDocumentId != null && uniqueCodeDocumentId != 0)
            {
                var x = _context.AppUniqueCodes.Include(i => i.AppDocumentPerTasks).FirstOrDefault(f => f.IduniqueCode == uniqueCodeDocumentId);
                if (x != null)
                {
                    //---------------

                    if (x.AppDocumentPerTasks != null)
                    {
                        x.AppDocumentPerTasks.ToList().ForEach(f =>
                        {
                            AppFolder fold = f.Folder;

                            _context.AppDocumentPerTasks.Remove(f);
                            _context.SaveChanges();

                            if (fold != null && fold.AppDocumentPerTasks.Count == 1)
                                fold.AppDocumentPerTasks.ToList()[0].FolderId = null;
                        });
                        _context.SaveChanges();
                    }
                    _context.AppUniqueCodes.Remove(x);
                    _context.SaveChanges();


                }
            }
        }

        public AppDocumentPerTask UploadDocumentPerTask(AppDocumentPerTask appDocumentPerTask, int uniqueCodeID)
        {
            appDocumentPerTask.Folder = null;
            //מסמך חדש
            if (appDocumentPerTask.IddocumentPerTask == 0)
            {
                appDocumentPerTask.Folder = null;
                appDocumentPerTask.FolderId = null;
                _context.AppDocumentPerTasks.Add(appDocumentPerTask);
            }
            //עידכון מסמך קיים
            else
            {
                var x = _context.AppDocumentPerTasks.Include(i => i.Folder).FirstOrDefault(f => f.IddocumentPerTask == appDocumentPerTask.IddocumentPerTask);
                if (x != null)
                {
                    x.DateUpdated = appDocumentPerTask.DateUpdated;
                    x.UserUpdated = appDocumentPerTask.UserUpdated;
                    x.Path = appDocumentPerTask.Path;
                    x.Name = appDocumentPerTask.Name;
                    x.Type = appDocumentPerTask.Type;
                    appDocumentPerTask = x;
                }
            }

            _context.SaveChanges();
            return appDocumentPerTask;
        }

        public List<AppDocumentPerTask> UploadFewDocumentsPerTask(List<AppDocumentPerTask> lists, string nameFolder, int uniqueCodeID, int userId, int? customerId)
        {
            int i = 0;
            string name = "";
            AppFolder f = null;

            if (uniqueCodeID != 0)
            {
                List<AppDocumentPerTask> lst = new List<AppDocumentPerTask>();
                AppDocumentPerTask appDocumentPerTask;
                int? appUserPerSchoolId;
                int? tabRequiredDocumentPerTaskId = null;

                if (customerId == 0)
                    customerId = null;

                //היוזר פר סקול של הלקוח 
                List<AppUserPerSchool> appUserPerSchools = _context.AppUserPerSchools.Where(w => w.UserId == userId).ToList();
                //הדרוש של הקבצים המועלים
                TabRequiredDocumentPerTask tabRequiredDocumentPerTask = _context.TabRequiredDocumentPerTasks.Include(i => i.UniqueCode.TabRequiredDocumentPerTasks).FirstOrDefault(w => w.IdrequiredDocumentPerTask == lists[0].RequiredDocumentPerTaskId);
                //הקורסים התואמים אליהם צריך להעלות את הקבצים
                List<AppTask> AppTasks = _context.AppTasks.Where(w => w.UniqueCodeId == uniqueCodeID).ToList();
                int? UniqueCode = null;
                bool isFirstTime = true;
                List<int?> ListUnique = new List<int?>();
                int index = 0;
                bool flag = false;

                //מעבר על הקורסים התואמים
                AppTasks.ForEach(fe =>
                {
                    index = 0;
                    f = null;
                    //היוזר פר סקול של הסקול הנוכחי והלקוח
                    appUserPerSchoolId = appUserPerSchools.FirstOrDefault(f => f.SchoolId == fe.SchoolId)?.IduserPerSchool;
                    tabRequiredDocumentPerTaskId = null;

                    //אם זה עידכון של קובץ בודד תואם / או עידכון של קובץ תואם מתיקיה
                    if (lists.Count == 1 && (lists[0].IddocumentPerTask != null && lists[0].IddocumentPerTask > 0))
                    {
                        appDocumentPerTask = _context.AppDocumentPerTasks.Include(i => i.Folder).FirstOrDefault(r => r.SchoolId == fe.SchoolId && r.TaskId == fe.Idtask && r.UniqueCodeId == lists[0].UniqueCodeId);

                        if (appDocumentPerTask != null)
                        {
                            if (appDocumentPerTask.Folder != null)
                            {
                                f = appDocumentPerTask.Folder;
                                if (f != null)
                                    f.IndexFile = f.IndexFile + lists.Count;
                            }
                            appDocumentPerTask.Path = lists[0].Path;
                            appDocumentPerTask.Type = lists[0].Type;
                            appDocumentPerTask.DateUpdated = DateTime.Today;
                            appDocumentPerTask.UserUpdatedId = appUserPerSchoolId;
                            appDocumentPerTask.Name = lists[0].Name;
                            //appDocumentPerTask.Folder = f;
                        }
                        _context.SaveChanges();
                        lst.Add(appDocumentPerTask);
                    }

                    else
                    {


                        //חיפוש הדרוש של המוסד הנוכחי
                        if (tabRequiredDocumentPerTask != null && tabRequiredDocumentPerTask.SchoolId != fe.SchoolId && tabRequiredDocumentPerTask.UniqueCode != null && tabRequiredDocumentPerTask.UniqueCode.TabRequiredDocumentPerTasks != null && tabRequiredDocumentPerTask.UniqueCode.TabRequiredDocumentPerTasks.Count > 0)
                        {
                            var tabRequired = tabRequiredDocumentPerTask.UniqueCode.TabRequiredDocumentPerTasks.FirstOrDefault(f => f.SchoolId == fe.SchoolId);
                            if (tabRequired != null)
                            {
                                tabRequiredDocumentPerTaskId = tabRequired.IdrequiredDocumentPerTask;
                                if (tabRequired.UniqueCodeId != tabRequiredDocumentPerTask.UniqueCodeId)
                                {
                                    tabRequired.UniqueCodeId = tabRequiredDocumentPerTask.UniqueCodeId;
                                    _context.SaveChanges();
                                }
                            }
                        }

                        //באם לא קיים הדרוש למוסד הנוכחי
                        if (tabRequiredDocumentPerTask != null && (tabRequiredDocumentPerTaskId == null || tabRequiredDocumentPerTaskId == 0))
                        {
                            if (tabRequiredDocumentPerTask.SchoolId == fe.SchoolId)
                                tabRequiredDocumentPerTaskId = tabRequiredDocumentPerTask.IdrequiredDocumentPerTask;

                            else
                            {
                                if (tabRequiredDocumentPerTask != null)
                                {
                                    if (tabRequiredDocumentPerTask.UniqueCodeId == null || tabRequiredDocumentPerTask.UniqueCodeId == 0)
                                    {
                                        var unique = new AppUniqueCode() { CustomerId = customerId, DateCreated = DateTime.Today };
                                        _context.AppUniqueCodes.Add(unique);
                                        _context.SaveChanges();
                                        tabRequiredDocumentPerTask.UniqueCodeId = unique.IduniqueCode;


                                    }
                                    var tabRequired = new TabRequiredDocumentPerTask()
                                    {
                                        DateCreated = DateTime.Today,
                                        Name = tabRequiredDocumentPerTask.Name,
                                        SchoolId = fe.SchoolId,
                                        UniqueCodeId = tabRequiredDocumentPerTask.UniqueCodeId,
                                        UserCreatedId = appUserPerSchoolId
                                    };
                                    _context.TabRequiredDocumentPerTasks.Add(tabRequired);
                                    _context.SaveChanges();
                                    tabRequiredDocumentPerTaskId = tabRequired.IdrequiredDocumentPerTask;
                                }
                                else
                                    tabRequiredDocumentPerTaskId = null;
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
                                folderId = _context.AppDocumentPerTasks.FirstOrDefault(f => f.RequiredDocumentPerTaskId == tabRequiredDocumentPerTaskId && f.SchoolId == fe.SchoolId && f.ExsistDocumentId == lists[0].ExsistDocumentId)?.FolderId;
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


                            appDocumentPerTask = new AppDocumentPerTask();
                            if (f != null)
                            {

                                appDocumentPerTask.FolderId = f.IdFolder;
                                appDocumentPerTask.Folder = f;
                            }
                            if (lists.Count() == 1 && lists[0].IddocumentPerTask == 0)
                            {
                                if (f == null)
                                {
                                    var x = _context.AppDocumentPerTasks.FirstOrDefault(f => f.RequiredDocumentPerTaskId == tabRequiredDocumentPerTaskId);
                                    if (x != null)
                                    {
                                        appDocumentPerTask.FolderId = x.FolderId;
                                        flag = true;
                                    }
                                }
                            }
                            appDocumentPerTask.SchoolId = fe.SchoolId;
                            appDocumentPerTask.Path = fo.Path;
                            appDocumentPerTask.TaskId = fe.Idtask;
                            appDocumentPerTask.DateCreated = DateTime.Today;
                            appDocumentPerTask.UserCreatedId = appUserPerSchoolId;
                            //appDocumentPerTask.DateUpdated = DateTime.Today;
                            //appDocumentPerTask.UserUpdated = appUserPerSchoolId;
                            appDocumentPerTask.Type = fo.Type;
                            appDocumentPerTask.RequiredDocumentPerTaskId = tabRequiredDocumentPerTaskId;
                            appDocumentPerTask.Name = fo.Name;
                            appDocumentPerTask.UniqueCodeId = UniqueCode;
                            appDocumentPerTask.ExsistDocumentId = fo.ExsistDocumentId;

                            i = fo.Name.IndexOf('.');
                            if (i > -1)
                            {
                                name = fo.Name.Substring(0, i);
                                if (name != null && name != "")
                                {
                                    appDocumentPerTask.Name = name;
                                }
                            }

                            lst.Add(appDocumentPerTask);
                            index++;
                        });
                    }

                    isFirstTime = false;

                });
                _context.AppDocumentPerTasks.AddRange(lst.Where(w => w.IddocumentPerTask == null || w.IddocumentPerTask == 0));
                _context.SaveChanges();
                lists = lst.Where(w => w.SchoolId == lists[0].SchoolId).ToList();
                if (flag)
                {
                    lists[0].Folder = new AppFolder() { Name = nameFolder };
                }
            }
            else
            {

                if (lists.Count > 1 && ( lists[0].FolderId == null || lists[0].FolderId == 0))
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

                if (lists.Count == 1 && lists[0].IddocumentPerTask > 0)
                {
                    var doc = _context.AppDocumentPerTasks.FirstOrDefault(f => f.IddocumentPerTask == lists[0].IddocumentPerTask);
                    if (doc != null)
                    {
                        doc.Name = lists[0].Name;
                        doc.Type = lists[0].Type;
                        doc.UserUpdated = lists[0].UserUpdated;
                        doc.DateUpdated = lists[0].DateUpdated;
                        doc.Path = lists[0].Path;
                        doc.Folder = f;
                    }
                    lists = new List<AppDocumentPerTask>() { doc };
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
                    _context.AppDocumentPerTasks.AddRange(lists);
                }
                _context.SaveChanges();
            }


            return lists;
        }
    }
}
