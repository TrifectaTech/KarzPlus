// --------------------------------
// <copyright file="Special.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>TODO - CHANGE AUTHOR</author>
// <summary>
//  Special Entity Layer Object.   
// </summary>
// ---------------------------------

using System;
using KarzPlus.Entities.Common;

namespace KarzPlus.Entities
{
	/// <summary>
	/// Special entity object. 
	/// </summary>
	[Serializable]
	public class Special
	{
		public bool IsItemModified { get; set; }

        private int? specialId;

        /// <summary>
        /// Gets or sets SpecialId.
        /// </summary>
        [SqlName("SpecialId")]
        public int? SpecialId
        {   
            get 
            {
                return specialId;
            }
            set
            {
                if (value != specialId)
                {
                    specialId = value;
                    IsItemModified = true;
                }
            }
        }

        private int inventoryId;

        /// <summary>
        /// Gets or sets InventoryId.
        /// </summary>
        [SqlName("InventoryId")]
        public int InventoryId
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

        private DateTime dateStart;

        /// <summary>
        /// Gets or sets DateStart.
        /// </summary>
        [SqlName("DateStart")]
        public DateTime DateStart
        {   
            get 
            {
                return dateStart;
            }
            set
            {
                if (value != dateStart)
                {
                    dateStart = value;
                    IsItemModified = true;
                }
            }
        }

        private DateTime dateEnd;

        /// <summary>
        /// Gets or sets DateEnd.
        /// </summary>
        [SqlName("DateEnd")]
        public DateTime DateEnd
        {   
            get 
            {
                return dateEnd;
            }
            set
            {
                if (value != dateEnd)
                {
                    dateEnd = value;
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

        /// <summary>
        /// Initializes a new instance of the Special class.
        /// </summary>
        public Special()
        {
            SpecialId = default(int?);
            InventoryId = default(int);
            DateStart = default(DateTime);
            DateEnd = default(DateTime);
            Price = default(decimal);
            IsItemModified = false;
        }

		public override string ToString()
		{
			return string.Format("SpecialId: {0}, InventoryId: {1}, Price: {2};", SpecialId, InventoryId, Price);
		}
	}
}
