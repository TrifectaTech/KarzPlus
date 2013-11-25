// --------------------------------
// <copyright file="PaymentInfoManager.cs" >
//     � 2013 KarzPlus Inc. 
// </copyright>
// <author>TODO - CHANGE AUTHOR</author>
// <summary>
// Encapsulate business logic of PaymentInfo.   
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
    /// This class encapsulates the business logic of PaymentInfo entity
    /// </summary>
    public static class PaymentInfoManager
    {        
        /// <summary>
        /// Searches for PaymentInfo
        /// </summary>
        /// <param name="search" />
        /// <returns>An IEnumerable set of PaymentInfo</returns>
        public static IEnumerable<PaymentInfo> Search(SearchPaymentInfo search)
        {            
			return search == null ? new List <PaymentInfo>() : PaymentInfoDao.Search(search);
        }	
	     
        /// <summary>
        /// Loads PaymentInfo by the id parameter
        /// </summary>
        /// <param name="paymentInfoId">Primary Key of PaymentInfo table</param>
        /// <returns>PaymentInfo entity</returns>
        public static PaymentInfo Load(int paymentInfoId)
        {
			SearchPaymentInfo search
				= new SearchPaymentInfo
					{
						PaymentInfoId = paymentInfoId
					};    
			return Search(search).FirstOrDefault();
        }

        /// <summary>
        /// Save PaymentInfo Entity
        /// </summary>
        /// <param name="item">Entity to save</param>
        /// <param name="errorMessage">Error Message</param>
		/// <returns>return true if save successfully, else return false</returns>
        public static bool Save(PaymentInfo item, out string errorMessage)
        {
            bool isValid = Validate(item, out errorMessage);                     
            
			if (isValid)
			{
                PaymentInfoDao.Save(item);				
            }	        

            return isValid;
        }

        /// <summary>
        /// Validate PaymentInfo Entity
        /// </summary>
        /// <param name="item">Entity to validate</param>
        /// <param name="errorMessage">error message if validation failed</param>
        /// <returns>return true if entity passes validation logic, else return false</returns>
        public static bool Validate(PaymentInfo item, out string errorMessage)
        {		
			errorMessage = string.Empty;

			MembershipUser user = Membership.GetUser(item.UserId);
			if (user == null)
			{
				errorMessage += "UserId must be valid. ";
			}

	        if (item.CreditCardNumber.IsNullOrWhiteSpace())
	        {
		        errorMessage += "CreditCardNumber is required. ";
			}

			if (!item.ExpirationDate.IsValidWithSqlDateStandards())
			{
				errorMessage += "ExpirationDate is required and must be valid. ";
			}

	        if (item.BillingAddress.IsNullOrWhiteSpace())
	        {
		        errorMessage += "BillingAddress is required. ";
	        }

			errorMessage = errorMessage.TrimSafely();
            
            return errorMessage.IsNullOrWhiteSpace();
        }

        /// <summary>
        /// Delete a PaymentInfo entity
        /// </summary>
        /// <param name="paymentInfoId">Primary Key of PaymentInfo table</param>
        public static void Delete(int paymentInfoId)
        {            
            PaymentInfoDao.Delete(paymentInfoId);            
        }
    }
}
