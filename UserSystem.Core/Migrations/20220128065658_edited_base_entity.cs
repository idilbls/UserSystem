using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserSystem.Core.Migrations
{
    public partial class edited_base_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "User");
        }
    }
}
