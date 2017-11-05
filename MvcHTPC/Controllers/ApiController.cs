using MvcHTPC.Models;
using MvcHTPC.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHTPC.Controllers
{
    public class ApiController : Controller
    {
        MvcHTPCContext db = new MvcHTPCContext();

        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public string SaveUrlToFolder(string folder, string url)
        {
            string result = "Failure";
            Debug.WriteLine("folder: {0}\nurl: {1}", folder, url);
            UserService userService = new UserService();
            FolderService folderService = new FolderService();

            /*
             * if folder exists and folder not locked
             * do database things
             */
            folderService.CreateFolder(folder);
            if (folderService.AddContentToFolder(folder, url) == true)
            {
                result = "Success";
            }

            

            return result;

        }
    }
}