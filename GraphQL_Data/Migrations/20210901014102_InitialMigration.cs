using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQL_Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLINICAS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLINICAS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MEDICOS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CRM = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CLINICA_ID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDICOS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MEDICOS_CLINICAS_CLINICA_ID",
                        column: x => x.CLINICA_ID,
                        principalTable: "CLINICAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PACIENTES",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IDADE = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    PESO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ALTURA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CLINICA_ID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PACIENTES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PACIENTES_CLINICAS_CLINICA_ID",
                        column: x => x.CLINICA_ID,
                        principalTable: "CLINICAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MEDICOS_CLINICA_ID",
                table: "MEDICOS",
                column: "CLINICA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PACIENTES_CLINICA_ID",
                table: "PACIENTES",
                column: "CLINICA_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MEDICOS");

            migrationBuilder.DropTable(
                name: "PACIENTES");

            migrationBuilder.DropTable(
                name: "CLINICAS");
        }
    }
}
