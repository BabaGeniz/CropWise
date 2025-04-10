using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CropWise.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCropTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CropDescription",
                table: "Crops");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CropDescription",
                table: "Crops",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
