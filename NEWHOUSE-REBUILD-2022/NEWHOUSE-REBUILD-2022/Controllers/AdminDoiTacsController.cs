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
    public class AdminDoiTacsController : Controller
    {
        private NEWHOUSE2022Entities db = new NEWHOUSE2022Entities();

        // GET: AdminDoiTacs
        public ActionResult Index()
        {
            return View(db.DoiTacs.ToList());
        }

        // GET: AdminDoiTacs/Details/5
        

        // GET: AdminDoiTacs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminDoiTacs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create( DoiTac doiTac, HttpPostedFileBase uploadhinh)
        {
             
            db.SaveChanges();
            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                int id = int.Parse(db.Slides.ToList().Last().ID.ToString());

                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "slide" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Content/img/doitac/"), _FileName);
                uploadhinh.SaveAs(_path);

                DoiTac unv = db.DoiTacs.FirstOrDefault(x => x.ID == id);
                unv.Hinh = _FileName;
                db.SaveChanges();
            }
            return RedirectToAction("Index", "AdminDoiTacs");
        }
         
        // GET: AdminDoiTacs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoiTac doiTac = db.DoiTacs.Find(id);
            if (doiTac == null)
            {
                return HttpNotFound();
            }
            return View(doiTac);
        }

        // POST: AdminDoiTacs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( DoiTac doiTac, HttpPostedFileBase uploadhinh)
        {
            

            DoiTac unv = db.DoiTacs.FirstOrDefault(x => x.ID == doiTac.ID);
            unv.TuaDe = doiTac.TuaDe;
            unv.Link = doiTac.Link;
            
            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                int id = doiTac.ID;
                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "doitac" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Content/img/doitac"), _FileName);
                uploadhinh.SaveAs(_path);
                unv.Hinh = _FileName;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: AdminDoiTacs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoiTac doiTac = db.DoiTacs.Find(id);
            if (doiTac == null)
            {
                return HttpNotFound();
            }
            return View(doiTac);
        }

        // POST: AdminDoiTacs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoiTac doiTac = db.DoiTacs.Find(id);
            db.DoiTacs.Remove(doiTac);
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
