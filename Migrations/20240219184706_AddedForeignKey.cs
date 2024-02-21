using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory_managment.Migrations
{
    /// <inheritdoc />
    public partial class AddedForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "boxId",
                table: "Boxes",
                newName: "BoxId");

            migrationBuilder.AddColumn<int>(
                name: "PalletId",
                table: "Pallets",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BoxId",
                table: "Boxes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "PalletId",
                table: "Boxes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Bottles",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BoxId",
                table: "Bottles",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_Pallets_PalletId",
                table: "Pallets",
                column: "PalletId");

            migrationBuilder.CreateIndex(
                name: "IX_Boxes_BoxId",
                table: "Boxes",
                column: "BoxId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boxes_Bottles_BoxId",
                table: "Boxes",
                column: "BoxId",
                principalTable: "Bottles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pallets_Boxes_PalletId",
                table: "Pallets",
                column: "PalletId",
                principalTable: "Boxes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boxes_Bottles_BoxId",
                table: "Boxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Pallets_Boxes_PalletId",
                table: "Pallets");

            migrationBuilder.DropIndex(
                name: "IX_Pallets_PalletId",
                table: "Pallets");

            migrationBuilder.DropIndex(
                name: "IX_Boxes_BoxId",
                table: "Boxes");

            migrationBuilder.DropColumn(
                name: "PalletId",
                table: "Pallets");

            migrationBuilder.DropColumn(
                name: "PalletId",
                table: "Boxes");

            migrationBuilder.RenameColumn(
                name: "BoxId",
                table: "Boxes",
                newName: "boxId");

            migrationBuilder.AlterColumn<string>(
                name: "boxId",
                table: "Boxes",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Code",
                table: "Bottles",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "BoxId",
                table: "Bottles",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }
    }
}
