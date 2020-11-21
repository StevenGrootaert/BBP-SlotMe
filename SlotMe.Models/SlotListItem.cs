using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMe.Models
{
    public class SlotListItem
    {
        public int SlotId { get; set; }
        public string UserId { get; set; }
        public DateTime SlotStart { get; set; }
        public DateTime SlotEnd { get; set; }

    }
}
