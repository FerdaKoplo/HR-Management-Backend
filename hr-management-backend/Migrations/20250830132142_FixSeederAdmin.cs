using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hr_management_backend.Migrations
{
    /// <inheritdoc />
    public partial class FixSeederAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$eCSdIXVfJzXubQqCSGEFY.obqKlKs8Kphs2nz0d1D3TnrV87fS9kC", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$91uBQQjq9gBVVQ1tZp.bA.202DBvwJ.BJbZjNH/K577AgQ.0ZoHOi", 1 });
        }
    }
}
