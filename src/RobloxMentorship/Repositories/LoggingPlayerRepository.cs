using RobloxMentorship.Interfaces;
using RobloxMentorship.Models;

namespace RobloxMentorship.Repositories;

/// <summary>
/// Decorator that wraps any IPlayerRepository implementation and adds logging.
/// Follows the Decorator Pattern — adds behaviour without modifying the original class.
/// 
/// Usage:
///   IPlayerRepository inner   = new InMemoryPlayerRepository();
///   IPlayerRepository logging = new LoggingPlayerRepository(inner);
/// </summary>
public class LoggingPlayerRepository : IPlayerRepository
{
    private readonly IPlayerRepository _inner;

    public LoggingPlayerRepository(IPlayerRepository inner)
    => _inner = inner;


    public async Task SaveAsync(Player player)
    {
        Console.WriteLine($"[LOG] Saving player: {player.Name}");
        await _inner.SaveAsync(player);
    }

    public async Task<Player?> GetByNameAsync(string name)
    {
        Console.WriteLine($"[LOG] Getting player by name: {name}");
        return await _inner.GetByNameAsync(name);
    }

    public async Task<List<Player>> GetAllAsync()
    {
        Console.WriteLine("[LOG] Getting all players");
        return await _inner.GetAllAsync();
    }
}
