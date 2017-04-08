using System;

namespace SmartLeopard.Dal.Framework
{
    public interface IEntity
    {
        int Id { get; set; }
        bool Disabled { get; set; }
        DateTime Created { get; set; }
        DateTime Updated { get; set; }
    }
}