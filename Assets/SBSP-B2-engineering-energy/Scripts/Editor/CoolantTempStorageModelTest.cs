using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class CoolantTempStorageModelTest
{
	/*-=-=-=-=-=-=-=-=-=-=-=-=-
    [Test]
    public void NoArgConstructorInitializationTest()
    {
        CoolantTempStorageModel ctsm = new CoolantTempStorageModel();
        Assert.AreEqual("", ctsm.GetCoolantType());
        Assert.AreEqual(0.0f, ctsm.GetAvailableCoolant());
        Assert.AreEqual(0.0f, ctsm.GetMinimumStorage());
        Assert.AreEqual(0.0f, ctsm.GetStorageMaxCapacity());
        Assert.AreEqual(false, ctsm.GetStorageAtMaxCapacity());
        Assert.AreEqual(false, ctsm.GetStorageEmpty());
    }

    [Test]
    public void ConstructorWithArgsIntializationTest()
    {
        string type = "test-type";
        float available = 5.0f,
            minStorage = 3.0f,
            maxStorage = 20.0f;
        bool atMax = false,
            empty = false;
        CoolantTempStorageModel ctsm = new CoolantTempStorageModel(type, available, minStorage, maxStorage, atMax, empty);
        Assert.AreEqual(type, ctsm.GetCoolantType());
        Assert.AreEqual(available, ctsm.GetAvailableCoolant());
        Assert.AreEqual(minStorage, ctsm.GetMinimumStorage());
        Assert.AreEqual(maxStorage, ctsm.GetStorageMaxCapacity());
        Assert.AreEqual(atMax, ctsm.GetStorageAtMaxCapacity());
        Assert.AreEqual(empty, ctsm.GetStorageEmpty());
    }

    [Test]
    public void SetCoolantTypeTest()
    {
        string type1 = "test-type-1",
            type2 = "test-type-2";
        float available = 5.0f,
            minStorage = 3.0f,
            maxStorage = 20.0f;
        bool atMax = false,
            empty = false;
        CoolantTempStorageModel ctsm = new CoolantTempStorageModel(type1, available, minStorage, maxStorage, atMax, empty);
        ctsm.SetCoolantType(type2);
        Assert.AreEqual(type2, ctsm.GetCoolantType());
    }

    [Test]
    public void SetAvailableCoolantTest()
    {
        string type = "test-type";
        float available1 = 5.0f,
            available2 = 4.4f,
            minStorage = 3.0f,
            maxStorage = 20.0f;
        bool atMax = false,
            empty = false;
        CoolantTempStorageModel ctsm = new CoolantTempStorageModel(type, available1, minStorage, maxStorage, atMax, empty);
        ctsm.SetAvailableCoolant(available2);
        Assert.AreEqual(available2, ctsm.GetAvailableCoolant());
    }

    [Test]
    public void SetMinimumStorageTest()
    {
        string type = "test-type";
        float available = 5.0f,
            minStorage1 = 3.0f,
            minStorage2 = 1.0f,
            maxStorage = 20.0f;
        bool atMax = false,
            empty = false;
        CoolantTempStorageModel ctsm = new CoolantTempStorageModel(type, available, minStorage1, maxStorage, atMax, empty);
        ctsm.SetMinimumStorage(minStorage2);
        Assert.AreEqual(minStorage2, ctsm.GetMinimumStorage());
    }

    [Test]
    public void SetStorageMaxCapacityTest()
    {
        string type = "test-type";
        float available = 5.0f,
            minStorage = 3.0f,
            maxStorage1 = 20.0f,
            maxStorage2 = 33.3f;
        bool atMax = false,
            empty = false;
        CoolantTempStorageModel ctsm = new CoolantTempStorageModel(type, available, minStorage, maxStorage1, atMax, empty);
        ctsm.SetStorageMaxCapacity(maxStorage2);
        Assert.AreEqual(maxStorage2, ctsm.GetStorageMaxCapacity());
    }

    [Test]
    public void SetStorageAtMaxCapacityTest()
    {
        string type = "test-type";
        float available = 5.0f,
            minStorage = 3.0f,
            maxStorage = 20.0f;
        bool atMax1 = false,
            atMax2 = true,
            empty = false;
        CoolantTempStorageModel ctsm = new CoolantTempStorageModel(type, available, minStorage, maxStorage, atMax1, empty);
        ctsm.SetStorageAtMaxCapacity(atMax2);
        Assert.AreEqual(atMax2, ctsm.GetStorageAtMaxCapacity());
    }

    [Test]
    public void SetStorageEmptyTest()
    {
        string type = "test-type";
        float available = 5.0f,
            minStorage = 3.0f,
            maxStorage = 20.0f;
        bool atMax = false,
            empty1 = false,
            empty2 = true;
        CoolantTempStorageModel ctsm = new CoolantTempStorageModel(type, available, minStorage, maxStorage, atMax, empty1);
        ctsm.SetStorageEmpty(empty2);
        Assert.AreEqual(empty2, ctsm.GetStorageEmpty());
    }
    -=-=-=-=-=-=-=-=-=-=-=-=-*/
}
