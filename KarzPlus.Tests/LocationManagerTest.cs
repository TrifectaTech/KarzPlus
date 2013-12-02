// --------------------------------
// <copyright file="LocationManagerTest.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>JOrtega</author>
// <summary>
//  Location Test Layer Object.   
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
    ///This is a test class for LocationManagerTest and is intended
    ///to contain all LocationManagerTest Unit Tests
    ///</summary>
    [TestClass]
    public class LocationManagerTest
    {
        /// <summary>
        ///A test for Load
        ///</summary>
        [TestMethod]
        public void LocationLoadTest()
        {
			// TODO - Initiate keys
            const int locationId = 0; 

            Location entity = LocationManager.Load(locationId);
            Assert.IsNotNull(entity, "Location object was null");
        }

		/// <summary>
        ///A null test for Load
        ///</summary>
        [TestMethod]
        public void LocationLoadNullTest()
        {
			
            List<Location> entity = LocationManager.Search(null).ToList();
            Assert.IsFalse(entity.Any(), "Location object was null");
        }


        /// <summary>
        ///A test for Save
        ///</summary>
        [TestMethod]
        public void LocationSaveTest()
        {
			// TODO - Initiate keys
			const int locationId = 0; 

            Location entity = LocationManager.Load(locationId);
            string errorMessage;
            string errorMessageExpected = string.Empty;
            const bool expected = true;
            bool actual = LocationManager.Save(entity, out errorMessage);
            Assert.AreEqual(errorMessageExpected, errorMessage, "Some errors were found with Location object");
            Assert.AreEqual(expected, actual, "Save wasn't successful");
        }

        /// <summary>
        ///A test for Validate
        ///</summary>
        [TestMethod]
        public void LocationValidateTest()
        {
			// TODO - Initiate keys
			const int locationId = 0; 

            Location entity = LocationManager.Load(locationId);
            string errorMessage;
            string errorMessageExpected = string.Empty;
            const bool expected = true;
            bool actual = LocationManager.Validate(entity, out errorMessage);
            Assert.AreEqual(errorMessageExpected, errorMessage, "Some errors were found with Location object");
            Assert.AreEqual(expected, actual, "Location object was invalid");
        }
    }
}