using MoviesApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.WebAPI.Helpers.Dtos
{
    public class MoviesDto
    {
        public IList<Movie> Movies { get; set; }

    }
}
