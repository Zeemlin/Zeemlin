using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zeemlin.Data.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_SuperAdmins_SuperAdminId",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Directors_SuperAdmins_SuperAdminId",
                table: "Directors");

            migrationBuilder.DropForeignKey(
                name: "FK_Schools_SuperAdmins_SuperAdminId",
                table: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Schools_SuperAdminId",
                table: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Directors_SuperAdminId",
                table: "Directors");

            migrationBuilder.DropIndex(
                name: "IX_Admins_SuperAdminId",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "SuperAdminId",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "SuperAdminId",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "SuperAdminId",
                table: "Admins");

            migrationBuilder.AlterColumn<string>(
                name: "Biography",
                table: "Teachers",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Teachers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "SuperAdmins",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Parents",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Directors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Admins",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "SuperAdmins");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Admins");

            migrationBuilder.AlterColumn<string>(
                name: "Biography",
                table: "Teachers",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SuperAdminId",
                table: "Schools",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SuperAdminId",
                table: "Directors",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SuperAdminId",
                table: "Admins",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schools_SuperAdminId",
                table: "Schools",
                column: "SuperAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Directors_SuperAdminId",
                table: "Directors",
                column: "SuperAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_SuperAdminId",
                table: "Admins",
                column: "SuperAdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_SuperAdmins_SuperAdminId",
                table: "Admins",
                column: "SuperAdminId",
                principalTable: "SuperAdmins",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Directors_SuperAdmins_SuperAdminId",
                table: "Directors",
                column: "SuperAdminId",
                principalTable: "SuperAdmins",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_SuperAdmins_SuperAdminId",
                table: "Schools",
                column: "SuperAdminId",
                principalTable: "SuperAdmins",
                principalColumn: "Id");
        }
    }
}
