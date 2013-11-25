// --------------------------------
// <copyright file="SearchCarMake.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>TODO - CHANGE AUTHOR</author>
// <summary>
//  SearchCarMake Search Entity Object.   
// </summary>
// ---------------------------------

using System;

namespace KarzPlus.Entities
{
	/// <summary>
	/// SearchCarMake search entity object. 
	/// </summary>
	[Serializable]
	public class SearchCarMake
	{
        /// <summary>
        /// Gets or sets MakeId.
        /// </summary>
        public int? MakeId { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Manufacturer.
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets Deleted.
        /// </summary>
        public bool? Deleted { get; set; }

        /// <summary>
        /// Initializes a new instance of the SearchCarMake class.
        /// </summary>
        public SearchCarMake()
        {
            MakeId = null;
            Name = null;
            Manufacturer = null;
            Deleted = null;
        }
	}
}
