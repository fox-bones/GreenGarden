using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenGarden.Migrations
{
    public partial class TopCropInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TopCropCropId",
                table: "Gardenership",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TopCrops",
                columns: table => new
                {
                    CropId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopCrops", x => x.CropId);
                });

            migrationBuilder.InsertData(
                table: "TopCrops",
                columns: new[] { "CropId", "Description", "Name" },
                values: new object[] { 1, "Native to Asia. Part of the nightshade family.", "Eggplant" });

            migrationBuilder.InsertData(
                table: "TopCrops",
                columns: new[] { "CropId", "Description", "Name" },
                values: new object[] { 2, "Part of the nightshade family.", "Tomato" });

            migrationBuilder.InsertData(
                table: "TopCrops",
                columns: new[] { "CropId", "Description", "Name" },
                values: new object[] { 3, "Part of the nightshade family.", "Potato" });

            migrationBuilder.CreateIndex(
                name: "IX_Gardenership_TopCropCropId",
                table: "Gardenership",
                column: "TopCropCropId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gardenership_TopCrops_TopCropCropId",
                table: "Gardenership",
                column: "TopCropCropId",
                principalTable: "TopCrops",
                principalColumn: "CropId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gardenership_TopCrops_TopCropCropId",
                table: "Gardenership");

            migrationBuilder.DropTable(
                name: "TopCrops");

            migrationBuilder.DropIndex(
                name: "IX_Gardenership_TopCropCropId",
                table: "Gardenership");

            migrationBuilder.DropColumn(
                name: "TopCropCropId",
                table: "Gardenership");
        }
    }
}
