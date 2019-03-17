using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CurrencyConverterService;
using CurrencyLocalData.Entities;
using LiteDB;

namespace CurrencyLocalData
{
    public class GlobalCurrenciesDataAccessor : IDataAccessor<GlobalCurrencies>
    {
        protected LiteCollection<GlobalCurrencies> _collection;

        public GlobalCurrenciesDataAccessor(string dataStore)
        {
            var mapper = BsonMapper.Global;

            mapper.Entity<GlobalCurrencies>()
                .Id(x => x.ID);

            var db = new LiteDatabase(dataStore);
            _collection = db.GetCollection<GlobalCurrencies>();
        }

        public async Task<int> Count()
        {
            Task<int> task = Task.Run(() => _collection.Count());
            await task;
            return task.Result;
        }

        public async Task Create(GlobalCurrencies item)
        {
            Task task = Task.Run(() =>
            {
                item.ID = Guid.NewGuid().ToString();
                _collection.Insert(item);
            });
            await task;
        }

        public async Task<bool> PersonalizedDeleteQuery(Expression<Func<GlobalCurrencies, bool>> predicate)
        {
            return _collection.Delete(predicate) == 1;
        }

        public async Task<IEnumerable<GlobalCurrencies>> PersonalizedQuery(Expression<Func<GlobalCurrencies, bool>> predicate)
        {
            return _collection.Find(predicate);
        }

        public async Task<IEnumerable<GlobalCurrencies>> ReadAll()
        {
            Task<IEnumerable<GlobalCurrencies>> task = Task.Run(() => _collection.FindAll());
            await task;
            return task.Result;
        }

        public async Task Update(GlobalCurrencies item)
        {
            Task task = Task.Run(() => _collection.Update(item));
            await task;
        }
    }
}
