using Microsoft.AspNet.Identity;
using MvcHTPC.DTOs;
using MvcHTPC.Models;
using MvcHTPC.Services;
using MvcHTPC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHTPC.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            HomeViewModel viewModel = new HomeViewModel();
            UserService userService = new UserService();

            if (User.Identity.IsAuthenticated)
                viewModel.userDto = userService.GetUserDtoById(Convert.ToInt64(User.Identity.GetUserId()));

            return View(viewModel);
        }

        public ActionResult Progress()
        {
            return View("FeatureList");
        }
    }
}