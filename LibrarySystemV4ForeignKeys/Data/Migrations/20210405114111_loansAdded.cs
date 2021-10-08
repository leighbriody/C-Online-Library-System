using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibrarySystemV4ForeignKeys.Data.Migrations
{
    public partial class loansAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    loanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookId = table.Column<int>(nullable: false),
                    username = table.Column<string>(nullable: true),
                    dateTaken = table.Column<DateTime>(nullable: false),
                    dueDate = table.Column<DateTime>(nullable: false),
                    dateReturned = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.loanId);
                    table.ForeignKey(
                        name: "FK_Loans_Books_bookId",
                        column: x => x.bookId,
                        principalTable: "Books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loans_bookId",
                table: "Loans",
                column: "bookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");
        }
    }
}
