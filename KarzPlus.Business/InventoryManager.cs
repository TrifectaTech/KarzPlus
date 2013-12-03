// --------------------------------
// <copyright file="InventoryManager.cs" >
//     � 2013 KarzPlus Inc. 
// </copyright>
// <author>JDuverge</author>
// <summary>
// Encapsulate business logic of Inventory.   
// </summary>
// ---------------------------------

using System.Collections.Generic;
using System.Linq;
using KarzPlus.Data;
using KarzPlus.Entities;
using KarzPlus.Entities.ExtensionMethods;

namespace KarzPlus.Business
{
	/// <summary>
	/// This class encapsulates the business logic of Inventory entity
	/// </summary>
	public static class InventoryManager
	{
		/// <summary>
		/// Searches for Inventory
		/// </summary>
		/// <param name="search" />
		/// <returns>An IEnumerable set of Inventory</returns>
		public static IEnumerable<Inventory> Search(SearchInventory search)
		{
			return search == null ? new List<Inventory>() : InventoryDao.Search(search);
		}

		/// <summary>
		/// Loads Inventory by the id parameter
		/// </summary>
		/// <param name="inventoryId">Primary Key of Inventory table</param>
		/// <returns>Inventory entity</returns>
		public static Inventory Load(int inventoryId)
		{
			SearchInventory search
				= new SearchInventory
					{
						InventoryId = inventoryId
					};
			return Search(search).FirstOrDefault();
		}

		/// <summary>
		/// Save Inventory Entity
		/// </summary>
		/// <param name="item">Entity to save</param>
		/// <param name="errorMessage">Error Message</param>
		/// <returns>return true if save successfully, else return false</returns>
		public static bool Save(Inventory item, out string errorMessage)
		{
			bool isValid = Validate(item, out errorMessage);

			if (isValid)
			{
				InventoryDao.Save(item);
			}

			return isValid;
		}

		/// <summary>
		/// Validate Inventory Entity
		/// </summary>
		/// <param name="item">Entity to validate</param>
		/// <param name="errorMessage">error message if validation failed</param>
		/// <returns>return true if entity passes validation logic, else return false</returns>
		public static bool Validate(Inventory item, out string errorMessage)
		{
			errorMessage = string.Empty;

			CarModel carModel = CarModelManager.Load(item.ModelId);
			if (carModel == null)
			{
				errorMessage += "ModelId must be valid. ";
			}

			errorMessage = errorMessage.TrimSafely();

			return errorMessage.IsNullOrWhiteSpace();
		}

		/// <summary>
		/// Soft Delete an Inventory entity
		/// </summary>
		/// <param name="inventoryId">Primary Key of Inventory table</param>
		public static void Delete(int inventoryId)
		{
			Inventory inventory = Load(inventoryId);
			if (inventory != null)
			{
				inventory.Deleted = true;

				string errorMessage;
				Save(inventory, out errorMessage);
			}
		}

		/// <summary>
		/// Hard Delete an Inventory entity
		/// </summary>
		/// <param name="inventoryId">Primary Key of Inventory table</param>
		public static void HardDelete(int inventoryId)
		{
			InventoryDao.Delete(inventoryId);
		}
	}
}
