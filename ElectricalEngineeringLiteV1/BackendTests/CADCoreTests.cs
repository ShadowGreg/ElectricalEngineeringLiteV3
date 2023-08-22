﻿using System.Collections.Generic;
using BillingFillingController.Contrlollers.ElectricalPanel;
using CADCore;
using CoreV01.Feeder;
using netDxf;
using NUnit.Framework;

namespace BackendTests {
    [TestFixture]
    public class CADCoreTests {
        private DXFController _dxfController;

        [SetUp]
        public void Setup() {
            _dxfController = new DXFController();
        }

        [Test]
        public void ElectricalPanelFillController_Test() {
            // Arrange


            // Act
            _dxfController.DrawDiagramFrame(new Vector2(0, 0));

            // Assert
        }

        [Test]
        public void DrawIntroductoryUnit_Test() {
            // Arrange
            ElectricalPanelFillController electricalPanelFillController = new ElectricalPanelFillController();
            BaseConsumer consumer = new BaseConsumer();

            // Act
            electricalPanelFillController.AddOnPanel(new List<BaseConsumer>() { consumer });
            var circuitBreaker = electricalPanelFillController.GetPanel().BusBars[0].InputSwitch;
            var electricalPanel = electricalPanelFillController.GetPanel();
            _dxfController.DrawIntroductoryUnit(new Vector2(0, 0), circuitBreaker, electricalPanel);

            // Assert
        }

        [Test]
        public void DrawIntroductoryUnit_With_Distance_Test() {
            // Arrange
            ElectricalPanelFillController electricalPanelFillController = new ElectricalPanelFillController();
            BaseConsumer consumer = new BaseConsumer();

            // Act
            electricalPanelFillController.AddOnPanel(new List<BaseConsumer>() { consumer });
            var circuitBreaker = electricalPanelFillController.GetPanel().BusBars[0].InputSwitch;
            var electricalPanel = electricalPanelFillController.GetPanel();
            _dxfController.DrawIntroductoryUnit(new Vector2(150, -300), circuitBreaker, electricalPanel);

            // Assert
        }

        [Test]
        public void DrawUnit_Test() {
            // Arrange
            ElectricalPanelFillController electricalPanelFillController = new ElectricalPanelFillController();
            BaseConsumer consumer = new BaseConsumer();

            // Act
            electricalPanelFillController.AddOnPanel(new List<BaseConsumer>()
                { consumer, consumer, consumer, consumer, consumer, consumer, consumer, });
            var feeder = electricalPanelFillController.GetPanel().BusBars[0].Feeders[3];

            _dxfController.DrawUnit(new Vector2(150, -300), feeder);

            // Assert
        }

        [Test]
        public void DrawUnits_Test() {
            // Arrange
            ElectricalPanelFillController electricalPanelFillController = new ElectricalPanelFillController();
            BaseConsumer consumer = new BaseConsumer();

            // Act
            electricalPanelFillController.AddOnPanel(new List<BaseConsumer>()
                { consumer, consumer, consumer, consumer, consumer, consumer, consumer, });
            var feeders = electricalPanelFillController.GetPanel().BusBars[0].Feeders;

            _dxfController.DrawUnits(new Vector2(150, -300), feeders);

            // Assert
        }

        [Test]
        public void DrawPanel_Test() {
            // Arrange
            ElectricalPanelFillController electricalPanelFillController = new ElectricalPanelFillController();
            BaseConsumer consumer = new BaseConsumer();

            // Act
            electricalPanelFillController.AddOnPanel(new List<BaseConsumer>()
                { consumer, consumer, consumer, consumer, consumer, consumer, consumer, });
            var panel = electricalPanelFillController.GetPanel();

            _dxfController.DrawPanel(panel, "sample.dxf");

            // Assert
        }
    }
}