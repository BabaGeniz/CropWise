using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CropWise.Migrations
{
    /// <inheritdoc />
    public partial class updatefarmertableforeignkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Farmers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Farmers");
        }
    }
}
