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
        EnergyConsumer consumer = new EnergyConsumer(name, baseConsumption);

        Assert.AreEqual(name, consumer.Name);
        Assert.AreEqual(baseConsumption, consumer.BaseEnergyConsumption);
    }

    [Test]
    public void NewEnergyConsumerEnergyConsumptionIsEqualToBaseTest()
    {
        string name = "Missiles";
        float baseConsumption = 3.0f;
        EnergyConsumer consumer = new EnergyConsumer(name, baseConsumption);

        Assert.AreEqual(baseConsumption, consumer.EnergyConsumption);
    }

    [Test]
    public void EqualsWithNonEnergyConsumerObjectReturnsFalseTest()
    {
        string name = "Missiles";
        float baseConsumption = 3.0f;
        EnergyConsumer consumer = new EnergyConsumer(name, baseConsumption);
        EnergyStorage other = new EnergyStorage();

        Assert.IsFalse(consumer.Equals(other));
    }

    [Test]
    public void EqualsWithDifferentEnergyConsumerReturnsFalseTest()
    {
        string name = "Missiles";
        float baseConsumption = 3.0f;
        EnergyConsumer consumer = new EnergyConsumer(name, baseConsumption);

        string otherName = "Beam";
        float otherBaseConsumption = 1.0f;
        EnergyConsumer otherConsumer = new EnergyConsumer(otherName, otherBaseConsumption);

        Assert.IsFalse(consumer.Equals(otherConsumer));
    }

    [Test]
    public void EqualsWithSelfReturnsTrueTest()
    {
        string name = "Missiles";
        float baseConsumption = 3.0f;
        EnergyConsumer consumer = new EnergyConsumer(name, baseConsumption);

        Assert.IsTrue(consumer.Equals(consumer));
    }
    
    [Test]
    public void EqualsWithEquivalentEnergyConsumerReturnsTrueTest()
    {
        string name = "Missiles";
        float baseConsumption = 3.0f;
        EnergyConsumer consumer = new EnergyConsumer(name, baseConsumption);
        EnergyConsumer otherConsumer = new EnergyConsumer(name, baseConsumption);

        Assert.IsTrue(consumer.Equals(otherConsumer));
    }

    [Test]
    public void GetHashCodeDifferentForDifferentEnergyConsumersTest()
    {
        string name = "Missiles";
        float baseConsumption = 3.0f;
        EnergyConsumer consumer = new EnergyConsumer(name, baseConsumption);

        string otherName = "Beam";
        float otherBaseConsumption = 1.0f;
        EnergyConsumer otherConsumer = new EnergyConsumer(otherName, otherBaseConsumption);

        Assert.AreNotEqual(consumer.GetHashCode(), otherConsumer.GetHashCode());
    }

    [Test]
    public void GetHashCodeSameForEquivalentEnergyConsumersTest()
    {
        string name = "Missiles";
        float baseConsumption = 3.0f;
        EnergyConsumer consumer = new EnergyConsumer(name, baseConsumption);
        EnergyConsumer otherConsumer = new EnergyConsumer(name, baseConsumption);

        Assert.AreEqual(consumer.GetHashCode(), otherConsumer.GetHashCode());
    }
}
