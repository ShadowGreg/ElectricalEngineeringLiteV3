using ElectricalEngineering.Domain.Feeder;
using ElectricalEngineering.DomainServices.Contrlollers.ElectricalPanel;

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