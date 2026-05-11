# Status Event Count By Key

## Problem

Given a list of status events, count how many times each status appears within a recent time window.

Example:
- Healthy: 12
- Warning: 4
- Failure: 1

## Concepts

- dictionary counting
- grouping
- filtering
- aggregation
- LINQ projection

## Real-World Situation

Operational systems often need to summarize recent events to understand whether behavior is normal or abnormal.

## Real-World Applications

- dashboard summaries
- API health monitoring
- incident trend detection
- login failure summaries
- fraud signal counts
- customer activity summaries
- event-type histograms

## DotNetFiddle

[(https://dotnetfiddle.net/p0T2XL)]

## Related Repository Implementations

- `ProofWorks.EngineeringPlaybook.Collections`
- `ProofWorks.ArtistOps.Api`