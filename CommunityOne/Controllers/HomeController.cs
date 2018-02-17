using System.Web.Mvc;
using CommunityOne.Toolkit;
using System.Collections.Generic;
using CommunityOne.Models;
using System.Data.Sql;
using System.Data;
using System.Linq;
using System;
using System.Data.SqlClient;
using System.Configuration;

namespace CommunityOne.Controllers
{
    public class HomeController : Controller
    {
        CommunityOneEntities db = new CommunityOneEntities();

        [NoCache]
        [Authorize]
        public ActionResult Index()
        {
            List<UserMenu> menuList = new List<UserMenu>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CommunityOneDbContext"].ToString()))
            {
                con.Open();

                string query = "Select * from tblMenu where isActive=1";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
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
            return View(menuList);
        }

        public ActionResult AnotherLink()
        {
            return View("Index");
        }

        public JsonResult loadPoHeader()
        {

            List<POHDRshrt_ViewModel> polist = db.loadPOHeaderShort("CLA", "100").Select(x => new POHDRshrt_ViewModel
            {
                ponumb = (int)x.PO_No,
                postat = x.PO_Stat + " - " + x.PO_Status_Des,
                vendor = x.PO_Vendor_No.ToString() + " - " + x.PO_Vendor_Name,
                poedat = x.PO_Entry_Date,
                pocost = x.PO_Cost,
                pomalw = x.PO_SKU_Level_Allowance,
                povalw = x.PO_Vendor_Level_Allowance,
                buyer = x.PO_Buyer_Init + " - " + x.PO_Buyer_Name
            }).ToList();

            return Json(polist, JsonRequestBehavior.AllowGet);
        }


        private IEnumerable<UserMenu> getMenuTree(List<UserMenu> l, int? menuParentId)
        {
            return l.Where(x => x.menuParentId == menuParentId).Select(x => new UserMenu()
            {
                menuId = x.menuId,
                menuTitle = x.menuTitle,
                menuLink = x.menuLink,
                menuParentId = x.menuParentId,
                isActive = x.isActive,
                menmenu = getMenuTree(l, x.menuId)
            }).ToList();
        }
    }
}
