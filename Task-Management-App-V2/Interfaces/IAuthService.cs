using Task_Management_App_V2.DTO;
using Task_Management_App_V2.Models;

namespace Task_Management_App_V2.Interfaces
{
    public interface IAuthService
    {
        public Task<GeneralResponseInternalDTO> CreateUser(UserModel user);
    }
}
