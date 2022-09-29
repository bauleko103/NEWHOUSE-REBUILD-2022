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
    public class AdminSlidesController : Controller
    {
        private NEWHOUSE2022Entities db = new NEWHOUSE2022Entities();

        // GET: AdminSlides
        public ActionResult Index()
        {
            
            if (Session["UserID"] != null)
            {
                var orderByDescendingResult = from s in db.Slides //Sorts the studentList collection in descending order
                                              orderby s.ID descending
                                              select s;
                var tk= db.Slides.OrderByDescending(sl => sl.ID).ToList();
                ViewBag.LonToiBe = orderByDescendingResult;
                return View(db.Slides.ToList());
              
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }

        }

       

        // GET: AdminSlides/Create
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

        // POST: AdminSlides/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Slide slide, HttpPostedFileBase uploadhinh)
        {
            db.Slides.Add(slide);
            db.SaveChanges();
            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                int id = int.Parse(db.Slides.ToList().Last().ID.ToString());

                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "slide" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Content/img/"), _FileName);
                uploadhinh.SaveAs(_path);

                Slide unv = db.Slides.FirstOrDefault(x => x.ID == id);
                unv.Hinh = _FileName;
                db.SaveChanges();
            }
            return RedirectToAction("Index","AdminSlides");
        }
        
        // GET: AdminSlides/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slide slide = db.Slides.Find(id);
            if (slide == null)
            {
                return HttpNotFound();
            }
            return View(slide);
        }

       /* public int SlideSize = 0;*/

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Slide slide, HttpPostedFileBase uploadhinh )
        {
            /*var data = (from s in db.Slides select s.ID);
            int totalPage = data.Count();*/
            SlideSize = totalPage;
            Slide unv = db.Slides.FirstOrDefault(x => x.ID == slide.ID);
            unv.TuaDe = slide.TuaDe;
            unv.TuaDePhu = slide.TuaDePhu;
            unv.SoThuTu = slide.SoThuTu;

            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                int id = slide.ID;
                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "slide" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Content/img/"), _FileName);
                uploadhinh.SaveAs(_path);
                unv.Hinh = _FileName;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        // GET: AdminSlides/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slide slide = db.Slides.Find(id);
            if (slide == null)
            {
                return HttpNotFound();
            }
            return View(slide);
        }

        // POST: AdminSlides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slide slide = db.Slides.Find(id);
            db.Slides.Remove(slide);
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
