using RobloxMentorship.Models;

namespace RobloxMentorship.Interfaces;

/// <summary>
/// Defines the contract for player data storage.
/// Implementations can be swapped (in-memory, SQL, Redis) without changing business logic.
/// </summary>
public interface IPlayerRepository
{
    void         Save(Player player);
    Player?      GetByName(string name);
    List<Player> GetAll();
}
