using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAttendanceSystem.Migrations
{
    public partial class initalDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AdminUsername = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AdminPassword = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    StudentGender = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    StudentEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentContact = table.Column<double>(type: "float", maxLength: 10, nullable: false),
                    StudentUsername = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StudentPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    AttendanceId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AttendanceStatus = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.AttendanceId);
                    table.ForeignKey(
                        name: "FK_Attendances_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Leaves",
                columns: table => new
                {
                    LeaveId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LeaveApplyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveReason = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaves", x => x.LeaveId);
                    table.ForeignKey(
                        name: "FK_Leaves_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_StudentId",
                table: "Attendances",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_StudentId",
                table: "Leaves",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "Leaves");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
