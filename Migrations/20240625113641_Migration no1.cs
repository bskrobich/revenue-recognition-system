using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RevenueRecognitionSystem.Migrations
{
    /// <inheritdoc />
    public partial class Migrationno1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Software",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Software", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Software_Version",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Version = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SoftwareId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Software_Version", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Software_Version_Software_SoftwareId",
                        column: x => x.SoftwareId,
                        principalTable: "Software",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Software",
                columns: new[] { "Id", "Category", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Business", "A collection of applications and services available from Microsoft servers.", "Microsoft 365" },
                    { 2, "Graphic Design", "A graphic program intended for creating and processing raster graphics.", "Adobe Photoshop" }
                });

            migrationBuilder.InsertData(
                table: "Software_Version",
                columns: new[] { "Id", "SoftwareId", "Version" },
                values: new object[,]
                {
                    { 1, 1, 2405m },
                    { 2, 1, 2406m },
                    { 3, 2, 25.8m },
                    { 4, 2, 25.9m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Software_Version_SoftwareId",
                table: "Software_Version",
                column: "SoftwareId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Software_Version");

            migrationBuilder.DropTable(
                name: "Software");
        }
    }
}
