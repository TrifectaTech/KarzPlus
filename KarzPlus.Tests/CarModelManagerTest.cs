// --------------------------------
// <copyright file="CarModelManagerTest.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>TODO - CHANGE AUTHOR</author>
// <summary>
//  CarModel Test Layer Object.   
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
    ///This is a test class for CarModelManagerTest and is intended
    ///to contain all CarModelManagerTest Unit Tests
    ///</summary>
    [TestClass]
    public class CarModelManagerTest
    {
        /// <summary>
        ///A test for Load
        ///</summary>
        [TestMethod]
        public void CarModelLoadTest()
        {
			// TODO - Initiate keys
            const int modelId = 0; 

            CarModel entity = CarModelManager.Load(modelId);
            Assert.IsNotNull(entity, "CarModel object was null");
        }

		/// <summary>
        ///A null test for Load
        ///</summary>
        [TestMethod]
        public void CarModelLoadNullTest()
        {
			
            List<CarModel> entity = CarModelManager.Search(null).ToList();
            Assert.IsFalse(entity.Any(), "CarModel object was null");
        }


        /// <summary>
        ///A test for Save
        ///</summary>
        [TestMethod]
        public void CarModelSaveTest()
        {
			// TODO - Initiate keys
			const int modelId = 0; 

            CarModel entity = CarModelManager.Load(modelId);
            string errorMessage;
            string errorMessageExpected = string.Empty;
            const bool expected = true;
            bool actual = CarModelManager.Save(entity, out errorMessage);
            Assert.AreEqual(errorMessageExpected, errorMessage, "Some errors were found with CarModel object");
            Assert.AreEqual(expected, actual, "Save wasn't successful");
        }

        /// <summary>
        ///A test for Validate
        ///</summary>
        [TestMethod]
        public void CarModelValidateTest()
        {
			// TODO - Initiate keys
			const int modelId = 0; 

            CarModel entity = CarModelManager.Load(modelId);
            string errorMessage;
            string errorMessageExpected = string.Empty;
            const bool expected = true;
            bool actual = CarModelManager.Validate(entity, out errorMessage);
            Assert.AreEqual(errorMessageExpected, errorMessage, "Some errors were found with CarModel object");
            Assert.AreEqual(expected, actual, "CarModel object was invalid");
        }
    }
}