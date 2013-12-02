// --------------------------------
// <copyright file="CarMakeManagerTest.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>JDuverge</author>
// <summary>
//  CarMake Test Layer Object.   
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
    ///This is a test class for CarMakeManagerTest and is intended
    ///to contain all CarMakeManagerTest Unit Tests
    ///</summary>
    [TestClass]
    public class CarMakeManagerTest
    {
        /// <summary>
        ///A test for Load
        ///</summary>
        [TestMethod]
        public void CarMakeLoadTest()
        {
			// TODO - Initiate keys
            const int makeId = 0; 

            CarMake entity = CarMakeManager.Load(makeId);
            Assert.IsNotNull(entity, "CarMake object was null");
        }

		/// <summary>
        ///A null test for Load
        ///</summary>
        [TestMethod]
        public void CarMakeLoadNullTest()
        {
			
            List<CarMake> entity = CarMakeManager.Search(null).ToList();
            Assert.IsFalse(entity.Any(), "CarMake object was null");
        }


        /// <summary>
        ///A test for Save
        ///</summary>
        [TestMethod]
        public void CarMakeSaveTest()
        {
			// TODO - Initiate keys
			const int makeId = 0; 

            CarMake entity = CarMakeManager.Load(makeId);
            string errorMessage;
            string errorMessageExpected = string.Empty;
            const bool expected = true;
            bool actual = CarMakeManager.Save(entity, out errorMessage);
            Assert.AreEqual(errorMessageExpected, errorMessage, "Some errors were found with CarMake object");
            Assert.AreEqual(expected, actual, "Save wasn't successful");
        }

        /// <summary>
        ///A test for Validate
        ///</summary>
        [TestMethod]
        public void CarMakeValidateTest()
        {
			// TODO - Initiate keys
			const int makeId = 0; 

            CarMake entity = CarMakeManager.Load(makeId);
            string errorMessage;
            string errorMessageExpected = string.Empty;
            const bool expected = true;
            bool actual = CarMakeManager.Validate(entity, out errorMessage);
            Assert.AreEqual(errorMessageExpected, errorMessage, "Some errors were found with CarMake object");
            Assert.AreEqual(expected, actual, "CarMake object was invalid");
        }
    }
}