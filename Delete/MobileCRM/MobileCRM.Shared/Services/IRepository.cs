using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MobileCRM.Services
{
    /// <summary>
    /// Generic repository interface.
    /// </summary>
    /// <remarks>
    /// Provides the service interface for concreate storage services.
    /// </remarks>
    public interface IRepository<T> : IDisposable where T: class, new()
    {
        /// <summary>
        /// Retrieves all <typeparamref>T</typeparamref>s.
        /// </summary>
        Task<IEnumerable<T>> All();

        /// <summary>
        /// Retrieves the <typeparamref>T</typeparamref> matching the <paramref name="criteria"/>.
        /// </summary>
        /// <returns>The async task.</returns>
        /// <param name="criteria">Criteria.</param>
        /// <typeparam name="T">The type of item.</typeparam>
        Task<IEnumerable<T>> FindAsync(Func<T,bool> predicatepredicate);

        /// <summary>
        /// Retrieves the <typeparamref>T</typeparamref> matching the specified identifier.
        /// </summary>
        /// <param name="identifier">Expression denoting the identifier.</param>
        /// <typeparam name="T">The type of item.</typeparam>
        Task<T> Get(Func<T, bool> identifier);

        /// <summary>
        /// Updates an existing <typeparamref>T</typeparamref> record.
        /// </summary>
        /// <param name="item">Item.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        Task<T> Update(T item);

        /// <summary>
        /// Delete the specified item.
        /// </summary>
        /// <param name="item">Item.</param>
        /// <typeparam name="T">The type of item.</typeparam>
        Task Delete(T item);

        /// <summary>
        /// Add the specified item.
        /// </summary>
        /// <param name="item">Item.</param>
        /// <typeparam name="T">The type of item.</typeparam>
        Task<T> Add(T item);
    }
}

