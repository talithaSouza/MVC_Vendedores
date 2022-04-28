using Microsoft.EntityFrameworkCore.Migrations;

namespace Vendedores_MVC.Migrations
{
    public partial class AdicicionadoForeingKeydepartamentoIdemVendedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedores_Departamentos_DepartamentoId",
                table: "Vendedores");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "Vendedores",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedores_Departamentos_DepartamentoId",
                table: "Vendedores",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedores_Departamentos_DepartamentoId",
                table: "Vendedores");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "Vendedores",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedores_Departamentos_DepartamentoId",
                table: "Vendedores",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
