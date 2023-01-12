using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MKFY.Repositories.Migrations
{
    public partial class AddUserBuyeIdtoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MKFYListItems_Users_UserID",
                table: "MKFYListItems");

            migrationBuilder.DropIndex(
                name: "IX_MKFYListItems_UserID",
                table: "MKFYListItems");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "MKFYListItems");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "MKFYListItems",
                newName: "UserID");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "MKFYListItems",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuyerId",
                table: "MKFYListItems",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSold",
                table: "MKFYListItems",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "UserLogs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    LogCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SearchString = table.Column<string>(type: "text", nullable: false),
                    SearchCategory = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MKFYListItems_UserID",
                table: "MKFYListItems",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_MKFYListItems_Users_UserID",
                table: "MKFYListItems",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MKFYListItems_Users_UserID",
                table: "MKFYListItems");

            migrationBuilder.DropTable(
                name: "UserLogs");

            migrationBuilder.DropIndex(
                name: "IX_MKFYListItems_UserID",
                table: "MKFYListItems");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "MKFYListItems");

            migrationBuilder.DropColumn(
                name: "IsSold",
                table: "MKFYListItems");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "MKFYListItems",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "MKFYListItems",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "MKFYListItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_MKFYListItems_UserID",
                table: "MKFYListItems",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_MKFYListItems_Users_UserID",
                table: "MKFYListItems",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
