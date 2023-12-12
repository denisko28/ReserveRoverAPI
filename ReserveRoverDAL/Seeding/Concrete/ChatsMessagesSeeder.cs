using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Seeding.Abstract;

namespace ReserveRoverDAL.Seeding.Concrete;

public class ChatsMessagesSeeder : ISeeder<ChatMessage>
{
    private static readonly List<ChatMessage> ChatsMessages = new()
    {
        new ChatMessage
        {
            Id = 1,
            ChatId = 1,
            FromUserId = "CCK7UNofA4XUpaSRC5W3RdNoMxm2",
            Message = "Привіт!",
            DateTime = DateTime.Parse("13/11/2023 11:03:34"),
            Viewed = true
        },
        new ChatMessage
        {
            Id = 2,
            ChatId = 1,
            FromUserId = "CCK7UNofA4XUpaSRC5W3RdNoMxm2",
            Message = "Як справи?",
            DateTime = DateTime.Parse("13/11/2023 11:03:54"),
            Viewed = true
        },
        new ChatMessage
        {
            Id = 3,
            ChatId = 1,
            FromUserId = "GQ6qNAoxa4e0RDvaFEnIQbuzbpm1",
            Message = "Привіт) Все чудово, в ти як?",
            DateTime = DateTime.Parse("13/11/2023 12:15:03"),
            Viewed = true
        },
        new ChatMessage
        {
            Id = 4,
            ChatId = 1,
            FromUserId = "CCK7UNofA4XUpaSRC5W3RdNoMxm2",
            Message = "В мене теж все досить добре",
            DateTime = DateTime.Parse("13/11/2023 12:21:12"),
            Viewed = true
        },
        new ChatMessage
        {
            Id = 5,
            ChatId = 1,
            FromUserId = "GQ6qNAoxa4e0RDvaFEnIQbuzbpm1",
            Message = "Найс, найс)",
            DateTime = DateTime.Parse("13/11/2023 13:01:56"),
            Viewed = false
        },
        
        new ChatMessage
        {
            Id = 6,
            ChatId = 2,
            FromUserId = "GQ6qNAoxa4e0RDvaFEnIQbuzbpm1",
            Message = "Привіт! Не хочеш піти сьогодні повечеряти?",
            DateTime = DateTime.Parse("14/11/2023 17:39:23"),
            Viewed = true
        },
        new ChatMessage
        {
            Id = 7,
            ChatId = 2,
            FromUserId = "L31xc7GbqoVTjPFlyyWjDFqhc6u1",
            Message = "Привіт, звісно, давай",
            DateTime = DateTime.Parse("14/11/2023 17:43:11"),
            Viewed = true
        },
        new ChatMessage
        {
            Id = 8,
            ChatId = 2,
            FromUserId = "GQ6qNAoxa4e0RDvaFEnIQbuzbpm1",
            Message = "В який заклад ти би хотів?",
            DateTime = DateTime.Parse("14/11/2023 17:58:51"),
            Viewed = true
        },
        new ChatMessage
        {
            Id = 9,
            ChatId = 2,
            FromUserId = "L31xc7GbqoVTjPFlyyWjDFqhc6u1",
            Message = "Як щодо Bla Bla Bar?",
            DateTime = DateTime.Parse("14/11/2023 18:06:45"),
            Viewed = true
        },
        new ChatMessage
        {
            Id = 10,
            ChatId = 2,
            FromUserId = "L31xc7GbqoVTjPFlyyWjDFqhc6u1",
            Message = "Там дуже смачні суші",
            DateTime = DateTime.Parse("14/11/2023 18:07:12"),
            Viewed = true
        },
        new ChatMessage
        {
            Id = 11,
            ChatId = 2,
            FromUserId = "GQ6qNAoxa4e0RDvaFEnIQbuzbpm1",
            Message = "Окей, тоді забронюю столик на 7",
            DateTime = DateTime.Parse("14/11/2023 18:14:03"),
            Viewed = false
        },
    };

    public void Seed(EntityTypeBuilder<ChatMessage> builder)
    {
        builder.HasData(ChatsMessages);
    }
}