using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMe.Models
{
    public class SlotListItem
    {
        public string TimeSlotId { get; set; }
        public string UserId { get; set; }
        public DateTime AvailableStart { get; set; }
        public DateTime AvailableEnd { get; set; }

    }
}
