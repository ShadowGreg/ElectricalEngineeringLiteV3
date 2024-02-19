using ElectricalEngineering.Domain.Contrlollers.ElectricalPanel;
using ElectricalEngineering.Domain.Feeder;

namespace BackendTests;

[TestFixture]
public class NodeTests {
    // https://help.autodesk.com/view/OARX/2021/ENU/?guid=GUID-EA9CDD11-19D1-4EBC-9F56-979ACF679E3C
    [SetUp]
    public void Setup() {
        _electricalPanelFillController = new ElectricalPanelFillController();
    }

    private List<BaseConsumer> _consumers;
    private ElectricalPanelFillController _electricalPanelFillController;
   
}