namespace horseRacingManagementSystem;

public class Horse : RacingEntity
{
    public DateTime DateOfBirth { get; set; }
    public string HorseID { get; set; }
    
    public Horse(string name, DateTime dateOfBirth, string horseID)
    {
        Name = name;
        DateOfBirth = dateOfBirth;
        HorseID = horseID;
    }
    
    public int GetAge()
    {
        return DateTime.Now.Year - DateOfBirth.Year;
    }
    
    public override string GetDetails()
    {
        return $"Horse: {Name}, ID: {HorseID}, DOB: {DateOfBirth.ToShortDateString()}, Age: {GetAge()}";
    }
}