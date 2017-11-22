using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

public class CoolantPumpModelTest
{
    [Test]
    public void NoArgumentConstructorInitializationTest()
    {
        CoolantPumpModel cpm = new CoolantPumpModel();
        Assert.AreEqual("", cpm.GetPumpType());
        Assert.AreEqual(0.0f, cpm.GetDeliverySpeed());
        Assert.AreEqual(0.0f, cpm.GetDeliverySpeedMultiplier());
    }

    [Test]
    public void ConstructorSetsAllValuesTest()
    {
        string pumpType = "test-pump-type";
        float deliverySpeed = 2.5f,
            deliverySpeedMultiplier = 1.3f;
        CoolantPumpModel cpm = new CoolantPumpModel(pumpType, deliverySpeed, deliverySpeedMultiplier);
        Assert.AreEqual(pumpType, cpm.GetPumpType());
        Assert.AreEqual(deliverySpeed, cpm.GetDeliverySpeed());
        Assert.AreEqual(deliverySpeedMultiplier, cpm.GetDeliverySpeedMultiplier());
    }

    [Test]
    public void SetPumpTypeSetPumpTypeTest()
    {
        string pumpType1 = "test-pump-type-1", 
            pumpType2 = "test-pump-type-2";
        float deliverySpeed = 2.5f,
            deliverySpeedMultiplier = 1.3f;
        CoolantPumpModel cpm = new CoolantPumpModel(pumpType1, deliverySpeed, deliverySpeedMultiplier);
        cpm.SetPumpType(pumpType2);
        Assert.AreEqual(pumpType2, cpm.GetPumpType());
    }

    [Test]
    public void SetDeliverySpeedSetsDeliverySpeedTest()
    {
        string pumpType = "test-pump-type";
        float deliverySpeed1 = 2.5f,
            deliverySpeed2 = 3.5f,
            deliverySpeedMultiplier = 1.3f;
        CoolantPumpModel cpm = new CoolantPumpModel(pumpType, deliverySpeed1, deliverySpeedMultiplier);
        cpm.SetDeliverySpeed(deliverySpeed2);
        Assert.AreEqual(deliverySpeed2, cpm.GetDeliverySpeed());
    }

    [Test]
    public void SetDeliverySpeedMultiplierSetsDeliverySpeedMultiplierTest()
    {
        string pumpType = "test-pump-type";
        float deliverySpeed = 2.5f,
            deliverySpeedMultiplier1 = 1.3f,
            deliverySpeedMultiplier2 = 0.75f;
        CoolantPumpModel cpm = new CoolantPumpModel(pumpType, deliverySpeed, deliverySpeedMultiplier1);
        cpm.SetDeliverySpeedMultiplier(deliverySpeedMultiplier2);
        Assert.AreEqual(deliverySpeedMultiplier2, cpm.GetDeliverySpeedMultiplier());
    }
}
