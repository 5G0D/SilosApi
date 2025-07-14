using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SilosApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Silos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Culture = table.Column<string>(type: "TEXT", nullable: false),
                    Gorchak = table.Column<double>(type: "REAL", nullable: true),
                    Protein = table.Column<double>(type: "REAL", nullable: true),
                    Bug = table.Column<double>(type: "REAL", nullable: true),
                    Sornaya = table.Column<double>(type: "REAL", nullable: true),
                    Zernovaya = table.Column<double>(type: "REAL", nullable: true),
                    Idk = table.Column<double>(type: "REAL", nullable: true),
                    Nature = table.Column<double>(type: "REAL", nullable: true),
                    Humidity = table.Column<double>(type: "REAL", nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: true),
                    HarvestYear = table.Column<DateTime>(type: "TEXT", maxLength: 4, nullable: true),
                    Class = table.Column<int>(type: "INTEGER", nullable: true),
                    Gluten = table.Column<double>(type: "REAL", nullable: true),
                    Fullness = table.Column<double>(type: "REAL", nullable: true),
                    TotalFootage = table.Column<double>(type: "REAL", nullable: true),
                    FreeFootage = table.Column<double>(type: "REAL", nullable: true),
                    AdditionalInfo = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Silos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Silos");
        }
    }
}
