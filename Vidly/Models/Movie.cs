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
        public int Id { get; set; }

        [Required]
        public Genre Genre { get; set; }

        public Byte GenreId { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        public int NumberInStock { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}