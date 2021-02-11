﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WebSiteAPI.Models.ModelsAPI
{
    public class Beach
    {

        public int Id { get; set; }
        
        public string BeachName { get; set; }
        public int CountyId { get; set; }
        public virtual County County { get; set; }
    }
}
