using Microsoft.EntityFrameworkCore;
using ReserveRoverDAL.Configurations;
using ReserveRoverDAL.Entities;

namespace ReserveRoverDAL;

public class ReserveRoverDbContext : DbContext
{
    public DbSet<City> Cities { get; set; }
    public DbSet<Friendship> Friendships { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Moderation> Moderations { get; set; }
    public DbSet<Place> Palaces { get; set; }
    public DbSet<PlaceImage> PlaceImages { get; set; }
    public DbSet<PlacePaymentMethod> PlacePaymentMethods { get; set; }
    public DbSet<PlaceDescription> PlaceDescriptions { get; set; }
    public DbSet<PublicUser> PublicUsers { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<TableSet> TableSets { get; set; }
    
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
        modelBuilder.ApplyConfiguration(new FriendshipsConfiguration());
        modelBuilder.ApplyConfiguration(new ChatsConfiguration());
        modelBuilder.ApplyConfiguration(new ChatsMessagesConfiguration());
        modelBuilder.ApplyConfiguration(new PublicUsersConfiguration());
    }
}
