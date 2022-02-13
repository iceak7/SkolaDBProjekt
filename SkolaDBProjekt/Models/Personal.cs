using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SkolaDBProjekt.Models
{
    public partial class Personal
    {
        public Personal()
        {
            Betyg = new HashSet<Betyg>();
            LärareKurs = new HashSet<LärareKurs>();
        }

        public int PersonalId { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public string Befattning { get; set; }
        public decimal? Månadslön { get; set; }
        public DateTime? AnställningsDatum { get; set; }

        public virtual ICollection<Betyg> Betyg { get; set; }
        public virtual ICollection<LärareKurs> LärareKurs { get; set; }
    }
}
