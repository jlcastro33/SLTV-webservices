using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLeopard.Models.Enums
{
    public enum DeviceStatus
    {
        [Description("booting")] Booting,
        [Description("running")] Running,
        [Description("shutting_down")] ShuttingDown
    }
}
