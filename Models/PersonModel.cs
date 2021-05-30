using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
// using System.Linq;
// using System.Threading.Tasks;

namespace exercise22.Models
{
    public class PersonModel
    {
        public int ID { get; set; }
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Range(18 , 65)]
        public int Age { get; set; }

        [Required]
        public DateTime DOB { get; set; }
        public String PolicyDetails { get; set; }

    }
}
