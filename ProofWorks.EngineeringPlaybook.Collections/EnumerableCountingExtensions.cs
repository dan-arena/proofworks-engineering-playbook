using System;
using System.Collections.Generic;

namespace ProofWorks.EngineeringPlaybook.Collections;

public static class EnumerableCountingExtensions
{
    public static Dictionary<TKey, int> CountByKey<T, TKey>(
        this IEnumerable<T>? items,
        Func<T, TKey> keySelector)
        where TKey : notnull
    {
        if (keySelector == null)
        {
            throw new ArgumentNullException(nameof(keySelector));
        }

        var results = new Dictionary<TKey, int>();

        if (items == null)
        {
            return results;
        }

        foreach (var item in items)
        {
            var key = keySelector(item);

            if (results.ContainsKey(key))
            {
                results[key]++;
            }
            else
            {
                results[key] = 1;
            }
        }

        return results;
    }
}