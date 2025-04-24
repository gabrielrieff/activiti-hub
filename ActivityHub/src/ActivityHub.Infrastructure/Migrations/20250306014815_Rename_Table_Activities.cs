using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActivityHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Rename_Table_Activities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activitys_Users_UserId",
                table: "Activitys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activitys",
                table: "Activitys");

            migrationBuilder.RenameTable(
                name: "Activitys",
                newName: "Activities");

            migrationBuilder.RenameIndex(
                name: "IX_Activitys_UserId",
                table: "Activities",
                newName: "IX_Activities_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activities",
                table: "Activities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Users_UserId",
                table: "Activities",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Users_UserId",
                table: "Activities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activities",
                table: "Activities");

            migrationBuilder.RenameTable(
                name: "Activities",
                newName: "Activitys");

            migrationBuilder.RenameIndex(
                name: "IX_Activities_UserId",
                table: "Activitys",
                newName: "IX_Activitys_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activitys",
                table: "Activitys",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Activitys_Users_UserId",
                table: "Activitys",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
