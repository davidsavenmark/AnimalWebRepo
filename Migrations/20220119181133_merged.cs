using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalCollection.Migrations
{
    public partial class merged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AnimalTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalTypes", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AnimalTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Animals_AnimalTypes_AnimalTypeID",
                        column: x => x.AnimalTypeID,
                        principalTable: "AnimalTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AnimalTypes",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Mammal" },
                    { 2, "Bird" },
                    { 3, "Fish" },
                    { 4, "Reptile" },
                    { 5, "Insect" },
                    { 6, "Amphibian" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "ID", "AnimalTypeID", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Dog" },
                    { 2, 2, "Raven" },
                    { 3, 3, "Salmon" },
                    { 4, 4, "Bearded Dragon" },
                    { 5, 5, "Ladybird" },
                    { 6, 6, "Frog" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_AnimalTypeID",
                table: "Animals",
                column: "AnimalTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "AnimalTypes");
        }
    }
}
