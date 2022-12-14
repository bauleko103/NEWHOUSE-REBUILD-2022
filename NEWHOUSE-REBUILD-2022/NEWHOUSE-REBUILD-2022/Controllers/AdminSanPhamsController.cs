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
    public class AdminSanPhamsController : Controller
    {
        private NEWHOUSE2022Entities db = new NEWHOUSE2022Entities();

        // GET: AdminSanPhams
        public ActionResult Index()
        {
            return View(db.SanPhams.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sp = db.SanPhams.Find(id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }

        // GET: AdminSanPhams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminSanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
         
        public ActionResult Create(  SanPham sanPham, HttpPostedFileBase uploadhinh)
        {
            db.SanPhams.Add(sanPham);
            db.SaveChanges();
            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                int id = int.Parse(db.SanPhams.ToList().Last().ID.ToString());

                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "sanpham" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Content/img/sanpham/"), _FileName);
                uploadhinh.SaveAs(_path);

                SanPham unv = db.SanPhams.FirstOrDefault(x => x.ID == id);
                unv.HinhGioiThieu= _FileName;
                db.SaveChanges();
            }
            return RedirectToAction("Index", "AdminSanPhams");
        }
        

        // GET: AdminSanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: AdminSanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
       
        public ActionResult Edit( SanPham sanPham, HttpPostedFileBase uploadhinh)
        {
             
            SanPham unv = db.SanPhams.FirstOrDefault(x => x.ID == sanPham.ID);
            unv.TuaDe = sanPham.TuaDe;
            unv.TuaDePhu = sanPham.TuaDePhu;
            unv.ViTri = sanPham.ViTri;
            unv.NoiDung = sanPham.NoiDung;
            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                int id = sanPham.ID;
                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "sanpham" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Content/img/sanpham"), _FileName);
                uploadhinh.SaveAs(_path);
                unv.HinhGioiThieu = _FileName;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        

        // GET: AdminSanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: AdminSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
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
