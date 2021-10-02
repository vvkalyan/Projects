using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.DataAccess
{
    public interface IMovieContextFactory
    {
        MoviesDbContext Create();
    }

    public class MovieContextFactory : IMovieContextFactory
    {
        private readonly string _connectionString;

        public MovieContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MoviesDbContext Create()
        {
            var optsBuilder = new DbContextOptionsBuilder<MoviesDbContext>();
            optsBuilder.UseSqlServer(_connectionString);
            var db = new MoviesDbContext(optsBuilder.Options);
            db.Database.EnsureCreated();
            return db;
        }
    }
}
