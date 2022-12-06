using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieCatalog.API.Migrations
{
    public partial class add_entitys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movieEntities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Poster = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<int>(type: "int", nullable: false),
                    Tagline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Budget = table.Column<int>(type: "int", nullable: true),
                    Fees = table.Column<int>(type: "int", nullable: true),
                    AgeLimit = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movieEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserEntityes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvatarLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntityes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenreModels",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieEntityId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenreModels_movieEntities_MovieEntityId",
                        column: x => x.MovieEntityId,
                        principalTable: "movieEntities",
                        principalColumn: "Id");
                });

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
                        name: "FK_MovieEntityUserEntity_movieEntities_FavoriteMoviesId",
                        column: x => x.FavoriteMoviesId,
                        principalTable: "movieEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieEntityUserEntity_UserEntityes_UsersFavoriteId",
                        column: x => x.UsersFavoriteId,
                        principalTable: "UserEntityes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewEntities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAnonymous = table.Column<bool>(type: "bit", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AutorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewEntities_UserEntityes_AutorId",
                        column: x => x.AutorId,
                        principalTable: "UserEntityes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreModels_MovieEntityId",
                table: "GenreModels",
                column: "MovieEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieEntityUserEntity_UsersFavoriteId",
                table: "MovieEntityUserEntity",
                column: "UsersFavoriteId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewEntities_AutorId",
                table: "ReviewEntities",
                column: "AutorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreModels");

            migrationBuilder.DropTable(
                name: "MovieEntityUserEntity");

            migrationBuilder.DropTable(
                name: "ReviewEntities");

            migrationBuilder.DropTable(
                name: "movieEntities");

            migrationBuilder.DropTable(
                name: "UserEntityes");
        }
    }
}
