using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

namespace energyStorageTest
{
    [TestFixture]
    public class TestEnergyStorage
    {
        [Test]
        public void test1_GetCurrentCapacity()
        {
            //Arrange
            EnergyStorage e = new EnergyStorage();
            int expectedResult = 0;

            //Act
            int result = e.GetCurrentCapacity();

            //Assert
            Assert.AreEqual(result,expectedResult);
        }

        [Test]
        public void test2_SetCurrentCapacity()
        {
            //Arrange
            EnergyStorage e = new EnergyStorage();
            int cap = 10;
            int expectedResult = 10;
           
            //Act
            e.SetCurrentCapacity(cap);
            int result = e.GetCurrentCapacity();
        
            //Assert
            Assert.AreEqual(result,expectedResult);
        }

        [Test]
        public void test3_GetMaxCapacity()
        {
            //Arrange
            EnergyStorage e = new EnergyStorage();
            bool expectedResult = false;

            //Act
            bool result = e.GetMaxCapacityReached();

            //Assert
            Assert.AreEqual(result,expectedResult);
        }

        [Test]
        public void test4_SetMaxCapacity()
        {
            //Arrange
            EnergyStorage e = new EnergyStorage();
            bool cap = true;
            bool expectedResult = true;

            //Act
            e.SetMaxCapacityReached(cap);
            bool result = e.GetMaxCapacityReached();

            //Assert
            Assert.AreEqual(result,expectedResult);
        }

        [Test]
        public void test5_GetOkToDistribute()
        {
            //Arrange
            EnergyStorage e = new EnergyStorage();
            bool expectedResult = false;

            //Act
            bool result = e.GetOkToDistribute();

            //Assert
            Assert.AreEqual(result,expectedResult);
        }

        [Test]
        public void test6_SetOkToDistribute()
        {
            //Arrange
            EnergyStorage e = new EnergyStorage();
            bool dist = true;
            bool expectedResult = true;

            //Act
            e.SetOkToDistribute(dist);
            bool result = e.GetOkToDistribute();

            //Assert
            Assert.AreEqual(result, expectedResult);
        }

        [Test]
        public void test7_GetStorageType()
        {
            //Arange
            EnergyStorage e = new EnergyStorage(); 
            string expectedResult = "";

            //Act
            string result = e.GetStrorageType();

            //Assert
            Assert.AreEqual(result, expectedResult);
        }

        [Test]
        public void test8_SetStorageType()
        {
            //Arange
            EnergyStorage e = new EnergyStorage();
            string plasma = "plasma";
            string expectedResult = "plasma";

            //Act
            e.SetStorageType(plasma);
            string result = e.GetStrorageType();

            //Assert
            Assert.AreEqual(result, expectedResult);
        }
    }
}