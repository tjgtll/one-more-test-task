using vebtech_test.DAL.Entities.Base;

namespace vebtech_test.DAL.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public List<UserRole> UserRoles { get; } = new();
    }
}
