using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMe.Models
{
    public class TalentListItem
    {
        public int TalentId { get; set; }
        public string TalentTitle { get; set; }
        public string TalentDescription { get; set; }

        // public int ArtistId { get; set } // it says this is void? it's one of the foreign keys

        // are we going to need the Artist Id displayed here? 
    }
}
// I hate git hub

