using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using ReserveRoverBLL.DTO.Requests;

namespace ReserveRoverBLL.Services.Abstract;

public interface IChatService
{
    Task SendMessage(SendMessageRequest request, HubCallerContext hubCallerContext, IHubCallerClients clients);
}