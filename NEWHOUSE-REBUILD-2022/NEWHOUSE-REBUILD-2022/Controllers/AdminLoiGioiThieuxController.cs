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
    public class AdminLoiGioiThieuxController : Controller
    {
        private NEWHOUSE2022Entities db = new NEWHOUSE2022Entities();

        // GET: AdminLoiGioiThieux
        public ActionResult Index()
        {
            return View(db.LoiGioiThieux.ToList());
        }

        // GET: AdminLoiGioiThieux/Details/5
        

        // GET: AdminLoiGioiThieux/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoiGioiThieu loiGioiThieu = db.LoiGioiThieux.Find(id);
            if (loiGioiThieu == null)
            {
                return HttpNotFound();
            }
            return View(loiGioiThieu);
        }

        // POST: AdminLoiGioiThieux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,GioiThieuSanPham,GioiThieuTinhNang,GioiThieuKTS")] LoiGioiThieu loiGioiThieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loiGioiThieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loiGioiThieu);
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
