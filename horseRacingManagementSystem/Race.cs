namespace HorseRacingManagementSystem;

public class Race : RacingEntity
{
    private static int _raceCounter = 1;

    public DateTime StartTime { get; set; }
    public List<Horse> Participants { get; private set; }

    public Race()
    {
        Name = "Race " + _raceCounter.ToString();
        _raceCounter++;
        StartTime = DateTime.MinValue;
        Participants = new List<Horse>();
    }

    public Race(string name, DateTime startTime)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            Name = "Race " + _raceCounter.ToString();
            _raceCounter++;
        }
        else
        {
            Name = name;
        }
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
        string timeInfo;
        if (StartTime != DateTime.MinValue)
        {
            timeInfo = ", Start Time: " + StartTime.ToString();
        }
        else
        {
            timeInfo = ", Start Time: Not set";
        }
        return "Race: " + Name + timeInfo + ", Participants: " + Participants.Count.ToString();
    }

    public string GetParticipantDetails()
    {
        string details = "Participants in " + Name + ":\n";
        foreach (Horse horse in Participants)
        {
            details += horse.GetDetails() + "\n";
        }
        return details;
    }
}