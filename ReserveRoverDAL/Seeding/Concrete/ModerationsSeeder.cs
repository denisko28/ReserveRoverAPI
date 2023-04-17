using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Seeding.Abstract;

namespace ReserveRoverDAL.Seeding.Concrete;

public class ModerationsSeeder : ISeeder<Moderation>
{
    private static readonly List<Moderation> Moderations = new()
    {
        new Moderation
        {
            Id = Guid.NewGuid(),
            PlaceId = 1,
            ModeratorId = "Mod1",
            DateTime = DateTime.Parse("2023/03/08 11:23:04"),
            Status = 2
        },
        new Moderation
        {
            Id = Guid.NewGuid(),
            PlaceId = 2,
            ModeratorId = "Mod2",
            DateTime = DateTime.Parse("2023/03/28 09:31:46"),
            Status = 2
        },
        new Moderation
        {
            Id = Guid.NewGuid(),
            PlaceId = 3,
            ModeratorId = "Mod1",
            DateTime = DateTime.Parse("2023/04/02 17:20:03"),
            Status = 2
        },
        new Moderation
        {
            Id = Guid.NewGuid(),
            PlaceId = 4,
            ModeratorId = "Mod2",
            DateTime = DateTime.Parse("2023/04/01 16:04:15"),
            Status = 1
        },
        new Moderation
        {
            Id = Guid.NewGuid(),
            PlaceId = 6,
            ModeratorId = "Mod2",
            DateTime = DateTime.Parse("2023/04/03 10:53:06"),
            Status = 2
        }
    };

    public void Seed(EntityTypeBuilder<Moderation> builder)
    {
        builder.HasData(Moderations);
    }
}