using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EP_Quest.Migrations
{
    public partial class AddedTimeWasAddedFieldToTheStepModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "TimeWasAdded",
                table: "Steps",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeWasAdded",
                table: "Steps");
        }
    }
}
