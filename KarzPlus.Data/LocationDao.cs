// --------------------------------
// <copyright file="LocationDao.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>JOrtega</author>
// <summary>
//  Location Data Layer Object.   
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
	/// This class connects to the Location Table
	/// </summary>
	public sealed class LocationDao : BaseDao
	{
		/// <summary>
		/// Searches for Location
		/// </summary>
		/// <param name="item" />
		/// <returns>An IEnumerable set of Location</returns>
		public static IEnumerable<Location> Search(SearchLocation item)
		{
			List<SqlParameter> parameters
				= new List<SqlParameter>
					{
						new SqlParameter("@LocationId", item.LocationId),
                        new SqlParameter("@Name", item.Name),
                        new SqlParameter("@Address", item.Address),
                        new SqlParameter("@City", item.City),
                        new SqlParameter("@State", item.State),
                        new SqlParameter("@Zip", item.Zip),
						new SqlParameter("@Phone", item.Phone),
						new SqlParameter("@Email", item.Email),
                        new SqlParameter("@Deleted", item.Deleted)
					};

			DataSet set = DataManager.ExecuteProcedure(KarzPlusConnectionString, "PKP_GetLocation", parameters);
			IEnumerable<DataRow> dataRows = set.GetRowsFromDataSet();
			return ConvertToEntityObject(dataRows);
		}

		/// <summary>
		/// Saves a Location to the data store.
		/// </summary>
		/// <param name="item">The item to save</param>
		public static void Save(Location item)
		{
			if (item.IsItemModified)
			{
				if (item.LocationId == null)
				{
					item.LocationId = Insert(item);
				}
				else
				{
					Update(item);
				}
			}
		}

		/// <summary>
		/// Inserts a new Location
		/// </summary>
		/// <param name="item">The Location item to insert</param>
		/// <returns>The id of the Location item just inserted</returns>
		private static int Insert(Location item)
		{
			List<SqlParameter> parameters
				= new List<SqlParameter>
					{
						new SqlParameter("@Name", item.Name),
                        new SqlParameter("@Address", item.Address),
                        new SqlParameter("@City", item.City),
                        new SqlParameter("@State", item.State),
                        new SqlParameter("@Zip", item.Zip),
						new SqlParameter("@Phone", item.Phone),
						new SqlParameter("@Email", item.Email),
                        new SqlParameter("@Deleted", item.Deleted)
					};
			return Convert.ToInt32(DataManager.ExecuteScalarProcedure(KarzPlusConnectionString, "PKP_InsertLocation", parameters));
		}

		/// <summary>
		/// Updates a Location
		/// </summary>
		/// <param name="item">The Location item to save</param>
		private static void Update(Location item)
		{
			List<SqlParameter> parameters
				= new List<SqlParameter>
					{
						new SqlParameter("@LocationId", item.LocationId),
                        new SqlParameter("@Name", item.Name),
                        new SqlParameter("@Address", item.Address),
                        new SqlParameter("@City", item.City),
                        new SqlParameter("@State", item.State),
                        new SqlParameter("@Zip", item.Zip),
						new SqlParameter("@Phone", item.Phone),
						new SqlParameter("@Email", item.Email),
                        new SqlParameter("@Deleted", item.Deleted)
					};
			DataManager.ExecuteProcedure(KarzPlusConnectionString, "PKP_UpdateLocation", parameters);
		}

		/// <summary>
		/// Does a physical delete of a(n) Location
		/// </summary>
		/// <param name="locationId" />
		public static void Delete(int locationId)
		{
			List<SqlParameter> parameters
				= new List<SqlParameter>
					{
						new SqlParameter("@LocationId", locationId)
					};
			DataManager.ExecuteProcedure(KarzPlusConnectionString, "PKP_DeleteLocation", parameters);
		}

		/// <summary>
		/// Converts an IEnumerable set of DataRows to an IEnumerable of Location
		/// </summary>
		/// <param name="dataRows" />
		/// <returns />
		private static IEnumerable<Location> ConvertToEntityObject(IEnumerable<DataRow> dataRows)
		{
			return dataRows.Select(row => new Location
				{
					LocationId = row.GetValue<int>("LocationId"),
					Name = row.GetValue<string>("Name").TrimSafely(),
					Address = row.GetValue<string>("Address").TrimSafely(),
					City = row.GetValue<string>("City").TrimSafely(),
					State = row.GetValue<string>("State").TrimSafely(),
					Zip = row.GetValue<string>("Zip").TrimSafely(),
					Phone = row.GetValue<string>("Phone").TrimSafely(),
					Email = row.GetValue<string>("Email").TrimSafely(),
					Deleted = row.GetValue<bool>("Deleted")
				});
		}
	}
}
