using SlotMe.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMe.Models
{
    public class GigEdit
    {
        public int GigId { get; set; }
        public int TalentRef { get; set; }
        public virtual ApplicationUser ArtistId { get; set; }

        public DateTime GigStart { get; set; }
        public DateTime GigEnd { get; set; }
    }
}
