using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace ReserveRoverBLL.Helpers;

public class UserClaimsHelper
{
    public static string GetUserId(HttpContext httpContext)
    {
        if (httpContext.User.Identity is not ClaimsIdentity identity) 
            return "";
            
        var userId = identity.Claims
            .FirstOrDefault(o => o.Type == "id")?.Value;
    
        if (userId == null)
            throw new Exception("Proper UserId claim wasn't found");
    
        return userId;
    }
}