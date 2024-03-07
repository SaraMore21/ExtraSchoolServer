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
    public class DocumentPerGroupRepository : IDocumentPerGroupRepository
    {
        private readonly ExtraSchoolContext _context;

        public DocumentPerGroupRepository(ExtraSchoolContext context)
        {
            _context = context;
        }


        public string DeleteDocumentPerGroup(int idDocumentPerGroup, int idGroup)
        {
            string s = "";
            if (idDocumentPerGroup != 0 && idDocumentPerGroup != null)
            {

                var x = _context.AppDocumentPerGroups.Include(i => i.RequiredDocumentPerGroup).FirstOrDefault(f => f.IddocumentPerGroup == idDocumentPerGroup);
  
                if (x != null)
                {
                    s = x.RequiredDocumentPerGroup != null ? x.RequiredDocumentPerGroup.Name : x.Name;

                    //---------
                    var fold = x.Folder;

                    //---------
                    _context.AppDocumentPerGroups.Remove(x);
                    _context.SaveChanges();
                    if (fold != null && fold.AppDocumentPerGroups.Count == 1)
                        fold.AppDocumentPerGroups.ToList()[0].FolderId = null;
                    _context.SaveChanges();

                }
            }
            return s;
        }

        public AppDocumentPerGroup DeleteFewDocumentPerGroup(int idFolder, int requiredDocumentPerGroupId)
        {
            AppDocumentPerGroup t = new AppDocumentPerGroup();

            if (idFolder != 0 && idFolder != null)
            {
                var x = _context.AppFolders.FirstOrDefault(f => f.IdFolder == idFolder);
                if (x != null)
                {
                    List<AppDocumentPerGroup> AppDocumentPerGroup = x.AppDocumentPerGroups.ToList();

                    _context.AppFolders.Remove(x);
                    _context.SaveChanges();

                    if (AppDocumentPerGroup != null && AppDocumentPerGroup.Count > 0)
                    {
                        _context.AppDocumentPerGroups.RemoveRange(AppDocumentPerGroup);
                        _context.SaveChanges();
                    }

                    if (requiredDocumentPerGroupId != 0)
                    {
                        var c = _context.TabRequiredDocumentPerGroups.FirstOrDefault(f => f.IdrequiredDocumentPerGroup == requiredDocumentPerGroupId);
                        if (c != null)
                        {
                            t.Name = c.Name;
                            t.RequiredDocumentPerGroupId = c.IdrequiredDocumentPerGroup;
                        }
                    }
                }
            }
            return t;
        }

        public List<AppDocumentPerGroup> GetLstDocumentPerGroup(int GroupId, int schollId)
        {
            List<AppDocumentPerGroup> lstDoc = new List<AppDocumentPerGroup>();
            var docPerGroup = _context.AppDocumentPerGroups.Include(i => i.Folder).Where(w => w.GroupId == GroupId).ToList();
            var docRequiredPerGroup = _context.TabRequiredDocumentPerGroups.Where(w => w.SchoolId == schollId);
            if (docPerGroup == null)
                docPerGroup = new List<AppDocumentPerGroup>();
            foreach (var doc in docRequiredPerGroup)
            {
                if (docPerGroup.FirstOrDefault(f => f.RequiredDocumentPerGroupId == doc.IdrequiredDocumentPerGroup) == null)
                    docPerGroup.Add(new AppDocumentPerGroup() { Name = doc.Name, RequiredDocumentPerGroupId = doc.IdrequiredDocumentPerGroup });
            }
            return docPerGroup;
        }

        public void SaveNameFile(int idfile, string nameFile)
        {
            var x = _context.AppDocumentPerGroups.FirstOrDefault(f => f.IddocumentPerGroup == idfile);
            if (x != null)
            {
                x.Name = nameFile;
                _context.SaveChanges();
            }
        }

        public AppDocumentPerGroup UploadDocumentPerGroup(AppDocumentPerGroup appDocumentPerGroup)
        {
            //מסמך חדש
            if (appDocumentPerGroup.IddocumentPerGroup == 0)
            {
                appDocumentPerGroup.Folder = null;
                appDocumentPerGroup.FolderId = null;
                _context.AppDocumentPerGroups.Add(appDocumentPerGroup);
            }
            //עידכון מסמך קיים
            else
            {
                var x = _context.AppDocumentPerGroups.Include(i => i.Folder).FirstOrDefault(f => f.IddocumentPerGroup == appDocumentPerGroup.IddocumentPerGroup);
                if (x != null)
                {
                    x.DateUpdated = appDocumentPerGroup.DateUpdated;
                    x.UserUpdatedId = appDocumentPerGroup.UserUpdatedId;
                    x.Path = appDocumentPerGroup.Path;
                    x.Name = appDocumentPerGroup.Name;
                    x.Type = appDocumentPerGroup.Type;
                    appDocumentPerGroup = x;
                }
            }

            _context.SaveChanges();
            return appDocumentPerGroup;
        }

        public List<AppDocumentPerGroup> UploadFewDocumentsPerGroup(List<AppDocumentPerGroup> lists, string nameFolder)
        {
            int i = 0;
            string name = "";
            AppFolder f = null;


            //באם זה העלאת מס קבצים פעם ראשונה לתיקיה חדשה פתיחת תיקיה
            if (lists.Count > 1 && (lists[0].FolderId == null || lists[0].FolderId == 0))
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
            if (lists.Count == 1 && lists[0].IddocumentPerGroup > 0)
            {
                var doc = _context.AppDocumentPerGroups.FirstOrDefault(f => f.IddocumentPerGroup == lists[0].IddocumentPerGroup);
                if (doc != null)
                {
                    doc.Name = lists[0].Name;
                    doc.Type = lists[0].Type;
                    doc.UserUpdatedId = lists[0].UserUpdatedId;
                    doc.DateUpdated = lists[0].DateUpdated;
                    doc.Path = lists[0].Path;
                    doc.Folder = f;
                }
                lists = new List<AppDocumentPerGroup>() { doc };
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
                _context.AppDocumentPerGroups.AddRange(lists);
            }
            _context.SaveChanges();

            return lists;
        }

    }
}
