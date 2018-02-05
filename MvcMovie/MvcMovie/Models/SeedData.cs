using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look if any movies already exist
                if (context.Movie.Any())
                {
                    return;
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Genre = "Romantic Comedy",
                        Price = 7.99M,
                        ReleaseDate = DateTime.Parse("1989-1-11"),
                        Title = "When Harry Met Sally"
                    },
                    new Movie
                    {
                        Genre = "Comedy",
                        Price = 7.99M,
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Title = "GhostBusters"
                    },
                    new Movie
                    {
                        Genre = "Comedy",
                        Price = 7.99M,
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Title = "GhostBusters 2"
                    },
                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
