using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityOne.Models;
using System.Security.Claims;
using System.Data.Entity;

namespace CommunityOne.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private CommunityOneEntities databaseManager = new CommunityOneEntities();

        // GET: Auth
        public ActionResult Login()
        {
            if (this.Request.IsAuthenticated)
            {
                return this.RedirectToAction("Index", "Home");
            }

            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            string err = "";

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using(CommunityOneEntities n = new CommunityOneEntities())
            {
                var io = (from i in n.tblUsrInfoes
                         join d in n.tblUsrDetails on i.UsrInfoID equals d.UsrInfoID
                         where i.UsrName == model.UsrName && i.UsrPass == model.UsrPass
                         select new { i.UsrName, i.UsrIsLog, i.UsrStatus, d.UsrFName, d.UsrLName, d.UsrEmpCode });

                var usrDetails = io.FirstOrDefault();
                if (io != null && io.Count()>0)
                {
                    if(usrDetails.UsrStatus == false)
                    {
                        err = "User is locked";
                    }else
                    {
                        LoginModel m = new LoginModel()
                        {
                            UsrName = usrDetails.UsrName,
                            UsrFname = usrDetails.UsrFName,
                            UsrLName = usrDetails.UsrLName,
                            UsrIsLog = usrDetails.UsrIsLog,
                            UsrStatus = usrDetails.UsrStatus
                        };

                        SignInUser(m, false);

                        return RedirectToAction("Index", "Home");
                    }
                }else
                {
                    err = "Incorrect username or password.";
                }

            }

            ModelState.AddModelError("", err);
            
            return View(model);
        }

        private void SignInUser(LoginModel model, bool v)
        {
            var identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name,model.UsrFname + model.UsrLName),
                new Claim(ClaimTypes.UserData, model.UsrName)
            },"ApplicationCookie");

            var authmanager = Request.GetOwinContext().Authentication;

            authmanager.SignIn(identity);

        }

        public ActionResult Logout()
        {
            var authManager = Request.GetOwinContext().Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Login", "Auth");
        }
    }
}