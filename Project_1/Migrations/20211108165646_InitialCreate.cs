using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassesTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Time = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassesTimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DaysNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaysNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupsNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupsNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LecturersNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturersNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationsNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationsNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectsNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectsNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeeksDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeksDates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<string>(type: "TEXT", nullable: true),
                    DayNameId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Days_DaysNames_DayNameId",
                        column: x => x.DayNameId,
                        principalTable: "DaysNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClassTimeId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubjectNameId = table.Column<int>(type: "INTEGER", nullable: false),
                    LecturerNameId = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationNameId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_ClassesTimes_ClassTimeId",
                        column: x => x.ClassTimeId,
                        principalTable: "ClassesTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subjects_LecturersNames_LecturerNameId",
                        column: x => x.LecturerNameId,
                        principalTable: "LecturersNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subjects_LocationsNames_LocationNameId",
                        column: x => x.LocationNameId,
                        principalTable: "LocationsNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subjects_SubjectsNames_SubjectNameId",
                        column: x => x.SubjectNameId,
                        principalTable: "SubjectsNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weeks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WeekDateId = table.Column<int>(type: "INTEGER", nullable: false),
                    GroupNameId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weeks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weeks_GroupsNames_GroupNameId",
                        column: x => x.GroupNameId,
                        principalTable: "GroupsNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Weeks_WeeksDates_WeekDateId",
                        column: x => x.WeekDateId,
                        principalTable: "WeeksDates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DaySubject",
                columns: table => new
                {
                    DayId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaySubject", x => new { x.DayId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_DaySubject_Days_DayId",
                        column: x => x.DayId,
                        principalTable: "Days",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DaySubject_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DayWeek",
                columns: table => new
                {
                    DaysId = table.Column<int>(type: "INTEGER", nullable: false),
                    WeeksId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayWeek", x => new { x.DaysId, x.WeeksId });
                    table.ForeignKey(
                        name: "FK_DayWeek_Days_DaysId",
                        column: x => x.DaysId,
                        principalTable: "Days",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayWeek_Weeks_WeeksId",
                        column: x => x.WeeksId,
                        principalTable: "Weeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Days_DayNameId",
                table: "Days",
                column: "DayNameId");

            migrationBuilder.CreateIndex(
                name: "IX_DaySubject_SubjectId",
                table: "DaySubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DayWeek_WeeksId",
                table: "DayWeek",
                column: "WeeksId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_ClassTimeId",
                table: "Subjects",
                column: "ClassTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_LecturerNameId",
                table: "Subjects",
                column: "LecturerNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_LocationNameId",
                table: "Subjects",
                column: "LocationNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SubjectNameId",
                table: "Subjects",
                column: "SubjectNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Weeks_GroupNameId",
                table: "Weeks",
                column: "GroupNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Weeks_WeekDateId",
                table: "Weeks",
                column: "WeekDateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DaySubject");

            migrationBuilder.DropTable(
                name: "DayWeek");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "Weeks");

            migrationBuilder.DropTable(
                name: "ClassesTimes");

            migrationBuilder.DropTable(
                name: "LecturersNames");

            migrationBuilder.DropTable(
                name: "LocationsNames");

            migrationBuilder.DropTable(
                name: "SubjectsNames");

            migrationBuilder.DropTable(
                name: "DaysNames");

            migrationBuilder.DropTable(
                name: "GroupsNames");

            migrationBuilder.DropTable(
                name: "WeeksDates");
        }
    }
}
