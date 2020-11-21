using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMe.Models
{
    public class TalentCreate
    {
        public int TalentId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string TalentTitle { get; set; }

        [MaxLength(8000)]
        public string TalentDescription { get; set; }
    }
}        // I hate git hub

