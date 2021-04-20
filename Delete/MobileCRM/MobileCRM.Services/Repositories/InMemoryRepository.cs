using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using MobileCRM.Services;
using MobileCRM.Models;
using System.Collections;

namespace MobileCRM.Services
{
    public class InMemoryRepository<T> : IRepository<T> where T: class, IContact, new()
    {
        static readonly protected IList<T> GlobalItems = new List<T>();

        public InMemoryRepository()
        {
            Items = new List<T>(GlobalItems);
        }

        protected IList<T> Items { get; set; }

        #region IRepository implementation

        public Task<IEnumerable<T>> All ()
        {
			return Task.FromResult<IEnumerable<T>> (Items);
        }

        public Task<IEnumerable<T>> FindAsync (Func<T, bool> predicate)
        {
			return Task.FromResult<IEnumerable<T>> (Items.Where (predicate));
        }

        public Task<T> Get (Func<T, bool> predicate)
        {
			return Task.FromResult<T> (Items.SingleOrDefault (predicate));
        }

        public Task<T> Update (T item)
        {
			return Task.Factory.StartNew (() => {
				var index = Items.IndexOf(item);
				if (index < 0)
					throw new InvalidOperationException("Cannot update an item not already in the collection");
				Items[index] = item;

				return item;
			});
        }

        public Task<T> Upsert (T item)
        {
			return Task.Factory.StartNew (() => {
				var index = Items.IndexOf(item);
				if (index < 0)
					Add(item);
				else
					Items[index] = item;

				return item;
			});
        }

        public Task Delete (T item)
        {
			return Task.Factory.StartNew (() => {
				Items.Remove(item);
			});
        }

        public Task<T> Add (T item)
        {
			return Task.Factory.StartNew (() => {
				Items.Add(item);
				return item;
			});
        }

        public Task<List<T>> AddRange(List<T> range)
        {
            return Task.Factory.StartNew(() => {
                foreach (var item in range)
                {
                    Items.Add(item);
                }
                return range;
            });
        }

        #endregion

        #region IDisposable implementation

        public void Dispose ()
        {

        }

        #endregion

    }
}