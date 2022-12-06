using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneBook.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryCode",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Cities_CityCode",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Countries_CountryCode",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Gender_GenderCode",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_GenderCode",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "GenderCode",
                table: "Contacts");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryCode",
                table: "Cities",
                column: "CountryCode",
                principalTable: "Countries",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Cities_CityCode",
                table: "Contacts",
                column: "CityCode",
                principalTable: "Cities",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Countries_CountryCode",
                table: "Contacts",
                column: "CountryCode",
                principalTable: "Countries",
                principalColumn: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryCode",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Cities_CityCode",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Countries_CountryCode",
                table: "Contacts");

            migrationBuilder.AddColumn<string>(
                name: "GenderCode",
                table: "Contacts",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    GenderCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    GenderName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GenderStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.GenderCode);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_GenderCode",
                table: "Contacts",
                column: "GenderCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryCode",
                table: "Cities",
                column: "CountryCode",
                principalTable: "Countries",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Cities_CityCode",
                table: "Contacts",
                column: "CityCode",
                principalTable: "Cities",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Countries_CountryCode",
                table: "Contacts",
                column: "CountryCode",
                principalTable: "Countries",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Gender_GenderCode",
                table: "Contacts",
                column: "GenderCode",
                principalTable: "Gender",
                principalColumn: "GenderCode");
        }
    }
}
