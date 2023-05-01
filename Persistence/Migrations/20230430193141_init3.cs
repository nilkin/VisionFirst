using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEntry",
                table: "Positions",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 30, 19, 31, 41, 609, DateTimeKind.Utc).AddTicks(5268),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEntry",
                table: "LeaveApplications",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 30, 19, 31, 41, 609, DateTimeKind.Utc).AddTicks(2674),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 4, 30, 11, 57, 12, 761, DateTimeKind.Utc).AddTicks(8632));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEntry",
                table: "Employees",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 30, 19, 31, 41, 608, DateTimeKind.Utc).AddTicks(9734),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 4, 30, 11, 57, 12, 761, DateTimeKind.Utc).AddTicks(3590));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEntry",
                table: "Departments",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 30, 19, 31, 41, 608, DateTimeKind.Utc).AddTicks(6651),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 4, 30, 11, 57, 12, 760, DateTimeKind.Utc).AddTicks(8257));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEntry",
                table: "Positions",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 4, 30, 19, 31, 41, 609, DateTimeKind.Utc).AddTicks(5268));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEntry",
                table: "LeaveApplications",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 30, 11, 57, 12, 761, DateTimeKind.Utc).AddTicks(8632),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 4, 30, 19, 31, 41, 609, DateTimeKind.Utc).AddTicks(2674));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEntry",
                table: "Employees",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 30, 11, 57, 12, 761, DateTimeKind.Utc).AddTicks(3590),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 4, 30, 19, 31, 41, 608, DateTimeKind.Utc).AddTicks(9734));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEntry",
                table: "Departments",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 30, 11, 57, 12, 760, DateTimeKind.Utc).AddTicks(8257),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 4, 30, 19, 31, 41, 608, DateTimeKind.Utc).AddTicks(6651));
        }
    }
}
