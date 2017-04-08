using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SmartLeopard.Dal.Framework;

namespace SmartLeopard.Dal.Entities
{
    public class User: Entity
    {
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required]
        public string  Email { get; set; }
        public string  Password { get; set; }
        public string ZipCode { get; set; }
        public string  CountryCode { get; set; }
         
        public virtual ICollection<Device> Devices { get; set; }
    }
}
