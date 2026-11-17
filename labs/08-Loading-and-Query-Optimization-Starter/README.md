# Lab 8 — Loading and Query Optimization

## One idea
If expensive work repeats, ask whether you can perform some work once during preparation and reuse the result.

The starter keeps raw quest lines. `PreparedQuestStore` is intentionally incomplete: its query methods still parse/scan raw data repeatedly.

## Run
```bash
dotnet restore DSA.Lab08.sln
dotnet test DSA.Lab08.sln
dotnet run --project src/DSA.Lab08.App
```

## Tasks
1. Establish starter correctness/test state.
2. Inspect `QuestParser.ParseCount` and the app measurements.
3. Change `PreparedQuestStore` so input is parsed once during construction.
4. Build an ID index suitable for repeated `FindById`.
5. Build a region index suitable for repeated `GetByRegion`.
6. Re-run tests and the same workload.
7. Explain the trade-off: more preparation/storage, cheaper repeated queries.

## Optional cache thought experiment
If a region summary were expensive and the quest data never changed after loading, when would caching that summary be safe? What changes if quests can be added/removed at runtime?

## Assignment bridge
This is concept practice. Do not rewrite Frontier Dispatch around these quest classes. Apply the reasoning only where your own measurements justify it.
