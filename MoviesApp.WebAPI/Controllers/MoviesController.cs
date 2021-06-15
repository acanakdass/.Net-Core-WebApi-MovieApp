using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoviesApp.Business.Abstract;
using MoviesApp.Business.Concrete;
using MoviesApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var movies = _movieService.GetAllMovies();
            return Ok(movies); //200 ok döndür ve body'sine movies ekle
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie != null)
            {
                return Ok(movie); //200 ok => body'de movie ile birlikte
            }
            return NotFound();//404
        }

        [HttpPost]
        public IActionResult Post([FromBody] Movie movie)  //[FromBody] =>> gelen body'de Movie beklediğini belirtir
        {
            if (ModelState.IsValid)
            {
                var createdMovie = _movieService.CreateMovie(movie);
                return CreatedAtAction("Get", new { id = createdMovie.Id }, createdMovie);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public Movie Put([FromBody] Movie movie)  //[FromBody] =>> gelen body'de Movie beklediğini belirtir
        {
            return _movieService.UpdateMovie(movie);
        }

        [HttpDelete]
        public void Delete(int id)  //[FromBody] =>> gelen body'de Movie beklediğini belirtir
        {
            _movieService.DeleteMovie(id);
        }

    }
}
