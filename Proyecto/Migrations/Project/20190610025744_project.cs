using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto.Migrations.Project
{
    public partial class project : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

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
                    AwardedBestActor = table.Column<bool>(nullable: false),
                    ID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technician", x => x.AwardedBestActor);
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
                    TechnicianAwardedBestActor = table.Column<bool>(nullable: false),
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
                        name: "FK_Postulants_Technician_TechnicianAwardedBestActor",
                        column: x => x.TechnicianAwardedBestActor,
                        principalTable: "Technician",
                        principalColumn: "AwardedBestActor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Postulants_ProjectID1",
                table: "Postulants",
                column: "ProjectID1");

            migrationBuilder.CreateIndex(
                name: "IX_Postulants_TechnicianAwardedBestActor",
                table: "Postulants",
                column: "TechnicianAwardedBestActor");

            migrationBuilder.CreateIndex(
                name: "IX_Role_RolLvlId",
                table: "Role",
                column: "RolLvlId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "Postulants");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Technician");

            migrationBuilder.DropTable(
                name: "RoleLevel");
        }
    }
}
