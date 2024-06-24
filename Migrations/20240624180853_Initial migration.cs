using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RevenueRecognitionSystem.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    KRS = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.KRS);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PESEL = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PESEL);
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "KRS", "Address", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { "000123456789", "rondo Daszyńskiego 2, 00-843 Warsaw", "contact@techcompany.com", "Tech Company", "123456789" },
                    { "000987654321", "al. Jana Pawła II 19, 00-854 Warsaw", "contact@financecompany.com", "Finance Company", "987654321" }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "PESEL", "Address", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { "01987654321", "plac Politechniki 1, 00-661 Warsaw", "jane.doe@gmail.com", "Jane", "Doe", "987654321" },
                    { "12345678901", "Koszykowa 86, 02-008 Warsaw", "john.doe@gmail.com", "John", "Doe", "123456789" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
