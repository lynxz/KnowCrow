using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnowCrow.GraphQL.Migrations
{
    public partial class AddCompanyInformationId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyInformationId",
                table: "Companies",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyInformationId",
                table: "Companies");
        }
    }
}
