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
                Console.WriteLine("No entry exists.");
            }
            connection.Close();
        }
    }

    public static void DisplayEntriesDetailed(int habitId)
    {
        //Console.WriteLine("Quantity\tSymbol\tDate");
        using (var connection = new SqliteConnection(Database.connectionString))
        {
            connection.Open();
            var tableCmd = connection.CreateCommand();

            tableCmd.CommandText = $@"select Entry.ID,Entry.Quantity,Unit.Symbol,Entry.Date
from entry,Habit h,Unit
WHERE h.ID = entry.habitId
and unit.ID = h.UnitID
AND h.ID = {habitId}";
            SqliteDataReader reader = tableCmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"ID = {reader.GetInt32(0)}: {reader.GetInt32(1)}\t{reader.GetString(2)}\t{reader.GetString(3)}");
                }
            }
            else
            {
                Console.WriteLine("No entry exists.");
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
                Console.WriteLine("No entry exists.");
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

    public static Boolean UpdateEntry(int entryId,int quantity)
    {
        try
        {
            using (var connection = new SqliteConnection(Database.connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText = $"UPDATE Entry SET Quantity='{quantity}' WHERE ID = {entryId}";
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

    public static Boolean DeleteEntry(int entryId)
    {
        try
        {
            using (var connection = new SqliteConnection(Database.connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText = $"DELETE FROM Entry WHERE ID = {entryId}";

                tableCmd.ExecuteNonQuery();
                
                return true;
            }
        }
        catch
        {
            return true;
        }
    }

    public static Boolean EntryExist(int entryId){
        int counter = 0;
        using (var connection = new SqliteConnection(Database.connectionString))
        {
            connection.Open();
            var tableCmd = connection.CreateCommand();

            tableCmd.CommandText = $"SELECT * FROM Entry where ID = {entryId}";
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