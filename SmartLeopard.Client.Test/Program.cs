using SmartLeopard.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLeopard.Client.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
            var api = new ApiHelper("http://localhost:1047/");
         //   var r = Task.Run(() => api.Public.CallhomeAsync(DeviceStatus.ShuttingDown, Guid.NewGuid().ToString(), "es-es")).Result;

         //   Console.WriteLine(r);
         var   r = Task.Run(() => api.Public.UpdateAsync()).Result;
            Console.WriteLine(r);
            var fr = Console.ReadKey();
            if (fr.KeyChar == 'r')
                Main(args);
        }
    }
}
