using Microsoft.EntityFrameworkCore.Migrations;

namespace To_Do.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "toDoItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "bargraphItems",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_id",
                table: "toDoItems");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "bargraphItems");
        }
    }
}
