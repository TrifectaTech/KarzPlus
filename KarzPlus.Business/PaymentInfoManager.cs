// --------------------------------
// <copyright file="PaymentInfoManager.cs" >
//     � 2013 KarzPlus Inc. 
// </copyright>
// <author>KEscobar</author>
// <summary>
// Encapsulate business logic of PaymentInfo.   
// </summary>
// ---------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        // 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>An IEnumerable set of PaymentInfo</returns>
        public static IEnumerable<PaymentInfo> LoadByUserId(Guid userId)
        {
            SearchPaymentInfo search = new SearchPaymentInfo
            {
                UserId = userId
            };

            return Search(search);
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
            MembershipUser user = Membership.GetUser(item.UserId);

            StringBuilder builder = new StringBuilder();

			if (user == null)
			{
				builder.AppendHtmlLine("*UserId must be valid");
			}

	        if (item.CreditCardNumber.IsNullOrWhiteSpace())
	        {
		        builder.AppendHtmlLine("*CreditCardNumber is required");
			}

			if (!item.ExpirationDate.IsValidWithSqlDateStandards())
			{
                builder.AppendHtmlLine("*ExpirationDate is required and must be valid");
			}

	        if (item.BillingAddress.IsNullOrWhiteSpace())
	        {
	            builder.AppendHtmlLine("*Billing Address is required");
	        }

            if (item.CreditCardNumber.Length != 16)
            {
                builder.AppendHtmlLine("*Credit Card Number must be 16 digits");
            }

            if (!item.CreditCardNumber.IsNumeric())
            {
                builder.AppendLine("*Credit Card Number must be a 16 digit number");
            }

            errorMessage = builder.ToString();
            
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
