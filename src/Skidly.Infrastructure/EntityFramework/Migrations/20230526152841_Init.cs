using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skidly.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudyAreas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _userId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyAreas_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudyAreas_ApplicationUser__userId",
                        column: x => x._userId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudyGoals",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudyAreaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    _areaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpectedLearningTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyGoals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyGoals_StudyAreas_StudyAreaId",
                        column: x => x.StudyAreaId,
                        principalTable: "StudyAreas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudyGoals_StudyAreas__areaId",
                        column: x => x._areaId,
                        principalTable: "StudyAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pomodoros",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudyGoalId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpectedDuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _goalId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pomodoros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pomodoros_StudyGoals_StudyGoalId",
                        column: x => x.StudyGoalId,
                        principalTable: "StudyGoals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pomodoros_StudyGoals__goalId",
                        column: x => x._goalId,
                        principalTable: "StudyGoals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pomodoros__goalId",
                table: "Pomodoros",
                column: "_goalId");

            migrationBuilder.CreateIndex(
                name: "IX_Pomodoros_StudyGoalId",
                table: "Pomodoros",
                column: "StudyGoalId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyAreas__userId",
                table: "StudyAreas",
                column: "_userId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyAreas_ApplicationUserId",
                table: "StudyAreas",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyGoals__areaId",
                table: "StudyGoals",
                column: "_areaId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyGoals_StudyAreaId",
                table: "StudyGoals",
                column: "StudyAreaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pomodoros");

            migrationBuilder.DropTable(
                name: "StudyGoals");

            migrationBuilder.DropTable(
                name: "StudyAreas");

            migrationBuilder.DropTable(
                name: "ApplicationUser");
        }
    }
}
