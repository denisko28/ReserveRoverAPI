using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Seeding.Abstract;

namespace ReserveRoverDAL.Seeding.Concrete;

public class ChatsSeeder : ISeeder<Chat>
{
    private static readonly List<Chat> Chats = new()
    {
        new Chat {Id = 1, User1Id = "CCK7UNofA4XUpaSRC5W3RdNoMxm2", User2Id = "GQ6qNAoxa4e0RDvaFEnIQbuzbpm1"},
        new Chat {Id = 2, User1Id = "GQ6qNAoxa4e0RDvaFEnIQbuzbpm1", User2Id = "L31xc7GbqoVTjPFlyyWjDFqhc6u1"},
        // new Chat {Id = 3, User1Id = "En6jfcgABnQqw5wNBIpHLvMlB102", User2Id = "GQ6qNAoxa4e0RDvaFEnIQbuzbpm1"},
    };

    public void Seed(EntityTypeBuilder<Chat> builder)
    {
        builder.HasData(Chats);
    }
}