using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DataBase {
    public sealed class ApplicationDbContext: DbContext {
        public DbSet<BDConsumer> Consumers { get; set; }

        // public ApplicationDbContext() {
        //     Database.EnsureCreated();
        // }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Data Source = C:/workspace/ElectricalEngineeringLiteV3/ElectricalEngineeringLiteV1/identifier.sqlite");
            

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<BDConsumer>().HasData(GetEmployees());
            base.OnModelCreating(modelBuilder);
        }

        private List<BDConsumer> GetEmployees() {
            return new List<BDConsumer> {
                new BDConsumer { Id = 100, FirstName = "John", LastName = "Doe" },
                new BDConsumer { Id = 101, FirstName = "Nicole", LastName = "Martha" },
                new BDConsumer { Id = 102, FirstName = "Steve", LastName = "Johnson" },
                new BDConsumer { Id = 103, FirstName = "Thomas", LastName = "Bond" },
            };
        }
    }


    public class BDConsumer {
        [Key] public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    // public class BDConsumerRepository {
    //     private SQLiteConnection connection;
    //
    //     private void CreateDatabase() {
    //         if (!File.Exists("myDatabase.db")) {
    //             SQLiteConnection.CreateFile("myDatabase.db");
    //             string query = "CREATE TABLE BDConsumers (StringId TEXT PRIMARY KEY, Name TEXT)";
    //             SQLiteCommand command = new SQLiteCommand(query, connection);
    //             command.ExecuteNonQuery();
    //         }
    //     }
    //     protected void OnModelCreating(DbModelBuilder modelBuilder) {
    //         modelBuilder.Entity<BDConsumer>().HasKey(c => c.StringId);
    //     }
    //
    //     public BDConsumerRepository() {
    //         CreateDatabase();
    //         connection = new SQLiteConnection("Data Source=myDatabase.db;Version=3;");
    //         connection.Open();
    //     }
    //
    //     public List<BDConsumer> GetAll() {
    //         List<BDConsumer> consumers = new List<BDConsumer>();
    //         string query = "SELECT * FROM BDConsumers";
    //         SQLiteCommand command = new SQLiteCommand(query, connection);
    //         SQLiteDataReader reader = command.ExecuteReader();
    //         while (reader.Read()) {
    //             BDConsumer consumer = new BDConsumer();
    //             consumer.StringId = reader["StringId"].ToString();
    //             consumer.Name = reader["Name"].ToString();
    //             consumers.Add(consumer);
    //         }
    //
    //         reader.Close();
    //         return consumers;
    //     }
    //
    //     public void Add(BDConsumer consumer) {
    //         string query = "INSERT INTO BDConsumers (StringId, Name) VALUES (@StringId, @Name)";
    //         SQLiteCommand command = new SQLiteCommand(query, connection);
    //         command.Parameters.AddWithValue("@StringId", consumer.StringId);
    //         command.Parameters.AddWithValue("@Name", consumer.Name);
    //         command.ExecuteNonQuery();
    //     }
    //
    //     public void Update(BDConsumer consumer) {
    //         string query = "UPDATE BDConsumers SET Name = @Name WHERE StringId = @StringId";
    //         SQLiteCommand command = new SQLiteCommand(query, connection);
    //         command.Parameters.AddWithValue("@StringId", consumer.StringId);
    //         command.Parameters.AddWithValue("@Name", consumer.Name);
    //         command.ExecuteNonQuery();
    //     }
    //
    //     public void Delete(BDConsumer consumer) {
    //         string query = "DELETE FROM BDConsumers WHERE StringId = @StringId";
    //         SQLiteCommand command = new SQLiteCommand(query, connection);
    //         command.Parameters.AddWithValue("@StringId", consumer.StringId);
    //         command.ExecuteNonQuery();
    //     }
    //
    //     public void Dispose() {
    //         connection.Close();
    //     }
    // }
}