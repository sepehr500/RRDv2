﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RRDv2.Models
{
    public enum BedSize
    {
        Twin,
        TwinXL,
        CaliforniaKing,
        Queen,
        Full,
        King
    }
    public class Room
    {

        public int Id { get; set; }

        public int FloorId { get; set; }
        public int ReviewId { get; set; }
        public int RoomNum { get; set; }
        public int NumberOfBeds { get; set; }
        public BedSize BedSize { get; set; }
        public virtual RoomType RoomType { get; set; }
        public virtual Floor Floor { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        
    }
}