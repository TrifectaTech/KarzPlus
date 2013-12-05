// --------------------------------
// <copyright file="LocationManagerTest.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>JOrtega</author>
// <summary>
//  Location Test Layer Object.   
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
    ///This is a test class for LocationManagerTest and is intended
    ///to contain all LocationManagerTest Unit Tests
    ///</summary>
    [TestClass]
    public class LocationManagerTest
    {
		private Location LocationTestObject { get; set; }

		[TestInitialize]
		public void CreateTestObject()
		{
			Random rand = new Random();
			LocationTestObject
				= new Location
				{
					Name = string.Format("TestLocation_{0}", rand.Next(1, 1000)),
					Address = "123 Fake Street",
					City = "Fake City",
					Email = "fake@email.com",
					Phone = "5551112234",
					State = "FS",
					Zip = "11233"
				};

			string errorMessage;
			LocationManager.Save(LocationTestObject, out errorMessage);
		}

		[TestCleanup]
		public void DestroyTestObject()
		{
			if (LocationTestObject != null && LocationTestObject.LocationId.HasValue)
			{
				LocationManager.HardDelete(LocationTestObject.LocationId.Value);
			}
		}

		/// <summary>
		///A test for Load
		///</summary>
		[TestMethod]
		public void LocationLoadTest()
		{
			Assert.IsNotNull(LocationTestObject, "Test object was null");
			Assert.IsNotNull(LocationTestObject.LocationId, "Test object was not saved successfully");

			Location entity = LocationManager.Load(LocationTestObject.LocationId.Value);
			Assert.IsNotNull(entity, "Location object was null");

			Assert.IsTrue(entity.Name.SafeEquals(LocationTestObject.Name), "Name was not as expected");
			Assert.IsTrue(entity.FullAddress.SafeEquals(LocationTestObject.FullAddress), "FullAddress was not as expected");
			Assert.IsTrue(entity.Phone.SafeEquals(LocationTestObject.Phone), "Phone was not as expected");
			Assert.IsTrue(entity.Email.SafeEquals(LocationTestObject.Email), "Email was not as expected");
		}

		/// <summary>
		///A test for Save
		///</summary>
		[TestMethod]
		public void LocationSaveTest()
		{
			Assert.IsNotNull(LocationTestObject, "Test object was null");
			Assert.IsNotNull(LocationTestObject.LocationId, "Test object was not saved successfully");

			Location entity = LocationManager.Load(LocationTestObject.LocationId.Value);
			Assert.IsNotNull(entity, "Location object was null");

			string newName = string.Format("Not_{0}", entity.Name);
			string newAddress = entity.Address.Reverse();

			entity.Name = newName;
			entity.Address = newAddress;

			string errorMessage;
			LocationManager.Save(entity, out errorMessage);

			Assert.IsTrue(errorMessage.IsNullOrWhiteSpace(), "Error while saving object");

			Assert.IsNotNull(entity.LocationId, "Entity doesn't have an ID");

			Location newEntity = LocationManager.Load(entity.LocationId.Value);

			Assert.IsNotNull(newEntity, "Could not load new entity");

			Assert.IsTrue(newEntity.Name.SafeEquals(newName), "Name edit was not persisted to data store");
			Assert.IsTrue(newEntity.Address.SafeEquals(newAddress), "Address edit was not persisted to data store");
		}

		/// <summary>
		///A test for Validate
		///</summary>
		[TestMethod]
		public void LocationValidateTest()
		{
			Assert.IsNotNull(LocationTestObject, "Test object was null");

			string errorMessage;
			bool valid = LocationManager.Validate(LocationTestObject, out errorMessage);

			Assert.IsTrue(valid, "Location was not valid when it should have been");
			Assert.IsTrue(errorMessage.IsNullOrWhiteSpace(), "Errors found when there shouldn't have been any");

			string name = LocationTestObject.Name;

			LocationTestObject.Name = string.Empty;

			valid = LocationManager.Validate(LocationTestObject, out errorMessage);

			Assert.IsFalse(valid, "Location was valid when it shouldn't have been");
			Assert.IsTrue(errorMessage.HasValue(), "Errors not found when there should have been any");
			Assert.IsTrue(errorMessage.Contains("Name is required", StringComparison.InvariantCultureIgnoreCase));

			LocationTestObject.Name = name;
			LocationTestObject.Email = "aaaaa.com";
			LocationTestObject.Phone = "11";

			valid = LocationManager.Validate(LocationTestObject, out errorMessage);

			Assert.IsFalse(valid, "Location was valid when it shouldn't have been");
			Assert.IsTrue(errorMessage.HasValue(), "Errors not found when there should have been any");
			Assert.IsTrue(errorMessage.Contains("Phone must be valid", StringComparison.InvariantCultureIgnoreCase));
			Assert.IsTrue(errorMessage.Contains("Email must be valid", StringComparison.InvariantCultureIgnoreCase));
		}
    }
}