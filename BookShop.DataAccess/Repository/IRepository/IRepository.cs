using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class //we make it generic here
    {
        //T is a Category
        IEnumerable<T> GetAll();
       // T GetFirstOrDefault(); get the first or default but you can call it as only Get too
        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);

        //void Update(T entity);
        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entity);
        
    }
}
