using ProofWorks.EngineeringPlaybook.Collections;

namespace ProofWorks.EngineeringPlaybook.Collections.Tests;

public class EnumerableCountingExtensionsTests
{
    [Fact]
    public void CountBy_WhenItemsContainDuplicateKeys_ReturnsCorrectCounts()
    {
        // Arrange
        var events = new List<TestStatusEvent>
        {
            new(TestStatus.Healthy),
            new(TestStatus.Healthy),
            new(TestStatus.Warning),
            new(TestStatus.Unhealthy),
            new(TestStatus.Warning),
            new(TestStatus.Warning)
        };

        // Act
        var result = events.CountByKey(e => e.Status);

        // Assert
        Assert.Equal(2, result[TestStatus.Healthy]);
        Assert.Equal(3, result[TestStatus.Warning]);
        Assert.Equal(1, result[TestStatus.Unhealthy]);
    }

    [Fact]
    public void CountBy_WhenInputIsEmpty_ReturnsEmptyDictionary()
    {
        // Arrange
        var events = new List<TestStatusEvent>();

        // Act
        var result = events.CountBy(e => e.Status);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void CountBy_WhenInputIsNull_ReturnsEmptyDictionary()
    {
        // Arrange
        List<TestStatusEvent>? events = null;

        // Act
        var result = EnumerableCountingExtensions.CountByKey(events, e => e.Status);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void CountBy_WhenSingleKeyExists_ReturnsSingleDictionaryEntry()
    {
        // Arrange
        var events = new List<TestStatusEvent>
        {
            new(TestStatus.Healthy),
            new(TestStatus.Healthy),
            new(TestStatus.Healthy)
        };

        // Act
        var result = events.CountByKey(e => e.Status);

        // Assert
        Assert.Single(result);
        Assert.Equal(3, result[TestStatus.Healthy]);
    }

    private sealed record TestStatusEvent(TestStatus Status);

    private enum TestStatus
    {
        Healthy,
        Warning,
        Unhealthy
    }
}