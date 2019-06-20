using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto.Migrations.Project
{
    public partial class projects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(maxLength: 60, nullable: false),
                    Description = table.Column<string>(maxLength: 180, nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectID);
                });

            migrationBuilder.CreateTable(
                name: "RoleLevel",
                columns: table => new
                {
                    RolLvlId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RolLvlDsc = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleLevel", x => x.RolLvlId);
                });

            migrationBuilder.CreateTable(
                name: "Technician",
                columns: table => new
                {
                    TechnicianID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    ProjectID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technician", x => x.TechnicianID);
                    table.ForeignKey(
                        name: "FK_Technician_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HiringCost",
                columns: table => new
                {
                    HirCosId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RolLvlId = table.Column<int>(nullable: false),
                    HirCosHourly = table.Column<float>(nullable: false),
                    HirCosAdditional = table.Column<float>(nullable: false),
                    HirCosFull = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiringCost", x => x.HirCosId);
                    table.ForeignKey(
                        name: "FK_HiringCost_RoleLevel_RolLvlId",
                        column: x => x.RolLvlId,
                        principalTable: "RoleLevel",
                        principalColumn: "RolLvlId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RolDsc = table.Column<string>(nullable: false),
                    RolLvlId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                    table.ForeignKey(
                        name: "FK_Role_RoleLevel_RolLvlId",
                        column: x => x.RolLvlId,
                        principalTable: "RoleLevel",
                        principalColumn: "RolLvlId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Postulants",
                columns: table => new
                {
                    TechnicianID = table.Column<int>(nullable: false),
                    ProjectID = table.Column<int>(nullable: false),
                    ProjectID1 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postulants", x => new { x.TechnicianID, x.ProjectID });
                    table.UniqueConstraint("AK_Postulants_ProjectID_TechnicianID", x => new { x.ProjectID, x.TechnicianID });
                    table.ForeignKey(
                        name: "FK_Postulants_Project_ProjectID1",
                        column: x => x.ProjectID1,
                        principalTable: "Project",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Postulants_Technician_TechnicianID",
                        column: x => x.TechnicianID,
                        principalTable: "Technician",
                        principalColumn: "TechnicianID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HiringCost_RolLvlId",
                table: "HiringCost",
                column: "RolLvlId");

            migrationBuilder.CreateIndex(
                name: "IX_Postulants_ProjectID1",
                table: "Postulants",
                column: "ProjectID1");

            migrationBuilder.CreateIndex(
                name: "IX_Role_RolLvlId",
                table: "Role",
                column: "RolLvlId");

            migrationBuilder.CreateIndex(
                name: "IX_Technician_ProjectID",
                table: "Technician",
                column: "ProjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HiringCost");

            migrationBuilder.DropTable(
                name: "Postulants");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Technician");

            migrationBuilder.DropTable(
                name: "RoleLevel");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
