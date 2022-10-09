using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnowCrow.GraphQL.Migrations
{
    public partial class SupportMultipleRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Roles_RoleId",
                table: "Experiences");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_RoleId",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Experiences");

            migrationBuilder.AddColumn<int>(
                name: "WorkExperienceId",
                table: "Roles",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_WorkExperienceId",
                table: "Roles",
                column: "WorkExperienceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Experiences_WorkExperienceId",
                table: "Roles",
                column: "WorkExperienceId",
                principalTable: "Experiences",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Experiences_WorkExperienceId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_WorkExperienceId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "WorkExperienceId",
                table: "Roles");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Experiences",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_RoleId",
                table: "Experiences",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Roles_RoleId",
                table: "Experiences",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}
