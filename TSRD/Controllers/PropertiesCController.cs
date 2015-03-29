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
    public class PropertiesCController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        // GET: PropertiesC


        public ActionResult Index()
        {
			var property = db.Property.Include(p => p.PropertyType).Include(p => p.Unit).AsQueryable();
            return View(property.ToList());
        }

		[HttpPost, ActionName("Index")]
        public ActionResult Index(string searchString)
        {
			var property = db.Property.Include(p => p.PropertyType).Include(p => p.Unit).AsQueryable();
			if (!String.IsNullOrEmpty(searchString))
			{   
	
				property = property.Where(m =>m.Specification.Contains(searchString) || m.SN.Contains(searchString) || m.NO.Contains(searchString) || m.MACAddress.Contains(searchString) || m.Description.Contains(searchString) || m.Comment.Contains(searchString) ).AsQueryable();
			}	

			
            return View(property.ToList());
        }




        // GET: PropertiesC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Property.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // GET: PropertiesC/Create
        public ActionResult Create()
        {
            ViewBag.PropertyTypeID = new SelectList(db.PropertyType, "ID", "ListedName");
            ViewBag.UnitID = new SelectList(db.Unit, "ID", "ListedName");
            return View();
        }

        // POST: PropertiesC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Specification,SN,NO,MACAddress,PropertyTypeID,UnitID,Description,Comment,CreatedTime,ModifiedTime")] Property property)
        {
            if (ModelState.IsValid)
            {
                db.Property.Add(property);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PropertyTypeID = new SelectList(db.PropertyType, "ID", "ListedName", property.PropertyTypeID);
            ViewBag.UnitID = new SelectList(db.Unit, "ID", "ListedName", property.UnitID);
            return View(property);
        }

        // GET: PropertiesC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Property.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            ViewBag.PropertyTypeID = new SelectList(db.PropertyType, "ID", "ListedName", property.PropertyTypeID);
            ViewBag.UnitID = new SelectList(db.Unit, "ID", "ListedName", property.UnitID);
            return View(property);
        }

        // POST: PropertiesC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Specification,SN,NO,MACAddress,PropertyTypeID,UnitID,Description,Comment,CreatedTime,ModifiedTime")] Property property)
        {
            if (ModelState.IsValid)
            {
                db.Entry(property).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PropertyTypeID = new SelectList(db.PropertyType, "ID", "ListedName", property.PropertyTypeID);
            ViewBag.UnitID = new SelectList(db.Unit, "ID", "ListedName", property.UnitID);
            return View(property);
        }

        // GET: PropertiesC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Property.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // POST: PropertiesC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Property property = db.Property.Find(id);
            db.Property.Remove(property);
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
