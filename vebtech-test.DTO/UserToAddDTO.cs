using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vebtech_test.DTO
{
    public class UserToAddDTO
    {
        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Age required")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Age is not a number")]
        [Range(0, int.MaxValue, ErrorMessage = "Age must be a positive number")]
        public string Age { get; set; }
        [Required(ErrorMessage = "Email required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
    }
}
