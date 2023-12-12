using Microsoft.AspNetCore.SignalR;

namespace ReserveRoverBLL.Helpers;

public class CustomUserIdProvider : IUserIdProvider
{
    public string? GetUserId(HubConnectionContext connection)
    {
        return connection.User?.Identities.FirstOrDefault()?.Claims
            .FirstOrDefault(o => o.Type == "id")?.Value;
    }
}