using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jusfr.Persistent {
    public static partial class PredicateBuilder {
        public static Paged<TEntry> Page<TEntry>(this IQueryable<TEntry> query, Int32 currentPage = 1, Int32 itemsPerpage = 10) {
            Int32 skip = Math.Max((currentPage - 1) * itemsPerpage, 0);
            return new Paged<TEntry>(
                query.Skip(skip).Take(itemsPerpage).ToArray(),
                currentPage,
                itemsPerpage,
                query.LongCount());
        }
    }

    public class Paged {
        public Int32 CurrentPage { get; set; }
        public Int32 ItemsPerPage { get; set; }
        public Int64 TotalItems { get; set; }
        public Int32 TotalPages { get; set; }

    }

    public class Paged<T> : Paged {
        public IList<T> Items { get; set; }

        public Paged(IList<T> items, Int32 currentPage, Int32 itemsPerPage, Int64 totalItems) {
            Items = items;
            CurrentPage = currentPage;
            ItemsPerPage = itemsPerPage;
            TotalItems = totalItems;
            TotalPages = (Int32)Math.Ceiling((Double)totalItems / itemsPerPage);
        }

        public Paged(IList<T> items, Paged pageBase) {
            Items = items;
            CurrentPage = pageBase.CurrentPage;
            ItemsPerPage = pageBase.ItemsPerPage;
            TotalItems = pageBase.TotalItems;
            TotalPages = pageBase.TotalPages;
        }
    }
}
