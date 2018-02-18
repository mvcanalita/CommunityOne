using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityOne.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace CommunityOne.Controllers
{
    public class UserMenuController : Controller
    {

        CommunityOneEntities _db = new CommunityOneEntities();

        [ChildActionOnly]
        // GET: UserMenu 
        public ActionResult FetchUserMenu()
        {

            List<UserMenu> menuList = new List<UserMenu>();
            using(SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CommunityOneDbContext"].ToString()))
            {
                string query = "Select * from tblMenu where isActive=1";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using(SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            UserMenu m = new UserMenu()
                            {
                                menuId = Convert.ToInt32(rdr["menuId"]),
                                menuTitle = rdr["menuTitle"].ToString(),
                                menuLink = rdr["menuLink"].ToString(),
                                menuParentId = rdr["menuParentId"] != DBNull.Value ? Convert.ToInt32(rdr["menuParentId"]) : (int?)null,
                                isActive = Convert.ToBoolean(rdr["isActive"])
                            };
                            menuList.Add(m);
                        }
                    }
                  
                }


            }
            IEnumerable<UserMenu> menuTree = getMenuTree(menuList, null);
            return PartialView(menuTree);
        }

        private List<UserMenu> getMenuTree(IEnumerable<UserMenu> l, int? menuParentId)
        {
            return l.Where(x => x.menuParentId == menuParentId).Select(x => new UserMenu()
            {
                menuId = x.menuId,
                menuTitle = x.menuTitle,
                menuLink = x.menuLink,
                menuParentId = x.menuParentId,
                isActive = x.isActive,
                menmenu = getMenuTree(l,x.menuId)
            }).ToList();
        }
    }
}