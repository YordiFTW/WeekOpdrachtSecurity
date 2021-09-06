using Microsoft.EntityFrameworkCore.Migrations;

namespace WeekOpdrachtSecurity.API.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Secrets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Classification = table.Column<int>(type: "int", nullable: false),
                    Context = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secrets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Secrets",
                columns: new[] { "Id", "Classification", "Context" },
                values: new object[,]
                {
                    { 1, 2, "Lorem Ipsum1" },
                    { 2, 1, "Lorem Ipsum2" },
                    { 3, 0, "Lorem Ipsum3" },
                    { 4, 2, "Lorem Ipsum4" },
                    { 5, 1, "Lorem Ipsum5" },
                    { 6, 0, "Lorem Ipsum6" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FirstName", "IsBlocked", "LastName", "UserType" },
                values: new object[] { "Test3", true, "Test3", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "IsAdmin", "IsBlocked", "LastName", "Password", "UserType", "Username" },
                values: new object[,]
                {
                    { 4, "Test4", false, false, "Test4", "test", 2, "test4" },
                    { 5, "Admin", true, false, "Admin", "admin", 0, "admin" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Secrets");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FirstName", "IsBlocked", "LastName" },
                values: new object[] { "Test2", false, "Test2" });
        }
    }
}
