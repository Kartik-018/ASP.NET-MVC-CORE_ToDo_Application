using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace To_Do.Migrations
{
    /// <inheritdoc />
    public partial class AddIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_bargraphItems",
                table: "bargraphItems");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "bargraphItems",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bargraphItems",
                table: "bargraphItems",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_bargraphItems",
                table: "bargraphItems");

            migrationBuilder.DropColumn(
                name: "id",
                table: "bargraphItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bargraphItems",
                table: "bargraphItems",
                column: "date");
        }
    }
}
