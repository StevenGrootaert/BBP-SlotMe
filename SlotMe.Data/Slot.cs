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
        public int SlotId { get; set; }
        [ForeignKey("ArtistId")]
        public string UserId { get; set; }
        public virtual ApplicationUser ArtistId { get; set; }
        
        public DateTime SlotStart { get; set; }
        
        public DateTime SlotEnd { get; set; }
        
    }
}
