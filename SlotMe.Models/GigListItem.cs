using Microsoft.VisualBasic.ApplicationServices;
using SlotMe.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMe.Models
{
    public class GigListItem
    {
        public int GigId { get; set; }
        public int TalentId { get; set; }
        // public in TalentRef { get; set; }
        public virtual ApplicationUser ArtistId { get; set; }

    }
}
