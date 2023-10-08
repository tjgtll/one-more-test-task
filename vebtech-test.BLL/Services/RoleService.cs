using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vebtech_test.BLL.Services.IServices;
using vebtech_test.BLL.Utilites.Exeptions;
using vebtech_test.DAL.Entities;
using vebtech_test.DAL.Repositories;
using vebtech_test.DAL.Repositories.IRepositories;
using vebtech_test.DTO;

namespace vebtech_test.BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Role> _roleRepository;
        private readonly ILogger<RoleService> _logger;

        public RoleService(IGenericRepository<Role> roleRepository, IMapper mapper, ILogger<RoleService> logger)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
            _logger = logger;
        }

        public void AddRole(RoleToAddDTO roleToAddDTO)
        {
            _roleRepository.Add(_mapper.Map<Role>(roleToAddDTO));
            _logger.LogInformation("Add new role {0}", roleToAddDTO.Name);
        }

        public RoleDTO GetRole(string roleId)
        {
            Guid.TryParse(roleId, out var roleIdGuid);

            var role = _roleRepository.GetById(roleIdGuid);

            if (role == null)
            {
                _logger.LogInformation("Role not found {0}", roleId);
                throw new RoleNotFoundException(roleIdGuid);
            }
            var roleDTO = _mapper.Map<RoleDTO>(role);

            return roleDTO;
        }

        public List<RoleDTO> GetRoles()
        {
            var result = _roleRepository.GetAll();
            _logger.LogInformation("Gets {0} roles", result.Count());
            return _mapper.Map<List<RoleDTO>>(result);
        }
    }
}
