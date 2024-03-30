public class LevelSystem
{
    private Dictionary<int, string> _levelNames = new Dictionary<int, string>()
    {
        { 1, "Rookie" },
        { 2, "Apprentice" },
        { 3, "Expert" },

    };

    private Dictionary<int, int> _levelPointsRequirements = new Dictionary<int, int>()
    {
        { 1, 200 }, // Points required for level 1
        { 2, 700 }, // Points required for level 2
        { 3, 1200 }, // Points required for level 3
    };

    public int CurrentLevel { get; private set; }
    public int CurrentPoints { get; private set; }

    public LevelSystem()
    {
        CurrentLevel = 1;
        CurrentPoints = 0;
    }

    public void AddPoints(int points)
    {
        CurrentPoints += points;
        UpdateLevel();
    }

    private void UpdateLevel()
    {
        foreach (var levelRequirement in _levelPointsRequirements)
        {
            if (CurrentPoints >= levelRequirement.Value)
            {
                CurrentLevel = levelRequirement.Key;
            }
            else
            {
                break;
            }
        }
    }

    public string GetCurrentLevelName()
    {
        return _levelNames.ContainsKey(CurrentLevel) ? _levelNames[CurrentLevel] : "Unknown";
    }

    
}
