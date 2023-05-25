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
Press C to register an entry.
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

        protected static void showHabitMenu()
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
                    /*Console.Clear();
                    Console.WriteLine("Enter the name of your Habit:");
                    string habitName = Console.ReadLine();
                    Console.WriteLine("Choose the ID of the unit to use:");
                    Database.printUnits(Database.getUnits());
                    int habitUnit = Convert.ToInt32(Console.ReadLine());
                    Habit.AddHabit(habitName, habitUnit,ref habits);*/
                    Console.WriteLine("Press any key to go back.");
                    Console.ReadLine();
                    break;
                case "3":
                    /*Console.Clear();
                    string newName;
                    int newUnitId;

                    Console.WriteLine("Which Habit do you want to update. choose an ID");
                    //Database.printHabits(Database.getHabits());
                    printAllHabits(habits);
                    habitId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Choose a new Habit Name");
                    newName = Console.ReadLine();
                    Console.WriteLine("choose a new Unit (type the ID of the unit you want to choose.)");
                    Database.printUnits(Database.getUnits());
                    newUnitId = Convert.ToInt32(Console.ReadLine());
                    if (Habit.UpdateHabit(habitId, newName, newUnitId,ref habits))
                    {
                        Console.WriteLine("Habit Updated Successfully.");
                    }
                    else
                    {
                        Console.WriteLine("There was an error while updating the habit. please try again later.");
                    }*/

                    Console.WriteLine("Press any key to go back.");
                    Console.ReadLine();
                    break;
                case "4":
                    /*Console.Clear();
                    //Database.printHabits(Database.getHabits());
                    printAllHabits(habits);
                    Console.WriteLine("Which habit do you want to delete. choose an ID (please note all entries related to this habit will be deleted as well.)");
                    habitId = Convert.ToInt32(Console.ReadLine());
                    //habitId = Helpers.ValidateInput(habitId);
                    if (Habit.DeleteHabit(habitId,ref habits))
                    {
                        Console.WriteLine("Habit deleted successfully");
                    }
                    else
                    {
                        Console.WriteLine("Habit cannot be deleted because there are some entries linked to it.");
                    }
                    //rightChoice = true;*/
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

    protected static void showUnitMenu()
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
                    /*Console.Clear();
                    Console.WriteLine("Enter the name of your unit:");
                    string unitName = Console.ReadLine();
                    Console.WriteLine("Enter the Symbol of your unit:");
                    string unitSym = Console.ReadLine();
                    Database.addUnit(unitName, unitSym);
                    //rightChoice = true;
                    Console.WriteLine("Press any key to go back.");
                    Console.ReadLine();*/
                    break;
                case "3":
                    /*Console.Clear();
                    string newName, newSym;
                    Database.printUnits(Database.getUnits());
                    Console.WriteLine("Which Unit do you want to update. choose an ID");
                    unitId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Choose a new Unit Name");
                    newName = Console.ReadLine();
                    Console.WriteLine("choose a new Unit Symbol");
                    newSym = Console.ReadLine();
                    Database.UpdateUnit(unitId, newName, newSym);
                    //rightChoice = true;
                    Console.WriteLine("Press any key to go back.");
                    Console.ReadLine();*/
                    break;
                case "4":
                    /*Console.Clear();
                    Database.printUnits(Database.getUnits());
                    Console.WriteLine("Which Unit do you want to delete. choose an ID (please note that you cannot delete a unit used by a tracked habit.)");
                    unitId = Convert.ToInt32(Console.ReadLine());
                    if (Database.DeleteUnit(unitId))
                    {
                        Console.WriteLine("Unit deleted successfully");
                    }
                    else
                    {
                        Console.WriteLine("Unit cannot be deleted because it is used.");
                    }

                    //rightChoice = true;
                    Console.WriteLine("Press any key to go back.");
                    Console.ReadLine();
                    break;*/
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