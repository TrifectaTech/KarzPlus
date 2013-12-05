// --------------------------------
// <copyright file="SpecialManagerTest.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>JOrtega</author>
// <summary>
//  Special Test Layer Object.   
// </summary>
// ---------------------------------

using System;
using KarzPlus.Business;
using KarzPlus.Entities;
using KarzPlus.Entities.ExtensionMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KarzPlus.Tests
{
    /// <summary>
    ///This is a test class for SpecialManagerTest and is intended
    ///to contain all SpecialManagerTest Unit Tests
    ///</summary>
    [TestClass]
    public class SpecialManagerTest
    {
        public Inventory InventoryTestObject { get; set; }

        public Special SpecialTestObject { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            InventoryTestObject = InventoryManagerTest.CreateTestObject();

            SpecialTestObject = CreateSpecialObject(InventoryTestObject);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            DeleteSpecialObject(SpecialTestObject);

            InventoryManagerTest.DeleteInventoryObject(InventoryTestObject);
        }

        /// <summary>
        ///A test for Load
        ///</summary>
        [TestMethod]
        public void SpecialLoadTest()
        {
            Assert.IsNotNull(SpecialTestObject, "Test object was null");

            Assert.IsNotNull(SpecialTestObject.SpecialId, "Test object was not saved successfully");

            Special entity = SpecialManager.Load(SpecialTestObject.SpecialId.Value);

            Assert.IsNotNull(entity, "Special object was null");

            Assert.IsTrue(entity.DateEnd.Equals(SpecialTestObject.DateEnd), "Date end was not as expected");

            Assert.IsTrue(entity.DateStart.Equals(SpecialTestObject.DateStart), "Date start was not as expected");

            Assert.IsTrue(entity.InventoryId.Equals(SpecialTestObject.InventoryId), "InventoryId was not as expected");

            Assert.IsTrue(entity.Price.Round() == SpecialTestObject.Price.Round(), "Price was not as expected");

            Assert.IsTrue(entity.SpecialId.Equals(SpecialTestObject.SpecialId), "SpecialId was not as expected");
        }

        /// <summary>
        ///A test for Save
        ///</summary>
        [TestMethod]
        public void SpecialSaveTest()
        {
            Random rand = new Random();

            Assert.IsNotNull(SpecialTestObject, "Test object was null");

            Assert.IsNotNull(SpecialTestObject.SpecialId, "Test object was not saved successfully");

            Special entity = SpecialManager.Load(SpecialTestObject.SpecialId.Value);

            Assert.IsNotNull(entity, "Special object was null");

            entity.Price = (decimal) ((rand.NextDouble() + .01)*rand.Next(5, 100));

            string errorMessage;

            SpecialManager.Save(entity, out errorMessage);

            Special savedEntity = SpecialManager.Load(entity.SpecialId.GetValueOrDefault());

            Assert.IsTrue(savedEntity.Price.Round().Equals(entity.Price.Round()));
        }

        /// <summary>
		///A test for Validate
		///</summary>
		[TestMethod]
		public void SpecialValidateTest()
		{
			Assert.IsNotNull(SpecialTestObject, "Test object was null");

			string errorMessage;

            bool valid = SpecialManager.Validate(SpecialTestObject, out errorMessage);

			Assert.IsTrue(valid, "Special was not valid when it should have been");

			Assert.IsTrue(errorMessage.IsNullOrWhiteSpace(), "Errors found when there shouldn't have been any");

            SpecialTestObject.DateStart = default(DateTime);

            valid = SpecialManager.Validate(SpecialTestObject, out errorMessage);

			Assert.IsFalse(valid, "Special was valid when it shouldn't have been");

			Assert.IsTrue(errorMessage.HasValue(), "Errors not found when there should have been any");
		}

        public static void DeleteSpecialObject(Special special)
        {
            SpecialManager.Delete(special.SpecialId.GetValueOrDefault());
        }

        public static Special CreateSpecialObject(Inventory inventory)
        {
            Random rand = new Random();

            Special special = new Special
            {
                DateEnd = DateTime.Parse("4/1/2013"),
                DateStart = DateTime.Parse("1/1/2013"),
                IsItemModified = true,
                InventoryId = inventory.InventoryId.GetValueOrDefault(),
                SpecialId = null,
                Price = (decimal)((rand.NextDouble() + .01) * rand.Next(5, 100))
            };

            string errorMessage;

            SpecialManager.Save(special, out errorMessage);

            return special;
        }

    }
}