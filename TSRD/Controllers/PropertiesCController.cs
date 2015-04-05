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
    [Route("SubType")]
    public class PropertiesCController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        // GET: PropertiesC
        
        public ActionResult Index(int id)
        {
            var property = db.Property.Where(m => m.PropertyTypeID == id).AsQueryable();
            property = property.Include(p => p.PropertyType).Include(p => p.Unit).AsQueryable();
            int page;
            int pageCount;
            int pageSize;
            page = 1;
            pageSize = TSRD.Global.PageSize;

            pageCount = Convert.ToInt16(Math.Ceiling(Convert.ToDouble(property.Count()) / pageSize));
			property = property.OrderByDescending(m => m.ID).Skip(pageSize * (page - 1)).Take(pageSize).AsQueryable();			
            ViewData["SearchString"] = "";
            ViewData["PageCount"] = pageCount;
            ViewData["CurrentPage"] = 1;
            ViewData["PropertyTypeID"] = id;
            return View(property.ToList());
        }

		[HttpPost, ActionName("Index")]
        public ActionResult Index(string searchString, int? Page,int id)
        {
            var property = db.Property.Where(m => m.PropertyTypeID == id).AsQueryable();
            property = property.Include(p => p.PropertyType).Include(p => p.Unit).AsQueryable();
            int page;
            int pageCount;
            int pageSize;
            page = Page ?? 1;
            if (page < 1)
                page = 1;
            pageSize = TSRD.Global.PageSize;


			if (!String.IsNullOrEmpty(searchString))
			{   
	
				property = property.Where(m =>m.Specification.Contains(searchString) || m.SN.Contains(searchString) || m.NO.Contains(searchString) || m.MACAddress.Contains(searchString) || m.Description.Contains(searchString) || m.Comment.Contains(searchString) ).AsQueryable();
			}
            pageCount = Convert.ToInt16(Math.Ceiling(Convert.ToDouble(property.Count()) / pageSize));
            if (page > pageCount)
                page = pageCount;
			property  = property.OrderByDescending(m => m.ID).Skip(pageSize * (page - 1)).Take(pageSize).AsQueryable();
            ViewData["SearchString"] = searchString;
            ViewData["PageCount"] = pageCount;
            ViewData["CurrentPage"] = page;
            ViewData["PropertyTypeID"] = id;
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
        public ActionResult Create(int id)
        {            
            ViewData["PropertyID"] = id;
            ViewData["PropertyName"] = db.Property.Single(m => m.ID == id);
            ViewBag.UnitID = new SelectList(db.Unit, "ID", "ListedName");
            return View();
        }

        // POST: PropertiesC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Specification,SN,NO,MACAddress,PropertyTypeID,UnitID,Description,Comment,CreatedTime,ModifiedTime")] Property property, int id)
        {
            if (ModelState.IsValid)
            {
				property.CreatedTime = DateTime.Now;
                db.Property.Add(property);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewData["PropertyID"] = id;
            ViewData["PropertyName"] = db.Property.Single(m => m.ID == id);
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
				property.ModifiedTime = DateTime.Now;
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
