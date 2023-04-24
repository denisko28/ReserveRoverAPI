using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Seeding.Abstract;

namespace ReserveRoverDAL.Seeding.Concrete;

public class TableSetsSeeder : ISeeder<TableSet>
{
    private static readonly List<TableSet> TableSets = new()
    {
        new TableSet
        {
            Id = 1,
            PlaceId = 1,
            TableCapacity = 2,
            TablesNum = 3
        },
        new TableSet
        {
            Id = 2,
            PlaceId = 1,
            TableCapacity = 3,
            TablesNum = 2
        },
        new TableSet
        {
            Id = 3,
            PlaceId = 1,
            TableCapacity = 4,
            TablesNum = 3
        },
        new TableSet
        {
            Id = 4,
            PlaceId = 1,
            TableCapacity = 6,
            TablesNum = 1
        },
        new TableSet
        {
            Id = 5,
            PlaceId = 2,
            TableCapacity = 2,
            TablesNum = 4
        },
        new TableSet
        {
            Id = 6,
            PlaceId = 2,
            TableCapacity = 4,
            TablesNum = 5
        },
        new TableSet
        {
            Id = 7,
            PlaceId = 3,
            TableCapacity = 3,
            TablesNum = 3
        },
        new TableSet
        {
            Id = 8,
            PlaceId = 3,
            TableCapacity = 4,
            TablesNum = 4
        },
        new TableSet
        {
            Id = 9,
            PlaceId = 3,
            TableCapacity = 6,
            TablesNum = 2
        },
        new TableSet
        {
            Id = 10,
            PlaceId = 4,
            TableCapacity = 1,
            TablesNum = 3
        },
        new TableSet
        {
            Id = 11,
            PlaceId = 4,
            TableCapacity = 2,
            TablesNum = 4
        },
        new TableSet
        {
            Id = 12,
            PlaceId = 5,
            TableCapacity = 2,
            TablesNum = 3
        },
        new TableSet
        {
            Id = 13,
            PlaceId = 5,
            TableCapacity = 4,
            TablesNum = 2
        },
        new TableSet
        {
            Id = 14,
            PlaceId = 5,
            TableCapacity = 5,
            TablesNum = 2
        },
        new TableSet
        {
            Id = 15,
            PlaceId = 6,
            TableCapacity = 2,
            TablesNum = 6
        },
        new TableSet
        {
            Id = 16,
            PlaceId = 6,
            TableCapacity = 4,
            TablesNum = 4
        },
        new TableSet
        {
            Id = 17,
            PlaceId = 6,
            TableCapacity = 5,
            TablesNum = 1
        }
    };

    public void Seed(EntityTypeBuilder<TableSet> builder)
    {
        builder.HasData(TableSets);
    }
}