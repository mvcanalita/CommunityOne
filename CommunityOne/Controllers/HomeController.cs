using System.Web.Mvc;
using CommunityOne.Toolkit;
using System.Collections.Generic;
using CommunityOne.Models;
using System.Data.Sql;
using System.Data;
using System.Linq;
using System;

namespace CommunityOne.Controllers
{
    public class HomeController : Controller
    {
        [NoCache]
        [Authorize]
        public ActionResult Index()
        {
            CommunityOneEntities db = new CommunityOneEntities();

            IEnumerable<POHDRshrt_ViewModel> polist = db.vw_POHeaderShort.Where(x => x.PO_Buyer_Init == "CLA").Select(x => new POHDRshrt_ViewModel
            {
                ponumb = (int)x.PO_No,
                postat = x.PO_Stat + " - " + x.PO_Status_Des,
                vendor = x.PO_Vendor_No.ToString() + " - " + x.PO_Vendor_Name,
                poedat = x.PO_Entry_Date,
                pocost = x.PO_Cost,
                pomalw = x.PO_SKU_Level_Allowance,
                povalw = x.PO_Vendor_Level_Allowance,
                buyer = x.PO_Buyer_Init + " - " + x.PO_Buyer_Name
            }).OrderByDescending(x=>x.ponumb).Take(10).ToList();

            return View(polist);
        }

        public ActionResult AnotherLink()
        {
            return View("Index");
        }

        public JsonResult loadPoHeader()
        {
            CommunityOneEntities db = new CommunityOneEntities();

            List<POHDRshrt_ViewModel> polist = db.vw_POHeaderShort.Where(x => x.PO_Buyer_Init == "CLA").Select(x => new POHDRshrt_ViewModel {
                ponumb=(int)x.PO_No,
                postat=x.PO_Stat + " - " + x.PO_Status_Des,
                vendor=x.PO_Vendor_No.ToString() + " - " + x.PO_Vendor_Name,
                poedat=x.PO_Entry_Date,
                pocost=x.PO_Cost,
                pomalw=x.PO_SKU_Level_Allowance,
                povalw=x.PO_Vendor_Level_Allowance,
                buyer=x.PO_Buyer_Init + " - " + x.PO_Buyer_Name
            }).ToList();
            
            return Json(polist, JsonRequestBehavior.AllowGet);
        }
    }
}
