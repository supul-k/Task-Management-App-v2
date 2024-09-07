using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Task_Management_App_V2.Models;

namespace Task_Management_App_V2.DTO
{
    public class AssignmentCreateDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public bool Status { get; set; }

        public string UserId { get; set; }
    }
}
