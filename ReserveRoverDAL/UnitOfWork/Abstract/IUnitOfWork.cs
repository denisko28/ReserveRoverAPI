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
        
        ITableSetsRepository TableSetsRepository { get; }
        
        IModerationRepository ModerationRepository { get; }
        
        IReservationsRepository ReservationsRepository { get; }
        
        IReviewsRepository ReviewsRepository { get; }
        
        ICitiesRepository CitiesRepository { get; }
        
        IPublicUsersRepository PublicUsersRepository { get; }
        
        IFriendshipRepository FriendshipRepository { get; }

        Task SaveChangesAsync();
    }
}