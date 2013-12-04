// --------------------------------
// <copyright file="InventoryManagerTest.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>JDuverge</author>
// <summary>
//  Inventory Test Layer Object.   
// </summary>
// ---------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using KarzPlus.Business;
using KarzPlus.Entities;
using KarzPlus.Entities.ExtensionMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KarzPlus.Tests
{
    /// <summary>
    ///This is a test class for InventoryManagerTest and is intended
    ///to contain all InventoryManagerTest Unit Tests
    ///</summary>
    [TestClass]
    public class InventoryManagerTest
    {
		private Inventory InventoryTestObject { get; set; }

		[TestInitialize]
		public void CreateTestObject()
		{
			int carModelId = default(int), locationId = default(int);
			string errorMessage;

			Random rand = new Random();

			List<CarModel> carModels = CarModelManager.LoadAll().ToList();
			if (carModels.SafeAny())
			{
				carModelId = carModels.First().ModelId.GetValueOrDefault();
			}
			else
			{
				CarModel carModel
					= new CarModel
					{
						Name = string.Format("TestCarModel_{0}", rand.Next(1, 1000))
					};

				CarModelManager.Save(carModel, out errorMessage);

				if (carModel.ModelId.HasValue)
				{
					carModelId = carModel.ModelId.Value;
				}
			}

			List<Location> locations = LocationManager.LoadAll().ToList();
			if (locations.SafeAny())
			{
				locationId = locations.First(l => l.LocationId.HasValue).LocationId.GetValueOrDefault();
			}
			else
			{
				Location location
					= new Location
					{
						Name = string.Format("TestLocation_{0}", rand.Next(1, 1000)),
						Address = "123 Fake Street",
						City = "Fake City",
						Email = "fake@email.com",
						Phone = "5555555555",
						State = "FS",
						Zip = "55555"
					};

				LocationManager.Save(location, out errorMessage);

				if (location.LocationId.HasValue)
				{
					locationId = location.LocationId.Value;
				}
			}

			InventoryTestObject
				= new Inventory
				{
					ModelId = carModelId,
					Color = "Black",
					Price = (decimal)((rand.NextDouble() + .01) * rand.Next(5, 100)),
					LocationId = locationId,
					Quantity = rand.Next(1, 50),
					Year = rand.Next(DateTime.Now.AddYears(rand.Next(1, 100).NegativeValue()).Year, DateTime.Now.Year)
				};

			InventoryManager.Save(InventoryTestObject, out errorMessage);
		}

		[TestCleanup]
		public void DestroyTestObject()
		{
			if (InventoryTestObject != null && InventoryTestObject.InventoryId.HasValue)
			{
				InventoryManager.HardDelete(InventoryTestObject.InventoryId.Value);
			}
		}

		/// <summary>
		///A test for Load
		///</summary>
		[TestMethod]
		public void InventoryLoadTest()
		{
			Assert.IsNotNull(InventoryTestObject, "Test object was null");
			Assert.IsNotNull(InventoryTestObject.InventoryId, "Test object was not saved succesffully");

			Inventory entity = InventoryManager.Load(InventoryTestObject.InventoryId.Value);
			Assert.IsNotNull(entity, "Inventory object was null");

			Assert.IsTrue(entity.Color.SafeEquals(InventoryTestObject.Color), "Color was not as expected");
			Assert.IsTrue(entity.LocationId == InventoryTestObject.LocationId, "LocationId was not as expected");
			Assert.IsTrue(entity.ModelId == InventoryTestObject.ModelId, "ModelId was not as expected");
			Assert.IsTrue(entity.Price.Round() == InventoryTestObject.Price.Round(), "Price was not as expected");
			Assert.IsTrue(entity.Quantity == InventoryTestObject.Quantity, "Quantity was not as expected");
			Assert.IsTrue(entity.Year == InventoryTestObject.Year, "Year was not as expected");
		}

		/// <summary>
		///A test for Save
		///</summary>
		[TestMethod]
		public void InventorySaveTest()
		{
			Assert.IsNotNull(InventoryTestObject, "Test object was null");
			Assert.IsNotNull(InventoryTestObject.InventoryId, "Test object was not saved succesffully");

			Inventory entity = InventoryManager.Load(InventoryTestObject.InventoryId.Value);
			Assert.IsNotNull(entity, "Inventory object was null");

			string newColor = string.Format("Not_{0}", entity.Color);
			const int newQuantity = 5;

			entity.Color = newColor;
			entity.Quantity = newQuantity;

			string errorMessage;
			InventoryManager.Save(entity, out errorMessage);

			Assert.IsTrue(errorMessage.IsNullOrWhiteSpace(), "Error while saving object");

			Assert.IsNotNull(entity.InventoryId, "Entity doesn't have an ID");

			Inventory newEntity = InventoryManager.Load(entity.InventoryId.Value);

			Assert.IsNotNull(newEntity, "Could not load new entity");

			Assert.IsTrue(newEntity.Color.SafeEquals(newColor), "Color edit was not persisted to data store");
			Assert.IsTrue(newEntity.Quantity == newQuantity, "Quantity edit was not persisted to data store");
		}

		/// <summary>
		///A test for Validate
		///</summary>
		[TestMethod]
		public void InventoryValidateTest()
		{
			Assert.IsNotNull(InventoryTestObject, "Test object was null");

			string errorMessage;
			bool valid = InventoryManager.Validate(InventoryTestObject, out errorMessage);

			Assert.IsTrue(valid, "Inventory was not valid when it should have been");
			Assert.IsTrue(errorMessage.IsNullOrWhiteSpace(), "Errors found when there shouldn't have been any");

			InventoryTestObject.LocationId = -1;
			InventoryTestObject.ModelId = -1;

			valid = InventoryManager.Validate(InventoryTestObject, out errorMessage);

			Assert.IsFalse(valid, "Inventory was valid when it shouldn't have been");
			Assert.IsTrue(errorMessage.HasValue(), "Errors not found when there should have been any");
			Assert.IsTrue(errorMessage.Contains("ModelId must be valid", StringComparison.InvariantCultureIgnoreCase));
			Assert.IsTrue(errorMessage.Contains("LocationId must be valid", StringComparison.InvariantCultureIgnoreCase));
		}
    }
}