﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalIR.DataAccessLayer.Migrations
{
    public partial class mig_add_table_contact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Contacts",
                newName: "Phone");

            migrationBuilder.AddColumn<string>(
                name: "FooterTitle",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OpenDays",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OpenDaysDescription",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OpenHours",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FooterTitle",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "OpenDays",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "OpenDaysDescription",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "OpenHours",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Contacts",
                newName: "PhoneNumber");
        }
    }
}