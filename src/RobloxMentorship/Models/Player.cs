namespace RobloxMentorship.Models;

/// <summary>
/// Represents a game player with level, experience, and rank progression.
/// </summary>
public class Player
{
    public string Name             { get; set; }
    public int    Level            { get; set; }
    public double ExperiencePoints { get; set; }
    public bool   IsOnline         { get; set; }
    public string GameMode         { get; set; }

    public Player(string name, int level)
    {
        Name             = name;
        Level            = level;
        ExperiencePoints = 0;
        IsOnline         = false;
        GameMode         = "Classic";
    }

    public string GetRank()
    {
        if (Level < 20) return "Bronze";
        if (Level < 40) return "Silver";
        return "Gold";
    }

    public void AddExperience(double xp)
    {
        ExperiencePoints += xp;
        Console.WriteLine($"{Name} gained {xp} XP. Total: {ExperiencePoints}");
    }

    public void GoOnline()
    {
        IsOnline = true;
        Console.WriteLine($"{Name} is now online.");
    }

    public void LevelUp()
    {
        Level += 1;
        Console.WriteLine($"{Name} leveled up! Now level {Level}");
    }

    public string GetSummary()
        => $"[{GetRank()}] {Name} | Level {Level} | XP: {ExperiencePoints} | Online: {IsOnline} | Mode: {GameMode}";
}
