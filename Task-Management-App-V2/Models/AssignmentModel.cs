using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Task_Management_App_V2.Models
{
    public class AssignmentModel
    {
        [Key]
        [Column("AssignmentId", TypeName ="nvarchar(100)")]
        public string Id { get; set; }

        [Column("Name", TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column("Description", TypeName = "nvarchar(450)")]
        public string Description { get; set; }

        [Column("DueDate")]
        public DateTime DueDate { get; set; }

        [Column("Status")]
        public bool Status { get; set; }

        public string UserId { get; set; }
        public UserModel Users { get; set; }        
    }
}
