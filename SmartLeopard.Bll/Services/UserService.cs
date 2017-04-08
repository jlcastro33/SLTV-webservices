using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartLeopard.Dal.Entities;
using SmartLeopard.Dal.Framework;

namespace SmartLeopard.Bll.Services
{
    public class UserService: DataService<User>
    {
        public UserService(IRepository<User> repository) : base(repository)
        {
        }
    }
}
