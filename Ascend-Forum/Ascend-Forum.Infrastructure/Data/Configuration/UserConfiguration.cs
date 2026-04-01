using Ascend_Forum.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ascend_Forum.Infrastructure.Data.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(SeedUsers());
    }

    private IEnumerable<User> SeedUsers()
    {
        return new List<User>
        {
            new User
            {
                Id = "user1-id-guid",
                UserName = "john_doe",
                NormalizedUserName = "JOHN_DOE",
                Email = "john@example.com",
                NormalizedEmail = "JOHN@EXAMPLE.COM",
                FirstName = "John",
                LastName = "Doe",
                AscendName = "JohnD",
                PasswordHash = "AQAAAAEAACcQAAAAE...",
                SecurityStamp = "bfc71631-94dc-4e96-a1f5-a8c2a873e76b",
                ConcurrencyStamp = "32f7a925-a319-4b11-a57c-3249afa12826"
            },
            new User
            {
                Id = "user2-id-guid",
                UserName = "jane_smith",
                NormalizedUserName = "JANE_SMITH",
                Email = "jane@example.com",
                NormalizedEmail = "JANE@EXAMPLE.COM",
                FirstName = "Jane",
                LastName = "Smith",
                AscendName = "JaneS",
                PasswordHash = "AQAAAAEAACcQAAAAE...",
                SecurityStamp = "a9a9e9e1-1c77-4045-beba-4a17bc172051",
                ConcurrencyStamp = "837a16f2-e19f-42fb-8e2c-c88c95b6e3bd"
            },
            new User
            {
                Id = "user3-id-guid",
                UserName = "bob_builder",
                NormalizedUserName = "BOB_BUILDER",
                Email = "bob@example.com",
                NormalizedEmail = "BOB@EXAMPLE.COM",
                FirstName = "Bob",
                LastName = "Builder",
                AscendName = "BobB",
                PasswordHash = "AQAAAAEAACcQAAAAE...",
                SecurityStamp = "553fb997-9c9b-4019-a567-f696ceb59244",
                ConcurrencyStamp = "afc3f667-5c62-44fc-9dea-fe421ef547b3"
            },
            new User
            {
                Id = "user4-id-guid",
                UserName = "alice_wonder",
                NormalizedUserName = "ALICE_WONDER",
                Email = "alice@example.com",
                NormalizedEmail = "ALICE@EXAMPLE.COM",
                FirstName = "Alice",
                LastName = "Wonder",
                AscendName = "AliceW",
                PasswordHash = "AQAAAAEAACcQAAAAE...",
                SecurityStamp = "76927ff1-c7c3-465e-8377-aaadbe1a947d",
                ConcurrencyStamp = "be68dcd3-adcd-489c-8654-a49e56c7b2e4"
            },
            new User
            {
                Id = "user5-id-guid",
                UserName = "charlie_brown",
                NormalizedUserName = "CHARLIE_BROWN",
                Email = "charlie@example.com",
                NormalizedEmail = "CHARLIE@EXAMPLE.COM",
                FirstName = "Charlie",
                LastName = "Brown",
                AscendName = "CharlieB",
                PasswordHash = "AQAAAAEAACcQAAAAE...",
                SecurityStamp = "b2654e37-220f-4fc3-8987-085a93850d9f",
                ConcurrencyStamp = "dc2e087c-0ae5-4027-80ad-35cd817fe2ad"
            },
            new User
            {
                Id = "b1a1c1d1-e111-41a1-9111-111111111111",
                UserName = "jeff_seid",
                NormalizedUserName = "JEFF_SEID",
                Email = "jeff@example.com",
                NormalizedEmail = "JEFF@EXAMPLE.COM",
                FirstName = "Jeff",
                LastName = "Seid",
                AscendName = "Seid",
                PasswordHash = "AQAAAAEAACcQAAAAE...",
                SecurityStamp = "d2a1c1d1-e111-41a1-9111-111111111112",
                ConcurrencyStamp = "e3a1c1d1-e111-41a1-9111-111111111113"
            },
            new User
            {
                Id = "b2a2c2d2-e222-42a2-9222-222222222222",
                UserName = "zyzz",
                NormalizedUserName = "ZYZZ",
                Email = "zyzz@example.com",
                NormalizedEmail = "ZYZZ@EXAMPLE.COM",
                FirstName = "Aziz",
                LastName = "Shavershian",
                AscendName = "Zyzz",
                PasswordHash = "AQAAAAEAACcQAAAAE...",
                SecurityStamp = "d2a2c2d2-e222-42a2-9222-222222222223",
                ConcurrencyStamp = "e3a2c2d2-e222-42a2-9222-222222222224"
            },
            new User
            {
                Id = "b3a3c3d3-e333-43a3-9333-333333333333",
                UserName = "chestbrah",
                NormalizedUserName = "CHESTBRAH",
                Email = "chestbrah@example.com",
                NormalizedEmail = "CHESTBRAH@EXAMPLE.COM",
                FirstName = "Said",
                LastName = "Shavershian",
                AscendName = "Chestbrah",
                PasswordHash = "AQAAAAEAACcQAAAAE...",
                SecurityStamp = "d3a3c3d3-e333-43a3-9333-333333333334",
                ConcurrencyStamp = "e3a3c3d3-e333-43a3-9333-333333333335"
            },
            new User
            {
                Id = "b4a4c4d4-e444-44a4-9444-444444444444",
                UserName = "dorian_saraci",
                NormalizedUserName = "DORIAN_SARACI",
                Email = "dorian@example.com",
                NormalizedEmail = "DORIAN@EXAMPLE.COM",
                FirstName = "Dorian",
                LastName = "Saraci",
                AscendName = "Dorian",
                PasswordHash = "AQAAAAEAACcQAAAAE...",
                SecurityStamp = "d4a4c4d4-e444-44a4-9444-444444444445",
                ConcurrencyStamp = "e4a4c4d4-e444-44a4-9444-444444444446"
            },
            new User
            {
                Id = "b5a5c5d5-e555-45a5-9555-555555555555",
                UserName = "jon_skywalker",
                NormalizedUserName = "JON_SKYWALKER",
                Email = "jon@example.com",
                NormalizedEmail = "JON@EXAMPLE.COM",
                FirstName = "Jon",
                LastName = "Skywalker",
                AscendName = "Skywalker",
                PasswordHash = "AQAAAAEAACcQAAAAE...",
                SecurityStamp = "d5a5c5d5-e555-45a5-9555-555555555556",
                ConcurrencyStamp = "e5a5c5d5-e555-45a5-9555-555555555557"
            },
            new User
            {
                Id = "b6a6c6d6-e666-46a6-9666-666666666666",
                UserName = "tnf",
                NormalizedUserName = "TNF",
                Email = "tnf@example.com",
                NormalizedEmail = "TNF@EXAMPLE.COM",
                FirstName = "TNF",
                LastName = "Coach",
                AscendName = "TNF",
                PasswordHash = "AQAAAAEAACcQAAAAE...",
                SecurityStamp = "d6a6c6d6-e666-46a6-9666-666666666667",
                ConcurrencyStamp = "e6a6c6d6-e666-46a6-9666-666666666668"
            },
        };
    }
}
