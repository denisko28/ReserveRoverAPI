using Microsoft.AspNetCore.Http;
using ReserveRoverBLL.DTO.Requests;
using ReserveRoverBLL.DTO.Responses;

namespace ReserveRoverBLL.Services.Abstract;

public interface IFriendsService
{
    Task<IEnumerable<PublicUserResponse>> SearchForNew(SearchForFriendsRequest request,
        HttpContext httpContext);

    Task<IEnumerable<FriendshipResponse>> GetFriendships(SearchForFriendsRequest request, HttpContext httpContext);

    Task<IEnumerable<FriendshipResponse>> GetFriendshipRequests(HttpContext httpContext);

    Task AddFriend(string friendUserId, HttpContext httpContext);

    Task AcceptFriendship(int friendshipId, HttpContext httpContext);

    Task DeleteFriendship(int friendshipId, HttpContext httpContext);
    Task<FriendsCountResponse> GetCount(HttpContext httpContext);
}