using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Repository;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        ApplicationDbContext context;
        public CategoryRepository(ApplicationDbContext _context) : base(_context)
        {
            this.context = _context;
        }

        public Category GetCategoryWithMovies(int id)
        {
            Category category = context.Categories.Include(c=>c.Movies).FirstOrDefault(c=>c.Id==id);
            return category;
        }
    }
}
