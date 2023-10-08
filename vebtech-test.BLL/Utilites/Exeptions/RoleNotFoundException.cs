using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vebtech_test.DAL.Entities;

namespace vebtech_test.BLL.Utilites.Exeptions
{
    public class RoleNotFoundException : Exception
    {
        public Guid RoleId { get; }

        public RoleNotFoundException()
        {
        }

        public RoleNotFoundException(Guid roleId)
        {
            RoleId = roleId;
            
        }
        public RoleNotFoundException(string message)
            : base(message)
        {
            message += RoleId.ToString();
        }

        public RoleNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
            message += RoleId.ToString();
        }
    }
}
