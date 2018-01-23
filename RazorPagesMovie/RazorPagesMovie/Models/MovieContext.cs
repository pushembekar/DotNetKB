using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesMovie.Models
{
    /// <summary>
    /// MovieContext class defines the database context or the "object" that will be used to talk to the database
    /// for the entity "Movie"
    /// </summary>
    public class MovieContext : DbContext
    {
        // Dependency injection of DbContextOptions in the contructor
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {

        }

        // Entity to hold the list of Movies
        public DbSet<Movie> Movie { get; set; }
    }
}
