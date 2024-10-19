namespace HorseRacingManagementSystem;

public class Program
    {
        static List<RaceEvent> _events = new List<RaceEvent>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n1. Create Race Event");
                Console.WriteLine("2. Add Race to Event");
                Console.WriteLine("3. View Events");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateRaceEvent();
                        break;
                    case "2":
                        AddRaceToEvent();
                        break;
                    case "3":
                        ViewEvents();
                        break;
                    case "4":
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
                _events.Add(new RaceEvent(name, date, location));
                Console.WriteLine("Event created successfully.");
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
            foreach (RaceEvent e in _events)
            {
                if (e.Name == eventName)
                {
                    selectedEvent = e;
                    break;
                }
            }

            if (selectedEvent != null)
            {
                Console.Write("Enter race name: ");
                string raceName = Console.ReadLine();
                Console.Write("Enter race date (yyyy-mm-dd): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                selectedEvent.AddRace(new Race(raceName, date));
                Console.WriteLine("Race added successfully.");
            }
            else
            {
                Console.WriteLine("Event not found.");
            }
        }

        static void ViewEvents()
        {
            if (_events.Count == 0)
            {
                Console.WriteLine("No events available.");
                return;
            }

            foreach (var evt in _events)
            {
                Console.WriteLine(evt.GetDetails());
            }
        }
    }