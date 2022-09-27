using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NEWHOUSE_REBUILD_2022.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Slider()
        {
            return View();
        }

        public ActionResult DuAn()
        {
            return View();
        }

        public ActionResult TinTuc()
        {
            return View();
        }

        public ActionResult KienTrucSu()
        {
            return View();
        }

        public ActionResult DoiTac()
        {
            return View();
        }

        public ActionResult LienHe()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}