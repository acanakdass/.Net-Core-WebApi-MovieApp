using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoviesApp.Business.Abstract;
using MoviesApp.Business.Concrete;
using MoviesApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
        [Route("[action]")]
        //[EnableCors]
        public async Task<IActionResult> GetAll()
        {
            var movies = await _movieService.GetAllMovies();
            var moviesJson = JsonSerializer.Serialize(movies);
            return Ok(movies); //200 ok döndür ve body'sine movies ekle
        }
        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie != null)
            {
                return Ok(movie); //200 ok => body'de movie ile birlikte
            }
            return NotFound();//404
        }

        [HttpGet]
        [Route("[action]/{name}")]
        public IActionResult GetMovieByName(string name)
        {
            //var movie = _movieService.GetAllMovies().Where(m=>m.Name==name).FirstOrDefault();
            //if (movie != null)
            //{
            //    return Ok(movie); //200 ok => body'de movie ile birlikte
            //}
            return NotFound();//404
        }

        [HttpPost]
        [Route("[action]")]
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
        [Route("[action]")]
        public IActionResult Put([FromBody] Movie movie)  //[FromBody] =>> gelen body'de Movie beklediğini belirtir
        {
            if (ModelState.IsValid)
            {
                var updatedMovie = _movieService.UpdateMovie(movie);
                return Ok(updatedMovie); //200
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete(int id)  //[FromBody] =>> gelen body'de Movie beklediğini belirtir
        {
            var movieToDelete = _movieService.GetMovieById(id);
            if (movieToDelete != null)
            {
                _movieService.DeleteMovie(id);
                return Ok(); //200
            }
            return NotFound();
        }

    }
}
