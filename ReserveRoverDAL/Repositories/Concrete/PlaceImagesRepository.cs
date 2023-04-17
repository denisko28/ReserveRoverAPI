using Microsoft.EntityFrameworkCore;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Exceptions;
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

    public async Task UpdateAsync(PlaceImage placeImage)
    {
        await Task.Run(() => _placeImages.Update(placeImage));
    }

    public async Task DeleteAsync(int placeId, short sequenceIndex)
    {
        var entity = await _placeImages.FirstOrDefaultAsync(place => place.PlaceId == placeId && place.SequenceIndex == sequenceIndex);
        
        if(entity == null)
            throw new EntityNotFoundException(nameof(PlaceImage), $"placeId: {placeId} & sequenceIndex: {sequenceIndex}");
        
        await Task.Run(() => _placeImages.Remove(entity));
    }
}