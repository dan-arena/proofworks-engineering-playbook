# Time-Based Status Window (Sliding Window)

## Problem

Analyze timestamped service-health events and determine whether a service is experiencing instability within a rolling time window.

Example:
- 3 degraded or failed events within 5 minutes
- warning percentage exceeding operational thresholds
- recent event patterns indicating elevated outage risk

## Concepts

- sliding window
- time-series analysis
- rolling operational analysis
- timestamp filtering
- two-pointer technique
- rolling aggregation

## Real-World Situation

Efficiently analyze recent operational history without rescanning the full event history repeatedly.

## Real-World Applications

- API monitoring
- operational dashboards
- observability systems
- fraud detection
- login failure analysis
- traffic spike detection
- service degradation monitoring

## ArtistOps Usage

ArtistOps uses this pattern to:
- track recent API health signals
- determine operational status
- detect elevated outage risk
- drive dashboard color/status transitions

## DotNetFiddle

[(https://dotnetfiddle.net/1uNq4v)]

## Related Repository Implementations

- `ProofWorks.EngineeringPlaybook.TimeSeries`
- `ProofWorks.ArtistOps.Api`