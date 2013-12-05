// --------------------------------
// <copyright file="Transaction.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>KEscobar</author>
// <summary>
//  Transaction Entity Layer Object.   
// </summary>
// ---------------------------------

using System;
using KarzPlus.Entities.Common;

namespace KarzPlus.Entities
{
	/// <summary>
	/// Transaction entity object. 
	/// </summary>
	[Serializable]
	public class Transaction
	{
		public bool IsItemModified { get; set; }

        /// <summary>
        /// Flag indicating this transaction entity is an actual rental order being saved
        /// </summary>
        public bool IsRentalTransactionInProgress { get; set; }

        private int? transactionId;

        /// <summary>
        /// Gets or sets TransactionId.
        /// </summary>
        [SqlName("TransactionId")]
        public int? TransactionId
        {   
            get 
            {
                return transactionId;
            }
            set
            {
                if (value != transactionId)
                {
                    transactionId = value;
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

        private DateTime transactionDate;

        /// <summary>
        /// Gets or sets TransactionDate.
        /// </summary>
        [SqlName("TransactionDate")]
        public DateTime TransactionDate
        {   
            get 
            {
                return transactionDate;
            }
            set
            {
                if (value != transactionDate)
                {
                    transactionDate = value;
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

        private DateTime rentalDateStart;

        /// <summary>
        /// Gets or sets RentalDateStart.
        /// </summary>
        [SqlName("RentalDateStart")]
        public DateTime RentalDateStart
        {   
            get 
            {
                return rentalDateStart;
            }
            set
            {
                if (value != rentalDateStart)
                {
                    rentalDateStart = value;
                    IsItemModified = true;
                }
            }
        }

        private DateTime rentalDateEnd;

        /// <summary>
        /// Gets or sets RentalDateEnd.
        /// </summary>
        [SqlName("RentalDateEnd")]
        public DateTime RentalDateEnd
        {   
            get 
            {
                return rentalDateEnd;
            }
            set
            {
                if (value != rentalDateEnd)
                {
                    rentalDateEnd = value;
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
        /// Initializes a new instance of the Transaction class.
        /// </summary>
        public Transaction()
        {
            TransactionId = default(int?);
            UserId = default(Guid);
            CreditCardNumber = default(string);
            ExpirationDate = default(DateTime);
            CCV = default(int);
            BillingAddress = default(string);
            BillingCity = default(string);
            BillingState = default(string);
            BillingZip = default(string);
            TransactionDate = default(DateTime);
            InventoryId = default(int);
            RentalDateStart = default(DateTime);
            RentalDateEnd = default(DateTime);
            Price = default(decimal);
            IsItemModified = false;
        }

		public override string ToString()
		{
			return string.Format("TransactionId: {0}, UserId: {1}, TransactionDate: {2}, InventoryId: {3};", TransactionId, UserId, TransactionDate, InventoryId);
		}
	}
}
