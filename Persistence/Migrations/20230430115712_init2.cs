using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEntry",
                table: "LeaveApplications",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 30, 11, 57, 12, 761, DateTimeKind.Utc).AddTicks(8632),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 4, 29, 15, 48, 6, 393, DateTimeKind.Utc).AddTicks(3299));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEntry",
                table: "Employees",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 30, 11, 57, 12, 761, DateTimeKind.Utc).AddTicks(3590),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 4, 29, 15, 48, 6, 393, DateTimeKind.Utc).AddTicks(438));

            migrationBuilder.AlterColumn<string>(
                name: "Record",
                table: "Departments",
                type: "ntext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ntext");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEntry",
                table: "Departments",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 30, 11, 57, 12, 760, DateTimeKind.Utc).AddTicks(8257),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 4, 29, 15, 48, 6, 392, DateTimeKind.Utc).AddTicks(7163));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEntry",
                table: "LeaveApplications",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 29, 15, 48, 6, 393, DateTimeKind.Utc).AddTicks(3299),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 4, 30, 11, 57, 12, 761, DateTimeKind.Utc).AddTicks(8632));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEntry",
                table: "Employees",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 29, 15, 48, 6, 393, DateTimeKind.Utc).AddTicks(438),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 4, 30, 11, 57, 12, 761, DateTimeKind.Utc).AddTicks(3590));

            migrationBuilder.AlterColumn<string>(
                name: "Record",
                table: "Departments",
                type: "ntext",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "ntext",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEntry",
                table: "Departments",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 29, 15, 48, 6, 392, DateTimeKind.Utc).AddTicks(7163),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 4, 30, 11, 57, 12, 760, DateTimeKind.Utc).AddTicks(8257));
        }
    }
}
