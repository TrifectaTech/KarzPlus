// --------------------------------
// <copyright file="SearchCarModel.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>JDuverge</author>
// <summary>
//  SearchCarModel Search Entity Object.   
// </summary>
// ---------------------------------

using System;

namespace KarzPlus.Entities
{
	/// <summary>
	/// SearchCarModel search entity object. 
	/// </summary>
	[Serializable]
	public class SearchCarModel
	{
        /// <summary>
        /// Gets or sets ModelId.
        /// </summary>
        public int? ModelId { get; set; }

        /// <summary>
        /// Gets or sets MakeId.
        /// </summary>
        public int? MakeId { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets CarImage.
        /// </summary>
        public byte[] CarImage { get; set; }

        /// <summary>
        /// Gets or sets Deleted.
        /// </summary>
        public bool? Deleted { get; set; }

        /// <summary>
        /// Initializes a new instance of the SearchCarModel class.
        /// </summary>
        public SearchCarModel()
        {
            ModelId = null;
            MakeId = null;
            Name = null;
            CarImage = null;
            Deleted = false;
        }
	}
}
