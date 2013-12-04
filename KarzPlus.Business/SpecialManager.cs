// --------------------------------
// <copyright file="SpecialManager.cs" >
//     � 2013 KarzPlus Inc. 
// </copyright>
// <author>JOrtega</author>
// <summary>
// Encapsulate business logic of Special.   
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
    /// This class encapsulates the business logic of Special entity
    /// </summary>
    public static class SpecialManager
    {        
        /// <summary>
        /// Searches for Special
        /// </summary>
        /// <param name="search" />
        /// <returns>An IEnumerable set of Special</returns>
        public static IEnumerable<Special> Search(SearchSpecial search)
        {            
			return search == null ? new List <Special>() : SpecialDao.Search(search);
        }	
	     
        /// <summary>
        /// Loads Special by the id parameter
        /// </summary>
        /// <param name="specialId">Primary Key of Special table</param>
        /// <returns>Special entity</returns>
        public static Special Load(int specialId)
        {
			SearchSpecial search
				= new SearchSpecial
					{
						SpecialId = specialId
					};    
			return Search(search).FirstOrDefault();
        }

        /// <summary>
        /// Save Special Entity
        /// </summary>
        /// <param name="item">Entity to save</param>
        /// <param name="errorMessage">Error Message</param>
		/// <returns>return true if save successfully, else return false</returns>
        public static bool Save(Special item, out string errorMessage)
        {
            bool isValid = Validate(item, out errorMessage);                     
            
			if (isValid)
			{
                SpecialDao.Save(item);				
            }	        

            return isValid;
        }

        /// <summary>
        /// Validate Special Entity
        /// </summary>
        /// <param name="item">Entity to validate</param>
        /// <param name="errorMessage">error message if validation failed</param>
        /// <returns>return true if entity passes validation logic, else return false</returns>
        public static bool Validate(Special item, out string errorMessage)
        {
			errorMessage = string.Empty;
	        
			Inventory inventory = InventoryManager.Load(item.InventoryId);
	        if (inventory == null)
	        {
		        errorMessage += "InventoryId must be valid. ";
	        }

			if (!item.DateStart.IsValidWithSqlDateStandards())
			{
				errorMessage += "DateStart must be valid. ";
			}

			if (!item.DateEnd.IsValidWithSqlDateStandards())
			{
				errorMessage += "DateEnd must be valid. ";
			}

			errorMessage = errorMessage.TrimSafely();
            
            return errorMessage.IsNullOrWhiteSpace();
        }

        /// <summary>
        /// Delete a Special entity
        /// </summary>
        /// <param name="specialId">Primary Key of Special table</param>
        public static void Delete(int specialId)
        {            
            SpecialDao.Delete(specialId);            
        }

        /// <summary>
        /// Loads all specials
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Special> LoadAll()
        {
            SearchSpecial searchSpecial = new SearchSpecial();

            return Search(searchSpecial);
        }
    }
}
