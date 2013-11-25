// --------------------------------
// <copyright file="TransactionDao.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>TODO - CHANGE AUTHOR</author>
// <summary>
//  Transaction Data Layer Object.   
// </summary>
// ---------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using KarzPlus.Data.Common;
using KarzPlus.Entities;
using KarzPlus.Entities.ExtensionMethods;

namespace KarzPlus.Data
{
	/// <summary>
	/// This class connects to the Transaction Table
	/// </summary>
	public sealed class TransactionDao : BaseDao
	{
		/// <summary>
		/// Searches for Transaction
		/// </summary>
		/// <param name="item" />
		/// <returns>An IEnumerable set of Transaction</returns>
		public static IEnumerable<Transaction> Search(SearchTransaction item)
		{
			List<SqlParameter> parameters
				= new List<SqlParameter>
					{
						new SqlParameter("@TransactionId", item.TransactionId),
                        new SqlParameter("@UserId", item.UserId),
                        new SqlParameter("@CreditCardNumber", item.CreditCardNumber),
                        new SqlParameter("@ExpirationDate", item.ExpirationDate),
                        new SqlParameter("@CCV", item.CCV),
                        new SqlParameter("@BillingAddress", item.BillingAddress),
                        new SqlParameter("@BillingCity", item.BillingCity),
                        new SqlParameter("@BillingState", item.BillingState),
                        new SqlParameter("@BillingZip", item.BillingZip),
                        new SqlParameter("@TransactionDate", item.TransactionDate),
                        new SqlParameter("@InventoryId", item.InventoryId),
                        new SqlParameter("@RentalDateStart", item.RentalDateStart),
                        new SqlParameter("@RentalDateEnd", item.RentalDateEnd),
                        new SqlParameter("@Price", item.Price)
					};

			DataSet set = DataManager.ExecuteProcedure(KarzPlusConnectionString, "PKP_GetTransaction", parameters);
			IEnumerable<DataRow> dataRows = set.GetRowsFromDataSet();
			return ConvertToEntityObject(dataRows);
		}

		/// <summary>
		/// Saves a Transaction to the data store.
		/// </summary>
		/// <param name="item">The item to save</param>
		public static void Save(Transaction item)
		{
			if (item.IsItemModified)
			{
				if (item.TransactionId == null)
				{
					item.TransactionId = Insert(item);
				}
				else
				{
					Update(item);
				}
			}
		}

		/// <summary>
		/// Inserts a new Transaction
		/// </summary>
		/// <param name="item">The Transaction item to insert</param>
		/// <returns>The id of the Transaction item just inserted</returns>
		private static int Insert(Transaction item)
		{
			List<SqlParameter> parameters
				= new List<SqlParameter>
					{
						new SqlParameter("@UserId", item.UserId),
                        new SqlParameter("@CreditCardNumber", item.CreditCardNumber),
                        new SqlParameter("@ExpirationDate", item.ExpirationDate),
                        new SqlParameter("@CCV", item.CCV),
                        new SqlParameter("@BillingAddress", item.BillingAddress),
                        new SqlParameter("@BillingCity", item.BillingCity),
                        new SqlParameter("@BillingState", item.BillingState),
                        new SqlParameter("@BillingZip", item.BillingZip),
                        new SqlParameter("@TransactionDate", item.TransactionDate),
                        new SqlParameter("@InventoryId", item.InventoryId),
                        new SqlParameter("@RentalDateStart", item.RentalDateStart),
                        new SqlParameter("@RentalDateEnd", item.RentalDateEnd),
                        new SqlParameter("@Price", item.Price)
					};
			return Convert.ToInt32(DataManager.ExecuteScalarProcedure(KarzPlusConnectionString, "PKP_InsertTransaction", parameters));
		}

		/// <summary>
		/// Updates a Transaction
		/// </summary>
		/// <param name="item">The Transaction item to save</param>
		private static void Update(Transaction item)
		{
			List<SqlParameter> parameters
				= new List<SqlParameter>
					{
						new SqlParameter("@TransactionId", item.TransactionId),
                        new SqlParameter("@UserId", item.UserId),
                        new SqlParameter("@CreditCardNumber", item.CreditCardNumber),
                        new SqlParameter("@ExpirationDate", item.ExpirationDate),
                        new SqlParameter("@CCV", item.CCV),
                        new SqlParameter("@BillingAddress", item.BillingAddress),
                        new SqlParameter("@BillingCity", item.BillingCity),
                        new SqlParameter("@BillingState", item.BillingState),
                        new SqlParameter("@BillingZip", item.BillingZip),
                        new SqlParameter("@TransactionDate", item.TransactionDate),
                        new SqlParameter("@InventoryId", item.InventoryId),
                        new SqlParameter("@RentalDateStart", item.RentalDateStart),
                        new SqlParameter("@RentalDateEnd", item.RentalDateEnd),
                        new SqlParameter("@Price", item.Price)
					};
			DataManager.ExecuteProcedure(KarzPlusConnectionString, "PKP_UpdateTransaction", parameters);
		}

		/// <summary>
		/// Does a physical delete of a(n) Transaction
		/// </summary>
		/// <param name="transactionId" />
		public static void Delete(int transactionId)
		{
			List<SqlParameter> parameters
				= new List<SqlParameter>
					{
						new SqlParameter("@TransactionId", transactionId)
					};
			DataManager.ExecuteProcedure(KarzPlusConnectionString, "PKP_DeleteTransaction", parameters);
		}

		/// <summary>
		/// Converts an IEnumerable set of DataRows to an IEnumerable of Transaction
		/// </summary>
		/// <param name="dataRows" />
		/// <returns />
		private static IEnumerable<Transaction> ConvertToEntityObject(IEnumerable<DataRow> dataRows)
		{
			return dataRows.Select(row => new Transaction
				{
					TransactionId = row.GetValue<int>("TransactionId"),
					UserId = row.GetValue<Guid>("UserId"),
					CreditCardNumber = row.GetValue<string>("CreditCardNumber").TrimSafely(),
					ExpirationDate = row.GetValue<DateTime>("ExpirationDate"),
					CCV = row.GetValue<int>("CCV"),
					BillingAddress = row.GetValue<string>("BillingAddress").TrimSafely(),
					BillingCity = row.GetValue<string>("BillingCity").TrimSafely(),
					BillingState = row.GetValue<string>("BillingState").TrimSafely(),
					BillingZip = row.GetValue<string>("BillingZip").TrimSafely(),
					TransactionDate = row.GetValue<DateTime>("TransactionDate"),
					InventoryId = row.GetValue<int>("InventoryId"),
					RentalDateStart = row.GetValue<DateTime>("RentalDateStart"),
					RentalDateEnd = row.GetValue<DateTime>("RentalDateEnd"),
					Price = row.GetValue<decimal>("Price")
				});
		}
	}
}
