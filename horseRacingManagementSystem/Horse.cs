namespace horseRacingManagementSystem;

public class Horse
{
    private string name;
    private DateTime dateOfBirth;
    private string horseID;

    public string Name
    {
        get { return name; }
        set
        {
            
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty or whitespace."); 
            }

            name = value;
        }
    }

    public DateTime DateOfBirth
    {
        get { return dateOfBirth; }
        set
        {
            if (value > DateTime.Now)
            {
                throw new ArgumentException("Date of birth cannot be in the future.");
            }
                
            dateOfBirth = value;
        }
    }

    public string HorseID
    {
        get { return horseID; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("HorseID cannot be empty or whitespace.");
            }
                
            horseID = value;
        }
    }
    
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
    
    public string GetDetails()
    {
        return $"Horse: {Name}, ID: {HorseID}, DOB: {DateOfBirth.ToShortDateString()}, Age: {GetAge()}";
    }
}