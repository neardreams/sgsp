using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace TSRD.Models
{
    public class PropertyTypesController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        // GET: PropertyTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.PropertyType.ToListAsync());
        }

        // GET: PropertyTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyType propertyType = await db.PropertyType.FindAsync(id);
            if (propertyType == null)
            {
                return HttpNotFound();
            }
            return View(propertyType);
        }

        // GET: PropertyTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PropertyTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Type,Name,Description,Comment,CreatedTime,ModifiedTime")] PropertyType propertyType)
        {
            if (ModelState.IsValid)
            {
                db.PropertyType.Add(propertyType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(propertyType);
        }

        // GET: PropertyTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyType propertyType = await db.PropertyType.FindAsync(id);
            if (propertyType == null)
            {
                return HttpNotFound();
            }
            return View(propertyType);
        }

        // POST: PropertyTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Type,Name,Description,Comment,CreatedTime,ModifiedTime")] PropertyType propertyType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propertyType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(propertyType);
        }

        // GET: PropertyTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyType propertyType = await db.PropertyType.FindAsync(id);
            if (propertyType == null)
            {
                return HttpNotFound();
            }
            return View(propertyType);
        }

        // POST: PropertyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PropertyType propertyType = await db.PropertyType.FindAsync(id);
            db.PropertyType.Remove(propertyType);
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
