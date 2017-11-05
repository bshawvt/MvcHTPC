using Microsoft.AspNet.Identity;
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

    public class AccountController : Controller
    {
        MvcHTPCContext db = new MvcHTPCContext();

        // GET: Login
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            AccountViewModel viewModel = new AccountViewModel();

            long? userId = Convert.ToInt64(User.Identity.GetUserId());
            viewModel.userDto = new UserDto(db.tblUsers.Find(userId));
            
            return View(viewModel);
        }
       
        public ActionResult Settings()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Auth");

            AccountViewModel viewModel = new AccountViewModel();
            long? userId = Convert.ToInt64(User.Identity.GetUserId());
            viewModel.userDto = new UserDto(db.tblUsers.Find(userId));

            return View(viewModel);
        }
        
    }
}