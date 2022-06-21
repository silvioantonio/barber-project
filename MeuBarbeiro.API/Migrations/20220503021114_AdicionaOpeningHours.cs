using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuBarbeiro.API.Migrations
{
    public partial class AdicionaOpeningHours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Worker_Providers_ProviderId",
                table: "Worker");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "Worker",
                newName: "provider_id");

            migrationBuilder.RenameIndex(
                name: "IX_Worker_ProviderId",
                table: "Worker",
                newName: "IX_Worker_provider_id");

            migrationBuilder.AddColumn<int>(
                name: "ProviderOpeningHoursId",
                table: "Providers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProviderOpeningHours",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    opening_day = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    start_hour = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    end_hour = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderOpeningHours", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_ProviderOpeningHoursId",
                table: "Providers",
                column: "ProviderOpeningHoursId");

            migrationBuilder.AddForeignKey(
                name: "FK_Providers_ProviderOpeningHours_ProviderOpeningHoursId",
                table: "Providers",
                column: "ProviderOpeningHoursId",
                principalTable: "ProviderOpeningHours",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Worker_Providers_provider_id",
                table: "Worker",
                column: "provider_id",
                principalTable: "Providers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Providers_ProviderOpeningHours_ProviderOpeningHoursId",
                table: "Providers");

            migrationBuilder.DropForeignKey(
                name: "FK_Worker_Providers_provider_id",
                table: "Worker");

            migrationBuilder.DropTable(
                name: "ProviderOpeningHours");

            migrationBuilder.DropIndex(
                name: "IX_Providers_ProviderOpeningHoursId",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "ProviderOpeningHoursId",
                table: "Providers");

            migrationBuilder.RenameColumn(
                name: "provider_id",
                table: "Worker",
                newName: "ProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_Worker_provider_id",
                table: "Worker",
                newName: "IX_Worker_ProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Worker_Providers_ProviderId",
                table: "Worker",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
