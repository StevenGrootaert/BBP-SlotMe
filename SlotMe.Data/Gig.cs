using System;
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

        [ForeignKey("Talent Ref")]
        public int TalentId { get; set; }
        public virtual Talent TalentRef { get; set; } 

        [ForeignKey("Artist")]
        public Guid UserId { get; set; }
        public virtual ApplicationUser ArtistId { get; set; }

        [Required]
        public DateTime GigStart { get; set; }

        [Required]
        public DateTime GigEnd { get; set; }
    }
}
