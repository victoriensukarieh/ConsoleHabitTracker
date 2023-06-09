using ConsoleTableExt;

class Helpers
{
    public static int ValidateIntegerInput()
    {
        string input = Console.ReadLine();
        while (String.IsNullOrEmpty(input) || !Int32.TryParse(input, out _))
        {
            Console.WriteLine("The input needs to be an integer. Enter the correct input.");
            input = Console.ReadLine();
        }
        return Convert.ToInt32(input);
    }

    public static string ValidateStringInput()
    {
        string input = Console.ReadLine();
        while (String.IsNullOrEmpty(input))
        {
            Console.WriteLine("The input cannot be empty. Enter the correct input.");
            input = Console.ReadLine();
        }
        return input;
    }

    public static void PrintTable(List<List<object>> tableData, List<String> header)
    {
        Console.WriteLine();
        ConsoleTableBuilder
            .From(tableData)
            .WithFormat(ConsoleTableBuilderFormat.Alternative)
            .WithColumn(header)
            .ExportAndWriteLine();
        Console.WriteLine();
    }

    public static void PrintSuccessMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void PrintFailureMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void PrintWarningMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}