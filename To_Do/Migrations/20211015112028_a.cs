using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace To_Do.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bargraphItems",
                columns: table => new
                {
                    date = table.Column<DateTime>(nullable: false),
                    completed_task = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bargraphItems", x => x.date);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bargraphItems");
        }
    }
}
