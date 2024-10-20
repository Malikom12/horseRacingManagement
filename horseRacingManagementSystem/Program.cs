﻿namespace HorseRacingManagementSystem;

public class Program
    {
        static List<RaceEvent> _events = new List<RaceEvent>();
        static List<Horse> _horses = new List<Horse>();
        static UserType currentUser;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nWelcome to the Horse Racing Management System");
                Console.WriteLine("1. Racecourse Manager");
                Console.WriteLine("2. Horse Owner");
                Console.WriteLine("3. Racegoer");
                Console.WriteLine("4. Exit");
                Console.Write("Select your role: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        currentUser = new UserType(UserType.Role.RacecourseManager);
                        RacecourseManagerMenu();
                        break;
                    case "2":
                        currentUser = new UserType(UserType.Role.HorseOwner);
                        HorseOwnerMenu();
                        break;
                    case "3":
                        currentUser = new UserType(UserType.Role.Racegoer);
                        RacegoerMenu();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void RacecourseManagerMenu()
        {
            while (true)
            {
                Console.WriteLine("\n" + currentUser.ToString() + " Menu");
                Console.WriteLine("1. Create Race Event");
                Console.WriteLine("2. Add Race to Event");
                Console.WriteLine("3. Upload Horses for Race");
                Console.WriteLine("4. View All Events");
                Console.WriteLine("5. Return to Main Menu");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        if (currentUser.CanCreateEvent())
                            CreateRaceEvent();
                        else
                            Console.WriteLine("You don't have permission to create events.");
                        break;
                    case "2":
                        if (currentUser.CanAddRace())
                            AddRaceToEvent();
                        else
                            Console.WriteLine("You don't have permission to add races.");
                        break;
                    case "3":
                        if (currentUser.CanUploadHorses())
                            UploadHorsesForRace();
                        else
                            Console.WriteLine("You don't have permission to upload horses.");
                        break;
                    case "4":
                        ViewAllEvents();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void HorseOwnerMenu()
        {
            while (true)
            {
                Console.WriteLine("\n" + currentUser.ToString() + " Menu");
                Console.WriteLine("1. Register Horse");
                Console.WriteLine("2. Enter Horse in Race");
                Console.WriteLine("3. View Registered Horses");
                Console.WriteLine("4. View Upcoming Events");
                Console.WriteLine("5. Return to Main Menu");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        if (currentUser.CanRegisterHorse())
                            RegisterHorse();
                        else
                            Console.WriteLine("You don't have permission to register horses.");
                        break;
                    case "2":
                        if (currentUser.CanEnterHorseInRace())
                            EnterHorseInRace();
                        else
                            Console.WriteLine("You don't have permission to enter horses in races.");
                        break;
                    case "3":
                        ViewRegisteredHorses();
                        break;
                    case "4":
                        if (currentUser.CanViewUpcomingEvents())
                            ViewUpcomingEvents();
                        else
                            Console.WriteLine("You don't have permission to view upcoming events.");
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void RacegoerMenu()
        {
            while (true)
            {
                Console.WriteLine("\n" + currentUser.ToString() + " Menu");
                Console.WriteLine("1. View Upcoming Events");
                Console.WriteLine("2. View Event Details");
                Console.WriteLine("3. Return to Main Menu");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        if (currentUser.CanViewUpcomingEvents())
                            ViewUpcomingEvents();
                        else
                            Console.WriteLine("You don't have permission to view upcoming events.");
                        break;
                    case "2":
                        ViewEventDetails();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

    static void CreateRaceEvent()
    {
        Console.Write("Enter event name: ");
        string name = Console.ReadLine();
        Console.Write("Enter event date (yyyy-mm-dd): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
        {
            Console.Write("Enter location: ");
            string location = Console.ReadLine();
            try
            {
                _events.Add(new RaceEvent(name, date, location));
                Console.WriteLine("Event created successfully.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error creating event: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Invalid date format.");
        }
    }

    static void AddRaceToEvent()
    {
        if (_events.Count == 0)
        {
            Console.WriteLine("No events available. Create an event first.");
            return;
        }

        Console.Write("Enter event name: ");
        string eventName = Console.ReadLine();
        RaceEvent selectedEvent = null;
        foreach (RaceEvent evt in _events)
        {
            if (evt.Name == eventName)
            {
                selectedEvent = evt;
                break;
            }
        }

        if (selectedEvent != null)
        {
            Console.Write("Enter race name: ");
            string raceName = Console.ReadLine();
            Console.Write("Enter race start time (yyyy-mm-dd HH:mm): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime startTime))
            {
                try
                {
                    Race newRace = new Race(raceName, startTime);
                    selectedEvent.AddRace(newRace);
                    Console.WriteLine("Race added successfully.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error adding race: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid date/time format.");
            }
        }
        else
        {
            Console.WriteLine("Event not found.");
        }
    }

    static void RegisterHorse()
    {
        Console.Write("Enter horse name: ");
        string name = Console.ReadLine();
        Console.Write("Enter horse date of birth (yyyy-mm-dd): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime dob))
        {
            Horse newHorse = new Horse(name, dob);
            _horses.Add(newHorse);
            Console.WriteLine($"Horse registered successfully. Horse ID: {newHorse.HorseID}");
        }
        else
        {
            Console.WriteLine("Invalid date format.");
        }
    }

    static void EnterHorseInRace()
    {
        if (_events.Count == 0 || _horses.Count == 0)
        {
            Console.WriteLine("No events or horses available. Please create both first.");
            return;
        }

        Console.Write("Enter horse ID: ");
        if (int.TryParse(Console.ReadLine(), out int horseID))
        {
            Horse selectedHorse = null;
            foreach (Horse horse in _horses)
            {
                if (horse.HorseID == horseID)
                {
                    selectedHorse = horse;
                    break;
                }
            }

            if (selectedHorse != null)
            {
                Console.Write("Enter event name: ");
                string eventName = Console.ReadLine();
                RaceEvent selectedEvent = null;
                foreach (RaceEvent evt in _events)
                {
                    if (evt.Name == eventName)
                    {
                        selectedEvent = evt;
                        break;
                    }
                }

                if (selectedEvent != null)
                {
                    Console.Write("Enter race name: ");
                    string raceName = Console.ReadLine();
                    Race selectedRace = null;
                    foreach (Race race in selectedEvent.Races)
                    {
                        if (race.Name == raceName)
                        {
                            selectedRace = race;
                            break;
                        }
                    }

                    if (selectedRace != null)
                    {
                        selectedRace.AddHorse(selectedHorse);
                        Console.WriteLine("Horse entered in race successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Race not found.");
                    }
                }
                else
                {
                    Console.WriteLine("Event not found.");
                }
            }
            else
            {
                Console.WriteLine("Horse not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid horse ID.");
        }
    }

    static void ViewEvents()
    {
        if (_events.Count == 0)
        {
            Console.WriteLine("No events available.");
            return;
        }

        foreach (RaceEvent evt in _events)
        {
            Console.WriteLine(evt.GetDetails());
            Console.WriteLine(evt.GetRaceDetails());
            Console.WriteLine();
        }
    }
    
    
    static void UploadHorsesForRace()
    {
        if (_events.Count == 0)
        {
            Console.WriteLine("No events available. Create an event first.");
            return;
        }

        Console.Write("Enter event name: ");
        string eventName = Console.ReadLine();
        RaceEvent selectedEvent = null;
        foreach (RaceEvent evt in _events)
        {
            if (evt.Name == eventName)
            {
                selectedEvent = evt;
                break;
            }
        }

        if (selectedEvent != null)
        {
            Console.Write("Enter race name: ");
            string raceName = Console.ReadLine();
            Race selectedRace = null;
            foreach (Race race in selectedEvent.Races)
            {
                if (race.Name == raceName)
                {
                    selectedRace = race;
                    break;
                }
            }

            if (selectedRace != null)
            {
                Console.WriteLine("Enter horse details (name,dateofbirth) one per line. Enter a blank line to finish:");
                while (true)
                {
                    string input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input)) break;

                    string[] parts = input.Split(',');
                    if (parts.Length == 2)
                    {
                        string name = parts[0].Trim();
                        if (DateTime.TryParse(parts[1].Trim(), out DateTime dob))
                        {
                            Horse horse = new Horse(name, dob);
                            selectedRace.AddHorse(horse);
                            _horses.Add(horse);
                            Console.WriteLine($"Added horse: {name}");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid date format for horse: {name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input format. Please use: name,dateofbirth");
                    }
                }
                Console.WriteLine("Finished uploading horses to race.");
            }
            else
            {
                Console.WriteLine("Race not found.");
            }
        }
        else
        {
            Console.WriteLine("Event not found.");
        }
    }

    static void ViewAllEvents()
    {
        if (_events.Count == 0)
        {
            Console.WriteLine("No events available.");
            return;
        }

        foreach (RaceEvent evt in _events)
        {
            Console.WriteLine(evt.GetDetails());
            Console.WriteLine(evt.GetRaceDetails());
            Console.WriteLine();
        }
    }

    static void ViewRegisteredHorses()
    {
        if (_horses.Count == 0)
        {
            Console.WriteLine("No horses registered.");
            return;
        }

        foreach (Horse horse in _horses)
        {
            Console.WriteLine(horse.GetDetails());
        }
    }

    static void ViewUpcomingEvents()
    {
        if (_events.Count == 0)
        {
            Console.WriteLine("No events available.");
            return;
        }

        DateTime now = DateTime.Now;
        bool hasUpcomingEvents = false;

        foreach (RaceEvent evt in _events)
        {
            if (evt.EventDate >= now)
            {
                Console.WriteLine(evt.GetDetails());
                hasUpcomingEvents = true;
            }
        }

        if (!hasUpcomingEvents)
        {
            Console.WriteLine("No upcoming events.");
        }
    }

    static void ViewEventDetails()
    {
        if (_events.Count == 0)
        {
            Console.WriteLine("No events available.");
            return;
        }

        Console.Write("Enter event name: ");
        string eventName = Console.ReadLine();
        RaceEvent selectedEvent = null;
        foreach (RaceEvent evt in _events)
        {
            if (evt.Name == eventName)
            {
                selectedEvent = evt;
                break;
            }
        }

        if (selectedEvent != null)
        {
            Console.WriteLine(selectedEvent.GetDetails());
            Console.WriteLine(selectedEvent.GetRaceDetails());
        }
        else
        {
            Console.WriteLine("Event not found.");
        }
    }
}