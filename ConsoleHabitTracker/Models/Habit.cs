using Microsoft.Data.Sqlite;
using ConsoleHabitTracker;
class Habit {
    //static string connectionString = @"Data Source=HabitTracker.db";

    public static void DisplayHabits(){        
        using (var connection = new SqliteConnection(Database.connectionString))
        {
            connection.Open();
            var tableCmd = connection.CreateCommand();
                       
            tableCmd.CommandText = @"SELECT Habit.ID, Habit.Name, Habit.UnitID,Unit.Name,Unit.Symbol
            FROM Habit,Unit
            WHERE Habit.UnitID = Unit.ID";
            SqliteDataReader reader = tableCmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"ID = {reader.GetInt32(0)}, Name = {reader.GetString(1)}, Unit = {reader.GetString(4)}");                     
                }
            }
            else
            {
                Console.WriteLine("No tracked habits exists.");
            }
            connection.Close();
        }       
    }
}