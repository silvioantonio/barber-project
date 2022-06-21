using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuBarbeiro.API.Migrations
{
    public partial class AtualizaWorkerId2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProviderHours_Workers_worker_id",
                table: "ProviderHours");

            migrationBuilder.RenameColumn(
                name: "worker_id",
                table: "ProviderHours",
                newName: "WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderHours_worker_id",
                table: "ProviderHours",
                newName: "IX_ProviderHours_WorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderHours_Workers_WorkerId",
                table: "ProviderHours",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProviderHours_Workers_WorkerId",
                table: "ProviderHours");

            migrationBuilder.RenameColumn(
                name: "WorkerId",
                table: "ProviderHours",
                newName: "worker_id");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderHours_WorkerId",
                table: "ProviderHours",
                newName: "IX_ProviderHours_worker_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderHours_Workers_worker_id",
                table: "ProviderHours",
                column: "worker_id",
                principalTable: "Workers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
