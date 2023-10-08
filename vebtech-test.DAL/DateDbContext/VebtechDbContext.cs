using Microsoft.EntityFrameworkCore;
using vebtech_test.DAL.Entities;

namespace vebtech_test.DAL.DateDbContext
{
    public class VebtechDbContext : DbContext
    {
        public VebtechDbContext(DbContextOptions<VebtechDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedData(modelBuilder);
        }
        private void SeedData(ModelBuilder modelBuilder)
        {
            var roles = new List<Role>
            {
               new Role { Id = new Guid("d80c8954-b524-4f3e-960a-7711fde800d8"), Name = "User" },
               new Role { Id = new Guid("42bd93a1-2704-4351-bace-ae9814b6e45d"), Name = "Admin" },
               new Role { Id = new Guid("ba96c858-bc06-463d-864e-d411836fc931"), Name = "Support" },
               new Role { Id = new Guid("c594c4db-11f6-49aa-84ce-d04c38eb56b0"), Name = "SuperAdmin" }
            };

            var users = new List<User>
            {
                new User { Id = new Guid("d80c8954-b524-4f3e-960a-7711fde800d8"), Name = "User1",         Age = 25, Email = "user1@example.com" },
                new User { Id = new Guid("42bd93a1-2704-4351-bace-ae9814b6e45d"), Name = "Admin1",        Age = 30, Email = "admin1@example.com" },
                new User { Id = new Guid("c594c4db-11f6-49aa-84ce-d04c38eb56b0"), Name = "SuperAdmin1",   Age = 35, Email = "superadmin1@example.com" }
            };

            var userRoles = new List<UserRole>
            {
                new UserRole { Id = Guid.NewGuid(), UserId = users[0].Id, RoleId = new Guid("d80c8954-b524-4f3e-960a-7711fde800d8") },
                new UserRole { Id = Guid.NewGuid(), UserId = users[1].Id, RoleId = new Guid("42bd93a1-2704-4351-bace-ae9814b6e45d") },
                new UserRole { Id = Guid.NewGuid(), UserId = users[1].Id, RoleId = new Guid("ba96c858-bc06-463d-864e-d411836fc931") },
                new UserRole { Id = Guid.NewGuid(), UserId = users[2].Id, RoleId = new Guid("c594c4db-11f6-49aa-84ce-d04c38eb56b0") }
            };

            modelBuilder.Entity<Role>().HasData(roles);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<UserRole>().HasData(userRoles);

        }
    }
}
