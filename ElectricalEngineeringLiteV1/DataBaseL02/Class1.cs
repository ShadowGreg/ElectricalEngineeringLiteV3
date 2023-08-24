using DataBase;
using Microsoft.EntityFrameworkCore;

namespace DataBaseL02 {
    public class Class1: DbContext {
        public DbSet<BDConsumer> Consumers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite(
                "Data Source = C:/workspace/ElectricalEngineeringLiteV3/ElectricalEngineeringLiteV1/identifier.sqlite");
        }
        
        
    }
}