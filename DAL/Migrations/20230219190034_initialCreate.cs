using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserCountries",
                columns: table => new
                {
                    UserCountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DailCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCountries", x => x.UserCountryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilePhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserCountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserCountries_UserCountryId",
                        column: x => x.UserCountryId,
                        principalTable: "UserCountries",
                        principalColumn: "UserCountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailConfirms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailConfirms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailConfirms_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserCountries",
                columns: new[] { "UserCountryId", "Country", "DailCode" },
                values: new object[,]
                {
                    { 1, "Afghanistan", 93 },
                    { 2, "Aland Islands", 358 },
                    { 3, "Albania", 355 },
                    { 4, "Algeria", 213 },
                    { 5, "AmericanSamoa", 1684 },
                    { 6, "Andorra", 376 },
                    { 7, "Angola", 244 },
                    { 8, "Anguilla", 1264 },
                    { 9, "Antarctica", 672 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConfirmPassword", "Email", "FirstName", "LastName", "Password", "Phone", "ProfilePhoto", "UserCountryId" },
                values: new object[,]
                {
                    { 1, "123456", "ahmedmo@gmail.com", "Ahmed", "Mohamed", "123456", "010202020", null, 1 },
                    { 2, "123456", "ahmedmo@gmail.com", "mohamed", "Mohamed", "123456", "010202020", null, 2 },
                    { 3, "123456", "ahmedmo@gmail.com", "sara", "Mohamed", "123456", "010202020", null, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailConfirms_UserId",
                table: "EmailConfirms",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserCountryId",
                table: "Users",
                column: "UserCountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailConfirms");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserCountries");
        }
    }
}
