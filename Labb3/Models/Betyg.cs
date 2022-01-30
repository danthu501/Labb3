using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb3.Models
{
    public partial class Betyg
    {
        public int BetygId { get; set; }
        public int Ämne { get; set; }
        public string Betyg1 { get; set; }
        public DateTime? BetygetSatDatum { get; set; }
        public int? BetygsättandeLärareId { get; set; }

        public virtual Anställda BetygsättandeLärare { get; set; }
        public virtual Ämne ÄmneNavigation { get; set; }
    }
}
