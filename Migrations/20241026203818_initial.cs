using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenGarden.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Gardenership",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    GenderIdentity = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    State = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Zip = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopCropCropId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gardenership", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Gardenership_TopCrops_TopCropCropId",
                        column: x => x.TopCropCropId,
                        principalTable: "TopCrops",
                        principalColumn: "CropId");
                });

            migrationBuilder.InsertData(
                table: "Gardenership",
                columns: new[] { "ID", "Address", "Cell", "City", "Email", "FirstName", "GenderIdentity", "LastName", "State", "TopCropCropId", "Zip" },
                values: new object[,]
                {
                    { 1, null, null, null, "freyaplaya@gmail.com", "Freya", null, "Greene", null, null, null },
                    { 2, null, null, null, "victorharwood@gmail.com", "Victor", null, "Harwood", null, null, null },
                    { 3, null, null, null, "luisnotluis@gmail.com", "Luis", null, "Greene", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "TopCrops",
                columns: new[] { "CropId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Native to Asia. Part of the nightshade family.", "Eggplant" },
                    { 2, "Part of the nightshade family. Native to the Andes of South America, around Peru.", "Tomato" },
                    { 3, "Part of the nightshade family. Native to the Andes of South America.", "Potato" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gardenership_TopCropCropId",
                table: "Gardenership",
                column: "TopCropCropId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gardenership");

            migrationBuilder.DropTable(
                name: "TopCrops");
        }
    }
}
