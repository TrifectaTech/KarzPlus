﻿// --------------------------------
// <copyright file="PaymentInfo.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>KEscobar</author>
// <summary>
//  PaymentInfo Entity Layer Object.   
// </summary>
// ---------------------------------

using System;
using KarzPlus.Entities.Common;
using KarzPlus.Entities.ExtensionMethods;

namespace KarzPlus.Entities
{
	/// <summary>
	/// PaymentInfo entity object. 
	/// </summary>
	[Serializable]
	public class PaymentInfo
	{
		public bool IsItemModified { get; set; }

        private int? paymentInfoId;

        /// <summary>
        /// Gets or sets PaymentInfoId.
        /// </summary>
        [SqlName("PaymentInfoId")]
        public int? PaymentInfoId
        {   
            get 
            {
                return paymentInfoId;
            }
            set
            {
                if (value != paymentInfoId)
                {
                    paymentInfoId = value;
                    IsItemModified = true;
                }
            }
        }

        private Guid userId;

        /// <summary>
        /// Gets or sets UserId.
        /// </summary>
        [SqlName("UserId")]
        public Guid UserId
        {   
            get 
            {
                return userId;
            }
            set
            {
                if (value != userId)
                {
                    userId = value;
                    IsItemModified = true;
                }
            }
        }

        private string creditCardNumber;

        /// <summary>
        /// Gets or sets CreditCardNumber.
        /// </summary>
        [SqlName("CreditCardNumber")]
        public string CreditCardNumber
        {   
            get 
            {
                return creditCardNumber;
            }
            set
            {
                if (value != creditCardNumber)
                {
                    creditCardNumber = value;
                    IsItemModified = true;
                }
            }
        }

        private DateTime expirationDate;

        /// <summary>
        /// Gets or sets ExpirationDate.
        /// </summary>
        [SqlName("ExpirationDate")]
        public DateTime ExpirationDate
        {   
            get 
            {
                return expirationDate;
            }
            set
            {
                if (value != expirationDate)
                {
                    expirationDate = value;
                    IsItemModified = true;
                }
            }
        }

        private int ccv;

        /// <summary>
        /// Gets or sets CCV.
        /// </summary>
        [SqlName("CCV")]
        public int CCV
        {   
            get 
            {
                return ccv;
            }
            set
            {
                if (value != ccv)
                {
                    ccv = value;
                    IsItemModified = true;
                }
            }
        }

        private string billingAddress;

        /// <summary>
        /// Gets or sets BillingAddress.
        /// </summary>
        [SqlName("BillingAddress")]
        public string BillingAddress
        {   
            get 
            {
                return billingAddress;
            }
            set
            {
                if (value != billingAddress)
                {
                    billingAddress = value;
                    IsItemModified = true;
                }
            }
        }

        private string billingCity;

        /// <summary>
        /// Gets or sets BillingCity.
        /// </summary>
        [SqlName("BillingCity")]
        public string BillingCity
        {   
            get 
            {
                return billingCity;
            }
            set
            {
                if (value != billingCity)
                {
                    billingCity = value;
                    IsItemModified = true;
                }
            }
        }

        private string billingState;

        /// <summary>
        /// Gets or sets BillingState.
        /// </summary>
        [SqlName("BillingState")]
        public string BillingState
        {   
            get 
            {
                return billingState;
            }
            set
            {
                if (value != billingState)
                {
                    billingState = value;
                    IsItemModified = true;
                }
            }
        }

        private string billingZip;

        /// <summary>
        /// Gets or sets BillingZip.
        /// </summary>
        [SqlName("BillingZip")]
        public string BillingZip
        {   
            get 
            {
                return billingZip;
            }
            set
            {
                if (value != billingZip)
                {
                    billingZip = value;
                    IsItemModified = true;
                }
            }
        }

        public string PaymentInfoDisplay
        {
            get
            {
                return string.Format("CCNumber-ExpDate: {0}-{1} ; BillingAddress: {2}, Zip: {3};",
                    CreditCardNumber.Suffix(4), ExpirationDate.Date.ToShortDateString(), BillingAddress, BillingZip);
            }
        }

        /// <summary>
        /// Initializes a new instance of the PaymentInfo class.
        /// </summary>
        public PaymentInfo()
        {
            PaymentInfoId = default(int?);
            UserId = default(Guid);
            CreditCardNumber = default(string);
            ExpirationDate = default(DateTime);
            CCV = default(int);
            BillingAddress = default(string);
            BillingCity = default(string);
            BillingState = default(string);
            BillingZip = default(string);
            IsItemModified = false;
        }

		public override string ToString()
		{
			return string.Format("PaymentInfoId: {0}, UserId: {1};", PaymentInfoId, UserId);
		}
	}
}
