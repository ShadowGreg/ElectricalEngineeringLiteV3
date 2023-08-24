using System.Collections.Generic;
using BillingFillingController.Contrlollers.ElectricalPanel;
using CoreV01.Feeder;
using CoreV01.Properties;
using DataBase;
using DataBaseL02;
using DataBaseSL01;
using NUnit.Framework;

namespace BackendTests {
    [TestFixture]
    public class DbTests {
        private ElectricalPanelFillController _electricalPanelFillController;

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

        [Test]
        public void Controller_Test_For_A_Specific_Value() {
            // Arrange
            string databaseFile = "../../database.sav";
            var sqliteHelper = new SqLiteHelper(databaseFile);


            // Act
            sqliteHelper.DeleteTable<BaseConsumer>();
            sqliteHelper.CreateDatabase<BaseConsumer>();
            
            sqliteHelper.DeleteTable<BaseCable>();
            sqliteHelper.CreateDatabase<BaseCable>();
            
            sqliteHelper.DeleteTable<BaseCircuitBreaker>();
            sqliteHelper.CreateDatabase<BaseCircuitBreaker>();
            
            sqliteHelper.DeleteTable<BaseFeeder>();
            sqliteHelper.CreateDatabase<BaseFeeder>();
            
            sqliteHelper.DeleteTable<BaseBusbar>();
            sqliteHelper.CreateDatabase<BaseBusbar>();
            
            sqliteHelper.DeleteTable<BaseElectricalPanel>();
            sqliteHelper.CreateDatabase<BaseElectricalPanel>();

            // Assert
            // Assert.NotNull(actualPanel);
        }
    }
}