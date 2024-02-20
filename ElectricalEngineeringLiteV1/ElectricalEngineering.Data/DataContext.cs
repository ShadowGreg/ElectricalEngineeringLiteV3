using System.Runtime.InteropServices.ComTypes;
using ElectricalEngineering.Domain;
using ElectricalEngineering.Domain.Feeder;
using Microsoft.EntityFrameworkCore;

namespace ElectricalEngineering.Data {
    public sealed class DataContext: DbContext {
        public DbSet<BaseConsumer> Consumers { get; set; }
        public DbSet<BaseCircuitBreaker> CircuitBreakers { get; set; }
        public DbSet<BaseCable> BaseCables { get; set; }
        public DbSet<BaseFeeder> BaseFeeders { get; set; }
        public DbSet<BaseBusbar> BaseBusbars { get; set; }
        public DbSet<BaseElectricalPanel> BaseElectricalPanels { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BaseConsumer>().HasKey(b => b.SelfId);
            modelBuilder.Entity<BaseCircuitBreaker>().HasKey(b => b.SelfId);
            modelBuilder.Entity<BaseCable>().HasKey(b => b.SelfId);
            modelBuilder.Entity<BaseFeeder>().HasKey(b => b.SelfId);
            modelBuilder.Entity<BaseBusbar>().HasKey(b => b.SelfId);
            //modelBuilder.Entity<BaseElectricalPanel>().HasKey(b => b.SelfId);
        }
    }
}