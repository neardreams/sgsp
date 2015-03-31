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
    public class RMAFormsCController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        // GET: RMAFormsC


        public ActionResult Index()
        {
			var rMAForm = db.RMAForm.Include(r => r.Consumable).Include(r => r.Property).AsQueryable();
            int page;
            int pageCount;
            int pageSize;
            page = 1;
            pageSize = TSRD.Global.PageSize;
			
			ViewBag.Status  = new SelectList(from TSRD.Enums.RMAFormStatus d in Enum.GetValues(typeof(TSRD.Enums.RMAFormStatus)) select new { ID = (int)d, Name = d.ToString() },"ID","Name");
				pageCount = (rMAForm.Count() / pageSize) + 1;
			rMAForm = rMAForm.OrderByDescending(m => m.ID).Skip(pageSize * (page - 1)).Take(pageSize).AsQueryable();			
            ViewData["SearchString"] = "";
            ViewData["PageCount"] = pageCount;
            ViewData["CurrentPage"] = 1;
            return View(rMAForm.ToList());
        }

		[HttpPost, ActionName("Index")]
        public ActionResult Index(string searchString, TSRD.Enums.RMAFormStatus? Status, int? Page)
        {
			var rMAForm = db.RMAForm.Include(r => r.Consumable).Include(r => r.Property).AsQueryable();
            int page;
            int pageCount;
            int pageSize;
            page = Page ?? 1;
            if (page < 1)
                page = 1;
            pageSize = TSRD.Global.PageSize;


			if (!String.IsNullOrEmpty(searchString))
			{   
	
				rMAForm = rMAForm.Where(m =>m.Contact.Contains(searchString) || m.ContactInfo.Contains(searchString) || m.Description.Contains(searchString) || m.Comment.Contains(searchString) ).AsQueryable();
			}	
			ViewBag.Status  = new SelectList(from TSRD.Enums.RMAFormStatus d in Enum.GetValues(typeof(TSRD.Enums.RMAFormStatus)) select new { ID = (int)d, Name = d.ToString() },"ID","Name");
			if (Status!=null)
			{
				rMAForm = rMAForm.Where(m => m.Status == Status).AsQueryable();
			}
            pageCount = (rMAForm.Count() / pageSize) + 1;
            if (page > pageCount)
                page = pageCount;
			rMAForm  = rMAForm.OrderByDescending(m => m.ID).Skip(pageSize * (page - 1)).Take(pageSize).AsQueryable();
            ViewData["SearchString"] = searchString;
            ViewData["PageCount"] = pageCount;
            ViewData["CurrentPage"] = page;  
			
            return View(rMAForm.ToList());
        }




        // GET: RMAFormsC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RMAForm rMAForm = db.RMAForm.Find(id);
            if (rMAForm == null)
            {
                return HttpNotFound();
            }
            return View(rMAForm);
        }

        // GET: RMAFormsC/Create
        public ActionResult Create()
        {
            ViewBag.ConsumableID = new SelectList(db.Consumable, "ID", "ListedName");
            ViewBag.PropertyID = new SelectList(db.Property, "ID", "ListedName");
            return View();
        }

        // POST: RMAFormsC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Status,Contact,ContactInfo,RMATime,ReturnTime,Closed,PropertyID,ConsumableID,Description,Comment,CreatedTime,ModifiedTime")] RMAForm rMAForm,int[] PropertyID)
        {
            if (ModelState.IsValid)
            {
				rMAForm.CreatedTime = DateTime.Now;
                db.RMAForm.Add(rMAForm);
                if (PropertyID!=null && PropertyID.Length>0)
                {
                    foreach (int propertyID in PropertyID)
                    {
                        
                    }
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ConsumableID = new SelectList(db.Consumable, "ID", "ListedName", rMAForm.ConsumableID);
            ViewBag.PropertyID = new SelectList(db.Property, "ID", "ListedName", rMAForm.PropertyID);
            return View(rMAForm);
        }

        // GET: RMAFormsC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RMAForm rMAForm = db.RMAForm.Find(id);
            if (rMAForm == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConsumableID = new SelectList(db.Consumable, "ID", "ListedName", rMAForm.ConsumableID);
            ViewBag.PropertyID = new SelectList(db.Property, "ID", "ListedName", rMAForm.PropertyID);
            return View(rMAForm);
        }

        // POST: RMAFormsC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Status,Contact,ContactInfo,RMATime,ReturnTime,Closed,PropertyID,ConsumableID,Description,Comment,CreatedTime,ModifiedTime")] RMAForm rMAForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rMAForm).State = EntityState.Modified;
				rMAForm.ModifiedTime = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConsumableID = new SelectList(db.Consumable, "ID", "ListedName", rMAForm.ConsumableID);
            ViewBag.PropertyID = new SelectList(db.Property, "ID", "ListedName", rMAForm.PropertyID);
            return View(rMAForm);
        }

        // GET: RMAFormsC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RMAForm rMAForm = db.RMAForm.Find(id);
            if (rMAForm == null)
            {
                return HttpNotFound();
            }
            return View(rMAForm);
        }

        // POST: RMAFormsC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RMAForm rMAForm = db.RMAForm.Find(id);
            db.RMAForm.Remove(rMAForm);
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
