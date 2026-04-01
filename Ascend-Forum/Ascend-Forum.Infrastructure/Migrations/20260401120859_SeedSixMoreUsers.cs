using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ascend_Forum.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedSixMoreUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AscendName", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b1a1c1d1-e111-41a1-9111-111111111111", 0, "Seid", "e3a1c1d1-e111-41a1-9111-111111111113", "jeff@example.com", false, "Jeff", "Seid", false, null, "JEFF@EXAMPLE.COM", "JEFF_SEID", "AQAAAAEAACcQAAAAE...", null, false, "d2a1c1d1-e111-41a1-9111-111111111112", false, "jeff_seid" },
                    { "b2a2c2d2-e222-42a2-9222-222222222222", 0, "Zyzz", "e3a2c2d2-e222-42a2-9222-222222222224", "zyzz@example.com", false, "Aziz", "Shavershian", false, null, "ZYZZ@EXAMPLE.COM", "ZYZZ", "AQAAAAEAACcQAAAAE...", null, false, "d2a2c2d2-e222-42a2-9222-222222222223", false, "zyzz" },
                    { "b3a3c3d3-e333-43a3-9333-333333333333", 0, "Chestbrah", "e3a3c3d3-e333-43a3-9333-333333333335", "chestbrah@example.com", false, "Said", "Shavershian", false, null, "CHESTBRAH@EXAMPLE.COM", "CHESTBRAH", "AQAAAAEAACcQAAAAE...", null, false, "d3a3c3d3-e333-43a3-9333-333333333334", false, "chestbrah" },
                    { "b4a4c4d4-e444-44a4-9444-444444444444", 0, "Dorian", "e4a4c4d4-e444-44a4-9444-444444444446", "dorian@example.com", false, "Dorian", "Saraci", false, null, "DORIAN@EXAMPLE.COM", "DORIAN_SARACI", "AQAAAAEAACcQAAAAE...", null, false, "d4a4c4d4-e444-44a4-9444-444444444445", false, "dorian_saraci" },
                    { "b5a5c5d5-e555-45a5-9555-555555555555", 0, "Skywalker", "e5a5c5d5-e555-45a5-9555-555555555557", "jon@example.com", false, "Jon", "Skywalker", false, null, "JON@EXAMPLE.COM", "JON_SKYWALKER", "AQAAAAEAACcQAAAAE...", null, false, "d5a5c5d5-e555-45a5-9555-555555555556", false, "jon_skywalker" },
                    { "b6a6c6d6-e666-46a6-9666-666666666666", 0, "TNF", "e6a6c6d6-e666-46a6-9666-666666666668", "tnf@example.com", false, "TNF", "Coach", false, null, "TNF@EXAMPLE.COM", "TNF", "AQAAAAEAACcQAAAAE...", null, false, "d6a6c6d6-e666-46a6-9666-666666666667", false, "tnf" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b1a1c1d1-e111-41a1-9111-111111111111");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2a2c2d2-e222-42a2-9222-222222222222");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b3a3c3d3-e333-43a3-9333-333333333333");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4a4c4d4-e444-44a4-9444-444444444444");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5a5c5d5-e555-45a5-9555-555555555555");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b6a6c6d6-e666-46a6-9666-666666666666");
        }
    }
}
