using ReserveRoverDAL.Repositories.Abstract;

namespace ReserveRoverDAL.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        ReserveRoverDbContext DbContext { get; }
        
        IPlacesRepository PlacesRepository { get; }
        
        IPlaceImagesRepository PlaceImagesRepository { get; }
        
        IPlacesPaymentMethodsRepository PlacesPaymentMethodsRepository { get; }
        
        ILocationsRepository LocationsRepository { get; }
        
        ITablesRepository TablesRepository { get; }
        
        IModerationRepository ModerationRepository { get; }

        Task SaveChangesAsync();
    }
}