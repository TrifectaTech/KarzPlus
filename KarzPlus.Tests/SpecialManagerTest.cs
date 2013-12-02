// --------------------------------
// <copyright file="SpecialManagerTest.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>JOrtega</author>
// <summary>
//  Special Test Layer Object.   
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
    ///This is a test class for SpecialManagerTest and is intended
    ///to contain all SpecialManagerTest Unit Tests
    ///</summary>
    [TestClass]
    public class SpecialManagerTest
    {
        /// <summary>
        ///A test for Load
        ///</summary>
        [TestMethod]
        public void SpecialLoadTest()
        {
			// TODO - Initiate keys
            const int specialId = 0; 

            Special entity = SpecialManager.Load(specialId);
            Assert.IsNotNull(entity, "Special object was null");
        }

		/// <summary>
        ///A null test for Load
        ///</summary>
        [TestMethod]
        public void SpecialLoadNullTest()
        {
			
            List<Special> entity = SpecialManager.Search(null).ToList();
            Assert.IsFalse(entity.Any(), "Special object was null");
        }


        /// <summary>
        ///A test for Save
        ///</summary>
        [TestMethod]
        public void SpecialSaveTest()
        {
			// TODO - Initiate keys
			const int specialId = 0; 

            Special entity = SpecialManager.Load(specialId);
            string errorMessage;
            string errorMessageExpected = string.Empty;
            const bool expected = true;
            bool actual = SpecialManager.Save(entity, out errorMessage);
            Assert.AreEqual(errorMessageExpected, errorMessage, "Some errors were found with Special object");
            Assert.AreEqual(expected, actual, "Save wasn't successful");
        }

        /// <summary>
        ///A test for Validate
        ///</summary>
        [TestMethod]
        public void SpecialValidateTest()
        {
			// TODO - Initiate keys
			const int specialId = 0; 

            Special entity = SpecialManager.Load(specialId);
            string errorMessage;
            string errorMessageExpected = string.Empty;
            const bool expected = true;
            bool actual = SpecialManager.Validate(entity, out errorMessage);
            Assert.AreEqual(errorMessageExpected, errorMessage, "Some errors were found with Special object");
            Assert.AreEqual(expected, actual, "Special object was invalid");
        }
    }
}