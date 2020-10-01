using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoRiaInsaneTrader.Contracts
{
    internal interface IRepositrory<T> where T : IEquatable<T>
    {
        Task<IEnumerable<T>> FindAllAsync();

        Task<IEnumerable<T>> Find(Func<T, bool> predicate);

        Task InsertAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
