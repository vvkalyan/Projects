using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Comedy" },
                    { 3, "Animation" },
                    { 4, "Horror" },
                    { 5, "Thriller" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Rick" },
                    { 2, "Perry" },
                    { 3, "Jack" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "GenreId", "Runningtime", "Title", "YearOfRelease" },
                values: new object[,]
                {
                    { 1, 1, 143, "Skyfall", 2012 },
                    { 2, 1, 136, "Star Wars: The Force Awakens", 2015 },
                    { 3, 2, 125, "Bridesmaids", 2011 },
                    { 4, 2, 99, "God Bless America", 2012 },
                    { 5, 3, 148, "Zootopia", 2016 },
                    { 6, 3, 109, "Coco", 2017 },
                    { 7, 4, 116, "Us", 2019 },
                    { 8, 4, 89, "Relic", 2020 },
                    { 9, 5, 138, "Shutter Island", 2010 },
                    { 10, 5, 119, "The Silence of the Lambs", 2001 }
                });

            migrationBuilder.InsertData(
                table: "MovieUserRankings",
                columns: new[] { "Id", "MovieId", "Ranking", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 22, 8, 4, 3 },
                    { 16, 8, 5, 2 },
                    { 8, 8, 5, 1 },
                    { 21, 7, 4, 3 },
                    { 15, 7, 7, 2 },
                    { 7, 7, 5, 1 },
                    { 20, 6, 6, 3 },
                    { 14, 6, 2, 2 },
                    { 6, 6, 4, 1 },
                    { 19, 5, 5, 3 },
                    { 13, 5, 7, 2 },
                    { 5, 5, 7, 1 },
                    { 18, 4, 4, 3 },
                    { 12, 4, 6, 2 },
                    { 4, 4, 3, 1 },
                    { 17, 3, 3, 3 },
                    { 11, 3, 10, 2 },
                    { 3, 3, 10, 1 },
                    { 10, 2, 5, 2 },
                    { 2, 2, 4, 1 },
                    { 9, 1, 1, 2 },
                    { 23, 9, 3, 3 },
                    { 24, 10, 2, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieUserRankings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MovieUserRankings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MovieUserRankings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MovieUserRankings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MovieUserRankings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MovieUserRankings",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MovieUserRankings",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MovieUserRankings",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MovieUserRankings",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MovieUserRankings",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MovieUserRankings",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MovieUserRankings",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MovieUserRankings",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "MovieUserRankings",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "MovieUserRankings",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "MovieUserRankings",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "MovieUserRankings",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "MovieUserRankings",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "MovieUserRankings",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "MovieUserRankings",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "MovieUserRankings",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "MovieUserRankings",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "MovieUserRankings",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "MovieUserRankings",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
