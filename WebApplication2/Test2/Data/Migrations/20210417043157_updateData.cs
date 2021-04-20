using Microsoft.EntityFrameworkCore.Migrations;

namespace Test2.Data.Migrations
{
    public partial class updateData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Janrs_JanrId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Janrs");

            migrationBuilder.RenameColumn(
                name: "Fio",
                table: "Students",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "JanrId",
                table: "Books",
                newName: "GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_JanrId",
                table: "Books",
                newName: "IX_Books_GenreId");

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenreId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Genres_GenreId",
                table: "Genres",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Genres_GenreId",
                table: "Books",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Genres_GenreId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Students",
                newName: "Fio");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Books",
                newName: "JanrId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                newName: "IX_Books_JanrId");

            migrationBuilder.CreateTable(
                name: "Janrs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JanrId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Janrs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Janrs_Janrs_JanrId",
                        column: x => x.JanrId,
                        principalTable: "Janrs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Janrs_JanrId",
                table: "Janrs",
                column: "JanrId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Janrs_JanrId",
                table: "Books",
                column: "JanrId",
                principalTable: "Janrs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
