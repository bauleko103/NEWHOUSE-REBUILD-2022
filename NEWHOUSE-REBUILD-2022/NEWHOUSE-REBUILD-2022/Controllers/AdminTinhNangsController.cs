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
    public class AdminTinhNangsController : Controller
    {
        private NEWHOUSE2022Entities db = new NEWHOUSE2022Entities();

        // GET: AdminTinhNangs
        public ActionResult Index()
        {
            return View(db.TinhNangs.ToList());
        }

        

        // GET: AdminTinhNangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminTinhNangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create( TinhNang tinhNang, HttpPostedFileBase uploadhinh)
        {
            db.TinhNangs.Add(tinhNang);
            db.SaveChanges();
            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                int id = int.Parse(db.TinhNangs.ToList().Last().ID.ToString());

                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "tinhnang" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Content/img/tinhnang/"), _FileName);
                uploadhinh.SaveAs(_path);

                TinhNang unv = db.TinhNangs.FirstOrDefault(x => x.ID == id);
                unv.Hinh = _FileName;
                db.SaveChanges();
            }
            return RedirectToAction("Index", "AdminTinhNangs");
             
        }
         

        // GET: AdminTinhNangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinhNang tinhNang = db.TinhNangs.Find(id);
            if (tinhNang == null)
            {
                return HttpNotFound();
            }
            return View(tinhNang);
        }

        // POST: AdminTinhNangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( TinhNang tinhNang, HttpPostedFileBase uploadhinh)
        {
            TinhNang unv = db.TinhNangs.FirstOrDefault(x => x.ID == tinhNang.ID);
            unv.TuaDe = tinhNang.TuaDe;
            unv.NoiDung = tinhNang.NoiDung;
            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                int id = tinhNang.ID;
                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "tinhnang" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Content/img/tinhnang"), _FileName);
                uploadhinh.SaveAs(_path);
                unv.Hinh = _FileName;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        // GET: AdminTinhNangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinhNang tinhNang = db.TinhNangs.Find(id);
            if (tinhNang == null)
            {
                return HttpNotFound();
            }
            return View(tinhNang);
        }

        // POST: AdminTinhNangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TinhNang tinhNang = db.TinhNangs.Find(id);
            db.TinhNangs.Remove(tinhNang);
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
