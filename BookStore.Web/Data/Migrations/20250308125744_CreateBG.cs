using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateBG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookGenres",
                columns: table => new
                {
                    IdBook = table.Column<int>(type: "int", nullable: false),
                    IdGenre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenres", x => new { x.IdGenre, x.IdBook });
                    table.ForeignKey(
                        name: "FK_BookGenres_Books_IdBook",
                        column: x => x.IdBook,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGenres_Genre_IdGenre",
                        column: x => x.IdGenre,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookGenres_IdBook",
                table: "BookGenres",
                column: "IdBook");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookGenres");
        }
    }
}
