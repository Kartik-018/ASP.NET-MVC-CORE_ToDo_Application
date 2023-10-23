using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace To_Do.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "toDoItems",
                columns: table => new
                {
                    todo_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    task_name = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    date_added = table.Column<DateTime>(type: "date", nullable: false),
                    due_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_toDoItems", x => x.todo_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "toDoItems");
        }
    }
}
