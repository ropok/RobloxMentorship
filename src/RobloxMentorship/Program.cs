using RobloxMentorship.Interfaces;
using RobloxMentorship.Repositories;
using RobloxMentorship.Services;

// ============================================================
// Lesson 3 — Interfaces & Dependency Injection
// ============================================================
//
// Console.WriteLine("=== Roblox Mentorship — Lesson 3 ===\n");
//
// // Compose the dependency chain:
// // LoggingPlayerRepository wraps InMemoryPlayerRepository (Decorator Pattern)
// IPlayerRepository inner     = new InMemoryPlayerRepository();
// IPlayerRepository repository = new LoggingPlayerRepository(inner);
// var service = new PlayerService(repository);
//
// // Register players
// service.RegisterPlayer("Builderman", 42);
// service.RegisterPlayer("Kuga", 5);
// service.RegisterPlayer("Kraft", 11);
//
// // Award XP — includes a missing player case
// Console.WriteLine();
// service.AwardExperience("Kuga", 500);
// service.AwardExperience("Ghost", 100);
//
// // Level up
// service.LevelUpPlayer("Kraft");
//
// // Top players
// service.GetTopPlayers(2);
//
// // Full list
// service.PrintAllPlayers();

Console.WriteLine("=== Lesson 4: async/await & Exception Handling ===\n");

try
{
    IPlayerRepository inner = new InMemoryPlayerRepository();
    IPlayerRepository repository = new LoggingPlayerRepository(inner);
    var service = new PlayerService(repository);
    // --- Normal flow ---
    // await service.RegisterPlayerAsync("Builderman", 42);
    // await service.RegisterPlayerAsync("Kuga", 5);
    // await service.RegisterPlayerAsync("Kraft", 11);
    //

    // Research Question: Task.WhenAll make sure all the tasks were completed, meanwhile Task.WhenAny() just wait only one task to be completed.
    await Task.WhenAll(
    service.RegisterPlayerAsync("Builderman", 42),
    service.RegisterPlayerAsync("Kuga", 5),
    service.RegisterPlayerAsync("Kraft", 11)
        );

    await service.AwardExperienceAsync("Kuga", 500);
    await service.GetTopPlayersAsync(2);
    await service.PrintAllPlayersAsync();

    // -- Exception Handling ---
    Console.WriteLine("\n=== Testing Exception Handling ===\n");

    // Test 1: invalid name
    try
    {
        await service.RegisterPlayerAsync("", 10);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"[CAUGHT ArgumentException] {ex.Message}");
    }

    // Test 2: invalid level
    try
    {
        await service.RegisterPlayerAsync("Hacker", 999);
    }
    catch (ArgumentOutOfRangeException ex)
    {
        Console.WriteLine($"[CAUGHT ArgumentOutOfRangeException] {ex.Message}");
    }

    // Test 3: negative XP
    try
    {
        await service.AwardExperienceAsync("Builderman", -50);
    }
    catch (ArgumentOutOfRangeException ex)
    {
        Console.WriteLine($"[CAUGHT ArgumentOutOfRangeException] {ex.Message}");
    }



    // Test 4: GetPlayerAsync with missing player
    try
    {
        await service.GetPlayerAsync("Ghost");
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"[CAUGHT InvalidOperationException] {ex.Message}");
    }

    Console.WriteLine("\n App is still running after all exceptions.");
}
catch (Exception ex)
{
    Console.WriteLine($"[FATAL] This should never happen -- investigate immediately.");
    Console.WriteLine($"[FATAL] {ex.GetType().Name}: {ex.Message} ");
    Console.WriteLine($"[FATAL] Stack trace: {ex.StackTrace}");
    throw;
}


