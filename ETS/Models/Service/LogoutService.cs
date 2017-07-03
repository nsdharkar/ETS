using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ETS.Models.Repository;

namespace ETS.Models.Service
{
    public interface ILogoutService
    {
        void UserLogOut(string sessionValue, string remarks);
    }

    public class LogoutService : ILogoutService
    {
        protected ILogoutRepository LogoutRepository { get; set; }

        public LogoutService(ILogoutRepository logoutRepository)
        {
            LogoutRepository = logoutRepository;
        }

        public void UserLogOut(string sessionValue , string remarks)
        {
            var userId = sessionValue.Split('|')[0];
            LogoutRepository.UserLogOut(Convert.ToInt16(userId), remarks);
        }
    }
}