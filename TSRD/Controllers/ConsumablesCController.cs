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
    public class ConsumablesCController : Controller
    {
        private DefaultConnection db = new DefaultConnection();





        // GET: ConsumablesC
        public ActionResult ConsumableFormList(int ID)
        {
            var consumableForm = db.ConsumableForm.Where(m => m.ConsumableID == ID).Include(c => c.Consumable).AsQueryable();
            int page;
            int pageCount;
            int pageSize;
            page = 1;
            pageSize = TSRD.Global.PageSize;

            pageCount = (consumableForm.Count() / pageSize) + 1;
            consumableForm = consumableForm.OrderByDescending(m => m.ID).Skip(pageSize * (page - 1)).Take(pageSize).AsQueryable();
            ViewData["SearchString"] = "";
            ViewData["PageCount"] = pageCount;
            ViewData["CurrentPage"] = 1;
            ViewData["ConsumableName"] = db.Consumable.Single(m => m.ID == ID).ListedName;
            return View(consumableForm.ToList());
        }

        [HttpPost, ActionName("ConsumableFormList")]
        public ActionResult ConsumableFormList(string searchString, int? Page, int ID)
        {
            var consumableForm = db.ConsumableForm.Where(m=>m.ConsumableID==ID).Include(c => c.Consumable).AsQueryable();
            int page;
            int pageCount;
            int pageSize;
            page = Page ?? 1;
            if (page < 1)
                page = 1;
            pageSize = TSRD.Global.PageSize;


            if (!String.IsNullOrEmpty(searchString))
            {

                consumableForm = consumableForm.Where(m => m.Description.Contains(searchString) || m.Comment.Contains(searchString)).AsQueryable();
            }
            pageCount = (consumableForm.Count() / pageSize) + 1;
            if (page > pageCount)
                page = pageCount;
            consumableForm = consumableForm.OrderByDescending(m => m.ID).Skip(pageSize * (page - 1)).Take(pageSize).AsQueryable();
            ViewData["SearchString"] = searchString;
            ViewData["PageCount"] = pageCount;
            ViewData["CurrentPage"] = page;
            ViewData["ConsumableName"] = db.Consumable.Single(m => m.ID == ID).ListedName;
            return View(consumableForm.ToList());
        }
        public ActionResult AddConsumable(int ID)
        {
            ViewData["ConsumableID"] = ID;
            ViewData["Consumable"] = db.Consumable.Single(m => m.ID == ID).ListedName;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddConsumable([Bind(Include = "ID,Amount,ConsumableID,Description,Comment,CreatedTime,ModifiedTime")] ConsumableForm consumableForm)
        {
            if (ModelState.IsValid)
            {
                consumableForm.CreatedTime = DateTime.Now;
                db.ConsumableForm.Add(consumableForm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(consumableForm);
        }

        public ActionResult DeleteConsumable(int ID)
        {
            ViewData["ConsumableID"] = ID;
            ViewData["Consumable"] = db.Consumable.Single(m => m.ID == ID).ListedName;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConsumable([Bind(Include = "ID,Amount,ConsumableID,Description,Comment,CreatedTime,ModifiedTime")] ConsumableForm consumableForm)
        {            
            if (ModelState.IsValid)
            {
                consumableForm.Amount = -consumableForm.Amount;
                consumableForm.CreatedTime = DateTime.Now;
                db.ConsumableForm.Add(consumableForm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(consumableForm);
        }

        public ActionResult Index()
        {
			var consumable = db.Consumable.AsQueryable();
            int page;
            int pageCount;
            int pageSize;
            page = 1;
            pageSize = TSRD.Global.PageSize;
			
				pageCount = (consumable.Count() / pageSize) + 1;
			consumable = consumable.OrderByDescending(m => m.ID).Skip(pageSize * (page - 1)).Take(pageSize).AsQueryable();			
            ViewData["SearchString"] = "";
            ViewData["PageCount"] = pageCount;
            ViewData["CurrentPage"] = 1;
            return View(consumable.ToList());
        }

		[HttpPost, ActionName("Index")]
        public ActionResult Index(string searchString, int? Page)
        {
			var consumable = db.Consumable.AsQueryable();
            int page;
            int pageCount;
            int pageSize;
            page = Page ?? 1;
            if (page < 1)
                page = 1;
            pageSize = TSRD.Global.PageSize;


			if (!String.IsNullOrEmpty(searchString))
			{   
	
				consumable = consumable.Where(m =>m.Name.Contains(searchString) || m.NO.Contains(searchString) || m.Description.Contains(searchString) || m.Comment.Contains(searchString) ).AsQueryable();
			}	
            pageCount = (consumable.Count() / pageSize) + 1;
            if (page > pageCount)
                page = pageCount;
			consumable  = consumable.OrderByDescending(m => m.ID).Skip(pageSize * (page - 1)).Take(pageSize).AsQueryable();
            ViewData["SearchString"] = searchString;
            ViewData["PageCount"] = pageCount;
            ViewData["CurrentPage"] = page;  
            return View(consumable.ToList());
        }




        // GET: ConsumablesC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumable consumable = db.Consumable.Find(id);
            if (consumable == null)
            {
                return HttpNotFound();
            }
            return View(consumable);
        }

        // GET: ConsumablesC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConsumablesC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,NO,Amount,Enabled,Description,Comment,CreatedTime,ModifiedTime")] Consumable consumable)
        {
            if (ModelState.IsValid)
            {
				consumable.CreatedTime = DateTime.Now;
                db.Consumable.Add(consumable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(consumable);
        }

        // GET: ConsumablesC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumable consumable = db.Consumable.Find(id);
            if (consumable == null)
            {
                return HttpNotFound();
            }
            return View(consumable);
        }

        // POST: ConsumablesC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,NO,Amount,Enabled,Description,Comment,CreatedTime,ModifiedTime")] Consumable consumable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consumable).State = EntityState.Modified;
				consumable.ModifiedTime = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(consumable);
        }

        // GET: ConsumablesC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumable consumable = db.Consumable.Find(id);
            if (consumable == null)
            {
                return HttpNotFound();
            }
            return View(consumable);
        }

        // POST: ConsumablesC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consumable consumable = db.Consumable.Find(id);
            db.Consumable.Remove(consumable);
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
