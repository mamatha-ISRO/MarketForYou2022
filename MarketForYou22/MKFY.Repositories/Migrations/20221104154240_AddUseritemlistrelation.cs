using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MKFY.Repositories.Migrations
{
    public partial class AddUseritemlistrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "MKFYListItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MKFYListItems",
                type: "text",
                nullable: true);

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

            migrationBuilder.DropIndex(
                name: "IX_MKFYListItems_UserID",
                table: "MKFYListItems");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "MKFYListItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MKFYListItems");
        }
    }
}
