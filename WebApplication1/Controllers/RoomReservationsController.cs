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
    public class RoomReservationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RoomReservations
        public ActionResult Index()
        {
            var roomReservations = db.RoomReservations.Include(r => r.Rooms);
            var ac = db.Users.Include(r => r.UserName);
            return View(roomReservations.ToList());
        }

        // GET: RoomReservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomReservation roomReservation = db.RoomReservations.Find(id);
            if (roomReservation == null)
            {
                return HttpNotFound();
            }
            return View(roomReservation);
        }

        // GET: RoomReservations/Create
        public ActionResult Create()
        {
            ViewBag.RoomID = new SelectList(db.Rooms, "RoomID", "RoomID");
            ViewBag.UserName = new SelectList(db.Users, "UserName", "UserName");
            return View();
        }

        private bool isDateValid(RoomReservation roomReservation)
        {
            if(IsDatePassed(roomReservation.CheckIn))
            {
                ModelState.AddModelError("inValidDate", "Date has already passed");
                return false;
            }
            return true;
        }

        public bool IsDatePassed(DateTime dateToValidate)
        {
            var results = dateToValidate < DateTime.Now;
            return results;
        }
        // POST: RoomReservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RR_ID,RoomID,UserID,UserName,CheckIn,CheckOut,Bill,BookingStatus,ACheckIn,ACheckOut")] RoomReservation roomReservation)
        {
            //roomReservation.CheckIn = new DateTime(roomReservation.CheckIn.Year, roomReservation.CheckIn.Month, roomReservation.CheckIn.Day);

            if (ModelState.IsValid /*&& isDateValid(roomReservation)*/)
            {
                //var use = db.RoomReservations.ToList().Find(x => x.RR_ID == roomReservation.RR_ID);
                //if(use!=null)
                //{
                //    ModelState.AddModelError("", "Reservation already exists");
                //    ModelState.Clear();
                //    ViewBag.Messageb = "Reservation ID already exists! please try again";
                //}
                //var user = db.RoomReservations.ToList().Find(x => x.CheckIn == roomReservation.CheckIn);
                //if(user!=null)
                //{
                //    ModelState.AddModelError("", "Date is already Booked");
                //    ModelState.Clear();
                //    ViewBag.Messagea="Date is already booked! please try again";
                //}
                //else
                //{
                //    string str = TempData[]
                //}
                //roomReservation.Bill = roomReservation.calcCost();
                roomReservation.BookingStatus = roomReservation.calcStatus();
                db.RoomReservations.Add(roomReservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoomID = new SelectList(db.Rooms, "RoomID", "RoomID", roomReservation.RoomID);
            ViewBag.UserName = new SelectList(db.Users, "UserName", "UserName", roomReservation.UserID);
            return View(roomReservation);
        }

        // GET: RoomReservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomReservation roomReservation = db.RoomReservations.Find(id);
            if (roomReservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoomID = new SelectList(db.Rooms, "RoomID", "RoomID", roomReservation.RoomID);
            ViewBag.UserName = new SelectList(db.Users, "UserName", "UserName", roomReservation.UserID);
            return View(roomReservation);
        }

        // POST: RoomReservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RR_ID,RoomID,UserID,UserName,CheckIn,CheckOut,Bill,BookingStatus,ACheckIn,ACheckOut")] RoomReservation roomReservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomReservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoomID = new SelectList(db.Rooms, "RoomID", "RoomID", roomReservation.RoomID);
            ViewBag.UserName = new SelectList(db.Users, "UserName", "UserName", roomReservation.UserID);
            return View(roomReservation);
        }

        // GET: RoomReservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomReservation roomReservation = db.RoomReservations.Find(id);
            if (roomReservation == null)
            {
                return HttpNotFound();
            }
            return View(roomReservation);
        }

        // POST: RoomReservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoomReservation roomReservation = db.RoomReservations.Find(id);
            db.RoomReservations.Remove(roomReservation);
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
