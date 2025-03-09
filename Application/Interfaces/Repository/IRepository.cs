using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repository
{
    public interface IRepository<T> where T : class
    {
        public void Delete(T entity);
        public List<T> GetAll();
        public T Get(Expression<Func<T, bool>> filter);
        public void Insert(T obj);
        public void Update(T obj);

    }
}
