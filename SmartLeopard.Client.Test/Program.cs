using SmartLeopard.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartLeopard.Models;

namespace SmartLeopard.Client.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
            var api = new ApiHelper("http://localhost:1047/");
            var rh = Task.Run(() => api.Public.CallhomeAsync(DeviceStatus.ShuttingDown, Guid.NewGuid().ToString(), "es-es")).Result;

           Console.WriteLine(rh);
         var   r = Task.Run(() => api.Account.Register(new RegistryModel { })).Result;
            Console.WriteLine(r);
            var fr = Console.ReadKey();
            if (fr.KeyChar == 'r')
                Main(args);
        }
    }
}
