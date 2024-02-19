using System;
using System.Data.SQLite;
using CoreV01.Properties;

namespace DataBaseSL01.ReadWrite {
    public class DataController<T> where T : DBDependence {
        private readonly string _databaseFile;
        private readonly string _connectionString;
        private readonly SqLiteHelper _dbHelper;

        public DataController(string databaseFile) {
            _databaseFile = databaseFile;
            _connectionString = $"Data Source={databaseFile};Version=3;";
            _dbHelper = new SqLiteHelper(databaseFile);
            _dbHelper.CreateDatabase<T>();
        }

        private bool ConsumerExists(string selfId) {
            using (var connection = new SQLiteConnection(_connectionString)) {
                connection.Open();

                string selectQuery = $"SELECT COUNT(*) FROM {typeof(T).Name} WHERE SelfId = @SelfId";

                using (var command = new SQLiteCommand(selectQuery, connection)) {
                    command.Parameters.AddWithValue("@SelfId", selfId);
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    return count > 0;
                }
            }
        }

        public void UpdateConsumer(T consumer) {
            using (var connection = new SQLiteConnection(_connectionString)) {
                connection.Open();

                var properties = typeof(T).GetProperties();
                var updateQuery = $"UPDATE {typeof(T).Name} SET ";

                for (int i = 0; i < properties.Length; i++) {
                    var property = properties[i];
                    updateQuery += $"{property.Name} = @{property.Name}";

                    if (i < properties.Length - 1)
                        updateQuery += ", ";
                }

                updateQuery += " WHERE SelfId = @SelfId";

                using (var command = new SQLiteCommand(updateQuery, connection)) {
                    foreach (var property in properties)
                        command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(consumer));

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public void WriteConsumer(T consumer) {
            if (!ConsumerExists(consumer.SelfId)) {
                using (var connection = new SQLiteConnection(_connectionString)) {
                    connection.Open();

                    var properties = typeof(T).GetProperties();
                    var insertQuery = $"INSERT INTO {typeof(T).Name} (";

                    for (int i = 0; i < properties.Length; i++) {
                        var property = properties[i];
                        insertQuery += property.Name;

                        if (i < properties.Length - 1)
                            insertQuery += ", ";
                    }

                    insertQuery += ") VALUES (";

                    for (int i = 0; i < properties.Length; i++) {
                        var property = properties[i];
                        insertQuery += $"@{property.Name}";

                        if (i < properties.Length - 1)
                            insertQuery += ", ";
                    }

                    insertQuery += ")";

                    using (var command = new SQLiteCommand(insertQuery, connection)) {
                        foreach (var property in properties)
                            command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(consumer));

                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }
            }
            else {
                UpdateConsumer(consumer);
            }
        }

        public T ReadConsumer(string id) {
            using (var connection = new SQLiteConnection(_connectionString)) {
                connection.Open();

                string selectQuery = $"SELECT * FROM {typeof(T).Name} WHERE SelfId = @SelfId";

                using (var command = new SQLiteCommand(selectQuery, connection)) {
                    command.Parameters.AddWithValue("@SelfId", id);

                    using (var reader = command.ExecuteReader()) {
                        if (reader.Read()) {
                            var consumer = Activator.CreateInstance<T>();

                            foreach (var property in typeof(T).GetProperties()) {
                                var value = reader[property.Name];
                                if (value != DBNull.Value)
                                    property.SetValue(consumer, value);
                            }

                            return consumer;
                        }
                    }
                }

                connection.Close();
            }

            return null;
        }
    }
}