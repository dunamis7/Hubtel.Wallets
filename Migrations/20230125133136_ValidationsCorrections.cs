using Microsoft.EntityFrameworkCore.Migrations;

namespace Hubtel.Wallets.Api.Migrations
{
    public partial class ValidationsCorrections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Wallets",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "AccountSchemeType",
                table: "Wallets",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Wallets",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "AccountSchemeType",
                table: "Wallets",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
