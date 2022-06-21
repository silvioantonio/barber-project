using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuBarbeiro.API.Migrations
{
    public partial class AtualizaWorkerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProviderHour_Workers_WorkerId",
                table: "ProviderHour");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProviderHour",
                table: "ProviderHour");

            migrationBuilder.RenameTable(
                name: "ProviderHour",
                newName: "ProviderHours");

            migrationBuilder.RenameColumn(
                name: "WorkerId",
                table: "ProviderHours",
                newName: "worker_id");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderHour_WorkerId",
                table: "ProviderHours",
                newName: "IX_ProviderHours_worker_id");

            migrationBuilder.AlterColumn<long>(
                name: "worker_id",
                table: "ProviderHours",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProviderHours",
                table: "ProviderHours",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderHours_Workers_worker_id",
                table: "ProviderHours",
                column: "worker_id",
                principalTable: "Workers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProviderHours_Workers_worker_id",
                table: "ProviderHours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProviderHours",
                table: "ProviderHours");

            migrationBuilder.RenameTable(
                name: "ProviderHours",
                newName: "ProviderHour");

            migrationBuilder.RenameColumn(
                name: "worker_id",
                table: "ProviderHour",
                newName: "WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderHours_worker_id",
                table: "ProviderHour",
                newName: "IX_ProviderHour_WorkerId");

            migrationBuilder.AlterColumn<long>(
                name: "WorkerId",
                table: "ProviderHour",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProviderHour",
                table: "ProviderHour",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderHour_Workers_WorkerId",
                table: "ProviderHour",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "id");
        }
    }
}
