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
      => _repository = repository;


    public async Task RegisterPlayerAsync(string name, int level)
    {
        // Validate input - throw specific exceptions for bad data
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Player name cannot be empty.", nameof(name));

        if (level < 1 || level > 100)
            throw new ArgumentOutOfRangeException(nameof(level), "Level must between 1 and 100.");

        var player = new Player(name, level);
        player.GoOnline();
        await _repository.SaveAsync(player);
    }

    public async Task AwardExperienceAsync(string playerName, double xp)
    {
        if (xp <= 0)
            throw new ArgumentOutOfRangeException(nameof(xp), "XP must be greater than zero.");
        var player = await _repository.GetByNameAsync(playerName);
        if (player == null)
        {
            Console.WriteLine($"Player '{playerName}' not found.");
            return;
        }
        player.AddExperience(xp);
        await _repository.SaveAsync(player);
    }

    public async Task LevelUpPlayerAsync(string playerName)
    {
        var player = await _repository.GetByNameAsync(playerName);
        if (player == null)
        {
            Console.WriteLine($"Player '{playerName}' not found.");
            return;
        }
        player.LevelUp();
        await _repository.SaveAsync(player); // always persist after mutation
    }

    public async Task PrintAllPlayersAsync()
    {
        var players = await _repository.GetAllAsync();
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
    public async Task GetTopPlayersAsync(int count)
    {
        var players = await _repository.GetAllAsync();
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

    public async Task<Player?> GetPlayerAsync(string name)
    {
        var player = await _repository.GetByNameAsync(name);
        if (player == null)
        {
            throw new InvalidOperationException("Player is not found!");
        }
        return await Task.FromResult(player);
    }
}
