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
    public class AdminGiaiPhapsController : Controller
    {
        private NEWHOUSE2022Entities db = new NEWHOUSE2022Entities();

        // GET: AdminGiaiPhaps
        public ActionResult Index()
        {
            return View(db.GiaiPhaps.OrderByDescending(b => b.ID).ToList());
        }

        // GET: AdminGiaiPhaps/Details/5
        

        // GET: AdminGiaiPhaps/Create
        public ActionResult Create()
        {
         
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: AdminGiaiPhaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create( GiaiPhap giaiPhap, HttpPostedFileBase uploadhinh)
        {
             
            db.GiaiPhaps.Add(giaiPhap);
            db.SaveChanges();
            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                int id = int.Parse(db.GiaiPhaps.ToList().Last().ID.ToString());

                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "giaiPhap" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Content/img/giaiphap/"), _FileName);
                uploadhinh.SaveAs(_path);

                GiaiPhap unv = db.GiaiPhaps.FirstOrDefault(x => x.ID == id);
                unv.Hinh = _FileName;
                db.SaveChanges();
            }
            return RedirectToAction("Index", "AdminGiaiPhaps");
        }
     
        // GET: AdminGiaiPhaps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaiPhap giaiPhap = db.GiaiPhaps.Find(id);
            if (giaiPhap == null)
            {
                return HttpNotFound();
            }
            return View(giaiPhap);
        }

        // POST: AdminGiaiPhaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( GiaiPhap giaiPhap, HttpPostedFileBase uploadhinh)
        {
            GiaiPhap unv = db.GiaiPhaps.FirstOrDefault(x => x.ID == giaiPhap.ID);
            unv.TuaDe = giaiPhap.TuaDe;
            unv.NoiDung = giaiPhap.NoiDung;

            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                int id = giaiPhap.ID;
                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "giaiphap" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Content/img/giaiphap"), _FileName);
                uploadhinh.SaveAs(_path);
                unv.Hinh = _FileName;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        // GET: AdminGiaiPhaps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaiPhap giaiPhap = db.GiaiPhaps.Find(id);
            if (giaiPhap == null)
            {
                return HttpNotFound();
            }
            return View(giaiPhap);
        }

        // POST: AdminGiaiPhaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GiaiPhap giaiPhap = db.GiaiPhaps.Find(id);
            db.GiaiPhaps.Remove(giaiPhap);
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
