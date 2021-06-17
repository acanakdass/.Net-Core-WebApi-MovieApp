using MoviesApp.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.MVC.Models
{
    public class MovieAddAjaxModel
    {
        public MovieAddDto MovieAddDto { get; set; }
        public string MovieAddPartial { get; set; }
        public MovieDto MovieDto { get; set; }
    }
}
