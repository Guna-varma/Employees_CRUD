using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Emp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "departmentList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DepartmentName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Location = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departmentList", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "projectsList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    projectName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    ProjectLead = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectsList", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "employeeDetailsList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    EmployeeCode = table.Column<string>(type: "longtext", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeDetailsList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employeeDetailsList_departmentList_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "departmentList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "bankDetailsList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    AccountNo = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    IFSCCode = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Branch = table.Column<string>(type: "longtext", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bankDetailsList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bankDetailsList_employeeDetailsList_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employeeDetailsList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "departmentList",
                columns: new[] { "Id", "DepartmentName", "Location" },
                values: new object[] { 1, "Digital", "Gurgaon" });

            migrationBuilder.InsertData(
                table: "projectsList",
                columns: new[] { "Id", "ProjectLead", "projectName" },
                values: new object[] { 1, "Shiva", "xNet" });

            migrationBuilder.InsertData(
                table: "employeeDetailsList",
                columns: new[] { "Id", "DepartmentId", "EmployeeCode", "FirstName", "ImageURL", "LastName" },
                values: new object[] { 1, 1, "22060023", "Guna", "", "Varma" });

            migrationBuilder.InsertData(
                table: "bankDetailsList",
                columns: new[] { "Id", "AccountNo", "Branch", "EmployeeId", "IFSCCode" },
                values: new object[] { 1, "1234567890", "HYD", 1, "SBIN0000967" });

            migrationBuilder.CreateIndex(
                name: "IX_bankDetailsList_EmployeeId",
                table: "bankDetailsList",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_employeeDetailsList_DepartmentId",
                table: "employeeDetailsList",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bankDetailsList");

            migrationBuilder.DropTable(
                name: "projectsList");

            migrationBuilder.DropTable(
                name: "employeeDetailsList");

            migrationBuilder.DropTable(
                name: "departmentList");
        }
    }
}
