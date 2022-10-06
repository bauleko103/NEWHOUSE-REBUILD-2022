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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDKTS,TuaDe,TuaDePhu,ThongTin,HinhGioiThieu,TieuChi1,TieuChi2,TieuChi3")] KT kT)
        {
            if (ModelState.IsValid)
            {
                db.KTS.Add(kT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kT);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDKTS,TuaDe,TuaDePhu,ThongTin,HinhGioiThieu,TieuChi1,TieuChi2,TieuChi3")] KT kT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kT);
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
