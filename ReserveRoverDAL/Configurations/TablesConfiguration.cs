using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Seeding.Concrete;

namespace ReserveRoverDAL.Configurations;

public class TablesConfiguration : IEntityTypeConfiguration<TableSet>
{
    public void Configure(EntityTypeBuilder<TableSet> builder)
    {
        builder.HasKey(e => e.Id).HasName("tables_pkey");

        builder.ToTable("tables");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.PlaceId).HasColumnName("place_id");
        builder.Property(e => e.TableCapacity).HasColumnName("table_type");
        builder.Property(e => e.TablesNum).HasColumnName("tables_num");

        builder.HasOne(d => d.Place).WithMany(p => p.TableSets)
            .HasForeignKey(d => d.PlaceId)
            .HasConstraintName("tables_place_id_fkey");

        // new TableSetsSeeder().Seed(builder);
    }
}