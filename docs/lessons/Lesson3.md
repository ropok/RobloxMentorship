# Lesson 3 — Interfaces & Dependency Injection

## Key Concepts
- **Interface** = contract (what, not how)
- **Dependency Injection** = give a class its dependencies from outside
- **Decorator Pattern** = wrap a class to add behaviour without modifying it
- **Nullable types** (`Player?`) = a method might return null — handle it

## What I Built
- `IPlayerRepository` interface with `Save`, `GetByName`, `GetAll`
- `InMemoryPlayerRepository` — concrete implementation using a List
- `LoggingPlayerRepository` — Decorator wrapping any `IPlayerRepository`
- `PlayerService` — business logic depending on the interface, not the implementation

## Design Decision
`GetTopPlayers` lives in `PlayerService`, not `IPlayerRepository`, because:
1. Sorting and ranking is **business logic**, not data access
2. All repository implementations would be forced to implement it (Interface Segregation)
3. The definition of "top" can change without touching the data layer

## Principal Engineer Notes
- `private readonly` — always default for injected dependencies
- `Player?` — nullable. When something might not exist, return null, don't throw
- Always call `_repository.Save()` after mutating an object — don't rely on reference side effects
- Swap one line in `Program.cs` to change the entire storage implementation
