using ReserveRoverDAL.Entities;

namespace ReserveRoverDAL.Repositories.Abstract;

public interface IReviewsRepository
{
    Task<IEnumerable<Review>> GetByPlaceAsync(int placeId, int pageNumber, int pageSize);

    Task InsertAsync(Review review);
}