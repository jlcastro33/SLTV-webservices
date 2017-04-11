using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartLeopard.Dal.Framework;
using SmartLeopard.Models.Enums;

namespace SmartLeopard.Dal.Entities
{

    [Table("devices")]
    public class Device : Entity
    { 
        [Required]
        public string Mac { get; set; }
        [Required]
        public DeviceStatus  Status { get; set; }
        public string Model { get; set; }
        public string FirmwareVersion { get; set; }
        public string  Language { get; set; }


        public virtual ICollection<User> Users { get; set; }
    }
}
