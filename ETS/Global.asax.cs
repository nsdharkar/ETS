using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using ETS.Models.Service;
using ETS.Models.Repository;
using System.Configuration;
using ETS.Controllers;

namespace ETS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private ILogoutService LogoutService { get; set; }

        public MvcApplication()
        {
            this.LogoutService = new LogoutService(new LogoutRepository(new DbConnectionFactory(ConfigurationManager.ConnectionStrings["ETSConnString"].ConnectionString)));
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_End(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(Convert.ToString(Session["user"])))
            {
                LogoutService.UserLogOut(Convert.ToString(Session["user"]), "Session Time Out");
                Session.Clear();
                Session.Abandon();
            }
        }
    }
}
