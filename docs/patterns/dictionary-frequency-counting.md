# Dictionary / Frequency Counting Pattern

## Overview

Dictionary-based frequency counting is a pattern used to count how often values appear in a collection.

It is commonly used when a problem asks for:
- occurrences
- duplicates
- frequency
- most common values
- grouped totals
- summary counts

## Core Idea

Maintain a dictionary where:
- the key represents the value being counted
- the value represents how many times that key has appeared

Each item is processed once.

## Examples in This Repository

### Count By Key

Uses a generic extension method to count items by a selected key.

Fiddle:
`/fiddles/collections/status-event-count-by-key.md`

## Real-World Business Examples

- counting API statuses
- summarizing event types
- detecting duplicate records
- counting failed login attempts
- building operational dashboards
- summarizing sales by category
- tracking incident frequency
- counting customer actions by type

## ArtistOps Usage

ArtistOps uses this pattern to summarize recent API health signals and support operational status interpretation.

## Key Concepts

- Dictionary<TKey, int>
- grouping
- aggregation
- frequency analysis
- histogram construction
- lookup efficiency

## Complexity

Dictionary counting is usually O(n), because each item is processed once and dictionary lookup is generally O(1).