// Path: Data/Repository.cs
using System.Collections.Generic;
using System.Data.SQLite;
using SmartPlantBuddies.Models;
namespace SmartPlantBuddies.Data
{
    public class Repository
    {
        private readonly string _connectionString = "Data Source=smartplantbuddies.db";

        public Repository()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            string createUsersTable = @"CREATE TABLE IF NOT EXISTS Users (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Email TEXT,
                PasswordHash TEXT,
                CreatedAt TEXT
            );";

            string createSensorsTable = @"CREATE TABLE IF NOT EXISTS Sensors (
                SensorId INTEGER PRIMARY KEY AUTOINCREMENT,
                UserId INTEGER,
                Type TEXT,
                Location TEXT,
                FOREIGN KEY(UserId) REFERENCES Users(Id)
            );";

            string createSensorReadingsTable = @"CREATE TABLE IF NOT EXISTS SensorReadings (
                ReadingId INTEGER PRIMARY KEY AUTOINCREMENT,
                SensorId INTEGER,
                MoistureLevel REAL,
                Temperature REAL,
                Timestamp TEXT,
                FOREIGN KEY(SensorId) REFERENCES Sensors(SensorId)
            );";

            string createAlertsTable = @"CREATE TABLE IF NOT EXISTS Alerts (
                AlertId INTEGER PRIMARY KEY AUTOINCREMENT,
                UserId INTEGER,
                ReadingId INTEGER,
                Type TEXT,
                Timestamp TEXT,
                FOREIGN KEY(UserId) REFERENCES Users(Id),
                FOREIGN KEY(ReadingId) REFERENCES SensorReadings(ReadingId)
            );";

            string createWateringLogsTable = @"CREATE TABLE IF NOT EXISTS WateringLogs (
                LogId INTEGER PRIMARY KEY AUTOINCREMENT,
                UserId INTEGER,
                SensorId INTEGER,
                EventType TEXT,
                Notes TEXT,
                Timestamp TEXT,
                FOREIGN KEY(UserId) REFERENCES Users(Id),
                FOREIGN KEY(SensorId) REFERENCES Sensors(SensorId)
            );";

            using var command = new SQLiteCommand(connection);
            command.CommandText = createUsersTable;
            command.ExecuteNonQuery();

            command.CommandText = createSensorsTable;
            command.ExecuteNonQuery();

            command.CommandText = createSensorReadingsTable;
            command.ExecuteNonQuery();

            command.CommandText = createAlertsTable;
            command.ExecuteNonQuery();

            command.CommandText = createWateringLogsTable;
            command.ExecuteNonQuery();
        }

        // Save Sensor Reading
        public void SaveSensorReading(SensorReading reading)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            string query = @"INSERT INTO SensorReadings (SensorId, MoistureLevel, Temperature, Timestamp)
                             VALUES (@SensorId, @MoistureLevel, @Temperature, @Timestamp);";

            using var cmd = new SQLiteCommand(query, connection);
            cmd.Parameters.AddWithValue("@SensorId", reading.SensorId);
            cmd.Parameters.AddWithValue("@MoistureLevel", reading.MoistureLevel);
            cmd.Parameters.AddWithValue("@Temperature", reading.Temperature);
            cmd.Parameters.AddWithValue("@Timestamp", reading.Timestamp);
            cmd.ExecuteNonQuery();
        }

        // Retrieve all sensor readings
        public List<SensorReading> GetSensorReadings(int sensorId)
        {
            var readings = new List<SensorReading>();
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            string query = "SELECT * FROM SensorReadings WHERE SensorId = @SensorId";
            using var cmd = new SQLiteCommand(query, connection);
            cmd.Parameters.AddWithValue("@SensorId", sensorId);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                readings.Add(new SensorReading
                {
                    ReadingId = reader.GetInt32(0),
                    SensorId = reader.GetInt32(1),
                    MoistureLevel = reader.GetDouble(2),
                    Temperature = reader.GetDouble(3),
                    Timestamp = reader.GetString(4)
                });
            }
            return readings;
        }

        // Similar methods for other tables...
        public void SaveWateringLog(WateringLog log)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            string query = @"INSERT INTO WateringLogs (UserId, SensorId, EventType, Notes, Timestamp)
                             VALUES (@UserId, @SensorId, @EventType, @Notes, @Timestamp);";

            using var cmd = new SQLiteCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserId", log.UserId);
            cmd.Parameters.AddWithValue("@SensorId", log.SensorId);
            cmd.Parameters.AddWithValue("@EventType", log.EventType);
            cmd.Parameters.AddWithValue("@Notes", log.Notes);
            cmd.Parameters.AddWithValue("@Timestamp", log.Timestamp);
            cmd.ExecuteNonQuery();
        }

        // Add other retrieval/update methods as needed
    }
}