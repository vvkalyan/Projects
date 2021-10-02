using System;

namespace Movies
{
    public class MovieSearchResult
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int YearOfRelease { get; set; }

        public int Runningtime { get; set; }

        public string Genres { get; set; }

        public double? AverageRating { get; set; }
    }
}
