using ReserveRoverDAL.Repositories.Abstract;
using ReserveRoverDAL.UnitOfWork.Abstract;

namespace ReserveRoverDAL.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public ReserveRoverDbContext DbContext { get; }

        public IPlacesRepository PlacesRepository { get; }

        public IPlaceImagesRepository PlaceImagesRepository { get; }

        public IPlacesPaymentMethodsRepository PlacesPaymentMethodsRepository { get; }

        public ILocationsRepository LocationsRepository { get; }

        public ITableSetsRepository TableSetsRepository { get; }

        public IModerationRepository ModerationRepository { get; }

        public IReservationsRepository ReservationsRepository { get; }

        public IReviewsRepository ReviewsRepository { get; }

        public ICitiesRepository CitiesRepository { get; }

        public IPublicUsersRepository PublicUsersRepository { get; }

        public IFriendshipRepository FriendshipRepository { get; }

        public UnitOfWork(ReserveRoverDbContext dbContext, IPlacesRepository placesRepository,
            IPlaceImagesRepository placeImagesRepository,
            IPlacesPaymentMethodsRepository placesPaymentMethodsRepository, ILocationsRepository locationsRepository,
            ITableSetsRepository tableSetsRepository, IModerationRepository moderationRepository,
            IReservationsRepository reservationsRepository, IReviewsRepository reviewsRepository,
            ICitiesRepository citiesRepository, IPublicUsersRepository publicUsersRepository,
            IFriendshipRepository friendshipRepository)
        {
            DbContext = dbContext;
            PlacesRepository = placesRepository;
            PlaceImagesRepository = placeImagesRepository;
            PlacesPaymentMethodsRepository = placesPaymentMethodsRepository;
            LocationsRepository = locationsRepository;
            TableSetsRepository = tableSetsRepository;
            ModerationRepository = moderationRepository;
            ReservationsRepository = reservationsRepository;
            ReviewsRepository = reviewsRepository;
            CitiesRepository = citiesRepository;
            PublicUsersRepository = publicUsersRepository;
            FriendshipRepository = friendshipRepository;
        }

        public async Task SaveChangesAsync()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}