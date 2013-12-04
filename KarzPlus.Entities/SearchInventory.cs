// --------------------------------
// <copyright file="SearchInventory.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>JDuverge</author>
// <summary>
//  SearchInventory Search Entity Object.   
// </summary>
// ---------------------------------

using System;

namespace KarzPlus.Entities
{
	/// <summary>
	/// SearchInventory search entity object. 
	/// </summary>
	[Serializable]
	public class SearchInventory
	{
        /// <summary>
        /// Gets or sets InventoryId.
        /// </summary>
        public int? InventoryId { get; set; }

        /// <summary>
        /// Gets or sets ModelId.
        /// </summary>
        public int? ModelId { get; set; }

        /// <summary>
        /// Gets or sets Year.
        /// </summary>
        public int? Year { get; set; }

        /// <summary>
        /// Gets or sets Quantity.
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Gets or sets LocationId.
        /// </summary>
        public int? LocationId { get; set; }

        /// <summary>
        /// Gets or sets Color.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets Price.
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Gets or sets Deleted.
        /// </summary>
        public bool? Deleted { get; set; }

        /// <summary>
        /// Initializes a new instance of the SearchInventory class.
        /// </summary>
        public SearchInventory()
        {
            InventoryId = null;
            ModelId = null;
            Year = null;
            Quantity = null;
            LocationId = null;
            Color = null;
            Price = null;
            Deleted = false;
        }
	}
}
