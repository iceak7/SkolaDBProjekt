using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SkolaDBProjekt.Models
{
    public partial class ElevKurs
    {
        public int ElevKursId { get; set; }
        public string Fkpersonnummer { get; set; }
        public int? FkkursId { get; set; }

        public virtual Kurs Fkkurs { get; set; }
        public virtual Elev FkpersonnummerNavigation { get; set; }
    }
}
