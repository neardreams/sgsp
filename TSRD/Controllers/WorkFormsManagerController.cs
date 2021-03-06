﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TSRD.Models;
using TSRD.Enums;
namespace TSRD.Controllers
{
    public class WorkFormsManagerController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        // GET: WorkFormsManager
        public ActionResult Index()		
		{
            ViewBag.Type = new SelectList(from WorkFormType d in Enum.GetValues(typeof(WorkFormType))
												select new { ID = (int)d, Name = d.ToString() }
												,"ID","Name");

            var workForm = db.WorkForm.Include(w => w.Unit);
            return View(workForm.ToList());
        }

        // GET: WorkFormsManager/Details/5
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

        // GET: WorkFormsManager/Create
        public ActionResult Create()
        {
            ViewBag.UnitID = new SelectList(db.Unit, "ID", "ListedName");			
            return View();
        }

        // POST: WorkFormsManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Contact,AcceptedTime,ClosedTime,Closed,Type,UnitID,Description,Comment,CreatedTime,ModifiedTime")] WorkForm workForm)
        {
			workForm.CreatedTime = DateTime.Now;
			workForm.ModifiedTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.WorkForm.Add(workForm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UnitID = new SelectList(db.Unit, "ID", "ListedName", workForm.UnitID);
            return View(workForm);
        }

        // GET: WorkFormsManager/Edit/5
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

        // POST: WorkFormsManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Contact,AcceptedTime,ClosedTime,Closed,Type,UnitID,Description,Comment,CreatedTime,ModifiedTime")] WorkForm workForm)
        {		
			workForm.CreatedTime = workForm.CreatedTime;
			workForm.ModifiedTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(workForm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UnitID = new SelectList(db.Unit, "ID", "ListedName", workForm.UnitID);
            return View(workForm);
        }

        // GET: WorkFormsManager/Delete/5
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

        // POST: WorkFormsManager/Delete/5
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
