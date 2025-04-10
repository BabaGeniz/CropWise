using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CropWise.Migrations
{
    /// <inheritdoc />
    public partial class addcropandcrophealthtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmId = table.Column<int>(type: "int", nullable: false),
                    CropName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CropType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CropDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePlanted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Crops_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CropHealthReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CropId = table.Column<int>(type: "int", nullable: false),
                    HealthScore = table.Column<int>(type: "int", nullable: false),
                    AnalysisDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateGenerated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Recommendations = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CropHealthReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CropHealthReports_Crops_CropId",
                        column: x => x.CropId,
                        principalTable: "Crops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CropHealthReports_CropId",
                table: "CropHealthReports",
                column: "CropId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Crops_FarmId",
                table: "Crops",
                column: "FarmId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CropHealthReports");

            migrationBuilder.DropTable(
                name: "Crops");
        }
    }
}
