using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MagicVilla_VillaAPI.Migrations
{
    public partial class AddForeignKeyToVillaTable : Migration
    { 
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VillaId",
                table: "villaNumber",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "VillaDb",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 12, 18, 16, 13, 681, DateTimeKind.Local).AddTicks(3642));

            migrationBuilder.UpdateData(
                table: "VillaDb",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 12, 18, 16, 13, 687, DateTimeKind.Local).AddTicks(5230));

            migrationBuilder.UpdateData(
                table: "VillaDb",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 12, 18, 16, 13, 687, DateTimeKind.Local).AddTicks(5264));

            migrationBuilder.UpdateData(
                table: "VillaDb",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 12, 18, 16, 13, 687, DateTimeKind.Local).AddTicks(5266));

            migrationBuilder.UpdateData(
                table: "VillaDb",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 12, 18, 16, 13, 687, DateTimeKind.Local).AddTicks(5268));

            migrationBuilder.CreateIndex(
                name: "IX_villaNumber_VillaId",
                table: "villaNumber",
                column: "VillaId");

            migrationBuilder.AddForeignKey(
                name: "FK_villaNumber_VillaDb_VillaId",
                table: "villaNumber",
                column: "VillaId",
                principalTable: "VillaDb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_villaNumber_VillaDb_VillaId",
                table: "villaNumber");

            migrationBuilder.DropIndex(
                name: "IX_villaNumber_VillaId",
                table: "villaNumber");

            migrationBuilder.DropColumn(
                name: "VillaId",
                table: "villaNumber");

            migrationBuilder.UpdateData(
                table: "VillaDb",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 12, 16, 54, 26, 106, DateTimeKind.Local).AddTicks(7961));

            migrationBuilder.UpdateData(
                table: "VillaDb",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 12, 16, 54, 26, 112, DateTimeKind.Local).AddTicks(6143));

            migrationBuilder.UpdateData(
                table: "VillaDb",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 12, 16, 54, 26, 112, DateTimeKind.Local).AddTicks(6176));

            migrationBuilder.UpdateData(
                table: "VillaDb",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 12, 16, 54, 26, 112, DateTimeKind.Local).AddTicks(6179));

            migrationBuilder.UpdateData(
                table: "VillaDb",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 12, 16, 54, 26, 112, DateTimeKind.Local).AddTicks(6180));
        }
    }
}
