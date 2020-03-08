using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication9.Migrations
{
    public partial class Escuelita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    idCursos = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.idCursos);
                });

            migrationBuilder.CreateTable(
                name: "estudiantesCursos",
                columns: table => new
                {
                    idEstudiante = table.Column<int>(nullable: false),
                    IdCursos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estudiantesCursos", x => new { x.IdCursos, x.idEstudiante });
                    table.ForeignKey(
                        name: "FK_estudiantesCursos_Cursos_IdCursos",
                        column: x => x.IdCursos,
                        principalTable: "Cursos",
                        principalColumn: "idCursos",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_estudiantesCursos_Alumnos_idEstudiante",
                        column: x => x.idEstudiante,
                        principalTable: "Alumnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profesores",
                columns: table => new
                {
                    idProfesores = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    idCursos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.idProfesores);
                    table.ForeignKey(
                        name: "FK_Profesores_Cursos_idCursos",
                        column: x => x.idCursos,
                        principalTable: "Cursos",
                        principalColumn: "idCursos",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_estudiantesCursos_idEstudiante",
                table: "estudiantesCursos",
                column: "idEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_Profesores_idCursos",
                table: "Profesores",
                column: "idCursos",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "estudiantesCursos");

            migrationBuilder.DropTable(
                name: "Profesores");

            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
