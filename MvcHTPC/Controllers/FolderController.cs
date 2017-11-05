using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHTPC.Controllers
{
    public class FolderController : Controller
    {
        // GET: Folder
        public ActionResult Folder(string id)
        {
            ViewBag.id = id;
            return View();
        }
    }
}