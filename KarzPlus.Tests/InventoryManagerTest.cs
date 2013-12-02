// --------------------------------
// <copyright file="InventoryManagerTest.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>JDuverge</author>
// <summary>
//  Inventory Test Layer Object.   
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
    ///This is a test class for InventoryManagerTest and is intended
    ///to contain all InventoryManagerTest Unit Tests
    ///</summary>
    [TestClass]
    public class InventoryManagerTest
    {
        /// <summary>
        ///A test for Load
        ///</summary>
        [TestMethod]
        public void InventoryLoadTest()
        {
			// TODO - Initiate keys
            const int inventoryId = 0; 

            Inventory entity = InventoryManager.Load(inventoryId);
            Assert.IsNotNull(entity, "Inventory object was null");
        }

		/// <summary>
        ///A null test for Load
        ///</summary>
        [TestMethod]
        public void InventoryLoadNullTest()
        {
			
            List<Inventory> entity = InventoryManager.Search(null).ToList();
            Assert.IsFalse(entity.Any(), "Inventory object was null");
        }


        /// <summary>
        ///A test for Save
        ///</summary>
        [TestMethod]
        public void InventorySaveTest()
        {
			// TODO - Initiate keys
			const int inventoryId = 0; 

            Inventory entity = InventoryManager.Load(inventoryId);
            string errorMessage;
            string errorMessageExpected = string.Empty;
            const bool expected = true;
            bool actual = InventoryManager.Save(entity, out errorMessage);
            Assert.AreEqual(errorMessageExpected, errorMessage, "Some errors were found with Inventory object");
            Assert.AreEqual(expected, actual, "Save wasn't successful");
        }

        /// <summary>
        ///A test for Validate
        ///</summary>
        [TestMethod]
        public void InventoryValidateTest()
        {
			// TODO - Initiate keys
			const int inventoryId = 0; 

            Inventory entity = InventoryManager.Load(inventoryId);
            string errorMessage;
            string errorMessageExpected = string.Empty;
            const bool expected = true;
            bool actual = InventoryManager.Validate(entity, out errorMessage);
            Assert.AreEqual(errorMessageExpected, errorMessage, "Some errors were found with Inventory object");
            Assert.AreEqual(expected, actual, "Inventory object was invalid");
        }
    }
}