using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LastFinal.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorizedUsers",
                columns: table => new
                {
                    AuthorizedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorizedName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizedUsers", x => x.AuthorizedId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    PackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.PackageId);
                });

            migrationBuilder.CreateTable(
                name: "Typees",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Typees", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserLastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceProducts",
                columns: table => new
                {
                    InsuranceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsuranceName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    TypeeTypeId = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    AuthorizedId = table.Column<int>(type: "int", nullable: false),
                    AuthorizedUserAuthorizedId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Premium = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceProducts", x => x.InsuranceId);
                    table.ForeignKey(
                        name: "FK_InsuranceProducts_AuthorizedUsers_AuthorizedUserAuthorizedId",
                        column: x => x.AuthorizedUserAuthorizedId,
                        principalTable: "AuthorizedUsers",
                        principalColumn: "AuthorizedId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsuranceProducts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsuranceProducts_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "PackageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsuranceProducts_Typees_TypeeTypeId",
                        column: x => x.TypeeTypeId,
                        principalTable: "Typees",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceProductUser",
                columns: table => new
                {
                    InsuranceProductInsuranceId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceProductUser", x => new { x.InsuranceProductInsuranceId, x.UserId });
                    table.ForeignKey(
                        name: "FK_InsuranceProductUser_InsuranceProducts_InsuranceProductInsuranceId",
                        column: x => x.InsuranceProductInsuranceId,
                        principalTable: "InsuranceProducts",
                        principalColumn: "InsuranceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsuranceProductUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceProducts_AuthorizedUserAuthorizedId",
                table: "InsuranceProducts",
                column: "AuthorizedUserAuthorizedId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceProducts_CategoryId",
                table: "InsuranceProducts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceProducts_PackageId",
                table: "InsuranceProducts",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceProducts_TypeeTypeId",
                table: "InsuranceProducts",
                column: "TypeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceProductUser_UserId",
                table: "InsuranceProductUser",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsuranceProductUser");

            migrationBuilder.DropTable(
                name: "InsuranceProducts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AuthorizedUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Typees");
        }
    }
}
