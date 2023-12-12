using Microsoft.AspNetCore.SignalR;
using ReserveRoverBLL.DTO.Requests;
using ReserveRoverBLL.Services.Abstract;

namespace ReserveRoverBLL.Services.Concrete;

public class ChatService : IChatService
{
    public async Task SendMessage(SendMessageRequest request, HubCallerContext hubCallerContext,
        IHubCallerClients clients)
    {
        var senderId = hubCallerContext.User?.Identities.FirstOrDefault()?.Claims
            .FirstOrDefault(o => o.Type == "id")?.Value;
        await clients.User(request.ToUserId).SendAsync("ReceiveMessage", new {request.Message, senderId});
    }
}