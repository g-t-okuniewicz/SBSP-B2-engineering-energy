using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using NUnit.Framework;

[TestFixture]
public class EnergyConsumerTest
{
    [Test]
    public void NewEnergyConsumerSetsNameAndBaseEnergyConsumptionTest()
    {
        string name = "Missiles";
        float baseConsumption = 3.0f;
		float heatFactor = 1.0f;
		EnergyConsumer consumer = new EnergyConsumer(name, baseConsumption, heatFactor);

        Assert.AreEqual(name, consumer.Name);
        Assert.AreEqual(baseConsumption, consumer.BaseEnergyDemand);
    }

    [Test]
    public void NewEnergyConsumerEnergyConsumptionIsEqualToBaseTest()
    {
        string name = "Missiles";
        float baseConsumption = 3.0f;
		float heatFactor = 1.0f;
		EnergyConsumer consumer = new EnergyConsumer(name, baseConsumption, heatFactor);

        Assert.AreEqual(baseConsumption, consumer.CurrentEnergyDemand);
    }

    [Test]
    public void EqualsWithNonEnergyConsumerObjectReturnsFalseTest()
    {
        string name = "Missiles";
        float baseConsumption = 3.0f;
		float heatFactor = 1.0f;
		EnergyConsumer consumer = new EnergyConsumer(name, baseConsumption, heatFactor);
        EnergyStorage other = new EnergyStorage();

        Assert.IsFalse(consumer.Equals(other));
    }

    [Test]
    public void EqualsWithDifferentEnergyConsumerReturnsFalseTest()
    {
        string name = "Missiles";
        float baseConsumption = 3.0f;
		float heatFactor = 1.0f;
		EnergyConsumer consumer = new EnergyConsumer(name, baseConsumption, heatFactor);

        string otherName = "Beam";
        float otherBaseConsumption = 1.0f;
		float otherHeatFactor = 0.5f;
		EnergyConsumer otherConsumer = new EnergyConsumer(otherName, otherBaseConsumption, otherHeatFactor);

        Assert.IsFalse(consumer.Equals(otherConsumer));
    }

    [Test]
    public void EqualsWithSelfReturnsTrueTest()
    {
        string name = "Missiles";
        float baseConsumption = 3.0f;
		float heatFactor = 1.0f;
		EnergyConsumer consumer = new EnergyConsumer(name, baseConsumption, heatFactor);

        Assert.IsTrue(consumer.Equals(consumer));
    }
    
    [Test]
    public void EqualsWithEquivalentEnergyConsumerReturnsTrueTest()
    {
        string name = "Missiles";
        float baseConsumption = 3.0f;
		float heatFactor = 1.0f;
		EnergyConsumer consumer = new EnergyConsumer(name, baseConsumption, heatFactor);
		EnergyConsumer otherConsumer = new EnergyConsumer(name, baseConsumption, heatFactor);

        Assert.IsTrue(consumer.Equals(otherConsumer));
    }

    [Test]
    public void GetHashCodeDifferentForDifferentEnergyConsumersTest()
    {
        string name = "Missiles";
        float baseConsumption = 3.0f;
		float heatFactor = 1.5f;
		EnergyConsumer consumer = new EnergyConsumer(name, baseConsumption, heatFactor);

        string otherName = "Beam";
        float otherBaseConsumption = 1.0f;
		float otherHeatFactor = 0.5f;
		EnergyConsumer otherConsumer = new EnergyConsumer(otherName, otherBaseConsumption, otherHeatFactor);

        Assert.AreNotEqual(consumer.GetHashCode(), otherConsumer.GetHashCode());
    }

    [Test]
    public void GetHashCodeSameForEquivalentEnergyConsumersTest()
    {
        string name = "Missiles";
        float baseConsumption = 3.0f;
		float heatFactor = 1.0f;
		EnergyConsumer consumer = new EnergyConsumer(name, baseConsumption, heatFactor);
		EnergyConsumer otherConsumer = new EnergyConsumer(name, baseConsumption, heatFactor);

        Assert.AreEqual(consumer.GetHashCode(), otherConsumer.GetHashCode());
    }
}
