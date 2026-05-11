# Sliding Window Pattern

## Overview

Sliding Window is an algorithmic pattern used to efficiently evaluate a moving subset of data without recalculating the entire data set repeatedly.

The window may be:
- index-based, such as characters in a string or values in an array
- time-based, such as events within the last 5 minutes

## Core Idea

Maintain:
- a left boundary
- a right boundary
- the current active window state

Expand the window when new data enters.
Shrink the window when data is no longer valid.

## Examples in This Repository

### Longest Substring Without Repeating Characters

Uses an index-based sliding window over a string.

Fiddle:
`/fiddles/sliding-window/longest-substring-without-repeating-characters.md`

### Time-Based Status Window

Uses a time-based sliding window over timestamped status events.

Fiddle:
`/fiddles/sliding-window/time-based-status-window.md`

## Real-World Business Examples

- fraud detection
- API rate limiting
- login/security monitoring
- observability systems
- rolling service-health analysis
- streaming analytics
- AI/RAG chunking with overlapping context windows

## ArtistOps Usage

ArtistOps uses the time-based sliding window pattern to analyze recent API health signals and determine whether the API should be considered Healthy, Warning, AtRisk, or Failure.

## Key Concepts

- two-pointer technique
- HashSet
- Queue
- rolling window
- timestamp filtering
- rolling aggregation
- stateful analysis

## Complexity

Sliding window solutions often reduce brute-force O(n²) scans to O(n), because each item usually enters and exits the active window once.