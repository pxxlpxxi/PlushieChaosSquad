using System;
using System.Collections.Generic;
using System.Text;

namespace PlushieChaosSquad.Helpers
{
    /// <summary>
    /// Provides generic helper methods for searching collections
    /// </summary>
    internal static class SearchHelper
    {
        /// <summary>
        /// Finds the first item in a collection that satisfies the specified condition.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="items">The collection to search.</param>
        /// <param name="condition">The condition an item must satisfy.</param>
        /// <returns></returns>
        internal static T FindFirst<T>(IEnumerable<T> items, Func<T, bool> condition)
        {
            foreach (T item in items)
            {
                if (condition(item)) return item;
            }
            return default!;
        }
    }
}
