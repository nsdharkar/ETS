using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ETS.Models.Entity;
using Dapper;
using log4net;

namespace ETS.Models.Repository
{
    public interface ILoginRepository
    {
        UserMaster CheckUserAuthentication(UserMaster userMaster);
        void CreateUserLog(UserMaster userMaster);
    }
    public class LoginRepository : ILoginRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        private static readonly ILog logger = LogManager.GetLogger(typeof(LoginRepository));

        public LoginRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public UserMaster CheckUserAuthentication(UserMaster userMaster)
        {
            logger.Debug("User Authentication function called.");
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                return conn.QueryFirstOrDefault<UserMaster>("usp_chkUserExist", new { @username = userMaster.UserName, @passwd = userMaster.Password }, null, 5000, System.Data.CommandType.StoredProcedure);
            }
        }

        public void CreateUserLog(UserMaster userMaster)
        {
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Query<int>("usp_createUserLog", new { @UserId = userMaster.UserId }, null, true, 5000, System.Data.CommandType.StoredProcedure);
            }
        }
    }
}