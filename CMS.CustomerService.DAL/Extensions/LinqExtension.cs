using System;
using System.Collections.Generic;

namespace DUC.CMS.CustomerService.DAL
{
    public static class LinqExtension
    {
        /// <summary>
        /// Converts to list.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">source</exception>
        public static List<TSource> ToList<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException("source");
            return new List<TSource>(source);
        }
    }
}
