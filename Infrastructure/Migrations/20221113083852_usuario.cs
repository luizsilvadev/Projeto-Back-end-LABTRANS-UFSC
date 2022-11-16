using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class usuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_BOOKING_AspNetUsers_UserId",
                table: "TB_BOOKING");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_MESSAGE_AspNetUsers_UserId",
                table: "TB_MESSAGE");

            migrationBuilder.DropIndex(
                name: "IX_TB_MESSAGE_UserId",
                table: "TB_MESSAGE");

            migrationBuilder.DropIndex(
                name: "IX_TB_BOOKING_UserId",
                table: "TB_BOOKING");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TB_MESSAGE");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TB_BOOKING");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TB_MESSAGE",
                type: "nvarchar(450)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TB_BOOKING",
                type: "nvarchar(450)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.CreateIndex(
                name: "IX_TB_MESSAGE_UserId",
                table: "TB_MESSAGE",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_BOOKING_UserId",
                table: "TB_BOOKING",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_BOOKING_AspNetUsers_UserId",
                table: "TB_BOOKING",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_MESSAGE_AspNetUsers_UserId",
                table: "TB_MESSAGE",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
