using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Task_Management_App_V2.DTO
{
    public class UserCreateDTO
    {
        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Role { get; set; }

        public string Password { get; set; }
    }
}
