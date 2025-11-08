using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System;
using SmartPlantBuddies.Models;

namespace SmartPlantBuddies.Data
{
    public class Repository
    {
        private readonly string _dbPath = "wateringLogs.db";

        public Repository()
        {
            if (!File.Exists(_dbPath))
            {
                SQLiteConnection.CreateFile(_dbPath);
                using (var conn = new SQLiteConnection($"Data Source={_dbPath}"))
                {
                    conn.Open();
                    var cmd = new SQLiteCommand(
                        "CREATE TABLE WateringLogs (Id INTEGER PRIMARY KEY, WateredAt TEXT, Notes TEXT)", conn);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddWateringLog(WateringLog log)
        {
            using (var conn = new SQLiteConnection($"Data Source={_dbPath}"))
            {
                conn.Open();
                var cmd = new SQLiteCommand(
                    "INSERT INTO WateringLogs (WateredAt, Notes) VALUES (@WateredAt, @Notes)", conn);
                cmd.Parameters.AddWithValue("@WateredAt", log.WateredAt.ToString("o")); // ISO 8601
                cmd.Parameters.AddWithValue("@Notes", log.Notes);
                cmd.ExecuteNonQuery();
            }
        }

        public List<WateringLog> GetAllWateringLogs()
        {
            var logs = new List<WateringLog>();
            using (var conn = new SQLiteConnection($"Data Source={_dbPath}"))
            {
                conn.Open();
                // Order by WateredAt descending for latest first
                var cmd = new SQLiteCommand("SELECT Id, WateredAt, Notes FROM WateringLogs ORDER BY WateredAt DESC", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        logs.Add(new WateringLog
                        {
                            Id = reader.GetInt32(0),
                            WateredAt = DateTime.Parse(reader.GetString(1)),
                            Notes = reader.IsDBNull(2) ? "" : reader.GetString(2)
                        });
                    }
                }
            }
            return logs;
        }
    }
}