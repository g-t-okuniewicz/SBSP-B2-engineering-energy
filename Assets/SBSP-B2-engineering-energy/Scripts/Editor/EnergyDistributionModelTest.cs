using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using System;

[TestFixture]
public class EnergyDistributionModelTest
{
    [Test]
    public void NewEnergyDistributionModelHasNoConsumersTest()
    {
        EnergyDistributionModel edm = new EnergyDistributionModel();
        Assert.IsEmpty(edm.Consumers);
    }

    [Test]
    public void AddEnergyConsumerAddsExpectedEnergyConsumersTest()
    {
        EnergyDistributionModel edm = new EnergyDistributionModel();
        EnergyConsumer consumer = new EnergyConsumer("Missiles", 3.0f, 0.75f);
        edm.AddEnergyConsumer(consumer);

        List<EnergyConsumer> consumers = edm.Consumers;

        Assert.NotNull(consumers);
        Assert.AreEqual(1, consumers.Count);
        Assert.AreEqual(consumer, consumers[0]);

        EnergyConsumer consumer2 = new EnergyConsumer("Missiles", 3.0f, 0.75f),
            consumer3 = new EnergyConsumer("Headlights", 0.3f, 1.5f);
        edm.AddEnergyConsumer(consumer2);
        edm.AddEnergyConsumer(consumer3);

        List<EnergyConsumer> expectedConsumers = new List<EnergyConsumer>();
        expectedConsumers.Add(consumer);
        expectedConsumers.Add(consumer2);
        expectedConsumers.Add(consumer3);
        consumers = edm.Consumers;

        CollectionAssert.AreEqual(expectedConsumers, consumers);
    }

    [Test]
    public void GetTotalEnergyDemandReturnsZeroWithNoConsumers()
    {
        EnergyDistributionModel edm = new EnergyDistributionModel();
        float expected = 0.0f;

        Assert.AreEqual(expected, edm.GetTotalEnergyDemand());
    }

    [Test]
    public void GetTotalEnergyDemandReturnsSumOfConsumersEnergyConsumptionTest()
    {
        EnergyDistributionModel edm = new EnergyDistributionModel();
        float ec1 = 1.0f, ec2 = 3.0f, ec3 = 0.3f;
        float sum = ec1 + ec2 + ec3;
        EnergyConsumer consumer1 = new EnergyConsumer("Beam", ec1, 1.0f),
            consumer2 = new EnergyConsumer("Missiles", ec2, 0.75f),
            consumer3 = new EnergyConsumer("Headlights", ec3, 1.5f);
        edm.AddEnergyConsumer(consumer1);
        edm.AddEnergyConsumer(consumer2);
        edm.AddEnergyConsumer(consumer3);

        Assert.AreEqual(sum, edm.GetTotalEnergyDemand());
    }

    [Test]
    public void UpdateModelDecresesEnergyStorageByTotalEnergyDemandTest()
    {
        EnergyDistributionModel edm = new EnergyDistributionModel();
        EnergyStorage storage = new EnergyStorage();
        storage.SetCurrentCapacity(storage.maxCapacity);
        edm.EnergyStorage = storage;
        float ec1 = 1.0f, ec2 = 3.0f, ec3 = 0.3f;
        float sum = ec1 + ec2 + ec3;
        EnergyConsumer consumer1 = new EnergyConsumer("Beam", ec1, 1.0f),
            consumer2 = new EnergyConsumer("Missiles", ec2, 0.75f),
            consumer3 = new EnergyConsumer("Headlights", ec3, 1.5f);
        edm.AddEnergyConsumer(consumer1);
        edm.AddEnergyConsumer(consumer2);
        edm.AddEnergyConsumer(consumer3);

        float initStorage = edm.GetEnergyStorageCurrentCapacity();
        float expected = initStorage - sum;

        edm.UpdateModel();

        Assert.AreEqual(expected, edm.GetEnergyStorageCurrentCapacity());
    }

    [Test]
    public void WithEnergyInStorageUpdateModelAdjustsConsumerHeatTest()
    {
        EnergyDistributionModel edm = new EnergyDistributionModel();
        EnergyStorage storage = new EnergyStorage();
        storage.SetCurrentCapacity(storage.maxCapacity);
        edm.EnergyStorage = storage;
        EnergyConsumer consumer1 = new EnergyConsumer("Beam", 1.0f, 1.0f),
            consumer2 = new EnergyConsumer("Missiles", 3.0f, 0.75f),
            consumer3 = new EnergyConsumer("Headlights", 0.3f, 1.5f),
            consumer4 = new EnergyConsumer("AC", 0.5f, 0.8f);
        consumer1.Heat = EnergyDistributionModel.MAX_HEAT + 5.0f;
        consumer2.Heat = 0.0f;
        consumer2.CurrentEnergyMultiplier = 1.5f;
        consumer3.Heat = 0.5f;
        consumer4.CurrentEnergyMultiplier = 0.5f;
        consumer4.Heat = -5.0f;
        edm.AddEnergyConsumer(consumer1);
        edm.AddEnergyConsumer(consumer2);
        edm.AddEnergyConsumer(consumer3);
        edm.AddEnergyConsumer(consumer4);
        List<EnergyConsumer> consumers = new List<EnergyConsumer>();
        consumers.Add(consumer1);
        consumers.Add(consumer2);
        consumers.Add(consumer3);
        consumers.Add(consumer4);

        float consumer1ExpectedHeat = EnergyDistributionModel.MAX_HEAT,
            consumer2ExpectedHeat = consumer2.Heat + (consumer2.CurrentEnergyMultiplier * consumer2.HeatFactor),
            consumer3ExpectedHeat = consumer3.Heat - ((1.0f - consumer3.CurrentEnergyMultiplier) * consumer3.HeatFactor),
            consumer4ExpectedHeat = 0.0f;

        edm.UpdateModel();

        consumers = edm.Consumers;
        consumer1 = consumers[0];
        consumer2 = consumers[1];
        consumer3 = consumers[2];
        consumer4 = consumers[3];

        Assert.AreEqual(consumer1ExpectedHeat, consumer1.Heat);
        Assert.AreEqual(consumer2ExpectedHeat, consumer2.Heat);
        Assert.AreEqual(consumer3ExpectedHeat, consumer3.Heat);
        Assert.AreEqual(consumer4ExpectedHeat, consumer4.Heat);
    }

    [Test]
    public void WithNoEnergyInStorageUpdateModelAdjustsConsumersTest()
    {
        EnergyDistributionModel edm = new EnergyDistributionModel();
        EnergyStorage storage = new EnergyStorage();
        storage.SetCurrentCapacity(0.0f);
        edm.EnergyStorage = storage;
        EnergyConsumer consumer1 = new EnergyConsumer("Beam", 1.0f, 1.0f),
            consumer2 = new EnergyConsumer("Missiles", 3.0f, 0.75f);
        consumer1.Heat = 5.0f;
        consumer2.Heat = 0.0f;
        consumer2.CurrentEnergyMultiplier = 1.5f;
        edm.AddEnergyConsumer(consumer1);
        edm.AddEnergyConsumer(consumer2);
        List<EnergyConsumer> consumers = new List<EnergyConsumer>();
        consumers.Add(consumer1);
        consumers.Add(consumer2);

        float consumer1ExpectedHeat = consumer1.Heat - consumer1.HeatFactor;
        float consumer2ExpectedHeat = 0.0f;
        float commonExpectedCurrentEnergyMultiplier = 0.0f;

        edm.UpdateModel();

        consumers = edm.Consumers;
        consumer1 = consumers[0];
        consumer2 = consumers[1];

        Assert.AreEqual(consumer1ExpectedHeat, consumer1.Heat);
        Assert.AreEqual(consumer2ExpectedHeat, consumer2.Heat);
        Assert.AreEqual(commonExpectedCurrentEnergyMultiplier, consumer1.CurrentEnergyMultiplier);
        Assert.AreEqual(commonExpectedCurrentEnergyMultiplier, consumer2.CurrentEnergyMultiplier);
    }
}
