using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETS.Models.Service;

namespace ETS.Controllers
{
    public class LogoutController : Controller
    {
        private ILogoutService LogoutService { get; set; }

        public LogoutController(ILogoutService logoutService)
        {
            LogoutService = logoutService;
        }
        // GET: Logout
        
        public ActionResult Index()
        {
            if(!string.IsNullOrEmpty(Convert.ToString(Session["user"])))
            {
                LogoutService.UserLogOut(Convert.ToString(Session["user"]), "User Log Out");
                Session.Clear();
                Session.Abandon();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}