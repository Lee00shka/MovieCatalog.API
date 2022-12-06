using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieCatalog.API.Migrations
{
    public partial class add_entitys_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MovieId",
                table: "ReviewEntities",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewEntities_MovieId",
                table: "ReviewEntities",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewEntities_movieEntities_MovieId",
                table: "ReviewEntities",
                column: "MovieId",
                principalTable: "movieEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewEntities_movieEntities_MovieId",
                table: "ReviewEntities");

            migrationBuilder.DropIndex(
                name: "IX_ReviewEntities_MovieId",
                table: "ReviewEntities");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "ReviewEntities");
        }
    }
}
