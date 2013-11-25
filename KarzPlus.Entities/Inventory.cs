// --------------------------------
// <copyright file="Inventory.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>TODO - CHANGE AUTHOR</author>
// <summary>
//  Inventory Entity Layer Object.   
// </summary>
// ---------------------------------

using System;
using KarzPlus.Entities.Common;

namespace KarzPlus.Entities
{
	/// <summary>
	/// Inventory entity object. 
	/// </summary>
	[Serializable]
	public class Inventory
	{
		public bool IsItemModified { get; set; }

        private int? inventoryId;

        /// <summary>
        /// Gets or sets InventoryId.
        /// </summary>
        [SqlName("InventoryId")]
        public int? InventoryId
        {   
            get 
            {
                return inventoryId;
            }
            set
            {
                if (value != inventoryId)
                {
                    inventoryId = value;
                    IsItemModified = true;
                }
            }
        }

        private int modelId;

        /// <summary>
        /// Gets or sets ModelId.
        /// </summary>
        [SqlName("ModelId")]
        public int ModelId
        {   
            get 
            {
                return modelId;
            }
            set
            {
                if (value != modelId)
                {
                    modelId = value;
                    IsItemModified = true;
                }
            }
        }

        private int year;

        /// <summary>
        /// Gets or sets Year.
        /// </summary>
        [SqlName("Year")]
        public int Year
        {   
            get 
            {
                return year;
            }
            set
            {
                if (value != year)
                {
                    year = value;
                    IsItemModified = true;
                }
            }
        }

        private int quantity;

        /// <summary>
        /// Gets or sets Quantity.
        /// </summary>
        [SqlName("Quantity")]
        public int Quantity
        {   
            get 
            {
                return quantity;
            }
            set
            {
                if (value != quantity)
                {
                    quantity = value;
                    IsItemModified = true;
                }
            }
        }

        private int locationId;

        /// <summary>
        /// Gets or sets LocationId.
        /// </summary>
        [SqlName("LocationId")]
        public int LocationId
        {   
            get 
            {
                return locationId;
            }
            set
            {
                if (value != locationId)
                {
                    locationId = value;
                    IsItemModified = true;
                }
            }
        }

        private string color;

        /// <summary>
        /// Gets or sets Color.
        /// </summary>
        [SqlName("Color")]
        public string Color
        {   
            get 
            {
                return color;
            }
            set
            {
                if (value != color)
                {
                    color = value;
                    IsItemModified = true;
                }
            }
        }

        private decimal price;

        /// <summary>
        /// Gets or sets Price.
        /// </summary>
        [SqlName("Price")]
        public decimal Price
        {   
            get 
            {
                return price;
            }
            set
            {
                if (value != price)
                {
                    price = value;
                    IsItemModified = true;
                }
            }
        }

        private bool deleted;

        /// <summary>
        /// Gets or sets Deleted.
        /// </summary>
        [SqlName("Deleted")]
        public bool Deleted
        {   
            get 
            {
                return deleted;
            }
            set
            {
                if (value != deleted)
                {
                    deleted = value;
                    IsItemModified = true;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the Inventory class.
        /// </summary>
        public Inventory()
        {
            InventoryId = default(int?);
            ModelId = default(int);
            Year = default(int);
            Quantity = default(int);
            LocationId = default(int);
            Color = default(string);
            Price = default(decimal);
            Deleted = default(bool);
            IsItemModified = false;
        }

		public override string ToString()
		{
			return string.Format("InventoryId: {0}, ModelId: {1}, Year: {2}, Quantity: {3}, LocationId: {4};", InventoryId, ModelId, Year, Quantity, LocationId);
		}
	}
}
