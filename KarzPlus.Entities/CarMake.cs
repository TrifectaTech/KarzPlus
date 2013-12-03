// --------------------------------
// <copyright file="CarMake.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>JDuverge</author>
// <summary>
//  CarMake Entity Layer Object.   
// </summary>
// ---------------------------------

using System;
using KarzPlus.Entities.Common;

namespace KarzPlus.Entities
{
	/// <summary>
	/// CarMake entity object. 
	/// </summary>
	[Serializable]
	public class CarMake
	{
		public bool IsItemModified { get; set; }

        private int? makeId;

        /// <summary>
        /// Gets or sets MakeId.
        /// </summary>
        [SqlName("MakeId")]
        public int? MakeId
        {   
            get 
            {
                return makeId;
            }
            set
            {
                if (value != makeId)
                {
                    makeId = value;
                    IsItemModified = true;
                }
            }
        }

        private string name;

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [SqlName("Name")]
        public string Name
        {   
            get 
            {
                return name;
            }
            set
            {
                if (value != name)
                {
                    name = value;
                    IsItemModified = true;
                }
            }
        }

        private string manufacturer;

        /// <summary>
        /// Gets or sets Manufacturer.
        /// </summary>
        [SqlName("Manufacturer")]
        public string Manufacturer
        {   
            get 
            {
                return manufacturer;
            }
            set
            {
                if (value != manufacturer)
                {
                    manufacturer = value;
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
        /// Initializes a new instance of the CarMake class.
        /// </summary>
        public CarMake()
        {
            MakeId = default(int?);
            Name = default(string);
            Manufacturer = default(string);
            Deleted = default(bool);
            IsItemModified = false;
        }

		public override string ToString()
		{
			return string.Format("MakeId: {0}, Name: {1}, Manufacturer: {2};", MakeId, Name, Manufacturer);
		}
	}
}
