using System;
using System.Collections.Generic;
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
        public string Title { get; set; }
        // Release date of the movie
        public DateTime ReleaseDate { get; set; }
        // Type of the movie (genre)
        public string Genre { get; set; }
        // Cost of buying/renting the movie
        public decimal Price { get; set; }
    }
}
