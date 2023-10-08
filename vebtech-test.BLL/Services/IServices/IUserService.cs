using vebtech_test.DTO;

namespace vebtech_test.BLL.Services.IServices
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetUsers(int page, int pageSize, string sortBy, string sortOrder, string filterByName, string filterByRole);
        UserDTO GetUser(string userId);
        void AddUser(UserToAddDTO userToAddDTO);
        void AddUserRole(string userId,string roleId);
        UserDTO UpdateUser(UserToUpdateDTO userToUpdateDTO);
        bool DeleteUser(string userId);
    }
}
