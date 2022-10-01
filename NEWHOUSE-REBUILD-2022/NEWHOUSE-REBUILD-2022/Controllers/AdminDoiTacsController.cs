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
        public ActionResult UploadFiles()
        {
            return View();
        }
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult UploadFiles(DoiTac doiTac, HttpPostedFileBase[] files)
        {

            
                    db.DoiTacs.Add(doiTac);
                    db.SaveChanges();
            //Checking file is available to save.  
                    var MangHinh = new List<string>();// recommended 
            foreach (HttpPostedFileBase file in files)
                {

                    if (file != null)
                    {
                        int id = int.Parse(db.DoiTacs.ToList().Last().ID.ToString());
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/Content/img/doitac/") +  InputFileName);
                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);
                        DoiTac unv = db.DoiTacs.FirstOrDefault(x => x.ID == id);
                        
                        MangHinh.Add(InputFileName);
                       
                    }
                }
            
            db.SaveChanges();
                ViewBag.UploadStatus = files.Count().ToString() + " files uploaded successfully.";
            ViewBag.ListHinh = MangHinh;
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
        public ActionResult Edit([Bind(Include = "ID,TuaDe,Link,Hinh")] DoiTac doiTac)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doiTac).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doiTac);
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
