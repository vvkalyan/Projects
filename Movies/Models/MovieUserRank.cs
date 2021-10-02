using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class MovieUserRank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Range(1,10)]
        public int? Ranking { get; set; }

        public Movie Movie { get; set; }

        public User User { get; set; }



    }
}
