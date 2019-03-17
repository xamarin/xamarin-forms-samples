using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyLocalData
{
    public interface IDataAccessor<T>
    {
        Task<bool> PersonalizedDeleteQuery(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> PersonalizedQuery(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> ReadAll();
        Task Update(T item);
        Task Create(T item);
        Task<int> Count();
    }
}
