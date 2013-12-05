// --------------------------------
// <copyright file="PaymentInfoManagerTest.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>KEscobar</author>
// <summary>
//  PaymentInfo Test Layer Object.   
// </summary>
// ---------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using KarzPlus.Business;
using KarzPlus.Entities;
using KarzPlus.Entities.ExtensionMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Security;

namespace KarzPlus.Tests
{
    /// <summary>
    ///This is a test class for PaymentInfoManagerTest and is intended
    ///to contain all PaymentInfoManagerTest Unit Tests
    ///</summary>
    [TestClass]
    public class PaymentInfoManagerTest
    {

        private PaymentInfo PaymentInfoTestObject { get; set; }

        [TestInitialize]
        public void CreateTestObject()
        {
            string errorMessage;

            string userName = string.Format("TestUser_{0}", new Random().Next(1, 100000));

            string email = string.Format("TestUser_{0}@gmail.com", new Random().Next(1, 100000));

            MembershipCreateStatus status = new MembershipCreateStatus();
            MembershipUser newuser = Membership.CreateUser(userName, "john!!dD0122", email, "Apple is good?", "Apple", true, out status);

            PaymentInfoTestObject
                = new PaymentInfo
                           {
                               UserId = (Guid)newuser.ProviderUserKey,
                               CreditCardNumber = "1234432112344321",
                               ExpirationDate = DateTime.Now.AddDays(100),
                               CCV = 892,
                               BillingAddress = "TestAddress",
                               BillingCity = "TestCity",
                               BillingState = "FL",
                               BillingZip = "31233"
                           };

            PaymentInfoManager.Save(PaymentInfoTestObject, out errorMessage);
        }

        [TestCleanup]
        public void DestroyTestObject()
        {
            if (PaymentInfoTestObject != null && PaymentInfoTestObject.PaymentInfoId.HasValue)
            {
                CarModelManager.HardDelete(PaymentInfoTestObject.PaymentInfoId.Value);
            }
        }

        /// <summary>
        ///A test for Load
        ///</summary>
        [TestMethod]
        public void PaymentInfoLoadTest()
        {
            Assert.IsNotNull(PaymentInfoTestObject, "Test object was null");
            Assert.IsNotNull(PaymentInfoTestObject.PaymentInfoId, "Test object was not saved successfully");

            PaymentInfo entity = PaymentInfoManager.Load(PaymentInfoTestObject.PaymentInfoId.Value);
            Assert.IsNotNull(entity, "PaymentInfo object was null");

            Assert.IsTrue(entity.PaymentInfoId == PaymentInfoTestObject.PaymentInfoId, "PaymentInfoId was not as expected");
            Assert.IsTrue(entity.BillingAddress.SafeEquals(PaymentInfoTestObject.BillingAddress), "BillingAddress was not as expected");
        }

        /// <summary>
        ///A test for Save
        ///</summary>
        [TestMethod]
        public void PaymentInfoSaveTest()
        {
            Assert.IsNotNull(PaymentInfoTestObject, "Test object was null");
            Assert.IsNotNull(PaymentInfoTestObject.PaymentInfoId, "Test object was not saved succesffully");

            PaymentInfo entity = PaymentInfoManager.Load(PaymentInfoTestObject.PaymentInfoId.Value);
            Assert.IsNotNull(entity, "PaymentInfo object was null");

            string newAddress = string.Format("Not_{0}", entity.PaymentInfoId);

            entity.BillingAddress = newAddress;

            string errorMessage;
            PaymentInfoManager.Save(entity, out errorMessage);

            Assert.IsTrue(errorMessage.IsNullOrWhiteSpace(), "Error while saving object");

            Assert.IsNotNull(entity.PaymentInfoId, "Entity doesn't have an ID");

            PaymentInfo newEntity = PaymentInfoManager.Load(entity.PaymentInfoId.Value);

            Assert.IsNotNull(newEntity, "Could not load new entity");

            Assert.IsTrue(newEntity.BillingAddress.SafeEquals(newAddress), "BillingAddress edit was not persisted to data store");
        }

        /// <summary>
        ///A test for Validate
        ///</summary>
        [TestMethod]
        public void PaymentInfoValidateTest()
        {
            Assert.IsNotNull(PaymentInfoTestObject, "Test object was null");

            string errorMessage;
            bool valid = PaymentInfoManager.Validate(PaymentInfoTestObject, out errorMessage);

            Assert.IsTrue(valid, "PaymentInfo was not valid when it should have been");
            Assert.IsTrue(errorMessage.IsNullOrWhiteSpace(), "Errors found when there shouldn't have been any");

            string address = PaymentInfoTestObject.BillingAddress;
            string ccNumber = PaymentInfoTestObject.CreditCardNumber;

            PaymentInfoTestObject.BillingCity = string.Empty;
            PaymentInfoTestObject.CreditCardNumber = "dfasdf34234";

            valid = PaymentInfoManager.Validate(PaymentInfoTestObject, out errorMessage);

            Assert.IsFalse(valid, "PaymentInfo was valid when it shouldn't have been");
            Assert.IsTrue(errorMessage.HasValue(), "Errors not found when there should have been any");
            Assert.IsTrue(errorMessage.Contains("*Credit Card Number must be a 16 digit number", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(errorMessage.Contains("*Billing Address is required", StringComparison.InvariantCultureIgnoreCase));
        }
    }
}