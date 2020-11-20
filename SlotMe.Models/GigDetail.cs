using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMe.Models
{
    public class GigDetail
    {
        public int ID { get; set; }
        public string Talent { get; set; }
        public string Time { get; set; }

        public virtual User User { get; set; }
    }2
}
