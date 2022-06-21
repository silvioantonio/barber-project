using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuBarbeiro.API.Migrations
{
    public partial class AtualizaWorkerId5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Users_user_id",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_user_id",
                table: "Appointments");

            migrationBuilder.AddColumn<long>(
                name: "provider_hour_id",
                table: "Appointments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "provider_hour_id",
                table: "Appointments");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_user_id",
                table: "Appointments",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Users_user_id",
                table: "Appointments",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
