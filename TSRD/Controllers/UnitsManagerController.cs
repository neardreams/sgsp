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
    public class UnitsManagerController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        // GET: UnitsManager
        public async Task<ActionResult> Index()
        {
            return View(await db.Unit.ToListAsync());
        }

        // GET: UnitsManager/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = await db.Unit.FindAsync(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // GET: UnitsManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnitsManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,IDString,Floor,Area,Description,Comment,CreatedTime,ModifiedTime")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Unit.Add(unit);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(unit);
        }

        // GET: UnitsManager/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = await db.Unit.FindAsync(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: UnitsManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,IDString,Floor,Area,Description,Comment,CreatedTime,ModifiedTime")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unit).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(unit);
        }

        // GET: UnitsManager/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = await db.Unit.FindAsync(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: UnitsManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Unit unit = await db.Unit.FindAsync(id);
            db.Unit.Remove(unit);
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
