// --------------------------------
// <copyright file="SearchSpecial.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>JOrtega</author>
// <summary>
//  SearchSpecial Search Entity Object.   
// </summary>
// ---------------------------------

using System;

namespace KarzPlus.Entities
{
	/// <summary>
	/// SearchSpecial search entity object. 
	/// </summary>
	[Serializable]
	public class SearchSpecial
	{
        /// <summary>
        /// Gets or sets SpecialId.
        /// </summary>
        public int? SpecialId { get; set; }

        /// <summary>
        /// Gets or sets InventoryId.
        /// </summary>
        public int? InventoryId { get; set; }

        /// <summary>
        /// Gets or sets DateStart.
        /// </summary>
        public DateTime? DateStart { get; set; }

        /// <summary>
        /// Gets or sets DateEnd.
        /// </summary>
        public DateTime? DateEnd { get; set; }

        /// <summary>
        /// Gets or sets Price.
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Initializes a new instance of the SearchSpecial class.
        /// </summary>
        public SearchSpecial()
        {
            SpecialId = null;
            InventoryId = null;
            DateStart = null;
            DateEnd = null;
            Price = null;
        }
	}
}
