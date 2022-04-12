using System;
using System.Collections.Generic;

#nullable disable

namespace APIPlaceOfRestProject
{
    public partial class Street
    {
        public Street()
        {
            Buildings = new HashSet<Building>();
        }

        public int Idstreet { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Building> Buildings { get; set; }
    }
}
