using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AttendanceManagementSystem.Migrations.ApplicationDb
{
    public partial class addedDataSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("d0473b45-c347-4c03-a762-9bf255d2107e"), "1f5edf05-986d-4c09-b91a-8485111a98f2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("57e475f4-0bac-44d7-9d31-89b5cef227d3"), "744a85c9-14be-4ff4-9bf5-d3be876678b1", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("3fd63305-c615-43c1-9dda-da5b9f3b26e8"), "e963db56-d58b-4e9c-9bfb-2dd63e0492b1", "Student", "STUDENT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3fd63305-c615-43c1-9dda-da5b9f3b26e8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("57e475f4-0bac-44d7-9d31-89b5cef227d3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d0473b45-c347-4c03-a762-9bf255d2107e"));
        }
    }
}
