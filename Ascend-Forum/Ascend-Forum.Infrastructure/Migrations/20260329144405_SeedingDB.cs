using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ascend_Forum.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AscendName", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "user1-id-guid", 0, "JohnD", "32f7a925-a319-4b11-a57c-3249afa12826", "john@example.com", false, "John", "Doe", false, null, "JOHN@EXAMPLE.COM", "JOHN_DOE", "AQAAAAEAACcQAAAAE...", null, false, "bfc71631-94dc-4e96-a1f5-a8c2a873e76b", false, "john_doe" },
                    { "user2-id-guid", 0, "JaneS", "837a16f2-e19f-42fb-8e2c-c88c95b6e3bd", "jane@example.com", false, "Jane", "Smith", false, null, "JANE@EXAMPLE.COM", "JANE_SMITH", "AQAAAAEAACcQAAAAE...", null, false, "a9a9e9e1-1c77-4045-beba-4a17bc172051", false, "jane_smith" },
                    { "user3-id-guid", 0, "BobB", "afc3f667-5c62-44fc-9dea-fe421ef547b3", "bob@example.com", false, "Bob", "Builder", false, null, "BOB@EXAMPLE.COM", "BOB_BUILDER", "AQAAAAEAACcQAAAAE...", null, false, "553fb997-9c9b-4019-a567-f696ceb59244", false, "bob_builder" },
                    { "user4-id-guid", 0, "AliceW", "be68dcd3-adcd-489c-8654-a49e56c7b2e4", "alice@example.com", false, "Alice", "Wonder", false, null, "ALICE@EXAMPLE.COM", "ALICE_WONDER", "AQAAAAEAACcQAAAAE...", null, false, "76927ff1-c7c3-465e-8377-aaadbe1a947d", false, "alice_wonder" },
                    { "user5-id-guid", 0, "CharlieB", "dc2e087c-0ae5-4027-80ad-35cd817fe2ad", "charlie@example.com", false, "Charlie", "Brown", false, null, "CHARLIE@EXAMPLE.COM", "CHARLIE_BROWN", "AQAAAAEAACcQAAAAE...", null, false, "b2654e37-220f-4fc3-8987-085a93850d9f", false, "charlie_brown" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "Latest trends in technology and software development.", "https://picsum.photos/id/1/200/300", "Technology" },
                    { 2, "Discuss everything about video games and consoles.", "https://picsum.photos/id/2/200/300", "Gaming" },
                    { 3, "Space, Biology, Physics and more.", "https://picsum.photos/id/3/200/300", "Science" },
                    { 4, "Coding challenges, best practices and career advice.", "https://picsum.photos/id/4/200/300", "Programming" },
                    { 5, "Health, travel and general discussion.", "https://picsum.photos/id/5/200/300", "Lifestyle" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedOn", "CreatorId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "This is the content for post 1 in category 1. It contains some useful information.", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user1-id-guid", "Post 1 in Category 1" },
                    { 2, 1, "This is the content for post 2 in category 1. It contains some useful information.", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user2-id-guid", "Post 2 in Category 1" },
                    { 3, 1, "This is the content for post 3 in category 1. It contains some useful information.", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user3-id-guid", "Post 3 in Category 1" },
                    { 4, 1, "This is the content for post 4 in category 1. It contains some useful information.", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user4-id-guid", "Post 4 in Category 1" },
                    { 5, 1, "This is the content for post 5 in category 1. It contains some useful information.", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user5-id-guid", "Post 5 in Category 1" },
                    { 6, 2, "This is the content for post 1 in category 2. It contains some useful information.", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user1-id-guid", "Post 1 in Category 2" },
                    { 7, 2, "This is the content for post 2 in category 2. It contains some useful information.", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user2-id-guid", "Post 2 in Category 2" },
                    { 8, 2, "This is the content for post 3 in category 2. It contains some useful information.", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user3-id-guid", "Post 3 in Category 2" },
                    { 9, 2, "This is the content for post 4 in category 2. It contains some useful information.", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user4-id-guid", "Post 4 in Category 2" },
                    { 10, 2, "This is the content for post 5 in category 2. It contains some useful information.", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user5-id-guid", "Post 5 in Category 2" },
                    { 11, 3, "This is the content for post 1 in category 3. It contains some useful information.", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user1-id-guid", "Post 1 in Category 3" },
                    { 12, 3, "This is the content for post 2 in category 3. It contains some useful information.", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user2-id-guid", "Post 2 in Category 3" },
                    { 13, 3, "This is the content for post 3 in category 3. It contains some useful information.", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user3-id-guid", "Post 3 in Category 3" },
                    { 14, 3, "This is the content for post 4 in category 3. It contains some useful information.", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user4-id-guid", "Post 4 in Category 3" },
                    { 15, 3, "This is the content for post 5 in category 3. It contains some useful information.", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user5-id-guid", "Post 5 in Category 3" },
                    { 16, 4, "This is the content for post 1 in category 4. It contains some useful information.", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user1-id-guid", "Post 1 in Category 4" },
                    { 17, 4, "This is the content for post 2 in category 4. It contains some useful information.", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user2-id-guid", "Post 2 in Category 4" },
                    { 18, 4, "This is the content for post 3 in category 4. It contains some useful information.", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user3-id-guid", "Post 3 in Category 4" },
                    { 19, 4, "This is the content for post 4 in category 4. It contains some useful information.", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user4-id-guid", "Post 4 in Category 4" },
                    { 20, 4, "This is the content for post 5 in category 4. It contains some useful information.", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user5-id-guid", "Post 5 in Category 4" },
                    { 21, 5, "This is the content for post 1 in category 5. It contains some useful information.", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user1-id-guid", "Post 1 in Category 5" },
                    { 22, 5, "This is the content for post 2 in category 5. It contains some useful information.", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user2-id-guid", "Post 2 in Category 5" },
                    { 23, 5, "This is the content for post 3 in category 5. It contains some useful information.", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user3-id-guid", "Post 3 in Category 5" },
                    { 24, 5, "This is the content for post 4 in category 5. It contains some useful information.", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user4-id-guid", "Post 4 in Category 5" },
                    { 25, 5, "This is the content for post 5 in category 5. It contains some useful information.", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user5-id-guid", "Post 5 in Category 5" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedOn", "CreatorId", "ParentId", "PostId" },
                values: new object[,]
                {
                    { 1, "Comment 1 for post 1. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user1-id-guid", null, 1 },
                    { 2, "Comment 2 for post 1. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user2-id-guid", null, 1 },
                    { 3, "Comment 1 for post 2. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user3-id-guid", null, 2 },
                    { 4, "Comment 2 for post 2. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user4-id-guid", null, 2 },
                    { 5, "Comment 1 for post 3. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user5-id-guid", null, 3 },
                    { 6, "Comment 2 for post 3. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user1-id-guid", null, 3 },
                    { 7, "Comment 1 for post 4. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user2-id-guid", null, 4 },
                    { 8, "Comment 2 for post 4. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user3-id-guid", null, 4 },
                    { 9, "Comment 1 for post 5. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user4-id-guid", null, 5 },
                    { 10, "Comment 2 for post 5. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user5-id-guid", null, 5 },
                    { 11, "Comment 1 for post 6. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user1-id-guid", null, 6 },
                    { 12, "Comment 2 for post 6. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user2-id-guid", null, 6 },
                    { 13, "Comment 1 for post 7. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user3-id-guid", null, 7 },
                    { 14, "Comment 2 for post 7. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user4-id-guid", null, 7 },
                    { 15, "Comment 1 for post 8. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user5-id-guid", null, 8 },
                    { 16, "Comment 2 for post 8. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user1-id-guid", null, 8 },
                    { 17, "Comment 1 for post 9. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user2-id-guid", null, 9 },
                    { 18, "Comment 2 for post 9. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user3-id-guid", null, 9 },
                    { 19, "Comment 1 for post 10. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user4-id-guid", null, 10 },
                    { 20, "Comment 2 for post 10. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user5-id-guid", null, 10 },
                    { 21, "Comment 1 for post 11. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user1-id-guid", null, 11 },
                    { 22, "Comment 2 for post 11. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user2-id-guid", null, 11 },
                    { 23, "Comment 1 for post 12. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user3-id-guid", null, 12 },
                    { 24, "Comment 2 for post 12. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user4-id-guid", null, 12 },
                    { 25, "Comment 1 for post 13. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user5-id-guid", null, 13 },
                    { 26, "Comment 2 for post 13. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user1-id-guid", null, 13 },
                    { 27, "Comment 1 for post 14. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user2-id-guid", null, 14 },
                    { 28, "Comment 2 for post 14. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user3-id-guid", null, 14 },
                    { 29, "Comment 1 for post 15. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user4-id-guid", null, 15 },
                    { 30, "Comment 2 for post 15. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user5-id-guid", null, 15 },
                    { 31, "Comment 1 for post 16. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user1-id-guid", null, 16 },
                    { 32, "Comment 2 for post 16. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user2-id-guid", null, 16 },
                    { 33, "Comment 1 for post 17. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user3-id-guid", null, 17 },
                    { 34, "Comment 2 for post 17. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user4-id-guid", null, 17 },
                    { 35, "Comment 1 for post 18. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user5-id-guid", null, 18 },
                    { 36, "Comment 2 for post 18. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user1-id-guid", null, 18 },
                    { 37, "Comment 1 for post 19. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user2-id-guid", null, 19 },
                    { 38, "Comment 2 for post 19. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user3-id-guid", null, 19 },
                    { 39, "Comment 1 for post 20. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user4-id-guid", null, 20 },
                    { 40, "Comment 2 for post 20. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user5-id-guid", null, 20 },
                    { 41, "Comment 1 for post 21. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user1-id-guid", null, 21 },
                    { 42, "Comment 2 for post 21. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user2-id-guid", null, 21 },
                    { 43, "Comment 1 for post 22. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user3-id-guid", null, 22 },
                    { 44, "Comment 2 for post 22. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user4-id-guid", null, 22 },
                    { 45, "Comment 1 for post 23. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user5-id-guid", null, 23 },
                    { 46, "Comment 2 for post 23. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user1-id-guid", null, 23 },
                    { 47, "Comment 1 for post 24. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user2-id-guid", null, 24 },
                    { 48, "Comment 2 for post 24. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user3-id-guid", null, 24 },
                    { 49, "Comment 1 for post 25. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user4-id-guid", null, 25 },
                    { 50, "Comment 2 for post 25. Nice post!", new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "user5-id-guid", null, 25 }
                });

            migrationBuilder.InsertData(
                table: "CommentReactions",
                columns: new[] { "Id", "CommentId", "CreatedOn", "ReactionType", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 2, "user2-id-guid" },
                    { 2, 2, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, "user3-id-guid" },
                    { 3, 3, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 2, "user4-id-guid" },
                    { 4, 4, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, "user5-id-guid" },
                    { 5, 5, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 2, "user1-id-guid" },
                    { 6, 6, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, "user2-id-guid" },
                    { 7, 7, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 2, "user3-id-guid" },
                    { 8, 8, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, "user4-id-guid" },
                    { 9, 9, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 2, "user5-id-guid" },
                    { 10, 10, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, "user1-id-guid" },
                    { 11, 11, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 2, "user2-id-guid" },
                    { 12, 12, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, "user3-id-guid" },
                    { 13, 13, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 2, "user4-id-guid" },
                    { 14, 14, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, "user5-id-guid" },
                    { 15, 15, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 2, "user1-id-guid" },
                    { 16, 16, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, "user2-id-guid" },
                    { 17, 17, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 2, "user3-id-guid" },
                    { 18, 18, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, "user4-id-guid" },
                    { 19, 19, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 2, "user5-id-guid" },
                    { 20, 20, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, "user1-id-guid" },
                    { 21, 21, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 2, "user2-id-guid" },
                    { 22, 22, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, "user3-id-guid" },
                    { 23, 23, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 2, "user4-id-guid" },
                    { 24, 24, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, "user5-id-guid" },
                    { 25, 25, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 2, "user1-id-guid" },
                    { 26, 26, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, "user2-id-guid" },
                    { 27, 27, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 2, "user3-id-guid" },
                    { 28, 28, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, "user4-id-guid" },
                    { 29, 29, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 2, "user5-id-guid" },
                    { 30, 30, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, "user1-id-guid" },
                    { 31, 31, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 2, "user2-id-guid" },
                    { 32, 32, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, "user3-id-guid" },
                    { 33, 33, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 2, "user4-id-guid" },
                    { 34, 34, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, "user5-id-guid" },
                    { 35, 35, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 2, "user1-id-guid" },
                    { 36, 36, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, "user2-id-guid" },
                    { 37, 37, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 2, "user3-id-guid" },
                    { 38, 38, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, "user4-id-guid" },
                    { 39, 39, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 2, "user5-id-guid" },
                    { 40, 40, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, "user1-id-guid" },
                    { 41, 41, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 2, "user2-id-guid" },
                    { 42, 42, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, "user3-id-guid" },
                    { 43, 43, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 2, "user4-id-guid" },
                    { 44, 44, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, "user5-id-guid" },
                    { 45, 45, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 2, "user1-id-guid" },
                    { 46, 46, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, "user2-id-guid" },
                    { 47, 47, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 2, "user3-id-guid" },
                    { 48, 48, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, "user4-id-guid" },
                    { 49, 49, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 2, "user5-id-guid" },
                    { 50, 50, new DateTime(2026, 3, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, "user1-id-guid" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "CommentReactions",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1-id-guid");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2-id-guid");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3-id-guid");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user4-id-guid");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user5-id-guid");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
