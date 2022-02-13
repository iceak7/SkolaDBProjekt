using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SkolaDBProjekt.Models
{
    public partial class Elev
    {
        public Elev()
        {
            Betyg = new HashSet<Betyg>();
            ElevKurs = new HashSet<ElevKurs>();
        }

        public string Personnummer { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public string Kön { get; set; }
        public int? FkklassId { get; set; }

        public virtual Klass Fkklass { get; set; }
        public virtual ICollection<Betyg> Betyg { get; set; }
        public virtual ICollection<ElevKurs> ElevKurs { get; set; }
    }
}
