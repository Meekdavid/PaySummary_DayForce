using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaySummary_DayForce.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RateTableRows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dept = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Effective_Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Effective_End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hourly_Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateTableRows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimecardRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employee_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Employee_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_Worked = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Earnings_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Job_Worked = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dept_Worked = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Bonus = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimecardRecords", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RateTableRows");

            migrationBuilder.DropTable(
                name: "TimecardRecords");
        }
    }
}
