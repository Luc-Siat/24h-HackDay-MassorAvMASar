using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Api.Migrations
{
    /// <inheritdoc />
    public partial class insertRaceInDog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Race",
                table: "Dogs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Race",
                table: "Dogs");
        }
    }
}
