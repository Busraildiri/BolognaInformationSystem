using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolognaInformationSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgramOutcomes",
                columns: table => new
                {
                    ProgramOutcomeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramOutcomes", x => x.ProgramOutcomeID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TCIdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedInstructorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_Courses_Users_AssignedInstructorID",
                        column: x => x.AssignedInstructorID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "LearningOutcomes",
                columns: table => new
                {
                    OutcomeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningOutcomes", x => x.OutcomeID);
                    table.ForeignKey(
                        name: "FK_LearningOutcomes_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OutcomeRelations",
                columns: table => new
                {
                    OutcomeID = table.Column<int>(type: "int", nullable: false),
                    ProgramOutcomeID = table.Column<int>(type: "int", nullable: false),
                    RelationDegree = table.Column<int>(type: "int", nullable: false),
                    LearningOutcomeOutcomeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutcomeRelations", x => new { x.OutcomeID, x.ProgramOutcomeID });
                    table.ForeignKey(
                        name: "FK_OutcomeRelations_LearningOutcomes_LearningOutcomeOutcomeID",
                        column: x => x.LearningOutcomeOutcomeID,
                        principalTable: "LearningOutcomes",
                        principalColumn: "OutcomeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutcomeRelations_ProgramOutcomes_ProgramOutcomeID",
                        column: x => x.ProgramOutcomeID,
                        principalTable: "ProgramOutcomes",
                        principalColumn: "ProgramOutcomeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AssignedInstructorID",
                table: "Courses",
                column: "AssignedInstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_LearningOutcomes_CourseID",
                table: "LearningOutcomes",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeRelations_LearningOutcomeOutcomeID",
                table: "OutcomeRelations",
                column: "LearningOutcomeOutcomeID");

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeRelations_ProgramOutcomeID",
                table: "OutcomeRelations",
                column: "ProgramOutcomeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OutcomeRelations");

            migrationBuilder.DropTable(
                name: "LearningOutcomes");

            migrationBuilder.DropTable(
                name: "ProgramOutcomes");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
