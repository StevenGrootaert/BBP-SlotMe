using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMe.Data
{
    public class Slot
    {
        [Key]
        public string TimeSlotId { get; set; }
        [ForeignKey("ArtistId")]
        public string UserId { get; set; }
        public virtual ApplicationUser ArtistId { get; set; }
        [Required]
        public DateTime AvailableStart { get; set; }
        [Required]
        public DateTime AvailableEnd { get; set; }
     
    }
}
