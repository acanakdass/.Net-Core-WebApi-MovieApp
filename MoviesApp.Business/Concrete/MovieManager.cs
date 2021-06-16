using MoviesApp.Business.Abstract;
using MoviesApp.DataAccess.Abstract;
using MoviesApp.DataAccess.Concrete;
using MoviesApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Business.Concrete
{
    public class MovieManager : IMovieService
    {
        private IMovieRepository _movieRepository;

        public MovieManager(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public Movie CreateMovie(Movie movie)
        {
            return _movieRepository.CreateMovie(movie);
        }

        public void DeleteMovie(int id)
        {
            _movieRepository.DeleteMovie(id);
        }

        public async Task<List<Movie>> GetAllMovies()
        {
            return await _movieRepository.GetAllMovies();
        }

        public Movie GetMovieById(int id)
        {
            return _movieRepository.GetMovieById(id);
        }

        public Movie UpdateMovie(Movie movie)
        {
            return _movieRepository.UpdateMovie(movie);
        }
    }
}
