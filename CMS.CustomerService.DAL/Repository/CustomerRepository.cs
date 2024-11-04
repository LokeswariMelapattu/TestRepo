using DUC.CMS.CustomerService.DAL.DataExtensions;
using DUC.CMS.CustomerService.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace DUC.CMS.CustomerService.DAL
{
    public class CustomerRepository : Repository.Repository<CUSTOMER>
    {
        public CustomerRepository(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public int SaveAddress(ADDRESS addressToAdd)
        {
            var addressId = new ObjectParameter("P_Address_ID", addressToAdd.ADDRESS_ID);

            this._dbContext.Context.UpdateAddress(addressId, addressToAdd.AREA_ID, addressToAdd.CITY_ID, addressToAdd.COUNTRY_ID,
                addressToAdd.POST_CODE, addressToAdd.DETAILED_ADDRESS, addressToAdd.IS_ACTIVE, addressToAdd.PHONE_NUMBER, addressToAdd.FAX, addressToAdd.LAST_UPDATED_USER_ID, addressToAdd.LAST_UPDATED_DATE, addressToAdd.LAST_LOCATION_ID);
            if (addressId != null)
            {
                return (int)((decimal)addressId.Value);
            }
            throw new Exception("Error while inserting address");
        }

        /// <summary>
        /// Saves the customer information.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns></returns>
        public int SaveCustomerInfo(CTCustomer customer)
        {
            var p_CUSTOMER_ID = new ObjectParameter("p_CUSTOMER_ID", customer.CUSTOMER_ID);
            var p_CODE = new ObjectParameter("p_CODE", typeof(string));
            p_CODE.Value = customer.CODE;
            // TODO remove null before committing
            _dbContext.Context.UpdateCustomerInfo(p_CUSTOMER_ID, customer.NAME, customer.CUSTOMER_TYPE_ID, customer.CLASSIFICATION_ID,
                customer.ACCOUNT_TYPE_ID, customer.NATIONALITY_ID, customer.NATIONAL_ID, customer.BASIC_ADDRESS_ID, customer.BILLING_ADDRESS_ID,
                customer.SHIPPING_ADDRESS_ID, customer.FAMILY_ID, customer.FINANCIAL_ACCOUNT_TYPE_ID, customer.FINANCIAL_ACCOUNT_NUMBER,
                customer.ACCOUNT_MANAGER_ID, customer.BILLING_FREQUENCY_ID, customer.NOTIFICATION_THRESHOLD, customer.SUSPPENSION_THRESHOLD, customer.IS_VIP,
                customer.REGISTRATION_DATE, customer.STATUS_ID, customer.STATUS_REASON_ID, customer.IS_ACTIVE, customer.PIN, customer.NOTIFICATION_LANGUAGE_ID,
                customer.NOTIFICATION_CHANNEL_ID, customer.REQUEST_SOURCE_TYPE_ID, null /* customer.CARD_CENTER_ID*/, customer.LAST_UPDATED_USER_ID, customer.LAST_UPDATED_DATE, customer.UNIT_ID, customer.BILLING_FREQUENCY_DAY_ORDER,
                customer.PAYEMENT_TERMS, customer.IDENTIFICATION_TYPE_ID, customer.COMPANY_ID, customer.IS_PREMIER, customer.FinancialStartYear, p_CODE, customer.LAST_LOCATION_ID, customer.ISBENEFICIARYIDNONUNIQUE, customer.CUSTOM_BILL_FREQUENCY, customer.IS_EMPLOYER, customer.CONTRACT_NUMBER);

            if (p_CUSTOMER_ID != null)
            {
                return (int)((decimal)p_CUSTOMER_ID.Value);
            }
            throw new Exception("Error While Inserting Contact");
        }


        public IEnumerable<PRODUCT> GetAllProduct(int? productCategoryID)
        {
            List<PRODUCT> products;
            products = _dbContext.Context.GetAllProduct(productCategoryID).ToList();
            return products.ToArray();
        }

        /// <summary>
        /// Updates the uplift discount product.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <returns></returns>
        public bool UpdateUpliftDiscountProduct(int customerID, int UpliftID, CTBase Audit)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.UpdateUpliftDiscountProduct(customerID, UpliftID, Audit.LastUserID, Audit.LastUpdateDate, Audit.LastLocationID, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        public bool UpdatePushNotification(int BenificaryId, int isPushEnabled, int UserID, int LocationId)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.UpdatePushNotification(BenificaryId, isPushEnabled, UserID, LocationId, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        private static int IntValue(ObjectParameter P)
        {
            if (P.Value != null && P.Value != DBNull.Value)
            {
                return Convert.ToInt32(P.Value);
            }
            return -1;
        }
        public int GetPushNotification(int BenificaryId)
        {
            var p_IS_PUSH_DISABLED = new ObjectParameter("P_IS_PUSH_DISABLED", typeof(decimal));
            var res = _dbContext.Context.GetPushNotification(BenificaryId, p_IS_PUSH_DISABLED);
            return IntValue(p_IS_PUSH_DISABLED);
            // return Convert.ToInt32(p_IS_PUSH_DISABLED.Value);
        }

        /// <summary>
        /// Checks the customer group in use.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="customerGroupId">The customer group identifier.</param>
        /// <returns></returns>
        public bool CheckCustomerGroupInUse(int customerId, int customerGroupId)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.CheckCustomerGroupInUse(customerId, customerGroupId, p_RESULT);
            if (p_RESULT != null)
            {
                return (decimal)p_RESULT.Value == 1;
            }
            return false;
        }

        /// <summary>
        /// Gets all customer groups.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        public List<CTCustomerGroup> GetAllCustomerGroups(int customerId, string groupName)
        {
            return _dbContext.Context.GetAllCustomerGroups(customerId, groupName).ToList();
        }

        /// <summary>
        /// Updates the customer group.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <returns></returns>
        public bool UpdateCustomerGroup(BENEFICIARY_GROUP argument)
        {
            var p_GROUP_ID = new ObjectParameter("p_GROUP_ID", argument.GROUP_ID);

            _dbContext.Context.UpdateCustomerGroup(p_GROUP_ID, argument.CUSTOMER_ID, argument.EN_GROUP_NAME, argument.AR_GROUP_NAME
                , argument.LAST_UPDATED_USER_ID, argument.LAST_UPDATED_DATE, argument.DESCRIPTION, argument.IS_ACTIVE, argument.LAST_LOCATION_ID, argument.CODE_COMBINATION_ID);
            return true;
        }

        //F36      
        public List<CUSTOMER_STATUS_REASON> GetAllCustomerStatusReasons(int statusID)
        {
            return _dbContext.Context.GetAllCustomerStatusReasons(statusID).ToList();
        }

        public bool UpdateBeneficiaryGroupInfo(int customerID, int beneficiaryID, int? groupID, int? UserID, DateTime? LastUpdatedDate, int? LocationId)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.UpdateBeneficiaryGroupInfo(customerID, beneficiaryID, groupID, UserID, LastUpdatedDate, LocationId, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        /// <summary>
        /// Deletes the customer group.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <returns></returns>
        public bool DeleteCustomerGroup(BENEFICIARY_GROUP argument)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.DeleteCustomerGroup(argument.GROUP_ID, argument.LAST_UPDATED_USER_ID, argument.LAST_UPDATED_DATE, argument.LAST_LOCATION_ID, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        /// <summary>
        /// Gets all customer information.
        /// </summary>
        /// <param name="search">The search.</param>
        /// <returns></returns>
        public List<CTCustomerInfo> GetAllCustomerInfo(CTCustomerInfo search)
        {
            return _dbContext.Context.GetAllCustomerInfo(search.CustomerID, search.Code, search.CompanyID, search.MobileNumber, search.StatusID, search.StatusName,
                search.CustomerName, search.RegisterFrom, search.RegisterTo, search.RegistrationDate, search.CustomerClassificationID, search.CustomerClassification,
                search.AccountTypeID, search.AccountType, search.NationalID, search.FINANCIAL_ACCOUNT_NUMBER, search.UserID).ToList();
        }

        public List<CTCustomerInfo> SearchCustomerInfo(CTCustomerInfo search, int pageNo, int pageSize, out int rowCount)
        {
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.SearchCustomerInfo(search.CustomerID, search.Code, search.CompanyID, search.MobileNumber, search.StatusID, search.StatusName,
                search.CustomerName, search.RegisterFrom, search.RegisterTo, search.RegistrationDate, search.CustomerClassificationID, search.CustomerClassification,
                search.AccountTypeID, search.AccountType, search.NationalID, search.FINANCIAL_ACCOUNT_NUMBER, search.UserID, search.EmployeeID, search.TokenCode, search.IsSubscribed, pageNo, pageSize, p_ROW_COUNT).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }

        public List<CTCustomerInfo> SearchCustomerForClosure(CTCustomerInfo search, int pageNo, int pageSize, out int rowCount)
        {
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.SearchCustomerForClosure(search.CustomerID, search.Code, search.CompanyID, search.MobileNumber, search.StatusID, search.StatusName,
                search.CustomerName, search.RegisterFrom, search.RegisterTo, search.RegistrationDate, search.CustomerClassificationID, search.CustomerClassification,
                search.AccountTypeID, search.AccountType, search.NationalID, search.FINANCIAL_ACCOUNT_NUMBER, search.UserID, search.EmployeeID, pageNo, pageSize, p_ROW_COUNT).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }

        public List<CTCustomerInfo> SearchCustomerforPayment(CTCustomerInfo search, int pageNo, int pageSize, int IsRefund, out int rowCount)
        {
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.SearchCustomerforPayment(search.CustomerID, search.Code, search.CompanyID, search.MobileNumber, search.StatusID, search.StatusName,
                search.CustomerName, search.RegisterFrom, search.RegisterTo, search.RegistrationDate, search.CustomerClassificationID, search.CustomerClassification,
                search.AccountTypeID, search.AccountType, search.NationalID, search.FINANCIAL_ACCOUNT_NUMBER, search.UserID, IsRefund, pageNo, pageSize, p_ROW_COUNT).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }

        public CTDebitCreditRequest ViewCreditDebitRequest(int P_REQUESTID)
        {
            var data = _dbContext.Context.ViewCreditDebitRequest(P_REQUESTID).FirstOrDefault();
            return data;
        }

        public CTRefundRequest ViewRefundRequest(int P_REQUESTID)
        {
            var data = _dbContext.Context.ViewRefundRequest(P_REQUESTID).FirstOrDefault();
            return data;
        }

        public CTVoucherRequest ViewVoucherRequest(int P_REQUESTID)
        {
            var data = _dbContext.Context.ViewVoucherRequest(P_REQUESTID).FirstOrDefault();
            return data;
        }

        /// <summary>
        /// Searches the beneficiaries.
        /// </summary>
        /// <param name="search">The search.</param>
        /// <returns></returns>
        public List<CTCustomerBeneficiaryResult> SearchBeneficiaries(CTCustomerBeneficiary search, int pageNo, int pageSize, out int rowCount)
        {
            var p_PAGE_NO = new ObjectParameter("p_PAGE_NO", typeof(decimal));
            p_PAGE_NO.Value = pageNo;
            var p_PAGE_SIZE = new ObjectParameter("p_PAGE_SIZE", typeof(decimal));
            p_PAGE_SIZE.Value = pageSize;
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.SearchBeneficiaries(search.BENEFICIARY_ID, search.BENEFICIARY_CODE, search.CUSTOMER_ID, search.CUSTOMER_CODE, search.BENEFICIARY_NAME, search.MOBILE, search.STATUS_ID, search.STATUS_NAME
                , search.NATIONAL_ID, search.NATIONALILTY_ID, search.NATIONALITY_NAME, search.REGISTRATION_DATE, search.REGISTER_FROM_DATE, search.REGISTER_TO_DATE,
                search.CUSTOMER_GROUP, search.IS_VIP, search.UserID, search.EmployeeID, search.IdNumber, p_PAGE_NO, p_PAGE_SIZE, p_ROW_COUNT, search.TokenCode, search.CustomerName).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }

        /// <summary>
        /// Searches the customer beneficiary.
        /// </summary>
        /// <param name="search">The search.</param>
        /// <returns></returns>
        public List<CTCustomerBenSearch> SearchCustomerBeneficiary(CTCustomerBenSearch search, int pageNo, int pageSize, out int rowCount)
        {
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.SearchCustomerBeneficiary(search.CUSTOMER_ID, search.CUSTOMER_CODE, search.BENEFICIARY_ID, search.BENEFICIARY_CODE, search.CUSTOMER_NAME, search.BENEFICIARY_NAME, search.UserID
                , pageNo, pageSize, p_ROW_COUNT).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }

        public List<CTCustomerBeneficiaryResult> GetBeneficiaryInfo(CTCustomerBeneficiary search, int pageNo, int pageSize, out int rowCount)
        {
            var p_PAGE_NO = new ObjectParameter("p_PAGE_NO", typeof(decimal));
            p_PAGE_NO.Value = pageNo;
            var p_PAGE_SIZE = new ObjectParameter("p_PAGE_SIZE", typeof(decimal));
            p_PAGE_SIZE.Value = pageSize;
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.SearchBeneficiaries(search.BENEFICIARY_ID, search.BENEFICIARY_CODE, search.CUSTOMER_ID, search.CUSTOMER_CODE, search.BENEFICIARY_NAME, search.MOBILE, search.STATUS_ID, search.STATUS_NAME
                , search.NATIONAL_ID, search.NATIONALILTY_ID, search.NATIONALITY_NAME, search.REGISTRATION_DATE, search.REGISTER_FROM_DATE, search.REGISTER_TO_DATE,
                search.CUSTOMER_GROUP, search.IS_VIP, search.UserID, search.EmployeeID, search.IdNumber, p_PAGE_NO, p_PAGE_SIZE, p_ROW_COUNT, search.TokenCode, search.CustomerName).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }

        public List<BENEFICIARY> GetBeneficiaryInfo(int beneficiaryId)
        {
            return _dbContext.Context.GetBeneficiaryInfo(beneficiaryId).ToList();
        }

        public List<CTUpliftCustomerProduct> GetAllUpliftDiscountProducts(int customerId)
        {
            return _dbContext.Context.GetAllUpliftDiscountProducts(customerId).ToList();
        }

        public List<CTProperty> GetAllEmiratesByCountryID(int countryId)
        {
            return _dbContext.Context.GetAllEmiratesByCountryID(countryId).ToList();
        }

        public decimal UpdateCustomerStatus(int customerId, string customerCode, int customerStatusId, int? customerStatusReasonId, DateTime fromDate, DateTime toDate, int? UserID, DateTime? LastUpdatedDate, int? LocationId)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.UpdateCustomerStatus(customerId, customerCode, customerStatusId, customerStatusReasonId, fromDate, toDate, UserID, LastUpdatedDate, LocationId, p_RESULT);
            return (decimal)p_RESULT.Value;
        }

        public bool AddPayment(CUSTOMER_PAYMENT payment, CTBase Audit)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            var p_PAYMENT_ID = new ObjectParameter("p_PAYMENT_ID", payment.PAYMENT_ID);
            _dbContext.Context.AddPayment(p_PAYMENT_ID, payment.CUSTOMER_ID,
                payment.PAYMENT_TYPE_ID, payment.INITIAL_BALANCE, payment.TRANSACTION_AMOUNT, payment.FINAL_BALANCE,
                payment.AUTHORIZATION_CODE, payment.INVOICE_ID, payment.DATE_TIME, payment.PAYMENT_METHOD_ID, payment.PAYMENT_DOCUMENT_REF,
                payment.REMARKS, payment.IS_ACTIVE, Audit.LastUserID, Audit.LastUpdateDate, Audit.LastLocationID, payment.PAYMENT_INTERFACE_ID,
                payment.VAT_INVOICE_NUMBER, payment.VAT_SERVICE_ID, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        public void GetCustomerBalance(int customerId, out decimal UsableBalance, out decimal TotalBalance, out decimal AccumulativeBlockedAmount)
        {
            //var aCCUMULATIVEBLOCKEDAMOUNT = new ObjectParameter("AccumulativeBlockedAmount", typeof(decimal));
            //var uSABLEBALANCE = new ObjectParameter("UsableBalance", typeof(decimal));
            //var tOTALBALANCE = new ObjectParameter("TotalBalance", typeof(decimal));

            var aCCUMULATIVEBLOCKEDAMOUNT = new ObjectParameter("aCCUMULATIVEBLOCKEDAMOUNT", typeof(decimal));
            var uSABLEBALANCE = new ObjectParameter("uSABLEBALANCE", typeof(decimal));
            var tOTALBALANCE = new ObjectParameter("tOTALBALANCE", typeof(decimal));
            _dbContext.Context.GetCustomerBalance(customerId, tOTALBALANCE, aCCUMULATIVEBLOCKEDAMOUNT, uSABLEBALANCE);
            TotalBalance = Convert.ToDecimal(tOTALBALANCE.Value);
            AccumulativeBlockedAmount = Convert.ToDecimal(aCCUMULATIVEBLOCKEDAMOUNT.Value);
            UsableBalance = Convert.ToDecimal(uSABLEBALANCE.Value);
        }

        public DateTime? GetMinCutomerTransactionDate(int customerId)
        {
            var data = _dbContext.Context.GetMinCutomerTransactionDate(customerId).ToList();
            if (data == null)
                return null;
            return data.Count > 0 ? data[0] : null;
        }

        public List<CTAccountBalance> GetAccountBalance(int customerId, DateTime? fromDate, DateTime? toDate, int pageNo, int pageSize, out int rowCount)
        {
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.GetAccountBalance(customerId, fromDate, toDate, pageNo, pageSize, p_ROW_COUNT).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }

        public List<CTTransactionSearch> GetCustomerTransactions(CTTransactionSearch search, int pageNo, int pageSize, out int rowCount, out decimal PaidAmountSum, out decimal AdjustmentAmountSum, out decimal TotalAmountSum, out decimal PaidVATSum)
        {
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var p_ROW_SUM_TOTAL = new ObjectParameter("p_ROW_SUM_TOTAL", typeof(decimal));
            var p_ROW_SUM_ADJ = new ObjectParameter("p_ROW_SUM_ADJ", typeof(decimal));
            var p_ROW_SUM_PAID = new ObjectParameter("p_ROW_SUM_PAID", typeof(decimal));
            var p_ROW_SUM_VAT = new ObjectParameter("p_ROW_SUM_VAT", typeof(decimal));
            var data = _dbContext.Context.GetCustomerTransactions(search.BENEFICIARY_ID, search.BENEFICIARY_CODE, search.CUSTOMER_ID, search.BENEFICIARY_NAME,
                search.TRANS_FROM_DATE, search.TRANS_TO_DATE, search.TOKEN_TYPE_ID, search.TOKEN_TYPE, search.STATION_ID,
                search.PRODUCT_ID, search.SERIAL, search.GROUP_ID, search.TRANSACTION_AMOUNT, search.TRANSACTION_ADJUSTMENT,
                search.TRANSACTION_PAID_AMOUNT, search.VAT_INV_NUM, pageNo, pageSize, p_ROW_COUNT, p_ROW_SUM_TOTAL, p_ROW_SUM_ADJ, p_ROW_SUM_PAID, p_ROW_SUM_VAT).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            PaidAmountSum = Convert.ToDecimal(p_ROW_SUM_PAID.Value);
            AdjustmentAmountSum = Convert.ToDecimal(p_ROW_SUM_ADJ.Value);
            TotalAmountSum = Convert.ToDecimal(p_ROW_SUM_TOTAL.Value);
            PaidVATSum = Convert.ToDecimal(p_ROW_SUM_VAT.Value);
            return data;
        }

        public List<CTTransactionSearchInv> TransactionSearchInv(CTTransactionSearchInv search, int pageNo, int pageSize, out int rowCount,
            out decimal PaidAmountSum, out decimal AdjustmentAmountSum, out decimal TotalAmountSum, out decimal TotalVAT)
        {
            var p_ROW_COUNT = new ObjectParameter("P_Row_Count", typeof(decimal));
            var p_ROW_SUM_TOTAL = new ObjectParameter("P_Row_Sum_Total", typeof(decimal));
            var p_ROW_SUM_ADJ = new ObjectParameter("P_Row_Sum_Adj", typeof(decimal));
            var p_ROW_SUM_PAID = new ObjectParameter("P_Row_Sum_Paid", typeof(decimal));
            var p_ROW_SUM_VAT = new ObjectParameter("P_ROW_SUM_VAT", typeof(decimal));
            var data = _dbContext.Context.TransactionSearchInv(search.BENEFICIARY_ID, search.BENEFICIARY_CODE, search.CUSTOMER_ID, search.BENEFICIARY_NAME,
                search.TRANS_FROM_DATE, search.TRANS_TO_DATE, search.TOKEN_TYPE_ID, search.TOKEN_TYPE, search.STATION_ID,
                search.PRODUCT_ID, search.SERIAL, search.GROUP_ID, search.TRANSACTION_AMOUNT, search.TRANSACTION_ADJUSTMENT,
                search.TRANSACTION_PAID_AMOUNT, Convert.ToDecimal(search.VAT_INV_NUM), pageNo, pageSize,
                p_ROW_COUNT, p_ROW_SUM_TOTAL, p_ROW_SUM_ADJ, p_ROW_SUM_PAID, p_ROW_SUM_VAT, search.Invoice_ID).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            PaidAmountSum = Convert.ToDecimal(p_ROW_SUM_PAID.Value);
            AdjustmentAmountSum = Convert.ToDecimal(p_ROW_SUM_ADJ.Value);
            TotalAmountSum = Convert.ToDecimal(p_ROW_SUM_TOTAL.Value);
            TotalVAT = Convert.ToDecimal(p_ROW_SUM_VAT.Value);
            return data;
        }

        public int IsEmployeeCardAlreadyIssued(int employeeId, int customerID, out string cardSerialNo)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            var p_Message = new ObjectParameter("p_Message", typeof(string));
            _dbContext.Context.IsEmployeeCardAlreadyIssued(employeeId, customerID, p_RESULT, p_Message);
            cardSerialNo = Convert.ToString(p_Message.Value);
            return Convert.ToInt32(p_RESULT.Value);
        }

        public bool IsReplacementIssueRequest(int customerId, int beneficiaryId, int tokenId)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.IsReplacementIssueRequest(tokenId, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        //public bool ReplacePersonalizationOrderRequest(int tokenId)
        //{
        //    var p_PERSONALIZATION_ORDER_ID = tokenId > 0 ?
        //       new ObjectParameter("p_PERSONALIZATION_ORDER_ID", tokenId) :
        //       new ObjectParameter("p_PERSONALIZATION_ORDER_ID", typeof(decimal));

        //    var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));

        //    _dbContext.Context.ReplacePersonalizationOrderRequest(p_PERSONALIZATION_ORDER_ID, p_RESULT);
        //    return Convert.ToBoolean(p_RESULT.Value);
        //}

        //public bool ReplaceWorkOrderRequest(int tokenId)
        //{
        //    var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
        //    _dbContext.Context.ReplaceWorkOrderRequest(tokenId, p_RESULT);
        //    return Convert.ToBoolean(p_RESULT.Value);
        //}

        //public List<VEHICLE_REGISTER> SearchVehicleRegister(int makeId, int modelId, int year)
        //{
        //    return _dbContext.Context.SearchVehicleRegister(null, makeId, modelId, year, null, null, null, null, null, null, null).ToList();
        //}

        public List<CTBeneficiaryStatusHistory> GetBeneficiaryStatusHistory(int beneficiaryId)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            return _dbContext.Context.GetBeneficiaryStatusHistory(beneficiaryId, p_RESULT).ToList();
        }

        public List<CTCustomerStatusHistory> GetCustomerStatusHistory(int customerId)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            return _dbContext.Context.GetCustomerStatusHistory(customerId, p_RESULT).ToList();
        }

        public bool SubmitSMSRequest(SMS_MESSAGE message, int languageID)
        {
            var p_SMS_NOTIFICATION_ID = new ObjectParameter("p_SMS_NOTIFICATION_ID", message.MESSAGE_ID);
            _dbContext.Context.SubmitSMSRequest(p_SMS_NOTIFICATION_ID, "CMS", message.MESSAGE_BODY, message.MOBILE_NUMBER,
                message.MESSAGE_DATE_TIME, 0, 1, message.MESSAGE_DATE_TIME, message.LAST_UPDATED_USER_ID, message.LAST_UPDATED_DATE, message.LAST_LOCATION_ID, languageID);
            if (Convert.ToInt32(p_SMS_NOTIFICATION_ID.Value) > 0)
                return true;
            return false;
        }

        public bool SubmitEmailRequest(EMAIL_NOTIFICATION entity, int LanguageID)
        {
            var p_EMAIL_NOTIFICATION_ID = new ObjectParameter("p_EMAIL_NOTIFICATION_ID", entity.EMAIL_NOTIFICATION_ID);
            _dbContext.Context.SubmitEmailRequest(p_EMAIL_NOTIFICATION_ID, entity.NOTIFICATION_SOURCE, entity.EMAIL_BODY, entity.EMAIL_SUBJECT, entity.EMAIL_RECEPIENTS, entity.DATE_RECEIVED,
                entity.IS_SENT, entity.DATE_PROCESSED, entity.IS_ACTIVE, LanguageID, entity.LAST_UPDATED_USER_ID, entity.LAST_UPDATED_DATE, entity.LAST_LOCATION_ID);
            if (Convert.ToInt32(p_EMAIL_NOTIFICATION_ID.Value) > 0)
                return true;
            return false;
        }

        public bool UpdateBeneficiaryPIN(int customerId, int beneficiaryId, string beneficiaryCode, string PIN, CTBase Audit)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.UpdateBeneficiaryPIN(beneficiaryId, beneficiaryCode, PIN, Audit.LastUserID, Audit.LastUpdateDate, Audit.LastLocationID, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        public int UpdateBeneficiaryInfo(CTBeneficiaryInfo entity)
        {

            var p_BENEFICIARY_ID = new ObjectParameter("p_BENEFICIARY_ID", entity.BeneficiaryEntity.BENEFICIARY_ID);
            var p_CODE = new ObjectParameter("p_CODE", typeof(string));
            p_CODE.Value = entity.BeneficiaryEntity.CODE;

            _dbContext.Context.UpdateBeneficiaryInfo(p_BENEFICIARY_ID, p_CODE, entity.BeneficiaryEntity.CUSTOMER_ID, entity.BeneficiaryEntity.EMPLOYEE_ID, entity.BeneficiaryEntity.ADDRESS_ID, entity.BeneficiaryEntity.NAME, entity.BeneficiaryEntity.MOBILE,
                entity.BeneficiaryEntity.EMAIL, entity.BeneficiaryEntity.PIN, entity.BeneficiaryEntity.LANGUAGE_ID, entity.BeneficiaryEntity.IDENTIFICATION_TYPE_ID, entity.BeneficiaryEntity.NATIONAL_ID, entity.BeneficiaryEntity.NATIONALILTY_ID,
                entity.BeneficiaryEntity.NOTIFICATION_CHANNEL_ID, entity.BeneficiaryEntity.NOTIFICATION_LANGUAGE_ID, entity.BeneficiaryEntity.FAMILY_ID, entity.BeneficiaryEntity.GROUP_ID, entity.BeneficiaryEntity.BENEFICIARY_STATUS_ID
             , entity.BeneficiaryEntity.BENEFICIARY_STATUS_REASON_ID, entity.BeneficiaryEntity.IS_STATUS_INHERITED, entity.BeneficiaryEntity.IS_DISABILITY, entity.BeneficiaryEntity.LAST_UPDATED_USER_ID, entity.BeneficiaryEntity.LAST_UPDATED_DATE,
             entity.BeneficiaryEntity.REGISTRATION_DATE, entity.BeneficiaryEntity.IS_VIP, entity.BeneficiaryEntity.IS_ACTIVE, entity.BeneficiaryEntity.GENDER, entity.BeneficiaryEntity.IS_CUSTOMER_DEFAULT, entity.BeneficiaryEntity.DATEOFBIRTH,
             entity.BeneficiaryEntity.LAST_LOCATION_ID);
            return Convert.ToInt32(p_BENEFICIARY_ID.Value);
        }

        public bool UpdateCustomerPIN(int customerId, int contactTypeId, string PIN, CTBase Audit)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.UpdateCustomerPIN(customerId, contactTypeId, PIN, Audit.LastUserID, Audit.LastUpdateDate, Audit.LastLocationID, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        /// <summary>
        /// Gets the customer billing dates.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        public List<CTCustomerBillingDate> GetCustomerBillingDates(int customerId)
        {
            return _dbContext.Context.GetCustomerBillingDates(customerId).ToList();
        }

        /// <summary>
        /// Gets the customer billing period.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        public List<CTCustomerBillingPeriod> GetCustomerBillingPeriod(int customerId)
        {
            var data = _dbContext.Context.GetCustomerBillingPeriod(customerId).ToList();
            if (data != null & data.Count > 0)
                return data;
            return null;
        }

        /// <summary>
        /// Searches the customer billing.
        /// </summary>
        /// <param name="search">The search.</param>
        /// <returns></returns>
        public List<CTCustomerBillingSearch> SearchCustomerBilling(CTCustomerBillingSearch search, int pageNo, int pageSize, out int rowCount)
        {
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.SearchCustomerBilling(search.INVOICE_NUMBER, search.BILLING_DATE == DateTime.MinValue ? null : search.BILLING_DATE, search.DATE_FROM == DateTime.MinValue ? null : search.DATE_FROM, search.DATE_TO == DateTime.MinValue ? null : search.DATE_TO,
                search.CUSTOMER_ID, pageNo, pageSize, p_ROW_COUNT).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }

        /// <summary>
        /// Gets the customer billing information.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="invoiceId">The invoice identifier.</param>
        /// <returns></returns>
        public CTCustomerBillingDetail GetCustomerBillingInfo(int customerId, string invoiceNumber)
        {
            var data = _dbContext.Context.GetCustomerBillingInfo(customerId, invoiceNumber).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }

        /// <summary>
        /// Gets the hr employee data.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns></returns>
        public CTERPEmployee GetHREmployeeData(int employeeNumber)
        {
            var data = _dbContext.Context.GetHREmployeeData(employeeNumber).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }

        /// <summary>
        /// Updates the identity card information.
        /// </summary>
        /// <param name="card">The card.</param>
        /// <returns></returns>
        public int UpdateIdentityCardInfo(CTEmployeeIdentityCard card)
        {
            var P_TOKEN_ID = card.P_TOKEN_ID > 0 ?
               new ObjectParameter("P_TOKEN_ID", card.P_TOKEN_ID) :
               new ObjectParameter("P_TOKEN_ID", -1);

            var p_result = new ObjectParameter("p_result", typeof(decimal));

            _dbContext.Context.UpdateIdentityCardInfo(P_TOKEN_ID, card.P_EMPLOYEE_ID, card.P_PERSONALIZATION_NUMBER, card.P_PERSONALIZATION_STATUS_ID,
                card.P_CARD_CENTER_ID, card.P_APPOINTMENT_DATE, card.P_PRSNLIZTION_ORDR_TYP_ID, card.P_PERSONALIZATION_REASON_ID, card.P_IDENTIFICATION_TYPE_ID, card.P_IDENTITY_NUMBER,
              card.P_CUSTOMER_ID, card.P_User_ID, card.P_Last_updated_DATE, card.P_Location_ID, p_result);

            if (Convert.ToInt32(p_result.Value) == 1)
                return Convert.ToInt32(P_TOKEN_ID.Value);
            return -1;
        }

        /// <summary>
        /// Gets the customer un billed information.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        public List<CTCustomerUnbilledInfo> GetCustomerUnBilledInfo(int customerId, string vatInvoiceNum, int pageNo, int pageSize, out int rowCount, out decimal PaidAmountSum,
            out decimal AdjustmentAmountSum, out decimal TotalAmountSum, out decimal TotalVatAmount)
        {
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var p_ROW_SUM_TOTAL = new ObjectParameter("p_ROW_SUM_TOTAL", typeof(decimal));
            var p_ROW_SUM_ADJ = new ObjectParameter("p_ROW_SUM_ADJ", typeof(decimal));
            var p_ROW_SUM_PAID = new ObjectParameter("p_ROW_SUM_PAID", typeof(decimal));
            var p_VAT_AMOUNT = new ObjectParameter("p_VAT_AMOUNT", typeof(decimal));
            var data = _dbContext.Context.GetCustomerUnBilledInfo(customerId, vatInvoiceNum, pageNo, pageSize, p_ROW_COUNT, p_ROW_SUM_TOTAL, p_ROW_SUM_ADJ, p_ROW_SUM_PAID, p_VAT_AMOUNT).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            PaidAmountSum = string.IsNullOrEmpty(p_ROW_SUM_PAID.Value.ToString()) ? 0 : Convert.ToDecimal(p_ROW_SUM_PAID.Value);
            AdjustmentAmountSum = string.IsNullOrEmpty(p_ROW_SUM_ADJ.Value.ToString()) ? 0 : Convert.ToDecimal(p_ROW_SUM_ADJ.Value);
            TotalAmountSum = string.IsNullOrEmpty(p_ROW_SUM_TOTAL.Value.ToString()) ? 0 : Convert.ToDecimal(p_ROW_SUM_TOTAL.Value);
            TotalVatAmount = string.IsNullOrEmpty(p_VAT_AMOUNT.Value.ToString()) ? 0 : Convert.ToDecimal(p_VAT_AMOUNT.Value);
            return data;
        }

        /// <summary>
        /// Gets the customer infomation.
        /// </summary>
        /// <param name="financialAccountNumber">The financial account number.</param>
        /// <returns></returns>
        public CTCustomerDetails GetCustomerInfomation(string financialAccountNumber)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            var data = _dbContext.Context.GetCustomerInformation(financialAccountNumber, p_RESULT).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }

        /// <summary>
        /// Gets the payment history.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        public List<CTCustomerPayment> GetPaymentHistory(int customerId, int pageNo, int pageSize, out int rowCount)
        {
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.GetPaymentHistory(customerId, pageNo, pageSize, p_ROW_COUNT).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }

        public CTCustomerPayment GetCustomerPaymentByPaymentID(int PaymentID)
        {
            var data = _dbContext.Context.GetCustomerPaymentByPaymentID(PaymentID).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }


        public List<AREA> GetAllAreas(int emirateID)
        {
            return _dbContext.Context.GetAllAreasByCityID(emirateID).ToList();
        }

        //F157
        //public List<CUSTOMER_PRODUCT_PRICE_UPLIFT> GetUpliftDiscountProductById(int customerID, int productID)
        //{
        //    return _dbContext.Context.GetUpliftDiscountProductById(customerID, productID).ToList();
        //}

        //F158
        public List<BENEFICIARY_GROUP> GetCustomerGroupById(int groupID)
        {
            return _dbContext.Context.GetCustomerGroupById(groupID).ToList();
        }

        //F170
        public bool DeleteUpliftDiscountProduct(int customerID, int UpliftID, CTBase Audit)
        {
            _dbContext.Context.DeleteUpliftDiscountProduct(customerID, UpliftID, Audit.LastUserID, Audit.LastUpdateDate, Audit.LastLocationID);
            return true;
        }

        //F175
        public CUSTOMER GetCustomerInfo(int customerID)
        {
            var data = _dbContext.Context.GetCustomerInfo(customerID).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }

        //F184
        public CTIdentityCard GetIdentityCardInfo(int employeeNumber, int CustomerID)
        {
            var data = _dbContext.Context.GetIdentityCardInfo(employeeNumber, CustomerID).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }

        public FINANCIAL_ACCOUNT_TYPE GetFinancialAccountType(int financialAccTypeID)
        {
            var data = _dbContext.Context.GetFinancialAccountType(financialAccTypeID).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }

        //189
        public List<CUSTOMER_STATUS> GetAllCustomerStatusByID(int customerId)
        {
            return _dbContext.Context.GetAllCustomerStatusByID(customerId).ToList();
        }

        //194
        public void GetTransactionSummary(int customerID, int? beneficiaryID, DateTime? fromDate, DateTime? toDate, out decimal? transactionAmount, out decimal? adjustment, out decimal? totalAmount)
        {
            var p_TOTAL_TRANSACTION_AMOUNT = new ObjectParameter("p_TOTAL_TRANSACTION_AMOUNT", typeof(decimal));
            var p_TOTAL_ADJUSTMENT = new ObjectParameter("p_TOTAL_ADJUSTMENT", typeof(decimal));
            var p_TOTAL_AMOUNT = new ObjectParameter("p_TOTAL_AMOUNT", typeof(decimal));
            _dbContext.Context.GetTransactionSummary(customerID, beneficiaryID, fromDate, toDate, p_TOTAL_TRANSACTION_AMOUNT, p_TOTAL_ADJUSTMENT, p_TOTAL_AMOUNT);
            transactionAmount = Convert.ToDecimal(p_TOTAL_TRANSACTION_AMOUNT.Value);
            adjustment = Convert.ToDecimal(p_TOTAL_ADJUSTMENT.Value);
            totalAmount = Convert.ToDecimal(p_TOTAL_AMOUNT.Value);
        }

        public void GetTransactionSummaryInv(int customerID, int? beneficiaryID, DateTime? fromDate, DateTime? toDate, int INVOICE_ID, out decimal? transactionAmount, out decimal? adjustment, out decimal? totalAmount)
        {
            var p_TOTAL_TRANSACTION_AMOUNT = new ObjectParameter("p_TOTAL_TRANSACTION_AMOUNT", typeof(decimal));
            var p_TOTAL_ADJUSTMENT = new ObjectParameter("p_TOTAL_ADJUSTMENT", typeof(decimal));
            var p_TOTAL_AMOUNT = new ObjectParameter("p_TOTAL_AMOUNT", typeof(decimal));
            _dbContext.Context.GetTransactionSummaryInv(customerID, beneficiaryID, fromDate, toDate, p_TOTAL_TRANSACTION_AMOUNT, p_TOTAL_ADJUSTMENT, p_TOTAL_AMOUNT, INVOICE_ID);
            transactionAmount = Convert.ToDecimal(p_TOTAL_TRANSACTION_AMOUNT.Value);
            adjustment = Convert.ToDecimal(p_TOTAL_ADJUSTMENT.Value);
            totalAmount = Convert.ToDecimal(p_TOTAL_AMOUNT.Value);
        }

        //F200
        public string GetCustomerCodeByID(int customerID)
        {
            var p_CODE = new ObjectParameter("p_CODE", typeof(string));
            _dbContext.Context.GetCustomerCodeByID(customerID, p_CODE);
            return Convert.ToString(p_CODE.Value);
        }

        //203
        public List<CTProductDTO> GetAllProductForDifferentialPricing(int customerID)
        {
            return _dbContext.Context.GetAllProductForDifferentialPricing(customerID).ToList();
        }

        //204
        public List<CTUpliftCustomerProduct> GetAllUpliftDiscountsForProduct(int productID)
        {
            return _dbContext.Context.GetAllUpliftDiscountsForProduct(productID).ToList();
        }

        public int SaveAccountManager(ACCOUNT_MANAGER entity)
        {
            var accountManagerId = new ObjectParameter("P_ACCOUNT_MANAGER_ID", entity.ACCOUNT_MANAGER_ID);

            this._dbContext.Context.SaveAccountManager(accountManagerId, entity.USER_ID, entity.NAME, entity.MOBILE, entity.PHONE, entity.EMAIL, entity.FAX,
                entity.IS_ACTIVE, entity.LAST_UPDATED_USER_ID, entity.LAST_UPDATED_DATE, entity.LAST_LOCATION_ID);
            if (accountManagerId != null)
            {
                return (int)((decimal)accountManagerId.Value);
            }
            throw new Exception("Error While Inserting Account Manager");
        }

        public int SaveContact(CONTACT entity, string passwordSalt, string hashedPassword)
        {
            var contactId = new ObjectParameter("P_CONTACT_ID", entity.CONTACT_ID);

            this._dbContext.Context.SaveContact(contactId, entity.NAME, entity.MOBILE, entity.PHONE, entity.EMAIL, entity.FAX, entity.PIN,
                entity.NOTIFICATION_LANGUAGE_ID, entity.NOTIFICATION_CHANNEL_ID, entity.LAST_UPDATED_USER_ID, entity.LAST_UPDATED_DATE, entity.LAST_LOCATION_ID
                , passwordSalt, hashedPassword);
            if (contactId != null)
            {
                return (int)((decimal)contactId.Value);
            }
            throw new Exception("Error While Inserting Contact");
        }

        public bool SaveCustomerContact(CUSTOMER_CONTACT entity)
        {
            this._dbContext.Context.SaveCustomerContact(entity.CUSTOMER_ID, entity.CONTACT_ID, entity.CONTACT_TYPE_ID, entity.LAST_UPDATED_USER_ID, entity.LAST_UPDATED_DATE, entity.LAST_LOCATION_ID);
            return true;
        }

        public CTCustomerReceiptPreference GetCustomerReceiptPreference(int customerID)
        {
            var data = _dbContext.Context.GetCustomerReceiptPreference(customerID).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }

        public bool UpdateCustomerReceiptPreference(CTCustomerReceiptPreference entity, CTBase Audit)
        {
            _dbContext.Context.UpdateCustomerReceiptPreference(entity.CUSTOMER_ID, entity.RECEIPT_TYPE_ID, Audit.LastUserID, Audit.LastUpdateDate, Audit.LastLocationID);
            return true;
        }

        public bool DeleteCustomerReceiptPreference(int customerID, int? UserID, DateTime? LastUpdatedDate, int? LocationId)
        {
            _dbContext.Context.DeleteCustomerReceiptPreference(customerID, UserID, LastUpdatedDate, LocationId);
            return true;
        }

        //215
        public bool DeleteCustomerDriverCard(int paymentTokenID, int driverCardTokenID, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.DeleteCustomerDriverCard(paymentTokenID, driverCardTokenID, UserID, LastUpdatedDate, LocationId, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        //F216
        public List<CTMappedDriver> GetAllCustomerDriverCardForToken(int paymentTokenID)
        {
            return _dbContext.Context.GetAllCustomerDriverCardForToken(paymentTokenID).ToList();
        }

        //218
        public bool HasModulePrivilege(string userName, int moduleID)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.HasModulePrivilege(userName, moduleID, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        //219
        public bool HasPagePrivilege(string userName, int pageID)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.HasPagePrivilege(userName, pageID, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        //220
        public bool HasFunctionPrivilege(string userName, int functionID)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.HasFunctionPrivilege(userName, functionID, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }


        //220
        public bool hasAddTokenUsedBalanceGranted(int UserID)
        {
            var HasAccess = new ObjectParameter("P_Has_Access", typeof(Int32));
            _dbContext.Context.hasAddTokenUsedBalanceGranted(UserID, HasAccess);

            if (HasAccess != null && Convert.ToInt16(HasAccess.Value) == 1)
            {
                return true;
            }
            return false;
        }

        //226
        public int GetMinimumAccountActivationBalance()
        {
            var bALANCE = new ObjectParameter("bALANCE", typeof(decimal));
            _dbContext.Context.GetMinimumAccountActivationBalance(bALANCE);
            return Convert.ToInt32(bALANCE.Value);
        }

        //F279
        public bool AddCustomerInvoicePreference(int CustomerID, int InvoiceTypeID, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.AddCustomerInvoicePreference(CustomerID, InvoiceTypeID, UserID, LastUpdatedDate, LocationId, p_RESULT);
            if (p_RESULT != null && Convert.ToInt32(p_RESULT.Value) > -1)
                return Convert.ToBoolean(p_RESULT.Value);
            return false;
        }

        //F280
        public bool DeleteCustomerInvoicePreference(int Customer_ID, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.DeleteCustomerInvoicePreference(Customer_ID, UserID, LastUpdatedDate, LocationId, p_RESULT);
            if (p_RESULT != null)
                return Convert.ToBoolean(p_RESULT.Value);
            return false;
        }

        //F281
        public CTCustomerRefund GetCustomerRefundData(string Customer_CODE)
        {
            var data = _dbContext.Context.GetCustomerRefundData(Customer_CODE).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }

        //F282
        public bool RefundCustomer(int Customer_ID, string docRef, string Remarks, CTBase Audit, decimal RefundAmount)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.RefundCustomer(Customer_ID, docRef, Remarks, Audit.LastUserID, Audit.LastUpdateDate, Audit.LastLocationID, p_RESULT, RefundAmount);
            if (p_RESULT != null)
                return Convert.ToBoolean(p_RESULT.Value);
            return false;
        }


        //F285
        public List<CTSearchRequestResult> SearchRequest(CTSearchRequest dto, int? ModuleID)
        {
            return _dbContext.Context.SearchRequest(dto.RequestDateFrom, dto.RequestDateTo, dto.RequestTypeID, dto.RequestStatusId, dto.CustomerName, dto.BeneficiaryName, dto.TokenName, ModuleID, dto.AssignedToUserID).ToList();
        }

        //F304
        public bool IsRefundAllowedForCustomer(int customer_id)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.IsRefundAllowedForCustomer(customer_id, p_RESULT);

            if (p_RESULT != null)
                return Convert.ToBoolean(p_RESULT.Value);
            return false;
        }

        //305
        public int GetCustomerInvoicePreference(int customerID)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.GetCustomerInvoicePreference(customerID, p_RESULT);
            if (p_RESULT != null)
                return Convert.ToInt32(p_RESULT.Value);
            return 0;
        }

        //306
        public bool AddTerminationPendingCustomer(int customerID, int userID, DateTime LastUpdatedDate, int LocationId)
        {
            _dbContext.Context.AddTerminationPendingCustomer(customerID, userID, LastUpdatedDate, LocationId);
            return true;
        }

        //307
        public bool AddServiceTransaction(int ServiceID, int CustomerID, int? BeneficiaryID, int? TokenID, int UserId, int LastUpdatedUserID, DateTime LastUpdatedDate, int LastLocationID)
        {
            var p_result = new ObjectParameter("P_RESULT", typeof(decimal));
            _dbContext.Context.AddServiceTransaction(ServiceID, CustomerID, BeneficiaryID, TokenID, LastLocationID, UserId, LastUpdatedUserID, LastUpdatedDate, LastLocationID, p_result);
            if (p_result != null)
                return Convert.ToBoolean(p_result.Value);
            return false;
        }

        //308
        public List<CTCustomerPaymentTransaction> GetCreditDebitNoteHistory(int CustomerID, int PageID, int PageSize, out int RowCount)
        {
            var p_ROW_COUNT = new ObjectParameter("P_Row_Count", typeof(decimal));
            var data = _dbContext.Context.GetCreditDebitNoteHistory(CustomerID, PageID, PageSize, p_ROW_COUNT).ToList();
            RowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }

        //309
        public string GetOrderNumber(int TokenID)
        {
            var p_ORDER_NUMBER = new ObjectParameter("p_ORDER_NUMBER", typeof(string));
            _dbContext.Context.GetOrderNumber(TokenID, p_ORDER_NUMBER);
            return p_ORDER_NUMBER.Value.ToString();
        }

        //310
        public List<CTProductDTO> GetAllNonDieselProducts()
        {
            return _dbContext.Context.GetAllNonDieselProducts().ToList();
        }

        //311
        public CTProperty GetCurrentCustomerStatus(int CustomerID)
        {
            var data = _dbContext.Context.GetCurrentCustomerStatus(CustomerID).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }

        //312
        public CTRequestServiceFee ViewServiceFeeRequest(int RequestID)
        {
            var data = _dbContext.Context.ViewServiceFeeRequest(RequestID).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }

        //313
        public bool UpdateServiceFee(CTServiceFee entity)
        {
            var P_RESULT = new ObjectParameter("P_RESULT", typeof(decimal));
            _dbContext.Context.UpdateServiceFee(entity.Service_fee_ID, entity.Service_ID, entity.Customer_Status_ID, entity.Customer_Type_ID, entity.Account_Type_ID,
                entity.Classification_ID, entity.ISPremier, entity.Location_ID, entity.Fee, entity.IsActive, entity.LastUpdatesUserID, entity.LastUpdatedDate, entity.LastLocationID, P_RESULT);
            if (Convert.ToInt32(P_RESULT.Value) == 1)
                return true;
            return false;
        }

        //314
        public bool IsRenewalRequest(int TokenID)
        {
            var p_result = new ObjectParameter("p_result", typeof(decimal));
            _dbContext.Context.IsRenewalRequest(TokenID, p_result);
            return Convert.ToBoolean(p_result.Value);
        }

        public CTRequest GetRequestById(int requestID)
        {
            var data = _dbContext.Context.GetRequestByID(requestID).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }

        public CTRequestCustomerAddress GetRequestCustomerAddress(int addressID)
        {
            var data = _dbContext.Context.GetRequestCustomerAddressById(addressID).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }

        public CTRequestCustomerAddress GetRequestCustomerAddressHistory(int addressID)
        {
            var data = _dbContext.Context.GetRequestCustomerAddresshISTORY(addressID).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }

        public CTRequestCustomerAddress GetCustomerAddress(int addressID)
        {
            var data = _dbContext.Context.GetCustomerAddress(addressID).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }

        public List<CTRequestCustomerContacts> GetRequestCustomerContacts(int requestCustomerID)
        {
            return _dbContext.Context.GetRequestCustomerContacts(requestCustomerID).ToList();
        }

        public List<CTRequestCustomerContacts> GetCustomerContacts(int CustomerID)
        {
            return _dbContext.Context.GetCustomerContacts(CustomerID).ToList();
        }


        //F315
        public bool RemoveAttachment(CTCustomerAttachment entity)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.RemoveAttachment(entity.CUSTOMER_ID, entity.REQUESTDOCUMENTID, entity.LastUserID, DateTime.Now, entity.LastLocationID, p_RESULT);
            if (p_RESULT != null)
                return Convert.ToBoolean(p_RESULT.Value);
            return false;
        }

        //F318
        public bool IsIDAlreadyRegistered(int Mode, int IDType, string IDNumber, int? CUSTOMERID, int? BeneficiaryID, out string pMessage)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            var p_Data = new ObjectParameter("P_DATA", typeof(string));
            _dbContext.Context.IsIDAlreadyRegistered(Mode, IDType, IDNumber, CUSTOMERID, BeneficiaryID, p_Data, p_RESULT);
            pMessage = p_Data.Value.ToString();
            if (p_RESULT != null)
                return Convert.ToBoolean(p_RESULT.Value);
            return false;
        }

        //F318
        public List<FAMILY> GetAllFamily()
        {
            return _dbContext.Context.GetAllFamily().ToList();
        }

        //F322
        public void GetOpeningClosingBalance(int CustomerID, DateTime FromDate, DateTime ToDate, out decimal? OpeningBalance, out decimal? ClosingBalance)
        {
            var p_OPENNING_BALANCE = new ObjectParameter("p_OPENNING_BALANCE", typeof(decimal));
            var p_CLOSING_BALANCE = new ObjectParameter("p_CLOSING_BALANCE", typeof(decimal));
            _dbContext.Context.GetOpeningClosingBalance(CustomerID, FromDate, ToDate, p_OPENNING_BALANCE, p_CLOSING_BALANCE);
            OpeningBalance = Convert.ToDecimal(p_OPENNING_BALANCE.Value);
            ClosingBalance = Convert.ToDecimal(p_CLOSING_BALANCE.Value);
        }

        //F323
        public int GetDieselProductID()
        {
            var p_ID = new ObjectParameter("DIESEL_ID", typeof(Int32));
            _dbContext.Context.GetDieselProductID(p_ID);
            return Convert.ToInt32(p_ID.Value);
        }

        //F324
        public int IsDieselRestricted(int tokenID)
        {
            var pResult = new ObjectParameter("P_RESULT", typeof(Int32));
            _dbContext.Context.IsDieselRestricted(tokenID, pResult);
            return Convert.ToInt32(pResult.Value);
        }

        //f325
        public List<CTLocation> GetAllCMSLocations()
        {
            return _dbContext.Context.GetAllCMSLocations().ToList();
        }

        //F326
        public bool UpdateCeilingLimit(int CeilingLimitID, decimal LimitValue, int UserId, int LocationId)
        {
            var _CeilingLimitID = new ObjectParameter("P_CEILING_LIMIT_ID", CeilingLimitID);
            _dbContext.Context.UpdateCeilingLimit(_CeilingLimitID, LimitValue, 1, UserId, DateTime.Now, LocationId);
            return true;
        }

        //F326
        public CEILING_LIMIT GetCeilingLimit()
        {
            var data = _dbContext.Context.GetCeilingLimit().ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }

        public List<CTDictionary> GetGLCostCentre()
        {
            var data = _dbContext.Context.GetGLCostCentre().ToList();
            return data;

        }

        //F327
        public bool TerminateCustomer(int customerID, int UserId, int LocationID, out int RefundAmount)
        {
            var pResult = new ObjectParameter("P_RESULT", typeof(int));
            var pRefundAmount = new ObjectParameter("P_REFUND_AMOUNT", typeof(int));

            _dbContext.Context.TerminateCustomer(customerID, pRefundAmount, UserId, LocationID, pResult);

            if (Convert.ToInt16(pResult.Value) == 0)
            {
                RefundAmount = 0;
                return false;
            }
            else
            {
                RefundAmount = Convert.ToInt32(pRefundAmount.Value);
                return true;
            }
        }

        public CTDictionary GetYearByID(int yearID)
        {
            var data = _dbContext.Context.GetYearByID(yearID).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;

        }

        public bool IsPremierAccessGranted(int userID)
        {
            var _hasAccess = new ObjectParameter("P_Has_Premier_Access", typeof(decimal));
            _dbContext.Context.IsPremierAccessGranted(userID, _hasAccess);
            return Convert.ToBoolean(_hasAccess.Value);
        }

        public bool IsUpdateVehicleInfoGranted(int userID)
        {
            var _hasAccess = new ObjectParameter("P_Has_Premier_Access", typeof(decimal));
            _dbContext.Context.IsUpdateVehicleInfoGranted(userID, _hasAccess);
            return Convert.ToBoolean(_hasAccess.Value);
        }

        public bool IsViewAuditGranted(int userID)
        {
            var _hasAccess = new ObjectParameter("P_Has_ViewAudit_Access", typeof(decimal));
            _dbContext.Context.IsViewAuditGranted(userID, _hasAccess);
            return Convert.ToBoolean(_hasAccess.Value);
        }

        public NOTIFICATION_MESSAGE GetNotificationMessageByCode(string MessageCode)
        {
            var data = _dbContext.Context.GetNotificationMessageByCode(MessageCode).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }

        public List<PAYMENT_TYPE> GetCreditDebitPaymentTypes()
        {
            return _dbContext.Context.GetCreditDebitPaymentTypes().ToList();
        }

        public int GetTerminationCutOffPeriod()
        {
            var pResult = new ObjectParameter("VALUE_STRING", typeof(Int32));
            _dbContext.Context.GetTerminationCutOffPeriod("TerminationRefundWaitTimeInDays", pResult);
            return Convert.ToInt32(pResult.Value);

        }

        public List<CTIssuanceLocationLoad> GetCardCentreLoad(int cardCentreId, int preferredMonthId, int preferredYear)
        {
            return _dbContext.Context.GetCardCentreLoad(cardCentreId, preferredMonthId, preferredYear).ToList();
        }
        public List<CTIssuanceLocationLoad> GetVehicleDepotLoad(int depotId, int preferredMonthId, int preferredYear)
        {
            return _dbContext.Context.GetVehicleDepotLoad(depotId, preferredMonthId, preferredYear).ToList();
        }

        public bool DeleteCsutomerFromCMSOrRequest(int? p_CUSTOMER_ID, int? p_REQUEST_ID)
        {
            var pResult = new ObjectParameter("P_RESULT", typeof(Int32));
            _dbContext.Context.DeleteCsutomerFromCMSOrRequest(p_CUSTOMER_ID, p_REQUEST_ID, pResult);
            return Convert.ToBoolean(pResult.Value);
        }

        public bool IsCustomerCodeValid(string code)
        {
            var pResult = new ObjectParameter("P_RESULT", typeof(decimal));
            _dbContext.Context.IsCustomerCodeValid(code, pResult);
            return Convert.ToBoolean(pResult.Value);
            // return false;
        }
        public string GetFullNationality(string Code)
        {
            var pCountryName = new ObjectParameter("P_COUNTRY_NAME", typeof(string));
            _dbContext.Context.GetFullNationality(Code, pCountryName);
            return Convert.ToString(pCountryName.Value);

        }

        public bool EventLog(DateTime _DateTime, string source, int LogLevel, string Message, string DetailedMessage)
        {
            var pResult = new ObjectParameter("P_RESULT", typeof(int));
            _dbContext.Context.EventLog(_DateTime, source, LogLevel, Message, DetailedMessage, pResult);
            return Convert.ToBoolean(pResult.Value);
        }
        public List<CTCustomerQuota> GetCustomerQuota(int CustomerId, int? ProductId)
        {
            return _dbContext.Context.GetCustomerQuota(CustomerId, ProductId).ToList();

        }

        public CTCustomerQuota GetAccountQuotaByQuotaId(int QuotaId)
        {
            var data = _dbContext.Context.GetAccountQuotaByQuotaId(QuotaId).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }
        public int GetNationalityIDByName(string Name)
        {
            var pResult = new ObjectParameter("P_RESULT", typeof(int));
            _dbContext.Context.GetNationalityIDByName(Name, pResult);
            return Convert.ToInt32(pResult.Value);
        }

        public int GetEmployeeNoForSerial(string SerialNo)
        {
            var pResult = new ObjectParameter("P_RESULT", typeof(int));
            _dbContext.Context.GetEmployeeNoForSerial(SerialNo, pResult);
            return Convert.ToInt32(pResult.Value);
        }
        public bool IsTokenSerialAlreadyExist(int? TokenId, string TokenSerial, out string Remark)
        {
            var pResult = new ObjectParameter("P_RESULT", typeof(int));
            var pRemark = new ObjectParameter("P_MESSAGE", typeof(int));
            _dbContext.Context.IsTokenSerialAlreadyExist(TokenId, TokenSerial, pResult, pRemark);
            Remark = Convert.ToString(pRemark.Value);
            return Convert.ToBoolean(pResult.Value);
        }
        public bool RenewKNPEmployeeCard(int tokenID, string newCardSerial, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            var pResult = new ObjectParameter("P_RESULT", typeof(int));
            _dbContext.Context.RenewKNPEmployeeCard(tokenID, newCardSerial, UserID, LastUpdatedDate, LocationId, pResult);
            return Convert.ToBoolean(pResult.Value);
        }

        public int SaveCustomerQuota(int? CustomerQuotaId, int custromerId, int productId, decimal Quota, int userId, int locationId)
        {
            ObjectParameter pCustomerQuotaId = null;
            if (CustomerQuotaId != null)
                pCustomerQuotaId = new ObjectParameter("P_CUSTOMER_QUOTA_ID", CustomerQuotaId);
            else
                pCustomerQuotaId = new ObjectParameter("P_CUSTOMER_QUOTA_ID", typeof(decimal?));

            _dbContext.Context.SaveCustomerQuota(pCustomerQuotaId, custromerId, productId, Quota, locationId, userId);
            return Convert.ToInt32(pCustomerQuotaId.Value);
        }
        public bool DeleteCustomerQuota(int customerId, int productId, int userId, int locationId)
        {
            _dbContext.Context.DeleteCustomerQuota(customerId, productId, locationId, userId);
            return true;
        }

        public bool IsKNPCCardAlreadyRegistered(string Serial)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.IsKNPCCardAlreadyRegistered(Serial, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        public decimal GetCustomerQuotaConsumption(int customerId, int productId)
        {
            ObjectParameter consumption = new ObjectParameter("P_QUOTA_CONSUMPTION", typeof(decimal));
            _dbContext.Context.GetCustomerQuotaConsumption(customerId, productId, consumption);
            return Convert.ToDecimal(consumption.Value);
        }

        public List<CTSearchTokenToDeliverResult> SearchCustomerTokensReadyForDelivery(CTSearchTokenToDeliver entity, out int totalCount)
        {
            var pTotalCount = new ObjectParameter("P_TOTAL_COUNT", typeof(int));
            var res = _dbContext.Context.SearchCustomerTokensReadyForDelivery(entity.TokenCode, entity.TokenName, entity.TokenTypeID, entity.BeneficiaryID, entity.BeneficiaryName, entity.BeneficiaryCode, entity.CustomerCode, entity.CustomerName,
                entity.TokenSerial, entity.CustomerID, entity.PageNumber, entity.PageSize, pTotalCount).ToList();
            totalCount = (!string.IsNullOrEmpty(Convert.ToString(pTotalCount.Value))) ? int.Parse(Convert.ToString(pTotalCount.Value)) : 0;
            return res;
        }

        public List<CTAccountTrnsBalance> GetAccountTransactionBalance(
                   int CustomerId,
                   Nullable<System.DateTime> DateFrom,
                   Nullable<System.DateTime> DateTo,
                   Nullable<decimal> TransTypeId,
                   string BeneficiaryNo,
                   string BeneficiaryName,
                   Nullable<decimal> TokenTypeId,
                   string TokenSerial,
                   string VatInvoiceNumber,
                   short? IsPremiumService,
                   int? ExemptionTypeId,
                   Nullable<decimal> PageNo,
                   Nullable<decimal> PageSize,
                   out int rowsCount
               )
        {
            var rowCountParameter = new ObjectParameter("P_Row_Count", typeof(decimal));
            var result = _dbContext.Context.GetAccountTransBalance(CustomerId, DateFrom, DateTo, BeneficiaryNo, BeneficiaryName, TokenTypeId, TokenSerial, VatInvoiceNumber, IsPremiumService, PageNo, PageSize, rowCountParameter).ToList();
            rowsCount = Convert.ToInt32(rowCountParameter.Value);
            return result;

        }

        public List<CTReceiptTransProduct> GetProductListByTransId(int? TransactionId)
        {
            return _dbContext.Context.GetProductListByTransId(TransactionId).ToList();
        }

        public CTPrintReceiptData GetPrintReceiptData(int? CustomerId, int? TransactionId, int? PaymentTypeId, string TransactionType)
        {
            var receiptData = _dbContext.Context.GetPrintReceiptData(CustomerId, TransactionId, PaymentTypeId, TransactionType).ToList();
            if (receiptData != null && receiptData.Count > 0)
                return receiptData[0];
            else
                return null;
        }

        public List<CTReceiptDetails> GetReceiptDetails(int? TransactionId)
        {
            return _dbContext.Context.GetReceiptDetails(TransactionId).ToList();
        }

        public List<CTAccountTrnsTypes> GetAllTrnsTypes()
        {
            return _dbContext.Context.GetAccountTrnsTypes().ToList();
        }

        public List<CTBillingFrequency> GetAllBillingFrequency()
        {
            return _dbContext.Context.GetAllBillingFrequency().ToList();
        }

        public bool ISBeneficiaryCreationAllowed(int? CustomerId)
        {
            var pRes = new ObjectParameter("P_RES", typeof(decimal));
            _dbContext.Context.IsBeneficiaryCreationAllowed(CustomerId, pRes);
            return Convert.ToBoolean(pRes.Value);
            // return false;
        }


        public int ISCompanyRegistrationIDUnique(int? CustomerID, int? RequestCustomerID, string CompanyID, out int Response)
        {
            var p_Res = new ObjectParameter("p_RES", typeof(decimal));
            _dbContext.Context.ISCompanyRegistrationIDUnique(CustomerID, RequestCustomerID, CompanyID, p_Res);
            Response = Convert.ToInt32(p_Res.Value);
            return Response;
        }
        public void ValidateDuplicateMobileNumber(string mobile, int? customerId)
        {
            _dbContext.Context.ValidateDuplicateMobileNumber(mobile, customerId);
        }

        public int GetBeneficiaryCount(int? CustomerId)
        {
            var pRes = new ObjectParameter("P_RES", typeof(decimal));
            _dbContext.Context.GetBeneficiaryCount(CustomerId, pRes);
            return Convert.ToInt32(pRes.Value);
            // return false;
        }
        public bool CheckNationalIDExistForIndPrepaid(string NationalID)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.CheckNationalIDExistForIndPrepaid(NationalID, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }
        public List<CTCustomerTypes> GetAllCustomerTypes()
        {
            return _dbContext.Context.GetAllCustomerTypes().ToList();
        }
        public List<CUSTOMER_ACCOUNT_TYPE> GetAllAccountTypes()
        {
            return _dbContext.Context.GetAllAccountTypes().ToList();
        }

        public List<CTProperty> GetAllNotificationPreferences()
        {
            return _dbContext.Context.GetAllNotificationPreferences().ToList();
        }

        #region WorkFlow

        public List<RQST_RQST_CUSTOMER_CNTCT_HIST> RequestCustomerContacHistMapping(int CustomerID)
        {
            return _dbContext.Context.RequestCustomerContacHistMapping(CustomerID).ToList();
        }
        public List<CTRequestCustomerContacts> GetrequestCustomerContactHistory(int CustomerID)
        {
            return _dbContext.Context.GetrequestCustomerContactHistory(CustomerID).ToList();
        }
        public List<RQST_REQUEST_CUSTOMER_CONTACT> RequestCustomerContact(int customer_id)
        {
            return _dbContext.Context.RequestCustomerContact(customer_id).ToList();
        }
        //700
        public int CreateWorkflowInstance(int RequestID, int RequestTypeID, int CurrentUserID, int Location_id)
        {
            var WorkFlowInstanceID = new ObjectParameter("WorkFlowInstanceID", typeof(decimal));
            _dbContext.Context.CreateWorkflowInstance(RequestID, RequestTypeID, CurrentUserID, Location_id, WorkFlowInstanceID);
            return Convert.ToInt32(WorkFlowInstanceID.Value);
        }
        //701
        public List<CTProperty> GetAllRequestTypes()
        {
            return _dbContext.Context.GetAllRequestTypes().ToList();
        }
        //702
        public List<CTProperty> GetAllRequestStatus()
        {
            return _dbContext.Context.GetAllRequestStatus().ToList();
        }
        //703
        public List<CTSearchRQSTRequestResult> SearchAgentRequest(CTSearchRequest searchdto, int pageNo, int pageSize, out int rowCount)
        {
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.SearchAgentRequest(searchdto.RequestID, searchdto.RequestCode, searchdto.RequestDateFrom, searchdto.RequestDateTo, searchdto.RequestTypeID, searchdto.CustomerName,
                searchdto.BeneficiaryName, searchdto.TokenName, searchdto.AssignedToUserID, searchdto.CustomerCode, searchdto.TokenCode, pageSize, pageNo, p_ROW_COUNT).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }
        //704
        public List<CTSearchRQSTRequestResult> SearchApproverRequest(CTSearchRequest searchdto, int pageNo, int pageSize, out int rowCount)
        {
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.SearchApproverRequest(searchdto.RequestID, searchdto.RequestCode, searchdto.RequestDateFrom, searchdto.RequestDateTo, searchdto.RequestTypeID, searchdto.RequestStatusId, searchdto.CustomerName,
                searchdto.BeneficiaryName, searchdto.TokenName, searchdto.AssignedToUserID, searchdto.CustomerCode, searchdto.TokenCode, pageSize, pageNo, p_ROW_COUNT).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }
        public List<CTSearchRQSTRequestResult> SearchFinalApproverRequest(CTSearchRequest searchdto, int pageNo, int pageSize, out int rowCount)
        {
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.SearchFinalApproverRequest(searchdto.RequestID, searchdto.RequestCode, searchdto.RequestDateFrom, searchdto.RequestDateTo, searchdto.RequestTypeID, searchdto.RequestStatusId, searchdto.CustomerName,
                searchdto.BeneficiaryName, searchdto.TokenName, searchdto.AssignedToUserID, searchdto.CustomerCode, searchdto.TokenCode, pageSize, pageNo, p_ROW_COUNT).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }
        public List<CTSearchPendingRequestResult> SearchPendingRequest(CTSearchRequest searchdto, int pageNo, int pageSize, out int rowCount)
        {
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.SearchPendingRequest(searchdto.RequestDateFrom, searchdto.RequestDateTo, searchdto.RequestCode, searchdto.RequestTypeID, searchdto.CustomerName, searchdto.CustomerCode,
                searchdto.BeneficiaryName, searchdto.TokenName, searchdto.TokenCode, pageSize, pageNo, p_ROW_COUNT).ToList();
            //searchdto.AssignedToUserID, 
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }
        public List<CTSearchEscalatedRequestResult> SearchEscalatedRequest(CTSearchRequest searchdto, int pageNo, int pageSize, out int rowCount)
        {
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.SearchEscalatedRequest(searchdto.RequestDateFrom, searchdto.RequestDateTo, searchdto.RequestCode, searchdto.RequestTypeID, searchdto.CustomerName, searchdto.CustomerCode,
                searchdto.BeneficiaryName, searchdto.TokenName, searchdto.TokenCode, pageSize, pageNo, p_ROW_COUNT).ToList();
            //searchdto.AssignedToUserID, 
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }
        public int ProcessEscalationRequest(int WorkFlowInstanceID, int RequestId, string Comments, int CurrentUserid, int LocationID, int? EscalatedUserTo, int? EscalteRoleId)
        {
            var p_WF_INSTANCE_ID = new ObjectParameter("p_WF_INSTANCE_ID", typeof(decimal));
            _dbContext.Context.ProcessEscalationRequest(p_WF_INSTANCE_ID, RequestId, WorkFlowInstanceID, CurrentUserid, LocationID, EscalatedUserTo, EscalteRoleId, DateTime.Now, Comments);
            return Convert.ToInt32(p_WF_INSTANCE_ID.Value);
        }

        //705
        public List<CTSearchRQSTRequestResult> SearchRequestHistory(CTSearchRequest searchdto, int pageNo, int pageSize, out int rowCount)
        {
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.SearchRequestHistory(searchdto.RequestID, searchdto.RequestCode, searchdto.RequestDateFrom, searchdto.RequestDateTo, searchdto.RequestTypeID, searchdto.RequestStatusId,
                searchdto.CustomerName, searchdto.BeneficiaryName, searchdto.TokenName, searchdto.AssignedToUserID, searchdto.CustomerCode, searchdto.TokenCode, pageSize, pageNo, p_ROW_COUNT).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }
        //706
        public CTRequestWorkflowHistoryDTO ViewRequestWorkflowHistory(int RequestID)
        {
            var data = _dbContext.Context.ViewRequestWorkflowHistory(RequestID).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }
        //707
        public bool UpdateRequestStatus(int RequestID, int RequestStatusID, string CustomerCode, string Remarks, int UserID, int LocationID)
        {
            _dbContext.Context.UpdateRequestStatus(RequestID, RequestStatusID, CustomerCode, Remarks, UserID, LocationID);
            return true;
        }
        //F708
        public CTRequestCustomer ViewAccountRequest(int RequestID)
        {
            var data = _dbContext.Context.ViewAccountRequest(RequestID).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }
        //709
        public CTRequestWorkOrder ViewWorkOrderRequest(int RequestID)
        {
            var data = _dbContext.Context.ViewWorkOrderRequest(RequestID).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }
        //F710
        public CTRequestPersonalization ViewPersonalizationIssueRequest(int RequestID)
        {
            var data = _dbContext.Context.ViewPersonalizationIssueRequest(RequestID).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }
        //711
        public CTRequestAccountClosure ViewAccountClosureRequest(int RequestID)
        {
            var data = _dbContext.Context.ViewAccountClosureRequest(RequestID).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }
        //F712
        public List<CTRequestDocument> GetRequestDocuments(int RequestTypeID)
        {
            return _dbContext.Context.GetRequestDocuments(RequestTypeID).ToList();
        }
        //F713
        public List<RQST_REQUEST_ATTACHEMENT> ViewAllRequestUploadedAttachments(int requestID)
        {
            return _dbContext.Context.ViewAllRequestUploadedAttachments(requestID).ToList();
        }
        //F714
        public RQST_REQUEST_ATTACHEMENT ViewRequestUploadedAttachmentByID(int AttachmentID)
        {
            var data = _dbContext.Context.ViewRequestUploadedAttachmentByID(AttachmentID).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }
        //F294
        public bool UploadAttachment(CTCustomerAttachment entity)
        {
            var P_AttachmentId = new ObjectParameter("P_AttachmentId", entity.ATTACHMENT_ID);
            _dbContext.Context.UploadAttachment(P_AttachmentId, entity.CUSTOMER_ID, entity.REQUESTDOCUMENTID, entity.ATTACHMENT, entity.FILEEXTENSION, entity.LastUserID, entity.LastLocationID);

            if (P_AttachmentId != null && Convert.ToInt32(P_AttachmentId.Value) > -1)
                return Convert.ToBoolean(P_AttachmentId.Value);

            return false;
        }
        //F715
        public bool UploadRequestAttachment(CTRQSTAttachment entity)
        {
            var P_AttachmentId = new ObjectParameter("P_REQST_AttachmentId", entity.ATTACHMENT_ID);
            _dbContext.Context.UploadRequestAttachment(P_AttachmentId, entity.REQUEST_ID, entity.REQUESTDOCUMENTID, entity.ATTACHMENT, entity.FILEEXTENSION,
                entity.LastUserID, entity.LastLocationID);

            if (P_AttachmentId != null && Convert.ToInt32(P_AttachmentId.Value) > -1)
                return Convert.ToBoolean(P_AttachmentId.Value);

            return false;
        }
        //716
        public int GetLastWorkFlowInstanceID(int RequestId)
        {
            var WorkFlowInstanceID = new ObjectParameter("WorkFlowInstanceID", typeof(decimal));
            _dbContext.Context.GetLastWorkFlowInstanceID(RequestId, WorkFlowInstanceID);
            return Convert.ToInt32(WorkFlowInstanceID.Value);
        }
        //717
        public int InitiateRequestWorkflow(int WorkFlowInstanceID, int? AssignedUserID, int? AssignedRoleID, int ActionID, string Comments, int CurrentUserid, int LocationID)
        {
            var V_WF_INSTANCE_ID = new ObjectParameter("V_WF_INSTANCE_ID", typeof(decimal));
            _dbContext.Context.InitiateRequestWorkflow(WorkFlowInstanceID, AssignedUserID, AssignedRoleID, ActionID, Comments, CurrentUserid, LocationID, V_WF_INSTANCE_ID);
            return Convert.ToInt32(V_WF_INSTANCE_ID.Value);
        }
        //718
        public int ProcessWorkFlowStep(int WorkFlowInstanceID, int? AssignedUserID, int? AssignedRoleID, int ActionID, string Comments, int CurrentUserid, int LocationID, out int IsApprovalComplete)
        {
            var V_WF_INSTANCE_ID = new ObjectParameter("V_WF_INSTANCE_ID", typeof(decimal));
            var P_IsApprovalComplete = new ObjectParameter("P_IS_APPROVAL_COMPLETE", typeof(decimal));
            _dbContext.Context.ProcessWorkFlowStep(WorkFlowInstanceID, AssignedUserID, AssignedRoleID, ActionID, Comments, CurrentUserid, LocationID, V_WF_INSTANCE_ID, P_IsApprovalComplete);
            IsApprovalComplete = Convert.ToInt32(P_IsApprovalComplete.Value);
            return Convert.ToInt32(V_WF_INSTANCE_ID.Value);
        }
        //F719
        public List<CTSearchTokenIssuanceResult> SearchTokenIssuance(CTSearchTokenIssuance entity, int pageNo, int pageSize, out int rowCount)
        {
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.SearchTokenIssuance(entity.CustomerCode, entity.CustomerName, entity.CompanyRegistrationID, entity.MobileNumber, entity.CustomerstatusID, entity.ClassificationID, entity.RegsiterFromDate,
                entity.RegsiterToDate, entity.FinancialAccountNumber, entity.CustomerAccountTypeID, entity.BeneficiaryCode, entity.BeneficiaryName, entity.EmployeeNumber, entity.TokenCode, entity.TokenName, entity.TokenTypeID,
                entity.TokenSerial, entity.TokenStatusID, pageSize, pageNo, p_ROW_COUNT).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;

        }
        //F720
        public int AddAccountRequestWFHistory(CTRequestWFHistoryCustomer entity)
        {
            var RequestCustomerId = new ObjectParameter("P_RequestCustomerId", entity.RequestCustomerId);
            _dbContext.Context.AddAccountRequestWFHistory(RequestCustomerId, entity.RequestID, entity.Name, entity.CustomerTypeID, entity.CompanyID,
                entity.ClassificationID, entity.AccountTypeID, entity.NationalityID, entity.NationalID, entity.BasicAddressID, entity.BillingAddressID,
                entity.ShippingAddressID, entity.FamilyID, entity.FinancialAccountTypeID, entity.FinancialAccountNo, entity.AccountManagerID,
                entity.BillingFrequencyID, entity.NotificationThreshold, entity.SuspensionThreshold, entity.IsVIP, entity.RequestSourceTypeID, entity.CardCentreID,
                entity.UnitID, entity.BillingFrequencyDayOrder, entity.PaymentTerms, entity.IdentificationTypeID, entity.IsActive, entity.EnableDefaultBeneficiary,
                entity.LastLocationID, entity.LastUserID, entity.MonthlyVolumeID, entity.GENDER, entity.DATEOFBIRTH);
            return Convert.ToInt32(RequestCustomerId.Value);
        }
        //F721
        public bool AddWorkOrderRequestWFHistory(CTRequestWFHistoryWorkOrderINput entity)
        {
            var P_RequestWorkOrderID = new ObjectParameter("P_RequestWorkOrderID", typeof(decimal));
            _dbContext.Context.AddWorkOrderRequestWFHistory(entity.RequestID, P_RequestWorkOrderID, entity.TokenName, entity.PreferredLocationId,
                entity.PreferredDateFrom, entity.PreferredDateTo, entity.ScheduledLocationID, entity.ScheduledDate, entity.AuthPersonIDType, entity.AuthPersonIDNumber,
                entity.isactive, entity.LastUserID, entity.ReasonID);

            if (P_RequestWorkOrderID != null && Convert.ToInt32(P_RequestWorkOrderID.Value) > -1)
                return Convert.ToBoolean(P_RequestWorkOrderID.Value);

            return false;
        }
        //F722
        public bool AddPersonalizationRequestWFHistory(RequestWFHistoryPersonalizationNput entity)
        {
            var PersonalizationID = new ObjectParameter("P_RequestPersonalOrderID", typeof(decimal));
            _dbContext.Context.AddPersonalizationRequestWFHistory(entity.WFInstanceID, PersonalizationID, entity.TokenName, entity.PreferredLocationId,
                entity.PreferredDateFrom, entity.PreferredDateTo, entity.ScheduledLocationID, entity.ScheduledDate, entity.AuthPersonIDType, entity.AuthPersonIDNumber,
                entity.IsActive, entity.LastUserID, entity.ReasonID);

            if (PersonalizationID != null && Convert.ToInt32(PersonalizationID.Value) > -1)
                return Convert.ToBoolean(PersonalizationID.Value);

            return false;
        }
        //F723
        public bool UploadRequestWFHistoryAttachment(CTRequestWFHistoryAttachment entity)
        {
            var RequestAttachmentId = new ObjectParameter("RequestAttachmentId", entity.Request_Attachment_Id);
            _dbContext.Context.UploadRequestWFHistoryAttachment(RequestAttachmentId, entity.WF_Instance_ID, entity.REQUEST_DOCUMENT_ID, entity.ATTACHMENT,
                entity.FILE_EXTENSION, entity.Last_Updated_User_ID, entity.Last_Location_ID);

            if (RequestAttachmentId != null && Convert.ToInt32(RequestAttachmentId.Value) > -1)
                return Convert.ToBoolean(RequestAttachmentId.Value);

            return false;
        }
        //F724
        //List<RequestWFHistoryAttachmentDTO>
        public bool RemoveRequestWFHistoryAttachment(CTRequestWFHistoryAttachment entity)
        {
            return true;
        }
        //F725
        public CTRequestWFHistoryCustomer ViewAccountRequestWFHistory(int WFInstanceID)
        {
            var data = _dbContext.Context.ViewAccountRequestWFHistory(WFInstanceID).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;

        }
        //F726
        public CTRequestWFHistoryWorkOrderINput ViewWorkOrderRequestWFHistory(int WFInstanceID)
        {
            var data = _dbContext.Context.ViewWorkOrderRequestWFHistory(WFInstanceID).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }
        //F727
        public RequestWFHistoryPersonalizationNput ViewPersonalizationIssueRequestWFHistory(int WFInstanceID)
        {
            var data = _dbContext.Context.ViewPersonalizationIssueRequestWFHistory(WFInstanceID).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }
        //F728
        public List<CTRequestWFHistoryAttachment> ViewAllRequestWFHistoryUploadedAttachments(int WFInstanceID)
        {
            return _dbContext.Context.ViewAllRequestWFHistoryUploadedAttachments(WFInstanceID).ToList();

        }
        //F729
        public CTRequestWFHistoryAttachment ViewRequestWFHistoryUploadedAttachmentByID(int AttachmentID)
        {
            var data = _dbContext.Context.ViewRequestWFHistoryUploadedAttachmentByID(AttachmentID).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }
        //F730
        public bool IsFinalApproverStep(int RequestID)
        {
            var resutl = new ObjectParameter("P_RESULT", typeof(decimal));
            _dbContext.Context.IsFinalApproverStep(RequestID, resutl);
            return Convert.ToBoolean(resutl.Value);
        }
        //F731
        public int GetpreviousWorkFlowInstanceID(int PCurrentWorkFlowInstanceID)
        {
            var result = new ObjectParameter("P_RESULT", typeof(decimal));
            _dbContext.Context.GetpreviousWorkFlowInstanceID(PCurrentWorkFlowInstanceID, result);
            return Convert.ToInt32(result.Value);

        }
        //F732
        public int GenerateAccountClosureRequest(int CustomerID, int UserID, DateTime LastUpdatedDate, int LocationID)
        {
            var RequestID = new ObjectParameter("P_RequestID", typeof(decimal));
            _dbContext.Context.GenerateAccountClosureRequest(CustomerID, UserID, LastUpdatedDate, LocationID, RequestID);
            return Convert.ToInt32(RequestID.Value);

        }
        public int AddCreditDebitRQST(int CustomerID, int p_PAYMENT_TYPE_ID, decimal p_TRANSACTION_AMOUNT, int p_PAYMENT_METHOD_ID, string p_REMARKS, int UserID, int LocationID)
        {
            var RequestID = new ObjectParameter("P_REQUEST_ID", typeof(decimal));
            _dbContext.Context.AddCreditDebitRQST(RequestID, CustomerID, p_PAYMENT_TYPE_ID, p_TRANSACTION_AMOUNT, p_PAYMENT_METHOD_ID, p_REMARKS, UserID, LocationID);
            return Convert.ToInt32(RequestID.Value);

        }
        public int AddRefundRQST(int CustomerID, int p_PAYMENT_TYPE_ID, decimal p_TRANSACTION_AMOUNT, int p_PAYMENT_METHOD_ID, string p_REMARKS, int UserID, int LocationID, int RefundTypeID, string paymentDOCRef, string BankName, string AccountHolderName, string AccountNumber, string IBANNumber, int? CountryId)
        {
            var RequestID = new ObjectParameter("P_REQUEST_ID", typeof(decimal));
            _dbContext.Context.AddRefundRQST(RequestID, CustomerID, p_TRANSACTION_AMOUNT, p_PAYMENT_METHOD_ID, p_REMARKS, UserID, LocationID, RefundTypeID, paymentDOCRef, BankName, AccountHolderName, AccountNumber, IBANNumber, CountryId);
            return Convert.ToInt32(RequestID.Value);

        }

        public int UpdateRefundRQST(int p_RequestID, string p_REMARKS, int UserID, int LocationID, decimal TransactionAmount, int RefundTypeID, string paymentDOCRef, string BankName, string AccountHolderName, string AccountNumber, string IBANNumber, int? CountryId)
        {
            return _dbContext.Context.UPDATE_REFUND_RQST(p_RequestID, p_REMARKS, UserID, LocationID, TransactionAmount, RefundTypeID, paymentDOCRef, BankName, AccountHolderName, AccountNumber, IBANNumber, CountryId);
        }

        public int AddVoucherRQST(int CustomerID, DateTime p_VALIDITY_START_DATE, DateTime p_VALIDITY_END_DATE, int? p_VALIDITY_TYPE_ID, int? p_VOUCHER_TYPE_ID,
            decimal? p_AMOUNT, string p_REMARKS, decimal? p_IS_NOTIFIED, decimal? p_IS_LOYALTY_VOUCHER, decimal? p_IS_ACTIVE, int UserID, int LocationID,
            string p_ALLOWEDPRODUCTIDS, int p_QUANTITY)
        {
            var RequestID = new ObjectParameter("P_REQUEST_ID", typeof(decimal));
            _dbContext.Context.AddVoucherRQST(RequestID, CustomerID, p_VALIDITY_START_DATE, p_VALIDITY_END_DATE, p_VALIDITY_TYPE_ID, p_VOUCHER_TYPE_ID,
                p_AMOUNT, p_REMARKS, p_IS_NOTIFIED, p_IS_LOYALTY_VOUCHER, p_IS_ACTIVE, UserID, LocationID, p_ALLOWEDPRODUCTIDS, p_QUANTITY);
            return Convert.ToInt32(RequestID.Value);

        }
        //F733
        public int AddNewAccountRequest(CTRequestCustomer DTO)
        {
            var RequestCustomerId = new ObjectParameter("P_RequestCustomerId", DTO.RequestCustomerId);
            _dbContext.Context.AddNewAccountRequest(RequestCustomerId, DTO.RequestID, DTO.Name, DTO.CustomerTypeID, DTO.CompanyID, DTO.ClassificationId, DTO.AccountTypeID,
                DTO.NationalityID, DTO.NationalID, DTO.BasicAddressId, DTO.BillingAddressId, DTO.ShippingAddressId, DTO.FamilyID, DTO.FinancialAccountTypeID,
                DTO.FinancialAccountNo, DTO.AccountManagerID, DTO.BillingFrequencyID, DTO.NotificationThreshold, DTO.SuspensionThreshold, DTO.IsVIP, DTO.RequestSourceTypeID,
                DTO.CardCentreID, DTO.UnitID, DTO.BillingFrequencyDayOrder, DTO.PaymentTerms, DTO.IdentificationTypeID, DTO.IsActive, DTO.EnableDefaultBeneficiary,
                DTO.LastUserID, DTO.LastLocationID, DTO.MonthlyVolumeID, DTO.IsPremier, DTO.GENDER, DTO.DATEOFBIRTH, DTO.IsEmployer, DTO.CustBillFrequency, DTO.ContractNumber
                );

            return Convert.ToInt32(RequestCustomerId.Value);
        }
        //F734
        public int AddWorkOrderRequest(CTRequestWorkOrder entity)
        {
            var RequestWorkOrderID = new ObjectParameter("P_RequestWorkOrderID", entity.RequestWorkOrderID);
            _dbContext.Context.AddNewWorkOrderRequest(entity.RequestId, RequestWorkOrderID, entity.TokenName, entity.PreferredLocationId, entity.PreferredDateFrom, entity.PreferredDateTo,
                entity.ScheduledLocationID, entity.ScheduledDate, entity.AuthPersonIDType, entity.AuthPersonIDNumber, entity.IsActive, entity.LastUserID, entity.ReasonID);

            return Convert.ToInt32(RequestWorkOrderID.Value);
        }
        //F735
        public int CreatePersonalizationRequest(CTRequestPersonalization entity)
        {
            var RequestPersonalizationOrderID = new ObjectParameter("P_RQUST_PRSNLIZATION_ORDER_ID", entity.RequestPersonalizationOrderID);
            _dbContext.Context.CreatePersonalizationRequest(entity.RequestId, RequestPersonalizationOrderID, entity.TokenName, entity.PreferredLocationId,
                entity.PreferredDateFrom, entity.PreferredDateTo, entity.ScheduledLocationID, entity.ScheduledDate, entity.AuthPersonIDType, entity.AuthPersonIDNumber, entity.IsActive,
                entity.LastUserID, entity.ReasonID);
            return Convert.ToInt32(RequestPersonalizationOrderID.Value);
        }
        public int CreateRequest(CTRequest entity)
        {
            var RequestID = new ObjectParameter("P_REQUEST_ID", entity.REQUEST_ID);
            _dbContext.Context.CreateRequest(RequestID, entity.DATE_TIME, entity.REQUEST_TYPE_ID, entity.REQUEST_STATUS_ID, entity.REQUESTER_USER_ID, entity.CUSTOMER_ID,
                entity.BENEFICIARY_ID, entity.TOKEN_ID, entity.REMARKS, entity.IS_ACTIVE, entity.LAST_UPDATED_USER_ID, entity.LAST_LOCATION_ID);
            return Convert.ToInt32(RequestID.Value);
        }
        public int AddRequestAccountManager(CTRequestAccountManager entity)
        {
            var ACCOUNT_MANAGER_ID = new ObjectParameter("P_ACCOUNT_MANAGER_ID", entity.AccountManagerID);
            _dbContext.Context.AddRequestCustomerAccountManager(ACCOUNT_MANAGER_ID, entity.user_id, entity.Name, entity.Mobile, entity.Phone, entity.Email,
                entity.Fax, entity.isActive, entity.LastUserID, entity.LastUpdatedDate, entity.LastLocationID);
            return Convert.ToInt32(ACCOUNT_MANAGER_ID.Value);
        }
        public CTRequestAccountManager GetRequestAccountManager(int AccountManagerID)
        {
            var data = _dbContext.Context.GetRequestCustomerAccountManager(AccountManagerID).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }
        public string GetRequestCode(int requestID)
        {
            var p_CODE = new ObjectParameter("P_Code", typeof(string));
            _dbContext.Context.GetRequestCode(requestID, p_CODE);
            return Convert.ToString(p_CODE.Value);
        }
        public int AddRequestCustomerContact(RQST_REQUEST_CONTACT entity, int customer_id, int ContactType, int contactid)
        {
            var REQUEST_CONTACT_ID = new ObjectParameter("P_REQUEST_CONTACT_ID", entity.REQUEST_CONTACT_ID);
            _dbContext.Context.AddRequestCustomerContact(REQUEST_CONTACT_ID, entity.CODE, entity.PIN, entity.NAME, entity.MOBILE, entity.PHONE, entity.EMAIL, entity.FAX, entity.NOTIFICATION_LANGUAGE_ID,
                entity.NOTIFICATION_CHANNEL_ID, entity.IS_ACTIVE, 0, customer_id, contactid, ContactType, entity.LAST_LOCATION_ID);
            return Convert.ToInt32(REQUEST_CONTACT_ID.Value);
        }

        public List<CTProperty> GetAvailableCustomerContatcType(int customerId)
        {
            return _dbContext.Context.GetAvailableCustomErContatcType(customerId).ToList();
        }

        public int AddRequestCustomerContactHistory(RQST_REQUEST_CONTACT_HIST entity, int customer_id, int ContactType, int contactid)
        {
            var REQUEST_CONTACT_ID = new ObjectParameter("P_REQUEST_CONTACT_ID", entity.REQUEST_CONTACT_ID);
            _dbContext.Context.AddRequestCustomerContactHistory(REQUEST_CONTACT_ID, entity.CODE, entity.PIN, entity.NAME, entity.MOBILE, entity.PHONE, entity.EMAIL, entity.FAX, entity.NOTIFICATION_LANGUAGE_ID,
                entity.NOTIFICATION_CHANNEL_ID, entity.IS_ACTIVE, 0, customer_id, contactid, ContactType, entity.LAST_LOCATION_ID);
            return Convert.ToInt32(REQUEST_CONTACT_ID.Value);
        }

        public int AddRequestCustomerAddress(RQST_REQUEST_CUSTOMER_ADDRESS entity)
        {
            var ADDRESS_ID = new ObjectParameter("P_ADDRESS_ID", entity.REQUEST_ADDRESS_ID);
            _dbContext.Context.AddRequestCustomerAddress(ADDRESS_ID, entity.AREA_ID, entity.CITY_ID, entity.COUNTRY_ID, entity.POST_CODE, entity.DETAILED_ADDRESS,
                entity.IS_ACTIVE, entity.LAST_UPDATED_USER_ID, entity.LAST_LOCATION_ID, entity.PHONE_NUMBER, entity.FAX);
            return Convert.ToInt32(ADDRESS_ID.Value);
        }
        public int AddRequestCustomerAddressHistory(RQST_REQUEST_CUSTOMER_ADDRESS entity)
        {
            var ADDRESS_ID = new ObjectParameter("P_ADDRESS_ID", entity.REQUEST_ADDRESS_ID);
            _dbContext.Context.AddRequestCustomerAddressHistory(ADDRESS_ID, entity.AREA_ID, entity.CITY_ID, entity.COUNTRY_ID, entity.POST_CODE, entity.DETAILED_ADDRESS,
                entity.IS_ACTIVE, entity.LAST_UPDATED_USER_ID, entity.LAST_LOCATION_ID, entity.PHONE_NUMBER, entity.FAX);
            return Convert.ToInt32(ADDRESS_ID.Value);
        }
        public CTCustomerReceiptPreference GetRequestCustomerReceiptPreference(int customerID)
        {
            var data = _dbContext.Context.GetRequestCustomerReceiptPreference(customerID).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }
        public List<CTWorkFlowHistory> GetWorkFlowHistory(int RequestID)
        {
            return _dbContext.Context.GetWorkFlowHistory(RequestID).ToList();
        }
        public CTCustomerAttachment ViewCustomerAttachmentByID(int AttachmentID)
        {
            //var data = _dbContext.Context.CUSTOMER_ATTACHMENT.ToList().Find(i => i.ATTACHMENT_ID == AttachmentID);
            var data = _dbContext.Context.ViewCustomerAttachmentByID(AttachmentID).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }
        //F296
        public List<CTCustomerAttachment> GetAllCustomerAttachments(int CustomerID)
        {
            //List<CUSTOMER_ATTACHMENT> list = new List<CUSTOMER_ATTACHMENT>();
            //list = (_dbContext.Context.CUSTOMER_ATTACHMENT.ToList().FindAll(i => i.CUSTOMER.CUSTOMER_ID == CustomerID));
            var list = _dbContext.Context.GetAllCustomerAttachments(CustomerID).ToList();
            if (list != null & list.Count > 0)
                return list;
            return null;
        }
        //F737
        public List<CTProperty> GetAllMonthlyVolumes()
        {
            return _dbContext.Context.GetAllMonthlyVolumes().ToList();
        }
        public int GetpreviousWorkflowHistoryInstance(int InstanceID)
        {
            var _Result = new ObjectParameter("P_RESULT", typeof(decimal));
            _dbContext.Context.GetpreviousWorkflowHistoryInstance(InstanceID, _Result);
            return Convert.ToInt32(_Result.Value);
        }

        public int ValidateRequest(int requesttypeid, int? requestId, int? customerId, int? beneficiaryId, int? tokenId, Int32? workflowinstanceid)
        {
            var result = new ObjectParameter("P_RESULT", typeof(decimal));
            _dbContext.Context.ValidateRequest(requesttypeid, requestId, customerId, beneficiaryId, tokenId, workflowinstanceid, result);
            return Convert.ToInt32(result.Value);
        }

        public int ValidateAccountCreationRequest(int requesttypeid, int? requestId, string pNationalId, string pFinancialAccountNo)
        {
            var result = new ObjectParameter("P_RESULT", typeof(decimal));
            _dbContext.Context.requestAccountCreationValidation(requesttypeid, requestId, pNationalId, pFinancialAccountNo, result);
            return Convert.ToInt32(result.Value);
        }

        public bool RevertWorkFlowStep(int wfInstanceId)
        {
            var result = new ObjectParameter("P_RESULT", typeof(decimal));
            _dbContext.Context.RevertWorkFlowStep(wfInstanceId, result);
            return Convert.ToBoolean(result.Value);
        }

        public bool CancelWorkOrder(int WorkOrderID, int LastLocationId, int LastUserID)
        {
            var result = new ObjectParameter("P_RESULT", typeof(decimal));
            _dbContext.Context.CancelWorkOrder(WorkOrderID, LastLocationId, LastUserID, result);
            return Convert.ToBoolean(result.Value);
        }

        public bool CancelPersonalizationOrder(int PersonalizaionOrderID, int LastLocationId, int LastUserID)
        {
            var result = new ObjectParameter("P_RESULT", typeof(decimal));
            _dbContext.Context.CancelPersonalizationOrder(PersonalizaionOrderID, LastLocationId, LastUserID, result);
            return Convert.ToBoolean(result.Value);
        }

        public CTOrderCancellation GetDetailsForPersonalizationCancellation(int PersonalizationID, int pTokenId)
        {
            var List = _dbContext.Context.GetDetailsForPersonalizationCancellation(PersonalizationID, pTokenId).ToList();
            if (List != null & List.Count > 0)
                return List[0];
            return null;
        }
        public CTOrderCancellation GetDetailsForWorkOrderCancellation(int WorkOrderID, int pTokenId)
        {
            var List = _dbContext.Context.GetDetailsForWorkOrderCancellation(WorkOrderID, pTokenId).ToList();
            if (List != null & List.Count > 0)
                return List[0];
            return null;
        }

        public bool IsRequestIDValidforAssignedUser(string RequestsIDs, int AssignedUserid, int Mode, out string InvalidIDsList)
        {
            var result = new ObjectParameter("P_RESULT", typeof(decimal));
            var InvalidIDs = new ObjectParameter("InvalidIDs", typeof(string));
            _dbContext.Context.IsRequestIDValidforAssignedUser(RequestsIDs, AssignedUserid, Mode, result, InvalidIDs);
            InvalidIDsList = Convert.ToString(InvalidIDs.Value);
            return Convert.ToBoolean(result.Value);
        }

        public bool IsRequestPendingForCustomerOrToken(int customerId, int? TokenId)
        {
            var result = new ObjectParameter("P_RESULT", typeof(decimal));
            _dbContext.Context.IsRequestPendingForCustomerOrToken(customerId, TokenId, result);
            return Convert.ToBoolean(result.Value);
        }

        public bool TerminatePendingRequests(int customerId, int? TokenId)
        {
            var result = new ObjectParameter("P_RESULT", typeof(decimal));
            _dbContext.Context.TerminatePendingRequests(customerId, TokenId, result);
            return Convert.ToBoolean(result.Value);
        }

        public bool RestrictionGroupTransaction(Nullable<decimal> MaximumTransactionAmount,
            int? IsActive, Nullable<decimal> LastUpdatedUserId,
            Nullable<System.DateTime> LastUpdatedDate, Nullable<decimal> LastLocationID,
            int? IsDry, Nullable<decimal> ProductCategoryID)
        {
            var p_RESTRICTION_GROUP_ID = new ObjectParameter("p_RESTRICTION_GROUP_ID", typeof(decimal));
            _dbContext.Context.RestrictionGroupTransaction(p_RESTRICTION_GROUP_ID, MaximumTransactionAmount, IsActive,
                LastUpdatedUserId, LastUpdatedDate, LastLocationID, IsDry, ProductCategoryID);
            return Convert.ToBoolean(p_RESTRICTION_GROUP_ID.Value);
        }

        public bool RestrictionGroupStation(int? RSGRPID, int? StationID,
             int? IsActive, int? LastUpdatedUserId,
            Nullable<System.DateTime> LastUpdatedDate, int? LastLocationID,
             int? IsDry)
        {
            var p_RS_GRP_ID = new ObjectParameter("p_RS_GRP_ID", typeof(decimal));
            p_RS_GRP_ID.Value = RSGRPID;
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.RestrictionGroupStation(p_RS_GRP_ID, StationID, IsActive,
                LastUpdatedUserId, LastUpdatedDate, LastLocationID, IsDry, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        public bool RestrictionGroupAmount(int? RestrictionGroupID, int? TimeFrequencyID,
            Nullable<decimal> AllowedAmount, int? IsActive, int? LastUpdatedUserId,
            Nullable<System.DateTime> LastUpdatedDate, int? LastLocationID,
             int? IsDry, int? ProductCategoryID)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.RestrictionGroupAmount(RestrictionGroupID, TimeFrequencyID, AllowedAmount, IsActive,
                LastUpdatedUserId, LastUpdatedDate, LastLocationID, IsDry, ProductCategoryID, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        public bool RestrictionGroupTransactionNo(int? RestrictionGroupID, int? NumberOfDays,
            int? NumberOfTransactions, int? TimeFrequencyID, int? IsActive,
            int? LastUpdatedUserId, Nullable<System.DateTime> LastUpdatedDate,
            int? LastLocationID, int? IsDry,
            int? ProductCategoryID)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.RestrictionGroupTransactionNo(RestrictionGroupID, NumberOfDays, NumberOfTransactions, TimeFrequencyID,
                IsActive, LastUpdatedUserId, LastUpdatedDate, LastLocationID, IsDry, ProductCategoryID, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        public List<CTProduct> GetAllTransactionProducts()
        {
            return _dbContext.Context.GetAllTransactionProducts().ToList();
        }
        public List<CTProductCategory> GetAllProductCategories()
        {
            return _dbContext.Context.GetAllProductCategories().ToList();
        }
        public List<CTProductCategoryDTO> ProductCategorySA()
        {
            return _dbContext.Context.ProductCategorySA().ToList();
        }

        public bool Reverse_Transaction(bool isPayment, int transactionDetailID, DateTime reverseDate, int currentUserid, int locationID, int isAuthRefund = 0)
        {
            var isReversed = new ObjectParameter("P_RESULT", typeof(decimal));
            var result = _dbContext.Context.Reverse_Transaction(isPayment ? 1 : 0, transactionDetailID, currentUserid, locationID, isReversed, isAuthRefund);
            return isReversed.Value.ToString().Equals("1");
        }

        public List<CTTransactionReversal> ViewReversedTransaction(bool isPayment, int transactionDetailID)
        {
            return _dbContext.Context.ViewReversedTransaction(isPayment ? 1 : 0, transactionDetailID).ToList();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool IsTransactionReversalGranted(int userID)
        {
            //To Do
            //var _hasAccess = new ObjectParameter("p_HAS_TRANSACTION_REVERSAL", typeof(decimal));
            //_dbContext.Context.IsTransactionReversalAllowed(userID, _hasAccess);
            return Convert.ToBoolean(true);
        }

        /// <summary>
        /// Search all the transaction record which is valid for reversal
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<CTTransactionReversal> SearchTransactionForReversal(CTTransactionReversalSearch entity, int pageNo, int pageSize, out int rowCount)
        {
            var p_Row_Count = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var results = _dbContext.Context.SearchTransactionForReversal(entity.FROM_DATE, entity.TO_DATE, entity.TRANSACTION_TYPE_ID, entity.VAT_INV_NUM, entity.CUSTOMER_CODE,
                entity.CUSTOMER_NAME, entity.BENEFICIARY_CODE, entity.BENEFICIARY_NAME, entity.TOKEN_TYPE_ID, entity.TOKEN_SERIAL,
                entity.STATION_ID, entity.PRODUCT_ID, entity.RECEIPT_ID, entity.AUTHORIZATION_CODE, entity.IsPremiumService, pageNo, pageSize, p_Row_Count).ToList();
            rowCount = Convert.ToInt32(p_Row_Count.Value);
            return results;
        }


        public List<CTRefundTypes> GetAllRefundTypes()
        {
            return _dbContext.Context.GetAllRefundTypes().ToList();
        }

        public CUSTOMER_PAYMENT GetTopUpDetailsByDocRef(string paymentDocRef, int? CustomerId)
        {
            return _dbContext.Context.GetTopUpDetailsByDocRef(paymentDocRef, CustomerId).FirstOrDefault();
        }

        #endregion

        #region Reports
        public List<CTProperty> GeAllPersonalizationOrderType()
        {
            return _dbContext.Context.GeAllPersonalizationOrderType().ToList();
        }

        public List<CTProperty> GeAllPersonaliztionOrderStatus()
        {
            return _dbContext.Context.GeAllPersonaliztionOrderStatus().ToList();
        }

        public List<CTProperty> GeAllDepots()
        {
            return _dbContext.Context.GeAllDepots().ToList();
        }

        public List<CTProperty> GeAllWorkOrderTypes()
        {
            return _dbContext.Context.GeAllWorkOrderTypes().ToList();
        }

        public List<CTProperty> GetAllInvoiceStatus()
        {
            return _dbContext.Context.GetAllInvoiceStatus().ToList();
        }

        public List<CTProperty> GetAllRefundMethods()
        {
            return _dbContext.Context.GetAllRefundMethods().ToList();
        }

        public List<CTProperty> GetAllEPICallTypes()
        {
            return _dbContext.Context.GetAllEPICallTypes().ToList();
        }

        public List<CTProperty> GetAllTransactionTypes()
        {
            return _dbContext.Context.GetAllTransactionTypes().ToList();
        }
        public List<CTProperty> GetAllBeneficiaryGroups()
        {
            return _dbContext.Context.GetAllBeneficiaryGroups().ToList();
        }

        public CTBillToDetails GetBillToDetails(string arcustomerno)
        {
            var data = _dbContext.Context.GetBillToDetails(arcustomerno).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }
        #endregion

        public void GetCustomerAvailableCreditLimit(int customerId, out decimal availCreditLimit)
        {
            availCreditLimit = 0;
            var p_availCreditLimit = new ObjectParameter("P_BALANCE_CREDIT_LIMIT", typeof(decimal));
            var data = _dbContext.Context.GetCustomerAvailableCreditLimit(customerId, p_availCreditLimit);
            if (p_availCreditLimit.Value != DBNull.Value)
                availCreditLimit = Convert.ToDecimal(p_availCreditLimit.Value);
        }
        public bool IsCustomerPendingRefundRequestExists(int customerId)
        {
            var p_RESULT = new ObjectParameter("P_RESULT", typeof(decimal));
            _dbContext.Context.IsCustomerPendingRefundRequestExists(customerId, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }
        public List<CTSearchVoucherTRX> SearchVoucherTransaction(int? StationID, int? ReceiptNo, DateTime? fromDate, DateTime? toDate, string VoucherSerialNo, string CustomerNo,
           int? VoucherID, string TransReferenceNo, string FinancialAccountName, string SiteName, int pageNo, int pageSize, out int rowCount)
        {
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.SearchVoucherTransaction(StationID, ReceiptNo, fromDate, toDate, VoucherSerialNo, CustomerNo, VoucherID, TransReferenceNo,
                FinancialAccountName, SiteName, pageNo, pageSize, p_ROW_COUNT).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }

        public bool TransactionEXTVoucherMAPIU(string VoucherNo, string VoucherSerialNo, string VatInvoiceNo, int LastUpdatedUserID, int LastLocationID)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.TransactionEXTVoucherMAPIU(VoucherNo, VoucherSerialNo, VatInvoiceNo, LastUpdatedUserID, LastLocationID, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        public List<CTTransactionEXTVoucherMapSA> ExternalVoucherTRX_AUDIT(DateTime? fromDate, DateTime? toDate, int? LastUpdatedUserID, int? LastLocationID, string OperationName,
            int pageNo, int pageSize, out int rowCount)
        {
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.ExternalVoucherTRX_AUDIT(fromDate, toDate, LastUpdatedUserID, LastLocationID, OperationName, pageNo, pageSize, p_ROW_COUNT).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }

        public List<CTProductServiceBilling> GetProductServiceBillingType()
        {
            return _dbContext.Context.GetProductServiceBillingType().ToList();
        }
        public List<CTProductServiceBillingFreq> GetProductServiceBillingFrequency(int? CustomerId)
        {
            return _dbContext.Context.GetProductServiceBillingFrequency(CustomerId).ToList();
        }
        public int UpdateProductServiceBillingFrequency(int? Id, int? CustomerId, int BillingTypeId, int BillingFrequencyId,int? LastLocationId, int? lastUpdateduser)
        {
            var p_Id = (Id==null? new ObjectParameter("P_ID",typeof(decimal)): new ObjectParameter("P_ID", Id)); 
            return _dbContext.Context.UpdateProductServiceBillingFrequency(p_Id,CustomerId,BillingTypeId,BillingFrequencyId,LastLocationId,lastUpdateduser);
        }

    }
}