using BlazorMovies.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Services
{
    public class RepositoryInMemory : IRepository
    {
        public List<Movie> GetMovies()
        {
            return new List<Movie>()
            {
                new Movie(){Title = "Moana", ReleaseDate = new DateTime(2016, 11, 23)},
                new Movie(){Title = "Inception", ReleaseDate = new DateTime(2010, 7, 16)},
                new Movie(){Title = "Spiderman: Which actor is it this time?", ReleaseDate = new DateTime(2020, 10, 11)}
            };
        }
    }
}
