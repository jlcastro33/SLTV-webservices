using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartLeopard.Dal.Framework;

namespace SmartLeopard.Dal.Helpers
{
    public static class StaticExtensions
    {
        public static void ApplyCreateDefaults(this IEntity entityToUpdate)
        {
            entityToUpdate.Created = DateTime.Now;
            entityToUpdate.ApplyUpdateDefaults();
        }
        public static void ApplyUpdateDefaults(this IEntity entityToUpdate)
        {
            entityToUpdate.Updated = DateTime.Now;
        }
    }
}
