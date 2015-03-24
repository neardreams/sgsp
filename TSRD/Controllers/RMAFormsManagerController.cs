using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TSRD.Models;

namespace TSRD.Controllers
{
    public class RMAFormsManagerController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        // GET: RMAFormsManager
        public async Task<ActionResult> Index()
        {
            return View(await db.RMAForm.ToListAsync());
        }

        // GET: RMAFormsManager/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RMAForm rMAForm = await db.RMAForm.FindAsync(id);
            if (rMAForm == null)
            {
                return HttpNotFound();
            }
            return View(rMAForm);
        }

        // GET: RMAFormsManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RMAFormsManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Status,Contact,ContactInfo,RMATime,ReturnTime,Closed,Description,Comment,CreatedTime,ModifiedTime")] RMAForm rMAForm)
        {
            if (ModelState.IsValid)
            {
                db.RMAForm.Add(rMAForm);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(rMAForm);
        }

        // GET: RMAFormsManager/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RMAForm rMAForm = await db.RMAForm.FindAsync(id);
            if (rMAForm == null)
            {
                return HttpNotFound();
            }
            return View(rMAForm);
        }

        // POST: RMAFormsManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Status,Contact,ContactInfo,RMATime,ReturnTime,Closed,Description,Comment,CreatedTime,ModifiedTime")] RMAForm rMAForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rMAForm).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(rMAForm);
        }

        // GET: RMAFormsManager/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RMAForm rMAForm = await db.RMAForm.FindAsync(id);
            if (rMAForm == null)
            {
                return HttpNotFound();
            }
            return View(rMAForm);
        }

        // POST: RMAFormsManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RMAForm rMAForm = await db.RMAForm.FindAsync(id);
            db.RMAForm.Remove(rMAForm);
            await db.SaveChangesAsync();
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
