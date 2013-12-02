// --------------------------------
// <copyright file="CarModelManager.cs" >
//     � 2013 KarzPlus Inc. 
// </copyright>
// <author>JDuverge</author>
// <summary>
// Encapsulate business logic of CarModel.   
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
    /// This class encapsulates the business logic of CarModel entity
    /// </summary>
    public static class CarModelManager
    {        
        /// <summary>
        /// Searches for CarModel
        /// </summary>
        /// <param name="search" />
        /// <returns>An IEnumerable set of CarModel</returns>
        public static IEnumerable<CarModel> Search(SearchCarModel search)
        {            
			return search == null ? new List <CarModel>() : CarModelDao.Search(search);
        }	
	     
        /// <summary>
        /// Loads CarModel by the id parameter
        /// </summary>
        /// <param name="modelId">Primary Key of CarModel table</param>
        /// <returns>CarModel entity</returns>
        public static CarModel Load(int modelId)
        {
			SearchCarModel search
				= new SearchCarModel
					{
						ModelId = modelId
					};    
			return Search(search).FirstOrDefault();
        }

        /// <summary>
        /// Save CarModel Entity
        /// </summary>
        /// <param name="item">Entity to save</param>
        /// <param name="errorMessage">Error Message</param>
		/// <returns>return true if save successfully, else return false</returns>
        public static bool Save(CarModel item, out string errorMessage)
        {
            bool isValid = Validate(item, out errorMessage);                     
            
			if (isValid)
			{
                CarModelDao.Save(item);				
            }	        

            return isValid;
        }

        /// <summary>
        /// Validate CarModel Entity
        /// </summary>
        /// <param name="item">Entity to validate</param>
        /// <param name="errorMessage">error message if validation failed</param>
        /// <returns>return true if entity passes validation logic, else return false</returns>
        public static bool Validate(CarModel item, out string errorMessage)
        {
			errorMessage = string.Empty;

	        CarMake carMake = CarMakeManager.Load(item.MakeId);
	        if (carMake == null)
	        {
		        errorMessage += "MakeId must be valid. ";
	        }

	        if (item.Name.IsNullOrWhiteSpace())
	        {
		        errorMessage += "Name is required. ";
	        }

	        if (Search(new SearchCarModel
							{
								Name = item.Name,
								MakeId = item.MakeId
							}).SafeAny(c => c.ModelId != item.ModelId))
	        {
		        errorMessage += "Cannot have multiple car models with the same name from the same make. ";
	        }

	        errorMessage = errorMessage.TrimSafely();
            
            return errorMessage.IsNullOrWhiteSpace();
        }

		/// <summary>
		/// Soft Delete a CarModel entity
		/// </summary>
		/// <param name="carModelId">Primary Key of CarModel table</param>
		public static void Delete(int carModelId)
		{
			CarModel carModel = Load(carModelId);
			if (carModel != null)
			{
				carModel.Deleted = true;

				string errorMessage;
				Save(carModel, out errorMessage);
			}
		}

		/// <summary>
		/// Hard Delete a CarModel entity
		/// </summary>
		/// <param name="carModelId">Primary Key of CarModel table</param>
		public static void HardDelete(int carModelId)
		{
			CarModelDao.Delete(carModelId);
		}
    }
}
