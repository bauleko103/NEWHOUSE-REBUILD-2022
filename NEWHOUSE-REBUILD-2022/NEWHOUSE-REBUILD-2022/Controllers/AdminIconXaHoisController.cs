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
    public class AdminIconXaHoisController : Controller
    {
        private NEWHOUSE2022Entities db = new NEWHOUSE2022Entities();

        // GET: AdminIconXaHois
        public ActionResult Index()
        {
            return View(db.IconXaHois.ToList());
        }
         
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IconXaHoi iconXaHoi = db.IconXaHois.Find(id);
            if (iconXaHoi == null)
            {
                return HttpNotFound();
            }
            return View(iconXaHoi);
        }

        // POST: AdminIconXaHois/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Icon1,Link1,Icon2,Link2,Icon3,Link3,Icon4,Link4")] IconXaHoi iconXaHoi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iconXaHoi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iconXaHoi);
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
