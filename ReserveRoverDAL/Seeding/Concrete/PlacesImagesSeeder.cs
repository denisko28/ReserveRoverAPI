using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Seeding.Abstract;

namespace ReserveRoverDAL.Seeding.Concrete;

public class PlacesImagesSeeder : ISeeder<PlaceImage>
{
    private static readonly List<PlaceImage> PlacesImages = new()
    {
        new PlaceImage
        {
            PlaceId = 1,
            SequenceIndex = 0,
            ImageUrl = "https://famigliagrande.ua/wp-content/uploads/2022/11/foto-prosciutto-pear11.jpg"
        },
        new PlaceImage
        {
            PlaceId = 1,
            SequenceIndex = 1,
            ImageUrl = "https://famigliagrande.ua/wp-content/uploads/2022/10/prosciuttopear.jpg"
        },
        new PlaceImage
        {
            PlaceId = 1,
            SequenceIndex = 2,
            ImageUrl = "https://famigliagrande.ua/wp-content/uploads/2022/10/foto-angel.jpg"
        },
        new PlaceImage
        {
            PlaceId = 2,
            SequenceIndex = 0,
            ImageUrl = "https://fastly.4sqi.net/img/general/600x600/186926302_7174fhsnxGKw_KYjrmEl6Mro1oz6NwjaygTiWZEsJUI.jpg"
        },
        new PlaceImage
        {
            PlaceId = 2,
            SequenceIndex = 1,
            ImageUrl = "https://fastly.4sqi.net/img/general/600x600/51690195_-M0XtE0y0jbTS9sUFC7C72Q9rXxVSUNqmpjuO6v6O_0.jpg"
        },
        new PlaceImage
        {
            PlaceId = 3,
            SequenceIndex = 0,
            ImageUrl = "https://assets.dots.live/misteram-public/f210f2ed-5e88-4ac6-8a88-d7bb1e8e0188-826x0.png"
        },
        new PlaceImage
        {
            PlaceId = 3,
            SequenceIndex = 1,
            ImageUrl = "https://travel.chernivtsi.ua/storage/posts/July2022/vxr25w9G6MqZd4qYRdiN.jpg"
        },
        new PlaceImage
        {
            PlaceId = 4,
            SequenceIndex = 0,
            ImageUrl = "https://lh3.googleusercontent.com/p/AF1QipO2b0cC1uaE836xZwwHE1OeiA_dDi_e41vL1UFt=w1080-h608-p-no-v0"
        },
        new PlaceImage
        {
            PlaceId = 5,
            SequenceIndex = 0,
            ImageUrl = "https://pyvtrest.com.ua/images/C43D7D64-90E1-418C-B4DE-F18C038D0F47.jpeg"
        },
        new PlaceImage
        {
            PlaceId = 5,
            SequenceIndex = 1,
            ImageUrl = "https://files.ratelist.top/uploads/images/bs/71875/photos/660872aa5b09e20adc70fdf8628f3e66-original.webp"
        },
        new PlaceImage
        {
            PlaceId = 6,
            SequenceIndex = 0,
            ImageUrl = "https://lh3.googleusercontent.com/p/AF1QipNdBerwXQBA6Ltb4Am5snYPi2e0Ph2lvtu4Io_S=s1360-w1360-h1020"
        },
        new PlaceImage
        {
            PlaceId = 6,
            SequenceIndex = 1,
            ImageUrl = "https://onedeal.com.ua/wp-content/uploads/2021/02/2018-07-17-4-1.jpg"
        }
    };

    public void Seed(EntityTypeBuilder<PlaceImage> builder)
    {
        builder.HasData(PlacesImages);
    }
}