using Task_Management_App_V2.DTO;
using Task_Management_App_V2.Models;

namespace Task_Management_App_V2.Interfaces
{
    public interface IJwtService
    {
        public Task<GeneralResponseInternalDTO> GenerateJwt(UserModel user);
    }
}
