using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vebtech_test.DTO
{
    public class UserToUpdateDTO
    {
        [Required(ErrorMessage = "Id required")]
        [RegularExpression("^[0-9A-Fa-f]{8}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{12}$", ErrorMessage = "Invalid GUID format")]
        public string Id { get; set; }
        public string Name { get; set; }
        [RegularExpression(@"^\d+$", ErrorMessage = "Age is not a number")]
        [Range(0, int.MaxValue, ErrorMessage = "Age must be a positive number")]
        public string Age { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
    }
}
