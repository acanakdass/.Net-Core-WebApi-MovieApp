using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Entities.Dtos
{
    public class MovieAddDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DisplayName("Film Adı")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string Artists { get; set; }
        [Required]
        public string Subject { get; set; }
    }
}
