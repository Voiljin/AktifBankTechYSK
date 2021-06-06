using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Data.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        T Get(int id);
        T Add(T entity);
        void Update(T entity);
        void UpdateAll(Expression<Func<T, bool>> filter, Expression<Func<T, T>> updateExpression);
        void DeleteBy(int id);
        void Delete(T entity);
        int SaveChanges();
    }
}
