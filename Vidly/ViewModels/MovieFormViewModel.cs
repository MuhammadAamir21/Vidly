using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }

        //public Movie Movie { get; set; }
        //Pure view model just to get rid of pre populated data in model
        //Arrive from id being null :0
        [Required]
        public int? Id { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public Byte? GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Number In Stock")]
        public int? NumberInStock { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public string Tittle
        {
            get
            {
                //if (Movie != null && Movie.Id != 0)
                if (Id != 0)
                {
                    return "Edit Movie";
                }
                else
                {
                    return "New Movie";
                }
            }
        }
    }
}