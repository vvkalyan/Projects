using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Movies.Search;
using Movies.DataAccess;

namespace Movies.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {

        private readonly ILogger<MoviesController> _logger;
        private readonly IMovieRepository _movieRepository;

        public MoviesController(ILogger<MoviesController> logger, IMovieRepository movieRepository)
        {
            _logger = logger;
            _movieRepository = movieRepository;  
        }

        [HttpGet]
        [Route("/SearchMovies")]
        public async Task<IActionResult> GetMovies([FromQuery] SearchFilter searchFilter)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Custom validator for now - to be refactored
                    List<string> genres = new List<string>() { "Action", "Comedy", "Animation", "Horror", "Thriller" };

                    if (searchFilter.Genres != null && searchFilter.Genres.Intersect(genres).Count() == 0)
                    {
                        return BadRequest();
                    }

                    List<MovieSearchResult> searchResults = _movieRepository.Find(searchFilter);
                    
                    if (searchResults != null || searchResults.Count > 0)
                    {
                        return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(searchResults));
                    }
                    else
                    {
                        return NotFound();
                    }

                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error :{0}" + ex.ToString());
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("/TopFiveMovies")]
        public async Task<IActionResult> GetMoviesTopFive()
        {
            try
            {
                if (ModelState.IsValid)
                {

                    List<MovieSearchResult> searchResults = _movieRepository.FindTopFiveMovies();
                  
                    if (searchResults != null || searchResults.Count > 0)
                    {
                        return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(searchResults));
                    }
                    else
                    {
                        return NotFound();
                    }

                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error :{0}" + ex.ToString());
                return BadRequest();
            }



        }

        [HttpGet]
        [Route("/TopFiveMoviesbyUser")]
        public async Task<IActionResult> GetTopFiveMoviesByUser([FromQuery] string user = "")
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var searchResults = _movieRepository.FindMoviesByUser(user);  
                    if (searchResults != null && searchResults.Count > 0)
                    {
                        return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(searchResults));
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error :{0}" + ex.ToString());
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("/UpdateMovieRanking")]
        public async Task<IActionResult> UpdateMovieRanking([FromQuery] int ranking, string movieName = "", string userName = "")
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (ranking < 0 || ranking > 5)
                    {
                        return BadRequest();
                    }

                    var movie = _movieRepository.FindMovie(movieName);
                    var user = _movieRepository.FindUser(userName);

                    if (movie is null || movie.Id < 1 || user is null || user.Id < 1)
                    {
                        return BadRequest();
                    }

                    await _movieRepository.UpdateMovieRating(ranking, user.Id, movie.Id); 
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }

            catch (Exception ex)
            {
                _logger.LogError($"Error:{0}", ex.ToString());
                return BadRequest();
            }
        }





    }
}
