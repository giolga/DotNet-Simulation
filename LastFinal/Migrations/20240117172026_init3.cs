using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LastFinal.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceProducts_InsuranceProductUsers_InsuranceProductUserInsuranceProductId",
                table: "InsuranceProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_InsuranceProductUsers_InsuranceProductUserInsuranceProductId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "InsuranceProductUsers");

            migrationBuilder.DropIndex(
                name: "IX_Users_InsuranceProductUserInsuranceProductId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_InsuranceProducts_InsuranceProductUserInsuranceProductId",
                table: "InsuranceProducts");

            migrationBuilder.DropColumn(
                name: "InsuranceProductUserInsuranceProductId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "InsuranceProductUserInsuranceProductId",
                table: "InsuranceProducts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InsuranceProductUserInsuranceProductId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InsuranceProductUserInsuranceProductId",
                table: "InsuranceProducts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InsuranceProductUsers",
                columns: table => new
                {
                    InsuranceProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceProductUsers", x => x.InsuranceProductId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_InsuranceProductUserInsuranceProductId",
                table: "Users",
                column: "InsuranceProductUserInsuranceProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceProducts_InsuranceProductUserInsuranceProductId",
                table: "InsuranceProducts",
                column: "InsuranceProductUserInsuranceProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceProducts_InsuranceProductUsers_InsuranceProductUserInsuranceProductId",
                table: "InsuranceProducts",
                column: "InsuranceProductUserInsuranceProductId",
                principalTable: "InsuranceProductUsers",
                principalColumn: "InsuranceProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_InsuranceProductUsers_InsuranceProductUserInsuranceProductId",
                table: "Users",
                column: "InsuranceProductUserInsuranceProductId",
                principalTable: "InsuranceProductUsers",
                principalColumn: "InsuranceProductId");
        }
    }
}
