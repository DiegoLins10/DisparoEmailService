using Microsoft.EntityFrameworkCore.Migrations;

namespace EmailDominios.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnviarEmail",
                columns: table => new
                {
                    IdEnviarEmail = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailOrigem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailDestino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeOrigem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeDestino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Assunto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mensagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnviarEmail", x => x.IdEnviarEmail);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnviarEmail");
        }
    }
}
