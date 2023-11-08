using Microsoft.EntityFrameworkCore;
using ReserveRoverDAL.Configurations;
using ReserveRoverDAL.Entities;

namespace ReserveRoverDAL;

public class ReserveRoverDbContext : DbContext
{
    public virtual DbSet<City> Cities { get; set; }
    
    public virtual DbSet<Location> Locations { get; set; }
    
    public virtual DbSet<Moderation> Moderations { get; set; }
    
    public virtual DbSet<Place> Places { get; set; }
    
    public virtual DbSet<PlaceImage> PlaceImages { get; set; }
    
    public virtual DbSet<PlacePaymentMethod> PlacePaymentMethods { get; set; }
    
    public virtual DbSet<PlaceDescription> PlaceDescriptions { get; set; }
    
    public virtual DbSet<Reservation> Reservations { get; set; }
    
    public virtual DbSet<Review> Reviews { get; set; }
    
    public virtual DbSet<TableSet> TableSets { get; set; }
    
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
