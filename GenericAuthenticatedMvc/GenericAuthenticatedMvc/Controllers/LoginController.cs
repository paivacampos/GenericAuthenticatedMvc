using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using GenericAuthenticatedMvc.Models;

namespace GenericAuthenticatedMvc.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public RedirectToRouteResult Logout()
        {
            FormsAuthentication.SignOut();

            var formsAuthCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            formsAuthCookie.Expires = DateTime.Today.AddDays(-1);
            TempData["Message"] = "You have been logged off, see you later!";

            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", null);
            }
            return View(new LoginModel());
        }

        [HttpPost]
        public ActionResult Login(string username, string password, bool rememberMe)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(username, password))
                {
                    FormsAuthentication.SetAuthCookie(username, rememberMe);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View();
        }

    }
}
