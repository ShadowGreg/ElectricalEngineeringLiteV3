using System.Collections.Generic;
using BillingFillingController.Contrlollers.ElectricalPanel;
using CoreV01.Feeder;
using ElectricalEngineeringLiteV1.View.CenterFrame.DistributionNetworkTable;
using NUnit.Framework;

namespace BackendTests {
    [TestFixture]
    public class NodeTests {
        // https://help.autodesk.com/view/OARX/2021/ENU/?guid=GUID-EA9CDD11-19D1-4EBC-9F56-979ACF679E3C
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
            var node = new Node(_electricalPanelFillController.GetPanel());

            // Assert
            Assert.NotNull(node);
        }
    }
}