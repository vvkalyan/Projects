using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Moq;
using Movies;
using Movies.DataAccess;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using Xunit;

namespace MoviesUnitTests
{
    public class MovieTest
    {
        private readonly DbConnection _connection;

        MoviesDbContext injectedContext;

        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            return connection;
        }

        [Fact]
        public async void MoviesTest()
        {


            var dbObjects = new List<Object>()
            //dbObjects.Add(new Genre() { Id = 1, Name = "Action" });


            {
                new Genre() { Id = 6, Name = "Action" } ,
                new Genre() { Id = 7, Name = "Comedy" },
                new Genre() { Id = 8, Name = "Animation"},
                new Genre() { Id = 9, Name = "Horror" },
                new Genre() { Id = 10, Name = "Thriller"}, 

                new User() { Id = 4, Name = "Rick" },
                new User() { Id = 5, Name = "Perry" },
                new User() { Id = 6, Name = "Jack" },

                new Movie() { Id = 11, Title = "Skyfall", Runningtime = 143, YearOfRelease = 2012 },
                new Movie() { Id = 12, Title = "Star Wars: The Force Awakens", Runningtime = 136, YearOfRelease = 2015 },
                new Movie() { Id = 13, Title = "Bridesmaids", Runningtime = 125, YearOfRelease = 2011 },
                new Movie() { Id = 14, Title = "God Bless America", Runningtime = 99, YearOfRelease = 2012 },
                new Movie() { Id = 15, Title = "Zootopia", Runningtime = 148, YearOfRelease = 2016 },
                new Movie() { Id = 16, Title = "Coco", Runningtime = 109, YearOfRelease = 2017 },
                new Movie() { Id = 17, Title = "Us", Runningtime = 116, YearOfRelease = 2019 },
                new Movie() { Id = 18, Title = "Relic", Runningtime = 89, YearOfRelease = 2020 },
                new Movie() { Id = 19, Title = "Shutter Island", Runningtime = 138, YearOfRelease = 2010 },
                new Movie() { Id = 20, Title = "The Silence of the Lambs", Runningtime = 119, YearOfRelease = 2001 },

                new MovieGenre() { Id = 11, MovieId = 1, GenreId = 1 },
                new MovieGenre() { Id = 12, MovieId = 2, GenreId = 1 },
                new MovieGenre() { Id = 13, MovieId = 3, GenreId = 2 },
                new MovieGenre() { Id = 14, MovieId = 4, GenreId = 2 },
                new MovieGenre() { Id = 15, MovieId = 5, GenreId = 3 },
                new MovieGenre() { Id = 16, MovieId = 6, GenreId = 3 },
                new MovieGenre() { Id = 17, MovieId = 7, GenreId = 4 },
                new MovieGenre() { Id = 18, MovieId = 8, GenreId = 4 },
                new MovieGenre() { Id = 19, MovieId = 9, GenreId = 5 },
                new MovieGenre() { Id = 20, MovieId = 10, GenreId = 5 },
                //some movie have more than 1 genre
                
                new MovieGenre() { Id = 21, MovieId = 5, GenreId = 2 },
                new MovieGenre() { Id = 22, MovieId = 6, GenreId = 2 },
                new MovieGenre() { Id = 23, MovieId = 9, GenreId = 1 },
                new MovieGenre() { Id = 24, MovieId = 10, GenreId = 1 },

                new MovieUserRank() { Id = 25, UserId = 4, MovieId =11, Ranking = 1 },
                 new MovieUserRank() { Id = 26, UserId = 4, MovieId = 12, Ranking = 4 },
                 new MovieUserRank() { Id = 27, UserId = 4, MovieId = 13, Ranking = 10 },
                 new MovieUserRank() { Id = 28, UserId = 4, MovieId = 14, Ranking = 3 },
                 new MovieUserRank() { Id = 29, UserId = 4, MovieId = 15, Ranking = 7 },
                 new MovieUserRank() { Id = 30, UserId = 4, MovieId = 16, Ranking = 4 },
                 new MovieUserRank() { Id = 31, UserId = 4, MovieId = 17, Ranking = 5 },
                 new MovieUserRank() { Id = 32, UserId = 4, MovieId = 18, Ranking = 5 },

                 new MovieUserRank() { Id = 33, UserId = 2, MovieId = 1, Ranking = 1 },
                 new MovieUserRank() { Id = 34, UserId = 2, MovieId = 2, Ranking = 5 },
                 new MovieUserRank() { Id = 35, UserId = 2, MovieId = 3, Ranking = 10 },
                 new MovieUserRank() { Id = 36, UserId = 2, MovieId = 4, Ranking = 6 },
                 new MovieUserRank() { Id = 37, UserId = 2, MovieId = 5, Ranking = 7 },
                 new MovieUserRank() { Id = 38, UserId = 2, MovieId = 6, Ranking = 2 },
                 new MovieUserRank() { Id = 39, UserId = 2, MovieId = 7, Ranking = 7 },
                 new MovieUserRank() { Id = 40, UserId = 2, MovieId = 8, Ranking = 5 },

                 new MovieUserRank() { Id = 41, UserId = 3, MovieId = 3, Ranking = 3 },
                 new MovieUserRank() { Id = 42, UserId = 3, MovieId = 4, Ranking = 4 },
                 new MovieUserRank() { Id = 43, UserId = 3, MovieId = 5, Ranking = 5 },
                 new MovieUserRank() { Id = 44, UserId = 3, MovieId = 6, Ranking = 6 },
                 new MovieUserRank() { Id = 45, UserId = 3, MovieId = 7, Ranking = 4 },
                 new MovieUserRank() { Id = 46, UserId = 3, MovieId = 8, Ranking = 4 },
                 new MovieUserRank() { Id = 47, UserId = 3, MovieId = 9, Ranking = 3 },
                 new MovieUserRank() { Id = 48, UserId = 3, MovieId = 10, Ranking = 2 }


            };



        var inMemoryDatabaseRoot = new InMemoryDatabaseRoot();
            var inMemDbInstance = Guid.NewGuid().ToString();

            var dbContextOptions = new DbContextOptionsBuilder<MoviesDbContext>().UseInMemoryDatabase(inMemDbInstance).Options;
            var contextFac = new Mock<IMovieContextFactory>();

            contextFac.Setup(c => c.Create()).Returns(() => new MoviesDbContext(dbContextOptions));
            var injectedContext = new MoviesDbContext(dbContextOptions);

            injectedContext.Database.EnsureDeleted();
            injectedContext.Database.EnsureCreated();
            injectedContext.AddRange(dbObjects);
            //injectedContext.SaveChanges();


            //ACT  

            var _movieRepository = new MovieRepository(contextFac.Object);

            //var movies =  _movieRepository.Find(new Movies.Search.SearchFilter { Title = "Skyfall", YearOfRelease = 2012, Genres = new List<string>(){ "Action"}});
            await _movieRepository.UpdateMovieRating(2, 1, 1);

            var movieuserRank = _movieRepository.FindMovieUserRank(1, 1); 
            Assert.True(movieuserRank.Ranking == 2, "");

            

        }
    }
}
