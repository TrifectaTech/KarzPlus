// --------------------------------
// <copyright file="CarMakeManagerTest.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>JDuverge</author>
// <summary>
//  CarMake Test Layer Object.   
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
	///This is a test class for CarMakeManagerTest and is intended
	///to contain all CarMakeManagerTest Unit Tests
	///</summary>
	[TestClass]
	public class CarMakeManagerTest
	{
		private CarMake CarMakeTestObject { get; set; }

		[TestInitialize]
		public void CreateTestObject()
		{
			Random rand = new Random();
			CarMakeTestObject
				= new CarMake
				{
					MakeId = null,
					Name = string.Format("TestCarMake_{0}", rand.Next(1, 1000)),
					Manufacturer = "TestCarManufacturer"
				};

			string errorMessage;
			CarMakeManager.Save(CarMakeTestObject, out errorMessage);
		}

		[TestCleanup]
		public void DestroyTestObject()
		{
			if (CarMakeTestObject != null && CarMakeTestObject.MakeId.HasValue)
			{
				CarMakeManager.HardDelete(CarMakeTestObject.MakeId.Value);
			}
		}

		/// <summary>
		///A test for Load
		///</summary>
		[TestMethod]
		public void CarMakeLoadTest()
		{
			Assert.IsNotNull(CarMakeTestObject, "Test object was null");
			Assert.IsNotNull(CarMakeTestObject.MakeId, "Test object was not saved succesffully");

			CarMake entity = CarMakeManager.Load(CarMakeTestObject.MakeId.Value);
			Assert.IsNotNull(entity, "CarMake object was null");

			Assert.IsTrue(entity.Name.SafeEquals(CarMakeTestObject.Name), "Name was not as expected");
			Assert.IsTrue(entity.Manufacturer.SafeEquals(CarMakeTestObject.Manufacturer), "Manufacturer was not as expected");
		}

		/// <summary>
		///A test for Save
		///</summary>
		[TestMethod]
		public void CarMakeSaveTest()
		{
			Assert.IsNotNull(CarMakeTestObject, "Test object was null");
			Assert.IsNotNull(CarMakeTestObject.MakeId, "Test object was not saved succesffully");

			CarMake entity = CarMakeManager.Load(CarMakeTestObject.MakeId.Value);
			Assert.IsNotNull(entity, "CarMake object was null");

			string newMake = string.Format("Not_{0}", entity.Name);

			entity.Name = newMake;

			string errorMessage;
			CarMakeManager.Save(entity, out errorMessage);

			Assert.IsTrue(errorMessage.IsNullOrWhiteSpace(), "Error while saving object");

			Assert.IsNotNull(entity.MakeId, "Entity doesn't have an ID");

			CarMake newEntity = CarMakeManager.Load(entity.MakeId.Value);

			Assert.IsNotNull(newEntity, "Could not load new entity");

			Assert.IsTrue(newEntity.Name.SafeEquals(newMake), "Name edit was not persisted to data store");
		}

		/// <summary>
		///A test for Validate
		///</summary>
		[TestMethod]
		public void CarMakeValidateTest()
		{
			Assert.IsNotNull(CarMakeTestObject, "Test object was null");

			string errorMessage;
			bool valid = CarMakeManager.Validate(CarMakeTestObject, out errorMessage);

			Assert.IsTrue(valid, "CarMake was not valid when it should have been");
			Assert.IsTrue(errorMessage.IsNullOrWhiteSpace(), "Errors found when there shouldn't have been any");

			string name = CarMakeTestObject.Name;

			CarMakeTestObject.Name = string.Empty;

			valid = CarMakeManager.Validate(CarMakeTestObject, out errorMessage);

			Assert.IsFalse(valid, "CarMake was valid when it shouldn't have been");
			Assert.IsTrue(errorMessage.HasValue(), "Errors not found when there should have been any");
			Assert.IsTrue(errorMessage.Contains("Name is required", StringComparison.InvariantCultureIgnoreCase));

			CarMake newCarMake
				= new CarMake
				{
					Name = name,
					Manufacturer = name
				};

			valid = CarMakeManager.Validate(newCarMake, out errorMessage);

			Assert.IsFalse(valid, "CarMake was valid when it shouldn't have been");
			Assert.IsTrue(errorMessage.HasValue(), "Errors not found when there should have been any");
			Assert.IsTrue(errorMessage.Contains("Cannot have multiple car makes with the same name", StringComparison.InvariantCultureIgnoreCase));
		}
	}
}