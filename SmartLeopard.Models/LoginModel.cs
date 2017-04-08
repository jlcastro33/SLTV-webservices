using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLeopard.Models
{
    public class LoginModel
    {
        [Required]
        public string Mac { get; set; }

        [Required]
        public string Lang { get; set; }
        
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
