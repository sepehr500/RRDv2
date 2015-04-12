using RRDv2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RRDv2.Controllers
{
    public class FloorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Floors
        public ActionResult Index(int HotelId = -1)
        {
            var floors = db.Floors.Include(f => f.Hotel);
            if (HotelId != -1)
            {
            floors = db.Floors.Where(x => x.HotelId == HotelId).Include(f => f.Hotel);

                
            }
            return View(floors.ToList());
        }

        // GET: Floors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Floor floor = db.Floors.Find(id);
            if (floor == null)
            {
                return HttpNotFound();
            }
            return View(floor);
        }

        // GET: Floors/Create
        public ActionResult Create(int HotelId = -1 )
        {
            ViewBag.HotelId = new SelectList(db.Hotels, "Id", "Name");
            if (HotelId != -1)
            {
                ViewBag.HotelId = HotelId;
                ViewBag.HotelName = db.Hotels.Where(x => x.Id == HotelId).First();
                Session["HotelId"] = HotelId;
            }
            return View();
        }

        // POST: Floors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int HotelId = -1, int NumFloor = 0)
        {

            for (int i = 0; i < NumFloor; i++)
            {
                db.Floors.Add(new Floor { HotelId = (int)Session["HotelId"], FloorNum = i + 1 });
                
            }
                db.SaveChanges();

            return RedirectToAction("Index", new { HotelId = (int)Session["HotelId"] });
        }

        // GET: Floors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Floor floor = db.Floors.Find(id);
            if (floor == null)
            {
                return HttpNotFound();
            }
            ViewBag.HotelId = new SelectList(db.Hotels, "Id", "Name", floor.HotelId);
            return View(floor);
        }

        // POST: Floors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HotelId,FloorNum")] Floor floor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(floor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HotelId = new SelectList(db.Hotels, "Id", "Name", floor.HotelId);
            return View(floor);
        }

        // GET: Floors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Floor floor = db.Floors.Find(id);
            if (floor == null)
            {
                return HttpNotFound();
            }
            return View(floor);
        }

        // POST: Floors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Floor floor = db.Floors.Find(id);
            db.Floors.Remove(floor);
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
