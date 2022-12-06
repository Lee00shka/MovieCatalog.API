using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieCatalog.API.Migrations
{
    public partial class edit_genereentity_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreEntityMovieEntity_GenreEntity_GeneresId",
                table: "GenreEntityMovieEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreEntityMovieEntity_MovieEntity_MoviesId",
                table: "GenreEntityMovieEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewEntitys_MovieEntity_MovieId",
                table: "ReviewEntitys");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEntitys_MovieEntity_MovieEntityId",
                table: "UserEntitys");

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
                name: "IX_MovieEntityUserEntity_UsersFavoriteId",
                table: "MovieEntityUserEntity",
                column: "UsersFavoriteId");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreEntityMovieEntity_GenreEntitys_GeneresId",
                table: "GenreEntityMovieEntity",
                column: "GeneresId",
                principalTable: "GenreEntitys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreEntityMovieEntity_MovieEntitys_MoviesId",
                table: "GenreEntityMovieEntity",
                column: "MoviesId",
                principalTable: "MovieEntitys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewEntitys_MovieEntitys_MovieId",
                table: "ReviewEntitys",
                column: "MovieId",
                principalTable: "MovieEntitys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreEntityMovieEntity_GenreEntitys_GeneresId",
                table: "GenreEntityMovieEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreEntityMovieEntity_MovieEntitys_MoviesId",
                table: "GenreEntityMovieEntity");

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

            migrationBuilder.CreateIndex(
                name: "IX_UserEntitys_MovieEntityId",
                table: "UserEntitys",
                column: "MovieEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreEntityMovieEntity_GenreEntity_GeneresId",
                table: "GenreEntityMovieEntity",
                column: "GeneresId",
                principalTable: "GenreEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreEntityMovieEntity_MovieEntity_MoviesId",
                table: "GenreEntityMovieEntity",
                column: "MoviesId",
                principalTable: "MovieEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
