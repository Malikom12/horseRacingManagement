namespace HorseRacingManagementSystem;

public class Horse : RacingEntity
{
    private DateTime _dateOfBirth;
    private static int _currentId = 0;

    public DateTime DateOfBirth
    {
        get { return _dateOfBirth; }
        set
        {
            if (value > DateTime.Now)
                throw new ArgumentException("Date of birth cannot be in the future.");
            _dateOfBirth = value;
        }
    }

    public int HorseID { get; }

    public Horse(string name, DateTime dateOfBirth)
    {
        Name = name;
        DateOfBirth = dateOfBirth;
        HorseID = _currentId;
        _currentId++;
    }
    
    public int GetAge()
    {
        var today = DateTime.Today;
        var age = today.Year - DateOfBirth.Year;
        if (DateOfBirth.Date > today.AddYears(-age)) age--;
        return age;
    }
    
    public override string GetDetails()
    {
        return $"Horse: {Name}, ID: {HorseID}, DOB: {DateOfBirth.ToShortDateString()}, Age: {GetAge()}";
    }
}