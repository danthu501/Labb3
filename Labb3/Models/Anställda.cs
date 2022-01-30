using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb3.Models
{
    public partial class Anställda
    {
        public Anställda()
        {
            Betyg = new HashSet<Betyg>();
        }

        public int AnställningsNummer { get; set; }
        public string FörNamn { get; set; }
        public string EfterNamn { get; set; }
        public string Befattning { get; set; }

        public virtual ICollection<Betyg> Betyg { get; set; }
    }
}
