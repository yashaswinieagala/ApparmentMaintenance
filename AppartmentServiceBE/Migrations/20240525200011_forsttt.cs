using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppartmentServiceBE.Migrations
{
    /// <inheritdoc />
    public partial class forsttt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApartMentDetails",
                columns: table => new
                {
                    flatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    flatNo = table.Column<int>(type: "int", nullable: false),
                    complexId = table.Column<int>(type: "int", nullable: false),
                    ownerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    size = table.Column<int>(type: "int", nullable: false),
                    facing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contactNumbers = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    occupants = table.Column<int>(type: "int", nullable: false),
                    selectedServices = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartMentDetails", x => x.flatId);
                });

            migrationBuilder.CreateTable(
                name: "ComplexDetails",
                columns: table => new
                {
                    complexId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    noofFlats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplexDetails", x => x.complexId);
                });

            migrationBuilder.CreateTable(
                name: "UserTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTable", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApartMentDetails");

            migrationBuilder.DropTable(
                name: "ComplexDetails");

            migrationBuilder.DropTable(
                name: "UserTable");
        }
    }
}
