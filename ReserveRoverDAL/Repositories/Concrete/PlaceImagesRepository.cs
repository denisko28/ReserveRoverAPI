using Microsoft.EntityFrameworkCore;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Repositories.Abstract;

namespace ReserveRoverDAL.Repositories.Concrete;

public class PlaceImagesRepository : IPlaceImagesRepository
{
    private readonly DbSet<PlaceImage> _placeImages;

    public PlaceImagesRepository(ReserveRoverDbContext dbContext)
    {
        _placeImages = dbContext.Set<PlaceImage>();
    }

    public async Task<IEnumerable<PlaceImage>> GetAsync(int placeId)
    {
        return await _placeImages
            .Where(image => image.PlaceId == placeId)
            .OrderBy(image => image.SequenceIndex)
            .ToListAsync();
    }

    public async Task InsertAsync(PlaceImage placeImage)
    {
        placeImage.PlaceId = 0;
        await _placeImages.AddAsync(placeImage);
    }

    public async Task InsertRangeAsync(IEnumerable<PlaceImage> placeImages)
    {
        await _placeImages.AddRangeAsync(placeImages);
    }

    public async Task DeleteByPlaceAsync(int placeId)
    {
        var entitiesToRemove = _placeImages.Where(e => e.PlaceId == placeId);
        await Task.Run(() => _placeImages.RemoveRange(entitiesToRemove));
    }
}