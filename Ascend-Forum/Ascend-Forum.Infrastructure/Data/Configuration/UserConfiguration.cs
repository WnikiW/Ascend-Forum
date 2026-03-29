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
            }
        };
    }
}
