# Hints

- Parse in the constructor, not in each query.
- Dictionary<string, QuestRecord> fits ID lookup.
- Dictionary<string, List<QuestRecord>> fits grouping by region.
- A query after construction should not increase ParseCount.
