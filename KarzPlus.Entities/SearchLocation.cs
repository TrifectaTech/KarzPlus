// --------------------------------
// <copyright file="SearchLocation.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>TODO - CHANGE AUTHOR</author>
// <summary>
//  SearchLocation Search Entity Object.   
// </summary>
// ---------------------------------

using System;

namespace KarzPlus.Entities
{
	/// <summary>
	/// SearchLocation search entity object. 
	/// </summary>
	[Serializable]
	public class SearchLocation
	{
        /// <summary>
        /// Gets or sets LocationId.
        /// </summary>
        public int? LocationId { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets City.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets State.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets Zip.
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// Gets or sets Deleted.
        /// </summary>
        public bool? Deleted { get; set; }

        /// <summary>
        /// Initializes a new instance of the SearchLocation class.
        /// </summary>
        public SearchLocation()
        {
            LocationId = null;
            Name = null;
            Address = null;
            City = null;
            State = null;
            Zip = null;
            Deleted = null;
        }
	}
}
