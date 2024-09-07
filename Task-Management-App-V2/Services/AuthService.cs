using Task_Management_App_V2.DTO;
using Task_Management_App_V2.Interfaces;
using Task_Management_App_V2.Models;

namespace Task_Management_App_V2.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<GeneralResponseInternalDTO> CreateUser(UserModel user)
        {
            try
            {
                var result = await _authRepository.CreateUser(user);
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }
    }
}
