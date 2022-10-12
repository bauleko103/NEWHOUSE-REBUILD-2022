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
    public class AdminKTS_DUANController : Controller
    {
        private NEWHOUSE2022Entities db = new NEWHOUSE2022Entities();

        // GET: AdminKTS_DUAN
        public ActionResult Index()
        {
            var kTS_DUAN = db.KTS_DUAN.Include(k => k.DUAN).Include(k => k.KT);

            return View(kTS_DUAN.ToList());
        }

        // GET: AdminKTS_DUAN/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KTS_DUAN kTS_DUAN = db.KTS_DUAN.Find(id);
            if (kTS_DUAN == null)
            {
                return HttpNotFound();
            }
            return View(kTS_DUAN);
        }

        // GET: AdminKTS_DUAN/Create
        public ActionResult Create()
        {
            ViewBag.IDDuan = new SelectList(db.DUANs, "IDDuan", "TuaDe");
            ViewBag.IDKTS = new SelectList(db.KTS, "IDKTS", "TuaDe");
            return View();
        }

        // POST: AdminKTS_DUAN/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDDuan,IDKTS")] KTS_DUAN kTS_DUAN)
        {
            if (ModelState.IsValid)
            {

                db.KTS_DUAN.Add(kTS_DUAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDDuan = new SelectList(db.DUANs, "IDDuan", "TuaDe", kTS_DUAN.IDDuan);
            ViewBag.IDKTS = new SelectList(db.KTS, "IDKTS", "TuaDe", kTS_DUAN.IDKTS);
            return View(kTS_DUAN);
        }

        // GET: AdminKTS_DUAN/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KTS_DUAN kTS_DUAN = db.KTS_DUAN.Find(id);
            if (kTS_DUAN == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDDuan = new SelectList(db.DUANs, "IDDuan", "TuaDe", kTS_DUAN.IDDuan);
            ViewBag.IDKTS = new SelectList(db.KTS, "IDKTS", "TuaDe", kTS_DUAN.IDKTS);
            return View(kTS_DUAN);
        }

        // POST: AdminKTS_DUAN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDDuan,IDKTS")] KTS_DUAN kTS_DUAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kTS_DUAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDDuan = new SelectList(db.DUANs, "IDDuan", "TuaDe", kTS_DUAN.IDDuan);
            ViewBag.IDKTS = new SelectList(db.KTS, "IDKTS", "TuaDe", kTS_DUAN.IDKTS);
            return View(kTS_DUAN);
        }

        // GET: AdminKTS_DUAN/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KTS_DUAN kTS_DUAN = db.KTS_DUAN.Find(id);
            if (kTS_DUAN == null)
            {
                return HttpNotFound();
            }
            return View(kTS_DUAN);
        }

        // POST: AdminKTS_DUAN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KTS_DUAN kTS_DUAN = db.KTS_DUAN.Find(id);
            db.KTS_DUAN.Remove(kTS_DUAN);
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
