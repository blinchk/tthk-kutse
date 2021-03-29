using Microsoft.EntityFrameworkCore.Migrations;

namespace KutseApp.Data.Migrations
{
    public partial class Guests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Confirmed",
                table: "Guest",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Guest",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guest_EventId",
                table: "Guest",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guest_Event_EventId",
                table: "Guest",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guest_Event_EventId",
                table: "Guest");

            migrationBuilder.DropIndex(
                name: "IX_Guest_EventId",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "Confirmed",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Guest");
        }
    }
}
