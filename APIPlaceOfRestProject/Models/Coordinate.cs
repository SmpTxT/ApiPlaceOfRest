using System;
using System.Collections.Generic;

#nullable disable

namespace APIPlaceOfRestProject
{
    public partial class Coordinate
    {
        public Coordinate()
        {
            Buildings = new HashSet<Building>();
        }

        public int Idcoordinate { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public virtual ICollection<Building> Buildings { get; set; }
    }
}
