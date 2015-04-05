using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
			var unit = db.Unit.AsQueryable();
            int page;
            int pageCount;
            int pageSize;
            page = 1;
            pageSize = TSRD.Global.PageSize;

            pageCount = Convert.ToInt16(Math.Ceiling(Convert.ToDouble(unit.Count()) / pageSize));
			unit = unit.OrderByDescending(m => m.ID).Skip(pageSize * (page - 1)).Take(pageSize).AsQueryable();			
            ViewData["SearchString"] = "";
            ViewData["PageCount"] = pageCount;
            ViewData["CurrentPage"] = 1;
            return View(unit.ToList());
        }

		[HttpPost, ActionName("Index")]
        public ActionResult Index(string searchString, int? Page)
        {
			var unit = db.Unit.AsQueryable();
            int page;
            int pageCount;
            int pageSize;
            page = Page ?? 1;
            if (page < 1)
                page = 1;
            pageSize = TSRD.Global.PageSize;


			if (!String.IsNullOrEmpty(searchString))
			{   
	
				unit = unit.Where(m =>m.Name.Contains(searchString) || m.Company.Contains(searchString) || m.Contact.Contains(searchString) || m.ContactInfo.Contains(searchString) || m.IDString.Contains(searchString) || m.Floor.Contains(searchString) || m.Area.Contains(searchString) || m.Description.Contains(searchString) || m.Comment.Contains(searchString) ).AsQueryable();
			}
            pageCount = Convert.ToInt16(Math.Ceiling(Convert.ToDouble(unit.Count()) / pageSize));
            if (page > pageCount)
                page = pageCount;
			unit  = unit.OrderByDescending(m => m.ID).Skip(pageSize * (page - 1)).Take(pageSize).AsQueryable();
            ViewData["SearchString"] = searchString;
            ViewData["PageCount"] = pageCount;
            ViewData["CurrentPage"] = page;  
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
            //Random random =  new Random(unchecked(DateTime.Now.Ticks.GetHashCode()));
            //for (int i = 0; i < 500000;i++)
            //{
            //    db.Test.Add(new Test { Amount =random.Next(1, 60000) ,ID1=random.Next(1,500),ID2=random.Next(1,500),ID3=random.Next(1,500)});                   
            //    if ((i % 50)==0)
            //        db.SaveChanges();
            //}
            //ViewData["Total"] = db.Test.Where(m => m.ID1 == 100).AsQueryable().Sum(m => m.Amount);
            db.SaveChanges();
            return View();
        }

        // POST: UnitsC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Company,Contact,ContactInfo,IDString,Floor,Area,Enabled,Description,Comment,CreatedTime,ModifiedTime")] Unit unit)
        {
            var existUnitCount = db.Unit.Where(m => m.Name.Equals(unit.Name)).Where(m => m.Enabled == true).Count();
            if (existUnitCount>0)
            {
                ModelState.AddModelError("Name", "名稱重複，請檢查後重試");
            }
            existUnitCount = db.Unit.Where(m => m.IDString.Equals(unit.IDString)).Where(m => m.Enabled == true).Count();
            if (existUnitCount > 0)
            {
                ModelState.AddModelError("IDString", "櫃號/員編重複，請檢查後重試");
            }
            if (ModelState.IsValid)
            {                
				//unit.CreatedTime = DateTime.Now;
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
            var existUnitCount = db.Unit.Where(m => m.Name.Equals(unit.Name) && m.ID != unit.ID).Where(m => m.Enabled == true).AsQueryable();
            if (existUnitCount.Count() > 0)
            {
                    ModelState.AddModelError("Name", "名稱重複，請檢查後重試");
            }
            existUnitCount = db.Unit.Where(m => m.IDString.Equals(unit.IDString) && m.ID!=unit.ID).Where(m => m.Enabled == true).AsQueryable();
            if (existUnitCount.Count() > 0)
            {
                ModelState.AddModelError("IDString", "櫃號/員編重複，請檢查後重試");
            }
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
