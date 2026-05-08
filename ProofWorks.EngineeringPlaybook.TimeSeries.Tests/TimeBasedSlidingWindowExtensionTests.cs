using ProofWorks.EngineeringPlaybook.TimeSeries;

namespace ProofWorks.EngineeringPlaybook.TimeSeries.Tests;

public class TimeBasedSlidingWindowExtensionsTests
{
    [Fact]
    public void HasThresholdWithinAnyWindow_WhenHistoricalClusterMeetsThreshold_ReturnsTrue()
    {
        // Arrange
        var now = DateTimeOffset.UtcNow;

        var events = new List<TestStatusEvent>
        {
            new(ServiceStatus.Healthy, now.AddMinutes(-20)),
            new(ServiceStatus.Warning, now.AddMinutes(-10)),
            new(ServiceStatus.Unhealthy, now.AddMinutes(-9)),
            new(ServiceStatus.Warning, now.AddMinutes(-8)),
            new(ServiceStatus.Healthy, now)
        };

        // Act
        var result = events.HasThresholdWithinAnyWindow(
            e => e.Timestamp,
            IsBadStatus,
            TimeSpan.FromMinutes(5),
            3);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void HasThresholdWithinAnyWindow_WhenBadEventsAreSpreadApart_ReturnsFalse()
    {
        // Arrange
        var now = DateTimeOffset.UtcNow;

        var events = new List<TestStatusEvent>
        {
            new(ServiceStatus.Warning, now.AddMinutes(-20)),
            new(ServiceStatus.Unhealthy, now.AddMinutes(-10)),
            new(ServiceStatus.Warning, now),
        };

        // Act
        var result = events.HasThresholdWithinAnyWindow(
            e => e.Timestamp,
            IsBadStatus,
            TimeSpan.FromMinutes(5),
            3);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void HasThresholdWithinTrailingWindow_WhenCurrentWindowMeetsThreshold_ReturnsTrue()
    {
        // Arrange
        var now = DateTimeOffset.UtcNow;

        var events = new List<TestStatusEvent>
        {
            new(ServiceStatus.Healthy, now.AddMinutes(-10)),
            new(ServiceStatus.Warning, now.AddMinutes(-4)),
            new(ServiceStatus.Unhealthy, now.AddMinutes(-3)),
            new(ServiceStatus.Warning, now.AddMinutes(-2)),
            new(ServiceStatus.Healthy, now)
        };

        // Act
        var result = events.HasThresholdWithinTrailingWindow(
            e => e.Timestamp,
            IsBadStatus,
            TimeSpan.FromMinutes(5),
            3,
            now);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void HasThresholdWithinTrailingWindow_WhenBadEventsAreOutsideCurrentWindow_ReturnsFalse()
    {
        // Arrange
        var now = DateTimeOffset.UtcNow;

        var events = new List<TestStatusEvent>
        {
            new(ServiceStatus.Warning, now.AddMinutes(-10)),
            new(ServiceStatus.Unhealthy, now.AddMinutes(-9)),
            new(ServiceStatus.Warning, now.AddMinutes(-8)),
            new(ServiceStatus.Healthy, now)
        };

        // Act
        var result = events.HasThresholdWithinTrailingWindow(
            e => e.Timestamp,
            IsBadStatus,
            TimeSpan.FromMinutes(5),
            3,
            now);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void HasThresholdWithinTrailingWindow_WhenInputIsEmpty_ReturnsFalse()
    {
        // Arrange
        var events = new List<TestStatusEvent>();
        var now = DateTimeOffset.UtcNow;

        // Act
        var result = events.HasThresholdWithinTrailingWindow(
            e => e.Timestamp,
            IsBadStatus,
            TimeSpan.FromMinutes(5),
            3,
            now);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void HasThresholdWithinTrailingWindow_WhenInputIsNull_ReturnsFalse()
    {
        // Arrange
        List<TestStatusEvent>? events = null;
        var now = DateTimeOffset.UtcNow;

        // Act
        var result = events.HasThresholdWithinTrailingWindow(
            e => e.Timestamp,
            IsBadStatus,
            TimeSpan.FromMinutes(5),
            3,
            now);

        // Assert
        Assert.False(result);
    }

    private static bool IsBadStatus(TestStatusEvent statusEvent)
    {
        return statusEvent.Status is ServiceStatus.Warning or ServiceStatus.Unhealthy;
    }

    private sealed record TestStatusEvent(ServiceStatus Status, DateTimeOffset Timestamp);

    private enum ServiceStatus
    {
        Healthy,
        Warning,
        Unhealthy
    }
}