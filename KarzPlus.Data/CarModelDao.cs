// --------------------------------
// <copyright file="CarModelDao.cs" >
//     © 2013 KarzPlus Inc. 
// </copyright>
// <author>TODO - CHANGE AUTHOR</author>
// <summary>
//  CarModel Data Layer Object.   
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
    /// This class connects to the CarModel Table
    /// </summary>
    public sealed class CarModelDao : BaseDao
    {
		/// <summary>
        /// Searches for CarModel
        /// </summary>
		/// <param name="item" />
        /// <returns>An IEnumerable set of CarModel</returns>
        public static IEnumerable<CarModel> Search(SearchCarModel item)
        {
            List<SqlParameter> parameters
                = new List<SqlParameter>
					{
						new SqlParameter("@ModelId", item.ModelId),
                        new SqlParameter("@MakeId", item.MakeId),
                        new SqlParameter("@Name", item.Name),
                        new SqlParameter("@CarImage", item.CarImage),
                        new SqlParameter("@Deleted", item.Deleted)
					};

            DataSet set = DataManager.ExecuteProcedure(KarzPlusConnectionString, "PKP_GetCarModel", parameters);
            IEnumerable<DataRow> dataRows = set.GetRowsFromDataSet();
            return ConvertToEntityObject(dataRows);
        }

        /// <summary>
        /// Saves a CarModel to the data store.
        /// </summary>
        /// <param name="item">The item to save</param>
        public static void Save(CarModel item)
        {
			if (item.IsItemModified)
            {
                if (item.ModelId == null)
                {
                    item.ModelId = Insert(item);
                }
                else
                {
                    Update(item);
                }
            }
        }

        /// <summary>
        /// Inserts a new CarModel
        /// </summary>
        /// <param name="item">The CarModel item to insert</param>
        /// <returns>The id of the CarModel item just inserted</returns>
        private static int Insert(CarModel item)
        {
            List<SqlParameter> parameters 
				= new List<SqlParameter>
					{
						new SqlParameter("@MakeId", item.MakeId),
                        new SqlParameter("@Name", item.Name),
                        new SqlParameter("@CarImage", item.CarImage),
                        new SqlParameter("@Deleted", item.Deleted)
					};
            return Convert.ToInt32(DataManager.ExecuteScalarProcedure(KarzPlusConnectionString, "PKP_InsertCarModel", parameters));
        }

        /// <summary>
        /// Updates a CarModel
        /// </summary>
        /// <param name="item">The CarModel item to save</param>
        private static void Update(CarModel item)
        {
            List<SqlParameter> parameters 
				= new List<SqlParameter>
					{
						new SqlParameter("@ModelId", item.ModelId),
                        new SqlParameter("@MakeId", item.MakeId),
                        new SqlParameter("@Name", item.Name),
                        new SqlParameter("@CarImage", item.CarImage),
                        new SqlParameter("@Deleted", item.Deleted)
					};
            DataManager.ExecuteProcedure(KarzPlusConnectionString, "PKP_UpdateCarModel", parameters);
        }

        /// <summary>
        /// Does a physical delete of a(n) CarModel
        /// </summary>
        /// <param name="modelId" />
        public static void Delete(int modelId)
        {
            List<SqlParameter> parameters 
				= new List<SqlParameter>
					{
						new SqlParameter("@ModelId", modelId)
					};
            DataManager.ExecuteProcedure(KarzPlusConnectionString, "PKP_DeleteCarModel", parameters);
        }

        /// <summary>
        /// Converts an IEnumerable set of DataRows to an IEnumerable of CarModel
        /// </summary>
        /// <param name="dataRows" />
        /// <returns />
        private static IEnumerable<CarModel> ConvertToEntityObject(IEnumerable<DataRow> dataRows)
        {
            return dataRows.Select(row => new CarModel
				{
                    ModelId = row.GetValue<int>("ModelId"),
                    MakeId = row.GetValue<int>("MakeId"),
                    Name = row.GetValue<string>("Name").TrimSafely(),
                    CarImage = row.GetValue<byte[]>("CarImage"),
                    Deleted = row.GetValue<bool>("Deleted")  
				});
        }
    }
}
