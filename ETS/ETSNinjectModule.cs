using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using ETS.Models.Repository;
using ETS.Models.Service;
using System.Configuration;

namespace ETS
{
    public class ETSNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbConnectionFactory>().To<DbConnectionFactory>()
                .WithConstructorArgument("connectionString",
                ConfigurationManager.ConnectionStrings["ETSConnString"].ConnectionString);

            //Repositories
            Bind<ILoginRepository>().To<LoginRepository>();

            //Services
            Bind<ILoginService>().To<LoginService>();

        }
    }
}