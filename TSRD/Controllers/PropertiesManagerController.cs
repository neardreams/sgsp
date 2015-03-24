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
    public class PropertiesManagerController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        // GET: PropertiesManager
        public async Task<ActionResult> Index()
        {
            return View(await db.Property.ToListAsync());
        }

        // GET: PropertiesManager/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = await db.Property.FindAsync(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // GET: PropertiesManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PropertiesManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Specification,SN,MACAddress,Description,Comment,CreatedTime,ModifiedTime")] Property property)
        {
            if (ModelState.IsValid)
            {
                db.Property.Add(property);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(property);
        }

        // GET: PropertiesManager/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = await db.Property.FindAsync(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // POST: PropertiesManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Specification,SN,MACAddress,Description,Comment,CreatedTime,ModifiedTime")] Property property)
        {
            if (ModelState.IsValid)
            {
                db.Entry(property).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(property);
        }

        // GET: PropertiesManager/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = await db.Property.FindAsync(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // POST: PropertiesManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Property property = await db.Property.FindAsync(id);
            db.Property.Remove(property);
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
