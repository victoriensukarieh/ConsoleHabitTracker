using Microsoft.Data.Sqlite;
using ConsoleHabitTracker;
class Entry
{
    public static void DisplayEntries(int habitId)
    {
        Console.WriteLine("Quantity\tSymbol\tDate");
        using (var connection = new SqliteConnection(Database.connectionString))
        {
            connection.Open();
            var tableCmd = connection.CreateCommand();

            tableCmd.CommandText = $@"select Entry.Quantity,Unit.Symbol,Entry.Date
from entry,Habit h,Unit
WHERE h.ID = entry.habitId
and unit.ID = h.UnitID
AND h.ID = {habitId}";
            SqliteDataReader reader = tableCmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetInt32(0)}\t{reader.GetString(1)}\t{reader.GetString(2)}");
                }
            }
            else
            {
                Console.WriteLine("No tracked habits exists.");
            }
            connection.Close();
        }
    }

    public static void DisplayEntriesSummary()
    {
        //Console.WriteLine("Quantity\tSymbol\tDate");
        using (var connection = new SqliteConnection(Database.connectionString))
        {
            connection.Open();
            var tableCmd = connection.CreateCommand();

            tableCmd.CommandText = @"select h.Name,SUM(Entry.Quantity),Unit.Symbol
from entry,Habit h,Unit
WHERE h.ID = entry.habitId
and unit.ID = h.UnitID
GROUP BY h.ID";
            SqliteDataReader reader = tableCmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetString(0)}: {reader.GetInt32(1)} {reader.GetString(2)}");
                }
            }
            else
            {
                Console.WriteLine("No tracked habits exists.");
            }
            connection.Close();
        }

    }

    public static Boolean AddEntry(int habitId, int quantity)
    {
        try
        {
            using (var connection = new SqliteConnection(Database.connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText = $"INSERT INTO Entry (HabitID,Date,Quantity) VALUES ('{habitId}',Date(),{quantity})";

                tableCmd.ExecuteNonQuery();
            }
            return true;
        }
        catch
        {
            return false;
        }
    }
}