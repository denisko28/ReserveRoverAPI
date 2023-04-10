using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ReserveRoverDAL.Seeding.Abstract;

public interface ISeeder<T> where T : class
{
    void Seed(EntityTypeBuilder<T> builder);
}