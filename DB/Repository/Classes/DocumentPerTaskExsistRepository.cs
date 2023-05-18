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
    public class DocumentPerTaskExsistRepository : IDocumentPerTaskExsistRepository
    {
        private readonly ExtraSchoolContext _context;

        public DocumentPerTaskExsistRepository(ExtraSchoolContext context)
        {
            _context = context;
        }

        public string DeleteDocumentPerTaskExsist(int idDocumentPerTaskExsist, int idTaskExsist)
        {
            string s = "";
            if (idDocumentPerTaskExsist != 0 && idDocumentPerTaskExsist != null)
            {

                var x = _context.AppDocumentPerTaskExsists.Include(i => i.RequiredDocumentPerTaskExsist).FirstOrDefault(f => f.IddocumentPerTaskExsist == idDocumentPerTaskExsist);
                if (x != null)
                {
                    s = x.RequiredDocumentPerTaskExsist != null ? x.RequiredDocumentPerTaskExsist.Name : x.Name;
                    _context.AppDocumentPerTaskExsists.Remove(x);
                    _context.SaveChanges();
                }
            }
            return s;
        }

        public AppDocumentPerTaskExsist DeleteFewDocumentPerTaskExsist(int idFolder, int requiredDocumentPerTaskExsistId)
        {
            AppDocumentPerTaskExsist t = new AppDocumentPerTaskExsist();

            if (idFolder != 0 && idFolder != null)
            {
                var x = _context.AppFolders.Include(i=> i.AppDocumentPerTaskExsists).FirstOrDefault(f => f.IdFolder == idFolder);
                if (x != null)
                {
                    List<AppDocumentPerTaskExsist> AppDocumentPerTaskExsist = x.AppDocumentPerTaskExsists.ToList();

                    _context.AppFolders.Remove(x);
                    _context.SaveChanges();
         
                    if (AppDocumentPerTaskExsist != null && AppDocumentPerTaskExsist.Count > 0)
                    {
                        _context.AppDocumentPerTaskExsists.RemoveRange(AppDocumentPerTaskExsist);
                        _context.SaveChanges();
                    }
                    if (requiredDocumentPerTaskExsistId != 0)
                    {
                        var c = _context.TabRequiredDocumentPerTaskExsists.FirstOrDefault(f => f.IdrequiredDocumentPerTaskExsist == requiredDocumentPerTaskExsistId);
                        if (c != null)
                        {
                            t.Name = c.Name;
                            t.RequiredDocumentPerTaskExsistId = c.IdrequiredDocumentPerTaskExsist;
                        }
                    }
                }
            }
            return t;
        }

        public List<AppDocumentPerTaskExsist> GetLstDocumentPerTaskExsist(int TaskExsistId, int schollId)
        {
            List<AppDocumentPerTaskExsist> lstDoc = new List<AppDocumentPerTaskExsist>();
            var docPerTaskExsist = _context.AppDocumentPerTaskExsists.Include(i => i.Folder).Where(w => w.TaskExsistId == TaskExsistId).ToList();
            var docRequiredPerTaskExsist = _context.TabRequiredDocumentPerTaskExsists.Where(w => w.SchoolId == schollId);
            if (docPerTaskExsist == null)
                docPerTaskExsist = new List<AppDocumentPerTaskExsist>();
            foreach (var doc in docRequiredPerTaskExsist)
            {
                if (docPerTaskExsist.FirstOrDefault(f => f.RequiredDocumentPerTaskExsistId == doc.IdrequiredDocumentPerTaskExsist) == null)
                    docPerTaskExsist.Add(new AppDocumentPerTaskExsist() { Name = doc.Name, RequiredDocumentPerTaskExsistId = doc.IdrequiredDocumentPerTaskExsist });
            }
            return docPerTaskExsist;
        }

        public void SaveNameFile(int idfile, string nameFile)
        {
            var x = _context.AppDocumentPerTaskExsists.FirstOrDefault(f => f.IddocumentPerTaskExsist == idfile);
            if (x != null)
            {
                x.Name = nameFile;
                _context.SaveChanges();
            }
        }

        public AppDocumentPerTaskExsist UploadDocumentPerTaskExsist(AppDocumentPerTaskExsist appDocumentPerTaskExsist)
        {
            //מסמך חדש
            if (appDocumentPerTaskExsist.IddocumentPerTaskExsist == 0)
            {
                appDocumentPerTaskExsist.Folder = null;
                appDocumentPerTaskExsist.FolderId = null;
                _context.AppDocumentPerTaskExsists.Add(appDocumentPerTaskExsist);
            }
            //עידכון מסמך קיים
            else
            {
                var x = _context.AppDocumentPerTaskExsists.Include(i => i.Folder).FirstOrDefault(f => f.IddocumentPerTaskExsist == appDocumentPerTaskExsist.IddocumentPerTaskExsist);
                if (x != null)
                {
                    x.DateUpdated = appDocumentPerTaskExsist.DateUpdated;
                    x.UserUpdatedId = appDocumentPerTaskExsist.UserUpdatedId;
                    x.Path = appDocumentPerTaskExsist.Path;
                    x.Name = appDocumentPerTaskExsist.Name;
                    x.Type = appDocumentPerTaskExsist.Type;
                    appDocumentPerTaskExsist = x;
                }
            }

            _context.SaveChanges();
            return appDocumentPerTaskExsist;
        }

        public List<AppDocumentPerTaskExsist> UploadFewDocumentsPerTaskExsist(List<AppDocumentPerTaskExsist> lists, string nameFolder)
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
            if (lists.Count == 1 && lists[0].IddocumentPerTaskExsist > 0)
            {
                var doc = _context.AppDocumentPerTaskExsists.FirstOrDefault(f => f.IddocumentPerTaskExsist == lists[0].IddocumentPerTaskExsist);
                if (doc != null)
                {
                    doc.Name = lists[0].Name;
                    doc.Type = lists[0].Type;
                    doc.UserUpdatedId = lists[0].UserUpdatedId;
                    doc.DateUpdated = lists[0].DateUpdated;
                    doc.Path = lists[0].Path;
                    doc.Folder = f;
                }
                lists = new List<AppDocumentPerTaskExsist>() { doc };
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
                _context.AppDocumentPerTaskExsists.AddRange(lists);
            }
            _context.SaveChanges();

            return lists;
        }
    }
}
