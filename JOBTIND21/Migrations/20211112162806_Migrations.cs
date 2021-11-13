using Microsoft.EntityFrameworkCore.Migrations;

namespace JOBTIND21.Migrations
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoEmp = table.Column<int>(type: "int", nullable: false),
                    EmailEmp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContraseñaEmp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vacante = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    DUI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Anuncio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anuncios = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    EmpresaID = table.Column<int>(type: "int", nullable: false),
                    Categoria = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anuncio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anuncio_Empresas_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Anuncio_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anuncio_EmpresaID",
                table: "Anuncio",
                column: "EmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_Anuncio_UsuarioID",
                table: "Anuncio",
                column: "UsuarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anuncio");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
