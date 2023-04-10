using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Seeding.Abstract;

namespace ReserveRoverDAL.Seeding.Concrete;

public class TablesSeeder : ISeeder<Table>
{
    private static readonly List<Table> Tables = new()
    {
        new Table
        {
            Id = 1,
            PlaceId = 1,
            TableCapacity = 2,
            TablesNum = 2
        },
        new Table
        {
            Id = 2,
            PlaceId = 1,
            TableCapacity = 3,
            TablesNum = 2
        },
        new Table
        {
            Id = 3,
            PlaceId = 1,
            TableCapacity = 4,
            TablesNum = 3
        },
        new Table
        {
            Id = 4,
            PlaceId = 1,
            TableCapacity = 6,
            TablesNum = 1
        },
        new Table
        {
            Id = 5,
            PlaceId = 2,
            TableCapacity = 2,
            TablesNum = 4
        },
        new Table
        {
            Id = 6,
            PlaceId = 2,
            TableCapacity = 4,
            TablesNum = 5
        },
        new Table
        {
            Id = 7,
            PlaceId = 3,
            TableCapacity = 3,
            TablesNum = 3
        },
        new Table
        {
            Id = 8,
            PlaceId = 3,
            TableCapacity = 4,
            TablesNum = 4
        },
        new Table
        {
            Id = 9,
            PlaceId = 3,
            TableCapacity = 6,
            TablesNum = 2
        },
        new Table
        {
            Id = 10,
            PlaceId = 4,
            TableCapacity = 1,
            TablesNum = 3
        },
        new Table
        {
            Id = 11,
            PlaceId = 4,
            TableCapacity = 2,
            TablesNum = 4
        },
        new Table
        {
            Id = 12,
            PlaceId = 5,
            TableCapacity = 2,
            TablesNum = 3
        },
        new Table
        {
            Id = 13,
            PlaceId = 5,
            TableCapacity = 4,
            TablesNum = 2
        },
        new Table
        {
            Id = 14,
            PlaceId = 5,
            TableCapacity = 5,
            TablesNum = 2
        },
        new Table
        {
            Id = 15,
            PlaceId = 6,
            TableCapacity = 2,
            TablesNum = 6
        },
        new Table
        {
            Id = 16,
            PlaceId = 6,
            TableCapacity = 4,
            TablesNum = 4
        },
        new Table
        {
            Id = 17,
            PlaceId = 6,
            TableCapacity = 5,
            TablesNum = 1
        }
    };

    public void Seed(EntityTypeBuilder<Table> builder)
    {
        builder.HasData(Tables);
    }
}