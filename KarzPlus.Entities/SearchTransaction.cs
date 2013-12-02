// --------------------------------
// <copyright file="SearchTransaction.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>KEscobar</author>
// <summary>
//  SearchTransaction Search Entity Object.   
// </summary>
// ---------------------------------

using System;

namespace KarzPlus.Entities
{
	/// <summary>
	/// SearchTransaction search entity object. 
	/// </summary>
	[Serializable]
	public class SearchTransaction
	{
        /// <summary>
        /// Gets or sets TransactionId.
        /// </summary>
        public int? TransactionId { get; set; }

        /// <summary>
        /// Gets or sets UserId.
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Gets or sets CreditCardNumber.
        /// </summary>
        public string CreditCardNumber { get; set; }

        /// <summary>
        /// Gets or sets ExpirationDate.
        /// </summary>
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets CCV.
        /// </summary>
        public int? CCV { get; set; }

        /// <summary>
        /// Gets or sets BillingAddress.
        /// </summary>
        public string BillingAddress { get; set; }

        /// <summary>
        /// Gets or sets BillingCity.
        /// </summary>
        public string BillingCity { get; set; }

        /// <summary>
        /// Gets or sets BillingState.
        /// </summary>
        public string BillingState { get; set; }

        /// <summary>
        /// Gets or sets BillingZip.
        /// </summary>
        public string BillingZip { get; set; }

        /// <summary>
        /// Gets or sets TransactionDate.
        /// </summary>
        public DateTime? TransactionDate { get; set; }

        /// <summary>
        /// Gets or sets InventoryId.
        /// </summary>
        public int? InventoryId { get; set; }

        /// <summary>
        /// Gets or sets RentalDateStart.
        /// </summary>
        public DateTime? RentalDateStart { get; set; }

        /// <summary>
        /// Gets or sets RentalDateEnd.
        /// </summary>
        public DateTime? RentalDateEnd { get; set; }

        /// <summary>
        /// Gets or sets Price.
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Initializes a new instance of the SearchTransaction class.
        /// </summary>
        public SearchTransaction()
        {
            TransactionId = null;
            UserId = null;
            CreditCardNumber = null;
            ExpirationDate = null;
            CCV = null;
            BillingAddress = null;
            BillingCity = null;
            BillingState = null;
            BillingZip = null;
            TransactionDate = null;
            InventoryId = null;
            RentalDateStart = null;
            RentalDateEnd = null;
            Price = null;
        }
	}
}
