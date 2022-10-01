using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
        public ActionResult Details(int? id)
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

        // GET: AdminCongNghes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminCongNghes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TuaDe11,NoiDung11,TuaDe12,NoiDung12,Hinh1,TuaDe2,NoiDung2,Hinh2,TuaDeChinh,TrichDan")] CongNghe congNghe)
        {
            if (ModelState.IsValid)
            {
                db.CongNghes.Add(congNghe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(congNghe);
        }

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TuaDe11,NoiDung11,TuaDe12,NoiDung12,Hinh1,TuaDe2,NoiDung2,Hinh2,TuaDeChinh,TrichDan")] CongNghe congNghe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(congNghe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(congNghe);
        }

        // GET: AdminCongNghes/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: AdminCongNghes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CongNghe congNghe = db.CongNghes.Find(id);
            db.CongNghes.Remove(congNghe);
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
