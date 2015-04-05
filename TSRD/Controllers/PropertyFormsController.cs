using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TSRD.Models;

namespace TSRD.Controllers
{
    public class PropertyFormsController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        // GET: PropertyForms


        public ActionResult Index()
        {
			var propertyForm = db.PropertyForm.Include(p => p.Property).AsQueryable();
            int page;
            int pageCount;
            int pageSize;
            page = 1;
            pageSize = TSRD.Global.PageSize;

            pageCount = Convert.ToInt16(Math.Ceiling(Convert.ToDouble(propertyForm.Count()) / pageSize));
			propertyForm = propertyForm.OrderByDescending(m => m.ID).Skip(pageSize * (page - 1)).Take(pageSize).AsQueryable();			
            ViewData["SearchString"] = "";
            ViewData["PageCount"] = pageCount;
            ViewData["CurrentPage"] = 1;
            return View(propertyForm.ToList());
        }

		[HttpPost, ActionName("Index")]
        public ActionResult Index(string searchString, int? Page)
        {
			var propertyForm = db.PropertyForm.Include(p => p.Property).AsQueryable();
            int page;
            int pageCount;
            int pageSize;
            page = Page ?? 1;
            if (page < 1)
                page = 1;
            pageSize = TSRD.Global.PageSize;


			if (!String.IsNullOrEmpty(searchString))
			{   
	
				propertyForm = propertyForm.Where(m =>m.Description.Contains(searchString) || m.Comment.Contains(searchString) ).AsQueryable();
			}
            pageCount = Convert.ToInt16(Math.Ceiling(Convert.ToDouble(propertyForm.Count()) / pageSize));
            if (page > pageCount)
                page = pageCount;
			propertyForm  = propertyForm.OrderByDescending(m => m.ID).Skip(pageSize * (page - 1)).Take(pageSize).AsQueryable();
            ViewData["SearchString"] = searchString;
            ViewData["PageCount"] = pageCount;
            ViewData["CurrentPage"] = page;  
			
            return View(propertyForm.ToList());
        }




        // GET: PropertyForms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyForm propertyForm = db.PropertyForm.Find(id);
            if (propertyForm == null)
            {
                return HttpNotFound();
            }
            return View(propertyForm);
        }

        // GET: PropertyForms/Create
        public ActionResult Create()
        {
            ViewBag.PropertyID = new SelectList(db.Property, "ID", "ListedName");
            return View();
        }

        // POST: PropertyForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PropertyID,Description,Comment,CreatedTime,ModifiedTime")] PropertyForm propertyForm)
        {
            if (ModelState.IsValid)
            {
				propertyForm.CreatedTime = DateTime.Now;
                db.PropertyForm.Add(propertyForm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PropertyID = new SelectList(db.Property, "ID", "ListedName", propertyForm.PropertyID);
            return View(propertyForm);
        }

        // GET: PropertyForms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyForm propertyForm = db.PropertyForm.Find(id);
            if (propertyForm == null)
            {
                return HttpNotFound();
            }
            ViewBag.PropertyID = new SelectList(db.Property, "ID", "ListedName", propertyForm.PropertyID);
            return View(propertyForm);
        }

        // POST: PropertyForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PropertyID,Description,Comment,CreatedTime,ModifiedTime")] PropertyForm propertyForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propertyForm).State = EntityState.Modified;
				propertyForm.ModifiedTime = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PropertyID = new SelectList(db.Property, "ID", "ListedName", propertyForm.PropertyID);
            return View(propertyForm);
        }

        // GET: PropertyForms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyForm propertyForm = db.PropertyForm.Find(id);
            if (propertyForm == null)
            {
                return HttpNotFound();
            }
            return View(propertyForm);
        }

        // POST: PropertyForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PropertyForm propertyForm = db.PropertyForm.Find(id);
            db.PropertyForm.Remove(propertyForm);
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
