﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindDAL.Entities
{
    public class Territory
    {
        public int TerritoryID { get; set; }
        public string TerritoryDescription { get; set; }
        public int RegionID { get; set; }
    }
}
