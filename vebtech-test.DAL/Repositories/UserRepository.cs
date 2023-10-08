using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vebtech_test.DAL.DateDbContext;
using vebtech_test.DAL.Entities;
using vebtech_test.DAL.Repositories.IRepositories;

namespace vebtech_test.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(VebtechDbContext dbContext) : base(dbContext)
        {
        }

        public User GetByEmail(string email)
        {
            return _dbSet.SingleOrDefault(u => u.Email == email);
        }

        public bool IsEmailExists(string email)
        {
            return _dbSet.Any(u => u.Email == email);
        }
    }
}
