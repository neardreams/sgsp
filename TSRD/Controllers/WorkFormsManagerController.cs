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
    public class WorkFormsManagerController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        // GET: WorkFormsManager
        public async Task<ActionResult> Index()
        {
            return View(await db.WorkForm.ToListAsync());
        }

        // GET: WorkFormsManager/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkForm workForm = await db.WorkForm.FindAsync(id);
            if (workForm == null)
            {
                return HttpNotFound();
            }
            return View(workForm);
        }

        // GET: WorkFormsManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkFormsManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Contact,AcceptedTime,ClosedTime,Closed,Type,Description,Comment,CreatedTime,ModifiedTime")] WorkForm workForm)
        {
            if (ModelState.IsValid)
            {
                db.WorkForm.Add(workForm);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(workForm);
        }

        // GET: WorkFormsManager/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkForm workForm = await db.WorkForm.FindAsync(id);
            if (workForm == null)
            {
                return HttpNotFound();
            }
            return View(workForm);
        }

        // POST: WorkFormsManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Contact,AcceptedTime,ClosedTime,Closed,Type,Description,Comment,CreatedTime,ModifiedTime")] WorkForm workForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workForm).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(workForm);
        }

        // GET: WorkFormsManager/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkForm workForm = await db.WorkForm.FindAsync(id);
            if (workForm == null)
            {
                return HttpNotFound();
            }
            return View(workForm);
        }

        // POST: WorkFormsManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            WorkForm workForm = await db.WorkForm.FindAsync(id);
            db.WorkForm.Remove(workForm);
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
