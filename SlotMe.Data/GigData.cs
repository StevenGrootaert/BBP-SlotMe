﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMe.Data
{
    public class Gig
    {
        [Key]
        public int GigId { get; set; }

        [ForeignKey("TalentRef")]
        public int TalentId { get; set; }
        public virtual Talent TalentRef { get; set; }

        [ForeignKey("ArtistId")]
        // changed from Guid to string?
        public string UserId { get; set; }
        public int UserID { get; set; }
        public virtual ApplicationUser ArtistId { get; set; }

        [Required]
        public DateTime GigStart { get; set; }

        [Required]
        public DateTime GigEnd { get; set; }
        public string Talent { get; set; }
        public string Time { get; set; }
    }
}
