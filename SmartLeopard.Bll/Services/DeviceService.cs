using SmartLeopard.Dal.Entities;
using SmartLeopard.Dal.Framework;

namespace SmartLeopard.Bll.Services
{
    public class DeviceService : DataService<Device>
    {
        public DeviceService(IRepository<Device> repository) : base(repository)
        {
        }
    }
}
