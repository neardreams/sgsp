using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TSRD.Models;
using TSRD.ViewModels;
namespace TSRD.Controllers
{
    public class ConsumablesCController : Controller
    {
        private DefaultConnection db = new DefaultConnection();




        public List<ConsumableIOList> GetConsumableIOList(int id)
        {            
            var list = new List<ConsumableIOList>();            
            var consumableForms = db.ConsumableForm.Where(m => m.ConsumableID == id);
            var workformConsumables = db.WorkFormConsumable.Where(m => m.ConsumableID == id);
            var rmaforms = db.RMAForm.Where(m => m.ConsumableID == id);
            foreach (ConsumableForm consumableform in consumableForms)
            {
                if (consumableform.Amount>0)
                    list.Add(new ConsumableIOList { Amount = consumableform.Amount,Status="入庫" });
                else
                    list.Add(new ConsumableIOList { Amount = consumableform.Amount, Status = "報廢" });
            }
            foreach (WorkFormConsumable workformconsumable in workformConsumables)
            {
                if (workformconsumable.Amount>0)
                    list.Add(new ConsumableIOList { Amount = workformconsumable.Amount, Status = "安裝" ,Unit = workformconsumable.WorkForm.Unit.ListedName});
                else
                    list.Add(new ConsumableIOList { Amount = workformconsumable.Amount, Status = "回收", Unit = workformconsumable.WorkForm.Unit.ListedName });
            }
            foreach (RMAForm rmaform in rmaforms)
            {
                if (rmaform.Closed)
                    list.Add(new ConsumableIOList { Amount = 0, Status = "維修(已完修)" });
                else
                    list.Add(new ConsumableIOList { Amount = 1, Status = "維修" });
            }
            return list;
        }
        // GET: ConsumablesC
        public ActionResult ConsumableIOList(int ID)
        {

            var consumableIOList = GetConsumableIOList(ID).AsQueryable();
            int page;
            int pageCount;
            int pageSize;
            page = 1;
            pageSize = TSRD.Global.PageSize;

            pageCount = Convert.ToInt16(Math.Ceiling(Convert.ToDouble(consumableIOList.Count()) / pageSize));
            consumableIOList = consumableIOList.OrderByDescending(m => m.ID).Skip(pageSize * (page - 1)).Take(pageSize).AsQueryable();
            ViewData["SearchString"] = "";
            ViewData["PageCount"] = pageCount;
            ViewData["CurrentPage"] = 1;
            ViewData["ConsumableName"] = db.Consumable.Single(m => m.ID == ID).ListedName;
            //return View(consumableForm.ToList());
            return View(consumableIOList.ToList());
        }

        [HttpPost, ActionName("ConsumableIOList")]
        public ActionResult ConsumableIOList(string searchString, int? Page, int ID)
        {
            var consumableIOList = GetConsumableIOList(ID).AsQueryable();
            int page;
            int pageCount;
            int pageSize;
            page = Page ?? 1;
            if (page < 1)
                page = 1;
            pageSize = TSRD.Global.PageSize;


            if (!String.IsNullOrEmpty(searchString))
            {

                consumableIOList = consumableIOList.Where(m => m.Description.Contains(searchString) || m.Comment.Contains(searchString)).AsQueryable();
            }
            pageCount = Convert.ToInt16(Math.Ceiling(Convert.ToDouble(consumableIOList.Count()) / pageSize));
            if (page > pageCount)
                page = pageCount;
            consumableIOList = consumableIOList.OrderByDescending(m => m.ID).Skip(pageSize * (page - 1)).Take(pageSize).AsQueryable();
            ViewData["SearchString"] = searchString;
            ViewData["PageCount"] = pageCount;
            ViewData["CurrentPage"] = page;
            ViewData["ConsumableName"] = db.Consumable.Single(m => m.ID == ID).ListedName;
            return View(consumableIOList.ToList());
        }
        public ActionResult AddConsumable(int ID)
        {
            ViewData["ConsumableID"] = ID;
            ViewData["Consumable"] = db.Consumable.Single(m => m.ID == ID).ListedName;
            return View();
        }
        [HttpPost, ActionName("AddConsumable")]
        [ValidateAntiForgeryToken]
        public ActionResult AddConsumable([Bind(Include = "ID,Amount,ConsumableID,Description,Comment,CreatedTime,ModifiedTime")] ConsumableForm consumableForm)
        {
            if (consumableForm.Amount <= 0)
            {
                ModelState.AddModelError("Amount", "數量有誤，請重新輸入");
            }
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
            if (consumableForm.Amount<=0)
            {
                ModelState.AddModelError("Amount", "數量有誤，請重新輸入");
            }
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
        public ActionResult Create([Bind(Include = "ID,Name,NO,Enabled,Description,Comment,CreatedTime,ModifiedTime")] Consumable consumable)
        {
            var existConsumable = db.Consumable.Where(m => m.NO.Equals(consumable.NO)).AsQueryable();
            if (existConsumable.Count()>0)
            {
                ModelState.AddModelError("NO", "耗材編號重複，請檢查後重試");
            }
            existConsumable = db.Consumable.Where(m => m.Name.Equals(consumable.Name)).AsQueryable();
            if (existConsumable.Count() > 0)
            {
                ModelState.AddModelError("Name", "耗材名稱重複，請檢查後重試");
            }
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
        public ActionResult Edit([Bind(Include = "ID,Name,NO,Enabled,Description,Comment,CreatedTime,ModifiedTime")] Consumable consumable)
        {
            var existConsumable = db.Consumable.Where(m => m.NO.Equals(consumable.NO) && m.ID!=consumable.ID).AsQueryable();
            if (existConsumable.Count() > 0)
            {
                ModelState.AddModelError("NO", "耗材編號重複，請檢查後重試");
            }
            existConsumable = db.Consumable.Where(m => m.Name.Equals(consumable.Name) && m.ID != consumable.ID).AsQueryable();
            if (existConsumable.Count() > 0)
            {
                ModelState.AddModelError("Name", "耗材名稱重複，請檢查後重試");
            }
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
