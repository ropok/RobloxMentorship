using RobloxMentorship.Interfaces;
using RobloxMentorship.Repositories;
using RobloxMentorship.Services;

// ============================================================
// Lesson 3 — Interfaces & Dependency Injection
// ============================================================

Console.WriteLine("=== Roblox Mentorship — Lesson 3 ===\n");

// Compose the dependency chain:
// LoggingPlayerRepository wraps InMemoryPlayerRepository (Decorator Pattern)
IPlayerRepository inner     = new InMemoryPlayerRepository();
IPlayerRepository repository = new LoggingPlayerRepository(inner);
var service = new PlayerService(repository);

// Register players
service.RegisterPlayer("Builderman", 42);
service.RegisterPlayer("Kuga", 5);
service.RegisterPlayer("Kraft", 11);

// Award XP — includes a missing player case
Console.WriteLine();
service.AwardExperience("Kuga", 500);
service.AwardExperience("Ghost", 100);

// Level up
service.LevelUpPlayer("Kraft");

// Top players
service.GetTopPlayers(2);

// Full list
service.PrintAllPlayers();
