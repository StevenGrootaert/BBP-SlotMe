using SlotMe.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMe.Models
{
    public class GigCreate
    {
        public int GigId { get; set; }

        [Required]
        public int TalentRef { get; set; } // might be TalentId as the ForeignKey

        [Required]
        public virtual ApplicationUser ArtistId { get; set; }

        //public int UserID { get; set; } // this is the user that created (booked) the Gig which gets tagged int he gig service I think

        [Required]
        public DateTime GigStart { get; set; }

        [Required]
        public DateTime GigEnd { get; set; }


        //public string Time { get; set; }

        //public virtual User Author { get; set; }
    }
}
