using MoviesApp.DataAccess.Abstract;
using MoviesApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.DataAccess.Concrete
{
    public class MovieRepository : IMovieRepository
    {
        public Movie CreateMovie(Movie movie)
        {
            using (var movieDbContext = new MoviesDbContext())
            {
                movieDbContext.Movies.Add(movie);
                movieDbContext.SaveChanges();
                return movie;
            }

        }

        public void DeleteMovie(int id)
        {
            using (var movieDbContext = new MoviesDbContext())
            {
                var movieToDelete = GetMovieById(id);
                movieDbContext.Movies.Remove(movieToDelete);
                movieDbContext.SaveChanges();
            }
        }

        public List<Movie> GetAllMovies()
        {
            using (var movieDbContext = new MoviesDbContext())
            {
                return movieDbContext.Movies.ToList();
            }
        }

        public Movie GetMovieById(int id)
        {
            using (var movieDbContext = new MoviesDbContext())
            {
                var movie = movieDbContext.Movies.Find(id);
                return movie;
            }
        }

        public Movie UpdateMovie(Movie movie)
        {
            using (var movieDbContext = new MoviesDbContext())
            {
                movieDbContext.Movies.Update(movie);
                movieDbContext.SaveChanges();
                return movie;
            }

        }
    }
}
