using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartingDate",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "0b1043ba-c59c-43c2-8557-961bf4af792a", new DateTime(2024, 8, 7, 9, 41, 48, 921, DateTimeKind.Utc).AddTicks(9090) });

            migrationBuilder.UpdateData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 7, 9, 41, 49, 25, DateTimeKind.Utc).AddTicks(4076));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99a19e57-0d2f-4cf4-930f-b7ab68d82ccb", new DateTime(2024, 8, 7, 9, 41, 48, 921, DateTimeKind.Utc).AddTicks(9371), "AQAAAAIAAYagAAAAEGV33QZ3sml4+PfVPwiDrWjw7AQOBy6akeaDTGDAb/vEDg5FrwrFiGOcqpLf1KJGhA==", "2d77c76d-1e10-4343-ab8d-81098ac88abe" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "StartingDate",
                table: "Movies");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "b515f362-9c3a-486f-b7fd-c96083e87c2c", new DateTime(2024, 7, 30, 14, 27, 10, 772, DateTimeKind.Utc).AddTicks(145) });

            migrationBuilder.UpdateData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 14, 27, 10, 862, DateTimeKind.Utc).AddTicks(4000));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84b80305-5991-414c-83f3-ababf96f740e", new DateTime(2024, 7, 30, 14, 27, 10, 772, DateTimeKind.Utc).AddTicks(374), "AQAAAAIAAYagAAAAEJkpJ2T/QzNsmGJjzJLg4Z2LXnT0dcf8vCS+e02Ln8WfQ8En/bIAb0hfV67bWu0mPw==", "c9b3ffe0-6ebe-42a5-8aae-27dbb151e834" });
        }
    }
}
