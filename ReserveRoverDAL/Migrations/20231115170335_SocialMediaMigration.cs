using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReserveRoverDAL.Migrations
{
    /// <inheritdoc />
    public partial class SocialMediaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "moderation",
                keyColumn: "id",
                keyValue: new Guid("477e6fd5-41ad-4ac8-8526-e80d588fdb73"));

            migrationBuilder.DeleteData(
                table: "moderation",
                keyColumn: "id",
                keyValue: new Guid("57e8a5db-87d3-4ec3-bc79-c5fb067f3ca6"));

            migrationBuilder.DeleteData(
                table: "moderation",
                keyColumn: "id",
                keyValue: new Guid("9cdab1bf-4b8e-4227-b90a-091eb8d18b5a"));

            migrationBuilder.DeleteData(
                table: "moderation",
                keyColumn: "id",
                keyValue: new Guid("ed3c3694-3d82-4b16-986b-e9d55cbce5b6"));

            migrationBuilder.DeleteData(
                table: "moderation",
                keyColumn: "id",
                keyValue: new Guid("faa2eb63-6619-4ee1-ac3e-309ebac2539a"));

            migrationBuilder.DeleteData(
                table: "reservations",
                keyColumn: "id",
                keyValue: new Guid("4893095e-503a-4946-b850-2f266afc414e"));

            migrationBuilder.DeleteData(
                table: "reservations",
                keyColumn: "id",
                keyValue: new Guid("52667067-14e0-4ebe-ae63-83b18fb3679b"));

            migrationBuilder.DeleteData(
                table: "reservations",
                keyColumn: "id",
                keyValue: new Guid("710348f4-796b-467d-b6a5-797d8fe288fe"));

            migrationBuilder.DeleteData(
                table: "reservations",
                keyColumn: "id",
                keyValue: new Guid("71ccf9bc-55bd-4535-91cc-ce86c387d998"));

            migrationBuilder.DeleteData(
                table: "reservations",
                keyColumn: "id",
                keyValue: new Guid("a99235f4-e450-4807-8af7-733d4a62012d"));

            migrationBuilder.DeleteData(
                table: "reservations",
                keyColumn: "id",
                keyValue: new Guid("b32a93f5-73fc-437e-8425-e2fc2d400bfd"));

            migrationBuilder.DeleteData(
                table: "reservations",
                keyColumn: "id",
                keyValue: new Guid("c40fa32b-308b-4c7d-86dd-ea4d4f0006b2"));

            migrationBuilder.DeleteData(
                table: "reservations",
                keyColumn: "id",
                keyValue: new Guid("dd1cd78c-0ac4-436c-8e38-a853b64b0fa8"));

            migrationBuilder.DeleteData(
                table: "reservations",
                keyColumn: "id",
                keyValue: new Guid("deecd260-e7e4-4d8c-bf53-fde34b0417da"));

            migrationBuilder.DeleteData(
                table: "reservations",
                keyColumn: "id",
                keyValue: new Guid("e11853fe-9850-4012-85b8-63cd3a83d5d3"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("08e78ee1-7d60-49e2-805c-b95f42c0d80c"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("0dd65bf5-700f-4de0-a6cf-8f03d5178c43"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("0f02dd97-cca6-480d-95a3-3daec4305f7b"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("27946048-abe0-445c-9117-23611d2346c5"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("2b090499-0416-4e31-99bb-5d15a01c31ad"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("3c0f4baa-d2d6-4c77-97b7-ee08ced1c9cb"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("3d441ee5-e318-4ef8-9335-57e9ada4b0f4"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("4c76a083-1d7b-45ed-959f-3ff63b8a3c58"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("514caade-65fe-43a5-a0dd-d16dc68199de"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("53af70a2-71f5-4475-98d0-3dc48c17292c"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("59ac935f-879b-4e6d-99ef-ed8c26c52606"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("827f5085-68b4-4258-9b84-14cc148b3e7e"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("85d34275-6637-4203-8c57-f581731b7d76"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("8939577e-b11a-48fa-af60-f611abbd3039"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("9f8d3391-61b2-4258-98aa-1bf469ed806c"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("ae62422a-ac55-4b53-af28-5e59cc7c1237"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("b1c96429-c1b0-417e-bad3-02ddd50f64d7"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("b8d3307c-eb89-4a7f-89c8-0d41cd136bdd"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("d553f1a8-3d20-4ca1-8ecb-50c28bce4d76"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("fb186b49-72ce-45a8-a71b-7c6210b704cc"));

            migrationBuilder.AlterColumn<decimal>(
                name: "mark",
                table: "reviews",
                type: "numeric(1)",
                precision: 1,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(1,0)",
                oldPrecision: 1);

            migrationBuilder.CreateTable(
                name: "public_users",
                columns: table => new
                {
                    id = table.Column<string>(type: "character(28)", fixedLength: true, maxLength: 28, nullable: false),
                    first_name = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    last_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    avatar = table.Column<string>(type: "character varying(170)", maxLength: 170, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("public_users_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "chats",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user1_id = table.Column<string>(type: "character(28)", fixedLength: true, maxLength: 28, nullable: false),
                    user2_id = table.Column<string>(type: "character(28)", fixedLength: true, maxLength: 28, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("chats_pkey", x => x.id);
                    table.ForeignKey(
                        name: "chat_public_user1_fkey",
                        column: x => x.user1_id,
                        principalTable: "public_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "chat_public_user2_fkey",
                        column: x => x.user2_id,
                        principalTable: "public_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "friendships",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user1_id = table.Column<string>(type: "character(28)", fixedLength: true, maxLength: 28, nullable: false),
                    user2_id = table.Column<string>(type: "character(28)", fixedLength: true, maxLength: 28, nullable: false),
                    requested_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    accepted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("friendships_pkey", x => x.id);
                    table.ForeignKey(
                        name: "friendship_public_user1_fkey",
                        column: x => x.user1_id,
                        principalTable: "public_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "friendship_public_user2_fkey",
                        column: x => x.user2_id,
                        principalTable: "public_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chats_messages",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChatId = table.Column<int>(type: "integer", nullable: false),
                    from_user_id = table.Column<string>(type: "character(28)", fixedLength: true, maxLength: 28, nullable: false),
                    message = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: false),
                    date_time = table.Column<DateTime>(type: "timestamp without time zone", maxLength: 120, nullable: false),
                    viewed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("chats_messages_pkey", x => x.id);
                    table.ForeignKey(
                        name: "chat_chat_messages_id_fkey",
                        column: x => x.ChatId,
                        principalTable: "chats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "moderation",
                columns: new[] { "id", "date", "moderator_id", "place_id", "status" },
                values: new object[,]
                {
                    { new Guid("002891be-7ebc-4c31-9ca0-1f42d38df160"), new DateTime(2023, 4, 2, 17, 20, 3, 0, DateTimeKind.Unspecified), "Mod1", 3, (short)2 },
                    { new Guid("17484fe0-88d7-41ca-9988-5a0bd9f6ce79"), new DateTime(2023, 3, 28, 9, 31, 46, 0, DateTimeKind.Unspecified), "Mod2", 2, (short)2 },
                    { new Guid("5327d999-b744-4966-8cf2-d79a4e29e1ae"), new DateTime(2023, 4, 3, 10, 53, 6, 0, DateTimeKind.Unspecified), "Mod2", 6, (short)2 },
                    { new Guid("afddd193-3827-43bb-8077-39bdf34eaf9e"), new DateTime(2023, 4, 1, 16, 4, 15, 0, DateTimeKind.Unspecified), "Mod2", 4, (short)1 },
                    { new Guid("e9c4a9b2-0994-4a02-baa1-d0e6aaf4a357"), new DateTime(2023, 3, 8, 11, 23, 4, 0, DateTimeKind.Unspecified), "Mod1", 1, (short)2 }
                });

            migrationBuilder.InsertData(
                table: "reservations",
                columns: new[] { "id", "begin_time", "creation_date_time", "end_time", "people_num", "PlaceId", "reserv_date", "status", "table_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("1e68496d-8f1c-49e7-b8bd-213c81ebaf4e"), new TimeOnly(16, 0, 0), new DateTime(2023, 4, 20, 23, 42, 9, 0, DateTimeKind.Unspecified), new TimeOnly(18, 30, 0), (short)5, 6, new DateOnly(2023, 4, 29), (short)0, 17, "U9" },
                    { new Guid("34412304-db23-4e5e-af68-01dc20546d89"), new TimeOnly(14, 0, 0), new DateTime(2023, 4, 21, 18, 15, 53, 0, DateTimeKind.Unspecified), new TimeOnly(16, 0, 0), (short)2, 1, new DateOnly(2023, 4, 26), (short)0, 1, "U60" },
                    { new Guid("35b3057d-4de9-43b1-8a45-fe920a0f7114"), new TimeOnly(11, 30, 0), new DateTime(2023, 4, 5, 19, 46, 11, 0, DateTimeKind.Unspecified), new TimeOnly(13, 0, 0), (short)2, 6, new DateOnly(2023, 4, 9), (short)0, 15, "U6" },
                    { new Guid("4df7985b-c640-4ca0-89fd-8f6378e91ee0"), new TimeOnly(14, 0, 0), new DateTime(2023, 4, 9, 8, 57, 15, 0, DateTimeKind.Unspecified), new TimeOnly(16, 0, 0), (short)4, 6, new DateOnly(2023, 4, 10), (short)0, 16, "U7" },
                    { new Guid("8c2065e5-4cc5-4a35-8070-4c424d30cc9f"), new TimeOnly(12, 0, 0), new DateTime(2023, 4, 16, 21, 46, 27, 0, DateTimeKind.Unspecified), new TimeOnly(14, 0, 0), (short)2, 1, new DateOnly(2023, 4, 26), (short)0, 1, "U4" },
                    { new Guid("9ee6dc11-e340-480f-926f-1601b685fe16"), new TimeOnly(10, 0, 0), new DateTime(2023, 4, 10, 7, 20, 58, 0, DateTimeKind.Unspecified), new TimeOnly(12, 0, 0), (short)2, 1, new DateOnly(2023, 4, 26), (short)0, 1, "U1" },
                    { new Guid("a53bb0c7-e667-4ccd-b28d-3758e43e1364"), new TimeOnly(14, 0, 0), new DateTime(2023, 4, 11, 15, 7, 4, 0, DateTimeKind.Unspecified), new TimeOnly(16, 0, 0), (short)2, 6, new DateOnly(2023, 4, 17), (short)1, 15, "U8" },
                    { new Guid("c9939799-c579-4928-9657-c85c669dc3d7"), new TimeOnly(10, 30, 0), new DateTime(2023, 4, 5, 17, 3, 34, 0, DateTimeKind.Unspecified), new TimeOnly(11, 30, 0), (short)2, 1, new DateOnly(2023, 4, 26), (short)0, 1, "U2" },
                    { new Guid("d0dc4aa6-e767-4edf-aa52-5aa7de0c65f4"), new TimeOnly(14, 30, 0), new DateTime(2023, 4, 8, 16, 18, 2, 0, DateTimeKind.Unspecified), new TimeOnly(16, 30, 0), (short)2, 1, new DateOnly(2023, 4, 26), (short)0, 1, "U3" },
                    { new Guid("e2f3c305-e84b-4716-9c61-f3a3f18eaede"), new TimeOnly(13, 0, 0), new DateTime(2023, 4, 19, 13, 6, 12, 0, DateTimeKind.Unspecified), new TimeOnly(15, 0, 0), (short)2, 1, new DateOnly(2023, 4, 26), (short)0, 1, "U5" }
                });

            migrationBuilder.InsertData(
                table: "reviews",
                columns: new[] { "id", "author_id", "comment", "creation_date", "mark", "place_id" },
                values: new object[,]
                {
                    { new Guid("38bbd354-8222-46a5-9861-5288d316b11f"), "En6jfcgABnQqw5wNBIpHLvMlB102", "", new DateOnly(2023, 4, 14), 5m, 1 },
                    { new Guid("47200fe9-0260-4d3f-a3b8-17855a977379"), "jidZO6WQMiYOSRIEE5ONUREmRpd2", "", new DateOnly(2023, 4, 16), 5m, 6 },
                    { new Guid("580c00c4-f33c-454e-95df-befe5b7fdf82"), "jidZO6WQMiYOSRIEE5ONUREmRpd2", "На жаль, не сподобалось, окрошка була пересолена, овочі в салаті в'ялі...", new DateOnly(2023, 5, 3), 3m, 2 },
                    { new Guid("5ace1260-0027-4136-9685-610d81a2a228"), "D7Cy0pTcq0NszfWnTiiqLyfh0eI3", "Копчене курча бездоганне, а от свиня за життя займалася фітнесом, міцна та підтягнута занадто)", new DateOnly(2023, 4, 11), 5m, 6 },
                    { new Guid("679e0ee6-ae73-489f-be1e-a41ed24be435"), "vHqgNXnqfcQqILCTRrC1qm2kfMh1", "Піца смачна, атмосфера в закладі приємна, але варто було б трохи оновити інтер'єр.", new DateOnly(2023, 4, 11), 4m, 2 },
                    { new Guid("71dec40b-7482-45a4-83fe-906a24ccda81"), "CCK7UNofA4XUpaSRC5W3RdNoMxm2", "", new DateOnly(2023, 4, 9), 5m, 3 },
                    { new Guid("81d19b62-2f94-4455-8f24-908eb3e010cf"), "D7Cy0pTcq0NszfWnTiiqLyfh0eI3", "Піца по бувовинськи - це смак мого дитинства. Смачно, швидко, бюджетно.", new DateOnly(2023, 4, 15), 5m, 2 },
                    { new Guid("82b12f7a-5762-44a6-ad88-344e38adcfcd"), "8M8DY0scwgR9gfbCvvzfXM6FnQ53", "", new DateOnly(2023, 5, 7), 5m, 2 },
                    { new Guid("89261258-039f-4d7a-8f29-e1296e040681"), "TWkGRrgJeiRbBxFHepdxr5Ye0Rl1", "", new DateOnly(2023, 4, 17), 5m, 1 },
                    { new Guid("89d99ce3-5d78-4e95-9593-b66e3c6242e3"), "8M8DY0scwgR9gfbCvvzfXM6FnQ53", "", new DateOnly(2023, 4, 4), 5m, 6 },
                    { new Guid("a42ac86c-4cca-4b3b-9a06-c2aa2bb1f0b9"), "En6jfcgABnQqw5wNBIpHLvMlB102", "Піца була смачна. Рекомендую)", new DateOnly(2023, 4, 13), 5m, 3 },
                    { new Guid("a5cdc317-80ba-4e47-aedd-cb11887a8d2b"), "D7Cy0pTcq0NszfWnTiiqLyfh0eI3", "", new DateOnly(2023, 4, 5), 5m, 3 },
                    { new Guid("a79ef70f-9ab8-4bc9-8363-fe6a9e78eb18"), "CCK7UNofA4XUpaSRC5W3RdNoMxm2", "Такої смачної їжі давно не куштувала", new DateOnly(2023, 4, 12), 5m, 6 },
                    { new Guid("a9c01746-4b3b-4ca8-8995-3038da2147a8"), "TWkGRrgJeiRbBxFHepdxr5Ye0Rl1", "Шашлик з купою жил, сала, ледь жувався.", new DateOnly(2023, 4, 16), 3m, 6 },
                    { new Guid("b44ceb88-9c53-4da8-a7c4-e9379ace81b7"), "vHqgNXnqfcQqILCTRrC1qm2kfMh1", "", new DateOnly(2023, 4, 11), 5m, 3 },
                    { new Guid("d512da1b-76b1-4604-ad39-54c8dea1794d"), "8M8DY0scwgR9gfbCvvzfXM6FnQ53", "Страви не підписані, мусили вгадувати.", new DateOnly(2023, 4, 14), 4m, 3 },
                    { new Guid("deff1ec1-9ffa-4254-b559-91da46126f0d"), "L31xc7GbqoVTjPFlyyWjDFqhc6u1", "", new DateOnly(2023, 4, 9), 5m, 6 },
                    { new Guid("f1f507de-0385-4ecc-bd99-1e220647378c"), "Q37k5ec7ccWjWuk7mPwMOQr3hoy2", "", new DateOnly(2023, 4, 8), 4m, 6 },
                    { new Guid("fd8f025a-d198-4dbd-8c88-15e737aed73f"), "L31xc7GbqoVTjPFlyyWjDFqhc6u1", "Сама смачна піцца в Че. Я ваш клієнт на віки-вічні", new DateOnly(2023, 4, 12), 5m, 1 },
                    { new Guid("ffc45953-fe64-44e5-8813-62a91bdca4a1"), "vHqgNXnqfcQqILCTRrC1qm2kfMh1", "Вже другий раз не дають прибори.", new DateOnly(2023, 4, 18), 4m, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_chats_user1_id_user2_id",
                table: "chats",
                columns: new[] { "user1_id", "user2_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_chats_user2_id",
                table: "chats",
                column: "user2_id");

            migrationBuilder.CreateIndex(
                name: "IX_chats_messages_ChatId",
                table: "chats_messages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_friendships_user1_id_user2_id",
                table: "friendships",
                columns: new[] { "user1_id", "user2_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_friendships_user2_id",
                table: "friendships",
                column: "user2_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chats_messages");

            migrationBuilder.DropTable(
                name: "friendships");

            migrationBuilder.DropTable(
                name: "chats");

            migrationBuilder.DropTable(
                name: "public_users");

            migrationBuilder.DeleteData(
                table: "moderation",
                keyColumn: "id",
                keyValue: new Guid("002891be-7ebc-4c31-9ca0-1f42d38df160"));

            migrationBuilder.DeleteData(
                table: "moderation",
                keyColumn: "id",
                keyValue: new Guid("17484fe0-88d7-41ca-9988-5a0bd9f6ce79"));

            migrationBuilder.DeleteData(
                table: "moderation",
                keyColumn: "id",
                keyValue: new Guid("5327d999-b744-4966-8cf2-d79a4e29e1ae"));

            migrationBuilder.DeleteData(
                table: "moderation",
                keyColumn: "id",
                keyValue: new Guid("afddd193-3827-43bb-8077-39bdf34eaf9e"));

            migrationBuilder.DeleteData(
                table: "moderation",
                keyColumn: "id",
                keyValue: new Guid("e9c4a9b2-0994-4a02-baa1-d0e6aaf4a357"));

            migrationBuilder.DeleteData(
                table: "reservations",
                keyColumn: "id",
                keyValue: new Guid("1e68496d-8f1c-49e7-b8bd-213c81ebaf4e"));

            migrationBuilder.DeleteData(
                table: "reservations",
                keyColumn: "id",
                keyValue: new Guid("34412304-db23-4e5e-af68-01dc20546d89"));

            migrationBuilder.DeleteData(
                table: "reservations",
                keyColumn: "id",
                keyValue: new Guid("35b3057d-4de9-43b1-8a45-fe920a0f7114"));

            migrationBuilder.DeleteData(
                table: "reservations",
                keyColumn: "id",
                keyValue: new Guid("4df7985b-c640-4ca0-89fd-8f6378e91ee0"));

            migrationBuilder.DeleteData(
                table: "reservations",
                keyColumn: "id",
                keyValue: new Guid("8c2065e5-4cc5-4a35-8070-4c424d30cc9f"));

            migrationBuilder.DeleteData(
                table: "reservations",
                keyColumn: "id",
                keyValue: new Guid("9ee6dc11-e340-480f-926f-1601b685fe16"));

            migrationBuilder.DeleteData(
                table: "reservations",
                keyColumn: "id",
                keyValue: new Guid("a53bb0c7-e667-4ccd-b28d-3758e43e1364"));

            migrationBuilder.DeleteData(
                table: "reservations",
                keyColumn: "id",
                keyValue: new Guid("c9939799-c579-4928-9657-c85c669dc3d7"));

            migrationBuilder.DeleteData(
                table: "reservations",
                keyColumn: "id",
                keyValue: new Guid("d0dc4aa6-e767-4edf-aa52-5aa7de0c65f4"));

            migrationBuilder.DeleteData(
                table: "reservations",
                keyColumn: "id",
                keyValue: new Guid("e2f3c305-e84b-4716-9c61-f3a3f18eaede"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("38bbd354-8222-46a5-9861-5288d316b11f"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("47200fe9-0260-4d3f-a3b8-17855a977379"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("580c00c4-f33c-454e-95df-befe5b7fdf82"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("5ace1260-0027-4136-9685-610d81a2a228"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("679e0ee6-ae73-489f-be1e-a41ed24be435"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("71dec40b-7482-45a4-83fe-906a24ccda81"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("81d19b62-2f94-4455-8f24-908eb3e010cf"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("82b12f7a-5762-44a6-ad88-344e38adcfcd"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("89261258-039f-4d7a-8f29-e1296e040681"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("89d99ce3-5d78-4e95-9593-b66e3c6242e3"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("a42ac86c-4cca-4b3b-9a06-c2aa2bb1f0b9"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("a5cdc317-80ba-4e47-aedd-cb11887a8d2b"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("a79ef70f-9ab8-4bc9-8363-fe6a9e78eb18"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("a9c01746-4b3b-4ca8-8995-3038da2147a8"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("b44ceb88-9c53-4da8-a7c4-e9379ace81b7"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("d512da1b-76b1-4604-ad39-54c8dea1794d"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("deff1ec1-9ffa-4254-b559-91da46126f0d"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("f1f507de-0385-4ecc-bd99-1e220647378c"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("fd8f025a-d198-4dbd-8c88-15e737aed73f"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: new Guid("ffc45953-fe64-44e5-8813-62a91bdca4a1"));

            migrationBuilder.AlterColumn<decimal>(
                name: "mark",
                table: "reviews",
                type: "numeric(1,0)",
                precision: 1,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(1)",
                oldPrecision: 1);

            migrationBuilder.InsertData(
                table: "moderation",
                columns: new[] { "id", "date", "moderator_id", "place_id", "status" },
                values: new object[,]
                {
                    { new Guid("477e6fd5-41ad-4ac8-8526-e80d588fdb73"), new DateTime(2023, 4, 1, 16, 4, 15, 0, DateTimeKind.Unspecified), "Mod2", 4, (short)1 },
                    { new Guid("57e8a5db-87d3-4ec3-bc79-c5fb067f3ca6"), new DateTime(2023, 4, 2, 17, 20, 3, 0, DateTimeKind.Unspecified), "Mod1", 3, (short)2 },
                    { new Guid("9cdab1bf-4b8e-4227-b90a-091eb8d18b5a"), new DateTime(2023, 3, 8, 11, 23, 4, 0, DateTimeKind.Unspecified), "Mod1", 1, (short)2 },
                    { new Guid("ed3c3694-3d82-4b16-986b-e9d55cbce5b6"), new DateTime(2023, 4, 3, 10, 53, 6, 0, DateTimeKind.Unspecified), "Mod2", 6, (short)2 },
                    { new Guid("faa2eb63-6619-4ee1-ac3e-309ebac2539a"), new DateTime(2023, 3, 28, 9, 31, 46, 0, DateTimeKind.Unspecified), "Mod2", 2, (short)2 }
                });

            migrationBuilder.InsertData(
                table: "reservations",
                columns: new[] { "id", "begin_time", "creation_date_time", "end_time", "people_num", "PlaceId", "reserv_date", "status", "table_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("4893095e-503a-4946-b850-2f266afc414e"), new TimeOnly(10, 0, 0), new DateTime(2023, 4, 10, 7, 20, 58, 0, DateTimeKind.Unspecified), new TimeOnly(12, 0, 0), (short)2, 1, new DateOnly(2023, 4, 26), (short)0, 1, "U1" },
                    { new Guid("52667067-14e0-4ebe-ae63-83b18fb3679b"), new TimeOnly(14, 30, 0), new DateTime(2023, 4, 8, 16, 18, 2, 0, DateTimeKind.Unspecified), new TimeOnly(16, 30, 0), (short)2, 1, new DateOnly(2023, 4, 26), (short)0, 1, "U3" },
                    { new Guid("710348f4-796b-467d-b6a5-797d8fe288fe"), new TimeOnly(10, 30, 0), new DateTime(2023, 4, 5, 17, 3, 34, 0, DateTimeKind.Unspecified), new TimeOnly(11, 30, 0), (short)2, 1, new DateOnly(2023, 4, 26), (short)0, 1, "U2" },
                    { new Guid("71ccf9bc-55bd-4535-91cc-ce86c387d998"), new TimeOnly(11, 30, 0), new DateTime(2023, 4, 5, 19, 46, 11, 0, DateTimeKind.Unspecified), new TimeOnly(13, 0, 0), (short)2, 6, new DateOnly(2023, 4, 9), (short)0, 15, "U6" },
                    { new Guid("a99235f4-e450-4807-8af7-733d4a62012d"), new TimeOnly(14, 0, 0), new DateTime(2023, 4, 11, 15, 7, 4, 0, DateTimeKind.Unspecified), new TimeOnly(16, 0, 0), (short)2, 6, new DateOnly(2023, 4, 17), (short)1, 15, "U8" },
                    { new Guid("b32a93f5-73fc-437e-8425-e2fc2d400bfd"), new TimeOnly(14, 0, 0), new DateTime(2023, 4, 21, 18, 15, 53, 0, DateTimeKind.Unspecified), new TimeOnly(16, 0, 0), (short)2, 1, new DateOnly(2023, 4, 26), (short)0, 1, "U60" },
                    { new Guid("c40fa32b-308b-4c7d-86dd-ea4d4f0006b2"), new TimeOnly(13, 0, 0), new DateTime(2023, 4, 19, 13, 6, 12, 0, DateTimeKind.Unspecified), new TimeOnly(15, 0, 0), (short)2, 1, new DateOnly(2023, 4, 26), (short)0, 1, "U5" },
                    { new Guid("dd1cd78c-0ac4-436c-8e38-a853b64b0fa8"), new TimeOnly(14, 0, 0), new DateTime(2023, 4, 9, 8, 57, 15, 0, DateTimeKind.Unspecified), new TimeOnly(16, 0, 0), (short)4, 6, new DateOnly(2023, 4, 10), (short)0, 16, "U7" },
                    { new Guid("deecd260-e7e4-4d8c-bf53-fde34b0417da"), new TimeOnly(12, 0, 0), new DateTime(2023, 4, 16, 21, 46, 27, 0, DateTimeKind.Unspecified), new TimeOnly(14, 0, 0), (short)2, 1, new DateOnly(2023, 4, 26), (short)0, 1, "U4" },
                    { new Guid("e11853fe-9850-4012-85b8-63cd3a83d5d3"), new TimeOnly(16, 0, 0), new DateTime(2023, 4, 20, 23, 42, 9, 0, DateTimeKind.Unspecified), new TimeOnly(18, 30, 0), (short)5, 6, new DateOnly(2023, 4, 29), (short)0, 17, "U9" }
                });

            migrationBuilder.InsertData(
                table: "reviews",
                columns: new[] { "id", "author_id", "comment", "creation_date", "mark", "place_id" },
                values: new object[,]
                {
                    { new Guid("08e78ee1-7d60-49e2-805c-b95f42c0d80c"), "TWkGRrgJeiRbBxFHepdxr5Ye0Rl1", "Шашлик з купою жил, сала, ледь жувався.", new DateOnly(2023, 4, 16), 3m, 6 },
                    { new Guid("0dd65bf5-700f-4de0-a6cf-8f03d5178c43"), "D7Cy0pTcq0NszfWnTiiqLyfh0eI3", "", new DateOnly(2023, 4, 5), 5m, 3 },
                    { new Guid("0f02dd97-cca6-480d-95a3-3daec4305f7b"), "L31xc7GbqoVTjPFlyyWjDFqhc6u1", "", new DateOnly(2023, 4, 9), 5m, 6 },
                    { new Guid("27946048-abe0-445c-9117-23611d2346c5"), "L31xc7GbqoVTjPFlyyWjDFqhc6u1", "Сама смачна піцца в Че. Я ваш клієнт на віки-вічні", new DateOnly(2023, 4, 12), 5m, 1 },
                    { new Guid("2b090499-0416-4e31-99bb-5d15a01c31ad"), "vHqgNXnqfcQqILCTRrC1qm2kfMh1", "Піца смачна, атмосфера в закладі приємна, але варто було б трохи оновити інтер'єр.", new DateOnly(2023, 4, 11), 4m, 2 },
                    { new Guid("3c0f4baa-d2d6-4c77-97b7-ee08ced1c9cb"), "jidZO6WQMiYOSRIEE5ONUREmRpd2", "На жаль, не сподобалось, окрошка була пересолена, овочі в салаті в'ялі...", new DateOnly(2023, 5, 3), 3m, 2 },
                    { new Guid("3d441ee5-e318-4ef8-9335-57e9ada4b0f4"), "TWkGRrgJeiRbBxFHepdxr5Ye0Rl1", "", new DateOnly(2023, 4, 17), 5m, 1 },
                    { new Guid("4c76a083-1d7b-45ed-959f-3ff63b8a3c58"), "Q37k5ec7ccWjWuk7mPwMOQr3hoy2", "", new DateOnly(2023, 4, 8), 4m, 6 },
                    { new Guid("514caade-65fe-43a5-a0dd-d16dc68199de"), "En6jfcgABnQqw5wNBIpHLvMlB102", "", new DateOnly(2023, 4, 14), 5m, 1 },
                    { new Guid("53af70a2-71f5-4475-98d0-3dc48c17292c"), "CCK7UNofA4XUpaSRC5W3RdNoMxm2", "", new DateOnly(2023, 4, 9), 5m, 3 },
                    { new Guid("59ac935f-879b-4e6d-99ef-ed8c26c52606"), "D7Cy0pTcq0NszfWnTiiqLyfh0eI3", "Копчене курча бездоганне, а от свиня за життя займалася фітнесом, міцна та підтягнута занадто)", new DateOnly(2023, 4, 11), 5m, 6 },
                    { new Guid("827f5085-68b4-4258-9b84-14cc148b3e7e"), "vHqgNXnqfcQqILCTRrC1qm2kfMh1", "", new DateOnly(2023, 4, 11), 5m, 3 },
                    { new Guid("85d34275-6637-4203-8c57-f581731b7d76"), "vHqgNXnqfcQqILCTRrC1qm2kfMh1", "Вже другий раз не дають прибори.", new DateOnly(2023, 4, 18), 4m, 1 },
                    { new Guid("8939577e-b11a-48fa-af60-f611abbd3039"), "8M8DY0scwgR9gfbCvvzfXM6FnQ53", "", new DateOnly(2023, 5, 7), 5m, 2 },
                    { new Guid("9f8d3391-61b2-4258-98aa-1bf469ed806c"), "jidZO6WQMiYOSRIEE5ONUREmRpd2", "", new DateOnly(2023, 4, 16), 5m, 6 },
                    { new Guid("ae62422a-ac55-4b53-af28-5e59cc7c1237"), "8M8DY0scwgR9gfbCvvzfXM6FnQ53", "", new DateOnly(2023, 4, 4), 5m, 6 },
                    { new Guid("b1c96429-c1b0-417e-bad3-02ddd50f64d7"), "CCK7UNofA4XUpaSRC5W3RdNoMxm2", "Такої смачної їжі давно не куштувала", new DateOnly(2023, 4, 12), 5m, 6 },
                    { new Guid("b8d3307c-eb89-4a7f-89c8-0d41cd136bdd"), "En6jfcgABnQqw5wNBIpHLvMlB102", "Піца була смачна. Рекомендую)", new DateOnly(2023, 4, 13), 5m, 3 },
                    { new Guid("d553f1a8-3d20-4ca1-8ecb-50c28bce4d76"), "D7Cy0pTcq0NszfWnTiiqLyfh0eI3", "Піца по бувовинськи - це смак мого дитинства. Смачно, швидко, бюджетно.", new DateOnly(2023, 4, 15), 5m, 2 },
                    { new Guid("fb186b49-72ce-45a8-a71b-7c6210b704cc"), "8M8DY0scwgR9gfbCvvzfXM6FnQ53", "Страви не підписані, мусили вгадувати.", new DateOnly(2023, 4, 14), 4m, 3 }
                });
        }
    }
}
