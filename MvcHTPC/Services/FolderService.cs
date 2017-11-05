using MvcHTPC.DTOs;
using MvcHTPC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MvcHTPC.Services
{
    public class FolderService
    {
        private MvcHTPCContext db = new MvcHTPCContext();
        public FolderService()
        {

        }

        public FolderDto MakeFolder()
        {
            return null;
        }
        public bool FolderExistsWithLocation(string location)
        {
            var folders = db.tblFolders.Where(x => x.location == location);
            if (folders.Count() > 0)
            {
                Debug.WriteLine("folder({0}) exists", location, "");
                return true;
            }
            Debug.WriteLine("folder({0}) does not exist", location, "");
            return false;
        }
        public void CreateFolder(string location)
        {
           if (FolderExistsWithLocation(location) == false)
            {
                db.tblFolders.Add(new folders
                {
                    dateOfCreation = DateTime.Now,
                    description = "",
                    //forumId = -1,
                    groupIds = "",
                    hidden = Models.DbModels.DbStaticEnums.HiddenState.HIDDEN,
                    iconText = "",
                    //id = -1,
                    lastModified = DateTime.Now,
                    location = location,
                    locked = false,
                    //modifiedLogId = -1,
                    //ownersId = -1,
                    title = "",
                });
                db.SaveChanges();
            }

        }

        public bool AddContentToFolder(string folder, string content)
        {
            var f = from i in db.tblFolders
                    where i.location == folder
                    select i;
            Debug.WriteLine(f);
            if (f.Count() > 0)
            {
                var _f = f.First();
                Debug.WriteLine("f is not null");
                db.tblContents.Add(new contents
                {
                    folderId = _f.id,
                    bodyText = content,
                    //id = 0,
                    dateOfCreation = DateTime.Now,
                    lastModification = DateTime.Now,
                    //modifiedLogId = 0,
                    //ownerId = 0,
                    title = "Test"
                });
                db.SaveChanges();
                return true;
            }
           /* var f = from i in db.tblFolders
                    where i.location == folder
                    select new FolderDto
                    {
                        description = i.description,
                        dateOfCreation = i.dateOfCreation,
                        forumId = i.forumId,
                        groupIds = i.groupIds,
                        hidden = i.hidden,
                        lastModified = i.lastModified,
                        location = i.location,
                        locked = i.locked,
                        ownersId = i.ownersId,
                        modifiedLogId = i.modifiedLogId,
                        title = i.title,
                        iconText = i.iconText
                    };

            if (f!=null)
            {
                db.tblContents.Add(new contents
                {
                    folderId = f.id,
                    bodyText = content,
                    //id = 0,
                    dateOfCreation = DateTime.Now,
                    lastModification = DateTime.Now,
                    //modifiedLogId = 0,
                    //ownerId = 0,
                    title = "Test"
                });
                db.SaveChanges();
                return true;
            }*/
            return false;
        }

        public FolderDto GetFolder(string folder)
        {
            
            FolderDto f = new FolderDto(db.tblFolders.Where(x => x.location == folder).First());
            return f;
        
        }

    }
}