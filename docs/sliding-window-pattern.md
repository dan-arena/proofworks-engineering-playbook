# Sliding Window Pattern

## Overview

Sliding Window is an algorithmic pattern used to efficiently evaluate a moving subset of data without recalculating the entire data set repeatedly.

It is commonly used for:
- string processing
- streaming analytics
- fraud detection
- API rate limiting
- rolling averages
- login/security monitoring
- observability systems

---

# Core Idea

Maintain:
- a left boundary
- a right boundary
- a current valid window

Expand the window when valid.
Shrink the window when invalid.

This allows many problems to be solved in O(n) time instead of O(n²).

---

# Current Example

## Longest Substring Without Repeating Characters

Implementation:
- extension method
- HashSet<char>
- two-pointer technique
- sliding window expansion/contraction

---

# Real-World Business Examples

## Fraud Detection
Detect repeated failed transactions within a rolling time window.

## API Rate Limiting
Restrict requests per user within a rolling time period.

## Security Monitoring
Detect repeated login failures in a rolling window.

## Streaming Analytics
Track rolling engagement metrics or event spikes.

## AI/RAG Processing
Chunk and process overlapping context windows efficiently.

---

# Related Concepts

- HashSet
- Queue
- Two-pointer algorithms
- Rolling aggregation
- Time-series processing