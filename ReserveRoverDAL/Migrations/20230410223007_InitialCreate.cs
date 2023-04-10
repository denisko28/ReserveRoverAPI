using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                    title = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    opens_at = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    closes_at = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    avg_mark = table.Column<decimal>(type: "numeric(2,1)", precision: 2, scale: 1, nullable: true),
                    avg_bill = table.Column<decimal>(type: "numeric(7,2)", precision: 7, scale: 2, nullable: false),
                    address = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    public_date = table.Column<DateOnly>(type: "date", nullable: true),
                    moderation_status = table.Column<short>(type: "smallint", nullable: false)
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
                columns: new[] { "id", "address", "avg_bill", "avg_mark", "city_id", "closes_at", "manager_id", "moderation_status", "opens_at", "public_date", "title" },
                values: new object[,]
                {
                    { 1, "вул. Заньковецької, 20", 600m, 4.7m, 1, new TimeOnly(20, 0, 0), "M1", (short)2, new TimeOnly(10, 0, 0), new DateOnly(2023, 3, 8), "Familia Grande" },
                    { 2, "вул. Небесної сотні 5а", 300m, null, 1, new TimeOnly(20, 0, 0), "M2", (short)2, new TimeOnly(8, 0, 0), new DateOnly(2023, 3, 28), "Піца парк" },
                    { 3, "вул. Івана Франка, 42Г", 950m, 4.8m, 2, new TimeOnly(22, 0, 0), "M3", (short)2, new TimeOnly(12, 0, 0), new DateOnly(2023, 4, 2), "Pang" },
                    { 4, "вул. академіка Амосова, 96В", 800m, null, 2, new TimeOnly(22, 0, 0), "M4", (short)1, new TimeOnly(10, 30, 0), null, "LAPASTA" },
                    { 5, "вул. Івана Мазепи, 17Е", 400m, null, 2, new TimeOnly(22, 0, 0), "M5", (short)0, new TimeOnly(13, 0, 0), null, "Пікантіко" },
                    { 6, "вул. Січевих Стрільців, 119Б, заїзд з пр. Дорошенка", 1250m, 4.6m, 3, new TimeOnly(21, 30, 0), "M6", (short)2, new TimeOnly(11, 30, 0), new DateOnly(2023, 4, 2), "Ребра та вогонь" }
                });

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
                    { new Guid("0fd2d2b3-e7f7-4eaf-a800-d5793719a4f1"), new DateOnly(2023, 4, 2), "Mod6", 6, (short)2 },
                    { new Guid("383de7d6-127c-4cba-8d0d-7c5a5a9ef4a8"), new DateOnly(2023, 3, 28), "Mod2", 2, (short)2 },
                    { new Guid("5e593796-f5dd-4ea8-93a9-fa7e4caa514f"), new DateOnly(2023, 4, 17), "Mod4", 4, (short)1 },
                    { new Guid("99c7a460-5616-44cc-b410-5929dfffe600"), null, "Mod5", 5, (short)0 },
                    { new Guid("9d50330d-6a94-417a-9a6a-11589e712499"), new DateOnly(2023, 4, 2), "Mod3", 3, (short)2 },
                    { new Guid("cb8fde55-ead5-4fd3-a770-603ef40e79f4"), new DateOnly(2023, 3, 8), "Mod1", 1, (short)2 }
                });

            migrationBuilder.InsertData(
                table: "place_images",
                columns: new[] { "place_id", "sequence_index", "image_url" },
                values: new object[,]
                {
                    { 1, (short)0, "https://assets.dots.live/misteram-public/1606a7ce-cf02-46c4-a097-7fe6759bde43.png" },
                    { 1, (short)1, "https://famigliagrande.ua/wp-content/uploads/2022/11/foto-prosciutto-pear11.jpg" },
                    { 1, (short)2, "https://famigliagrande.ua/wp-content/uploads/2022/10/prosciuttopear.jpg" },
                    { 1, (short)3, "https://famigliagrande.ua/wp-content/uploads/2022/10/foto-angel.jpg" },
                    { 2, (short)0, "https://assets.dots.live/misteram-public/0627f92845e66bd4fdb662e3e6129ccc.png" },
                    { 2, (short)1, "https://fastly.4sqi.net/img/general/600x600/186926302_7174fhsnxGKw_KYjrmEl6Mro1oz6NwjaygTiWZEsJUI.jpg" },
                    { 2, (short)2, "https://fastly.4sqi.net/img/general/600x600/51690195_-M0XtE0y0jbTS9sUFC7C72Q9rXxVSUNqmpjuO6v6O_0.jpg" },
                    { 3, (short)0, "https://assets.dots.live/misteram-public/2821669b-9921-4af9-acf8-a9b7e2e49a14.png" },
                    { 3, (short)1, "https://assets.dots.live/misteram-public/f210f2ed-5e88-4ac6-8a88-d7bb1e8e0188-826x0.png" },
                    { 3, (short)2, "https://travel.chernivtsi.ua/storage/posts/July2022/vxr25w9G6MqZd4qYRdiN.jpg" },
                    { 4, (short)0, "https://assets.dots.live/misteram-public/f1d85bcd-7b2f-4180-8a89-b55ad10fe019.png" },
                    { 4, (short)1, "https://lh3.googleusercontent.com/p/AF1QipO2b0cC1uaE836xZwwHE1OeiA_dDi_e41vL1UFt=w1080-h608-p-no-v0" },
                    { 5, (short)0, "https://assets.dots.live/misteram-public/7b5d6db7213f6e9d012f625024b94cb7.png" },
                    { 5, (short)1, "https://pyvtrest.com.ua/images/C43D7D64-90E1-418C-B4DE-F18C038D0F47.jpeg" },
                    { 5, (short)2, "https://files.ratelist.top/uploads/images/bs/71875/photos/660872aa5b09e20adc70fdf8628f3e66-original.webp" },
                    { 6, (short)0, "https://assets.dots.live/misteram-public/fd01592e-08b9-4058-bd77-dcfd74201b72.png" },
                    { 6, (short)1, "https://lh3.googleusercontent.com/p/AF1QipNdBerwXQBA6Ltb4Am5snYPi2e0Ph2lvtu4Io_S=s1360-w1360-h1020" },
                    { 6, (short)2, "https://onedeal.com.ua/wp-content/uploads/2021/02/2018-07-17-4-1.jpg" }
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
                    { new Guid("036ce13b-00ae-45b3-9ce6-03e89323ddc4"), "U20", "Копчене курча бездоганне, а от свиня за життя займалася фітнесом, міцна та підтягнута занадто)", new DateOnly(2023, 4, 11), 5m, 6 },
                    { new Guid("329320cf-ae4b-4cce-ab19-0a3c543bcb85"), "U1", "", new DateOnly(2023, 4, 9), 5m, 3 },
                    { new Guid("436931b5-6f4a-4c23-a521-5eb214110727"), "U12", "", new DateOnly(2023, 4, 14), 5m, 1 },
                    { new Guid("461cfc67-0161-48e1-94b1-f1072f120799"), "U10", "Сама смачна піцца в Че. Я ваш клієнт на віки-вічні", new DateOnly(2023, 4, 12), 5m, 1 },
                    { new Guid("4ae51fc6-1d00-4786-81bc-8baf72637ed7"), "U16", "Страви не підписані, мусили вгадувати.", new DateOnly(2023, 4, 14), 4m, 3 },
                    { new Guid("57a7cd73-1959-424d-8ec8-803532e5d539"), "U18", "", new DateOnly(2023, 4, 8), 4m, 6 },
                    { new Guid("67f57dbd-028b-4ee6-885a-0933ed1c2afc"), "U11", "Піца була смачна. Рекомендую)", new DateOnly(2023, 4, 13), 5m, 3 },
                    { new Guid("6c59268e-e86c-4b1b-97da-598dd48dbf49"), "U19", "", new DateOnly(2023, 4, 9), 5m, 6 },
                    { new Guid("82c66039-fb8b-4a04-8b42-3d825412cf6c"), "U17", "", new DateOnly(2023, 4, 4), 5m, 6 },
                    { new Guid("85ff3813-ab3b-47b2-af20-9e365ea294c3"), "U23", "", new DateOnly(2023, 4, 16), 5m, 6 },
                    { new Guid("9c515fec-fc20-4fee-a436-5be3ec77f616"), "U15", "", new DateOnly(2023, 4, 5), 5m, 3 },
                    { new Guid("b4deca11-7b7c-4cb0-8a21-52067f112235"), "U14", "Вже другий раз не дають прибори.", new DateOnly(2023, 4, 18), 4m, 1 },
                    { new Guid("b920c561-5055-4552-838d-8959cdd234f9"), "U21", "Такої смачної їжі давно не куштувала", new DateOnly(2023, 4, 12), 5m, 6 },
                    { new Guid("c786f93c-ef40-44cd-886d-8d405fc6a6c0"), "U13", "", new DateOnly(2023, 4, 17), 5m, 1 },
                    { new Guid("dc54019c-1d9b-4a85-bc6d-273716f80a25"), "U2", "", new DateOnly(2023, 4, 11), 5m, 3 },
                    { new Guid("ec67b623-7763-4b80-950e-6a213ce16f35"), "U22", "Шашлик з купою жил, сала, ледь жувався.", new DateOnly(2023, 4, 16), 3m, 6 }
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
                    { new Guid("08cc4909-f414-4e48-a1b8-481c1691672c"), new TimeOnly(11, 30, 0), new DateTime(2023, 4, 5, 19, 46, 11, 0, DateTimeKind.Unspecified), new TimeOnly(13, 0, 0), (short)2, new DateOnly(2023, 4, 9), (short)0, 15, "U6" },
                    { new Guid("3b625d67-10e4-4000-997d-3a6b586d6a97"), new TimeOnly(14, 0, 0), new DateTime(2023, 4, 10, 7, 20, 58, 0, DateTimeKind.Unspecified), new TimeOnly(16, 0, 0), (short)2, new DateOnly(2023, 4, 12), (short)2, 1, "U1" },
                    { new Guid("60290d67-2f37-4d97-9961-55041757b481"), new TimeOnly(14, 0, 0), new DateTime(2023, 4, 9, 8, 57, 15, 0, DateTimeKind.Unspecified), new TimeOnly(16, 0, 0), (short)4, new DateOnly(2023, 4, 10), (short)0, 16, "U7" },
                    { new Guid("695d5278-9533-4e70-86d0-f3f2d9dd0435"), new TimeOnly(14, 0, 0), new DateTime(2023, 4, 8, 16, 18, 2, 0, DateTimeKind.Unspecified), new TimeOnly(16, 0, 0), (short)2, new DateOnly(2023, 4, 12), (short)2, 1, "U3" },
                    { new Guid("93b18e55-97f3-40c6-b114-01fb0ad3a6ec"), new TimeOnly(16, 0, 0), new DateTime(2023, 4, 20, 23, 42, 9, 0, DateTimeKind.Unspecified), new TimeOnly(18, 30, 0), (short)5, new DateOnly(2023, 4, 29), (short)0, 17, "U9" },
                    { new Guid("ac230e8e-b750-4305-b17a-8a6d55e57af7"), new TimeOnly(16, 30, 0), new DateTime(2023, 4, 5, 17, 3, 34, 0, DateTimeKind.Unspecified), new TimeOnly(19, 30, 0), (short)2, new DateOnly(2023, 4, 12), (short)1, 1, "U2" },
                    { new Guid("cee5cd06-d680-4ad2-b4f3-3edca0bfc004"), new TimeOnly(14, 0, 0), new DateTime(2023, 4, 16, 21, 46, 27, 0, DateTimeKind.Unspecified), new TimeOnly(16, 0, 0), (short)2, new DateOnly(2023, 4, 22), (short)0, 1, "U4" },
                    { new Guid("e57b3f43-520c-407d-9739-7b7b2a1bfb1e"), new TimeOnly(17, 0, 0), new DateTime(2023, 4, 19, 13, 6, 12, 0, DateTimeKind.Unspecified), new TimeOnly(19, 0, 0), (short)2, new DateOnly(2023, 4, 22), (short)0, 1, "U5" },
                    { new Guid("ef209645-63f0-46a1-9b05-db57c0662828"), new TimeOnly(14, 0, 0), new DateTime(2023, 4, 11, 15, 7, 4, 0, DateTimeKind.Unspecified), new TimeOnly(16, 0, 0), (short)2, new DateOnly(2023, 4, 17), (short)1, 15, "U8" }
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
