using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Verzamelwoede_Dezegaatechtnietstuk.Data.Migrations
{
    /// <inheritdoc />
    public partial class Nugetc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "ValueFactor",
                table: "Category",
                type: "real",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValueFactor",
                table: "Category");
        }
    }
}
