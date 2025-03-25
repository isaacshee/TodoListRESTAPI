using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoListRESTAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "title",
                table: "TodoItems",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "TodoItems",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "dueDate",
                table: "TodoItems",
                newName: "DueDate");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "TodoItems",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "TodoItems",
                newName: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "TodoItems",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "TodoItems",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "DueDate",
                table: "TodoItems",
                newName: "dueDate");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "TodoItems",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "TodoItems",
                newName: "id");
        }
    }
}
