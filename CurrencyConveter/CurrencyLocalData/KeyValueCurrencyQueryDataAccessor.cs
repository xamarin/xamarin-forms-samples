using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CurrencyConverterService;
using CurrencyLocalData.Entities;
using LiteDB;

namespace CurrencyLocalData
{
    public class KeyValueCurrencyQueryDataAccessor : IDataAccessor<KeyValueCurrencyQuery>
    {
        protected LiteCollection<KeyValueCurrencyQuery> _collection;

        public KeyValueCurrencyQueryDataAccessor(string dataStore)
        {
            var mapper = BsonMapper.Global;

            mapper.Entity<KeyValueCurrencyQuery > ()
                .Id(x => x.ID);

            var db = new LiteDatabase(dataStore);
            _collection = db.GetCollection<KeyValueCurrencyQuery>();
        }

        public async Task<int> Count()
        {
            Task<int> task = Task.Run(() => _collection.Count());
            await task;
            return task.Result;
        }

        public async Task Create(KeyValueCurrencyQuery item)
        {
            item.ID = Guid.NewGuid().ToString();
            Task task = Task.Run(() => _collection.Insert(item));
            await task;
        }

        public async Task<bool> PersonalizedDeleteQuery(Expression<Func<KeyValueCurrencyQuery, bool>> predicate)
        {
            Task<bool> task = Task.Run(() => _collection.Delete(predicate) == 1);
            await task;
            return task.Result;
        }

        public async Task<IEnumerable<KeyValueCurrencyQuery>> PersonalizedQuery(Expression<Func<KeyValueCurrencyQuery, bool>> predicate)
        {
            return _collection.Find(predicate);
        }
   
        public async Task<IEnumerable<KeyValueCurrencyQuery>> ReadAll()
        {
            Task<IEnumerable<KeyValueCurrencyQuery>> task = Task.Run(() => _collection.FindAll());
            await task;
            return task.Result;
        }

        public async Task Update(KeyValueCurrencyQuery item)
        {
            _collection.Update(item);
        }
    }
}
