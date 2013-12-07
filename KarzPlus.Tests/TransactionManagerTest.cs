// --------------------------------
// <copyright file="TransactionManagerTest.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>KEscobar</author>
// <summary>
//  Transaction Test Layer Object.   
// </summary>
// ---------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using KarzPlus.Business;
using KarzPlus.Entities;
using KarzPlus.Entities.ExtensionMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KarzPlus.Tests
{
	/// <summary>
	///This is a test class for TransactionManagerTest and is intended
	///to contain all TransactionManagerTest Unit Tests
	///</summary>
	[TestClass]
	public class TransactionManagerTest
	{
		private Transaction TransactionTestObject { get; set; }

		[TestInitialize]
		public void CreateTestObject()
		{
			int inventoryId;
			Guid userId = Guid.Empty;
			Random rand = new Random();
			string errorMessage;

			string userName = string.Format("NewUser_{0}", rand.Next(1, 100000));
			const string passWord = "abcd1234!@#";
			string email = string.Format("emailaddress{0}@test.com", rand.Next(1, 1000000000));

			MembershipCreateStatus status;
			MembershipUser user = Membership.CreateUser(userName, passWord, email, "quieres apple?", "no, apple es para mujeres", true, out status);
			if (user != null && user.ProviderUserKey is Guid)
			{
				userId = (Guid)user.ProviderUserKey;
			}

			List<Inventory> inventoryList = InventoryManager.LoadAll().ToList();
			if (inventoryList.SafeAny())
			{
				inventoryId = inventoryList.First().InventoryId.GetValueOrDefault();
			}
			else
			{
				CarMake newMake
					= new CarMake
					{
						Manufacturer = "TestManufacturer",
						Name = string.Format("Make_{0}", rand.Next(1, 1000))
					};

				CarMakeManager.Save(newMake, out errorMessage);

				CarModel newModel
					= new CarModel
					{
						MakeId = newMake.MakeId.GetValueOrDefault(),
						Name = string.Format("Model_{0}", rand.Next(1, 1000))
					};

				CarModelManager.Save(newModel, out errorMessage);

				Location location
					= new Location
					{
						Name = string.Format("Location_{0}", rand.Next(1, 100000)),
						Address = string.Format("{0} Street St", rand.Next(10, 1000)),
						City = "Fake City",
						State = "FS",
						Zip = "11111",
						Email = "test@email.com",
						Phone = "1112223333"
					};

				LocationManager.Save(location, out errorMessage);

				Inventory inventory
					= new Inventory
					{
						ModelId = newModel.ModelId.GetValueOrDefault(),
						LocationId = location.LocationId.GetValueOrDefault(),
						Color = "Red",
						Price = (decimal) ((rand.NextDouble() + 0.1)*rand.Next(10, 60)),
						Quantity = rand.Next(1, 10),
						Year = rand.Next(1990, 2015)
					};

				inventoryId = inventory.InventoryId.GetValueOrDefault();
			}

			TransactionTestObject
				= new Transaction
				{
					BillingAddress = "123 Fake Street",
					BillingCity = "Fake City",
					BillingState = "FS",
					BillingZip = "12345",
					CCV = 123,
					CreditCardNumber = "4444999911110000",
					ExpirationDate = DateTime.Today.AddYears(rand.Next(5, 10)),
					InventoryId = inventoryId,
					Price = (decimal)( ( rand.NextDouble() + 0.1 ) * rand.Next(10, 60) ),
					RentalDateEnd = DateTime.Today.AddDays(rand.Next(11, 50)),
					RentalDateStart = DateTime.Today.AddDays(rand.Next(1, 10)),
					TransactionDate = DateTime.Today,
					UserId = userId
				};

			TransactionManager.Save(TransactionTestObject, out errorMessage);
		}

		[TestCleanup]
		public void DestroyTestObject()
		{
			if (TransactionTestObject != null)
			{
				if (TransactionTestObject.TransactionId.HasValue)
				{
					TransactionManager.Delete(TransactionTestObject.TransactionId.Value);
				}
			}
		}

		/// <summary>
		///A test for Load
		///</summary>
		[TestMethod]
		public void TransactionLoadTest()
		{
			Assert.IsNotNull(TransactionTestObject, "Test object was null");
			Assert.IsNotNull(TransactionTestObject.TransactionId, "Test object was not saved successfully");

			Transaction entity = TransactionManager.Load(TransactionTestObject.TransactionId.Value);
			Assert.IsNotNull(entity, "Transaction object was null");

			Assert.IsTrue(entity.BillingAddress.SafeEquals(TransactionTestObject.BillingAddress), "BillingAddress was not as expected");
			Assert.IsTrue(entity.CreditCardNumber.SafeEquals(TransactionTestObject.CreditCardNumber), "CreditCardNumber was not as expected");
			Assert.IsTrue(entity.Price.Round() == TransactionTestObject.Price.Round(), "Price was not as expected");
			Assert.IsTrue(entity.InventoryId == TransactionTestObject.InventoryId, "InventoryId was not as expected");
		}

		/// <summary>
		///A test for Save
		///</summary>
		[TestMethod]
		public void TransactionSaveTest()
		{
			Assert.IsNotNull(TransactionTestObject, "Test object was null");
			Assert.IsNotNull(TransactionTestObject.TransactionId, "Test object was not saved successfully");

			Transaction entity = TransactionManager.Load(TransactionTestObject.TransactionId.Value);
			Assert.IsNotNull(entity, "Transaction object was null");

			string newCreditCard = string.Format("{0}{1}", entity.CreditCardNumber.Suffix(8), entity.CreditCardNumber.SafeSubstring(8));
			DateTime newExpiration = entity.ExpirationDate.AddYears(1).Date;

			entity.CreditCardNumber = newCreditCard;
			entity.ExpirationDate = newExpiration;

			string errorMessage;
			TransactionManager.Save(entity, out errorMessage);

			Assert.IsTrue(errorMessage.IsNullOrWhiteSpace(), "Error while saving object");

			Assert.IsNotNull(entity.TransactionId, "Entity doesn't have an ID");

			Transaction newEntity = TransactionManager.Load(entity.TransactionId.Value);

			Assert.IsNotNull(newEntity, "Could not load new entity");

			Assert.IsTrue(newEntity.CreditCardNumber.SafeEquals(newCreditCard), "CreditCardNumber edit was not persisted to data store");
			Assert.IsTrue(newEntity.ExpirationDate.Equals(newExpiration), "CreditCardNumber edit was not persisted to data store");
		}
	}
}