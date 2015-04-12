using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RRDv2.Models
{
    public class Floor
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int FloorNum { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}