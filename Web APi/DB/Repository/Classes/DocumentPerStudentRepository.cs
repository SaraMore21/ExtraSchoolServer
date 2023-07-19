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
    public class DocumentPerStudentRepository : IDocumentPerStudentRepository
    {
        private readonly ExtraSchoolContext _context;

        public DocumentPerStudentRepository(ExtraSchoolContext context)
        {
            _context = context;
        }

        public string DeleteDocumentPerStudent(int idDocumentPerStudent, int idStudent)
        {
            string s = "";
            if (idDocumentPerStudent != 0 && idDocumentPerStudent != null)
            {

                var x = _context.AppDocumentPerStudents.Include(i => i.RequiredDocumentPerStudent).FirstOrDefault(f => f.IddocumentPerStudent == idDocumentPerStudent);
                //---------
                var fold = x.Folder;
                if (x != null)
                {
                    s = x.RequiredDocumentPerStudent != null ? x.RequiredDocumentPerStudent.Name : x.Name;

                    //---------
                    _context.AppDocumentPerStudents.Remove(x);
                    _context.SaveChanges();
                    if (fold != null && fold.AppDocumentPerStudents.Count == 1)
                        fold.AppDocumentPerStudents.ToList()[0].FolderId = null;
                    _context.SaveChanges();

                }
            }
            return s;
        }

        public AppDocumentPerStudent DeleteFewDocumentPerStudent(int idFolder, int requiredDocumentPerStudentId)
        {
            AppDocumentPerStudent t = new AppDocumentPerStudent();

            if (idFolder != 0 && idFolder != null)
            {
                var x = _context.AppFolders.Include(i=> i.AppDocumentPerStudents).FirstOrDefault(f => f.IdFolder == idFolder);
                if (x != null)
                {
                    List<AppDocumentPerStudent> AppDocumentPerStudent = x.AppDocumentPerStudents.ToList();

                    _context.AppFolders.Remove(x);
                    _context.SaveChanges();

                    if (AppDocumentPerStudent != null && AppDocumentPerStudent.Count > 0)
                    {
                        _context.AppDocumentPerStudents.RemoveRange(AppDocumentPerStudent);
                        _context.SaveChanges();
                    }
                    if (requiredDocumentPerStudentId != null && requiredDocumentPerStudentId > 0)
                    {
                        var c = _context.TabRequiredDocumentPerStudents.FirstOrDefault(f => f.IdrequiredDocumentPerStudent == requiredDocumentPerStudentId);
                        if (c != null)
                        {
                            t.Name = c.Name;
                            t.RequiredDocumentPerStudentId = c.IdrequiredDocumentPerStudent;
                        }
                    }
                }
            }
            return t;
        }



        public List<AppDocumentPerStudent> GetLstDocumentPerStudent(int StudentId, int schollId)
        {
            List<AppDocumentPerStudent> lstDoc = new List<AppDocumentPerStudent>();
            var docPerStudent = _context.AppDocumentPerStudents.Include(i => i.Folder).Where(w => w.StudentId == StudentId).ToList();
            var docRequiredPerStudent = _context.TabRequiredDocumentPerStudents.Where(w => w.SchoolId == schollId);
            if (docPerStudent == null)
                docPerStudent = new List<AppDocumentPerStudent>();
            foreach (var doc in docRequiredPerStudent)
            {
                if (docPerStudent.FirstOrDefault(f => f.RequiredDocumentPerStudentId == doc.IdrequiredDocumentPerStudent) == null)
                    docPerStudent.Add(new AppDocumentPerStudent() { Name = doc.Name, RequiredDocumentPerStudentId = doc.IdrequiredDocumentPerStudent });
            }
            return docPerStudent;
        }

        public void SaveNameFile(int idfile, string nameFile)
        {
            var x = _context.AppDocumentPerStudents.FirstOrDefault(f => f.IddocumentPerStudent == idfile);
            if (x != null)
            {
                x.Name = nameFile;
                _context.SaveChanges();
            }
        }

        public AppDocumentPerStudent UploadDocumentPerStudent(AppDocumentPerStudent appDocumentPerStudent)
        {
            //מסמך חדש
            if (appDocumentPerStudent.IddocumentPerStudent == 0)
            {
                appDocumentPerStudent.Folder = null;
                appDocumentPerStudent.FolderId = null;
                _context.AppDocumentPerStudents.Add(appDocumentPerStudent);
            }
            //עידכון מסמך קיים
            else
            {
                var x = _context.AppDocumentPerStudents.Include(i => i.Folder).FirstOrDefault(f => f.IddocumentPerStudent == appDocumentPerStudent.IddocumentPerStudent);
                if (x != null)
                {
                    x.DateUpdated = appDocumentPerStudent.DateUpdated;
                    x.UserUpdatedId = appDocumentPerStudent.UserUpdatedId;
                    x.Path = appDocumentPerStudent.Path;
                    x.Name = appDocumentPerStudent.Name;
                    x.Type = appDocumentPerStudent.Type;
                    appDocumentPerStudent = x;
                }
            }

            _context.SaveChanges();
            return appDocumentPerStudent;
        }

        public List<AppDocumentPerStudent> UploadFewDocumentsPerStudent(List<AppDocumentPerStudent> lists, string nameFolder)
        {
            int i = 0;
            string name = "";
            AppFolder f = null;


            //באם זה העלאת מס קבצים פעם ראשונה לתיקיה חדשה פתיחת תיקיה
            if (lists!= null && lists.Count>1 && lists[0].FolderId == null || lists[0].FolderId == 0)
            {
                f = new AppFolder() { SchoolId = lists[0].SchoolId, Name = nameFolder, DateCreated = DateTime.UtcNow.AddHours(3), UserCreated = lists[0].UserCreated, IndexFile = lists.Count + 1 };
                _context.AppFolders.Add(f);
                _context.SaveChanges();
            }
            //באם זה העלאת מס קבצים לתיקיה קיימת שליפת התיקיה
            else
            {
                f = _context.AppFolders.FirstOrDefault(f => f.IdFolder == lists[0].FolderId);
                if (f != null)
                    f.IndexFile = f.IndexFile + lists.Count;

            }

            //אם זה עידכון של קובץ מתיקיה
            if (lists.Count == 1 && lists[0].IddocumentPerStudent > 0)
            {
                var doc = _context.AppDocumentPerStudents.FirstOrDefault(f => f.IddocumentPerStudent == lists[0].IddocumentPerStudent);
                if (doc != null)
                {
                    doc.Name = lists[0].Name;
                    doc.Type = lists[0].Type;
                    doc.UserUpdatedId = lists[0].UserUpdatedId;
                    doc.DateUpdated = lists[0].DateUpdated;
                    doc.Path = lists[0].Path;
                    doc.Folder = f;
                }
                lists = new List<AppDocumentPerStudent>() { doc };
            }
            //העלאת קבצים לתיקיה
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
                _context.AppDocumentPerStudents.AddRange(lists);
            }
            _context.SaveChanges();

            return lists;
        }
    }
}
