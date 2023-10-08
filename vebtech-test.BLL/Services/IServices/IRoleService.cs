using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vebtech_test.DTO;

namespace vebtech_test.BLL.Services.IServices
{
    public interface IRoleService
    {
        List<RoleDTO> GetRoles();
        RoleDTO GetRole(string roleId);
        void AddRole(RoleToAddDTO roleToAddDTO);
    }
}
