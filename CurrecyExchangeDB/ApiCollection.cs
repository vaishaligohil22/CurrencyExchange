using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrecyExchangeDB
{
    public class Collection<T> : IEnumerable<T>
    {
        public Collection()
        {
            Items = new List<T>();
        }

        public Collection(List<T> list, long totalHits)
        {
            Items = list ?? new List<T>();
            TotalHits = totalHits;
        }

        public List<T> Items { get; set; }

        public long TotalHits { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public static class CollectionExtensions
    {
        public static async Task<Collection<T>> ResultAsync<T>(this IQueryable<T> query)
        {
            return new Collection<T>(await query.ToListAsync(), await query.LongCountAsync());
        }
    }
}
