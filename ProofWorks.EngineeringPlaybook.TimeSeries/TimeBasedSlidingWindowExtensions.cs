using System;
using System.Collections.Generic;
using System.Linq;

namespace ProofWorks.EngineeringPlaybook.TimeSeries;

public static class TimeBasedSlidingWindowExtensions
{
    /// <summary>
    /// Determines whether the provided sequence contains at least the specified number of matching
    /// items inside any rolling time window of the requested size.
    ///
    /// This is useful for detecting historical clusters, such as:
    /// - 3 failed login attempts within any 5-minute window
    /// - 5 payment failures within any 10-minute window
    /// - repeated unhealthy service events clustered together
    /// </summary>
    public static bool HasThresholdWithinAnyWindow<T>(
        this IEnumerable<T>? items,
        Func<T, DateTimeOffset> timestampSelector,
        Func<T, bool> matchSelector,
        TimeSpan windowSize,
        int threshold)
    {
        ValidateInputs(timestampSelector, matchSelector, windowSize, threshold);

        if (items == null)
            return false;

        var orderedItems = items
            .OrderBy(timestampSelector)
            .ToList();

        int left = 0;
        int matchCount = 0;

        for (int right = 0; right < orderedItems.Count; right++)
        {
            if (matchSelector(orderedItems[right]))
            {
                matchCount++;
            }

            while (timestampSelector(orderedItems[right]) - timestampSelector(orderedItems[left]) > windowSize)
            {
                if (matchSelector(orderedItems[left]))
                {
                    matchCount--;
                }

                left++;
            }

            if (matchCount >= threshold)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Determines whether the provided sequence contains at least the specified number of matching
    /// items inside a trailing time window ending at the provided windowEnd.
    ///
    /// This is useful for current operational checks, such as:
    /// - whether a service has had 3 warning/unhealthy events in the last 5 minutes
    /// - whether an API has exceeded an error threshold recently
    /// - whether a dashboard should currently show instability
    /// </summary>
    public static bool HasThresholdWithinTrailingWindow<T>(
        this IEnumerable<T>? items,
        Func<T, DateTimeOffset> timestampSelector,
        Func<T, bool> matchSelector,
        TimeSpan windowSize,
        int threshold,
        DateTimeOffset windowEnd)
    {
        ValidateInputs(timestampSelector, matchSelector, windowSize, threshold);

        if (items == null)
            return false;

        var windowStart = windowEnd - windowSize;

        var matchCount = items.Count(item =>
        {
            var timestamp = timestampSelector(item);

            return timestamp >= windowStart
                && timestamp <= windowEnd
                && matchSelector(item);
        });

        return matchCount >= threshold;
    }

    private static void ValidateInputs<T>(
        Func<T, DateTimeOffset> timestampSelector,
        Func<T, bool> matchSelector,
        TimeSpan windowSize,
        int threshold)
    {
        if (timestampSelector == null)
            throw new ArgumentNullException(nameof(timestampSelector));

        if (matchSelector == null)
            throw new ArgumentNullException(nameof(matchSelector));

        if (windowSize <= TimeSpan.Zero)
            throw new ArgumentOutOfRangeException(nameof(windowSize));

        if (threshold <= 0)
            throw new ArgumentOutOfRangeException(nameof(threshold));
    }
}