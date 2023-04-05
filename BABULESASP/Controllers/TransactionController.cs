using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BABULESASP.Models;

namespace BABULESASP.Controllers
{
    public class TransactionController : Controller
    {
        private FinanceManagerDBEntities db = new FinanceManagerDBEntities();

        // GET: Transaction
        public ActionResult Index()
        {
            return View(db.tblTransactions.ToList());
        }

        // GET: Transaction/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTransaction tblTransaction = db.tblTransactions.Find(id);
            if (tblTransaction == null)
            {
                return HttpNotFound();
            }
            return View(tblTransaction);
        }

        // GET: Transaction/Create
        public ActionResult Create()
        {
            List<string> tblategories = (from data in db.tblCategories select data.ct_name.Distinct<>).ToList();
            ViewBag.CategoriesListforName = new SelectList(tblategories);
            return View();
        }

        // POST: Transaction/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,tr_categorie,tr_type,tr_sum,tr_date,tr_description_")] tblTransaction tblTransaction)
        {
            List<string> tblategories = (from data in db.tblCategories select data.ct_name).ToList();
            ViewBag.CategoriesListforName = new SelectList(tblategories);
            if (ModelState.IsValid)
            {
                db.tblTransactions.Add(tblTransaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblTransaction);
        }

        // GET: Transaction/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTransaction tblTransaction = db.tblTransactions.Find(id);
            if (tblTransaction == null)
            {
                return HttpNotFound();
            }
            return View(tblTransaction);
        }

        // POST: Transaction/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,tr_categorie,tr_type,tr_sum,tr_date,tr_description_")] tblTransaction tblTransaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblTransaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblTransaction);
        }

        // GET: Transaction/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTransaction tblTransaction = db.tblTransactions.Find(id);
            if (tblTransaction == null)
            {
                return HttpNotFound();
            }
            return View(tblTransaction);
        }

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblTransaction tblTransaction = db.tblTransactions.Find(id);
            db.tblTransactions.Remove(tblTransaction);
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
