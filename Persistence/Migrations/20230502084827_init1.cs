using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEntry",
                table: "Positions",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 2, 8, 48, 27, 935, DateTimeKind.Utc).AddTicks(8370),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 5, 1, 22, 29, 19, 265, DateTimeKind.Utc).AddTicks(7007));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryDate",
                table: "LeaveDays",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 2, 8, 48, 27, 935, DateTimeKind.Utc).AddTicks(6709),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 5, 1, 22, 29, 19, 265, DateTimeKind.Utc).AddTicks(5323));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEntry",
                table: "LeaveApplications",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 2, 8, 48, 27, 935, DateTimeKind.Utc).AddTicks(4292),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 5, 1, 22, 29, 19, 265, DateTimeKind.Utc).AddTicks(2791));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEntry",
                table: "Employees",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 2, 8, 48, 27, 935, DateTimeKind.Utc).AddTicks(947),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 5, 1, 22, 29, 19, 264, DateTimeKind.Utc).AddTicks(9336));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEntry",
                table: "Departments",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 2, 8, 48, 27, 934, DateTimeKind.Utc).AddTicks(8224),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 5, 1, 22, 29, 19, 264, DateTimeKind.Utc).AddTicks(6158));

            migrationBuilder.AlterColumn<byte>(
                name: "Role",
                table: "Accounts",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)2,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEntry",
                table: "Positions",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 1, 22, 29, 19, 265, DateTimeKind.Utc).AddTicks(7007),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 5, 2, 8, 48, 27, 935, DateTimeKind.Utc).AddTicks(8370));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryDate",
                table: "LeaveDays",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 1, 22, 29, 19, 265, DateTimeKind.Utc).AddTicks(5323),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 5, 2, 8, 48, 27, 935, DateTimeKind.Utc).AddTicks(6709));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEntry",
                table: "LeaveApplications",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 1, 22, 29, 19, 265, DateTimeKind.Utc).AddTicks(2791),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 5, 2, 8, 48, 27, 935, DateTimeKind.Utc).AddTicks(4292));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEntry",
                table: "Employees",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 1, 22, 29, 19, 264, DateTimeKind.Utc).AddTicks(9336),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 5, 2, 8, 48, 27, 935, DateTimeKind.Utc).AddTicks(947));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEntry",
                table: "Departments",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 1, 22, 29, 19, 264, DateTimeKind.Utc).AddTicks(6158),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 5, 2, 8, 48, 27, 934, DateTimeKind.Utc).AddTicks(8224));

            migrationBuilder.AlterColumn<byte>(
                name: "Role",
                table: "Accounts",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldDefaultValue: (byte)2);
        }
    }
}
