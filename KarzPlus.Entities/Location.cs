// --------------------------------
// <copyright file="Location.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>JOrtega</author>
// <summary>
//  Location Entity Layer Object.   
// </summary>
// ---------------------------------

using System;
using KarzPlus.Entities.Common;

namespace KarzPlus.Entities
{
	/// <summary>
	/// Location entity object. 
	/// </summary>
	[Serializable]
	public class Location
	{
		public bool IsItemModified { get; set; }

        private int? locationId;

        /// <summary>
        /// Gets or sets LocationId.
        /// </summary>
        [SqlName("LocationId")]
        public int? LocationId
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

        private string address;

        /// <summary>
        /// Gets or sets Address.
        /// </summary>
        [SqlName("Address")]
        public string Address
        {   
            get 
            {
                return address;
            }
            set
            {
                if (value != address)
                {
                    address = value;
                    IsItemModified = true;
                }
            }
        }

        private string city;

        /// <summary>
        /// Gets or sets City.
        /// </summary>
        [SqlName("City")]
        public string City
        {   
            get 
            {
                return city;
            }
            set
            {
                if (value != city)
                {
                    city = value;
                    IsItemModified = true;
                }
            }
        }

        private string state;

        /// <summary>
        /// Gets or sets State.
        /// </summary>
        [SqlName("State")]
        public string State
        {   
            get 
            {
                return state;
            }
            set
            {
                if (value != state)
                {
                    state = value;
                    IsItemModified = true;
                }
            }
        }

        private string zip;

        /// <summary>
        /// Gets or sets Zip.
        /// </summary>
        [SqlName("Zip")]
        public string Zip
        {   
            get 
            {
                return zip;
            }
            set
            {
                if (value != zip)
                {
                    zip = value;
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

		private string phone;

		/// <summary>
		/// Gets or sets Phone
		/// </summary>
		[SqlName("Phone")]
		public string Phone
		{
			get
			{
				return phone;
			}
			set
			{
				if (value != phone)
				{
					phone = value;
					IsItemModified = true;
				}
			}
		}

		private string email;

		/// <summary>
		/// Gets or sets Email
		/// </summary>
		[SqlName("Email")]
		public string Email
		{
			get
			{
				return email;
			}
			set
			{
				if (value != email)
				{
					email = value;
					IsItemModified = true;
				}
			}
		}

        /// <summary>
        /// Initializes a new instance of the Location class.
        /// </summary>
        public Location()
        {
            LocationId = default(int?);
            Name = default(string);
            Address = default(string);
            City = default(string);
            State = default(string);
            Zip = default(string);
	        Phone = default(string);
	        Email = default(string);
            Deleted = default(bool);
            IsItemModified = false;
        }

		public override string ToString()
		{
			return string.Format("LocationId: {0}, Name: {1}, City: {2}, State: {3};", LocationId, Name, City, State);
		}
	}
}
