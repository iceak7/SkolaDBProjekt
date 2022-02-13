using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SkolaDBProjekt.Models
{
    public partial class Betyg
    {
        public int BetygId { get; set; }
        public int? FkkursId { get; set; }
        public string SattBetyg { get; set; }
        public DateTime? Datum { get; set; }
        public int? FkpersonalId { get; set; }
        public string Fkpersonnummer { get; set; }

        public virtual Kurs Fkkurs { get; set; }
        public virtual Personal Fkpersonal { get; set; }
        public virtual Elev FkpersonnummerNavigation { get; set; }
        public virtual BetygPoäng SattBetygNavigation { get; set; }
    }
}
