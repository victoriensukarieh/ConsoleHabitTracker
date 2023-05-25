using Microsoft.Data.Sqlite;
using ConsoleHabitTracker;
class Unit {
    public static void DisplayUnits(){        
        using (var connection = new SqliteConnection(Database.connectionString))
        {
            connection.Open();
            var tableCmd = connection.CreateCommand();
           
            tableCmd.CommandText = @"SELECT ID,Name,Symbol FROM Unit";
            SqliteDataReader reader = tableCmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"ID = {reader.GetInt32(0)}, Name = {reader.GetString(1)}, Symbol = {reader.GetString(2)}");                     
                }
            }
            else
            {
                Console.WriteLine("No Units exists.");
            }
            connection.Close();
        }       
    }
}