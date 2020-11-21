using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMe.Models
{
    public class TalentDetail
    {
        public int TalentId { get; set; }

        [Display(Name="Artist")]
        public string UserId { get; set; } // or is this going to be ArtistId??
        public string TalentTitle { get; set; }
        public string TalentDescription { get; set; }
    }
}
// I hate git hub        // I hate git hub

