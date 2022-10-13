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
    public class AdminCongNghesController : Controller
    {
        private NEWHOUSE2022Entities db = new NEWHOUSE2022Entities();

        // GET: AdminCongNghes
        public ActionResult Index()
        {
            return View(db.CongNghes.ToList());
        }

        // GET: AdminCongNghes/Details/5
         
        // GET: AdminCongNghes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongNghe congNghe = db.CongNghes.Find(id);
            if (congNghe == null)
            {
                return HttpNotFound();
            }
            return View(congNghe);
        }

        // POST: AdminCongNghes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( CongNghe congNghe, HttpPostedFileBase uploadhinh1, HttpPostedFileBase uploadhinh2)
        {
            CongNghe unv = db.CongNghes.FirstOrDefault(x => x.ID == congNghe.ID);
            unv.TuaDeChinh = congNghe.TuaDeChinh;
            unv.TrichDan = congNghe.TrichDan;
            unv.TuaDe11 = congNghe.TuaDe11;
            unv.TuaDe12 = congNghe.TuaDe12;
            unv.NoiDung11 = congNghe.NoiDung11;
            unv.NoiDung12 = congNghe.NoiDung12;
            unv.TuaDe2 = congNghe.TuaDe2;
            unv.NoiDung2 = congNghe.NoiDung2;
            if (uploadhinh1 != null && uploadhinh1.ContentLength > 0)
            {
                int id = congNghe.ID;
                string _FileName = "";
                int index = uploadhinh1.FileName.IndexOf('.');
                _FileName = "congnghe1" + id.ToString() + "." + uploadhinh1.FileName.Substring(index + 1);
                string _path1 = Path.Combine(Server.MapPath("~/Content/img/congnghe"), _FileName);
                uploadhinh1.SaveAs(_path1);
                unv.Hinh1 = _FileName;
            }
            if (uploadhinh2 != null && uploadhinh2.ContentLength > 0)
            {
                int id = congNghe.ID;
                string _FileName = "";
                int index = uploadhinh2.FileName.IndexOf('.');
                _FileName = "congnghe2" + id.ToString() + "." + uploadhinh2.FileName.Substring(index + 1);
                string _path2 = Path.Combine(Server.MapPath("~/Content/img/congnghe"), _FileName);
                uploadhinh2.SaveAs(_path2);
                unv.Hinh2 = _FileName;
            }
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
