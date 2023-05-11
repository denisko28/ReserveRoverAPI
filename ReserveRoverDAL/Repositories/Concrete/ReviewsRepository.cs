using Microsoft.EntityFrameworkCore;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Repositories.Abstract;

namespace ReserveRoverDAL.Repositories.Concrete;

public class ReviewsRepository : IReviewsRepository
{
    private readonly DbSet<Review> _reviews;

    public ReviewsRepository(ReserveRoverDbContext dbContext)
    {
        _reviews = dbContext.Set<Review>();
    }

    public async Task<IEnumerable<Review>> GetByPlaceAsync(int placeId, int pageNumber, int pageSize)
    {
        return await _reviews
            .Where(p => p.PlaceId == placeId)
            .OrderByDescending(p => p.CreationDate).Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task InsertAsync(Review review)
    {
        await _reviews.AddAsync(review);
    }
}