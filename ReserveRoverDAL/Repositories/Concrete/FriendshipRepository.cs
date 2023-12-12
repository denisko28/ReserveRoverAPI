using Microsoft.EntityFrameworkCore;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Exceptions;
using ReserveRoverDAL.Repositories.Abstract;

namespace ReserveRoverDAL.Repositories.Concrete;

public class FriendshipRepository : IFriendshipRepository
{
    private readonly DbSet<Friendship> _friendships;

    public FriendshipRepository(ReserveRoverDbContext dbContext)
    {
        _friendships = dbContext.Set<Friendship>();
    }

    public async Task<Friendship> GetByIdAsync(int id)
    {
        return await _friendships.FindAsync(id)
               ?? throw new EntityNotFoundException(nameof(Friendship), id);
    }
    
    public async Task<int> GetCountByUser2Id(string user2Id, bool accepted = false)
    {
        return await _friendships.Where(friendship => friendship.User2Id == user2Id && friendship.Accepted == accepted)
            .CountAsync();
    }

    public async Task<int> GetCountByUserId(string userId, bool accepted = true)
    {
        return await _friendships
            .Where(friendship => (friendship.User1Id == userId || friendship.User2Id == userId) &&
                                 friendship.Accepted == accepted).CountAsync();
    }

    public async Task<IEnumerable<Friendship>> GetByUser2IdWithUser1(string user2Id, bool accepted = false)
    {
        return await _friendships.Include(friendship => friendship.User1)
            .Where(friendship => friendship.User2Id == user2Id && friendship.Accepted == accepted).ToListAsync();
    }

    public async Task<IEnumerable<Friendship>> GetByUserIdWithUser(string userId, string? searchQuery, int pageNumber,
        int pageSize, bool accepted = true)
    {
        var friendships = _friendships
            .Include(friendship => friendship.User1)
            .Include(friendship => friendship.User2)
            .Where(friendship => (friendship.User1Id == userId || friendship.User2Id == userId) &&
                                 friendship.Accepted == accepted);

        if (!string.IsNullOrEmpty(searchQuery))
        {
            searchQuery = searchQuery.ToLower();
            var words = searchQuery.Split(' ');
            if (words.Length >= 2)
                friendships = friendships.Where(p =>
                    (p.User1Id != userId && (EF.Functions.Like(p.User1.FirstName.ToLower(), words[0] + "%") ||
                                             EF.Functions.Like(p.User1.LastName.ToLower(), words[1] + "%") ||
                                             EF.Functions.Like(p.User1.FirstName.ToLower(), words[1] + "%") ||
                                             EF.Functions.Like(p.User1.LastName.ToLower(), words[0] + "%"))) ||
                    (p.User2Id != userId && (EF.Functions.Like(p.User2.FirstName.ToLower(), words[0] + "%") ||
                                             EF.Functions.Like(p.User2.LastName.ToLower(), words[1] + "%") ||
                                             EF.Functions.Like(p.User2.FirstName.ToLower(), words[1] + "%") ||
                                             EF.Functions.Like(p.User2.LastName.ToLower(), words[0] + "%"))));
            else if (words.Length == 1)
                friendships = friendships.Where(p =>
                    (p.User1Id != userId && (EF.Functions.Like(p.User1.FirstName.ToLower(), words[0] + "%") ||
                                             EF.Functions.Like(p.User1.LastName.ToLower(), words[0] + "%"))) ||
                    (p.User2Id != userId && (EF.Functions.Like(p.User2.FirstName.ToLower(), words[0] + "%") ||
                                             EF.Functions.Like(p.User2.LastName.ToLower(), words[0] + "%"))));
        }

        return await friendships.Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task InsertAsync(Friendship friendship)
    {
        await Task.Run(() => _friendships.Add(friendship));
    }

    public async Task DeleteAsync(Friendship friendship)
    {
        await Task.Run(() => _friendships.Remove(friendship));
    }
}