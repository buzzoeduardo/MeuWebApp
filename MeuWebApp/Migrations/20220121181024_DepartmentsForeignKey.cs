using Microsoft.EntityFrameworkCore.Migrations;

namespace MeuWebApp.Migrations
{
    public partial class DepartmentsForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oficial_Department_DepartmentId",
                table: "Oficial");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Oficial",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Oficial_Department_DepartmentId",
                table: "Oficial",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oficial_Department_DepartmentId",
                table: "Oficial");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Oficial",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Oficial_Department_DepartmentId",
                table: "Oficial",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
