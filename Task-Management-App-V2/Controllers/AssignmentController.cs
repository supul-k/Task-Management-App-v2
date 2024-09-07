using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_Management_App_V2.DbAccess;
using Task_Management_App_V2.DTO;
using Task_Management_App_V2.Models;

namespace Task_Management_App_V2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AssignmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AssignmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("create-assignemt", Name ="CreateAssignment")]
        [Authorize(Roles ="Manager")]
        public async Task<IActionResult> CreateAssignment([FromBody] AssignmentCreateDTO request)
        {
            try
            {
                AssignmentModel assignment = new AssignmentModel();
                assignment.Id = Guid.NewGuid().ToString();
                assignment.Name = request.Name;
                assignment.Description = request.Description;
                assignment.DueDate = request.DueDate;
                assignment.Status = request.Status;
                assignment.UserId = request.UserId;

                _context.AddAsync(assignment);
                await _context.SaveChangesAsync();

                return Ok(assignment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-assignment/{assignmentId}", Name ="GetAssignment")]
        public async Task<IActionResult> GetAssignment(string assignmentId)
        {
            try
            {
                var result = await _context.Assignments.FindAsync(assignmentId);

                if (result == null)
                {
                    return BadRequest("Assignment Not Found");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-assignments", Name = "GetAssignments")]
        public async Task<IActionResult> GetAssignments()
        {
            try
            {
                var result = await _context.Assignments.ToListAsync();

                if (result == null)
                {
                    return BadRequest("Assignments Not Found");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("delete-assignment/{assignmentId}", Name = "DeleteAssignment")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> DeleteAssignment(string assignmentId)
        {
            try
            {
                var result = await _context.Assignments.FindAsync(assignmentId);

                if (result == null)
                {
                    return BadRequest("Assignment Not Found");
                }

                AssignmentModel assignment = result as AssignmentModel;

                _context.Assignments.Remove(assignment);
                await _context.SaveChangesAsync();

                return Ok("Assignment Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("update-assignment/{assignmentId}", Name = "UpdateAssignment")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> UpdateAssignment(string assignmentId, [FromBody] AssignmentCreateDTO request)
        {
            try
            {
                var result = await _context.Assignments.FindAsync(assignmentId);

                if (result == null)
                {
                    return BadRequest("Assignment Not Found");
                }

                AssignmentModel assignment = result as AssignmentModel;
                if (!string.IsNullOrEmpty(request.Name)) assignment.Name = request.Name;
                if (!string.IsNullOrEmpty(request.Description)) assignment.Description = request.Description;
                if (!string.IsNullOrEmpty(request.UserId)) assignment.UserId = request.UserId;
                if (!(request.DueDate == null)) assignment.DueDate = request.DueDate;
                if (!(request.Status == null)) assignment.Status = request.Status;


                _context.Assignments.Update(assignment);
                await _context.SaveChangesAsync();

                return Ok("Assignment Updated Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
