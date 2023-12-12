using ReserveRoverDAL.Entities;

namespace ReserveRoverDAL.Repositories.Abstract;

public interface IFriendshipRepository
{
    Task<Friendship> GetByIdAsync(int id);

    Task<int> GetCountByUser2Id(string user2Id, bool accepted = false);

    Task<int> GetCountByUserId(string userId, bool accepted = true);

    Task<IEnumerable<Friendship>> GetByUser2IdWithUser1(string user2Id, bool accepted = false);

    Task<IEnumerable<Friendship>> GetByUserIdWithUser(string userId, string? searchQuery, int pageNumber,
        int pageSize, bool accepted = true);

    Task InsertAsync(Friendship friendship);

    Task DeleteAsync(Friendship friendship);
}