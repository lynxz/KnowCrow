using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnowCrow.GraphQL.Migrations
{
    public partial class AddedUserInfoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserInfoId",
                table: "People",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "People");
        }
    }
}
