using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLeopard.Api.Framework
{
    public interface ILog
    {
        void Debug(object value);
        void Error(Exception exception);
    }
}
