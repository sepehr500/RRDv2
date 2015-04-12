using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RRDv2.Models
{
    public class Review
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Stars { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}