using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuBarbeiro.API.Migrations
{
    public partial class AlteraRelacoesModelsour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProviderHour_Worker_worker_id",
                table: "ProviderHour");

            migrationBuilder.RenameColumn(
                name: "worker_id",
                table: "ProviderHour",
                newName: "WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderHour_worker_id",
                table: "ProviderHour",
                newName: "IX_ProviderHour_WorkerId");

            migrationBuilder.AlterColumn<long>(
                name: "WorkerId",
                table: "ProviderHour",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderHour_Worker_WorkerId",
                table: "ProviderHour",
                column: "WorkerId",
                principalTable: "Worker",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProviderHour_Worker_WorkerId",
                table: "ProviderHour");

            migrationBuilder.RenameColumn(
                name: "WorkerId",
                table: "ProviderHour",
                newName: "worker_id");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderHour_WorkerId",
                table: "ProviderHour",
                newName: "IX_ProviderHour_worker_id");

            migrationBuilder.AlterColumn<long>(
                name: "worker_id",
                table: "ProviderHour",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderHour_Worker_worker_id",
                table: "ProviderHour",
                column: "worker_id",
                principalTable: "Worker",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
