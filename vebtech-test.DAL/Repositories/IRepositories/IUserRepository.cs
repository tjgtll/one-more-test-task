using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vebtech_test.DAL.Entities;

namespace vebtech_test.DAL.Repositories.IRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetByEmail(string email);
        bool IsEmailExists(string email);
    }
}
