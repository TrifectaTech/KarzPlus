// --------------------------------
// <copyright file="InventoryDao.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>TODO - CHANGE AUTHOR</author>
// <summary>
//  Inventory Data Layer Object.   
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
    /// This class connects to the Inventory Table
    /// </summary>
    public sealed class InventoryDao : BaseDao
    {
		/// <summary>
        /// Searches for Inventory
        /// </summary>
		/// <param name="item" />
        /// <returns>An IEnumerable set of Inventory</returns>
        public static IEnumerable<Inventory> Search(SearchInventory item)
        {
            List<SqlParameter> parameters
                = new List<SqlParameter>
					{
						new SqlParameter("@InventoryId", item.InventoryId),
                        new SqlParameter("@ModelId", item.ModelId),
                        new SqlParameter("@Year", item.Year),
                        new SqlParameter("@Quantity", item.Quantity),
                        new SqlParameter("@LocationId", item.LocationId),
                        new SqlParameter("@Color", item.Color),
                        new SqlParameter("@Price", item.Price),
                        new SqlParameter("@Deleted", item.Deleted)
					};

            DataSet set = DataManager.ExecuteProcedure(KarzPlusConnectionString, "PKP_GetInventory", parameters);
            IEnumerable<DataRow> dataRows = set.GetRowsFromDataSet();
            return ConvertToEntityObject(dataRows);
        }

        /// <summary>
        /// Saves a Inventory to the data store.
        /// </summary>
        /// <param name="item">The item to save</param>
        public static void Save(Inventory item)
        {
			if (item.IsItemModified)
            {
                if (item.InventoryId == null)
                {
                    item.InventoryId = Insert(item);
                }
                else
                {
                    Update(item);
                }
            }
        }

        /// <summary>
        /// Inserts a new Inventory
        /// </summary>
        /// <param name="item">The Inventory item to insert</param>
        /// <returns>The id of the Inventory item just inserted</returns>
        private static int Insert(Inventory item)
        {
            List<SqlParameter> parameters 
				= new List<SqlParameter>
					{
						new SqlParameter("@ModelId", item.ModelId),
                        new SqlParameter("@Year", item.Year),
                        new SqlParameter("@Quantity", item.Quantity),
                        new SqlParameter("@LocationId", item.LocationId),
                        new SqlParameter("@Color", item.Color),
                        new SqlParameter("@Price", item.Price),
                        new SqlParameter("@Deleted", item.Deleted)
					};
            return Convert.ToInt32(DataManager.ExecuteScalarProcedure(KarzPlusConnectionString, "PKP_InsertInventory", parameters));
        }

        /// <summary>
        /// Updates a Inventory
        /// </summary>
        /// <param name="item">The Inventory item to save</param>
        private static void Update(Inventory item)
        {
            List<SqlParameter> parameters 
				= new List<SqlParameter>
					{
						new SqlParameter("@InventoryId", item.InventoryId),
                        new SqlParameter("@ModelId", item.ModelId),
                        new SqlParameter("@Year", item.Year),
                        new SqlParameter("@Quantity", item.Quantity),
                        new SqlParameter("@LocationId", item.LocationId),
                        new SqlParameter("@Color", item.Color),
                        new SqlParameter("@Price", item.Price),
                        new SqlParameter("@Deleted", item.Deleted)
					};
            DataManager.ExecuteProcedure(KarzPlusConnectionString, "PKP_UpdateInventory", parameters);
        }

        /// <summary>
        /// Does a physical delete of a(n) Inventory
        /// </summary>
        /// <param name="inventoryId" />
        public static void Delete(int inventoryId)
        {
            List<SqlParameter> parameters 
				= new List<SqlParameter>
					{
						new SqlParameter("@InventoryId", inventoryId)
					};
            DataManager.ExecuteProcedure(KarzPlusConnectionString, "PKP_DeleteInventory", parameters);
        }

        /// <summary>
        /// Converts an IEnumerable set of DataRows to an IEnumerable of Inventory
        /// </summary>
        /// <param name="dataRows" />
        /// <returns />
        private static IEnumerable<Inventory> ConvertToEntityObject(IEnumerable<DataRow> dataRows)
        {
            return dataRows.Select(row => new Inventory
				{
                    InventoryId = row.GetValue<int>("InventoryId"),
                    ModelId = row.GetValue<int>("ModelId"),
                    Year = row.GetValue<int>("Year"),
                    Quantity = row.GetValue<int>("Quantity"),
                    LocationId = row.GetValue<int>("LocationId"),
                    Color = row.GetValue<string>("Color").TrimSafely(),
                    Price = row.GetValue<decimal>("Price"),
                    Deleted = row.GetValue<bool>("Deleted")  
				});
        }
    }
}
