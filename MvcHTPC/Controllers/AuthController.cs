using MvcHTPC.DTOs;
using MvcHTPC.Models;
using MvcHTPC.Services;
using MvcHTPC.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace MvcHTPC.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        [HttpPost]
        public ActionResult Login(string username, string password)
        {

            if (!ModelState.IsValid)
            {
                Debug.WriteLine("uninvalidation!");
                return RedirectToAction("Index", "Home");
            }

            AuthViewModel viewModel = new AuthViewModel();
            AuthService authService = new AuthService(password);
            users t_user = authService.Authenticate(username, password);
            if (t_user != null)
            {
                var identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.NameIdentifier, t_user.id.ToString()),
                new Claim(ClaimTypes.Name, t_user.username)
                    //new Claim(ClaimTypes.Country, "Murrica")
                }, "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);
                //HttpContext.GetOwinContext().Authentication;
                return RedirectToAction("Index", "Account");
            }
            viewModel.errors.Add("Username and/or password are incorrect");
            return View("Index", viewModel);
        }

        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Register(string username, string password, string email)
        {
            AuthViewModel viewModel = new AuthViewModel();
            AuthService auth = new AuthService("");
            ViewBag.registrationSuccessful = false;
            Debug.WriteLine("Register: url: username = {0}\npassword = {1}\nemail = {2}", username, "nowayman", email);
            if(!auth.IsUsernameTaken(username))
            { 
                Debug.WriteLine("username does not exist.. what about email?");
                if (!auth.IsEmailTaken(email))
                {
                    auth.CreateNewUser(username, password, email);
                    Debug.WriteLine("email is good!");
                    ViewBag.registrationSuccessful = true;
                }
                else
                {
                    viewModel.errors.Add("Email is already in use");
                }
            }
            else
            {
                viewModel.errors.Add("Username is already in use");
            }
            
            return View("Index", viewModel);
        }
        
        public PartialViewResult _AccountPartial()
        {// Account drop down

            AccountViewModel viewModel = new AccountViewModel();
            return PartialView("_AccountPartial", viewModel); // not logged in
        }

        public ActionResult Index()
        {
            AuthViewModel viewModel = new AuthViewModel();
            return View(viewModel);
        }
    }
}