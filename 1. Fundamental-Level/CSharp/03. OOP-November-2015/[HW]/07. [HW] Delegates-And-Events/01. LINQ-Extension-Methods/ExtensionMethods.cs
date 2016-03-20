using System;
using System.Collections.Generic;

public static class ExtensionMethods
{
    public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        ICollection<T> filteredElements = new List<T>();
        foreach (var element in collection)
        {
            if (!predicate(element))
            {
                filteredElements.Add(element);
            }
        }

        return filteredElements;
    }

    public static TSelector Max<TSource, TSelector>(this IEnumerable<TSource> collection, Func<TSource, TSelector> condition)
        where TSelector : IComparable
    {
        var max = default(TSelector);

        foreach (var element in collection)
        {
            var filteredElement = condition(element);
            if (filteredElement.CompareTo(max) > 0)
            {
                max = filteredElement;
            }
        }

        return max;
    }
}