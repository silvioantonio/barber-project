using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuBarbeiro.API.Migrations
{
    public partial class AtualizaWorker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Worker_worker_id",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderHour_Worker_WorkerId",
                table: "ProviderHour");

            migrationBuilder.DropForeignKey(
                name: "FK_Worker_Providers_provider_id",
                table: "Worker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Worker",
                table: "Worker");

            migrationBuilder.RenameTable(
                name: "Worker",
                newName: "Workers");

            migrationBuilder.RenameIndex(
                name: "IX_Worker_provider_id",
                table: "Workers",
                newName: "IX_Workers_provider_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workers",
                table: "Workers",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Workers_worker_id",
                table: "Appointments",
                column: "worker_id",
                principalTable: "Workers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderHour_Workers_WorkerId",
                table: "ProviderHour",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Providers_provider_id",
                table: "Workers",
                column: "provider_id",
                principalTable: "Providers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Workers_worker_id",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderHour_Workers_WorkerId",
                table: "ProviderHour");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Providers_provider_id",
                table: "Workers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workers",
                table: "Workers");

            migrationBuilder.RenameTable(
                name: "Workers",
                newName: "Worker");

            migrationBuilder.RenameIndex(
                name: "IX_Workers_provider_id",
                table: "Worker",
                newName: "IX_Worker_provider_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Worker",
                table: "Worker",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Worker_worker_id",
                table: "Appointments",
                column: "worker_id",
                principalTable: "Worker",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderHour_Worker_WorkerId",
                table: "ProviderHour",
                column: "WorkerId",
                principalTable: "Worker",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Worker_Providers_provider_id",
                table: "Worker",
                column: "provider_id",
                principalTable: "Providers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
