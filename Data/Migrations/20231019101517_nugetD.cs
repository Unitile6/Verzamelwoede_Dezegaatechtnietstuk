using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Verzamelwoede_Dezegaatechtnietstuk.Data.Migrations
{
    /// <inheritdoc />
    public partial class nugetD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Favourite",
                table: "Item",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Favourite",
                table: "Item");
        }
    }
}
