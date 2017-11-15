using NUnit.Framework;

public class EnergyTest
{
    [Test]
    public void EnergyTestGetEnergyType()
    {
        Energy energy = new Energy();

        // Use the Assert class to test conditions.
        string energyType = null;

        string actualEnergy = energy.GetEnergyType();

        Assert.AreEqual(actualEnergy, energyType);
    }

    [Test]
    public void EnergyTestSetEnergyType()
    {
        Energy energy = new Energy();

        string testType = "Plasma";

        energy.SetEnergyType(testType);

        Assert.AreEqual(testType, energy.GetEnergyType());
    }

    [Test]
    public void EnergyTestGetEnergyUnit()
    {
        Energy energy = new Energy();

        // Use the Assert class to test conditions.
        int energyUnit = 0;

        int actualEnergyUnit = energy.GetEnergyUnit();

        Assert.AreEqual(energyUnit, actualEnergyUnit);
    }

    [Test]
    public void EnergyTestSetEnergyUnit()
    {
        Energy energy = new Energy();

        int testUnit=0;

        energy.SetEnergyUnit(testUnit);

        Assert.AreEqual(testUnit, energy.GetEnergyUnit());
    }

    [Test]
    public void EnergyTestGetEnergyQuantity()
    {
        Energy energy = new Energy();

        // Use the Assert class to test conditions.
        int testQuantity = 0;

        int actualEnergyQuantity = energy.GetEnergyQuantity();

        Assert.AreEqual(testQuantity, actualEnergyQuantity);
    }

    [Test]
    public void EnergyTestSetEnergyQuantity()
    {
        Energy energy = new Energy();

        int testQuantity = 0;

        energy.SetEnergyQuantity(testQuantity);

        Assert.AreEqual(testQuantity, energy.GetEnergyQuantity());
    }
}
