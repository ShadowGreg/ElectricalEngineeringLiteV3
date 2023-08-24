﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using CoreV01.Feeder;
using CoreV01.Properties;

namespace DataBaseSL01 {
    public class SqLiteHelper {
        private readonly string _connectionString;

        public SqLiteHelper(string databaseFile) {
            _connectionString = $"Data Source={databaseFile};Version=3;";
            CreateDatabaseIfNotExists(databaseFile);
        }

        private static void CreateDatabaseIfNotExists(string databaseFile) {
            if (!System.IO.File.Exists(databaseFile)) {
                SQLiteConnection.CreateFile(databaseFile);
            }
        }

        public void CreateDatabase<T>() {
            using (var connection = new SQLiteConnection(_connectionString)) {
                connection.Open();

                var createTableQuery = GetCreateTableQuery<T>();

                using (var command = new SQLiteCommand(createTableQuery, connection)) {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteTable<T>() {
            using (var connection = new SQLiteConnection(_connectionString)) {
                connection.Open();

                var tableName = typeof(T).Name;
                var deleteTableQuery = $"DROP TABLE IF EXISTS {tableName}";

                using (var command = new SQLiteCommand(deleteTableQuery, connection)) {
                    command.ExecuteNonQuery();
                }
            }
        }

        private string GetCreateTableQuery<T>() {
            var tableName = typeof(T).Name;
            var properties = typeof(T).GetProperties();
            var createTableQuery = $"CREATE TABLE IF NOT EXISTS {tableName} (";

            foreach (var property in properties)
            {
                var columnName = property.Name;
                var columnType = GetColumnType(property.PropertyType);
                createTableQuery += $"{columnName} {columnType}, ";
            }

            createTableQuery = createTableQuery.TrimEnd(',', ' ');

            // Check if there is a field of type List<BaseFeeder>
            if (typeof(T).GetProperty("Feeders") != null &&
                typeof(T).GetProperty("Feeders").PropertyType == typeof(List<BaseFeeder>))
            {
                createTableQuery +=
                    $", FeedersOwnerId INTEGER, FOREIGN KEY(FeedersOwnerId) REFERENCES {tableName}(SelfId)";

                // Create the Feeders table
                createTableQuery += $"); CREATE TABLE IF NOT EXISTS Feeders (Id INTEGER PRIMARY KEY AUTOINCREMENT, FeedersKey INTEGER, FOREIGN KEY(FeedersKey) REFERENCES {tableName}(SelfId)";
            }

            // Check if there is a field of type List<BaseBusbar>
            if (typeof(T).GetProperty("BusBars") != null &&
                typeof(T).GetProperty("BusBars").PropertyType == typeof(List<BaseBusbar>))
            {
                createTableQuery +=
                    $", BusBarsOwnerId INTEGER, FOREIGN KEY(BusBarsOwnerId) REFERENCES {tableName}(SelfId)";

                // Create the BusBars table
                createTableQuery += $"); CREATE TABLE IF NOT EXISTS BusBars (Id INTEGER PRIMARY KEY AUTOINCREMENT, BusBarsKey INTEGER, FOREIGN KEY(BusBarsKey) REFERENCES {tableName}(SelfId)";
            }

            createTableQuery += ")";

            return createTableQuery;
        }

        private string GetColumnType(Type propertyType) {
            if (propertyType == typeof(int)) {
                return "INTEGER";
            }
            else if (propertyType == typeof(string)) {
                return "TEXT";
            }
            else if (propertyType == typeof(double)) {
                return "REAL";
            }
            else if (propertyType == typeof(ConsumerType)) {
                return "TEXT";
            }
            else if (propertyType == typeof(Material)) {
                return "TEXT";
            }
            else if (propertyType == typeof(BaseCircuitBreaker)) {
                return "TEXT";
            }
            else if (propertyType == typeof(BaseCable)) {
                return "TEXT";
            }
            else if (propertyType == typeof(BaseConsumer)) {
                return "TEXT";
            }
            else if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(List<>)) {
                var genericArgumentType = propertyType.GetGenericArguments()[0];
                return $"TEXT REFERENCES {genericArgumentType.Name}(Id)";
            }
            // Add more data types as per your requirements

            throw new NotSupportedException($"Data type {propertyType.Name} is not supported.");
        }
    }
}