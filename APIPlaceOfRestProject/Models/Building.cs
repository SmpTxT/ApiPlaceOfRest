using System;
using System.Collections.Generic;

#nullable disable

namespace APIPlaceOfRestProject
{
    public partial class Building
    {
        public int Idbuilding { get; set; }
        public int NumberBuilding { get; set; }
        public int? NumberStructure { get; set; }
        public int Idstreet { get; set; }
        public int Idcoordinate { get; set; }

        public virtual Coordinate IdcoordinateNavigation { get; set; }
        public virtual Street IdstreetNavigation { get; set; }
    }
}
