using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo_ASP.NET_MVC.DAL.Data.Migrations
{
    public partial class InitialNameComlumnForEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Employees");
        }
    }
}
