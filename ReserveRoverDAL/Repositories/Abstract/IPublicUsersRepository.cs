using ReserveRoverDAL.Entities;

namespace ReserveRoverDAL.Repositories.Abstract;

public interface IPublicUsersRepository : IGenericRepository<PublicUser>
{
    Task<IEnumerable<PublicUser>> GetAsyncWithoutFriends(string? searchQuery, string thisUserId,
        int pageNumber, int pageSize);
}