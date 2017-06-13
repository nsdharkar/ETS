﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ETS.Models.Repository;
using ETS.Models.Entity;

namespace ETS.Models.Service
{
    public interface ILoginService
    {
        UserMaster CheckUserAuthentication(UserMaster userMaster);
    }
    public class LoginService : ILoginService
    {
        protected ILoginRepository LoginRepository { get; set; }

        public LoginService()
        { }
        public LoginService(ILoginRepository loginRepository)
        {
            LoginRepository = loginRepository;
        }

        public UserMaster CheckUserAuthentication(UserMaster userMaster)
        {
            string userName = userMaster.UserName;
            string passWord = userMaster.Password;

            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(passWord))
            {
                return LoginRepository.CheckUserAuthentication(userMaster);
            }
            else
                throw new ArgumentNullException("Username or password cannot be null or empty.");
        }
    }
}