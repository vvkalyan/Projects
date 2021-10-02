using Movies.Models;
using Movies.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.DataAccess
{
    public interface IMovieRepository
    {
        Movie FindMovie(string name);
        User FindUser(string name);
        MovieUserRank FindMovieUserRank(int userid, int movieId);
        List<MovieSearchResult> Find(SearchFilter searchFilter);
        List<MovieSearchResult> FindTopFiveMovies();
        List<IEnumerable<MovieSearchResult>> FindMoviesByUser(string user);
        Task<bool> UpdateMovieRating(int rating, int userId, int movieId);


    }
    public class MovieRepository : IMovieRepository
    {
        private readonly IMovieContextFactory _contextFactory;
        public MovieRepository(IMovieContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public MovieUserRank FindMovieUserRank(int userid, int movieId)
        {
            using var ctx = _contextFactory.Create();
            return ctx.MovieUserRankings.Where(x => x.UserId == userid && x.MovieId == movieId).FirstOrDefault();  
        }

        public Movie FindMovie(string name)
        {
            using var ctx = _contextFactory.Create();

            return ctx.Movies.Where(x => x.Title.Equals(name)).FirstOrDefault();
            
        }

        public User FindUser(string name)
        {
            using var ctx = _contextFactory.Create();

            return ctx.Users.Where(x => x.Name.Equals(name)).FirstOrDefault();
        }
        public List<MovieSearchResult> Find(SearchFilter searchFilter)
        {
            IQueryable<Models.Movie> query = Enumerable.Empty<Models.Movie>().AsQueryable();
            using var ctx = _contextFactory.Create();
                
            if (!string.IsNullOrEmpty(searchFilter.Title))
            {
                query = ctx.Movies.Where(m => m.Title.Contains(searchFilter.Title));
            }

            if (searchFilter.YearOfRelease > 0)
            {
                query = query.Where(x => x.YearOfRelease == searchFilter.YearOfRelease);
            }

            if (searchFilter.Genres != null && searchFilter.Genres.Count > 0)
            {
                query = query.Where(m => m.MovieGenres.Select(x => x.Genre.Name).Any(t => searchFilter.Genres.Contains(t)));
            }


            var searchResults = query.Select(s => new MovieSearchResult
            {
                Id = s.Id,
                Title = s.Title,
                YearOfRelease = s.YearOfRelease,
                Runningtime = s.Runningtime,
                Genres = string.Join(",", s.MovieGenres.Select(y => y.Genre.Name)),
                AverageRating = s.MovieUserRankings.Average(z => z.Ranking)
            }).ToList();

            searchResults.ForEach(s => s.AverageRating = Math.Round(s.AverageRating.GetValueOrDefault() * 2, MidpointRounding.AwayFromZero) / 2);

            return searchResults;

        }

        public List<IEnumerable<MovieSearchResult>> FindMoviesByUser(string user)
        {
            using var ctx = _contextFactory.Create();

            return ctx.Users.Where(m => m.Name.Contains(user))
                        .Select(s => s.MovieUserRankings.OrderByDescending(x => x.Ranking).Take(5)
                        .Select(s => new MovieSearchResult
                        {
                            Id = s.Id,
                            Title = s.Movie.Title,
                            YearOfRelease = s.Movie.YearOfRelease,
                            Runningtime = s.Movie.Runningtime,
                            Genres = string.Join(",", s.Movie.MovieGenres.Select(g => g.Genre.Name)),
                            AverageRating = Math.Round(s.Movie.MovieUserRankings.Average(z => z.Ranking).GetValueOrDefault() * 2, MidpointRounding.AwayFromZero) / 2
                        })).ToList();

        }

        public List<MovieSearchResult> FindTopFiveMovies()
        {
            using var ctx = _contextFactory.Create();

            var searchResults = ctx.Movies.Select(s => new MovieSearchResult
            {
                Id = s.Id,
                Title = s.Title,
                YearOfRelease = s.YearOfRelease,
                Runningtime = s.Runningtime,
                Genres = string.Join(",", s.MovieGenres.Select(y => y.Genre.Name)),
                AverageRating = s.MovieUserRankings.Average(z => z.Ranking)
            }).OrderByDescending(z => z.AverageRating)
                   .Take(5).ToList();

            searchResults.ForEach(s => s.AverageRating = Math.Round(s.AverageRating.GetValueOrDefault() * 2, MidpointRounding.AwayFromZero) / 2);

            return searchResults;
        }

        public async Task<bool> UpdateMovieRating(int rating, int userId, int movieId)
        {
            using var ctx = _contextFactory.Create();

            var movieUserRank = ctx.MovieUserRankings.Where(x => x.UserId == userId && x.MovieId == movieId).FirstOrDefault();
            if (movieUserRank != null)
            {
                movieUserRank.Ranking = rating;
            }
            else
            {
                movieUserRank = new Models.MovieUserRank()
                {
                    UserId = userId,
                    MovieId = movieId,
                    Ranking = rating
                };
            }
            await ctx.SaveChangesAsync();
            return true;
        }
    }
}
