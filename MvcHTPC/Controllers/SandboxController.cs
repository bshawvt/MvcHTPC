using MvcHTPC.Models;
using MvcHTPC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHTPC.Controllers
{
    public class SandboxController : Controller
    {
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Auth");

            SandboxViewModel viewModel = new SandboxViewModel();

            return View(viewModel);
        }
    }
}