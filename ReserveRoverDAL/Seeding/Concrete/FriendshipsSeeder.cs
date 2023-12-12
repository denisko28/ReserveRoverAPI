using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Seeding.Abstract;

namespace ReserveRoverDAL.Seeding.Concrete;

public class FriendshipsSeeder : ISeeder<Friendship>
{
    private static readonly List<Friendship> Friendships = new()
    {
        new Friendship
        {
            Id = 1,
            User1Id = "GQ6qNAoxa4e0RDvaFEnIQbuzbpm1",
            User2Id = "D7Cy0pTcq0NszfWnTiiqLyfh0eI3",
            RequestedDateTime = DateTime.Parse("09/11/2023 11:03:34"),
            Accepted = false
        },
        new Friendship
        {
            Id = 2,
            User1Id = "CCK7UNofA4XUpaSRC5W3RdNoMxm2",
            User2Id = "GQ6qNAoxa4e0RDvaFEnIQbuzbpm1",
            RequestedDateTime = DateTime.Parse("09/11/2023 15:45:21"),
            Accepted = true
        },
        new Friendship
        {
            Id = 3,
            User1Id = "L31xc7GbqoVTjPFlyyWjDFqhc6u1",
            User2Id = "GQ6qNAoxa4e0RDvaFEnIQbuzbpm1",
            RequestedDateTime = DateTime.Parse("10/11/2023 14:37:09"),
            Accepted = true
        },
        new Friendship
        {
            Id = 4,
            User1Id = "En6jfcgABnQqw5wNBIpHLvMlB102",
            User2Id = "GQ6qNAoxa4e0RDvaFEnIQbuzbpm1",
            RequestedDateTime = DateTime.Parse("10/11/2023 17:39:22"),
            Accepted = true
        },
        new Friendship
        {
            Id = 5,
            User1Id = "TWkGRrgJeiRbBxFHepdxr5Ye0Rl1",
            User2Id = "CCK7UNofA4XUpaSRC5W3RdNoMxm2",
            RequestedDateTime = DateTime.Parse("10/11/2023 17:55:33"),
            Accepted = true
        },
        new Friendship
        {
            Id = 6,
            User1Id = "D7Cy0pTcq0NszfWnTiiqLyfh0eI3",
            User2Id = "En6jfcgABnQqw5wNBIpHLvMlB102",
            RequestedDateTime = DateTime.Parse("11/11/2023 03:59:20"),
            Accepted = false
        },
        new Friendship
        {
            Id = 7,
            User1Id = "TWkGRrgJeiRbBxFHepdxr5Ye0Rl1",
            User2Id = "GQ6qNAoxa4e0RDvaFEnIQbuzbpm1",
            RequestedDateTime = DateTime.Parse("11/11/2023 08:03:04"),
            Accepted = false
        },
    };

    public void Seed(EntityTypeBuilder<Friendship> builder)
    {
        builder.HasData(Friendships);
    }
}