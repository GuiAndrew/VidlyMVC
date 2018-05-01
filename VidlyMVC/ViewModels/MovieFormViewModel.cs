using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyMVC.Models;

namespace VidlyMVC.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required(ErrorMessage = "The Name field is required!")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Release Date field is required!")]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required(ErrorMessage = "The Number in Stock field is required!")]
        [Display(Name = "Number in Stock")]
        [Range(1, 20, ErrorMessage = "The value must be between 1 and 20!")]
        public byte? Stock { get; set; }

        //Property of Navigation:        
        [Display(Name = "Genre")]
        [Required(ErrorMessage = "The Genre field is required!")]
        public byte? GenreId { get; set; } //To use as a foreign key.

        public string Title
        {
            get
            {
                //if (Id != 0)
                //{
                //    return "Edit Movie";
                //}

                //return "New Movie";
                //OR:
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        // The ctor empty is use when a new movie is created.
        public MovieFormViewModel()
        {
            Id = 0; //This is to populate the hidden field in the view MovieForm.
        }
        // This ctor is for the update, etc.
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            Stock = movie.Stock;
            GenreId = movie.GenreId;
        }
    }
}