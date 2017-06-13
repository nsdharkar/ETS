using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETS.Models.Entity;
using ETS.Models.Service;

namespace ETS.Controllers
{
    public class LoginController : Controller
    {
        private ILoginService LoginService { get; set; }

        // GET: Login
        public LoginController(ILoginService loginService)
        {
            LoginService = loginService;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserMaster userMaster)
        {
            if (ModelState.IsValid)
            {
                var userAuthentication = LoginService.CheckUserAuthentication(userMaster);
                if (userAuthentication != null)
                {
                    TempData["usrId"] = userAuthentication.UserId;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    throw new Exception("No user found try again...");
                }
            }
            else
                return View();
        }
    }
}