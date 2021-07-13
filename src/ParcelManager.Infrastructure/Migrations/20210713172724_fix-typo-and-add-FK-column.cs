using Microsoft.EntityFrameworkCore.Migrations;

namespace ParcelManager.Infrastructure.Migrations
{
    public partial class fixtypoandaddFKcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parcels_Bag_BagId",
                table: "Parcels");

            migrationBuilder.RenameColumn(
                name: "DestionationCountry",
                table: "Parcels",
                newName: "DestinationCountry");

            migrationBuilder.AlterColumn<int>(
                name: "BagId",
                table: "Parcels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcels_Bag_BagId",
                table: "Parcels",
                column: "BagId",
                principalTable: "Bag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parcels_Bag_BagId",
                table: "Parcels");

            migrationBuilder.RenameColumn(
                name: "DestinationCountry",
                table: "Parcels",
                newName: "DestionationCountry");

            migrationBuilder.AlterColumn<int>(
                name: "BagId",
                table: "Parcels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Parcels_Bag_BagId",
                table: "Parcels",
                column: "BagId",
                principalTable: "Bag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
