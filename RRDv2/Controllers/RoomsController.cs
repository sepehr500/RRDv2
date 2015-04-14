using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RRDv2.Models;

namespace RRDv2.Controllers
{
    public class RoomsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rooms
        public ActionResult Index(int FloorId = -1)
        {
            var rooms = db.Rooms.Include(r => r.Floor);
            if (FloorId != -1)
            {

                Session["FloorId"] = FloorId;
                rooms = db.Rooms.Where(x => x.FloorId == FloorId).Include(r => r.Floor);

            }

            ViewBag.FloorId = FloorId;
            return View(rooms.ToList());
        }

        // GET: Rooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // GET: Rooms/Create
        public ActionResult Create(int FloorId = -1)
        {
            ViewBag.FloorId = new SelectList(db.Floors, "Id", "Id");
            //ViewBag.RoomTypes = new SelectList(db.RoomTypes, "Type", "Type");
            Session["RoomTypes"] = new SelectList(db.RoomTypes, "Type", "Type");
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RoomNum,NumberOfBeds,BedSize,RoomType, RoomSize, ElevatorDistance , ConnectingRoom")] Room room)
        {
            if (ModelState.IsValid)
            {
                var the_room_type = Request.Form["room_type"];
                var the_room_selection = Request.Form["room_selection"];
                System.Diagnostics.Debug.WriteLine("the_room_type: " + the_room_type);
                System.Diagnostics.Debug.WriteLine("the_room_selection: " + Request.Form["room_selection"]);
                if (Request.Form["room_selection"] == "Other")
                {

                    var num_rooms = db.RoomTypes.Where(x => x.Type == the_room_type).Count();
                    if (num_rooms == 0){
                        RoomType roomType = new RoomType();
                        roomType.Type = Request.Form["room_type"];
                        db.RoomTypes.Add(roomType);
                        room.RoomTypeId = roomType.Id;
                        room.RoomType = roomType;
                    }
                    else{
                        room.RoomTypeId = db.RoomTypes.Where(x => x.Type == Request.Form["room_type"]).First().Id;
                        room.RoomType = db.RoomTypes.Where(x => x.Type == Request.Form["room_type"]).First();
                    } 
                }
                else
                {
                    var room_type = db.RoomTypes.Where(x => x.Type == the_room_selection).First();
                    room.RoomTypeId = room_type.Id;
                    room.RoomType = room_type;
                }

                room.FloorId = (int)Session["FloorId"];

                db.Rooms.Add(room);
                db.SaveChanges();
                return RedirectToAction("Index", new { FloorId = (int)Session["FloorId"] });
            }

            ViewBag.FloorId = new SelectList(db.Floors, "Id", "Id", room.FloorId);
            return View(room);
        }

        // GET: Rooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }

            
            ViewBag.FloorId = new SelectList(db.Floors, "Id", "Id");
            //ViewBag.FloorId = new SelectList(db.Floors, "Id", "Id", room.FloorId);
            Session["RoomTypes"] = new SelectList(db.RoomTypes, "Type", "Type");
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FloorId,RoomNum,NumberOfBeds,BedSize,RoomType, RoomSize, ElevatorDistance , ConnectingRoom")] Room room)
        {
            if (ModelState.IsValid)
            {
                var the_room_type = Request.Form["room_type"];
                var the_room_selection = Request.Form["room_selection"];
                System.Diagnostics.Debug.WriteLine("the_room_type: " + the_room_type);
                System.Diagnostics.Debug.WriteLine("the_room_selection: " + Request.Form["room_selection"]);
                if (Request.Form["room_selection"] == "Other")
                {

                    var num_rooms = db.RoomTypes.Where(x => x.Type == the_room_type).Count();
                    if (num_rooms == 0)
                    {
                        RoomType roomType = new RoomType();
                        roomType.Type = Request.Form["room_type"];
                        db.RoomTypes.Add(roomType);
                        room.RoomTypeId = roomType.Id;
                        room.RoomType = roomType;
                    }
                    else
                    {
                        room.RoomTypeId = db.RoomTypes.Where(x => x.Type == Request.Form["room_type"]).First().Id;
                        room.RoomType = db.RoomTypes.Where(x => x.Type == Request.Form["room_type"]).First();
                    }
                }
                else
                {
                    var room_type = db.RoomTypes.Where(x => x.Type == the_room_selection).First();
                    room.RoomTypeId = room_type.Id;
                    room.RoomType = room_type;
                }



               
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FloorId = new SelectList(db.Floors, "Id", "Id", room.FloorId);
            return View(room);
        }

        // GET: Rooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Room room = db.Rooms.Find(id);
            db.Rooms.Remove(room);
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
