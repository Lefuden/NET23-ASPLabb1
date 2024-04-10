using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPLabb1.Data.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeOffApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeOffApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeOffApplications_Personals_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "Personals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Historys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalId = table.Column<int>(type: "int", nullable: false),
                    TimeOffApplicationId = table.Column<int>(type: "int", nullable: false),
                    ApplicationStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Historys_Personals_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "Personals",
                        principalColumn: "Id",
                        onUpdate:ReferentialAction.Cascade,
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Historys_TimeOffApplications_TimeOffApplicationId",
                        column: x => x.TimeOffApplicationId,
                        principalTable: "TimeOffApplications",
                        principalColumn: "Id",
                        onUpdate:ReferentialAction.Cascade,
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Historys_PersonalId",
                table: "Historys",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_Historys_TimeOffApplicationId",
                table: "Historys",
                column: "TimeOffApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeOffApplications_PersonalId",
                table: "TimeOffApplications",
                column: "PersonalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Historys");

            migrationBuilder.DropTable(
                name: "TimeOffApplications");

            migrationBuilder.DropTable(
                name: "Personals");
        }
    }
}
