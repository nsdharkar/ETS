using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETS.Models.Entity;
using ETS.Models.Service;

namespace ETS.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        private IMenuService MenuService { get; set; }

        //public MenuController()
        //{ }
        public MenuController(IMenuService menuService)
        {
            MenuService = menuService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult GetMenu()
        {
            string uName = Convert.ToString(Session["user"]).Split('|')[1];
            var mnu = MenuService.GetUserMenu(uName);
            return PartialView("GetMenu", mnu);
        }
    }
}