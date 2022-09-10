using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PL.Persistence.Migrations
{
    public partial class ProgrammingTechnology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgrammingTechnologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgrammingLanguageId = table.Column<int>(type: "int", nullable: false),
                    TechnologyType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingTechnologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgrammingTechnologies_ProgrammingLanguages_ProgrammingLanguageId",
                        column: x => x.ProgrammingLanguageId,
                        principalTable: "ProgrammingLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "Description", "DisplayOrder", "Name" },
                values: new object[] { 6, "A programming language which was intended to work in clientside HTML.", 2000, "JavaScript" });

            migrationBuilder.InsertData(
                table: "ProgrammingTechnologies",
                columns: new[] { "Id", "Description", "Name", "ProgrammingLanguageId", "TechnologyType" },
                values: new object[,]
                {
                    { 3, null, "WPF", 5, 2 },
                    { 4, "Apple's native object-oriented application programming interface (API) for its desktop operating system macOS.", "Cocoa", 4, 4 },
                    { 5, "An application framework and inversion of control container for the Java platform.", "Spring", 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProgrammingTechnologies",
                columns: new[] { "Id", "Description", "Name", "ProgrammingLanguageId", "TechnologyType" },
                values: new object[] { 1, "Most mature JavaScript library.", "jQuery", 6, 1 });

            migrationBuilder.InsertData(
                table: "ProgrammingTechnologies",
                columns: new[] { "Id", "Description", "Name", "ProgrammingLanguageId", "TechnologyType" },
                values: new object[] { 2, null, "Angular JS", 6, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammingTechnologies_Name",
                table: "ProgrammingTechnologies",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammingTechnologies_ProgrammingLanguageId",
                table: "ProgrammingTechnologies",
                column: "ProgrammingLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammingTechnologies_TechnologyType",
                table: "ProgrammingTechnologies",
                column: "TechnologyType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgrammingTechnologies");

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
