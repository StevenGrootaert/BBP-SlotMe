using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SlotMe.Data
{
    public class Availability
    {
        [Key]
        public int TimeSlotId { get; set; }

        [ForeignKey("Artist")]
        public Guid UserId { get; set; }
        public virtual ApplicationUser ArtistId { get; set; }

        [Required]
        public DateTime SlotStart { get; set; }

        [Required]
        public DateTime SlotEnd { get; set; }
    }
}
