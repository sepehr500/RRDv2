using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RRDv2.Models
{
    public enum BedSize
    {
        Full,
        Queen,
        King,
        CaliforniaKing,
        Twin,
        TwinXL
    }
    //public enum RoomType
    //{
    //    Guest,
    //    Suite,
    //    Executive,
    //    Tripple,
    //    Standard
    //}
    
    public class Room
    {

        public int Id { get; set; }

        public int FloorId { get; set; }
        public int RoomNum { get; set; }
        public int RoomTypeId { get; set; }
        public int? RoomLength { get; set; }
        public int? RoomSize { get; set; }
        public int ElevatorDistance { get; set; }
        public bool ConnectingRoom { get; set; }
        public int NumberOfBeds { get; set; }
        public BedSize BedSize { get; set; }
        public virtual RoomType RoomType { get; set; }
        public virtual Floor Floor { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        
    }
}