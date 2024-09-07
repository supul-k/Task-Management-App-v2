using Microsoft.EntityFrameworkCore;
using Task_Management_App_V2.DbAccess;
using Task_Management_App_V2.DTO;
using Task_Management_App_V2.Interfaces;
using Task_Management_App_V2.Models;

namespace Task_Management_App_V2.Respositories
{   
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<GeneralResponseInternalDTO> CreateUser(UserModel user)
        {
            try
            {
                _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return new GeneralResponseInternalDTO(true, "User Created");
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> FindUserByEmail(string email)
        {
            try
            {
                var result = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
                if (result == null)
                {
                    return new GeneralResponseInternalDTO(false, "Users not found");
                }

                return new GeneralResponseInternalDTO(true, "User found", result);
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }
    }
}
