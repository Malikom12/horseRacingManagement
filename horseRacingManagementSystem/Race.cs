namespace horseRacingManagementSystem;

public class Race : RacingEntity
{
    private static int _raceCounter = 1;

    public DateTime StartTime { get; set; }
    public List<Horse> Participants { get; set; }

    public Race()
    {
        Name = "Race " + _raceCounter;
        _raceCounter++;
        StartTime = DateTime.MinValue;
        Participants = new List<Horse>();
    }

    public Race(string name, DateTime startTime)
    {
        Name = name;
        StartTime = startTime;
        Participants = new List<Horse>();
    }

    public void AddHorse(Horse horse)
    {
        if (!Participants.Contains(horse))
        {
            Participants.Add(horse);
        }
        else
        {
            Console.WriteLine("This horse is already in the race.");
        }
    }

    public override string GetDetails()
    {
        string timeInfo = StartTime != DateTime.MinValue ? $", Start Time: {StartTime}" : ", Start Time: Not set";
        return $"Race: {Name}{timeInfo}, Participants: {Participants.Count}";
    }

    public string GetParticipantDetails()
    {
        string details = $"Participants in {Name}:\n";
        foreach (var horse in Participants)
        {
            details += horse.GetDetails() + "\n";
        }
        return details;
    }
}
