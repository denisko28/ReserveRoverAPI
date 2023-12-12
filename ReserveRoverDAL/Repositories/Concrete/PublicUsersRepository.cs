using Microsoft.EntityFrameworkCore;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Repositories.Abstract;

namespace ReserveRoverDAL.Repositories.Concrete;

public class PublicUsersRepository : GenericRepository<PublicUser>, IPublicUsersRepository
{
    public PublicUsersRepository(ReserveRoverDbContext dBContext) : base(dBContext)
    {
    }

    public async Task<IEnumerable<PublicUser>> GetAsyncWithoutFriends(string? searchQuery, string thisUserId, 
        int pageNumber, int pageSize)
    {
        IQueryable<PublicUser> publicUsers = Table
            .Include(user => user.FriendshipsUser1)
            .Include(user => user.FriendshipsUser2)
            .Where(user => 
            user.FriendshipsUser1.All(friend => friend.User2Id != thisUserId) && 
            user.FriendshipsUser2.All(friend => friend.User1Id != thisUserId) &&
            user.Id != thisUserId);

        if (!string.IsNullOrEmpty(searchQuery))
        {
            searchQuery = searchQuery.ToLower();
            var words = searchQuery.Split(' ');
            if (words.Length >= 2)
                publicUsers = publicUsers.Where(p =>
                    EF.Functions.Like(p.FirstName.ToLower(), words[0] + "%") ||
                    EF.Functions.Like(p.LastName.ToLower(), words[1] + "%") ||
                    EF.Functions.Like(p.FirstName.ToLower(), words[1] + "%") ||
                    EF.Functions.Like(p.LastName.ToLower(), words[0] + "%"));
            else if (words.Length == 1)
                publicUsers = publicUsers.Where(p =>
                    EF.Functions.Like(p.FirstName.ToLower(), words[0] + "%") ||
                    EF.Functions.Like(p.LastName.ToLower(), words[0] + "%"));
        }

        return await publicUsers.Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
}