using System;
using System.Collections.Generic;

#nullable disable

namespace APIPlaceOfRestProject
{
    public partial class Event
    {
        public int Idevent { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Discription { get; set; }
        public int? PictureLink { get; set; }
        public int EventLink { get; set; }
        public int Theme { get; set; }
        public int Building { get; set; }
        public int? Underground { get; set; }
    }
}
