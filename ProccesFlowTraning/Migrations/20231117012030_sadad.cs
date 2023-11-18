using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProccesFlowTraning.Migrations
{
    /// <inheritdoc />
    public partial class sadad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessRequests_Employees_EmployeeId1",
                table: "ProcessRequests");

            migrationBuilder.DropIndex(
                name: "IX_ProcessRequests_EmployeeId1",
                table: "ProcessRequests");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "ProcessRequests");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "ProcessRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProcessRequests_EmployeeId",
                table: "ProcessRequests",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessRequests_Employees_EmployeeId",
                table: "ProcessRequests",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessRequests_Employees_EmployeeId",
                table: "ProcessRequests");

            migrationBuilder.DropIndex(
                name: "IX_ProcessRequests_EmployeeId",
                table: "ProcessRequests");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "ProcessRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId1",
                table: "ProcessRequests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProcessRequests_EmployeeId1",
                table: "ProcessRequests",
                column: "EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessRequests_Employees_EmployeeId1",
                table: "ProcessRequests",
                column: "EmployeeId1",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }
    }
}
