// --------------------------------
// <copyright file="SearchPaymentInfo.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>KEscobar</author>
// <summary>
//  SearchPaymentInfo Search Entity Object.   
// </summary>
// ---------------------------------

using System;

namespace KarzPlus.Entities
{
	/// <summary>
	/// SearchPaymentInfo search entity object. 
	/// </summary>
	[Serializable]
	public class SearchPaymentInfo
	{
        /// <summary>
        /// Gets or sets PaymentInfoId.
        /// </summary>
        public int? PaymentInfoId { get; set; }

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
        /// Initializes a new instance of the SearchPaymentInfo class.
        /// </summary>
        public SearchPaymentInfo()
        {
            PaymentInfoId = null;
            UserId = null;
            CreditCardNumber = null;
            ExpirationDate = null;
            CCV = null;
            BillingAddress = null;
            BillingCity = null;
            BillingState = null;
            BillingZip = null;
        }
	}
}
