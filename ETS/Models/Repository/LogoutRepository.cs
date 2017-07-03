using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;

namespace ETS.Models.Repository
{
    public interface ILogoutRepository
    {
        void UserLogOut(int userId, string remarks);
    }

    public class LogoutRepository : ILogoutRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public LogoutRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public void UserLogOut(int userId, string remarks)
        {
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Query<int>("usp_userLogOut", new { @UserId = userId, @Remarks = remarks }, null, true, 5000, System.Data.CommandType.StoredProcedure);
            }
        }
    }
}