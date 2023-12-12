using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using ReserveRoverBLL.DTO.Requests;
using ReserveRoverBLL.Services.Abstract;

namespace ReserveRoverAPI.Hubs;

public class ChatHub : Hub
{
    private readonly IChatService _chatService;

    public ChatHub(IChatService chatService)
    {
        _chatService = chatService;
    }

    [Authorize]
    public async Task SendMessage(SendMessageRequest request)
    {
        await _chatService.SendMessage(request, Context, Clients);
    }
}