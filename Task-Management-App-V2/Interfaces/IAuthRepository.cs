using Task_Management_App_V2.DTO;
using Task_Management_App_V2.Models;

namespace Task_Management_App_V2.Interfaces
{
    public interface IAuthRepository
    {
        public Task<GeneralResponseInternalDTO> CreateUser(UserModel user);

        public Task<GeneralResponseInternalDTO> FindUserByEmail(string email);
    }
}
