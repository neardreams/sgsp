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
    public class ConsumablesManagerController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        // GET: ConsumablesManager
        public async Task<ActionResult> Index()
        {
            return View(await db.Consumable.ToListAsync());
        }

        // GET: ConsumablesManager/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumable consumable = await db.Consumable.FindAsync(id);
            if (consumable == null)
            {
                return HttpNotFound();
            }
            return View(consumable);
        }

        // GET: ConsumablesManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConsumablesManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Amount,Enabled,Description,Comment,CreatedTime,ModifiedTime")] Consumable consumable)
        {
            if (ModelState.IsValid)
            {
                db.Consumable.Add(consumable);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(consumable);
        }

        // GET: ConsumablesManager/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumable consumable = await db.Consumable.FindAsync(id);
            if (consumable == null)
            {
                return HttpNotFound();
            }
            return View(consumable);
        }

        // POST: ConsumablesManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Amount,Enabled,Description,Comment,CreatedTime,ModifiedTime")] Consumable consumable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consumable).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(consumable);
        }

        // GET: ConsumablesManager/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumable consumable = await db.Consumable.FindAsync(id);
            if (consumable == null)
            {
                return HttpNotFound();
            }
            return View(consumable);
        }

        // POST: ConsumablesManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Consumable consumable = await db.Consumable.FindAsync(id);
            db.Consumable.Remove(consumable);
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
