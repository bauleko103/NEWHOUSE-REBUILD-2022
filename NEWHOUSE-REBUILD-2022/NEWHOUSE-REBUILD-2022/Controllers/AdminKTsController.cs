using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NEWHOUSE_REBUILD_2022.Models;

namespace NEWHOUSE_REBUILD_2022.Controllers
{
    public class AdminKTsController : Controller
    {
        private NEWHOUSE2022Entities db = new NEWHOUSE2022Entities();

        // GET: AdminKTs
        public ActionResult Index()
        {
            return View(db.KTS.ToList());
        }

        // GET: AdminKTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KT kT = db.KTS.Find(id);
            if (kT == null)
            {
                return HttpNotFound();
            }
            return View(kT);
        }

        // GET: AdminKTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminKTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create( KT kT, HttpPostedFileBase uploadhinh)
        {
            db.KTS.Add(kT);
            db.SaveChanges();
            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                int id = int.Parse(db.KTS.ToList().Last().IDKTS.ToString());

                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "kts" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Content/img/kts/"), _FileName);
                uploadhinh.SaveAs(_path);

                KT unv = db.KTS.FirstOrDefault(x => x.IDKTS == id);
                unv.Hinh = _FileName;
                db.SaveChanges();
            }
            return RedirectToAction("Index", "AdminKTs");
 

        }

        // GET: AdminKTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KT kT = db.KTS.Find(id);
            if (kT == null)
            {
                return HttpNotFound();
            }
            return View(kT);
        }

        // POST: AdminKTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( KT kT, HttpPostedFileBase uploadhinh)
        {
             KT unv = db.KTS.FirstOrDefault(x => x.IDKTS == kT.IDKTS);
            unv.TuaDe = kT.TuaDe;
            unv.TuaDePhu = kT.TuaDePhu;
            unv.NgayThang = kT.NgayThang;
            unv.NoiDung = kT.NoiDung;
            unv.GioiThieu = kT.GioiThieu;
            unv.LoaiKTS = kT.LoaiKTS;
            unv.CongViec = kT.CongViec;
           
            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                int id = kT.IDKTS;
                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "kts" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Content/img/kts"), _FileName);
                uploadhinh.SaveAs(_path);
                unv.Hinh = _FileName;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: AdminKTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KT kT = db.KTS.Find(id);
            if (kT == null)
            {
                return HttpNotFound();
            }
            return View(kT);
        }

        // POST: AdminKTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KT kT = db.KTS.Find(id);
            db.KTS.Remove(kT);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
