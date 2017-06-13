using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ETS.Models.Entity;
using Dapper;

namespace ETS.Models.Repository
{
    public interface ILoginRepository
    {
        UserMaster CheckUserAuthentication(UserMaster userMaster);
    }
    public class LoginRepository : ILoginRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public LoginRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public UserMaster CheckUserAuthentication(UserMaster userMaster)
        {
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                return conn.QueryFirstOrDefault<UserMaster>("usp_chkUserExist", new { @username = userMaster.UserName, @passwd = userMaster.Password },null,5000,System.Data.CommandType.StoredProcedure);
            }
        }
    }
}