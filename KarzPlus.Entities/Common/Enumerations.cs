﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KarzPlus.Entities.ExtensionMethods;

namespace KarzPlus.Entities.Common
{
	#region	Enumerations Helper Class
	[Serializable]
	public static class EnumerationsHelper
	{
		#region Methods
		public static T ConvertFromInteger<T>(int enumValue)
		{
			T returnVal = default(T);

			Type baseType = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);

			foreach (T val in Enum.GetValues(baseType).Cast<T>().ToList().Where(val => Convert.ToInt32(val) == enumValue))
			{
				returnVal = val;
			}

			return returnVal;
		}

		public static T ConvertFromString<T>(string enumValue)
		{
			enumValue = enumValue.TrimSafely();

			T defaultItem = default(T);

			Type baseType = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);

			foreach (T item in Enum.GetValues(baseType).Cast<T>().Where(item => item.ToString().Equals(enumValue, StringComparison.CurrentCultureIgnoreCase)))
			{
				return item;
			}

			return defaultItem;
		}

		/// <summary>
		/// Gets Enumeration Values
		/// </summary>
		/// <typeparam name="T" />
		/// <param name="removeDefaults">If true, will remove all Enums with values less than or equal to 0</param>
		/// <param name="sortByName">If true, will sort by name rather than by value</param>
		/// <returns>List of Enumeration Values</returns>
		public static List<T> GetEnumerationValues<T>(bool removeDefaults = false, bool sortByName = false)
		{
			// ReSharper disable EmptyGeneralCatchClause
			Type baseType = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
			List<T> enumValues = Enum.GetValues(baseType).Cast<T>().ToList();

			try
			{
				if (removeDefaults)
				{
					enumValues.RemoveAll(e => Convert.ToInt32(e) <= 0);
				}
			}
			catch { }
			// ReSharper restore EmptyGeneralCatchClause

			return sortByName ? enumValues.OrderBy(e => e.ToString()).ToList() : enumValues;
		}

		/// <summary>
		/// Gets the specified values for an enumeration as a delimited string with a comma as the delimiter
		/// </summary>
		/// <param name="enumerationValues">If specified, will limit the enumeration values to those.</param>
		/// <param name="delimiter">If specified, will use as delimiter. Defaults to comma.</param>
		/// <returns>A string</returns>
		public static string GetEnumerationValuesAsDelimitedString<T>(IEnumerable<T> enumerationValues = null, string delimiter = ",")
		{
			if (enumerationValues == null)
			{
				enumerationValues = GetEnumerationValues<T>();
			}

			StringBuilder builder = new StringBuilder();
			foreach (T enumerationValue in enumerationValues)
			{
				builder.AppendFormat("{0}{1}", Convert.ToInt32(enumerationValue), delimiter);
			}

			return builder.ToString();
		}
		#endregion
	}
	#endregion
}
