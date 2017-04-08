using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartLeopard.Dal.Entities;

namespace SmartLeopard.Dal.Repositories
{
    public class DeviceRepository: Repository<Device>
    {
        public DeviceRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<Device> GetAsync(string mac)
        {
            return await DbSet.FirstOrDefaultAsync(d => d.Mac == mac);
        }
    }
}
