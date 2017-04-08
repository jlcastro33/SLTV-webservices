using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLeopard.Models
{
    public class RegistryModel
    {
        [Required]
        public string Mac { get; set; }

        [Required]
        public string Lang { get; set; }

        [Required]
        public string Name { get; set; }

        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string ZipCode { get; set; }

        public string CountryCode { get; set; } 
    }
}
