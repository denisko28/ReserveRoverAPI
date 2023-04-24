using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Seeding.Abstract;

namespace ReserveRoverDAL.Seeding.Concrete;

public class ReservationsSeeder : ISeeder<Reservation>
{
    private static readonly List<Reservation> Reservations = new()
    {
        new Reservation
        {
            Id = Guid.NewGuid(),
            PlaceId = 1,
            TableSetId = 1,
            UserId = "U1",
            ReservDate = DateOnly.Parse("2023-04-26"),
            BeginTime = TimeOnly.Parse("10:00:00"),
            EndTime = TimeOnly.Parse("12:00:00"),
            PeopleNum = 2,
            Status = 0,
            CreationDateTime = DateTime.Parse("04/10/2023 07:20:58")
        },
        new Reservation
        {
            Id = Guid.NewGuid(),
            PlaceId = 1,
            TableSetId = 1,
            UserId = "U2",
            ReservDate = DateOnly.Parse("2023-04-26"),
            BeginTime = TimeOnly.Parse("10:30:00"),
            EndTime = TimeOnly.Parse("11:30:00"),
            PeopleNum = 2,
            Status = 0,
            CreationDateTime = DateTime.Parse("04/05/2023 17:03:34")
        },
        new Reservation
        {
            Id = Guid.NewGuid(),
            PlaceId = 1,
            TableSetId = 1,
            UserId = "U3",
            ReservDate = DateOnly.Parse("2023-04-26"),
            BeginTime = TimeOnly.Parse("14:30:00"),
            EndTime = TimeOnly.Parse("16:30:00"),
            PeopleNum = 2,
            Status = 0,
            CreationDateTime = DateTime.Parse("04/08/2023 16:18:02")
        },
        new Reservation
        {
            Id = Guid.NewGuid(),
            PlaceId = 1,
            TableSetId = 1,
            UserId = "U4",
            ReservDate = DateOnly.Parse("2023-04-26"),
            BeginTime = TimeOnly.Parse("12:00:00"),
            EndTime = TimeOnly.Parse("14:00:00"),
            PeopleNum = 2,
            Status = 0,
            CreationDateTime = DateTime.Parse("04/16/2023 21:46:27")
        },
        new Reservation
        {
            Id = Guid.NewGuid(),
            PlaceId = 1,
            TableSetId = 1,
            UserId = "U5",
            ReservDate = DateOnly.Parse("2023-04-26"),
            BeginTime = TimeOnly.Parse("13:00:00"),
            EndTime = TimeOnly.Parse("15:00:00"),
            PeopleNum = 2,
            Status = 0,
            CreationDateTime = DateTime.Parse("04/19/2023 13:06:12")
        },
        new Reservation
        {
            Id = Guid.NewGuid(),
            PlaceId = 1,
            TableSetId = 1,
            UserId = "U60",
            ReservDate = DateOnly.Parse("2023-04-26"),
            BeginTime = TimeOnly.Parse("14:00:00"),
            EndTime = TimeOnly.Parse("16:00:00"),
            PeopleNum = 2,
            Status = 0,
            CreationDateTime = DateTime.Parse("04/21/2023 18:15:53")
        },
        new Reservation
        {
            Id = Guid.NewGuid(),
            PlaceId = 6,
            TableSetId = 15,
            UserId = "U6",
            ReservDate = DateOnly.Parse("2023-04-09"),
            BeginTime = TimeOnly.Parse("11:30:00"),
            EndTime = TimeOnly.Parse("13:00:00"),
            PeopleNum = 2,
            Status = 0,
            CreationDateTime = DateTime.Parse("04/05/2023 19:46:11")
        },
        new Reservation
        {
            Id = Guid.NewGuid(),
            PlaceId = 6,
            TableSetId = 16,
            UserId = "U7",
            ReservDate = DateOnly.Parse("2023-04-10"),
            BeginTime = TimeOnly.Parse("14:00:00"),
            EndTime = TimeOnly.Parse("16:00:00"),
            PeopleNum = 4,
            Status = 0,
            CreationDateTime = DateTime.Parse("04/09/2023 08:57:15")
        },new Reservation
        {
            Id = Guid.NewGuid(),
            PlaceId = 6,
            TableSetId = 15,
            UserId = "U8",
            ReservDate = DateOnly.Parse("2023-04-17"),
            BeginTime = TimeOnly.Parse("14:00:00"),
            EndTime = TimeOnly.Parse("16:00:00"),
            PeopleNum = 2,
            Status = 1,
            CreationDateTime = DateTime.Parse("04/11/2023 15:07:04")
        },new Reservation
        {
            Id = Guid.NewGuid(),
            PlaceId = 6,
            TableSetId = 17,
            UserId = "U9",
            ReservDate = DateOnly.Parse("2023-04-29"),
            BeginTime = TimeOnly.Parse("16:00:00"),
            EndTime = TimeOnly.Parse("18:30:00"),
            PeopleNum = 5,
            Status = 0,
            CreationDateTime = DateTime.Parse("04/20/2023 23:42:09")
        }
    };

    public void Seed(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasData(Reservations);
    }
}