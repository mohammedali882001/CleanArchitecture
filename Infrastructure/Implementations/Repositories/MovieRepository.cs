using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Movie;
using Application.Interfaces.Repository;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        ApplicationDbContext context;
        public MovieRepository(ApplicationDbContext _context) : base(_context)
        {
            context = _context;
        }

        public Movie GetMovieWithCategory(int id)
        {
            Movie movie = context.Movies.Include(m=>m.Category).FirstOrDefault(m=>m.Id==id);
            return movie;
        }
    }
}
