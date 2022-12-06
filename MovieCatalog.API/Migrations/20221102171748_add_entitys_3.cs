using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieCatalog.API.Migrations
{
    public partial class add_entitys_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreModels_movieEntities_MovieEntityId",
                table: "GenreModels");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieEntityUserEntity_movieEntities_FavoriteMoviesId",
                table: "MovieEntityUserEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieEntityUserEntity_UserEntityes_UsersFavoriteId",
                table: "MovieEntityUserEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewEntities_movieEntities_MovieId",
                table: "ReviewEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewEntities_UserEntityes_AutorId",
                table: "ReviewEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEntityes",
                table: "UserEntityes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReviewEntities",
                table: "ReviewEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movieEntities",
                table: "movieEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenreModels",
                table: "GenreModels");

            migrationBuilder.RenameTable(
                name: "UserEntityes",
                newName: "UserEntitys");

            migrationBuilder.RenameTable(
                name: "ReviewEntities",
                newName: "ReviewEntitys");

            migrationBuilder.RenameTable(
                name: "movieEntities",
                newName: "MovieEntitys");

            migrationBuilder.RenameTable(
                name: "GenreModels",
                newName: "GenreEntitys");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewEntities_MovieId",
                table: "ReviewEntitys",
                newName: "IX_ReviewEntitys_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewEntities_AutorId",
                table: "ReviewEntitys",
                newName: "IX_ReviewEntitys_AutorId");

            migrationBuilder.RenameIndex(
                name: "IX_GenreModels_MovieEntityId",
                table: "GenreEntitys",
                newName: "IX_GenreEntitys_MovieEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEntitys",
                table: "UserEntitys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReviewEntitys",
                table: "ReviewEntitys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieEntitys",
                table: "MovieEntitys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenreEntitys",
                table: "GenreEntitys",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TokenEntitys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenEntitys", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_GenreEntitys_MovieEntitys_MovieEntityId",
                table: "GenreEntitys",
                column: "MovieEntityId",
                principalTable: "MovieEntitys",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieEntityUserEntity_MovieEntitys_FavoriteMoviesId",
                table: "MovieEntityUserEntity",
                column: "FavoriteMoviesId",
                principalTable: "MovieEntitys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieEntityUserEntity_UserEntitys_UsersFavoriteId",
                table: "MovieEntityUserEntity",
                column: "UsersFavoriteId",
                principalTable: "UserEntitys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewEntitys_MovieEntitys_MovieId",
                table: "ReviewEntitys",
                column: "MovieId",
                principalTable: "MovieEntitys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewEntitys_UserEntitys_AutorId",
                table: "ReviewEntitys",
                column: "AutorId",
                principalTable: "UserEntitys",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreEntitys_MovieEntitys_MovieEntityId",
                table: "GenreEntitys");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieEntityUserEntity_MovieEntitys_FavoriteMoviesId",
                table: "MovieEntityUserEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieEntityUserEntity_UserEntitys_UsersFavoriteId",
                table: "MovieEntityUserEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewEntitys_MovieEntitys_MovieId",
                table: "ReviewEntitys");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewEntitys_UserEntitys_AutorId",
                table: "ReviewEntitys");

            migrationBuilder.DropTable(
                name: "TokenEntitys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEntitys",
                table: "UserEntitys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReviewEntitys",
                table: "ReviewEntitys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieEntitys",
                table: "MovieEntitys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenreEntitys",
                table: "GenreEntitys");

            migrationBuilder.RenameTable(
                name: "UserEntitys",
                newName: "UserEntityes");

            migrationBuilder.RenameTable(
                name: "ReviewEntitys",
                newName: "ReviewEntities");

            migrationBuilder.RenameTable(
                name: "MovieEntitys",
                newName: "movieEntities");

            migrationBuilder.RenameTable(
                name: "GenreEntitys",
                newName: "GenreModels");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewEntitys_MovieId",
                table: "ReviewEntities",
                newName: "IX_ReviewEntities_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewEntitys_AutorId",
                table: "ReviewEntities",
                newName: "IX_ReviewEntities_AutorId");

            migrationBuilder.RenameIndex(
                name: "IX_GenreEntitys_MovieEntityId",
                table: "GenreModels",
                newName: "IX_GenreModels_MovieEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEntityes",
                table: "UserEntityes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReviewEntities",
                table: "ReviewEntities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movieEntities",
                table: "movieEntities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenreModels",
                table: "GenreModels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreModels_movieEntities_MovieEntityId",
                table: "GenreModels",
                column: "MovieEntityId",
                principalTable: "movieEntities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieEntityUserEntity_movieEntities_FavoriteMoviesId",
                table: "MovieEntityUserEntity",
                column: "FavoriteMoviesId",
                principalTable: "movieEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieEntityUserEntity_UserEntityes_UsersFavoriteId",
                table: "MovieEntityUserEntity",
                column: "UsersFavoriteId",
                principalTable: "UserEntityes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewEntities_movieEntities_MovieId",
                table: "ReviewEntities",
                column: "MovieId",
                principalTable: "movieEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewEntities_UserEntityes_AutorId",
                table: "ReviewEntities",
                column: "AutorId",
                principalTable: "UserEntityes",
                principalColumn: "Id");
        }
    }
}
