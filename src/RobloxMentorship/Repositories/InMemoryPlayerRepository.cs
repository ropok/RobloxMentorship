using RobloxMentorship.Interfaces;
using RobloxMentorship.Models;

namespace RobloxMentorship.Repositories;

/// <summary>
/// In-memory implementation of IPlayerRepository.
/// Ideal for development, testing, and learning.
/// Replace with SqlPlayerRepository for production use.
/// </summary>
public class InMemoryPlayerRepository : IPlayerRepository
{
    private readonly List<Player> _players = new();

    public Task SaveAsync(Player player)
    {
        var existing = _players.FirstOrDefault(p => p.Name == player.Name);
        if (existing != null) _players.Remove(existing);
        _players.Add(player);
        Console.WriteLine($"[InMemory] Saved player: {player.Name}");
        return Task.CompletedTask;
    }

    public Task<Player?> GetByNameAsync(string name)
    {
        var player = _players.FirstOrDefault(p => p.Name == name);
        return Task.FromResult(player);
    }

    public Task<List<Player>> GetAllAsync()
      => Task.FromResult(_players);
}

