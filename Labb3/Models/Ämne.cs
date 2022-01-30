using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb3.Models
{
    public partial class Ämne
    {
        public Ämne()
        {
            Betyg = new HashSet<Betyg>();
        }

        public int ÄmneId { get; set; }
        public string ÄmneNamn { get; set; }

        public virtual ICollection<Betyg> Betyg { get; set; }
    }
}
