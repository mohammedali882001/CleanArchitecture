using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Services;
using Application.Interfaces.UnitOfWork;
using Infrastructure.Data;

namespace Infrastructure.Implementations.uOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        public ICategoryMapper CategoryMapper { get; }
        public IMovieMapper MovieMapper { get; }
        public UnitOfWork
            (
            ApplicationDbContext context,
            ICategoryMapper categoryMapper,
            IMovieMapper movieMapper

            )
        {
            this.CategoryMapper = categoryMapper; 
            this.context = context;
            this.MovieMapper = movieMapper;
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
