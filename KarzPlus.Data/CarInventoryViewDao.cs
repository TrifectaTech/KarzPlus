// --------------------------------
// <copyright file="CarInventoryViewDao.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>Kenneth Escobar</author>
// <summary>
//  CarMake Data Layer Object.   
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
    /// This class connects to the CarInventoryView
    /// </summary>
    public sealed class CarInventoryViewDao : BaseDao
    {
        /// <summary>
        /// Searches for CarMake
        /// </summary>
        /// <param name="item" />
        /// <returns>An IEnumerable set of CarMake</returns>
        public static IEnumerable<CarInventoryView> Search(CarInventoryViewSearch item)
        {
            List<SqlParameter> parameters
                = new List<SqlParameter>
					{
						new SqlParameter("@InventoryId", item.InventoryId),
                        new SqlParameter("@ModelId", item.ModelId),
                        new SqlParameter("@CarYear", item.CarYear),
                        new SqlParameter("@Quantity", item.Quantity),
						new SqlParameter("@LocationId", item.LocationId),
                        new SqlParameter("@Color", item.Color),
                        new SqlParameter("@Price", item.Price),
                        new SqlParameter("@InventoryDeleted", item.InventoryDeleted),
						new SqlParameter("@makeid", item.MakeId),
                        new SqlParameter("@ModelName", item.ModelName),
                        new SqlParameter("@ModelDeleted", item.ModelDeleted),
						new SqlParameter("@MakeName", item.MakeName),
                        new SqlParameter("@MakeDeleted", item.MakeDeleted),
                        new SqlParameter("@Manufacturer", item.Manufacturer),
                        new SqlParameter("@Address", item.Address),
						new SqlParameter("@City", item.City),
                        new SqlParameter("@State", item.State),
                        new SqlParameter("@LocationName", item.LocationName),
                        new SqlParameter("@Zip", item.Zip),
                        new SqlParameter("@LocationDeleted", item.LocationDeleted)
					};

            if( item.CarImage != null)
            {
                parameters.Add(new SqlParameter("@CarImage", item.CarImage));
            }

            DataSet set = DataManager.ExecuteProcedure(KarzPlusConnectionString, "PKP_GetVKP_CarInventory", parameters);
            IEnumerable<DataRow> dataRows = set.GetRowsFromDataSet();
            return ConvertToEntityObject(dataRows);
        }

        /// <summary>
        /// Converts an IEnumerable set of DataRows to an IEnumerable of CarMake
        /// </summary>
        /// <param name="dataRows" />
        /// <returns />
        private static IEnumerable<CarInventoryView> ConvertToEntityObject(IEnumerable<DataRow> dataRows)
        {
            return dataRows.Select(row => new CarInventoryView
            {
                InventoryId = row.GetValue<int?>("InventoryId"),
                ModelId = row.GetValue<int?>("ModelId"),
                CarYear = row.GetValue<int?>("CarYear"),
                Quantity = row.GetValue<int?>("Quantity"),
                LocationId = row.GetValue<int?>("LocationId"),
                Color = row.GetValue<string>("Color").TrimSafely(),
                Price = row.GetValue<decimal?>("Price"),
                InventoryDeleted = row.GetValue<bool?>("InventoryDeleted"),
                MakeId = row.GetValue<int?>("MakeId"),
                ModelName = row.GetValue<string>("ModelName").TrimSafely(),
                CarImage = row.GetValue<byte[]>("CarImage"),
                ModelDeleted = row.GetValue<bool?>("ModelDeleted"),
                MakeName = row.GetValue<string>("MakeName").TrimSafely(),
                MakeDeleted = row.GetValue<bool?>("MakeDeleted"),
                Manufacturer = row.GetValue<string>("Manufacturer").TrimSafely(),
                Address = row.GetValue<string>("Address").TrimSafely(),
                City = row.GetValue<string>("City").TrimSafely(),
                State = row.GetValue<string>("State").TrimSafely(),
                LocationName = row.GetValue<string>("LocationName").TrimSafely(),
                Zip = row.GetValue<string>("Zip").TrimSafely(),
                LocationDeleted = row.GetValue<bool?>("LocationDeleted")
            });
        }
    }
}
