using ReserveRoverDAL.Repositories.Abstract;
using ReserveRoverDAL.UnitOfWork.Abstract;

namespace ReserveRoverDAL.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public ReserveRoverDbContext DbContext { get; }
        
        public IPlacesRepository PlacesRepository { get; }

        public IPlaceImagesRepository PlaceImagesRepository { get; }

        public IPlacesPaymentMethodsRepository PlacesPaymentMethodsRepository { get; set; }
        
        public ILocationsRepository LocationsRepository { get; set; }
        
        public ITablesRepository TablesRepository { get; set; }

        public UnitOfWork(ReserveRoverDbContext dbContext, IPlacesRepository placesRepository,
            IPlaceImagesRepository placeImagesRepository,
            IPlacesPaymentMethodsRepository placesPaymentMethodsRepository, ILocationsRepository locationsRepository, ITablesRepository tablesRepository)
        {
            DbContext = dbContext;
            PlacesRepository = placesRepository;
            PlaceImagesRepository = placeImagesRepository;
            PlacesPaymentMethodsRepository = placesPaymentMethodsRepository;
            LocationsRepository = locationsRepository;
            TablesRepository = tablesRepository;
        }

        public async Task SaveChangesAsync()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}