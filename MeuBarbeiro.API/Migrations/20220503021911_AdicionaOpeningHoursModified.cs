using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuBarbeiro.API.Migrations
{
    public partial class AdicionaOpeningHoursModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_at",
                table: "ProviderOpeningHours");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "ProviderOpeningHours");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "ProviderOpeningHours",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "ProviderOpeningHours",
                type: "datetime(6)",
                nullable: true);
        }
    }
}
