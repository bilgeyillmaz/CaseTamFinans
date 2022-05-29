using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class FirstInitialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WriterFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishingHouse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfPages = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "BookName", "CategoryName", "NumberOfPages", "PublishingHouse", "Status", "WriterFullName" },
                values: new object[,]
                {
                    { 1, "1984", "Bilim-Kurgu, Distopik-Kurgu", 352, "MK Publications", true, "George Orwell" },
                    { 2, "Varolmanın Dayanılmaz Hafifliği", "Roman", 320, "HarperCollins Publishers", true, "Milan Kundera" },
                    { 3, "Hayvan Çiftliği", "Distopik Kurgu", 112, "Secker & Warburg", true, "George Orwell" },
                    { 4, "Martı Jonathan Livingston", "Kişisel Gelişim", 96, "Harpercollins", true, "Richard Bach" },
                    { 5, "Anne Frank'ın Hatıra Defteri", "Otobiyografi", 356, "Puffin", true, "Anne Frank" },
                    { 6, "Fahrenheit 451", "Bilim-Kurgu", 192, "HarperCollins", true, "Ray Bradbury" },
                    { 7, "Kürk Mantolu Madonna", "Roman", 160, "Penguin Classics", true, "Sabahattin Ali" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
