using System;
using System.Collections.Generic;

#nullable disable

namespace WebSiteAPI.Models
{
    public partial class Tide
    {
        public Tide()
        {
            UserTides = new HashSet<UserTide>();
        }

        public int TidesId { get; set; }
        public DateTime Day { get; set; }
        public string TideType { get; set; }
        public DateTime Time { get; set; }
        public double Height { get; set; }
        public int? Attendance { get; set; }

        public virtual ICollection<UserTide> UserTides { get; set; }
    }
}
