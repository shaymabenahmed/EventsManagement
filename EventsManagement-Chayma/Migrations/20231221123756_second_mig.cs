using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventsManagement_Chayma.Migrations
{
    /// <inheritdoc />
    public partial class second_mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Organizer",
                columns: new[] { "Id", "Email", "Name", "phone" },
                values: new object[,]
                {
                    { 1, "email1@gmail.com", "Organizer 1", "255 641" },
                    { 2, "email2@gmail.com", "Organizer 2", "255 641" },
                    { 3, "email3@gmail.com", "Organizer 3", "255 641" }
                });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "Id", "Description", "EndDate", "Location", "OrganizerId", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, "Description 1", "15/02/2023", "Location 1", 2, "15/02/2023", "Event 1" },
                    { 2, "Description 2", "15/02/2023", "Location 2", 3, "15/02/2023", "Event 2" },
                    { 3, "Description 3", "15/02/2023", "Location 3", 1, "15/02/2023", "Event 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Organizer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Organizer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Organizer",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
