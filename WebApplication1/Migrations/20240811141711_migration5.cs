using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class migration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Options_CorrectOptionId1",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "CorrectOptionId1",
                table: "Questions",
                newName: "CorrectOptionOptionId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_CorrectOptionId1",
                table: "Questions",
                newName: "IX_Questions_CorrectOptionOptionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Options",
                newName: "OptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Options_CorrectOptionOptionId",
                table: "Questions",
                column: "CorrectOptionOptionId",
                principalTable: "Options",
                principalColumn: "OptionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Options_CorrectOptionOptionId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "CorrectOptionOptionId",
                table: "Questions",
                newName: "CorrectOptionId1");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_CorrectOptionOptionId",
                table: "Questions",
                newName: "IX_Questions_CorrectOptionId1");

            migrationBuilder.RenameColumn(
                name: "OptionId",
                table: "Options",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Options_CorrectOptionId1",
                table: "Questions",
                column: "CorrectOptionId1",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
