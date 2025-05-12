using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RailwaySections.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "railway_sections",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    parameters_railway_code = table.Column<string>(type: "text", nullable: false),
                    parameters_unified_network_marking = table.Column<string>(type: "text", nullable: false),
                    title_full_name = table.Column<string>(type: "text", nullable: false),
                    title_mnemonic = table.Column<string>(type: "text", nullable: true),
                    title_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_railway_sections", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "railway_sections");
        }
    }
}
