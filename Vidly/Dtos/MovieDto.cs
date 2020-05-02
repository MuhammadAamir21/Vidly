using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        [Required]
        public int Id { get; set; }

        public GenreDto Genre { get; set; }

        [Required]
        public Byte GenreId { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(1, 20)]
        public int NumberInStock { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}