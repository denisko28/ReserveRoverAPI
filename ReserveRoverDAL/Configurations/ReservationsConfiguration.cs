using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Seeding.Concrete;

namespace ReserveRoverDAL.Configurations;

public class ReservationsConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasKey(e => e.Id).HasName("reservations_pkey");

        builder.ToTable("reservations");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("gen_random_uuid()")
            .HasColumnName("id");
        builder.Property(e => e.BeginTime).HasColumnName("begin_time");
        builder.Property(e => e.CreationDateTime)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("creation_date_time");
        builder.Property(e => e.EndTime).HasColumnName("end_time");
        builder.Property(e => e.PeopleNum).HasColumnName("people_num");
        builder.Property(e => e.ReservDate).HasColumnName("reserv_date");
        builder.Property(e => e.Status).HasColumnName("status");
        builder.Property(e => e.TableSetId).HasColumnName("table_id");
        builder.Property(e => e.UserId)
            .HasMaxLength(28)
            .IsFixedLength()
            .HasColumnName("user_id");

        builder.HasOne(d => d.TableSet).WithMany(p => p.Reservations)
            .HasForeignKey(d => d.TableSetId)
            .HasConstraintName("reservations_table_id_fkey");
        
        // new ReservationsSeeder().Seed(builder);
    }
}