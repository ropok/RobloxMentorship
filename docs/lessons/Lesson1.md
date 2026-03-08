# Lesson 1 — Variables, Types, Methods & Control Flow

## Key Concepts
- C# is strongly typed — every variable must declare its type
- Control flow with `if / else`
- Collections with `List<T>`
- Reusable logic with methods (DRY principle)

## What I Built
- Declared string, int, double, bool variables
- Wrote `GetPlayerRank()` returning Bronze / Silver / Gold
- Used `List<string>` and `foreach` to print players
- Extracted `CalculateTotalXP()` as a reusable method

## Principal Engineer Notes
- Never compare a bool to `true`: write `if (isOnline)` not `if (isOnline == true)`
- Use `var` when the type is obvious from context
- Methods do one thing only — if it needs a long comment, split it
- Typos in strings are invisible to the compiler — treat them like code
