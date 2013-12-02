// --------------------------------
// <copyright file="SpecialDao.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>JOrtega</author>
// <summary>
//  Special Data Layer Object.   
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
	/// This class connects to the Special Table
	/// </summary>
	public sealed class SpecialDao : BaseDao
	{
		/// <summary>
		/// Searches for Special
		/// </summary>
		/// <param name="item" />
		/// <returns>An IEnumerable set of Special</returns>
		public static IEnumerable<Special> Search(SearchSpecial item)
		{
			List<SqlParameter> parameters
				= new List<SqlParameter>
					{
						new SqlParameter("@SpecialId", item.SpecialId),
                        new SqlParameter("@InventoryId", item.InventoryId),
                        new SqlParameter("@DateStart", item.DateStart),
                        new SqlParameter("@DateEnd", item.DateEnd),
                        new SqlParameter("@Price", item.Price)
					};

			DataSet set = DataManager.ExecuteProcedure(KarzPlusConnectionString, "PKP_GetSpecial", parameters);
			IEnumerable<DataRow> dataRows = set.GetRowsFromDataSet();
			return ConvertToEntityObject(dataRows);
		}

		/// <summary>
		/// Saves a Special to the data store.
		/// </summary>
		/// <param name="item">The item to save</param>
		public static void Save(Special item)
		{
			if (item.IsItemModified)
			{
				if (item.SpecialId == null)
				{
					item.SpecialId = Insert(item);
				}
				else
				{
					Update(item);
				}
			}
		}

		/// <summary>
		/// Inserts a new Special
		/// </summary>
		/// <param name="item">The Special item to insert</param>
		/// <returns>The id of the Special item just inserted</returns>
		private static int Insert(Special item)
		{
			List<SqlParameter> parameters
				= new List<SqlParameter>
					{
						new SqlParameter("@InventoryId", item.InventoryId),
                        new SqlParameter("@DateStart", item.DateStart),
                        new SqlParameter("@DateEnd", item.DateEnd),
                        new SqlParameter("@Price", item.Price)
					};
			return Convert.ToInt32(DataManager.ExecuteScalarProcedure(KarzPlusConnectionString, "PKP_InsertSpecial", parameters));
		}

		/// <summary>
		/// Updates a Special
		/// </summary>
		/// <param name="item">The Special item to save</param>
		private static void Update(Special item)
		{
			List<SqlParameter> parameters
				= new List<SqlParameter>
					{
						new SqlParameter("@SpecialId", item.SpecialId),
                        new SqlParameter("@InventoryId", item.InventoryId),
                        new SqlParameter("@DateStart", item.DateStart),
                        new SqlParameter("@DateEnd", item.DateEnd),
                        new SqlParameter("@Price", item.Price)
					};
			DataManager.ExecuteProcedure(KarzPlusConnectionString, "PKP_UpdateSpecial", parameters);
		}

		/// <summary>
		/// Does a physical delete of a(n) Special
		/// </summary>
		/// <param name="specialId" />
		public static void Delete(int specialId)
		{
			List<SqlParameter> parameters
				= new List<SqlParameter>
					{
						new SqlParameter("@SpecialId", specialId)
					};
			DataManager.ExecuteProcedure(KarzPlusConnectionString, "PKP_DeleteSpecial", parameters);
		}

		/// <summary>
		/// Converts an IEnumerable set of DataRows to an IEnumerable of Special
		/// </summary>
		/// <param name="dataRows" />
		/// <returns />
		private static IEnumerable<Special> ConvertToEntityObject(IEnumerable<DataRow> dataRows)
		{
			return dataRows.Select(row => new Special
				{
					SpecialId = row.GetValue<int>("SpecialId"),
					InventoryId = row.GetValue<int>("InventoryId"),
					DateStart = row.GetValue<DateTime>("DateStart"),
					DateEnd = row.GetValue<DateTime>("DateEnd"),
					Price = row.GetValue<decimal>("Price")
				});
		}
	}
}
