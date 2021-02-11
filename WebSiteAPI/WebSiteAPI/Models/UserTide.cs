using System;
using System.Collections.Generic;

#nullable disable

namespace WebSiteAPI.Models
{
    public partial class UserTide
    {
        public int UserTidesId { get; set; }
        public string UserId { get; set; }
        public int TidesId { get; set; }

        public virtual Tide Tides { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
