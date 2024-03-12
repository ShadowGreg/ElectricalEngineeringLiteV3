namespace ElectricalEngineering.Data.Data
{
    public class EfDbInitializer
        : IDbInitializer
    {
        private readonly DataContext _dataContext;

        public EfDbInitializer(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public void InitializeDb()
        {
            _dataContext.Database.EnsureDeleted();
            _dataContext.Database.EnsureCreated();
            
            _dataContext.AddRange(FakeDataBase.Consumers);
            _dataContext.SaveChanges();
            
            _dataContext.AddRange(FakeDataBase.Cables);
            _dataContext.SaveChanges();
            
            _dataContext.AddRange(FakeDataBase.CircuitBreakers);
            _dataContext.SaveChanges();
            
            _dataContext.AddRange(FakeDataBase.BaseFeeders);
            _dataContext.SaveChanges();
            
            _dataContext.AddRange(FakeDataBase.BusBars);
            _dataContext.SaveChanges();
            
            _dataContext.AddRange(FakeDataBase.ElectricalPanels);
            _dataContext.SaveChanges();
        }
    }

}