using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ascend_Forum.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AscendNameAddedUniqueConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AscendName",
                table: "AspNetUsers",
                column: "AscendName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AscendName",
                table: "AspNetUsers");
        }
    }
}
