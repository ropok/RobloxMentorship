using RobloxMentorship.Models;

namespace RobloxMentorship.Interfaces;

/// <summary>
/// Defines the contract for player data storage.
/// Implementations can be swapped (in-memory, SQL, Redis) without changing business logic.
/// </summary>
public interface IPlayerRepository
{
    Task SaveAsync(Player player);
    Task<Player?> GetByNameAsync(string name);
    Task<List<Player>> GetAllAsync();

}
