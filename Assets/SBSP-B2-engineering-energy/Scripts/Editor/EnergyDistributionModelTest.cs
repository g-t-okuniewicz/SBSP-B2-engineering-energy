using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class EnergyDistributionModelTest
{
    [Test]
    public void NewEnergyDistributionModelContainsListOfExpectedEnergyConsumersTest()
    {
        EnergyDistributionModel edm = new EnergyDistributionModel();

        // should not be null 
        Assert.NotNull(edm.Consumers);

        // should not be empty 
        Assert.False(edm.Consumers.Count == 0);

        // should contain the expected energy consumers 
        List<EnergyConsumer> expected = new List<EnergyConsumer>(new EnergyConsumer[] {
            new EnergyConsumer("Beam", 1.0f),
            new EnergyConsumer("Missiles", 3.0f),
            new EnergyConsumer("Headlights", 0.3f)
        });

        CollectionAssert.AreEqual(expected, edm.Consumers);
    }
}
