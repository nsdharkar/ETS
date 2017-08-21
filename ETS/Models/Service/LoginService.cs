using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ETS.Models.Repository;
using ETS.Models.Entity;
using System.Security.Cryptography;
using System.Text;

namespace ETS.Models.Service
{
    public interface ILoginService
    {
        UserMaster CheckUserAuthentication(UserMaster userMaster);
        string CreateUserSessionValue(UserMaster authenticatedUser);
        void CreateUserLog(UserMaster userMaster);
    }
    public class LoginService : ILoginService
    {
        protected ILoginRepository LoginRepository { get; set; }

        public LoginService(ILoginRepository loginRepository)
        {
            LoginRepository = loginRepository;
        }

        public UserMaster CheckUserAuthentication(UserMaster userMaster)
        {
            //string userName = userMaster.UserName;
            userMaster.Password = GetEncryptedPassword(userMaster);

            if (!string.IsNullOrEmpty(userMaster.UserName) && !string.IsNullOrEmpty(userMaster.Password))
            {
                return LoginRepository.CheckUserAuthentication(userMaster);
            }
            else
                throw new ArgumentNullException("Username or password cannot be null or empty.");
        }

        public string CreateUserSessionValue(UserMaster authenticatedUser)
        {
            return authenticatedUser.UserId + "|" + authenticatedUser.UserName;
        }

        public void CreateUserLog(UserMaster userMaster)
        {
            LoginRepository.CreateUserLog(userMaster);
        }

        private string GetEncryptedPassword(UserMaster userMaster)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                return GetMd5Hash(md5Hash, userMaster.Password);
            }
        }

        private string GetMd5Hash(MD5 md5Hash, string password)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}