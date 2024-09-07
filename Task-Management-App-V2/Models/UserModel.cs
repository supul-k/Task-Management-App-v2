using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Task_Management_App_V2.Models
{
    public class UserModel
    {
        [Key]
        [Column("UserId", TypeName ="nvarchar(100)")]
        public string UserId { get; set; }

        [Column("UserName", TypeName = "nvarchar(100)")]
        public string UserName { get; set; }

        [EmailAddress]
        [Column("Email", TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        [Column("Role", TypeName = "nvarchar(100)")]
        public string Role { get; set; }

        [Required]
        [Column("PasswordHash", TypeName = "nvarchar(450)")]
        public string PasswordHash { get; set; }

        public ICollection<AssignmentModel> Assignments { get; }
    }
}
