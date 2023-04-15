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
                    date = table.Column<DateOnly>(type: "date", nullable: true),
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
                columns: new[] { "id", "address", "avg_bill", "avg_mark", "city_id", "closes_at", "ImagesCount", "main_image_url", "manager_id", "moderation_status", "opens_at", "Popularity", "public_date", "title" },
                values: new object[,]
                {
                    { 1, "вул. Заньковецької, 20", 600m, 4.7m, 1, new TimeOnly(20, 0, 0), (short)3, "https://assets.dots.live/misteram-public/1606a7ce-cf02-46c4-a097-7fe6759bde43.png", "M1", (short)2, new TimeOnly(10, 0, 0), 4, new DateOnly(2023, 3, 8), "Familia Grande" },
                    { 2, "вул. Небесної сотні 5а", 300m, null, 1, new TimeOnly(20, 0, 0), (short)2, "https://assets.dots.live/misteram-public/0627f92845e66bd4fdb662e3e6129ccc.png", "M2", (short)2, new TimeOnly(8, 0, 0), 2, new DateOnly(2023, 3, 28), "Піца парк" },
                    { 3, "вул. Івана Франка, 42Г", 950m, 4.8m, 2, new TimeOnly(22, 0, 0), (short)2, "https://assets.dots.live/misteram-public/2821669b-9921-4af9-acf8-a9b7e2e49a14.png", "M3", (short)2, new TimeOnly(12, 0, 0), 12, new DateOnly(2023, 4, 2), "Pang" }
                });

            migrationBuilder.InsertData(
                table: "places",
                columns: new[] { "id", "address", "avg_bill", "avg_mark", "city_id", "closes_at", "ImagesCount", "main_image_url", "manager_id", "moderation_status", "opens_at", "public_date", "title" },
                values: new object[,]
                {
                    { 4, "вул. академіка Амосова, 96В", 800m, null, 2, new TimeOnly(22, 0, 0), (short)1, "https://assets.dots.live/misteram-public/f1d85bcd-7b2f-4180-8a89-b55ad10fe019.png", "M4", (short)1, new TimeOnly(10, 30, 0), null, "LAPASTA" },
                    { 5, "вул. Івана Мазепи, 17Е", 400m, null, 2, new TimeOnly(22, 0, 0), (short)2, "https://assets.dots.live/misteram-public/7b5d6db7213f6e9d012f625024b94cb7.png", "M5", (short)0, new TimeOnly(13, 0, 0), null, "Пікантіко" }
                });

            migrationBuilder.InsertData(
                table: "places",
                columns: new[] { "id", "address", "avg_bill", "avg_mark", "city_id", "closes_at", "ImagesCount", "main_image_url", "manager_id", "moderation_status", "opens_at", "Popularity", "public_date", "title" },
                values: new object[] { 6, "вул. Січевих Стрільців, 119Б, заїзд з пр. Дорошенка", 1250m, 4.6m, 3, new TimeOnly(21, 30, 0), (short)2, "https://assets.dots.live/misteram-public/fd01592e-08b9-4058-bd77-dcfd74201b72.png", "M6", (short)2, new TimeOnly(11, 30, 0), 3, new DateOnly(2023, 4, 2), "Ребра та вогонь" });

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
                    { new Guid("18222309-30ee-45da-ad90-bd85ad908110"), new DateOnly(2023, 3, 28), "Mod2", 2, (short)2 },
                    { new Guid("225b53dd-b62a-4ff9-a3ec-93c74152bad5"), new DateOnly(2023, 4, 2), "Mod6", 6, (short)2 },
                    { new Guid("307acd21-a79c-4bcc-9f4c-c224901b2fad"), new DateOnly(2023, 4, 2), "Mod3", 3, (short)2 },
                    { new Guid("38bda491-6143-4bac-b7b0-c3d266d3b299"), new DateOnly(2023, 3, 8), "Mod1", 1, (short)2 },
                    { new Guid("4ee19b79-d2ac-47b1-a21f-71b000890e3e"), new DateOnly(2023, 4, 17), "Mod4", 4, (short)1 },
                    { new Guid("cbcd97ee-b902-4366-8247-87f79d5da802"), null, "Mod5", 5, (short)0 }
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
                    { new Guid("11133236-6a2c-4bd0-b7f0-a5494f9a48d4"), "U23", "", new DateOnly(2023, 4, 16), 5m, 6 },
                    { new Guid("24b13890-c422-47a4-92fd-360dcc9c79d9"), "U17", "", new DateOnly(2023, 4, 4), 5m, 6 },
                    { new Guid("2d257690-5aa5-477c-9ad6-ca67f68f1964"), "U20", "Копчене курча бездоганне, а от свиня за життя займалася фітнесом, міцна та підтягнута занадто)", new DateOnly(2023, 4, 11), 5m, 6 },
                    { new Guid("4bba8abe-e77a-4586-a4de-03b5fe39c4fd"), "U16", "Страви не підписані, мусили вгадувати.", new DateOnly(2023, 4, 14), 4m, 3 },
                    { new Guid("565af573-51ab-48dd-9a5d-cc13785a31a3"), "U12", "", new DateOnly(2023, 4, 14), 5m, 1 },
                    { new Guid("573bc050-b883-4dff-bd44-6e85e79c7b8e"), "U18", "", new DateOnly(2023, 4, 8), 4m, 6 },
                    { new Guid("6073b093-9cc9-4a7a-b59f-394c4068b347"), "U14", "Вже другий раз не дають прибори.", new DateOnly(2023, 4, 18), 4m, 1 },
                    { new Guid("a284b2f3-601e-4dda-afdf-d7f4ec95191c"), "U22", "Шашлик з купою жил, сала, ледь жувався.", new DateOnly(2023, 4, 16), 3m, 6 },
                    { new Guid("a8422476-dbd7-48a5-b5b1-55f22da21584"), "U11", "Піца була смачна. Рекомендую)", new DateOnly(2023, 4, 13), 5m, 3 },
                    { new Guid("ae05ec8c-ae9e-493d-85d4-9cabf7ded8fa"), "U15", "", new DateOnly(2023, 4, 5), 5m, 3 },
                    { new Guid("bc71e166-7671-4370-aba9-23f564ef452d"), "U19", "", new DateOnly(2023, 4, 9), 5m, 6 },
                    { new Guid("c2636fd0-2af9-4637-83ac-57bf067e8388"), "U2", "", new DateOnly(2023, 4, 11), 5m, 3 },
                    { new Guid("ce8726c8-af11-4945-b4cf-4e06388cdb16"), "U10", "Сама смачна піцца в Че. Я ваш клієнт на віки-вічні", new DateOnly(2023, 4, 12), 5m, 1 },
                    { new Guid("d01b8a11-7347-460a-bf34-571b438d674e"), "U1", "", new DateOnly(2023, 4, 9), 5m, 3 },
                    { new Guid("d0f2a1ef-d465-4661-8ddc-acaea08c091c"), "U13", "", new DateOnly(2023, 4, 17), 5m, 1 },
                    { new Guid("ee1e6f82-88d0-4289-8c60-be2a3669c3c3"), "U21", "Такої смачної їжі давно не куштувала", new DateOnly(2023, 4, 12), 5m, 6 }
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
                    { new Guid("009403b4-b67b-4269-9979-4c47ca79fbcb"), new TimeOnly(17, 0, 0), new DateTime(2023, 4, 19, 13, 6, 12, 0, DateTimeKind.Unspecified), new TimeOnly(19, 0, 0), (short)2, new DateOnly(2023, 4, 22), (short)0, 1, "U5" },
                    { new Guid("b58c120d-b69a-41cb-8e4a-8560cfeae5e5"), new TimeOnly(14, 0, 0), new DateTime(2023, 4, 8, 16, 18, 2, 0, DateTimeKind.Unspecified), new TimeOnly(16, 0, 0), (short)2, new DateOnly(2023, 4, 12), (short)2, 1, "U3" },
                    { new Guid("b605bebd-fe7a-4888-a354-4485e32d2fa9"), new TimeOnly(11, 30, 0), new DateTime(2023, 4, 5, 19, 46, 11, 0, DateTimeKind.Unspecified), new TimeOnly(13, 0, 0), (short)2, new DateOnly(2023, 4, 9), (short)0, 15, "U6" },
                    { new Guid("cfc1fb61-537d-4b4d-b13b-9797cf779b9e"), new TimeOnly(16, 0, 0), new DateTime(2023, 4, 20, 23, 42, 9, 0, DateTimeKind.Unspecified), new TimeOnly(18, 30, 0), (short)5, new DateOnly(2023, 4, 29), (short)0, 17, "U9" },
                    { new Guid("dd97511a-542c-4c66-a2ec-408045e69df9"), new TimeOnly(14, 0, 0), new DateTime(2023, 4, 9, 8, 57, 15, 0, DateTimeKind.Unspecified), new TimeOnly(16, 0, 0), (short)4, new DateOnly(2023, 4, 10), (short)0, 16, "U7" },
                    { new Guid("e74668e2-7471-4451-b63a-926a95672d68"), new TimeOnly(16, 30, 0), new DateTime(2023, 4, 5, 17, 3, 34, 0, DateTimeKind.Unspecified), new TimeOnly(19, 30, 0), (short)2, new DateOnly(2023, 4, 12), (short)1, 1, "U2" },
                    { new Guid("f2f69bc7-a17b-4ad8-9a01-f5b7fbde425a"), new TimeOnly(14, 0, 0), new DateTime(2023, 4, 10, 7, 20, 58, 0, DateTimeKind.Unspecified), new TimeOnly(16, 0, 0), (short)2, new DateOnly(2023, 4, 12), (short)2, 1, "U1" },
                    { new Guid("f4714642-1b52-4965-9320-f242f4382554"), new TimeOnly(14, 0, 0), new DateTime(2023, 4, 16, 21, 46, 27, 0, DateTimeKind.Unspecified), new TimeOnly(16, 0, 0), (short)2, new DateOnly(2023, 4, 22), (short)0, 1, "U4" },
                    { new Guid("fa3a6ed0-af79-415c-91af-4af04f05d9b6"), new TimeOnly(14, 0, 0), new DateTime(2023, 4, 11, 15, 7, 4, 0, DateTimeKind.Unspecified), new TimeOnly(16, 0, 0), (short)2, new DateOnly(2023, 4, 17), (short)1, 15, "U8" }
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
