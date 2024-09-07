using System.ComponentModel.DataAnnotations;

namespace Task_Management_App_V2.DTO
{
    public class UserLoginDTO
    {
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
