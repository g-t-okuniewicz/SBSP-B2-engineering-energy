using NUnit.Framework;

public class TemperatureTest
{
    [Test]
    public void NewEnergyConsumerTest()
    {
        string name = "Missiles";
        float baseConsumption = 3.0f;
        float heatFactor = 1.0f;
        EnergyConsumer consumer = new EnergyConsumer(name, baseConsumption, heatFactor);

        Assert.AreEqual(name, consumer.Name);
        Assert.AreEqual(baseConsumption, consumer.BaseEnergyDemand);
    }

    [Test]
    public void TemperatureTestMaxHeat()
    {
        // Arrange Max heat is 2.0f
        string name = "Missiles";
        float baseConsumption = 3.0f;
        float heatFactor = 2.0f;

        //Sets consumer
        EnergyConsumer maxHeatConsumer = new EnergyConsumer(name, baseConsumption, heatFactor);

        // Assert
        Assert.AreEqual(heatFactor, maxHeatConsumer.MaxEnergyDemand);
    }

    [Test]
    public void TemperatureTestOverMaxHeat()
    {
        // Arrange Max heat is 2.0f
        string name = "Missiles";
        float baseConsumption = 3.0f;
        float heatFactor = 3.0f;

        //Sets consumer
        EnergyConsumer maxOverHeatConsumer = new EnergyConsumer(name, baseConsumption, heatFactor);

        // Assert
        Assert.AreNotEqual(heatFactor, maxOverHeatConsumer.MaxEnergyDemand);
    }
}
