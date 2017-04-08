using System.Threading.Tasks;
using SmartLeopard.Dal.Entities;
using SmartLeopard.Dal.Framework;
using SmartLeopard.Dal.Repositories;

namespace SmartLeopard.Bll.Services
{
    public class DeviceService : DataService<Device>
    {
        public DeviceService(IRepository<Device> repository) : base(repository)
        {
        }

        public async Task<Device> GetAsync(string mac)
        {
            return await ((DeviceRepository)Repository).GetAsync(mac);
        }

        public async Task<bool> OldVersion(Device device)
        {
            return false;   
        }
    }
}
