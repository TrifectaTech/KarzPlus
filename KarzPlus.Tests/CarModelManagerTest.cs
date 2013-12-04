// --------------------------------
// <copyright file="CarModelManagerTest.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>JDuverge</author>
// <summary>
//  CarModel Test Layer Object.   
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
    ///This is a test class for CarModelManagerTest and is intended
    ///to contain all CarModelManagerTest Unit Tests
    ///</summary>
    [TestClass]
    public class CarModelManagerTest
    {
		private CarModel CarModelTestObject { get; set; }

		[TestInitialize]
		public void CreateTestObject()
		{
			int carMakeId = default(int);
			string errorMessage;

			Random rand = new Random();

			List<CarMake> carMakes = CarMakeManager.LoadAll().ToList();
			if (carMakes.SafeAny(c => c.MakeId.HasValue))
			{
				carMakeId = carMakes.First().MakeId.GetValueOrDefault();
			}
			else
			{
				CarMake carMake
					= new CarMake
					{
						Name = string.Format("TestCarMake_{0}", rand.Next(1, 1000)),
						Manufacturer = "TestManufacturer"
					};

				CarMakeManager.Save(carMake, out errorMessage);

				if (carMake.MakeId.HasValue)
				{
					carMakeId = carMake.MakeId.Value;
				}
			}

			CarModelTestObject
				= new CarModel
				{
					ModelId = null,
					MakeId = carMakeId,
					Name = string.Format("TestCarModel_{0}", rand.Next(1, 1000))
				};
			
			CarModelManager.Save(CarModelTestObject, out errorMessage);
		}

		[TestCleanup]
		public void DestroyTestObject()
		{
			if (CarModelTestObject != null && CarModelTestObject.ModelId.HasValue)
			{
				CarModelManager.HardDelete(CarModelTestObject.ModelId.Value);
			}
		}

		/// <summary>
		///A test for Load
		///</summary>
		[TestMethod]
		public void CarModelLoadTest()
		{
			Assert.IsNotNull(CarModelTestObject, "Test object was null");
			Assert.IsNotNull(CarModelTestObject.ModelId, "Test object was not saved succesffully");

			CarModel entity = CarModelManager.Load(CarModelTestObject.ModelId.Value);
			Assert.IsNotNull(entity, "CarModel object was null");

			Assert.IsTrue(entity.MakeId == CarModelTestObject.MakeId, "MakeId was not as expected");
			Assert.IsTrue(entity.Name.SafeEquals(CarModelTestObject.Name), "Name was not as expected");
		}

		/// <summary>
		///A test for Save
		///</summary>
		[TestMethod]
		public void CarModelSaveTest()
		{
			Assert.IsNotNull(CarModelTestObject, "Test object was null");
			Assert.IsNotNull(CarModelTestObject.ModelId, "Test object was not saved succesffully");

			CarModel entity = CarModelManager.Load(CarModelTestObject.ModelId.Value);
			Assert.IsNotNull(entity, "CarModel object was null");

			string newModel = string.Format("Not_{0}", entity.Name);

			entity.Name = newModel;

			string errorMessage;
			CarModelManager.Save(entity, out errorMessage);

			Assert.IsTrue(errorMessage.IsNullOrWhiteSpace(), "Error while saving object");

			Assert.IsNotNull(entity.ModelId, "Entity doesn't have an ID");

			CarModel newEntity = CarModelManager.Load(entity.ModelId.Value);

			Assert.IsNotNull(newEntity, "Could not load new entity");

			Assert.IsTrue(newEntity.Name.SafeEquals(newModel), "Name edit was not persisted to data store");
		}

		/// <summary>
		///A test for Validate
		///</summary>
		[TestMethod]
		public void CarModelValidateTest()
		{
			Assert.IsNotNull(CarModelTestObject, "Test object was null");

			string errorMessage;
			bool valid = CarModelManager.Validate(CarModelTestObject, out errorMessage);

			Assert.IsTrue(valid, "CarModel was not valid when it should have been");
			Assert.IsTrue(errorMessage.IsNullOrWhiteSpace(), "Errors found when there shouldn't have been any");

			string name = CarModelTestObject.Name;
			int makeId = CarModelTestObject.MakeId;

			CarModelTestObject.Name = string.Empty;
			CarModelTestObject.MakeId = -1;

			valid = CarModelManager.Validate(CarModelTestObject, out errorMessage);

			Assert.IsFalse(valid, "CarModel was valid when it shouldn't have been");
			Assert.IsTrue(errorMessage.HasValue(), "Errors not found when there should have been any");
			Assert.IsTrue(errorMessage.Contains("MakeId must be valid", StringComparison.InvariantCultureIgnoreCase));
			Assert.IsTrue(errorMessage.Contains("Name is required", StringComparison.InvariantCultureIgnoreCase));

			CarModel newCarModel
				= new CarModel
				{
					MakeId = makeId,
					Name = name
				};

			valid = CarModelManager.Validate(newCarModel, out errorMessage);

			Assert.IsFalse(valid, "CarModel was valid when it shouldn't have been");
			Assert.IsTrue(errorMessage.HasValue(), "Errors not found when there should have been any");
			Assert.IsTrue(errorMessage.Contains("Cannot have multiple car models with the same name from the same make", StringComparison.InvariantCultureIgnoreCase));
		}
    }
}