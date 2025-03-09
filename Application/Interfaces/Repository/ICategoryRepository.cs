using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Interfaces.Repository
{
    public interface ICategoryRepository:IRepository<Category>
    {
        public Category GetCategoryWithMovies(int id);
    }
}
