using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext _context)
        {
            context = _context;
            this.dbSet = context.Set<T>();
        }
        public virtual void Delete(T entity)
        {

            dbSet.Update(entity);
        }
        public virtual List<T> GetAll()
        {
            IQueryable<T> query = dbSet;

            return query.ToList();
        }
        public virtual T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }
        public void Insert(T obj)
        {
            dbSet.Add(obj);
        }
      
        public void Update(T obj)
        {
            dbSet.Update(obj);
        }
    }
}
