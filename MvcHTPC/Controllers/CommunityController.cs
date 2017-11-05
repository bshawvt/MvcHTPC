using MvcHTPC.DTOs;
using MvcHTPC.Models;
using MvcHTPC.Services;
using MvcHTPC.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHTPC.Controllers
{
    public class CommunityController : Controller
    {
        
        public ActionResult Index()
        {
            CommunityViewModel viewModel = new CommunityViewModel();
            CommunityService communityService = new CommunityService();
            viewModel.forumDtos = communityService.GetForumDtos();
            
            return View(viewModel);
        }
        [HttpGet]
        public ActionResult Notifier()
        {
            NotificationService noteService = new NotificationService();
            NotificationViewModel viewModel = new NotificationViewModel();
            viewModel.notificationDtos = noteService.GetLastMinutesNotifications();
            return Json(new {notes = viewModel}, JsonRequestBehavior.AllowGet);
        }
        [AllowAnonymous]
        public PartialViewResult _NotifierPartial()
        {
            return PartialView("_NotifierPartial");
        }

        public ActionResult Forum(string id)
        {
            ForumViewModel viewModel = new ForumViewModel();
            ForumService forumService = new ForumService();
            long t_forumId = Convert.ToInt64(id);
            viewModel.folderDtos = forumService.GetForumFolderDtosByDate(t_forumId);
            return View(viewModel);
        }
    }
}