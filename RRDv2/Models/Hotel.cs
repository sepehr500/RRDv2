using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RRDv2.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public int Zip { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Street { get; set; }

        public virtual ICollection<Floor> Floors { get; set; }
    }
}