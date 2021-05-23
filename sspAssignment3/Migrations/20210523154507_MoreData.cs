using Microsoft.EntityFrameworkCore.Migrations;

namespace sspAssignment3.Migrations
{
    public partial class MoreData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Nurses",
                columns: new[] { "ID", "Email", "Name", "Section" },
                values: new object[] { 2, "DefaultNurse2@hotmail.com", "DefaultNurse2", 1 });

            migrationBuilder.InsertData(
                table: "Nurses",
                columns: new[] { "ID", "Email", "Name", "Section" },
                values: new object[] { 3, "DefaultNurse3@yahoo.com", "DefaultNurse3", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Nurses",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Nurses",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
