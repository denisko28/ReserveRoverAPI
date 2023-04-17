using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NpgsqlTypes;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReserveRoverDAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cities_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "places",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    manager_id = table.Column<string>(type: "character(28)", fixedLength: true, maxLength: 28, nullable: false),
                    city_id = table.Column<int>(type: "integer", nullable: false),
                    main_image_url = table.Column<string>(type: "character varying(105)", maxLength: 105, nullable: false),
                    title = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    opens_at = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    closes_at = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    avg_mark = table.Column<decimal>(type: "numeric(2,1)", precision: 2, scale: 1, nullable: true),
                    Popularity = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    avg_bill = table.Column<decimal>(type: "numeric(7,2)", precision: 7, scale: 2, nullable: false),
                    address = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    ImagesCount = table.Column<short>(type: "smallint", nullable: false),
                    SubmissionDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    public_date = table.Column<DateOnly>(type: "date", nullable: true),
                    moderation_status = table.Column<short>(type: "smallint", nullable: false),
                    SearchVector = table.Column<NpgsqlTsVector>(type: "tsvector", nullable: false)
                        .Annotation("Npgsql:TsVectorConfig", "english")
                        .Annotation("Npgsql:TsVectorProperties", new[] { "title" })
                },
                constraints: table =>
                {
                    table.PrimaryKey("places_pkey", x => x.id);
                    table.ForeignKey(
                        name: "places_city_id_fkey",
                        column: x => x.city_id,
                        principalTable: "cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    place_id = table.Column<int>(type: "integer", nullable: false),
                    latitude = table.Column<decimal>(type: "numeric(8,6)", precision: 8, scale: 6, nullable: false),
                    longitude = table.Column<decimal>(type: "numeric(8,6)", precision: 8, scale: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("locations_pkey", x => x.place_id);
                    table.ForeignKey(
                        name: "locations_place_id_fkey",
                        column: x => x.place_id,
                        principalTable: "places",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "moderation",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    place_id = table.Column<int>(type: "integer", nullable: false),
                    moderator_id = table.Column<string>(type: "character(28)", fixedLength: true, maxLength: 28, nullable: false),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    status = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("moderation_pkey", x => x.id);
                    table.ForeignKey(
                        name: "moderation_place_id_fkey",
                        column: x => x.place_id,
                        principalTable: "places",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "place_images",
                columns: table => new
                {
                    place_id = table.Column<int>(type: "integer", nullable: false),
                    sequence_index = table.Column<short>(type: "smallint", nullable: false),
                    image_url = table.Column<string>(type: "character varying(105)", maxLength: 105, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("place_images_pkey", x => new { x.place_id, x.sequence_index });
                    table.ForeignKey(
                        name: "place_images_place_id_fkey",
                        column: x => x.place_id,
                        principalTable: "places",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "place_payment_methods",
                columns: table => new
                {
                    place_id = table.Column<int>(type: "integer", nullable: false),
                    method = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("place_payment_methods_pkey", x => new { x.place_id, x.method });
                    table.ForeignKey(
                        name: "place_payment_methods_place_id_fkey",
                        column: x => x.place_id,
                        principalTable: "places",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "places_descriptions",
                columns: table => new
                {
                    place_id = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "character varying(1500)", maxLength: 1500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("places_descriptions_pkey", x => x.place_id);
                    table.ForeignKey(
                        name: "places_descriptions_place_id_fkey",
                        column: x => x.place_id,
                        principalTable: "places",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    place_id = table.Column<int>(type: "integer", nullable: false),
                    author_id = table.Column<string>(type: "character(28)", fixedLength: true, maxLength: 28, nullable: false),
                    creation_date = table.Column<DateOnly>(type: "date", nullable: false),
                    mark = table.Column<decimal>(type: "numeric(1)", precision: 1, nullable: false),
                    comment = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("reviews_pkey", x => x.id);
                    table.ForeignKey(
                        name: "reviews_place_id_fkey",
                        column: x => x.place_id,
                        principalTable: "places",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tables",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    place_id = table.Column<int>(type: "integer", nullable: false),
                    table_type = table.Column<short>(type: "smallint", nullable: false),
                    tables_num = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tables_pkey", x => x.id);
                    table.ForeignKey(
                        name: "tables_place_id_fkey",
                        column: x => x.place_id,
                        principalTable: "places",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reservations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    table_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<string>(type: "character(28)", fixedLength: true, maxLength: 28, nullable: false),
                    reserv_date = table.Column<DateOnly>(type: "date", nullable: false),
                    begin_time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    end_time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    people_num = table.Column<short>(type: "smallint", nullable: false),
                    status = table.Column<short>(type: "smallint", nullable: false),
                    creation_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("reservations_pkey", x => x.id);
                    table.ForeignKey(
                        name: "reservations_table_id_fkey",
                        column: x => x.table_id,
                        principalTable: "tables",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "cities",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Чернівці" },
                    { 2, "Київ" },
                    { 3, "Львів" }
                });

            migrationBuilder.InsertData(
                table: "places",
                columns: new[] { "id", "address", "avg_bill", "avg_mark", "city_id", "closes_at", "ImagesCount", "main_image_url", "manager_id", "moderation_status", "opens_at", "Popularity", "public_date", "SubmissionDateTime", "title" },
                values: new object[,]
                {
                    { 1, "вул. Заньковецької, 20", 600m, 4.7m, 1, new TimeOnly(20, 0, 0), (short)3, "https://assets.dots.live/misteram-public/1606a7ce-cf02-46c4-a097-7fe6759bde43.png", "M1", (short)2, new TimeOnly(10, 0, 0), 4, new DateOnly(2023, 3, 8), new DateTime(2023, 3, 7, 7, 22, 16, 0, DateTimeKind.Unspecified), "Familia Grande" },
                    { 2, "вул. Небесної сотні 5а", 300m, null, 1, new TimeOnly(20, 0, 0), (short)2, "https://assets.dots.live/misteram-public/0627f92845e66bd4fdb662e3e6129ccc.png", "M2", (short)2, new TimeOnly(8, 0, 0), 2, new DateOnly(2023, 3, 28), new DateTime(2023, 3, 26, 18, 44, 9, 0, DateTimeKind.Unspecified), "Піца парк" },
                    { 3, "вул. Івана Франка, 42Г", 950m, 4.8m, 2, new TimeOnly(22, 0, 0), (short)2, "https://assets.dots.live/misteram-public/2821669b-9921-4af9-acf8-a9b7e2e49a14.png", "M3", (short)2, new TimeOnly(12, 0, 0), 12, new DateOnly(2023, 4, 2), new DateTime(2023, 4, 1, 14, 31, 57, 0, DateTimeKind.Unspecified), "Pang" }
                });

            migrationBuilder.InsertData(
                table: "places",
                columns: new[] { "id", "address", "avg_bill", "avg_mark", "city_id", "closes_at", "ImagesCount", "main_image_url", "manager_id", "moderation_status", "opens_at", "public_date", "SubmissionDateTime", "title" },
                values: new object[,]
                {
                    { 4, "вул. академіка Амосова, 96В", 800m, null, 2, new TimeOnly(22, 0, 0), (short)1, "https://assets.dots.live/misteram-public/f1d85bcd-7b2f-4180-8a89-b55ad10fe019.png", "M4", (short)1, new TimeOnly(10, 30, 0), null, new DateTime(2023, 4, 1, 11, 12, 19, 0, DateTimeKind.Unspecified), "LAPASTA" },
                    { 5, "вул. Івана Мазепи, 17Е", 400m, null, 2, new TimeOnly(22, 0, 0), (short)2, "https://assets.dots.live/misteram-public/7b5d6db7213f6e9d012f625024b94cb7.png", "M5", (short)0, new TimeOnly(13, 0, 0), null, new DateTime(2023, 4, 2, 23, 43, 37, 0, DateTimeKind.Unspecified), "Пікантіко" }
                });

            migrationBuilder.InsertData(
                table: "places",
                columns: new[] { "id", "address", "avg_bill", "avg_mark", "city_id", "closes_at", "ImagesCount", "main_image_url", "manager_id", "moderation_status", "opens_at", "Popularity", "public_date", "SubmissionDateTime", "title" },
                values: new object[] { 6, "вул. Січевих Стрільців, 119Б, заїзд з пр. Дорошенка", 1250m, 4.6m, 3, new TimeOnly(21, 30, 0), (short)2, "https://assets.dots.live/misteram-public/fd01592e-08b9-4058-bd77-dcfd74201b72.png", "M6", (short)2, new TimeOnly(11, 30, 0), 3, new DateOnly(2023, 4, 3), new DateTime(2023, 4, 2, 16, 50, 28, 0, DateTimeKind.Unspecified), "Ребра та вогонь" });

            migrationBuilder.InsertData(
                table: "locations",
                columns: new[] { "place_id", "latitude", "longitude" },
                values: new object[,]
                {
                    { 1, 48.291845m, 25.930247m },
                    { 2, 48.290586m, 25.935982m },
                    { 3, 50.439802m, 30.538339m },
                    { 4, 50.421874m, 30.466707m },
                    { 5, 50.480726m, 30.604961m },
                    { 6, 49.840546m, 24.024734m }
                });

            migrationBuilder.InsertData(
                table: "moderation",
                columns: new[] { "id", "date", "moderator_id", "place_id", "status" },
                values: new object[,]
                {
                    { new Guid("1b5d0d36-a1c3-4798-9358-8133e0315676"), new DateTime(2023, 4, 1, 16, 4, 15, 0, DateTimeKind.Unspecified), "Mod2", 4, (short)1 },
                    { new Guid("632afec5-f8dc-48ed-93ba-06c5b24d4860"), new DateTime(2023, 3, 28, 9, 31, 46, 0, DateTimeKind.Unspecified), "Mod2", 2, (short)2 },
                    { new Guid("825635dd-3e9e-4a6a-98ba-a96c2608fb98"), new DateTime(2023, 3, 8, 11, 23, 4, 0, DateTimeKind.Unspecified), "Mod1", 1, (short)2 },
                    { new Guid("a37c0780-755b-4d14-b5ae-6795dbafc95c"), new DateTime(2023, 4, 2, 17, 20, 3, 0, DateTimeKind.Unspecified), "Mod1", 3, (short)2 },
                    { new Guid("f11a0c73-2799-4b54-aae4-cbc4e76d8ddf"), new DateTime(2023, 4, 3, 10, 53, 6, 0, DateTimeKind.Unspecified), "Mod2", 6, (short)2 }
                });

            migrationBuilder.InsertData(
                table: "place_images",
                columns: new[] { "place_id", "sequence_index", "image_url" },
                values: new object[,]
                {
                    { 1, (short)0, "https://famigliagrande.ua/wp-content/uploads/2022/11/foto-prosciutto-pear11.jpg" },
                    { 1, (short)1, "https://famigliagrande.ua/wp-content/uploads/2022/10/prosciuttopear.jpg" },
                    { 1, (short)2, "https://famigliagrande.ua/wp-content/uploads/2022/10/foto-angel.jpg" },
                    { 2, (short)0, "https://fastly.4sqi.net/img/general/600x600/186926302_7174fhsnxGKw_KYjrmEl6Mro1oz6NwjaygTiWZEsJUI.jpg" },
                    { 2, (short)1, "https://fastly.4sqi.net/img/general/600x600/51690195_-M0XtE0y0jbTS9sUFC7C72Q9rXxVSUNqmpjuO6v6O_0.jpg" },
                    { 3, (short)0, "https://assets.dots.live/misteram-public/f210f2ed-5e88-4ac6-8a88-d7bb1e8e0188-826x0.png" },
                    { 3, (short)1, "https://travel.chernivtsi.ua/storage/posts/July2022/vxr25w9G6MqZd4qYRdiN.jpg" },
                    { 4, (short)0, "https://lh3.googleusercontent.com/p/AF1QipO2b0cC1uaE836xZwwHE1OeiA_dDi_e41vL1UFt=w1080-h608-p-no-v0" },
                    { 5, (short)0, "https://pyvtrest.com.ua/images/C43D7D64-90E1-418C-B4DE-F18C038D0F47.jpeg" },
                    { 5, (short)1, "https://files.ratelist.top/uploads/images/bs/71875/photos/660872aa5b09e20adc70fdf8628f3e66-original.webp" },
                    { 6, (short)0, "https://lh3.googleusercontent.com/p/AF1QipNdBerwXQBA6Ltb4Am5snYPi2e0Ph2lvtu4Io_S=s1360-w1360-h1020" },
                    { 6, (short)1, "https://onedeal.com.ua/wp-content/uploads/2021/02/2018-07-17-4-1.jpg" }
                });

            migrationBuilder.InsertData(
                table: "place_payment_methods",
                columns: new[] { "method", "place_id" },
                values: new object[,]
                {
                    { (short)0, 1 },
                    { (short)1, 1 },
                    { (short)0, 2 },
                    { (short)0, 3 },
                    { (short)1, 3 },
                    { (short)0, 4 },
                    { (short)1, 4 },
                    { (short)0, 5 },
                    { (short)0, 6 },
                    { (short)1, 6 }
                });

            migrationBuilder.InsertData(
                table: "places_descriptions",
                columns: new[] { "place_id", "description" },
                values: new object[,]
                {
                    { 1, "Famiglia Grande – справжня Неаполітанська Піцерія,яка поєднує в собі найкращі традиції приготування піци.\n\nТільки справжня піч - ми випікаємо нашу піцу в справжній італійській печі при температурі 400 С, від всесвітньо відомого виробника. Завдяки цьому піца Famiglia Grande має досконалий неаполітанський смак. Спеціальне борошно - ми використовуємо італійське цільнозернове борошно найвищої якості. Воно створене спеціально для тіста тривалого визрівання, з додаванням закваски для ферментації. Саме тому піца Famiglia Grande така смачна та низькокалорійна.\n\nФерментоване тісто на заквасці - наше тісто визріває 32 години........... ! Фірмовий італійський соус Pomodoro - соус для нашої піци готується з очищених перетертих томатів, привезених прямо з сонячної Італії.Справжня італійська Моцарелла - традиційно входить до складу неаполітанської піци. Це молодий сир. У кожну піцу ми додаємо саме його. Піцайоло - смак нашої піци залежить від його вміння, досвіду та натхнення. Тому люди, які готують для Вас, пройшли відмінну школу у провідного майстра." },
                    { 2, "Ваші улюблені, перевірені часом страви, затишна атмосефера, фірмова піца.У нас смачно." },
                    { 3, "'Pang' - це в першу чергу про смак та турботу. Поняття азіатської кухні асоціюється з корисними свіжими продуктами, легкими стравами і маленькими смачними закусками. Азіатська кухня - це можливість експериментувати зі смаками і коштувати самі незвичайні поєднання продуктів, відкриваючи для себе незвичайний світ традицій та екзотики! З нами ти відчуєш усі відтінки смаків, від гострого до солодкого. Поринь в атмосферу східної культури!" },
                    { 4, "LAPASTA - енотека/пастерія. 👨🏻‍🍳🍕\nСімейний ресторан справжньої італійської кухні.\nВ нашому меню можна зустріти всю палітру смаків Італії.\nНаша піца - це кращі італійські традиції.\nГарячі страви та салати - невимовна насолода від шеф кухаря." },
                    { 5, "Пікантіко - смачна домашня кухня за помірними цінами. Великий асортимент пива: завжди свіже розливне крафтове пиво, від кращих пивоварень. Закуски до пива: свинні вушка, крендель, домашні чіпси, чебурек величезного розміру. Піцца на любий смак за помірними цінами." },
                    { 6, "Рецепт наших ребер ми випробовували аж три роки. А щоб вони були правдивими, ми розробили спеціальні мангали (єдині у своєму роді), що дозволяють готувати на відкритому вогні, аби ребра виходили зі скоринкою та присмаком диму. Як любиш готувати ребра самотужки – нема питань, можеш придбати наш маринад окремо. Смакує він добре, і не лише до ребер. Ми – демократичний заклад, тому тут не маємо посуду та їмо руками (ну, й так, зрештою, смачніше). І, певна річ, до нас вхід без краваток." }
                });

            migrationBuilder.InsertData(
                table: "reviews",
                columns: new[] { "id", "author_id", "comment", "creation_date", "mark", "place_id" },
                values: new object[,]
                {
                    { new Guid("0a558774-e67f-41d2-9924-03ac079eca7e"), "U20", "Копчене курча бездоганне, а от свиня за життя займалася фітнесом, міцна та підтягнута занадто)", new DateOnly(2023, 4, 11), 5m, 6 },
                    { new Guid("2b64248e-ef82-4234-b398-e5a5fcff7f26"), "U14", "Вже другий раз не дають прибори.", new DateOnly(2023, 4, 18), 4m, 1 },
                    { new Guid("2c3a1af9-434b-4f23-b8df-5180e7548943"), "U19", "", new DateOnly(2023, 4, 9), 5m, 6 },
                    { new Guid("30a032de-c21f-4df3-b29f-2ef5255cbf96"), "U2", "", new DateOnly(2023, 4, 11), 5m, 3 },
                    { new Guid("32cc5464-940f-4032-87f5-c5e50cfe1ad8"), "U17", "", new DateOnly(2023, 4, 4), 5m, 6 },
                    { new Guid("3db56adf-20f7-4780-8b42-a9889e4a0d3e"), "U16", "Страви не підписані, мусили вгадувати.", new DateOnly(2023, 4, 14), 4m, 3 },
                    { new Guid("46433d49-6c1b-40db-b7f1-d9a3d001fae0"), "U23", "", new DateOnly(2023, 4, 16), 5m, 6 },
                    { new Guid("4ad256fa-f8f8-42e0-b985-7e99a2d389b5"), "U13", "", new DateOnly(2023, 4, 17), 5m, 1 },
                    { new Guid("993a944c-a4cc-4daa-963a-eb2514d6483a"), "U18", "", new DateOnly(2023, 4, 8), 4m, 6 },
                    { new Guid("a2d938ff-b2a8-461e-bc0d-87059e3c4dd3"), "U21", "Такої смачної їжі давно не куштувала", new DateOnly(2023, 4, 12), 5m, 6 },
                    { new Guid("bc5307e4-d5cc-417d-93e0-ec9a0f6ed25f"), "U15", "", new DateOnly(2023, 4, 5), 5m, 3 },
                    { new Guid("c0e725c6-fc45-4269-a8cb-a633db25f20f"), "U11", "Піца була смачна. Рекомендую)", new DateOnly(2023, 4, 13), 5m, 3 },
                    { new Guid("dab71c70-7f52-4dd2-8749-efa8db4c835f"), "U10", "Сама смачна піцца в Че. Я ваш клієнт на віки-вічні", new DateOnly(2023, 4, 12), 5m, 1 },
                    { new Guid("e4604588-b4cb-4c0f-b5e4-8fd74f34776f"), "U22", "Шашлик з купою жил, сала, ледь жувався.", new DateOnly(2023, 4, 16), 3m, 6 },
                    { new Guid("f09a4404-efaa-4732-8cc8-8f13b5e0f648"), "U12", "", new DateOnly(2023, 4, 14), 5m, 1 },
                    { new Guid("ffe157cc-5047-463c-b790-3bc7416fd4ec"), "U1", "", new DateOnly(2023, 4, 9), 5m, 3 }
                });

            migrationBuilder.InsertData(
                table: "tables",
                columns: new[] { "id", "place_id", "table_type", "tables_num" },
                values: new object[,]
                {
                    { 1, 1, (short)2, (short)2 },
                    { 2, 1, (short)3, (short)2 },
                    { 3, 1, (short)4, (short)3 },
                    { 4, 1, (short)6, (short)1 },
                    { 5, 2, (short)2, (short)4 },
                    { 6, 2, (short)4, (short)5 },
                    { 7, 3, (short)3, (short)3 },
                    { 8, 3, (short)4, (short)4 },
                    { 9, 3, (short)6, (short)2 },
                    { 10, 4, (short)1, (short)3 },
                    { 11, 4, (short)2, (short)4 },
                    { 12, 5, (short)2, (short)3 },
                    { 13, 5, (short)4, (short)2 },
                    { 14, 5, (short)5, (short)2 },
                    { 15, 6, (short)2, (short)6 },
                    { 16, 6, (short)4, (short)4 },
                    { 17, 6, (short)5, (short)1 }
                });

            migrationBuilder.InsertData(
                table: "reservations",
                columns: new[] { "id", "begin_time", "creation_date_time", "end_time", "people_num", "reserv_date", "status", "table_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("2798ed92-8fa6-4ebc-ab1e-e675945d6063"), new TimeOnly(17, 0, 0), new DateTime(2023, 4, 19, 13, 6, 12, 0, DateTimeKind.Unspecified), new TimeOnly(19, 0, 0), (short)2, new DateOnly(2023, 4, 22), (short)0, 1, "U5" },
                    { new Guid("3b130e4e-18db-4cde-bed1-68c08d69e4e8"), new TimeOnly(14, 0, 0), new DateTime(2023, 4, 11, 15, 7, 4, 0, DateTimeKind.Unspecified), new TimeOnly(16, 0, 0), (short)2, new DateOnly(2023, 4, 17), (short)1, 15, "U8" },
                    { new Guid("46fe9136-13cd-4da3-b955-e804d0aec398"), new TimeOnly(14, 0, 0), new DateTime(2023, 4, 10, 7, 20, 58, 0, DateTimeKind.Unspecified), new TimeOnly(16, 0, 0), (short)2, new DateOnly(2023, 4, 12), (short)2, 1, "U1" },
                    { new Guid("980aeeb8-ea38-4d77-a9b2-baa40c952972"), new TimeOnly(14, 0, 0), new DateTime(2023, 4, 16, 21, 46, 27, 0, DateTimeKind.Unspecified), new TimeOnly(16, 0, 0), (short)2, new DateOnly(2023, 4, 22), (short)0, 1, "U4" },
                    { new Guid("d6fa60fb-cecb-48ba-b63d-0d71f864ec3b"), new TimeOnly(14, 0, 0), new DateTime(2023, 4, 9, 8, 57, 15, 0, DateTimeKind.Unspecified), new TimeOnly(16, 0, 0), (short)4, new DateOnly(2023, 4, 10), (short)0, 16, "U7" },
                    { new Guid("db103b4e-1466-4da2-be90-bad628548b37"), new TimeOnly(16, 0, 0), new DateTime(2023, 4, 20, 23, 42, 9, 0, DateTimeKind.Unspecified), new TimeOnly(18, 30, 0), (short)5, new DateOnly(2023, 4, 29), (short)0, 17, "U9" },
                    { new Guid("db6802a6-b46a-4bce-a9f9-2dc534d3aa67"), new TimeOnly(14, 0, 0), new DateTime(2023, 4, 8, 16, 18, 2, 0, DateTimeKind.Unspecified), new TimeOnly(16, 0, 0), (short)2, new DateOnly(2023, 4, 12), (short)2, 1, "U3" },
                    { new Guid("f27288fc-8c47-4212-ad16-67013e477d1d"), new TimeOnly(16, 30, 0), new DateTime(2023, 4, 5, 17, 3, 34, 0, DateTimeKind.Unspecified), new TimeOnly(19, 30, 0), (short)2, new DateOnly(2023, 4, 12), (short)1, 1, "U2" },
                    { new Guid("f28e3a71-4f63-4db3-b8c7-cec34c08e3f3"), new TimeOnly(11, 30, 0), new DateTime(2023, 4, 5, 19, 46, 11, 0, DateTimeKind.Unspecified), new TimeOnly(13, 0, 0), (short)2, new DateOnly(2023, 4, 9), (short)0, 15, "U6" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_moderation_place_id",
                table: "moderation",
                column: "place_id");

            migrationBuilder.CreateIndex(
                name: "IX_places_city_id",
                table: "places",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_places_SearchVector",
                table: "places",
                column: "SearchVector")
                .Annotation("Npgsql:IndexMethod", "GIN");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_table_id",
                table: "reservations",
                column: "table_id");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_place_id",
                table: "reviews",
                column: "place_id");

            migrationBuilder.CreateIndex(
                name: "IX_tables_place_id",
                table: "tables",
                column: "place_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "moderation");

            migrationBuilder.DropTable(
                name: "place_images");

            migrationBuilder.DropTable(
                name: "place_payment_methods");

            migrationBuilder.DropTable(
                name: "places_descriptions");

            migrationBuilder.DropTable(
                name: "reservations");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "tables");

            migrationBuilder.DropTable(
                name: "places");

            migrationBuilder.DropTable(
                name: "cities");
        }
    }
}
