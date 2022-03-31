using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "city",
                table: "Employee",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Employee",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employee",
                newName: "EmpID");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailID",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpContactNo",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpName",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pwd",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmailID",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmpContactNo",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmpName",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Pwd",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Employee",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Employee",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "EmpID",
                table: "Employee",
                newName: "Id");
        }
    }
}
