# 🎮 C# .NET Core Engineering Mentorship

> A structured learning journey from Junior Developer to Principal Engineer,  
> aligned with the **Roblox Engineering Efficiency** career path.

---

## 👨‍💻 About This Repository

This repo documents my hands-on progression through C# and .NET Core — covering fundamentals, OOP, clean architecture, CI/CD pipelines, and production engineering practices.

Each lesson includes working code, personal notes, and code review feedback from a Principal Engineer mentor perspective.

**Goal:** Land a Senior Software Engineer role at a company like Roblox, building high-performance backend systems and CI/CD infrastructure at scale.

---

## 🗺️ Roadmap

| Phase | Focus | Status |
|-------|-------|--------|
| **Phase 1** | C# Language Fundamentals | 🟡 In Progress |
| **Phase 2** | .NET Core & REST APIs | ⬜ Up Next |
| **Phase 3** | Code Quality & Engineering Practices | ⬜ Planned |
| **Phase 4** | CI/CD & Production Readiness | ⬜ Planned |

---

## 📚 Lessons

### ✅ Phase 1 — C# Fundamentals

| Lesson | Topic | Notes |
|--------|-------|-------|
| [Lesson 1](docs/lessons/Lesson1.md) | Variables, Types, Methods & Control Flow | Strongly typed, DRY principle, collections |
| [Lesson 2](docs/lessons/Lesson2.md) | Object-Oriented Programming | Classes, constructors, properties, LINQ |
| [Lesson 3](docs/lessons/Lesson3.md) | Interfaces & Dependency Injection | Contracts, Decorator Pattern, SOLID |
| Lesson 4 | async/await & Exception Handling | *(coming soon)* |

### ⬜ Phase 2 — .NET Core & APIs
- Lesson 5: How .NET Works & Project Structure
- Lesson 6: REST APIs with ASP.NET Core
- Lesson 7: DI Container in ASP.NET Core
- Lesson 8: Entity Framework Core & Databases
- Lesson 9: Configuration Management

### ⬜ Phase 3 — Code Quality
- Lesson 10: Clean Code & SOLID Principles
- Lesson 11: Unit Testing with xUnit
- Lesson 12: Design Patterns
- Lesson 13: Code Review Mindset

### ⬜ Phase 4 — CI/CD & Production
- Lesson 14: Git Branching Strategy
- Lesson 15: GitHub Actions CI/CD Pipelines
- Lesson 16: Docker & Containerisation
- Lesson 17: Kubernetes Basics
- Lesson 18: Logging, Monitoring & Observability

---

## 🏗️ Project Structure

```
RobloxMentorship/
├── src/
│   └── RobloxMentorship/
│       ├── Models/                  # Domain models (Player, etc.)
│       ├── Interfaces/              # Contracts (IPlayerRepository, etc.)
│       ├── Repositories/            # Data access implementations
│       ├── Services/                # Business logic layer
│       └── Program.cs               # Entry point
├── tests/
│   └── RobloxMentorship.Tests/      # Unit tests (Phase 3)
├── docs/
│   └── lessons/                     # Lesson notes and reflections
├── .gitignore
└── README.md
```

---

## 🧠 Key Concepts Learned So Far

**Dependency Injection**
```csharp
// PlayerService depends on the CONTRACT, not the implementation
public class PlayerService
{
    private readonly IPlayerRepository _repository;

    public PlayerService(IPlayerRepository repository)
        => _repository = repository;
}
```

**Decorator Pattern**
```csharp
// Wrap any repository to add logging — zero changes to existing code
IPlayerRepository inner    = new InMemoryPlayerRepository();
IPlayerRepository logging  = new LoggingPlayerRepository(inner);
var service = new PlayerService(logging);
```

**LINQ**
```csharp
// Filter, sort, and slice collections cleanly
var topPlayers = players
    .OrderByDescending(p => p.Level)
    .Take(3);
```

---

## 🛠️ Tech Stack

| Technology | Purpose |
|------------|---------|
| C# 12 | Primary language |
| .NET 8 | Runtime & framework |
| ASP.NET Core | REST APIs *(Phase 2)* |
| Entity Framework Core | Database ORM *(Phase 2)* |
| xUnit | Unit testing *(Phase 3)* |
| GitHub Actions | CI/CD pipeline *(Phase 4)* |
| Docker | Containerisation *(Phase 4)* |
| Kubernetes | Orchestration *(Phase 4)* |

---

## 🚀 Getting Started

**Prerequisites**
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

**Run the project**
```bash
git clone https://github.com/YOUR_USERNAME/RobloxMentorship.git
cd RobloxMentorship/src/RobloxMentorship
dotnet run
```

**Run tests** *(available from Phase 3)*
```bash
cd tests/RobloxMentorship.Tests
dotnet test
```

---

## 📈 Career Target

This repository is part of a structured plan to reach a **Senior Software Engineer** role at a top-tier tech company.

```
Now          →  Junior .NET Developer      (Land first professional role)
Year 1–2     →  Mid-level Backend/DevOps   (Own a CI/CD pipeline)
Year 2.5–4   →  Senior Engineer            (Scaling company, AI tooling)
Year 4–5     →  Apply to Roblox            ($196K–$243K + equity)
```

Target role: [Senior Software Engineer, Engineering Efficiency — Roblox](https://careers.roblox.com/jobs/7604512)

---

## 📝 Progress Log

| Date | Milestone |
|------|-----------|
| 2026-03-08 | Started mentorship — Lesson 1 complete |
| 2026-03-08 | Lesson 2 complete — OOP, LINQ bonus challenge |
| 2026-03-08 | Lesson 3 complete — Interfaces, DI, Decorator Pattern |
| 2026-03-08 | GitHub repo structured with clean architecture |

---

## 🙏 Acknowledgements

Mentored under a Principal Engineer specialising in .NET Core, C#, and CI/CD production pipelines — with experience aligned to the Roblox Engineering Efficiency stack.

---

*"Build for the person who maintains it at 2am during an incident."*
