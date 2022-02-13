using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SkolaDBProjekt.Models
{
    public partial class Kurs
    {
        public Kurs()
        {
            Betyg = new HashSet<Betyg>();
            ElevKurs = new HashSet<ElevKurs>();
            LärareKurs = new HashSet<LärareKurs>();
        }

        public int KursId { get; set; }
        public string Ämne { get; set; }
        public DateTime? Startdatum { get; set; }
        public DateTime? Slutdatum { get; set; }

        public virtual ICollection<Betyg> Betyg { get; set; }
        public virtual ICollection<ElevKurs> ElevKurs { get; set; }
        public virtual ICollection<LärareKurs> LärareKurs { get; set; }
    }
}
