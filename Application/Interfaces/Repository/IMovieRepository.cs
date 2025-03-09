using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Movie;
using Domain.Models;

namespace Application.Interfaces.Repository
{
    public interface IMovieRepository:IRepository<Movie>
    {
       public Movie GetMovieWithCategory(int id);
    }
}
