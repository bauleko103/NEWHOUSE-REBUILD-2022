using NEWHOUSE_REBUILD_2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NEWHOUSE_REBUILD_2022.Controllers
{
    public class AdminController : Controller
    {
        private NEWHOUSE2022Entities db = new NEWHOUSE2022Entities();
        // GET: Admin
        
        // page login tk
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(NEWHOUSE_REBUILD_2022.Models.ADMIN userModel)
        {
            using (NEWHOUSE2022Entities db = new NEWHOUSE2022Entities())
            {
                var userDetails = db.ADMINs.Where(x => x.TaiKhoan == userModel.TaiKhoan && x.MatKhau == userModel.MatKhau).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong username or password.";
                    return View(userModel);
                }
                else
                {
                    Session["userID"] = userDetails.TaiKhoan;
                    Session["userMK"] = userDetails.MatKhau;
                    return RedirectToAction("Index", "Admin");
                }
            }
        }
        // page index dash
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }

        }

         
    }
}