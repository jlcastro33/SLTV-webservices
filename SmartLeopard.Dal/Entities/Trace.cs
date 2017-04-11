using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SmartLeopard.Dal.Framework;

namespace SmartLeopard.Dal.Entities
{
    [Table("tracing")]
    public class Trace: Entity
    {
        public string EndpointWithoutParams { get; set; }
        public string Method { get; set; }
        public string EndpointParams { get; set; }
        public string RequestContent { get; set; }

        public string ResponseStatusCode{ get; set; }
        public string  ResponseContent { get; set; }
        public double ProcessTimeMls { get; set; } 
    }
}
