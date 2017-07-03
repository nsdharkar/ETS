using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ETS.Models.Repository;
using ETS.Models.Entity;

namespace ETS.Models.Service
{
    public interface IMenuService
    {
        IList<UserMenu> GetUserMenu(string user);
    }
    public class MenuService : IMenuService
    {
        protected IMenuRepository MenuRepository { get; set; }

        public MenuService(IMenuRepository menuRepository)
        {
            MenuRepository = menuRepository;
        }

        public IList<UserMenu> GetUserMenu(string user)
        {
            if (!string.IsNullOrEmpty(user))
                return MenuRepository.GetUserMenu(user);
            else
                throw new ArgumentNullException("User cannot be null or blank");
        }
    }
}