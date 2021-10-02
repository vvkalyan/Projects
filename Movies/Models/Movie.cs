using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int YearOfRelease { get; set; }
        [Required]
        public int Runningtime { get; set; }
       
        public ICollection<User> Users { get; set; }
        public ICollection<MovieGenre> MovieGenres { get; set; }
        public ICollection<MovieUserRank> MovieUserRankings { get; set; }

    }
}
