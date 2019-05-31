using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TechnicianRole",
                columns: table => new
                {
                    TecRolId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TecRolDsc = table.Column<string>(nullable: true),
                    TecRolLvl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicianRole", x => x.TecRolId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TechnicianRole");
        }
    }
}
