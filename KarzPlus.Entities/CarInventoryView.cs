// --------------------------------
// <copyright file="Inventory.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>Kenneth Escobar</author>
// <summary>
//  Inventory Entity Layer Object.   
// </summary>
// ---------------------------------

using System;
using KarzPlus.Entities.Common;

namespace KarzPlus.Entities
{
	/// <summary>
	/// CarInventoryView entity object. 
	/// </summary>
	[Serializable]
    public class CarInventoryView
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
        /// Gets or sets CarYear.
        /// </summary>
        public int? CarYear { get; set; }

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
        /// Gets or sets InventoryDeleted.
        /// </summary>
        public bool? InventoryDeleted { get; set; }

        /// <summary>
        /// Gets or sets MakeName.
        /// </summary>
        public string MakeName { get; set; }

        /// <summary>
        /// Gets or sets Manufacturer.
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets MakeDeleted.
        /// </summary>
        public bool? MakeDeleted { get; set; }

        /// <summary>
        /// Gets or sets MakeId.
        /// </summary>
        public int? MakeId { get; set; }

        /// <summary>
        /// Gets or sets ModelName.
        /// </summary>
        public string ModelName { get; set; }

        /// <summary>
        /// Gets or sets CarImage.
        /// </summary>
        public byte[] CarImage { get; set; }

        /// <summary>
        /// Gets or sets ModelDeleted.
        /// </summary>
        public bool? ModelDeleted { get; set; }		

        /// <summary>
        /// Gets or sets LocationName.
        /// </summary>
        public string LocationName { get; set; }

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
        public bool? LocationDeleted { get; set; }

        public string FullAddress { get { return string.Format("Location Name- {0} Address: {1} {2}, {3}, {4}", LocationName ,Address, City, State, Zip, LocationId); } }


        /// <summary>
        /// Initializes a new instance of the CarInventoryView class.
        /// </summary>
        public CarInventoryView()
        {
            InventoryId = default(int?);
            ModelId = default(int?);
            CarYear = default(int?);
            Quantity = default(int?);
            LocationId = default(int?);
            Color = default(string);
            Price = default(decimal?);
            InventoryDeleted = default(bool?);
            MakeName = default(string);
            Manufacturer = default(string);
            MakeDeleted = default(bool?);
            MakeId = default(int?);
            ModelName= default(string);
            CarImage = default(byte[]);
            ModelDeleted = default(bool?);
            LocationName = default(string);
            Address = default(string);
            City = default(string);
            State = default(string);
            Zip = default(string);
            LocationDeleted = default(bool?);
        }

		public override string ToString()
		{
			return string.Format("InventoryId: {0}, ModelId: {1}, Year: {2}, Quantity: {3}, LocationId: {4};", InventoryId, ModelId, CarYear, Quantity, LocationId);
		}
	}
    
}
