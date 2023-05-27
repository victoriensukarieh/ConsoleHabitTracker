using Microsoft.Data.Sqlite;
using ConsoleHabitTracker;
class Habit
{
    public static void DisplayHabits()
    {
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

    public static Boolean AddHabit(string newName, int newUnitId)
    {
        try
        {
            using (var connection = new SqliteConnection(Database.connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText = $"INSERT INTO Habit (Name, UnitID) VALUES ('{newName}',{newUnitId})";

                tableCmd.ExecuteNonQuery();
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static Boolean UpdateHabit(int habitId, string newName, int newUnitId)
    {
        try
        {
            using (var connection = new SqliteConnection(Database.connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText = $"UPDATE Habit SET Name='{newName}',UnitID='{newUnitId}' WHERE ID = {habitId}";
                tableCmd.ExecuteNonQuery();
                connection.Close();
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static Boolean DeleteHabit(int habitId)
    {
        try
        {
            using (var connection = new SqliteConnection(Database.connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText = $"DELETE FROM Habit WHERE ID = {habitId}";

                tableCmd.ExecuteNonQuery();
                //}
                return true;
            }
        }
        catch
        {
            return true;
        }
    }

    public static Boolean IsHabitTracked(int habitID)
    {
        int counter = 0;
        using (var connection = new SqliteConnection(Database.connectionString))
        {
            connection.Open();
            var tableCmd = connection.CreateCommand();

            tableCmd.CommandText = $"SELECT * FROM Entry where HabitID = {habitID}";
            SqliteDataReader reader = tableCmd.ExecuteReader();

            if (reader.HasRows)
            {
                counter++;
            }
            connection.Close();
        }
        if (counter > 0)
        {
            return true;
        }
        else { return false; }
    }
}