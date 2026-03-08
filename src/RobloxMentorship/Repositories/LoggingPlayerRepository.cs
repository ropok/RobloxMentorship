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
    {
        _inner = inner;
    }

    public void Save(Player player)
    {
        Console.WriteLine($"[LOG] Saving player: {player.Name}");
        _inner.Save(player);
    }

    public Player? GetByName(string name)
    {
        Console.WriteLine($"[LOG] Getting player by name: {name}");
        return _inner.GetByName(name);
    }

    public List<Player> GetAll()
    {
        Console.WriteLine("[LOG] Getting all players");
        return _inner.GetAll();
    }
}
