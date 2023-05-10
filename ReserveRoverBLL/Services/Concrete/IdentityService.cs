using Firebase.Auth;
using ReserveRoverBLL.DTO.Requests;
using ReserveRoverBLL.Services.Abstract;

namespace ReserveRoverBLL.Services.Concrete;

public class IdentityService : IIdentityService
{
    private readonly FirebaseAuthProvider _authProvider;

    public IdentityService(FirebaseAuthProvider authProvider)
    {
        _authProvider = authProvider;
    }

    public async Task<bool> RegisterUser(RegisterUserRequest userRequest, string userRole)
    {
        var link = await _authProvider.CreateUserWithEmailAndPasswordAsync(userRequest.Email, userRequest.Password);
        var claims = new Dictionary<string, object>()
        {
            { "role", userRole }
        };
        await FirebaseAdmin.Auth.FirebaseAuth.DefaultInstance.SetCustomUserClaimsAsync(link.User.LocalId, claims);
        await _authProvider.SendEmailVerificationAsync(link);
        return true;
    }
}