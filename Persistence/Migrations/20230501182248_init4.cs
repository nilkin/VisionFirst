using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEntry",
                table: "Positions",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 1, 18, 22, 47, 962, DateTimeKind.Utc).AddTicks(9299),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 4, 30, 19, 31, 41, 609, DateTimeKind.Utc).AddTicks(5268));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryDate",
                table: "LeaveDays",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 1, 18, 22, 47, 962, DateTimeKind.Utc).AddTicks(7710),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEntry",
                table: "LeaveApplications",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 1, 18, 22, 47, 962, DateTimeKind.Utc).AddTicks(5220),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 4, 30, 19, 31, 41, 609, DateTimeKind.Utc).AddTicks(2674));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEntry",
                table: "Employees",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 1, 18, 22, 47, 962, DateTimeKind.Utc).AddTicks(2414),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 4, 30, 19, 31, 41, 608, DateTimeKind.Utc).AddTicks(9734));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEntry",
                table: "Departments",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 1, 18, 22, 47, 961, DateTimeKind.Utc).AddTicks(9437),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 4, 30, 19, 31, 41, 608, DateTimeKind.Utc).AddTicks(6651));

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Accounts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEntry",
                table: "Positions",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 30, 19, 31, 41, 609, DateTimeKind.Utc).AddTicks(5268),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 5, 1, 18, 22, 47, 962, DateTimeKind.Utc).AddTicks(9299));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryDate",
                table: "LeaveDays",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 1, 18, 22, 47, 962, DateTimeKind.Utc).AddTicks(7710));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEntry",
                table: "LeaveApplications",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 30, 19, 31, 41, 609, DateTimeKind.Utc).AddTicks(2674),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 5, 1, 18, 22, 47, 962, DateTimeKind.Utc).AddTicks(5220));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEntry",
                table: "Employees",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 30, 19, 31, 41, 608, DateTimeKind.Utc).AddTicks(9734),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 5, 1, 18, 22, 47, 962, DateTimeKind.Utc).AddTicks(2414));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEntry",
                table: "Departments",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 30, 19, 31, 41, 608, DateTimeKind.Utc).AddTicks(6651),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 5, 1, 18, 22, 47, 961, DateTimeKind.Utc).AddTicks(9437));
        }
    }
}
