using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant_API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    GroupCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "TableCategories",
                columns: table => new
                {
                    TableCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableCapacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableCategories", x => x.TableCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    TableId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableCategoryId = table.Column<int>(nullable: true),
                    IsBooked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.TableId);
                    table.ForeignKey(
                        name: "FK_Tables_TableCategories_TableCategoryId",
                        column: x => x.TableCategoryId,
                        principalTable: "TableCategories",
                        principalColumn: "TableCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<int>(nullable: true),
                    TableId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "TableId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "CustomerName", "EmailAddress", "GroupCount", "PhoneNumber" },
                values: new object[] { 1, "12 Parkstone Avenue", "Jamie Benjamin", "jb.demo@gmail.com", 2, "07836544992" });

            migrationBuilder.InsertData(
                table: "TableCategories",
                columns: new[] { "TableCategoryId", "TableCapacity" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 4 },
                    { 3, 6 },
                    { 4, 8 },
                    { 5, 10 },
                    { 6, 12 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "IsBooked", "TableCategoryId" },
                values: new object[,]
                {
                    { 1, false, 1 },
                    { 7, false, 1 },
                    { 12, false, 1 },
                    { 13, false, 1 },
                    { 14, false, 1 },
                    { 2, false, 2 },
                    { 8, false, 2 },
                    { 3, false, 3 },
                    { 9, false, 3 },
                    { 4, false, 4 },
                    { 10, false, 4 },
                    { 5, false, 5 },
                    { 11, false, 5 },
                    { 15, false, 5 },
                    { 6, false, 6 }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "BookingDate", "CustomerId", "TableId" },
                values: new object[] { 1, new DateTime(2020, 3, 9, 13, 30, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CustomerId",
                table: "Bookings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TableId",
                table: "Bookings",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_TableCategoryId",
                table: "Tables",
                column: "TableCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "TableCategories");
        }
    }
}
