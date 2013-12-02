// --------------------------------
// <copyright file="CarMakeManager.cs" >
//     � 2013 KarzPlus Inc. 
// </copyright>
// <author>JDuverge</author>
// <summary>
// Encapsulate business logic of CarMake.   
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
    /// This class encapsulates the business logic of CarMake entity
    /// </summary>
    public static class CarMakeManager
    {        
        /// <summary>
        /// Searches for CarMake
        /// </summary>
        /// <param name="search" />
        /// <returns>An IEnumerable set of CarMake</returns>
        public static IEnumerable<CarMake> Search(SearchCarMake search)
        {            
			return search == null ? new List <CarMake>() : CarMakeDao.Search(search);
        }	
	     
        /// <summary>
        /// Loads CarMake by the id parameter
        /// </summary>
        /// <param name="makeId">Primary Key of CarMake table</param>
        /// <returns>CarMake entity</returns>
        public static CarMake Load(int makeId)
        {
			SearchCarMake search
				= new SearchCarMake
					{
						MakeId = makeId
					};    
			return Search(search).FirstOrDefault();
        }

        /// <summary>
        /// Save CarMake Entity
        /// </summary>
        /// <param name="item">Entity to save</param>
        /// <param name="errorMessage">Error Message</param>
		/// <returns>return true if save successfully, else return false</returns>
        public static bool Save(CarMake item, out string errorMessage)
        {
            bool isValid = Validate(item, out errorMessage);                     
            
			if (isValid)
			{
                CarMakeDao.Save(item);				
            }	        

            return isValid;
        }

        /// <summary>
        /// Validate CarMake Entity
        /// </summary>
        /// <param name="item">Entity to validate</param>
        /// <param name="errorMessage">error message if validation failed</param>
        /// <returns>return true if entity passes validation logic, else return false</returns>
        public static bool Validate(CarMake item, out string errorMessage)
        {
			errorMessage = string.Empty;

	        if (item.Name.IsNullOrWhiteSpace())
	        {
		        errorMessage += "Name is required. ";
	        }

	        if (item.Manufacturer.IsNullOrWhiteSpace())
	        {
		        errorMessage += "Manufacturer is required. ";
	        }

	        if (Search(new SearchCarMake { Name = item.Name }).SafeAny(c => c.MakeId != item.MakeId))
	        {
		        errorMessage += "Cannot have multiple car makes with the same name. ";
	        }

	        errorMessage = errorMessage.TrimSafely();
            
            return errorMessage.IsNullOrWhiteSpace();
        }

		/// <summary>
		/// Soft Delete a CarMake entity
		/// </summary>
		/// <param name="carMakeId">Primary Key of CarMake table</param>
		public static void Delete(int carMakeId)
		{
			CarMake carMake = Load(carMakeId);
			if (carMake != null)
			{
				carMake.Deleted = true;

				string errorMessage;
				Save(carMake, out errorMessage);
			}
		}

		/// <summary>
		/// Hard Delete a CarMake entity
		/// </summary>
		/// <param name="carMakeId">Primary Key of CarMake table</param>
		public static void HardDelete(int carMakeId)
		{
			CarMakeDao.Delete(carMakeId);
		}
    }
}
