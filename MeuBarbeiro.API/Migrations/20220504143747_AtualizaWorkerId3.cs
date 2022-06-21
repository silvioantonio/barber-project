using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuBarbeiro.API.Migrations
{
    public partial class AtualizaWorkerId3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProviderHours_Workers_WorkerId",
                table: "ProviderHours");

            migrationBuilder.AlterColumn<long>(
                name: "WorkerId",
                table: "ProviderHours",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderHours_Workers_WorkerId",
                table: "ProviderHours",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProviderHours_Workers_WorkerId",
                table: "ProviderHours");

            migrationBuilder.AlterColumn<long>(
                name: "WorkerId",
                table: "ProviderHours",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderHours_Workers_WorkerId",
                table: "ProviderHours",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
