using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserAPI.Migrations
{
    /// <inheritdoc />
    public partial class addLedgerAndLedgerMembers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ledger",
                columns: table => new
                {
                    LedgerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ledger", x => x.LedgerId);
                });

            migrationBuilder.CreateTable(
                name: "LedgerMember",
                columns: table => new
                {
                    LedgerMemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LedgerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedgerMember", x => x.LedgerMemberId);
                    table.ForeignKey(
                        name: "FK_LedgerMember_Ledger_LedgerId",
                        column: x => x.LedgerId,
                        principalTable: "Ledger",
                        principalColumn: "LedgerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LedgerMember_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LedgerMember_LedgerId",
                table: "LedgerMember",
                column: "LedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerMember_UserId",
                table: "LedgerMember",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LedgerMember");

            migrationBuilder.DropTable(
                name: "Ledger");
        }
    }
}
