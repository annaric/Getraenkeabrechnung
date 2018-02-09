using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Modell
{
    public static class Erweiterungen
    {
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer = null)
        {
            return new HashSet<T>(source, comparer);
        }

        public static DbContextTransaction BeginOrReuseTransaction(this Database database)
        {
            if (database.CurrentTransaction != null)
                return null;
            else
                return database.BeginTransaction();
        }
    }
}
