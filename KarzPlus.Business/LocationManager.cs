// --------------------------------
// <copyright file="LocationManager.cs" >
//     � 2013 KarzPlus Inc. 
// </copyright>
// <author>TODO - CHANGE AUTHOR</author>
// <summary>
// Encapsulate business logic of Location.   
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
    /// This class encapsulates the business logic of Location entity
    /// </summary>
    public static class LocationManager
    {        
        /// <summary>
        /// Searches for Location
        /// </summary>
        /// <param name="search" />
        /// <returns>An IEnumerable set of Location</returns>
        public static IEnumerable<Location> Search(SearchLocation search)
        {            
			return search == null ? new List <Location>() : LocationDao.Search(search);
        }	
	     
        /// <summary>
        /// Loads Location by the id parameter
        /// </summary>
        /// <param name="locationId">Primary Key of Location table</param>
        /// <returns>Location entity</returns>
        public static Location Load(int locationId)
        {
			SearchLocation search
				= new SearchLocation
					{
						LocationId = locationId
					};    
			return Search(search).FirstOrDefault();
        }

        /// <summary>
        /// Save Location Entity
        /// </summary>
        /// <param name="item">Entity to save</param>
        /// <param name="errorMessage">Error Message</param>
		/// <returns>return true if save successfully, else return false</returns>
        public static bool Save(Location item, out string errorMessage)
        {
            bool isValid = Validate(item, out errorMessage);                     
            
			if (isValid)
			{
                LocationDao.Save(item);				
            }	        

            return isValid;
        }

        /// <summary>
        /// Validate Location Entity
        /// </summary>
        /// <param name="item">Entity to validate</param>
        /// <param name="errorMessage">error message if validation failed</param>
        /// <returns>return true if entity passes validation logic, else return false</returns>
        public static bool Validate(Location item, out string errorMessage)
        {		
			errorMessage = string.Empty;

	        if (item.Name.IsNullOrWhiteSpace())
	        {
		        errorMessage += "Name is required. ";
	        }

	        if (item.Address.IsNullOrWhiteSpace())
	        {
		        errorMessage += "Address is required. ";
	        }

	        if (item.City.IsNullOrWhiteSpace())
	        {
		        errorMessage += "City is required. ";
	        }

	        if (item.State.IsNullOrWhiteSpace())
	        {
		        errorMessage += "State is required. ";
	        }

	        if (item.Zip.IsNullOrWhiteSpace())
	        {
		        errorMessage += "Zip is required. ";
	        }
			
			errorMessage = errorMessage.TrimSafely();
            
            return errorMessage.IsNullOrWhiteSpace();
        }

	    /// <summary>
	    /// Soft Delete a Location entity
	    /// </summary>
	    /// <param name="locationId">Primary Key of Location table</param>
	    public static void Delete(int locationId)
	    {
		    Location location = Load(locationId);
		    if (location != null)
		    {
			    location.Deleted = true;

			    string errorMessage;
			    Save(location, out errorMessage);
		    }
	    }

        /// <summary>
        /// Hard Delete a Location entity
        /// </summary>
        /// <param name="locationId">Primary Key of Location table</param>
        public static void HardDelete(int locationId)
        {            
            LocationDao.Delete(locationId);            
        }
    }
}
