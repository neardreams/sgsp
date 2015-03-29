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
    public class WorkFormsCController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        // GET: WorkFormsC


        public ActionResult Index()
        {
			var workForm = db.WorkForm.Include(w => w.Unit).AsQueryable();
			ViewBag.WorkFormType  = new SelectList(from TSRD.Enums.WorkFormType d in Enum.GetValues(typeof(TSRD.Enums.WorkFormType)) select new { ID = (int)d, Name = d.ToString() },"ID","Name");
            return View(workForm.ToList());
        }

		[HttpPost, ActionName("Index")]
        public ActionResult Index(string searchString, TSRD.Enums.WorkFormType? WorkFormType)
        {
			var workForm = db.WorkForm.Include(w => w.Unit).AsQueryable();
			if (!String.IsNullOrEmpty(searchString))
			{   
	
				workForm = workForm.Where(m =>m.Contact.Contains(searchString) || m.Description.Contains(searchString) || m.Comment.Contains(searchString) ).AsQueryable();
			}	
			ViewBag.WorkFormType  = new SelectList(from TSRD.Enums.WorkFormType d in Enum.GetValues(typeof(TSRD.Enums.WorkFormType)) select new { ID = (int)d, Name = d.ToString() },"ID","Name");
			if (WorkFormType!=null)
			{
				workForm = workForm.Where(m => m.WorkFormType == WorkFormType).AsQueryable();
			}

			
            return View(workForm.ToList());
        }




        // GET: WorkFormsC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkForm workForm = db.WorkForm.Find(id);
            if (workForm == null)
            {
                return HttpNotFound();
            }
            return View(workForm);
        }

        // GET: WorkFormsC/Create
        public ActionResult Create()
        {
            ViewBag.UnitID = new SelectList(db.Unit, "ID", "ListedName");
            return View();
        }

        // POST: WorkFormsC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Contact,AcceptedTime,ClosedTime,Closed,WorkFormType,UnitID,Description,Comment,CreatedTime,ModifiedTime")] WorkForm workForm)
        {
            if (ModelState.IsValid)
            {
                db.WorkForm.Add(workForm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UnitID = new SelectList(db.Unit, "ID", "ListedName", workForm.UnitID);
            return View(workForm);
        }

        // GET: WorkFormsC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkForm workForm = db.WorkForm.Find(id);
            if (workForm == null)
            {
                return HttpNotFound();
            }
            ViewBag.UnitID = new SelectList(db.Unit, "ID", "ListedName", workForm.UnitID);
            return View(workForm);
        }

        // POST: WorkFormsC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Contact,AcceptedTime,ClosedTime,Closed,WorkFormType,UnitID,Description,Comment,CreatedTime,ModifiedTime")] WorkForm workForm)
        {
            if (ModelState.IsValid)
            {                
                db.Entry(workForm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UnitID = new SelectList(db.Unit, "ID", "ListedName", workForm.UnitID);
            return View(workForm);
        }

        // GET: WorkFormsC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkForm workForm = db.WorkForm.Find(id);
            if (workForm == null)
            {
                return HttpNotFound();
            }
            return View(workForm);
        }

        // POST: WorkFormsC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkForm workForm = db.WorkForm.Find(id);
            db.WorkForm.Remove(workForm);
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
