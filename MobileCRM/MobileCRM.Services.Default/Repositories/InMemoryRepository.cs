using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using MobileCRM.Services;
using MobileCRM.Models;

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

        public async Task<IEnumerable<T>> All ()
        {
            return Items;
        }

        public async Task<IEnumerable<T>> FindAsync (Func<T, bool> predicate)
        {
            return Items.Where(predicate);
        }

        public async Task<T> Get (Func<T, bool> predicate)
        {
            return Items.SingleOrDefault(predicate);
        }

        public async Task<T> Update (T item)
        {
            var index = Items.IndexOf(item);
            if (index < 0)
                throw new InvalidOperationException("Cannot update an item not already in the collection");
            Items[index] = item;
            return item;
        }

        public async Task<T> Upsert (T item)
        {
            var index = Items.IndexOf(item);
            if (index < 0)
                Add(item);
            else
                Items[index] = item;
            return item;
        }

        public async Task Delete (T item)
        {
            Items.Remove(item);
        }

        public async Task<T> Add (T item)
        {
            Items.Add(item);
            return item;
        }

        #endregion

        #region IDisposable implementation

        public void Dispose ()
        {

        }

        #endregion


    }
}

