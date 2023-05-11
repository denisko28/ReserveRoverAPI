using FirebaseAdmin.Auth;
using ReserveRoverBLL.DTO.Requests;

namespace ReserveRoverBLL.Services.Abstract;

public interface IIdentityService
{
    Task<UserRecord> GetUserById(string uid);
    
    Task<GetUsersResult> GetUsersById(IReadOnlyCollection<UserIdentifier> uid);
    
    Task<bool> RegisterUser(RegisterUserRequest userRequest, string userRole);
}