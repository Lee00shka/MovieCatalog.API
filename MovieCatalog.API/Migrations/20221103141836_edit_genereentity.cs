using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieCatalog.API.Migrations
{
    public partial class edit_genereentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreEntitys_MovieEntitys_MovieEntityId",
                table: "GenreEntitys");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewEntitys_MovieEntitys_MovieId",
                table: "ReviewEntitys");

            migrationBuilder.DropTable(
                name: "MovieEntityUserEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieEntitys",
                table: "MovieEntitys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenreEntitys",
                table: "GenreEntitys");

            migrationBuilder.DropIndex(
                name: "IX_GenreEntitys_MovieEntityId",
                table: "GenreEntitys");

            migrationBuilder.DropColumn(
                name: "MovieEntityId",
                table: "GenreEntitys");

            migrationBuilder.RenameTable(
                name: "MovieEntitys",
                newName: "MovieEntity");

            migrationBuilder.RenameTable(
                name: "GenreEntitys",
                newName: "GenreEntity");

            migrationBuilder.AddColumn<string>(
                name: "MovieEntityId",
                table: "UserEntitys",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MovieId",
                table: "ReviewEntitys",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieEntity",
                table: "MovieEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenreEntity",
                table: "GenreEntity",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GenreEntityMovieEntity",
                columns: table => new
                {
                    GeneresId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MoviesId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreEntityMovieEntity", x => new { x.GeneresId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_GenreEntityMovieEntity_GenreEntity_GeneresId",
                        column: x => x.GeneresId,
                        principalTable: "GenreEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreEntityMovieEntity_MovieEntity_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "MovieEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserEntitys_MovieEntityId",
                table: "UserEntitys",
                column: "MovieEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreEntityMovieEntity_MoviesId",
                table: "GenreEntityMovieEntity",
                column: "MoviesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewEntitys_MovieEntity_MovieId",
                table: "ReviewEntitys",
                column: "MovieId",
                principalTable: "MovieEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEntitys_MovieEntity_MovieEntityId",
                table: "UserEntitys",
                column: "MovieEntityId",
                principalTable: "MovieEntity",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewEntitys_MovieEntity_MovieId",
                table: "ReviewEntitys");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEntitys_MovieEntity_MovieEntityId",
                table: "UserEntitys");

            migrationBuilder.DropTable(
                name: "GenreEntityMovieEntity");

            migrationBuilder.DropIndex(
                name: "IX_UserEntitys_MovieEntityId",
                table: "UserEntitys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieEntity",
                table: "MovieEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenreEntity",
                table: "GenreEntity");

            migrationBuilder.DropColumn(
                name: "MovieEntityId",
                table: "UserEntitys");

            migrationBuilder.RenameTable(
                name: "MovieEntity",
                newName: "MovieEntitys");

            migrationBuilder.RenameTable(
                name: "GenreEntity",
                newName: "GenreEntitys");

            migrationBuilder.AlterColumn<string>(
                name: "MovieId",
                table: "ReviewEntitys",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MovieEntityId",
                table: "GenreEntitys",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieEntitys",
                table: "MovieEntitys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenreEntitys",
                table: "GenreEntitys",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MovieEntityUserEntity",
                columns: table => new
                {
                    FavoriteMoviesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UsersFavoriteId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieEntityUserEntity", x => new { x.FavoriteMoviesId, x.UsersFavoriteId });
                    table.ForeignKey(
                        name: "FK_MovieEntityUserEntity_MovieEntitys_FavoriteMoviesId",
                        column: x => x.FavoriteMoviesId,
                        principalTable: "MovieEntitys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieEntityUserEntity_UserEntitys_UsersFavoriteId",
                        column: x => x.UsersFavoriteId,
                        principalTable: "UserEntitys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreEntitys_MovieEntityId",
                table: "GenreEntitys",
                column: "MovieEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieEntityUserEntity_UsersFavoriteId",
                table: "MovieEntityUserEntity",
                column: "UsersFavoriteId");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreEntitys_MovieEntitys_MovieEntityId",
                table: "GenreEntitys",
                column: "MovieEntityId",
                principalTable: "MovieEntitys",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewEntitys_MovieEntitys_MovieId",
                table: "ReviewEntitys",
                column: "MovieId",
                principalTable: "MovieEntitys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
