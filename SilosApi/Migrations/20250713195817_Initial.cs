using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Gorchak = table.Column<double>(type: "double precision", nullable: true),
                    Protein = table.Column<double>(type: "double precision", nullable: true),
                    Bug = table.Column<double>(type: "double precision", nullable: true),
                    Sornaya = table.Column<double>(type: "double precision", nullable: true),
                    Zernovaya = table.Column<double>(type: "double precision", nullable: true),
                    Idk = table.Column<double>(type: "double precision", nullable: true),
                    Nature = table.Column<double>(type: "double precision", nullable: true),
                    Humidity = table.Column<double>(type: "double precision", nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: true),
                    HarvestYear = table.Column<int>(type: "integer", maxLength: 4, nullable: true),
                    Class = table.Column<int>(type: "integer", nullable: true),
                    Gluten = table.Column<double>(type: "double precision", nullable: true),
                    Fullness = table.Column<double>(type: "double precision", nullable: true),
                    TotalFootage = table.Column<double>(type: "double precision", nullable: true),
                    FreeFootage = table.Column<double>(type: "double precision", nullable: true),
                    AdditionalInfo = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
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
