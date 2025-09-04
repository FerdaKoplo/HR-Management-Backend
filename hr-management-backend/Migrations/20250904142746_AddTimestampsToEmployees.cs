using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hr_management_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddTimestampsToEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Evaluations",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Evaluations",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Evaluations",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "EmployeeTraining",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "EmployeeTraining",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "EmployeeTraining",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Employees",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Employees",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Employees",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 9, 4, 14, 27, 44, 727, DateTimeKind.Utc).AddTicks(96), "$2a$11$yeoFtOlqLdNvAUvuO4OA2e3vfY4/Wrph7DWwfRSzGR2CuhLKBLROu" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Evaluations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Evaluations");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Evaluations");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "EmployeeTraining");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "EmployeeTraining");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "EmployeeTraining");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Employees");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 8, 31, 16, 27, 15, 582, DateTimeKind.Utc).AddTicks(3342), "$2a$11$TKNgHZxhpOwdJmSw2jBW8.LSHgg0I.PsZDVERBoz9v/p6nThwubCW" });
        }
    }
}
