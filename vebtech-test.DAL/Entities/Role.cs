using vebtech_test.DAL.Entities.Base;

namespace vebtech_test.DAL.Entities
{
    public class Role:BaseEntity
    {
        public string Name { get; set; }

        public List<UserRole> UserRoles { get; } = new();
    }
}
