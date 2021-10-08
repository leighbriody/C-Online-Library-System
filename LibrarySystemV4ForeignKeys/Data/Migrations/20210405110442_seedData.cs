using Microsoft.EntityFrameworkCore.Migrations;

namespace LibrarySystemV4ForeignKeys.Data.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            //Populate Genre Table
            migrationBuilder.InsertData(
               table: "Genres",
               columns: new[] { "Id", "genreType" },
               values: new object[,]
               {
                    { 1, "Drama" },
                    { 2, "SciFi" },
                    { 3, "Romance" },
                    { 4, "Thriller" }
               });

            //Populate Books Table
            //Populate Books Table
            migrationBuilder.InsertData(
            table: "Books",
            columns: new[] { "id", "bookName", "author", "description", "quantity", "overdueFeePerDay" , "genreId" },
            values: new object[,]
            {
                    { 1, "Harry" , "J.K.Rowling"  , "Must Read" , 200 , 2 , 4},
                    { 2, "Mission 2" , "Harry King"  , "Must Read", 200 , 1 , 1},
                     { 3, "All Go" , "Dean Morris" , "Must Read", 200 , 1 , 3 },
                      { 4, "The Captain" , "Jannet Stone" , "Must Read" , 200 , 1 , 4 }
            });

            //No need to populate loans

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
