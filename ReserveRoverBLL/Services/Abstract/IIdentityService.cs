using ReserveRoverBLL.DTO.Requests;

namespace ReserveRoverBLL.Services.Abstract;

public interface IIdentityService
{
    Task<bool> RegisterUser(RegisterUserRequest userRequest, string userRole);
}