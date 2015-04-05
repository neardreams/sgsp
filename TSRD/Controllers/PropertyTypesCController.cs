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
    public class PropertyTypesCController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        // GET: PropertyTypesC
        public ActionResult PropertyList(int id)
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

        [HttpPost, ActionName("PropertyList")]
        public ActionResult PropertyList(string searchString, int? Page, int id)
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

                property = property.Where(m => m.Specification.Contains(searchString) || m.SN.Contains(searchString) || m.NO.Contains(searchString) || m.MACAddress.Contains(searchString) || m.Description.Contains(searchString) || m.Comment.Contains(searchString)).AsQueryable();
            }
            pageCount = Convert.ToInt16(Math.Ceiling(Convert.ToDouble(property.Count()) / pageSize));
            if (page > pageCount)
                page = pageCount;
            property = property.OrderByDescending(m => m.ID).Skip(pageSize * (page - 1)).Take(pageSize).AsQueryable();
            ViewData["SearchString"] = searchString;
            ViewData["PageCount"] = pageCount;
            ViewData["CurrentPage"] = page;
            ViewData["PropertyTypeID"] = id;
            return View(property.ToList());
        }
        // GET: PropertiesC/Details/5
        public ActionResult PropertyDetails(int? id)
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

        public ActionResult AddProperty(int id)
        {
            ViewData["PropertyTypeID"] = id;
            ViewData["PropertyTypeName"] = db.PropertyType.Single(m => m.ID == id).ListedName;
            ViewBag.UnitID = new SelectList(db.Unit, "ID", "ListedName");
            return View();
        }

        // POST: PropertiesC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProperty([Bind(Include = "ID,Name,Specification,SN,NO,MACAddress,PropertyTypeID,UnitID,Description,Comment,CreatedTime,ModifiedTime")] Property property,int id)
        {
            var existProperty = db.Property.Where(m => m.NO.Equals(property.NO)).AsQueryable();
            if (existProperty.Count()>0)
            {
                ModelState.AddModelError("NO", "財產編號重複，請檢查後重試");
            }
            if (ModelState.IsValid)
            {
                property.CreatedTime = DateTime.Now;
                db.Property.Add(property);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewData["PropertyTypeID"] = id;
            ViewData["PropertyTypeName"] = db.PropertyType.Single(m => m.ID == id).ListedName;
            ViewBag.UnitID = new SelectList(db.Unit, "ID", "ListedName", property.UnitID);
            return View(property);
        }


        // GET: PropertiesC/Edit/5
        public ActionResult EditProperty(int? id)
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
        public ActionResult EditProperty([Bind(Include = "ID,Name,Specification,SN,NO,MACAddress,PropertyTypeID,UnitID,Description,Comment,CreatedTime,ModifiedTime")] Property property)
        {
            var existProperty = db.Property.Where(m => m.NO.Equals(property.NO) && !m.ID.Equals(property.ID)).AsQueryable();
            if (existProperty.Count() > 0)
            {
                ModelState.AddModelError("NO", "財產編號重複，請檢查後重試");
            }
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

        public ActionResult Index()
        {
			var propertyType = db.PropertyType.AsQueryable();
            int page;
            int pageCount;
            int pageSize;
            page = 1;
            pageSize = TSRD.Global.PageSize;
			
				pageCount = (propertyType.Count() / pageSize) + 1;
			propertyType = propertyType.OrderByDescending(m => m.ID).Skip(pageSize * (page - 1)).Take(pageSize).AsQueryable();			
            ViewData["SearchString"] = "";
            ViewData["PageCount"] = pageCount;
            ViewData["CurrentPage"] = 1;
            return View(propertyType.ToList());
        }

		[HttpPost, ActionName("Index")]
        public ActionResult Index(string searchString, int? Page)
        {
			var propertyType = db.PropertyType.AsQueryable();
            int page;
            int pageCount;
            int pageSize;
            page = Page ?? 1;
            if (page < 1)
                page = 1;
            pageSize = TSRD.Global.PageSize;


			if (!String.IsNullOrEmpty(searchString))
			{   
	
				propertyType = propertyType.Where(m =>m.Name.Contains(searchString) || m.Name.Contains(searchString) || m.Description.Contains(searchString) || m.Comment.Contains(searchString) ).AsQueryable();
			}	
            pageCount = (propertyType.Count() / pageSize) + 1;
            if (page > pageCount)
                page = pageCount;
			propertyType  = propertyType.OrderByDescending(m => m.ID).Skip(pageSize * (page - 1)).Take(pageSize).AsQueryable();
            ViewData["SearchString"] = searchString;
            ViewData["PageCount"] = pageCount;
            ViewData["CurrentPage"] = page;  
            return View(propertyType.ToList());
        }




        // GET: PropertyTypesC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyType propertyType = db.PropertyType.Find(id);
            if (propertyType == null)
            {
                return HttpNotFound();
            }
            return View(propertyType);
        }

        // GET: PropertyTypesC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PropertyTypesC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Type,Name,Description,Comment,CreatedTime,ModifiedTime")] PropertyType propertyType)
        {
            var existPropertyType = db.PropertyType.Where(m => m.Name.Equals(propertyType.Name) && m.Disabled==false).AsQueryable();
            if (existPropertyType.Count()>0)
            {
                ModelState.AddModelError("Name", "財產類別名稱重複，請檢查後重試");
            }
            if (ModelState.IsValid)
            {
				propertyType.CreatedTime = DateTime.Now;
                db.PropertyType.Add(propertyType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(propertyType);
        }

        // GET: PropertyTypesC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyType propertyType = db.PropertyType.Find(id);
            if (propertyType == null)
            {
                return HttpNotFound();
            }
            return View(propertyType);
        }

        // POST: PropertyTypesC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Type,Name,Description,Comment,CreatedTime,ModifiedTime")] PropertyType propertyType)
        {
            var existPropertyType = db.PropertyType.Where(m => m.Name.Equals(propertyType.Name) && m.Disabled == false && m.ID!=propertyType.ID).AsQueryable();
            if (existPropertyType.Count() > 0)
            {
                ModelState.AddModelError("Name", "財產類別名稱重複，請檢查後重試");
            }
            if (ModelState.IsValid)
            {
                db.Entry(propertyType).State = EntityState.Modified;
				propertyType.ModifiedTime = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(propertyType);
        }

        // GET: PropertyTypesC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyType propertyType = db.PropertyType.Find(id);
            if (propertyType == null)
            {
                return HttpNotFound();
            }
            return View(propertyType);
        }

        // POST: PropertyTypesC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PropertyType propertyType = db.PropertyType.Find(id);
            db.PropertyType.Remove(propertyType);
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
