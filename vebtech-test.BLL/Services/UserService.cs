using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Data;
using vebtech_test.BLL.Services.IServices;
using vebtech_test.BLL.Utilites.Exeptions;
using vebtech_test.BLL.Utilites.Extensions;
using vebtech_test.DAL.Entities;
using vebtech_test.DAL.Repositories.IRepositories;
using vebtech_test.DTO;

namespace vebtech_test.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;
        private readonly IUserRepository _userRepository;
        private readonly IGenericRepository<UserRole> _userRoleRepository;
        private readonly ILogger<UserService> _logger;
        public UserService(
            IUserRepository userRepository,
            IGenericRepository<UserRole> userRoleRepository,
            IRoleService roleService,
            IMapper mapper,
            ILogger<UserService> logger)
        {
            _mapper = mapper;
            _roleService = roleService;
            _userRoleRepository = userRoleRepository;
            _userRepository = userRepository;
            _logger = logger;
        }
        public void AddUser(UserToAddDTO userToAddDTO)
        {
            if (_userRepository.IsEmailExists(userToAddDTO.Email))
            {
                _logger.LogError("Email already exists");
                throw new InvalidOperationException("Email already exists");
            }

            if (!int.TryParse(userToAddDTO.Age, out int age) || age < 0)
            {
                _logger.LogError("Invalid age value");
                throw new ArgumentException("Invalid age value");
            }
            _logger.LogInformation("Add new user {0}", userToAddDTO.Name);
            _userRepository.Add(_mapper.Map<User>(userToAddDTO));   
        }
        public void AddUserRole(string userId, string roleId)
        {
            var user = GetUser(userId);
            var userRole = _mapper.Map<UserRole>(user);
            var role = _roleService.GetRole(roleId);
            userRole.RoleId = _mapper.Map<Role>(role).Id;
            userRole.UserId = new Guid(user.Id);
            _logger.LogInformation("User {0} adding with new role {1}", user.Name, role.Name);
            _userRoleRepository.Add(userRole);
        }

        public bool DeleteUser(string userId)
        {
            if (Guid.TryParse(userId,out var userIdGuid))
            {
                var userToDelete = _userRepository.GetById(userIdGuid);

                if (userToDelete is null)
                {
                    _logger.LogError("User is not found");
                    throw new UserNotFoundException(userIdGuid);
                }
                _logger.LogInformation("User {0} deleted", userToDelete.Id);
                _userRepository.Delete(userToDelete);
                return true;
            }
            return false; 
        }

        public UserDTO GetUser(string userId)
        {
            if (!Guid.TryParse(userId, out var userIdGuid))
            {
                _logger.LogError("Invalid userId format");
                throw new ArgumentException("Invalid userId format");
            }

            var user = _userRepository.GetById(userIdGuid);

            if (user == null)
            {
                _logger.LogError("User Not Found");
                throw new UserNotFoundException(userIdGuid);
            }

            var userRoles = _userRoleRepository.GetById(userIdGuid);
            var roles = _roleService.GetRoles();

            var role = roles.FirstOrDefault(r => r.Id == userRoles.RoleId.ToString());
            var userDto = _mapper.Map<UserDTO>(user);

            if (role != null)
            {
                userDto.Roles = new List<RoleDTO> { _mapper.Map<RoleDTO>(role) };
            }
            _logger.LogInformation("Get {0} user", userDto.Id);
            return userDto;
        }

        public IEnumerable<UserDTO> GetUsers(
            int page, 
            int pageSize, 
            string sortBy,
            string sortOrder, 
            string filterByName, 
            string filterByRole)
        {
            _logger.LogInformation("GetUsers {0} {1} {2} {3} {4} {5}", page, pageSize, sortBy, sortOrder, filterByName, filterByRole);
            var users = _userRepository.GetAll();
            var roles = _roleService.GetRoles();
            users = users.OrderByProperty(sortBy, sortOrder);
            var userRoles = _userRoleRepository.GetAll();
            _logger.LogInformation("gets {0} users", userRoles.Count());

            var pagedUsers = users
                .GroupJoin(userRoles, u => u.Id, ur => ur.User.Id, 
                    (u, urs) => new { User = u, UserRoles = urs }
                )
                .SelectMany(x => x.UserRoles.DefaultIfEmpty(), (x, ur) => new { User = x.User, UserRole = ur })
                .Where(x => (string.IsNullOrEmpty(filterByName) || 
                            x.User.Name.Contains(filterByName)) &&
                            (string.IsNullOrEmpty(filterByRole) || 
                            (x.UserRole != null                 && 
                            x.UserRole.Role != null             && 
                            x.UserRole.Role.Name.Contains(filterByRole))))
                .Select(x =>
                {
                    var userDTO = _mapper.Map<UserDTO>(x.User);

                    if (x.UserRole != null && x.UserRole.RoleId != null)
                    {
                        var role = roles.FirstOrDefault(r => r.Id == x.UserRole.RoleId.ToString());

                        if (role != null)
                        {
                            userDTO.Roles = new List<RoleDTO> { _mapper.Map<RoleDTO>(role) };
                        }
                    }

                    return userDTO;
                })
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            var result = _mapper.Map<List<UserDTO>>(pagedUsers);
            return result;
        }

        public UserDTO UpdateUser(UserToUpdateDTO userToUpdateDTO)
        {
            if (userToUpdateDTO == null)
            {
                _logger.LogError("ArgumentNullException");
                throw new ArgumentNullException(nameof(userToUpdateDTO));
            }

            if (!Guid.TryParse(userToUpdateDTO.Id, out var userIdGuid))
            {
                _logger.LogError("Invalid userId format");
                throw new ArgumentException("Invalid userId format");
            }

            var user = _userRepository.GetById(userIdGuid);
            if (userToUpdateDTO.Email != user.Email)
            {
                if (_userRepository.IsEmailExists(userToUpdateDTO.Email))
                {
                    _logger.LogError("Email already exists");
                    throw new InvalidOperationException("Email already exists");
                }
            }
            if (!string.IsNullOrEmpty(userToUpdateDTO.Age))
            {
                if (!int.TryParse(userToUpdateDTO.Age, out int age) || age < 0)
                {
                    _logger.LogError("Invalid age value");
                    throw new ArgumentException("Invalid age value");
                }
                user.Age = age;
            }
            user.Name = !string.IsNullOrEmpty(userToUpdateDTO.Name) ? userToUpdateDTO.Name : user.Name;
            user.Email = !string.IsNullOrEmpty(userToUpdateDTO.Email) ? userToUpdateDTO.Email : user.Email;

            _userRepository.Update(user);
            _logger.LogInformation("user {0} update", user.Id);
            return _mapper.Map<UserDTO>(user);
        }
    }
}
