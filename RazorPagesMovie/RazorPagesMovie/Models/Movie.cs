using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovie.Models
{
    /// <summary>
    /// The Movie class is a Plain Old CLR class (POCO) to hold the unit of a movie
    /// </summary>
    public class Movie
    {
        // ID (Primary Key of the movie
        public int ID { get; set; }
        // Title of the movie
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        // Release date of the movie
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        // Type of the movie (genre)
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        // Cost of buying/renting the movie
        [Range(1,100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        // Movie rating
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9-""'\s-]*$")]
        [Required]
        [StringLength(5)]
        public string Rating { get; set; }
    }
}
