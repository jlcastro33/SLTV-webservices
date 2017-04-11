using System.Threading.Tasks;
using SmartLeopard.Dal.Entities;
using SmartLeopard.Dal.Framework;
using SmartLeopard.Dal.Repositories;

namespace SmartLeopard.Bll.Services
{
    public class DeviceService : DataService<Device>
    {
        private readonly DeviceRepository _repository;

        public DeviceService(DeviceRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<Device> GetAsync(string mac)
        {
            return await _repository.GetAsync(mac);
        }

        public async Task<bool> OldVersion(Device device)
        {
            return false;   
        }
    }
}
