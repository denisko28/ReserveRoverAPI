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
        
        public ITablesRepository TablesRepository { get; }
        
        public IModerationRepository ModerationRepository { get; }

        public UnitOfWork(ReserveRoverDbContext dbContext, IPlacesRepository placesRepository,
            IPlaceImagesRepository placeImagesRepository,
            IPlacesPaymentMethodsRepository placesPaymentMethodsRepository, ILocationsRepository locationsRepository, ITablesRepository tablesRepository, IModerationRepository moderationRepository)
        {
            DbContext = dbContext;
            PlacesRepository = placesRepository;
            PlaceImagesRepository = placeImagesRepository;
            PlacesPaymentMethodsRepository = placesPaymentMethodsRepository;
            LocationsRepository = locationsRepository;
            TablesRepository = tablesRepository;
            ModerationRepository = moderationRepository;
        }

        public async Task SaveChangesAsync()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}