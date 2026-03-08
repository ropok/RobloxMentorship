# Lesson 2 — Object-Oriented Programming

## Key Concepts
- **Class** = blueprint, **Object** = real instance
- Properties with `{ get; set; }`
- Constructors for initialising state
- Methods encapsulate behaviour (not floating functions)
- LINQ `.Where()` for filtering collections

## What I Built
- `Player` class with Name, Level, XP, IsOnline, GameMode properties
- Constructor setting default values
- `GetRank()`, `AddExperience()`, `GoOnline()`, `LevelUp()`, `GetSummary()` methods
- Filtered online players using LINQ lambda `p => p.IsOnline`

## Principal Engineer Notes
- **YAGNI** — You Ain't Gonna Need It. Only add properties actively used
- `{ get; set; }` — consider making read-only (`{ get; }`) to protect state
- Always surface data you add — unused properties cause confusion
- `p => p.IsOnline == true` → prefer `p => p.IsOnline`
