using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuBarbeiro.API.Migrations
{
    public partial class AlteraRelacoesModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Worker_Providers_ProviderId",
                table: "Worker");

            migrationBuilder.AlterColumn<long>(
                name: "ProviderId",
                table: "Worker",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Worker_Providers_ProviderId",
                table: "Worker",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Worker_Providers_ProviderId",
                table: "Worker");

            migrationBuilder.AlterColumn<long>(
                name: "ProviderId",
                table: "Worker",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

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
