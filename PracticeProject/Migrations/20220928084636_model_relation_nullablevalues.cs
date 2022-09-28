using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticeProject.Migrations
{
    public partial class model_relation_nullablevalues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Persons_PersonId1",
                table: "Relations");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId2",
                table: "Relations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId1",
                table: "Relations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Persons_PersonId1",
                table: "Relations",
                column: "PersonId1",
                principalTable: "Persons",
                principalColumn: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Persons_PersonId1",
                table: "Relations");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId2",
                table: "Relations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonId1",
                table: "Relations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Persons_PersonId1",
                table: "Relations",
                column: "PersonId1",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
