using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

public class CoolantModelTest
{
    [Test]
    public void NewCoolantModelHasBlankTypeTest()
    {
        CoolantModel model = new CoolantModel();
        string expected = "";
        Assert.AreEqual(expected, model.GetCoolantType());
    }

    [Test]
    public void NewCoolantWithTypeShouldHaveThatTypeTest()
    {
        string type = "test-type";
        CoolantModel model = new CoolantModel(type);
        Assert.AreEqual(type, model.GetCoolantType());
    }

    [Test]
    public void SetCoolantTypeShouldSetCoolantTypeTest()
    {
        string type1 = "test-type-1",
            type2 = "test-type-2";
        CoolantModel model = new CoolantModel(type1);
        model.SetCoolantType(type2);
        Assert.AreEqual(type2, model.GetCoolantType());
    }
}
