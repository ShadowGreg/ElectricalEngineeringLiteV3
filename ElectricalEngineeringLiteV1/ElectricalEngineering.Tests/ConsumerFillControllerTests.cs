namespace BackendTests;

[TestFixture]
public class ConsumerFillControllerTests {
    // [SetUp]
    // public void Setup() {
    //     _consumers = new DataBase.DataBase().GetConsumers();
    //     _consumerFillController = new ConsumerFillController();
    // }
    //
    // private List<BaseConsumer> _consumers;
    // private ConsumerFillController _consumerFillController;
    //
    // [Test]
    // public void Retrieved_All_Consumers_From_The_Database_Test() {
    //     // Arrange
    //     List<BaseConsumer> result = _consumers;
    //     // Act
    //
    //     // Assert
    //     Assert.NotNull(result);
    // }
    //
    // [Test]
    // public void Normal_Filling_Of_Consumer_Fields() {
    //     // Arrange
    //     List<BaseConsumer> nonСalculatedСonsumers = _consumers;
    //
    //     // Act
    //     List<BaseConsumer> сalculatedСonsumers = _consumers;
    //     foreach (var consumer in сalculatedСonsumers) _consumerFillController.FillConsumerFields(consumer);
    //
    //     // Assert
    //     Assert.AreEqual(nonСalculatedСonsumers[0].TanPowerFactor, сalculatedСonsumers[0].TanPowerFactor);
    // }
    //
    // [Test]
    // public void Design_Current_Value_Test() {
    //     // Arrange
    //     List<BaseConsumer> consumers = _consumers;
    //     double expected = 15.520168526602843d;
    //
    //     // Act
    //
    //     foreach (var consumer in consumers) _consumerFillController.FillConsumerFields(consumer);
    //
    //     double actual = consumers[0].RatedCurrent;
    //
    //     // Assert
    //     Assert.AreEqual(expected, actual);
    // }
    //
    // [Test]
    // public void Different_Design_Current_Values_When_Changing_The_Number_Of_Phases_Test() {
    //     // Arrange
    //     List<BaseConsumer> consumers = _consumers;
    //     double expected = 31.414647000023759d;
    //
    //     // Act
    //
    //     foreach (var consumer in consumers) _consumerFillController.FillConsumerFields(consumer);
    //
    //     consumers[0].Voltage = 230;
    //     _consumerFillController.FillConsumerFields(consumers[0]);
    //     double actual = consumers[0].RatedCurrent;
    //
    //     // Assert
    //     Assert.AreNotEqual(expected, actual);
    // }
    //
    // [Test]
    // public void Changing_The_Grounding_System_And_Error_Bars_Test() {
    //     // Arrange
    //     List<BaseConsumer> consumers = _consumers;
    //     double expected = 31.414647000023759d;
    //
    //     // Act
    //     foreach (var consumer in consumers) _consumerFillController.FillConsumerFields(consumer);
    //
    //     consumers[0].TypeGroundingSystem = "IT";
    //
    //     // Assert
    //     Assert.Throws<FormatException>(() => _consumerFillController.FillConsumerFields(consumers[0]));
    // }
}