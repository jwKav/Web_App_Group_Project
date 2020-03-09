using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant_API.Migrations
{
    public partial class edit_html_display : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 1,
                column: "IsBooked",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 1,
                column: "IsBooked",
                value: false);
        }
    }
}
