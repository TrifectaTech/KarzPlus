// --------------------------------
// <copyright file="TransactionManager.cs" >
//     � 2013 KarzPlus Inc. 
// </copyright>
// <author>KEscobar</author>
// <summary>
// Encapsulate business logic of Transaction.   
// </summary>
// ---------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using KarzPlus.Data;
using KarzPlus.Entities;
using KarzPlus.Entities.ExtensionMethods;

namespace KarzPlus.Business
{
    /// <summary>
    /// This class encapsulates the business logic of Transaction entity
    /// </summary>
    public static class TransactionManager
    {
        /// <summary>
        /// Searches for Transaction
        /// </summary>
        /// <param name="search" />
        /// <returns>An IEnumerable set of Transaction</returns>
        public static IEnumerable<Transaction> Search(SearchTransaction search)
        {
            return search == null ? new List<Transaction>() : TransactionDao.Search(search);
        }

        /// <summary>
        /// Loads Transaction by the id parameter
        /// </summary>
        /// <param name="transactionId">Primary Key of Transaction table</param>
        /// <returns>Transaction entity</returns>
        public static Transaction Load(int transactionId)
        {
            return Search(new SearchTransaction { TransactionId = transactionId }).FirstOrDefault();
        }

        /// <summary>
        /// Loads Transactions by InventoryId
        /// </summary>
        /// <param name="inventoryId" />
        /// <returns>An IEnumerable set of Transaction</returns>
        public static IEnumerable<Transaction> LoadByInventoryId(int inventoryId)
        {
            return Search(new SearchTransaction { InventoryId = inventoryId });
        }

        /// <summary>
        /// Calculates the total cost of the rental transaction to the customer
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public static decimal CalculateTransactionPrice(Transaction transaction)
        {
            Inventory item = InventoryManager.Load(transaction.InventoryId);

            decimal price = item.Price;

            Special foundSpecial = SpecialManager.LoadSpecialForTransaction(transaction);

            if ( foundSpecial != null)
            {
                price = foundSpecial.Price;
            }

            int amtOfDays = (transaction.RentalDateEnd - transaction.RentalDateStart).Days;

            price = (price * amtOfDays);

            return price;
        }

        /// <summary>
        /// Save Transaction Entity
        /// </summary>
        /// <param name="item">Entity to save</param>
        /// <param name="errorMessage">Error Message</param>
        /// <returns>return true if save successfully, else return false</returns>
        public static bool Save(Transaction item, out string errorMessage)
        {
            bool isValid = Validate(item, out errorMessage);

            if (isValid)
            {
                Inventory inventoryToSave = InventoryManager.Load(item.InventoryId);

                if (item.IsRentalTransactionInProgress)
                {
                    inventoryToSave.Quantity--;

                    isValid = InventoryManager.Save(inventoryToSave, out errorMessage);

                    item.Price = CalculateTransactionPrice(item);
                }

                if (isValid)
                {
                    TransactionDao.Save(item);
                }
            }

            return isValid;
        }

        /// <summary>
        /// Validate Transaction Entity
        /// </summary>
        /// <param name="item">Entity to validate</param>
        /// <param name="errorMessage">error message if validation failed</param>
        /// <returns>return true if entity passes validation logic, else return false</returns>
        public static bool Validate(Transaction item, out string errorMessage)
        {
            StringBuilder builder = new StringBuilder();

            if (item == null)
            {
                builder.AppendHtmlLine("*An unexpected error occurred. Please try again");
            }

            MembershipUser user = Membership.GetUser(item.UserId);

            if (user == null)
            {
                builder.AppendHtmlLine("*UserId must be valid");
            }

            Inventory inventory = InventoryManager.Load(item.InventoryId);

            if (inventory == null)
            {
                builder.AppendHtmlLine("*InventoryId must be valid");
            }
            else
            {
                if (item.IsRentalTransactionInProgress)
                {
                    if (inventory.Quantity == 0)
                    {
                        builder.AppendHtmlLine("*The product you selected cannot be rented at this time. Please change your selection and try again.");
                    }
                }
            }

            if (item.CreditCardNumber.IsNullOrWhiteSpace())
            {
                builder.AppendHtmlLine("*Credit Card Number is required");
            }
            else if (item.CreditCardNumber.Length != 16)
            {
                builder.AppendHtmlLine("*Credit Card Number is invalid");
            }

            if (!item.ExpirationDate.IsValidWithSqlDateStandards())
            {
                builder.AppendHtmlLine("*Expiration Date must be valid.");
            }

            if (!item.TransactionDate.IsValidWithSqlDateStandards())
            {
                builder.AppendHtmlLine("*Transaction Date must be valid");
            }

            if (!item.RentalDateStart.IsValidWithSqlDateStandards())
            {
                builder.AppendHtmlLine("*Rental DateStart must be valid");
            }

            if (!item.RentalDateEnd.IsValidWithSqlDateStandards())
            {
                builder.AppendHtmlLine("*Rental Date End must be valid");
            }

            if (item.RentalDateEnd.OnOrBefore(item.RentalDateStart))
            {
                builder.AppendHtmlLine("*Rental Date End must be after Rental Date Start");
            }

            if (!item.TransactionId.HasValue && item.ExpirationDate.Before(DateTime.Today))
            {
                builder.AppendHtmlLine("*Credit Card must not be expired");
            }

            if (item.BillingAddress.IsNullOrWhiteSpace())
            {
                builder.AppendHtmlLine("*BillingAddress is required.");
            }

            if (item.BillingCity.IsNullOrWhiteSpace())
            {
                builder.AppendHtmlLine("*BillingCity is required");
            }

            if (item.BillingState.IsNullOrWhiteSpace())
            {
                builder.AppendHtmlLine("*BillingState is required");
            }

            if (item.BillingZip.IsNullOrWhiteSpace())
            {
                builder.AppendHtmlLine("*BillingZip is required");
            }

            errorMessage = builder.ToString();

            return errorMessage.IsNullOrWhiteSpace();
        }

        /// <summary>
        /// Delete a Transaction entity
        /// </summary>
        /// <param name="transactionId">Primary Key of Transaction table</param>
        public static void Delete(int transactionId)
        {
            TransactionDao.Delete(transactionId);
        }
    }
}
