using AutoMapper;
using Microsoft.AspNetCore.Http;
using ReserveRoverBLL.DTO.Requests;
using ReserveRoverBLL.DTO.Responses;
using ReserveRoverBLL.Exceptions;
using ReserveRoverBLL.Helpers;
using ReserveRoverBLL.Services.Abstract;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.UnitOfWork.Abstract;

namespace ReserveRoverBLL.Services.Concrete;

public class FriendsService : IFriendsService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FriendsService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PublicUserResponse>> SearchForNew(SearchForFriendsRequest request, 
        HttpContext httpContext)
    {
        var currentUserId = UserClaimsHelper.GetUserId(httpContext);
        var publicUsers =
            await _unitOfWork.PublicUsersRepository.GetAsyncWithoutFriends(request.searchQuery, currentUserId,
                request.PageNumber, request.PageSize);
        return publicUsers.Select(_mapper.Map<PublicUser, PublicUserResponse>);
    }

    public async Task<IEnumerable<FriendshipResponse>> GetFriendships(SearchForFriendsRequest request,
        HttpContext httpContext)
    {
        var currentUserId = UserClaimsHelper.GetUserId(httpContext);
        var friendships = await _unitOfWork.FriendshipRepository.GetByUserIdWithUser(currentUserId,
            request.searchQuery, request.PageNumber, request.PageSize);
        return friendships.Select(friendship =>
        {
            if (friendship.User1Id == currentUserId)
                return new FriendshipResponse
                {
                    Id = friendship.Id,
                    FirstName = friendship.User2.FirstName,
                    LastName = friendship.User2.LastName,
                    Avatar = friendship.User2.Avatar,
                    FriendId = friendship.User2.Id,
                };
            return new FriendshipResponse
            {
                Id = friendship.Id,
                FirstName = friendship.User1.FirstName,
                LastName = friendship.User1.LastName,
                Avatar = friendship.User1.Avatar,
                FriendId = friendship.User1.Id,
            };
        });
    }

    public async Task<IEnumerable<FriendshipResponse>> GetFriendshipRequests(HttpContext httpContext)
    {
        var currentUserId = UserClaimsHelper.GetUserId(httpContext);
        var friendships = await _unitOfWork.FriendshipRepository.GetByUser2IdWithUser1(currentUserId);
        return friendships.Select(friendship => new FriendshipResponse
        {
            Id = friendship.Id,
            FirstName = friendship.User1.FirstName,
            LastName = friendship.User1.LastName,
            Avatar = friendship.User1.Avatar,
            FriendId = friendship.User1.Id,
        });
    }

    public async Task AddFriend(string friendUserId, HttpContext httpContext)
    {
        var currentUserId = UserClaimsHelper.GetUserId(httpContext);
        await _unitOfWork.FriendshipRepository.InsertAsync(new Friendship
        {
            User1Id = currentUserId, User2Id = friendUserId, RequestedDateTime = DateTime.Now, Accepted = false
        });
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task AcceptFriendship(int friendshipId, HttpContext httpContext)
    {
        var currentUserId = UserClaimsHelper.GetUserId(httpContext);
        var friendship = await _unitOfWork.FriendshipRepository.GetByIdAsync(friendshipId);
        if (friendship.User2Id != currentUserId)
            throw new ForbiddenAccessException("You don't have access to the accept this friendship");

        friendship.Accepted = true;
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteFriendship(int friendshipId, HttpContext httpContext)
    {
        var currentUserId = UserClaimsHelper.GetUserId(httpContext);
        var friendship = await _unitOfWork.FriendshipRepository.GetByIdAsync(friendshipId);
        if (friendship.User1Id != currentUserId && friendship.User2Id != currentUserId)
            if (friendship.User2Id != currentUserId)
                throw new ForbiddenAccessException("You don't have access to the delete this friendship");

        await _unitOfWork.FriendshipRepository.DeleteAsync(friendship);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<FriendsCountResponse> GetCount(HttpContext httpContext)
    {
        var currentUserId = UserClaimsHelper.GetUserId(httpContext);
        var friendsCount = await _unitOfWork.FriendshipRepository.GetCountByUserId(currentUserId);
        var requestsCount = await _unitOfWork.FriendshipRepository.GetCountByUser2Id(currentUserId);
        return new FriendsCountResponse {FriendsCount = friendsCount, RequestsCount = requestsCount};
    }
}