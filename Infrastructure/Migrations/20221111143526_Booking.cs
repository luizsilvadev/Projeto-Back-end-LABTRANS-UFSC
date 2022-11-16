using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Booking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_BOOKING",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BOKID = table.Column<int>(name: "BOK_ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BOKLOCAL = table.Column<int>(name: "BOK_LOCAL", type: "int", nullable: false),
                    BOKSALA = table.Column<int>(name: "BOK_SALA", type: "int", nullable: false),
                    BOKDATAHORAINICIO = table.Column<DateTime>(name: "BOK_DATA_HORA_INICIO", type: "datetime2", nullable: false),
                    BOKDATAHORAFIM = table.Column<DateTime>(name: "BOK_DATA_HORA_FIM", type: "datetime2", nullable: false),
                    BOKRESPONSAVEL = table.Column<string>(name: "BOK_RESPONSAVEL", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BOKCAFE = table.Column<bool>(name: "BOK_CAFE", type: "bit", nullable: false),
                    BOKQTDPESSOASCAFE = table.Column<int>(name: "BOK_QTD_PESSOAS_CAFE", type: "int", nullable: false),
                    BOKDESCRICAO = table.Column<string>(name: "BOK_DESCRICAO", type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_BOOKING", x => x.BOKID);
                    table.ForeignKey(
                        name: "FK_TB_BOOKING_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_BOOKING_UserId",
                table: "TB_BOOKING",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_BOOKING");
        }
    }
}
