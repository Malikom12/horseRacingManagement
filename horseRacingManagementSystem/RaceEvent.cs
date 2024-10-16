namespace horseRacingManagementSystem;

public class RaceEvent : RacingEntity
{
    public DateTime EventDate { get; set; }
    public string Location { get; set; }
    public List<Race> Races { get; set; }

    public RaceEvent(string name, DateTime eventDate, string location)
    {
        Name = name;
        EventDate = eventDate;
        Location = location;
        Races = new List<Race>();
    }

    public void AddRace(Race race)
    {
        Races.Add(race);
    }

    public override string GetDetails()
    {
        return $"Event: {Name}, Date: {EventDate.ToShortDateString()}, Location: {Location}, Number of Races: {Races.Count}";
    }
}