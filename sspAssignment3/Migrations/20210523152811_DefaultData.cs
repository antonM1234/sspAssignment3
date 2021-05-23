using Microsoft.EntityFrameworkCore.Migrations;

namespace sspAssignment3.Migrations
{
    public partial class DefaultData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Nurses",
                columns: new[] { "ID", "Email", "Name", "Section" },
                values: new object[] { 1, "DefaultNurse1@gmail.com", "DefaultNurse1", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Nurses",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
