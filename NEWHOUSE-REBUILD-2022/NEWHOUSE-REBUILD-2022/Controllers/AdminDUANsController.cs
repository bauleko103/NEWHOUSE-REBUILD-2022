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
    public class AdminDUANsController : Controller
    {
        private NEWHOUSE2022Entities db = new NEWHOUSE2022Entities();

        // GET: AdminDUANs
        public ActionResult Index( )
        {
            //var kTS_DUAN = db.KTS_DUAN.Include(k => k.DUAN).Include(k => k.KT);

            ViewBag.IDKTS = new SelectList(db.KTS, "IDKTS", "TuaDe");
           
            ViewBag.ID = db.KTS_DUAN.Include(k => k.DUAN).Include(k => k.KT);
            return View(db.DUANs.ToList());
        }

        // GET: AdminDUANs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DUAN dUAN = db.DUANs.Find(id);
           
            if (dUAN == null)
            {
                return HttpNotFound();
            }
            var hinhanh = from HA in db.DUANs
                          join DA in db.KTS_DUAN on HA.IDDuan equals DA.IDDuan
                          where DA.ID == id
                          select HA;
            ViewBag.hinhanh = hinhanh;
            return View(dUAN);
        }

        // GET: AdminDUANs/Create
        public ActionResult Create()
        {
            ViewBag.IDDuan = new SelectList(db.DUANs, "IDDuan", "TuaDe");
            ViewBag.IDKTS = new SelectList(db.KTS, "IDKTS", "TuaDe");
            return View();
        }

        // POST: AdminDUANs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create( DUAN dUAN, HttpPostedFileBase uploadhinh,  KTS_DUAN kTS_DUAN,  string chuoi )
        {
            /* //ViewBag.IDDuan = new SelectList(db.DUANs, "IDDuan", "TuaDe", kTS_DUAN.IDDuan);
             ViewBag.IDKTS = new SelectList(db.KTS, "IDKTS", "TuaDe", dUAN.IDDuan);

             kTS_DUAN.KT.TuaDe = ViewBag.IDKTS;
             db.KTS_DUAN.Add(kTS_DUAN);
             db.SaveChanges();*/
         
            db.DUANs.Add(dUAN); 
            db.SaveChanges();
            
            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                int id = int.Parse(db.DUANs.ToList().Last().IDDuan.ToString());

                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "duan" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Content/img/duan/"), _FileName);
                uploadhinh.SaveAs(_path);

                DUAN unv = db.DUANs.FirstOrDefault(x => x.IDDuan == id);
                unv.Hinh = _FileName;
                db.SaveChanges();
            }


            kTS_DUAN.IDDuan = dUAN.IDDuan;
            kTS_DUAN.IDKTS =chuoi;
            db.KTS_DUAN.Add(kTS_DUAN);
            ViewBag.IDKTS = new SelectList(db.KTS, "IDKTS", "TuaDe", dUAN.IDDuan);
            db.SaveChanges();
            return RedirectToAction("Index", "AdminDUANs");

             
        }

        // GET: AdminDUANs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DUAN dUAN = db.DUANs.Find(id);
            if (dUAN == null)
            {
                return HttpNotFound();
            }
            return View(dUAN);
        }


        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( DUAN dUAN, HttpPostedFileBase uploadhinh)
        {
            

            DUAN unv = db.DUANs.FirstOrDefault(x => x.IDDuan == dUAN.IDDuan);
            unv.TuaDe = dUAN.TuaDe;
            unv.TuaDePhu = dUAN.TuaDePhu;
            unv.NgayThang = dUAN.NgayThang;
            unv.NoiDung = dUAN.NoiDung;
            unv.GioiThieu = dUAN.GioiThieu;
            unv.LoaiDuAn = dUAN.LoaiDuAn;
            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                int id = dUAN.IDDuan;
                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "duan" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Content/img/duan"), _FileName);
                uploadhinh.SaveAs(_path);
                unv.Hinh = _FileName;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: AdminDUANs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DUAN dUAN = db.DUANs.Find(id);
            if (dUAN == null)
            {
                return HttpNotFound();
            }
            return View(dUAN);
        }

        // POST: AdminDUANs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DUAN dUAN = db.DUANs.Find(id);
            db.DUANs.Remove(dUAN);
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
