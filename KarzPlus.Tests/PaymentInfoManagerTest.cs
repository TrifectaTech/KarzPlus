// --------------------------------
// <copyright file="PaymentInfoManagerTest.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>KEscobar</author>
// <summary>
//  PaymentInfo Test Layer Object.   
// </summary>
// ---------------------------------

using System.Collections.Generic;
using System.Linq;
using KarzPlus.Business;
using KarzPlus.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KarzPlus.Tests
{
    /// <summary>
    ///This is a test class for PaymentInfoManagerTest and is intended
    ///to contain all PaymentInfoManagerTest Unit Tests
    ///</summary>
    [TestClass]
    public class PaymentInfoManagerTest
    {
        /// <summary>
        ///A test for Load
        ///</summary>
        [TestMethod]
        public void PaymentInfoLoadTest()
        {
			// TODO - Initiate keys
            const int paymentInfoId = 0; 

            PaymentInfo entity = PaymentInfoManager.Load(paymentInfoId);
            Assert.IsNotNull(entity, "PaymentInfo object was null");
        }

		/// <summary>
        ///A null test for Load
        ///</summary>
        [TestMethod]
        public void PaymentInfoLoadNullTest()
        {
			
            List<PaymentInfo> entity = PaymentInfoManager.Search(null).ToList();
            Assert.IsFalse(entity.Any(), "PaymentInfo object was null");
        }


        /// <summary>
        ///A test for Save
        ///</summary>
        [TestMethod]
        public void PaymentInfoSaveTest()
        {
			// TODO - Initiate keys
			const int paymentInfoId = 0; 

            PaymentInfo entity = PaymentInfoManager.Load(paymentInfoId);
            string errorMessage;
            string errorMessageExpected = string.Empty;
            const bool expected = true;
            bool actual = PaymentInfoManager.Save(entity, out errorMessage);
            Assert.AreEqual(errorMessageExpected, errorMessage, "Some errors were found with PaymentInfo object");
            Assert.AreEqual(expected, actual, "Save wasn't successful");
        }

        /// <summary>
        ///A test for Validate
        ///</summary>
        [TestMethod]
        public void PaymentInfoValidateTest()
        {
			// TODO - Initiate keys
			const int paymentInfoId = 0; 

            PaymentInfo entity = PaymentInfoManager.Load(paymentInfoId);
            string errorMessage;
            string errorMessageExpected = string.Empty;
            const bool expected = true;
            bool actual = PaymentInfoManager.Validate(entity, out errorMessage);
            Assert.AreEqual(errorMessageExpected, errorMessage, "Some errors were found with PaymentInfo object");
            Assert.AreEqual(expected, actual, "PaymentInfo object was invalid");
        }
    }
}