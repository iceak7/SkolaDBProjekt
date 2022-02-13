using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SkolaDBProjekt.Models
{
    public partial class BetygPoäng
    {
        public BetygPoäng()
        {
            BetygNavigation = new HashSet<Betyg>();
        }

        public string Betyg { get; set; }
        public int? Poäng { get; set; }

        public virtual ICollection<Betyg> BetygNavigation { get; set; }
    }
}
