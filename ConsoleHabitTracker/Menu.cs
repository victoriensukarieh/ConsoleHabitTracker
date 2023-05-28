class Menu
{
    public static void showGreeting()
    {
        Console.WriteLine("Hello there User!\nHow can i be of assisstance?\n");
        Console.WriteLine("Press any key to access the Main menu.\n");
        Console.ReadLine();
        Console.Clear();
    }

    public static void showMainMenu()
    {
        string choice = "";
        bool rightChoice = false;

        //Console.Clear();
        Console.WriteLine(@"Press A to view habits Menu.
Press B to view system units Menu.
Press C to View entries Menu.
Press X to Exit.");

        while (rightChoice == false)
        {
            choice = Console.ReadLine();
            switch (choice.ToUpper())
            {
                case "A":
                    showHabitMenu();
                    rightChoice = true;
                    break;
                case "B":
                    showUnitMenu();
                    rightChoice = true;
                    break;
                case "C":
                    ShowEntryMenu();
                    rightChoice = true;
                    break;
                case "X":
                    rightChoice = true;
                    break;
                default:
                    Console.WriteLine(@"Wrong choice. Try again please.");
                    //choice = Console.ReadLine();
                    break;
            }
        }
    }

    public static void showHabitMenu()
    {
        //List<Habit> habits = new();
        //habits = Database.getHabits();

        string choice = "";
        bool rightChoice = false;
        //string idInput;
        int habitId;
        while (rightChoice == false)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Habits Menu.");
            Console.WriteLine("---------------------------");
            Console.WriteLine(@"Press 1 To View Tracked Habits
Press 2 to add a habit.
Press 3 to update a habit.
Press 4 to delete a habit.
Press X to go back to the main menu.");
            choice = Console.ReadLine();
            switch (choice.ToUpper())
            {
                case "1":
                    Console.Clear();
                    Habit.DisplayHabits();
                    Console.WriteLine("Press any key to go back.");
                    Console.ReadLine();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Enter the name of your Habit:");
                    string habitName = Console.ReadLine();
                    Console.WriteLine("Choose the ID of the unit to use:");
                    Unit.DisplayUnits();
                    int habitUnit = Convert.ToInt32(Console.ReadLine());

                    if (Habit.AddHabit(habitName, habitUnit))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Habit inserted successfully.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Something went wrong while inserting new Habit.");
                        Console.ResetColor();
                    }
                    Console.WriteLine("Press any key to go back.");
                    Console.ReadLine();
                    break;
                case "3":
                    Console.Clear();
                    string newName;
                    int newUnitId;

                    Console.WriteLine("Which Habit do you want to update. choose an ID");
                    Habit.DisplayHabits();
                    habitId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Choose a new Habit Name");
                    newName = Console.ReadLine();
                    Console.WriteLine("choose a new Unit (type the ID of the unit you want to choose.)");
                    Unit.DisplayUnits();
                    newUnitId = Convert.ToInt32(Console.ReadLine());
                    Unit.DisplayUnits();
                    if (Habit.UpdateHabit(habitId, newName, newUnitId))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Habit updated successfully.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Something went wrong while updating the Habit.");
                        Console.ResetColor();
                    }

                    Console.WriteLine("Press any key to go back.");
                    Console.ReadLine();
                    break;
                case "4":
                    Console.Clear();
                    Habit.DisplayHabits();
                    Console.WriteLine("Which habit do you want to delete. choose an ID (please note all entries related to this habit will be deleted as well.)");
                    habitId = Convert.ToInt32(Console.ReadLine());

                    if (Habit.IsHabitTracked(habitId))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Habit cannot be deleted because there are some entries linked to it.");
                        Console.ResetColor();
                    }
                    else
                    {
                        if (Habit.DeleteHabit(habitId))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Habit Deleted successfully.");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Something went wrong while deleting the habit.");
                            Console.ResetColor();
                        }
                    }
                    //rightChoice = true;
                    Console.WriteLine("Press any key to go back.");
                    Console.ReadLine();
                    break;
                case "X":
                    rightChoice = true;
                    break;
                default:
                    Console.WriteLine("Wrong choice.");
                    Console.WriteLine("Press any key to try again.");
                    Console.ReadLine();
                    break;
            }
        }
        Console.Clear();
        Menu.showMainMenu();
    }

    public static void showUnitMenu()
    {
        int unitId;
        //Console.WriteLine("Units Menu Selected");

        string choice = "";
        bool rightChoice = false;
        while (rightChoice == false)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Units Menu.");
            Console.WriteLine("---------------------------");
            Console.WriteLine(@"Press 1 To View System Units
Press 2 to add a unit.
Press 3 to update a unit.
Press 4 to delete a unit.
Press X to go back to the main menu.");
            choice = Console.ReadLine();
            switch (choice.ToUpper())
            {
                case "1":
                    Console.Clear();
                    Unit.DisplayUnits();
                    Console.WriteLine("Press any key to go back.");
                    Console.ReadLine();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Enter the name of your Unit:");
                    string UnitName = Console.ReadLine();
                    Console.WriteLine("Choose the symbol of your unit:");
                    //Unit.DisplayUnits();
                    string UnitSymbol = Console.ReadLine();

                    if (Unit.AddUnit(UnitName, UnitSymbol))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Unit inserted successfully.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Something went wrong while inserting new Unit.");
                        Console.ResetColor();
                    }
                    Console.WriteLine("Press any key to go back.");
                    Console.ReadLine();
                    break;
                case "3":
                    Console.Clear();
                    string newName, newSym;

                    Console.WriteLine("Which Unit do you want to update. choose an ID");
                    Unit.DisplayUnits();
                    unitId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Choose a new Unit Name");
                    newName = Console.ReadLine();
                    Console.WriteLine("choose a new Unit Symbol");
                    newSym = Console.ReadLine();
                    if (Unit.UpdateUnit(unitId, newName, newSym))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Unit updated successfully.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Something went wrong while updating the Unit.");
                        Console.ResetColor();
                    }
                    Console.WriteLine("Press any key to go back.");
                    Console.ReadLine();
                    break;
                case "4":
                    Console.Clear();
                    Unit.DisplayUnits();
                    Console.WriteLine("Which unit do you want to delete. choose an ID (please you cannot delete a used unit.)");
                    unitId = Convert.ToInt32(Console.ReadLine());

                    if (Unit.IsUnitUsed(unitId))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Unit cannot be deleted because it is used.");
                        Console.ResetColor();
                    }
                    else
                    {
                        if (Unit.DeleteUnit(unitId))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Unit Deleted successfully.");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Something went wrong while deleting the unit.");
                            Console.ResetColor();
                        }
                    }
                    //rightChoice = true;
                    Console.WriteLine("Press any key to go back.");
                    Console.ReadLine();
                    break;
                case "X":
                    rightChoice = true;
                    break;
                default:
                    Console.WriteLine("Wrong choice.");
                    Console.WriteLine("Press any key to try again.");
                    Console.ReadLine();
                    break;
            }
        }
        Console.Clear();
        Menu.showMainMenu();
    }

    public static void ShowEntryMenu()
    {
        //List<Habit> habits = new();
        //habits = Database.getHabits();

        string choice = "";
        bool rightChoice = false;
        //string idInput;
        int habitId;
        while (rightChoice == false)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Entries Menu.");
            Console.WriteLine("---------------------------");
            Console.WriteLine(@"Press 1 To View Tracked Habits entries
Press 2 to view a summary of Tracked habits
Press 3 to add an entry.
Press 4 to update an entry.
Press 5 to delete an entry.
Press X to go back to the main menu.");
            choice = Console.ReadLine();
            switch (choice.ToUpper())
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Which Habit do you want to View?");
                    Habit.DisplayHabits();
                    habitId = Convert.ToInt32(Console.ReadLine());
                    Habit.DisplaySingleHabit(habitId);
                    Console.WriteLine("----------------------------------");
                    Entry.DisplayEntries(habitId);
                    Console.WriteLine("Press any key to go back.");
                    Console.ReadLine();
                    break;
                case "2":
                    Console.Clear();
                    Entry.DisplayEntriesSummary();
                    Console.WriteLine("Press any key to go back.");
                    Console.ReadLine();
                    break;
                case "3":
                    int quantity;
                    Console.Clear();
                    Console.WriteLine("Which Habit do you want to log?");
                    Habit.DisplayHabits();
                    habitId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Quantity:");
                    quantity = Convert.ToInt32(Console.ReadLine());
                    if (Entry.AddEntry(habitId, quantity))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Log inserted successfully.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Something went wrong while inserting data");
                        Console.ResetColor();
                    }

                    Console.WriteLine("Press any key to go back.");
                    Console.ReadLine();
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("Press any key to go back.");
                    Console.ReadLine();
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("Press any key to go back.");
                    Console.ReadLine();
                    break;
                case "X":
                    rightChoice = true;
                    break;
                default:
                    Console.WriteLine("Wrong choice.");
                    Console.WriteLine("Press any key to try again.");
                    Console.ReadLine();
                    break;
            }
        }
        Console.Clear();
        Menu.showMainMenu();

    }
}