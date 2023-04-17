using Microsoft.EntityFrameworkCore;
using ReserveRoverDAL.Configurations;

namespace ReserveRoverDAL;

public class ReserveRoverDbContext : DbContext
{
    public ReserveRoverDbContext(DbContextOptions<ReserveRoverDbContext> options)
        : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
            
        modelBuilder.ApplyConfiguration(new CitiesConfiguration());
        modelBuilder.ApplyConfiguration(new LocationsConfiguration());
        modelBuilder.ApplyConfiguration(new ModerationsConfiguration());
        modelBuilder.ApplyConfiguration(new PlacesConfiguration());
        modelBuilder.ApplyConfiguration(new PlacesDescriptionsConfiguration());
        modelBuilder.ApplyConfiguration(new PlacesImagesConfiguration());
        modelBuilder.ApplyConfiguration(new PlacesPaymentMethodsConfiguration());
        modelBuilder.ApplyConfiguration(new ReservationsConfiguration());
        modelBuilder.ApplyConfiguration(new ReviewsConfiguration());
        modelBuilder.ApplyConfiguration(new TablesConfiguration());
    }
}
