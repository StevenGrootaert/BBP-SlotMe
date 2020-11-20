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
        [Required]
        public int UserID { get; set; }
        [Required]
        public string Talent { get; set; }

        public string Time { get; set; }

        //public virtual User Author { get; set; }
    }
}
