namespace horseRacingManagementSystem;

public class RaceEvent : RacingEntity
{
    public DateTime EventDate { get; set; }
    public string Location { get; set; }
    public List<Race> Races { get; set; }

    public RaceEvent(string name, DateTime eventDate, string location)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty");
        if (string.IsNullOrWhiteSpace(location))
            throw new ArgumentException("Location cannot be empty");
        if (eventDate < DateTime.Now)
            throw new ArgumentException("Event date cannot be in the past");

        Name = name;
        EventDate = eventDate;
        Location = location;
        Races = new List<Race>();
    }

    public void AddRace(Race race)
    {
        Races.Add(race);
    }

    public void RemoveRace(Race race)
    {
        Races.Remove(race);
    }
    
    public override string GetDetails()
    {
        return $"Event: {Name}, Date: {EventDate.ToShortDateString()}, Location: {Location}, Number of Races: {Races.Count}";
    }
    
    public string GetRaceDetails()
    {
        if (Races.Count == 0)
            return "No races scheduled for this event.";

        string details = $"Races in {Name}:\n";
        foreach (var race in Races)
        {
            details += race.GetDetails() + "\n";
        }
        return details;
    }
}