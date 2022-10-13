using NEWHOUSE_REBUILD_2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NEWHOUSE_REBUILD_2022.Controllers
{
    public class HomeController : Controller
    {
        private NEWHOUSE2022Entities db = new NEWHOUSE2022Entities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Slider()
        {
            return View(db.Slides.ToList());
        }

        public ActionResult GiaiPhap()
        {
            return View(db.GiaiPhaps.ToList());
        }

        public ActionResult CongNghe()
        {
            return View(db.CongNghes.ToList());
        }

        public ActionResult SanPham()
        {
            var LoiGioiThieu = (from loigioithieu in db.LoiGioiThieux
                                select loigioithieu.GioiThieuSanPham).FirstOrDefault();
            ViewBag.LoiGioiThieu = LoiGioiThieu;
            return View(db.SanPhams.ToList());
        }

        public ActionResult SanPham_Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(db.SanPhams.ToList());
        }

        public ActionResult TinhNang()
        {
            var LoiGioiThieu = (from loigioithieu in db.LoiGioiThieux
                                select loigioithieu.GioiThieuTinhNang).FirstOrDefault();
            ViewBag.LoiGioiThieu = LoiGioiThieu;
            return View(db.TinhNangs.ToList());
        }

        public ActionResult DuAn()
        {
            return View(db.DUANs.ToList());
        }
        public ActionResult DuAn_Details(int? id)
        {
            return View(db.DUANs.ToList());
        }
        public ActionResult TinTuc()
        {
            return View(db.TinTucs.ToList());
        }

        public ActionResult KienTrucSu()
        {
            var LoiGioiThieuKTS = (from loigioithieu in db.LoiGioiThieux
                               select loigioithieu.GioiThieuKTS).FirstOrDefault();
            ViewBag.LoiGioiThieuKTS = LoiGioiThieuKTS;
            return View(db.KTS.ToList());
        }
        public ActionResult KienTrucSu_Details(int? id)
        {
            return View(db.KTS.ToList());
        }

        public ActionResult DoiTac()
        {
            return View(db.DoiTacs.ToList());
        }

        public ActionResult LienHe()
        {
            return View(db.LienHes.ToList());
        }
    }
}