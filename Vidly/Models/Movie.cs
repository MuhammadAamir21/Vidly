using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        //short cut for properties is prop + tab
        //Property are use to represent state

        //Control + Tab to quickly switch between active files or tabs in Visual studio
        //Alt + Tab for windows
        [Required]
        public int Id { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public Byte GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}