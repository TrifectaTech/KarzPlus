// --------------------------------
// <copyright file="CarMakeDao.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>JDuverge</author>
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
    /// This class connects to the CarMake Table
    /// </summary>
    public sealed class CarMakeDao : BaseDao
    {
		/// <summary>
        /// Searches for CarMake
        /// </summary>
		/// <param name="item" />
        /// <returns>An IEnumerable set of CarMake</returns>
        public static IEnumerable<CarMake> Search(SearchCarMake item)
        {
            List<SqlParameter> parameters
                = new List<SqlParameter>
					{
						new SqlParameter("@MakeId", item.MakeId),
                        new SqlParameter("@Name", item.Name),
                        new SqlParameter("@Manufacturer", item.Manufacturer),
                        new SqlParameter("@Deleted", item.Deleted)
					};

            DataSet set = DataManager.ExecuteProcedure(KarzPlusConnectionString, "PKP_GetCarMake", parameters);
            IEnumerable<DataRow> dataRows = set.GetRowsFromDataSet();
            return ConvertToEntityObject(dataRows);
        }

        /// <summary>
        /// Saves a CarMake to the data store.
        /// </summary>
        /// <param name="item">The item to save</param>
        public static void Save(CarMake item)
        {
			if (item.IsItemModified)
            {
                if (item.MakeId == null)
                {
                    item.MakeId = Insert(item);
                }
                else
                {
                    Update(item);
                }
            }
        }

        /// <summary>
        /// Inserts a new CarMake
        /// </summary>
        /// <param name="item">The CarMake item to insert</param>
        /// <returns>The id of the CarMake item just inserted</returns>
        private static int Insert(CarMake item)
        {
            List<SqlParameter> parameters 
				= new List<SqlParameter>
					{
						new SqlParameter("@Name", item.Name),
                        new SqlParameter("@Manufacturer", item.Manufacturer),
                        new SqlParameter("@Deleted", item.Deleted)
					};
            return Convert.ToInt32(DataManager.ExecuteScalarProcedure(KarzPlusConnectionString, "PKP_InsertCarMake", parameters));
        }

        /// <summary>
        /// Updates a CarMake
        /// </summary>
        /// <param name="item">The CarMake item to save</param>
        private static void Update(CarMake item)
        {
            List<SqlParameter> parameters 
				= new List<SqlParameter>
					{
						new SqlParameter("@MakeId", item.MakeId),
                        new SqlParameter("@Name", item.Name),
                        new SqlParameter("@Manufacturer", item.Manufacturer),
                        new SqlParameter("@Deleted", item.Deleted)
					};
            DataManager.ExecuteProcedure(KarzPlusConnectionString, "PKP_UpdateCarMake", parameters);
        }

        /// <summary>
        /// Does a physical delete of a(n) CarMake
        /// </summary>
        /// <param name="makeId" />
        public static void Delete(int makeId)
        {
            List<SqlParameter> parameters 
				= new List<SqlParameter>
					{
						new SqlParameter("@MakeId", makeId)
					};
            DataManager.ExecuteProcedure(KarzPlusConnectionString, "PKP_DeleteCarMake", parameters);
        }

        /// <summary>
        /// Converts an IEnumerable set of DataRows to an IEnumerable of CarMake
        /// </summary>
        /// <param name="dataRows" />
        /// <returns />
        private static IEnumerable<CarMake> ConvertToEntityObject(IEnumerable<DataRow> dataRows)
        {
            return dataRows.Select(row => new CarMake
				{
                    MakeId = row.GetValue<int>("MakeId"),
                    Name = row.GetValue<string>("Name").TrimSafely(),
                    Manufacturer = row.GetValue<string>("Manufacturer").TrimSafely(),
                    Deleted = row.GetValue<bool>("Deleted")  
				});
        }
    }
}
