namespace HorseRacingManagementSystem
{
    public class UserType
    {
        public enum Role
        {
            RacecourseManager,
            HorseOwner,
            Racegoer
        }

        public Role UserRole { get; private set; }

        public UserType(Role role)
        {
            UserRole = role;
        }

        public bool CanCreateEvent()
        {
            return UserRole == Role.RacecourseManager;
        }

        public bool CanAddRace()
        {
            return UserRole == Role.RacecourseManager;
        }

        public bool CanUploadHorses()
        {
            return UserRole == Role.RacecourseManager;
        }

        public bool CanRegisterHorse()
        {
            return UserRole == Role.HorseOwner;
        }

        public bool CanEnterHorseInRace()
        {
            return UserRole == Role.HorseOwner;
        }

        public bool CanViewUpcomingEvents()
        {
            return UserRole == Role.Racegoer || UserRole == Role.HorseOwner || UserRole == Role.RacecourseManager;
        }

        public override string ToString()
        {
            return UserRole.ToString();
        }
    }
}