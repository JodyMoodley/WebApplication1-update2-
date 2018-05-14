using System;
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
    public class CheckInsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CheckIns
        public ActionResult Index()
        {
            var checkIns = db.CheckIns.Include(c => c.RoomReservations);
            return View(checkIns.ToList());
        }

        // GET: CheckIns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckIn checkIn = db.CheckIns.Find(id);
            if (checkIn == null)
            {
                return HttpNotFound();
            }
            return View(checkIn);
        }

        // GET: CheckIns/Create
        public ActionResult Create()
        {
            ViewBag.ReservationID = new SelectList(db.RoomReservations, "RR_ID", "UserName");
            return View();
        }

        // POST: CheckIns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CheckInID,CheckInDate,ReservationID")] CheckIn checkIn)
        {
            if (ModelState.IsValid)
            {
                RoomReservation roomReservation = new RoomReservation();
                roomReservation = db.RoomReservations.Find(checkIn.ReservationID);
                roomReservation.ACheckIn = checkIn.CheckInDate;
                roomReservation.BookingStatus = "Booked";
                db.CheckIns.Add(checkIn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReservationID = new SelectList(db.RoomReservations, "RR_ID", "UserName", checkIn.ReservationID);
            return View(checkIn);
        }

        // GET: CheckIns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckIn checkIn = db.CheckIns.Find(id);
            if (checkIn == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReservationID = new SelectList(db.RoomReservations, "RR_ID", "UserName", checkIn.ReservationID);
            return View(checkIn);
        }

        // POST: CheckIns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CheckInID,CheckInDate,ReservationID")] CheckIn checkIn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checkIn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReservationID = new SelectList(db.RoomReservations, "RR_ID", "UserName", checkIn.ReservationID);
            return View(checkIn);
        }

        // GET: CheckIns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckIn checkIn = db.CheckIns.Find(id);
            if (checkIn == null)
            {
                return HttpNotFound();
            }
            return View(checkIn);
        }

        // POST: CheckIns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CheckIn checkIn = db.CheckIns.Find(id);
            db.CheckIns.Remove(checkIn);
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
