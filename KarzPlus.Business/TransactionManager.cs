// --------------------------------
// <copyright file="TransactionManager.cs" >
//     � 2013 KarzPlus Inc. 
// </copyright>
// <author>KEscobar</author>
// <summary>
// Encapsulate business logic of Transaction.   
// </summary>
// ---------------------------------

using System.Collections.Generic;
using System.Linq;
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
			SearchTransaction search
				= new SearchTransaction
					{
						TransactionId = transactionId
					};
			return Search(search).FirstOrDefault();
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
				TransactionDao.Save(item);
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
			errorMessage = string.Empty;

			MembershipUser user = Membership.GetUser(item.UserId);
			if (user == null)
			{
				errorMessage += "UserId must be valid. ";
			}

			Inventory inventory = InventoryManager.Load(item.InventoryId);
			if (inventory == null)
			{
				errorMessage += "InventoryId must be valid. ";
			}

			if (!item.ExpirationDate.IsValidWithSqlDateStandards())
			{
				errorMessage += "ExpirationDate must be valid. ";
			}

			if (!item.TransactionDate.IsValidWithSqlDateStandards())
			{
				errorMessage += "TransactionDate must be valid. ";
			}

			if (!item.RentalDateStart.IsValidWithSqlDateStandards())
			{
				errorMessage += "RentalDateStart must be valid. ";
			}

			if (!item.RentalDateEnd.IsValidWithSqlDateStandards())
			{
				errorMessage += "RentalDateEnd must be valid. ";
			}

			errorMessage = errorMessage.TrimSafely();

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
