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
    public class DocumentPerCourseRepository : IDocumentPerCourseRepository
    {
        private readonly ExtraSchoolContext _context;

        public DocumentPerCourseRepository(ExtraSchoolContext context)
        {
            _context = context;
        }


        public string DeleteDocumentPerCourse(int idDocumentPerCourse, int idCourse)
        {
            string s = "";
            if (idDocumentPerCourse != 0 && idDocumentPerCourse != null)
            {

                var x = _context.AppDocumentPerCourses.Include(i => i.RequiredDocumentPerCourse).FirstOrDefault(f => f.IddocumentPerCourse == idDocumentPerCourse);
                if (x != null)
                {
                    s = x.RequiredDocumentPerCourse != null ? x.RequiredDocumentPerCourse.Name : x.Name;
                    _context.AppDocumentPerCourses.Remove(x);
                    _context.SaveChanges();
                }
            }
            return s;
        }

        public AppDocumentPerCourse DeleteFewDocumentPerCourse(int idFolder, int requiredDocumentPerCourseId)
        {
            AppDocumentPerCourse t = new AppDocumentPerCourse();

            if (idFolder != 0 && idFolder != null)
            {
                var x = _context.AppFolders.FirstOrDefault(f => f.IdFolder == idFolder);
                if (x != null)
                {
                    List<AppDocumentPerCourse> AppDocumentPerCourse = x.AppDocumentPerCourses.ToList();

                    _context.AppFolders.Remove(x);
                    _context.SaveChanges();

                    if (AppDocumentPerCourse != null && AppDocumentPerCourse.Count > 0)
                    {
                        _context.AppDocumentPerCourses.RemoveRange(AppDocumentPerCourse);
                        _context.SaveChanges();
                    }

                    if (requiredDocumentPerCourseId != 0)
                    {
                        var c = _context.TabRequiredDocumentPerCourses.FirstOrDefault(f => f.IdrequiredDocumentPerCourse == requiredDocumentPerCourseId);
                        if (c != null)
                        {
                            t.Name = c.Name;
                            t.RequiredDocumentPerCourseId = c.IdrequiredDocumentPerCourse;
                        }
                    }
                }
            }
            return t;
        }

        public List<AppDocumentPerCourse> GetLstDocumentPerCourse(int CourseId, int schollId)
        {
            List<AppDocumentPerCourse> lstDoc = new List<AppDocumentPerCourse>();
            var docPerCourse = _context.AppDocumentPerCourses.Include(i => i.Folder).Where(w => w.CourseId == CourseId).ToList();
            var docRequiredPerCourse = _context.TabRequiredDocumentPerCourses.Where(w => w.SchoolId == schollId);
            if (docPerCourse == null)
                docPerCourse = new List<AppDocumentPerCourse>();
            foreach (var doc in docRequiredPerCourse)
            {
                if (docPerCourse.FirstOrDefault(f => f.RequiredDocumentPerCourseId == doc.IdrequiredDocumentPerCourse) == null)
                    docPerCourse.Add(new AppDocumentPerCourse() { Name = doc.Name, RequiredDocumentPerCourseId = doc.IdrequiredDocumentPerCourse });
            }
            return docPerCourse;
        }

        public void SaveNameFile(int idfile, string nameFile)
        {
            var x = _context.AppDocumentPerCourses.FirstOrDefault(f => f.IddocumentPerCourse == idfile);
            if (x != null)
            {
                x.Name = nameFile;
                _context.SaveChanges();
            }
        }

        public AppDocumentPerCourse UploadDocumentPerCourse(AppDocumentPerCourse appDocumentPerCourse)
        {
            //מסמך חדש
            if (appDocumentPerCourse.IddocumentPerCourse == 0)
            {
                appDocumentPerCourse.Folder = null;
                appDocumentPerCourse.FolderId = null;
                _context.AppDocumentPerCourses.Add(appDocumentPerCourse);
            }
            //עידכון מסמך קיים
            else
            {
                var x = _context.AppDocumentPerCourses.Include(i => i.Folder).FirstOrDefault(f => f.IddocumentPerCourse == appDocumentPerCourse.IddocumentPerCourse);
                if (x != null)
                {
                    x.DateUpdated = appDocumentPerCourse.DateUpdated;
                    x.UserUpdatedId = appDocumentPerCourse.UserUpdatedId;
                    x.Path = appDocumentPerCourse.Path;
                    x.Name = appDocumentPerCourse.Name;
                    x.Type = appDocumentPerCourse.Type;
                    appDocumentPerCourse = x;
                }
            }

            _context.SaveChanges();
            return appDocumentPerCourse;
        }

        public List<AppDocumentPerCourse> UploadFewDocumentsPerCourse(List<AppDocumentPerCourse> lists, string nameFolder)
        {
            int i = 0;
            string name = "";
            AppFolder f = null;


            //באם זה העלאת מס קבצים פעם ראשונה לתיקיה חדשה פתיחת תיקיה
            if (lists[0].FolderId == null || lists[0].FolderId == 0)
            {
                f = new AppFolder() { SchoolId = lists[0].SchoolId, Name = nameFolder, DateCreated = DateTime.UtcNow.AddHours(3), UserCreated = lists[0].UserCreated, IndexFile = lists.Count };
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
            if (lists.Count == 1 && lists[0].IddocumentPerCourse > 0)
            {
                var doc = _context.AppDocumentPerCourses.FirstOrDefault(f => f.IddocumentPerCourse == lists[0].IddocumentPerCourse);
                if (doc != null)
                {
                    doc.Name = lists[0].Name;
                    doc.Type = lists[0].Type;
                    doc.UserUpdatedId = lists[0].UserUpdatedId;
                    doc.DateUpdated = lists[0].DateUpdated;
                    doc.Path = lists[0].Path;
                    doc.Folder = f;
                }
                lists = new List<AppDocumentPerCourse>() { doc };
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
                _context.AppDocumentPerCourses.AddRange(lists);
            }
            _context.SaveChanges();

            return lists;
        }

    }
}