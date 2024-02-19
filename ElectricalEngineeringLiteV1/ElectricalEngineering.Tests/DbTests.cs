using ElectricalEngineering.Domain.Contrlollers.ElectricalPanel;
using ElectricalEngineering.Domain.Feeder;

namespace BackendTests;

[TestFixture]
public class DbTests {
    [SetUp]
    public void Setup() {
        _electricalPanelFillController = new ElectricalPanelFillController();
        _electricalPanelFillController.AddOnPanel(new List<BaseConsumer> {
                new BaseConsumer {
                    RatedElectricPower = 1
                },
                new BaseConsumer {
                    RatedElectricPower = 2
                },
                new BaseConsumer {
                    RatedElectricPower = 3
                }
            }
        );
    }

    private ElectricalPanelFillController _electricalPanelFillController;
    private const string databaseFile = "../../database.sav";

    // [Test]
    // public void Controller_Test_For_A_Specific_Value() {
    //     // Arrange
    //     var sqliteHelper = new SqLiteHelper(databaseFile);
    //
    //
    //     // Act
    //     sqliteHelper.DeleteTable<BaseConsumer>();
    //     sqliteHelper.CreateDatabase<BaseConsumer>();
    //
    //     sqliteHelper.DeleteTable<BaseCable>();
    //     sqliteHelper.CreateDatabase<BaseCable>();
    //
    //     sqliteHelper.DeleteTable<BaseCircuitBreaker>();
    //     sqliteHelper.CreateDatabase<BaseCircuitBreaker>();
    //
    //     sqliteHelper.DeleteTable<BaseFeeder>();
    //     sqliteHelper.CreateDatabase<BaseFeeder>();
    //
    //     sqliteHelper.DeleteTable<BaseBusbar>();
    //     sqliteHelper.CreateDatabase<BaseBusbar>();
    //
    //     sqliteHelper.DeleteTable<BaseElectricalPanel>();
    //     sqliteHelper.CreateDatabase<BaseElectricalPanel>();
    //
    //     // Assert
    // }
}