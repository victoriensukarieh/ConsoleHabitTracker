class Helpers{
    public static int ValidateIntegerInput(){
        string input = Console.ReadLine();
        while (String.IsNullOrEmpty(input) || !Int32.TryParse(input, out _))
        {
            Console.Beep();
            Console.WriteLine("The input needs to be an integer. Enter the correct input.");
            input = Console.ReadLine();
        }
        return Convert.ToInt32(input);
    }

    public static string ValidateStringInput(){
        string input = Console.ReadLine();
        while (String.IsNullOrEmpty(input))
        {
            Console.Beep();
            Console.WriteLine("The input needs to be an integer. Enter the correct input.");
            input = Console.ReadLine();
        }
        return input;       
    }
}