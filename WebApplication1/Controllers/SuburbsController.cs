﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SuburbsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Suburbs
        public ActionResult Index(string searchBy, string search)
        {

            if (searchBy == "Name")
            {
                var suburb = db.Suburbs.Include(s => s.City).Where((x => x.SuburbName.Contains(search) || search == null));
                return View(suburb.ToList());
            }
            else
            {

                var suburb = db.Suburbs.Include(s => s.City).Where((x => x.City.CityName.Contains(search) || search == null));
                return View(suburb.ToList());


            }
        }

        // GET: Suburbs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suburb suburb = db.Suburbs.Find(id);
            if (suburb == null)
            {
                return HttpNotFound();
            }
            return View(suburb);
        }

        // GET: Suburbs/Create
        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName");
            return View();
        }

        // POST: Suburbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SuburbID,SuburbName,CityID")] Suburb suburb)
        {
            if (ModelState.IsValid)
            {
                db.Suburbs.Add(suburb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName", suburb.CityID);
            return View(suburb);
        }

        // GET: Suburbs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suburb suburb = db.Suburbs.Find(id);
            if (suburb == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName", suburb.CityID);
            return View(suburb);
        }

        // POST: Suburbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SuburbID,SuburbName,CityID")] Suburb suburb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suburb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName", suburb.CityID);
            return View(suburb);
        }

        // GET: Suburbs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suburb suburb = db.Suburbs.Find(id);
            if (suburb == null)
            {
                return HttpNotFound();
            }
            return View(suburb);
        }

        // POST: Suburbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Suburb suburb = db.Suburbs.Find(id);
            db.Suburbs.Remove(suburb);
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
