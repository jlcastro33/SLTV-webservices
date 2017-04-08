using System;
using System.ComponentModel.DataAnnotations;

namespace SmartLeopard.Dal.Framework
{ 
    public abstract class Entity : IEntity 
    {
        [Key]
        public int Id { get; set; }

        public bool Disabled { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

    }
}
