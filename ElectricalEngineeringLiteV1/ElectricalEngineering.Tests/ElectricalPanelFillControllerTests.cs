using ElectricalEngineering.Domain.Contrlollers.ElectricalPanel;
using ElectricalEngineering.Domain.Feeder;

namespace BackendTests;

[TestFixture]
public class ElectricalPanelFillControllerTests {
    [SetUp]
    public void Setup() {
        _electricalPanelFillController = new ElectricalPanelFillController();
    }

    private List<BaseConsumer> _consumers;
    private ElectricalPanelFillController _electricalPanelFillController;

    [Test]
    public void ElectricalPanelFillController_Test() {
        // Arrange
        _electricalPanelFillController.AddOnPanel(new List<BaseConsumer> {
            new BaseConsumer()
        });

        // Act
        var actualPanel = _electricalPanelFillController.GetPanel();

        // Assert
        Assert.NotNull(actualPanel);
    }

    [Test]
    public void Controller_Test_For_A_Specific_Value() {
        // Arrange
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
        });

        // Act
        var actualPanel = _electricalPanelFillController.GetPanel();

        // Assert
        Assert.NotNull(actualPanel);
    }
}