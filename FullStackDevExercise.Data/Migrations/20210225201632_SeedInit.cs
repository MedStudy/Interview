using Microsoft.EntityFrameworkCore.Migrations;

namespace FullStackDevExercise.Data.Migrations
{
    public partial class SeedInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "owners",
                columns: new[] { "id", "first_name", "last_name" },
                values: new object[] { 1, "Rony", "Jose" });

            migrationBuilder.InsertData(
                table: "owners",
                columns: new[] { "id", "first_name", "last_name" },
                values: new object[] { 2, "Ann", "Jose" });

            migrationBuilder.InsertData(
                table: "pets",
                columns: new[] { "id", "age", "name", "owner_id", "type" },
                values: new object[] { 1, 1, "Dude", null, "Huskey Dog" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "owners",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "owners",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "pets",
                keyColumn: "id",
                keyValue: 1);
        }
    }
}
