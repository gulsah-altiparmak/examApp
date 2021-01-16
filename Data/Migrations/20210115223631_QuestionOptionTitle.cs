using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class QuestionOptionTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "QuestionOptions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "QuestionOptions");
        }
    }
}
