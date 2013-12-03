// --------------------------------
// <copyright file="CarModel.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>JDuverge</author>
// <summary>
//  CarModel Entity Layer Object.   
// </summary>
// ---------------------------------

using System;
using KarzPlus.Entities.Common;

namespace KarzPlus.Entities
{
	/// <summary>
	/// CarModel entity object. 
	/// </summary>
	[Serializable]
	public class CarModel
	{
		public bool IsItemModified { get; set; }


        private int? modelId;

        /// <summary>
        /// Gets or sets ModelId.
        /// </summary>
        [SqlName("ModelId")]
        public int? ModelId
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

        private int makeId;

        /// <summary>
        /// Gets or sets MakeId.
        /// </summary>
        [SqlName("MakeId")]
        public int MakeId
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

        private byte[] carImage;

        /// <summary>
        /// Gets or sets CarImage.
        /// </summary>
        [SqlName("CarImage")]
        public byte[] CarImage
        {   
            get 
            {
                return carImage;
            }
            set
            {
                if (value != carImage)
                {
                    carImage = value;
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
        /// Initializes a new instance of the CarModel class.
        /// </summary>
        public CarModel()
        {
            ModelId = default(int?);
            MakeId = default(int);
            Name = default(string);
            CarImage = default(byte[]);
            Deleted = default(bool);
            IsItemModified = false;
        }

		public override string ToString()
		{
			return string.Format("ModelId: {0}, MakeId: {1}, Name: {2};", ModelId, MakeId, Name);
		}
	}
}
