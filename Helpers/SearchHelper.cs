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

        /// <summary>
        /// Finds the item with the highest score according to the specified scoring function.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="items">The collection to search.</param>
        /// <param name="score">A function that calculates the score for each item.</param>
        /// <returns>
        /// The item with the highest score, or <c>default</c> if the collection is empty.
        /// </returns>
        internal static T FindBest<T>(
            IEnumerable<T> items,
            Func<T, int> score)
        {
            T? bestItem = default;
            int bestScore = int.MinValue;
            foreach (T item in items) { 
                int currentScore = score(item);
                if (currentScore > bestScore)
                {
                    bestScore= currentScore;
                    bestItem = item;
                }
            }
            return bestItem!;
        }
    }
}
