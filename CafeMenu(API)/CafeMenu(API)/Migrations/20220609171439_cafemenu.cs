using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeMenu_API_.Migrations
{
    public partial class cafemenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timeslot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Description", "ImgUrl", "Name", "Price", "Stock", "Timeslot", "Type" },
                values: new object[] { 1, "11", "https://www.etestware.com/wp-content/uploads/2020/12/shutterstock_515285995-1200x580.jpg", "1111", 1200L, 80, "afternoon", "a" });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Description", "ImgUrl", "Name", "Price", "Stock", "Timeslot", "Type" },
                values: new object[] { 2, "333", "https://www.etestware.com/wp-content/uploads/2020/12/shutterstock_515285995-1200x580.jpg", "2222", 800L, 100, "afternoon", "b" });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Description", "ImgUrl", "Name", "Price", "Stock", "Timeslot", "Type" },
                values: new object[] { 3, "333", "https://www.etestware.com/wp-content/uploads/2020/12/shutterstock_515285995-1200x580.jpg", "333", 1000L, 50, "afternoon", "c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foods");
        }
    }
}
