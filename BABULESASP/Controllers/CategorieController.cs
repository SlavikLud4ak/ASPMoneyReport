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
    public class CategorieController : Controller
    {
        private FinanceManagerDBEntities db = new FinanceManagerDBEntities();

        // GET: Categorie
        public ActionResult Index()
        {
            return View(db.tblCategories.ToList());
        }

        // GET: Categorie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCategorie tblCategorie = db.tblCategories.Find(id);
            if (tblCategorie == null)
            {
                return HttpNotFound();
            }
            return View(tblCategorie);
        }

        // GET: Categorie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ct_name,ct_description")] tblCategorie tblCategorie)
        {
            if (ModelState.IsValid)
            {
                db.tblCategories.Add(tblCategorie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblCategorie);
        }

        // GET: Categorie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCategorie tblCategorie = db.tblCategories.Find(id);
            if (tblCategorie == null)
            {
                return HttpNotFound();
            }
            return View(tblCategorie);
        }

        // POST: Categorie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ct_name,ct_description")] tblCategorie tblCategorie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCategorie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblCategorie);
        }

        // GET: Categorie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCategorie tblCategorie = db.tblCategories.Find(id);
            if (tblCategorie == null)
            {
                return HttpNotFound();
            }
            return View(tblCategorie);
        }

        // POST: Categorie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblCategorie tblCategorie = db.tblCategories.Find(id);
            db.tblCategories.Remove(tblCategorie);
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
