using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crudTortillas.Migrations
{
    public partial class cupones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cuponesDescuento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaCaducidad = table.Column<DateTime>(type: "datetime2", nullable: false),
                    porcentaje = table.Column<float>(type: "real", nullable: false),
                    codigo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cuponesDescuento", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cuponesDescuento");
        }
    }
}
