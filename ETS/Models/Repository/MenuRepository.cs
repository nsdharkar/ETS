using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ETS.Models.Entity;
using Dapper;

namespace ETS.Models.Repository
{
    public interface IMenuRepository
    {
        IList<UserMenu> GetUserMenu(string user);
    }
    public class MenuRepository : IMenuRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public MenuRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public IList<UserMenu> GetUserMenu(string user)
        {
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                return conn.Query<UserMenu>("usp_getMenuItems", new { @user = user }, null, false, 5000, System.Data.CommandType.StoredProcedure).ToList();
            }
        }
    }
}