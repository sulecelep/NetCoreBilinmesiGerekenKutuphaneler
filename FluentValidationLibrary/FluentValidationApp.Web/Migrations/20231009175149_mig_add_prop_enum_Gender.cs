﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace FluentValidationApp.Web.Migrations
{
    public partial class mig_add_prop_enum_Gender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Customers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Customers");
        }
    }
}
