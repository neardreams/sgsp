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
    public class UnitsCController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        // GET: UnitsC


        public ActionResult Index()
        {
            int page;

            page = 1;
            
            ViewData["SearchString"] = "";
            var unit = db.Unit.AsQueryable();
            ViewData["PageCount"] = (unit.Count() / TSRD.Global.PageSize) + 1;
            ViewData["CurrentPage"] = 1;
            unit = unit.OrderBy(m=>m.ID).Skip(TSRD.Global.PageSize*(page-1)).Take(TSRD.Global.PageSize).AsQueryable();            
            return View(unit.ToList());
        }

		[HttpPost]        
        public ActionResult Index(string searchString, int? Page)
        {
            int page;
            page = Page ?? 1;
            if (page < 1)
                page = 1;
            

            var unit = db.Unit.AsQueryable();
			if (!String.IsNullOrEmpty(searchString))
			{   
	
				unit = unit.Where(m =>m.Name.Contains(searchString) || m.Company.Contains(searchString) || m.Contact.Contains(searchString) || m.ContactInfo.Contains(searchString) || m.IDString.Contains(searchString) || m.Floor.Contains(searchString) || m.Area.Contains(searchString) || m.Description.Contains(searchString) || m.Comment.Contains(searchString) ).AsQueryable();
                
			}
            int pageCount;
            pageCount = (unit.Count() / TSRD.Global.PageSize) + 1;
            ViewData["PageCount"] = pageCount;
            if (page > pageCount)
                page = pageCount;
            unit = unit.OrderBy(m => m.ID).Skip(TSRD.Global.PageSize * (page - 1)).Take(TSRD.Global.PageSize).AsQueryable();             
            ViewData["CurrentPage"] = page;
            ViewData["SearchString"] = searchString;
            return View(unit.ToList());
        }




        // GET: UnitsC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.Unit.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // GET: UnitsC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnitsC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Company,Contact,ContactInfo,IDString,Floor,Area,Enabled,Description,Comment,CreatedTime,ModifiedTime")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Unit.Add(unit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unit);
        }

        // GET: UnitsC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.Unit.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: UnitsC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Company,Contact,ContactInfo,IDString,Floor,Area,Enabled,Description,Comment,CreatedTime,ModifiedTime")] Unit unit)
        {
            if (ModelState.IsValid)
            {
 
                db.Entry(unit).State = EntityState.Modified;
                unit.ModifiedTime = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unit);
        }

        // GET: UnitsC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.Unit.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: UnitsC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Unit unit = db.Unit.Find(id);
            db.Unit.Remove(unit);
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
