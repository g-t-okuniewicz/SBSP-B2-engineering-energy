using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

public class CoolantViewTest
{
	/*-=-=-=-=-=-=-=-=-=-=-=-=-
    [Test]
    public void NoArgConstructorInitTest()
    {
        CoolantView view = new CoolantView();
        Assert.AreEqual("", view.GetCoolantType());
        Assert.AreEqual(0.0f, view.GetCoolantAmount());
        Assert.AreEqual(0.0f, view.GetStorageCapacity());
        Assert.AreEqual(false, view.GetStorageEmpty());
        Assert.AreEqual(false, view.GetStorageAtMax());
        Assert.AreEqual("", view.GetPumpType());
        Assert.AreEqual(false, view.GetCoolantReady());
    }

    [Test]
    public void ArgConstructorInitTest()
    {
        string type = "test-type",
            pumpType = "test-pump-type";
        float amount = 4.2f,
            capacity = 19.0f;
        bool empty = false,
            atMax = false,
            ready = true;
        CoolantView view = new CoolantView(type, amount, capacity, atMax, pumpType, ready, empty);
        Assert.AreEqual(type, view.GetCoolantType());
        Assert.AreEqual(amount, view.GetCoolantAmount());
        Assert.AreEqual(capacity, view.GetStorageCapacity());
        Assert.AreEqual(empty, view.GetStorageEmpty());
        Assert.AreEqual(atMax, view.GetStorageAtMax());
        Assert.AreEqual(pumpType, view.GetPumpType());
        Assert.AreEqual(ready, view.GetCoolantReady());
    }

    [Test]
    public void SetCoolantTypeTest()
    {
        string type1 = "test-type-1",
            type2 = "test-type-2",
            pumpType = "test-pump-type";
        float amount = 4.2f,
            capacity = 19.0f;
        bool empty = false,
            atMax = false,
            ready = true;
        CoolantView view = new CoolantView(type1, amount, capacity, atMax, pumpType, ready, empty);
        view.SetCoolantType(type2);
        Assert.AreEqual(type2, view.GetCoolantType());
    }

    [Test]
    public void SetCoolantAmountTest()
    {
        string type = "test-type",
            pumpType = "test-pump-type";
        float amount1 = 4.2f,
            amount2 = 7.3f,
            capacity = 19.0f;
        bool empty = false,
            atMax = false,
            ready = true;
        CoolantView view = new CoolantView(type, amount1, capacity, atMax, pumpType, ready, empty);
        view.SetCoolantAmount(amount2);
        Assert.AreEqual(amount2, view.GetCoolantAmount());
    }

    [Test]
    public void SetStorageCapacityTest()
    {
        string type = "test-type",
            pumpType = "test-pump-type";
        float amount = 4.2f,
            capacity1 = 19.0f,
            capacity2 = 15.0f;
        bool empty = false,
            atMax = false,
            ready = true;
        CoolantView view = new CoolantView(type, amount, capacity1, atMax, pumpType, ready, empty);
        view.SetStorageCapacity(capacity2);
        Assert.AreEqual(capacity2, view.GetStorageCapacity());
    }

    [Test]
    public void SetStorageEmptyTest()
    {
        string type = "test-type",
            pumpType = "test-pump-type";
        float amount = 4.2f,
            capacity = 19.0f;
        bool empty1 = false,
            empty2 = true,
            atMax = false,
            ready = true;
        CoolantView view = new CoolantView(type, amount, capacity, atMax, pumpType, ready, empty1);
        view.SetStorageEmpty(empty2);
        Assert.AreEqual(empty2, view.GetStorageEmpty());
    }

	-=-=-=-=-=-=-=-=-=-=-=-=-*/
}
