using Microsoft.EntityFrameworkCore.Migrations;

namespace Vendedores_MVC.Migrations
{
    public partial class removidacolunadevendedoreregistro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FK_Departamento",
                table: "Vendedores");

            migrationBuilder.DropColumn(
                name: "FK_Vendedor",
                table: "RegistroDeVendas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FK_Departamento",
                table: "Vendedores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FK_Vendedor",
                table: "RegistroDeVendas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
