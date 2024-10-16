namespace horseRacingManagementSystem;

public class Race : RacingEntity
{
    public DateTime StartTime { get; set; }
    public List<Horse> Participants { get; set; }
    public double Distance { get; set; } // in meters or furlongs

    public Race(string name, DateTime startTime, double distance)
    {
        Name = name;
        StartTime = startTime;
        Distance = distance;
        Participants = new List<Horse>();
    }

    public void AddHorse(Horse horse)
    {
        Participants.Add(horse);
    }

    public override string GetDetails()
    {
        return $"Race: {Name}, Start Time: {StartTime}, Distance: {Distance}m, Participants: {Participants.Count}";
    }
}