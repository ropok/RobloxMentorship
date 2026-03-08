using RobloxMentorship.Interfaces;
using RobloxMentorship.Models;

namespace RobloxMentorship.Services;

/// <summary>
/// Business logic layer for player operations.
/// Depends on IPlayerRepository — not on any specific implementation.
/// </summary>
public class PlayerService
{
    private readonly IPlayerRepository _repository;

    public PlayerService(IPlayerRepository repository)
    {
        _repository = repository;
    }

    public void RegisterPlayer(string name, int level)
    {
        var player = new Player(name, level);
        player.GoOnline();
        _repository.Save(player);
    }

    public void AwardExperience(string playerName, double xp)
    {
        var player = _repository.GetByName(playerName);
        if (player == null)
        {
            Console.WriteLine($"Player '{playerName}' not found.");
            return;
        }
        player.AddExperience(xp);
        _repository.Save(player);
    }

    public void LevelUpPlayer(string playerName)
    {
        var player = _repository.GetByName(playerName);
        if (player == null)
        {
            Console.WriteLine($"Player '{playerName}' not found.");
            return;
        }
        player.LevelUp();
        _repository.Save(player); // always persist after mutation
    }

    public void PrintAllPlayers()
    {
        var players = _repository.GetAll();
        if (!players.Any())
        {
            Console.WriteLine("No players registered.");
            return;
        }
        Console.WriteLine("\n=== Registered Players ===");
        foreach (var player in players)
            Console.WriteLine(player.GetSummary());
    }

    /// <summary>
    /// Returns top N players sorted by Level descending.
    /// Sorting is business logic — it lives in the service, not the repository.
    /// </summary>
    public void GetTopPlayers(int count)
    {
        var players = _repository.GetAll();
        if (!players.Any())
        {
            Console.WriteLine("No players registered.");
            return;
        }
        var top = players.OrderByDescending(p => p.Level).Take(count);
        Console.WriteLine($"\n=== Top {count} Players ===");
        foreach (var player in top)
            Console.WriteLine(player.GetSummary());
    }
}
