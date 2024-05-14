using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_Lopez_Alvarez_Jose.Migrations
{
    public partial class Creandotablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sede",
                columns: table => new
                {
                    idSede = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    referencia = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    horaAtencion = table.Column<DateTime>(type: "date", nullable: false),
                    director = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    contacto = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    emailContacto = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    numeroConsultorios = table.Column<int>(type: "int", nullable: false),
                    numeroCamas = table.Column<int>(type: "int", nullable: false),
                    sitioWeb = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sede", x => x.idSede);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sede");
        }
    }
}
