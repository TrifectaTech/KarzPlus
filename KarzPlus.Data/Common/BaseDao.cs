using System;
using System.Configuration;

namespace KarzPlus.Data.Common
{
	/// <summary>
	/// Base DAO
	/// </summary>
	[Serializable]
	public abstract class BaseDao
	{
		/// <summary>
		/// Connection String for KarzPlus database
		/// </summary>
		protected static string KarzPlusConnectionString
		{
			get { return ConfigurationManager.ConnectionStrings["KarzPlusConnectionString"].ConnectionString; }
		}
	}
}
