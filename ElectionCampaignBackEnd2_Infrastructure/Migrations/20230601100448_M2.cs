using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectionCampaignBackEnd2_Infrastructure.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "usermasters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "usermasters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "usermasters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "usermasters",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "usermasters");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "usermasters");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "usermasters");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "usermasters");
        }
    }
}
