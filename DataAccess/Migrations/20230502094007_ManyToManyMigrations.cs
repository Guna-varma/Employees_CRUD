using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeptProject",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeptProject", x => new { x.ProjectId, x.DepartmentId });
                    table.ForeignKey(
                        name: "FK_DeptProject_departmentList_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "departmentList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeptProject_projectsList_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projectsList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DeptProject_DepartmentId",
                table: "DeptProject",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeptProject");
        }
    }
}
