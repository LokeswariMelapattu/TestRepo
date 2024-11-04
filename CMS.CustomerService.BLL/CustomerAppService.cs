using DUC.CMS.CustomerService.BLL.DTO;
using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.BLL.Mappers;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.CustomerService.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace DUC.CMS.CustomerService.BLL
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerAppService
    {
        /// <summary>
        /// F86 - Gets the customer information.
        /// </summary>
        /// <param name="financialAccountNumber">The financial account number.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public CustomerARDTO GetCustomerInformation(string financialAccountNumber)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetCustomerInfomation(financialAccountNumber).ToDTO();
            }
        }

        /// <summary>
        /// F87 - Updates the customer information.
        /// </summary>
        /// <param name="customerDto">The customer dto.</param>
        /// <returns></returns>
        public int UpdateCustomerInfo(CustomerDTO customerDto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                var entity = customerDto.ToCTEntity();

                if (entity.ADDRESS != null)
                {
                    if (entity.BASIC_ADDRESS_ID != null) entity.ADDRESS.ADDRESS_ID = (int)entity.BASIC_ADDRESS_ID;
                    entity.BASIC_ADDRESS_ID = repository.SaveAddress(entity.ADDRESS);
                }

                if (entity.ADDRESS1 != null)
                {
                    if (entity.BILLING_ADDRESS_ID != null) entity.ADDRESS1.ADDRESS_ID = (int)entity.BILLING_ADDRESS_ID;
                    entity.BILLING_ADDRESS_ID = repository.SaveAddress(entity.ADDRESS1);
                }

                if (entity.ADDRESS2 != null)
                {
                    if (entity.SHIPPING_ADDRESS_ID != null) entity.ADDRESS2.ADDRESS_ID = (int)entity.SHIPPING_ADDRESS_ID;
                    entity.SHIPPING_ADDRESS_ID = repository.SaveAddress(entity.ADDRESS2);
                }

                if (entity.ACCOUNT_MANAGER != null)
                {
                    entity.ACCOUNT_MANAGER_ID = repository.SaveAccountManager(entity.ACCOUNT_MANAGER);
                }

                entity.PIN = "1234";
                var customerId = repository.SaveCustomerInfo(entity);
                if (customerDto.CustomerReceiptPreference != null)
                {
                    if (customerDto.CustomerReceiptPreference.ReceiptTypeId == 3)//None
                    {
                        repository.DeleteCustomerReceiptPreference(customerId, customerDto.LastUpdatedUserId, DateTime.Now, customerDto.LastUpdatedLocationID);
                    }
                    else
                    {
                        customerDto.CustomerReceiptPreference.CustomerId = customerId;

                        BaseDTO Audit = new BaseDTO { LastUpdatedDate = DateTime.Now, LastUpdatedUserId = customerDto.LastUpdatedUserId, LastUpdatedLocationID = customerDto.LastUpdatedLocationID };
                        repository.UpdateCustomerReceiptPreference(customerDto.CustomerReceiptPreference.ToEntity(), Audit.ToEntity());
                    }
                }

                if (entity.CUSTOMER_CONTACT != null)
                {
                    foreach (var contact in entity.CUSTOMER_CONTACT)
                    {
                        var contactToAdd = new CUSTOMER_CONTACT
                        {
                            //CONTACT_ID = contact.CONTACT_ID,
                            CUSTOMER_ID = customerId,
                            CONTACT_TYPE_ID = contact.CONTACT_TYPE_ID,
                            LAST_LOCATION_ID = customerDto.LastUpdatedLocationID,
                            LAST_UPDATED_USER_ID = customerDto.LastUpdatedUserId,
                            LAST_UPDATED_DATE = DateTime.Now
                        };
                        if ((contact.CONTACT_TYPE_ID == 0 || contact.CONTACT_TYPE_ID == 2) && customerDto.OperationalContactID != null)
                        {
                            contact.CONTACT.CONTACT_ID = (int)customerDto.OperationalContactID;
                        }
                        else if (contact.CONTACT_TYPE_ID == 1 && customerDto.FinancialContactID != null)
                        {
                            contact.CONTACT.CONTACT_ID = (int)customerDto.FinancialContactID;
                        }

                        contactToAdd.CONTACT_ID = repository.SaveContact(contact.CONTACT, null, null);
                        repository.SaveCustomerContact(contactToAdd);
                    }
                }
                return customerId;
            }
        }

        /// <summary>
        /// F004 - Gets the identitification types.
        /// </summary>
        /// <returns></returns>
        public List<IdentificationTypeDTO> GetIdentitificationTypes()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new Repository<IDENTIFICATION_TYPE>(unitOfWork);
                var data = repository.ExecuteStoredProcedure("GetIdentitificationTypes");
                return data.ToDTOs();
            }
        }

        /// <summary>
        /// F31 - Gets all customer status.
        /// </summary>
        /// <returns></returns>
        public List<CustomerStatusDTO> GetAllCustomerStatus()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new Repository<CUSTOMER_STATUS>(unitOfWork);
                var data = repository.ExecuteStoredProcedure("GetAllCustomerStatus");
                return data.ToDTOs();
            }
        }

        /// <summary>
        /// F88 - Gets the customer classification.
        /// </summary>
        /// <returns></returns>
        public List<CustomerClassificationDTO> GetCustomerClassification()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new Repository<CUSTOMER_CLASSIFICATION>(unitOfWork);
                var data = repository.ExecuteStoredProcedure("GetCustomerClassification");
                return data.ToDTOs();
            }
        }


        //public List<ProductDTO> GetAllProduct()
        //{
        //    using (var unitOfWork = new UnitOfWork())
        //    {
        //        var repository = new Repository<PRODUCT>(unitOfWork);
        //        var data = repository.ExecuteStoredProcedure("GetAllProduct");
        //        return data.ToDTOs();
        //    }
        //}

        /// <summary>
        /// F89 - Gets all product.
        /// </summary>
        /// <returns></returns>
        public List<ProductDTO> GetAllProduct(int? productCategoryID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetAllProduct(productCategoryID).ToDTOs();
            }
        }

        /// <summary>
        /// F90 - Updates the uplift discount product.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        public bool UpdateUpliftDiscountProduct(int customerID, int UpliftID, BaseDTO Audit)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.UpdateUpliftDiscountProduct(customerID, UpliftID, Audit.ToEntity());
            }
        }

        public bool UpdatePushNotification(int BenificaryId, int isPushEnabled, int UserID, int LocationId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.UpdatePushNotification(BenificaryId, isPushEnabled, UserID, LocationId);
            }
        }


        public int GetPushNotification(int BenificaryId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetPushNotification(BenificaryId);
            }
        }


        /// <summary>
        /// F91 - Gets all uplift discount products.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        public List<UpliftDiscountDTO> GetAllUpliftDiscountProducts(int customerId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetAllUpliftDiscountProducts(customerId).ToDTOs();
            }
        }

        /// <summary>
        /// F92 - Gets all customer groups.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        public List<CustomerGroupDTO> GetAllCustomerGroups(int customerId, string groupName)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetAllCustomerGroups(customerId, groupName).ToDTOs();
            }
        }

        /// <summary>
        /// Gets all customer groups.
        /// </summary>
        /// <returns></returns>
        public List<CustomerGroupDTO> GetAllCustomerGroups()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new Repository<BENEFICIARY_GROUP>(unitOfWork);
                var data = repository.ExecuteStoredProcedure("GetAllCustomerGroups");
                return data.ToCGDTOs();
            }
        }

        /// <summary>
        /// F93 - Updates the customer group.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        public bool UpdateCustomerGroup(CustomerGroupDTO dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.UpdateCustomerGroup(dto.ToBGEntity());
            }
        }

        /// <summary>
        /// F94 - Determines whether [is customer group in use] [the specified customer identifier].
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="customerGroupId">The customer group identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool IsCustomerGroupInUse(int customerId, int customerGroupId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.CheckCustomerGroupInUse(customerId, customerGroupId);
            }
        }

        /// <summary>
        /// F95 - Deletes the customer group.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        public bool DeleteCustomerGroup(CustomerGroupDTO dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.DeleteCustomerGroup(dto.ToBGEntity());
            }
        }

        /// <summary>
        /// F002 - Gets all the Areas from the lookup.
        /// </summary>
        /// <returns></returns>
        public List<AreaDTO> GetAllAreas()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new Repository<AREA>(unitOfWork);
                var data = repository.ExecuteStoredProcedure("GetAllAreas");
                return data.ToDTOs();
            }
        }

        public List<AreaDTO> GetAllAreas(int emirateID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetAllAreas(emirateID).ToDTOs();
            }
        }

        /// <summary>
        /// F001 - Gets all emirates.
        /// </summary>
        /// <returns></returns>
        public List<CityDTO> GetAllEmirates()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new Repository<CITY>(unitOfWork);
                var data = repository.ExecuteStoredProcedure("GetAllEmirates");
                return data.ToDTOs();
            }
        }

        public List<PropertyDTO> GetAllEmirates(int countryID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetAllEmiratesByCountryID(countryID).ToDTOs();
            }
        }

        /// <summary>
        /// F003 - Gets all nationality.
        /// </summary>
        /// <returns></returns>
        public List<NationalityDTO> GetAllNationality()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new Repository<NATIONALITY>(unitOfWork);
                var data = repository.ExecuteStoredProcedure("GetAllNationality");
                return data.ToDTOs();
            }
        }

        /// <summary>
        /// F96 - Gets all customer information.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        public List<CustomerSearchDTO> SearchCustomerInfo(CustomerSearchDTO dto, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.SearchCustomerInfo(dto.ToEntity(), pageNo, pageSize, out rowCount).ToDTOs();
            }
        }
        public List<CustomerSearchDTO> SearchCustomerForClosure(CustomerSearchDTO dto, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.SearchCustomerForClosure(dto.ToEntity(), pageNo, pageSize, out rowCount).ToDTOs();
            }
        }

        public List<CustomerSearchDTO> SearchCustomerforPayment(CustomerSearchDTO dto, int pageNo, int pageSize, int IsRefund, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.SearchCustomerforPayment(dto.ToEntity(), pageNo, pageSize, IsRefund, out rowCount).ToDTOs();
            }
        }

        public DebitCreditRequestDTO ViewCreditDebitRequest(int P_REQUESTID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.ViewCreditDebitRequest(P_REQUESTID).MapToDto();
            }
        }

        public RefundRequestDTO ViewRefundRequest(int P_REQUESTID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.ViewRefundRequest(P_REQUESTID).MapToDto();
            }
        }

        public VoucherRequestDTO ViewVoucherRequest(int P_REQUESTID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.ViewVoucherRequest(P_REQUESTID).MapToDto();
            }
        }

        /// <summary>
        /// F97 - Gets all account types.
        /// </summary>
        /// <returns></returns>
        public List<CustomerAccountTypeDTO> GetAllAccountTypes()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new Repository<CUSTOMER_ACCOUNT_TYPE>(unitOfWork);
                var data = repository.ExecuteStoredProcedure("GetAllAccountTypes");
                return data.ToDTOs();
            }
        }

        /// <summary>
        /// F197 - Gets all account types.
        /// </summary>
        /// <returns></returns>
        public List<CustomerAccountTypeDTO> GetAllCustomerAccountTypes()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new Repository<CTCustomerAccounTypes>(unitOfWork);
                var data = repository.ExecuteStoredProcedure("GetAllCustomerAccountTypes");
                return data.ToDTOs();
            }
        }

        /// <summary>
        /// F98 - Searches the beneficiaries.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        public List<BeneficiarySearchDTO> SearchBeneficiaries(BeneficiarySearchDTO dto, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.SearchBeneficiaries(dto.ToCTEntity(), pageNo, pageSize, out rowCount).ToDTOs();
            }
        }

        /// <summary>
        /// F99 - Updates the beneficiary group information.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        public bool UpdateBeneficiaryGroupInfo(List<CustomerBeneficiaryGroupDTO> dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                foreach (var item in dto)
                {
                    repository.UpdateBeneficiaryGroupInfo(item.CustomerID, item.BeneficiaryID, item.GroupID, item.LastUpdatedUserId, item.LastUpdatedDate, item.LastUpdatedLocationID);
                }
                return true;
            }
        }

        /// <summary>
        /// F32 - Gets all customer status reasons.
        /// </summary>
        /// <returns></returns>
        public List<StatusReasonDTO> GetAllCustomerStatusReasons(int statusID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetAllCustomerStatusReasons(statusID).ToDTOs();
            }
        }

        /// <summary>
        /// F100 - Gets the customer status history.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        public List<CustomerStatusHistoryDTO> GetCustomerStatusHistory(int customerId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetCustomerStatusHistory(customerId).ToDTOs();
            }
        }

        /// <summary>
        /// F101 - Updates the customer status.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool UpdateCustomerStatus(CustomerStatusDTO dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                repository.UpdateCustomerStatus(dto.CustomerId, dto.CustomerCode, dto.CustomerStatusId, dto.CustomerStatusReasonId, dto.FromDate, dto.ToDate, dto.UserId, dto.LastUpdatedDate, dto.LastUpdatedLocationID);
                return true;
            }
        }

        /// <summary>
        /// F103 - Submits the SMS request.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        public bool SubmitSMSRequest(SMSMessageDTO dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.SubmitSMSRequest(dto.ToEntity(), dto.LanguageId);
            }
        }

        //F158
        public List<CustomerGroupDTO> GetCustomerGroupById(int groupID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetCustomerGroupById(groupID).ToCGDTOs();
            }
        }

        //F157 -- discarded
        //public List<UpliftDiscountDTO> GetUpliftDiscountProductById(int customerID, int productID)
        //{
        //    using (var unitOfWork = new UnitOfWork())
        //    {
        //        var repository = new CustomerRepository(unitOfWork);
        //        return repository.GetUpliftDiscountProductById(customerID).ToDTOs();
        //    }
        //}

        //F170
        public bool DeleteUpliftDiscountProduct(int customerID, int UpliftID, BaseDTO Audit)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.DeleteUpliftDiscountProduct(customerID, UpliftID, Audit.ToEntity());
            }
        }

        //F175
        public CustomerDTO GetCustomerInfo(int customerID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                var data = repository.GetCustomerInfo(customerID).ToDTO();
                if (data != null && data.FinancialAccountTypeID != null)
                {
                    var fAccType = repository.GetFinancialAccountType((int)data.FinancialAccountTypeID);
                    if (fAccType != null)
                        data.FinancialAccountType = fAccType.EN_NAME;
                }
                return data;
            }
        }

        //F184
        public IdentityCardDTO GetIdentityCardInfo(int employeeNumber, int CustomerID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetIdentityCardInfo(employeeNumber, CustomerID).ToDTO();
            }
        }

        /// <summary>
        /// F102 - Updates the customer pin.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="PinNumber">The pin no.</param>
        /// <returns></returns>
        public bool UpdateCustomerPIN(int customerId, int contactTypeId, string PinNumber, BaseDTO Audit)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.UpdateCustomerPIN(customerId, contactTypeId, PinNumber, Audit.ToEntity());
            }
        }

        /// <summary>
        /// F124 - Searches the customer beneficiary.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        public List<CustomerBeneficiarySearchDTO> SearchCustomerBeneficiary(CustomerBeneficiarySearchDTO dto, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.SearchCustomerBeneficiary(dto.ToCBEntity(), pageNo, pageSize, out rowCount).ToCBDTOs();
            }
        }

        /// <summary>
        /// F128 - Gets all payment methods.
        /// </summary>
        /// <returns></returns>
        public List<PaymentMethodDTO> GetAllPaymentMethods()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new Repository<PAYMENT_METHOD>(unitOfWork);
                var data = repository.ExecuteStoredProcedure("GetAllPaymentMethods");
                return data.ToDTOs();
            }
        }

        /// <summary>
        /// F130 - Gets the payment history.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        public List<CustomerPaymentDTO> GetPaymentHistory(int customerId, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetPaymentHistory(customerId, pageNo, pageSize, out rowCount).ToDTOs();
            }
        }

        public CustomerPaymentDTO GetCustomerPaymentByPaymentID(int PaymentID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetCustomerPaymentByPaymentID(PaymentID).ToDTO();
            }
        }
        /// <summary>
        /// F129 - Add the payment.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        public bool AddPayment(CustomerPaymentTransactionDTO dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                BaseDTO Audit = new BaseDTO { LastUpdatedDate = dto.LastUpdatedDate, LastUpdatedUserId = dto.LastUpdatedUserId, LastUpdatedLocationID = dto.LastUpdatedLocationID };
                var repository = new CustomerRepository(unitOfWork);
                return repository.AddPayment(dto.ToEntity(), Audit.ToEntity());
            }
        }

        /// <summary>
        /// F131 - Gets the customer balance.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        public CustomerBalanceDTO GetCustomerBalance(int customerId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                decimal _usableBalance, _totalBalance, _accumulativeBlockedAmount;
                var repository = new CustomerRepository(unitOfWork);
                repository.GetCustomerBalance(customerId, out _usableBalance, out _totalBalance, out _accumulativeBlockedAmount);
                return new CustomerBalanceDTO { CustomerID = customerId, TotalBalance = _totalBalance, UsableBalance = _usableBalance, AccumulativeBlockedAmount = _accumulativeBlockedAmount };
            }
        }

        /// <summary>
        /// F132 - Gets the minimum cutomer transaction date.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        public DateTime? GetMinCutomerTransactionDate(int customerId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetMinCutomerTransactionDate(customerId);
            }
        }

        /// <summary>
        /// F133 - Gets the account balance.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        public List<AccountBalanceDTO> GetAccountBalance(int customerId, DateTime? fromDate, DateTime? toDate, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetAccountBalance(customerId, fromDate == DateTime.MinValue ? null : fromDate, toDate == DateTime.MinValue ? null : toDate, pageNo, pageSize, out rowCount).ToDTOs();
            }
        }

        /// <summary>
        /// F134 - Gets the customer transactions.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        public List<TransactionSearchDTO> GetCustomerTransactions(TransactionSearchDTO dto, int pageNo, int pageSize, out int rowCount, out decimal PaidAmountSum,
            out decimal AdjustmentAmountSum, out decimal TotalAmountSum, out decimal PaidVATSum)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                var transactions = repository.GetCustomerTransactions(dto.ToEntity(), pageNo, pageSize, out rowCount, out PaidAmountSum, out AdjustmentAmountSum, out TotalAmountSum, out PaidVATSum).ToDTOs();
                if (transactions != null)
                    foreach (var trans in transactions)
                    {
                        if (string.Equals(trans.ServiceOrProductName, "PRODUCT LIST", StringComparison.InvariantCultureIgnoreCase))
                        {
                            trans.ProductDtos = repository.GetProductListByTransId(trans.TransactionId).ToDTOs();
                            foreach (var prod in trans.ProductDtos)
                            {
                                prod.VatInvoiceNumber = trans.VAT_INV_NUM;
                                prod.IsPrintable = true; // as it is not used
                            }
                        }
                    }
                return transactions;
            }
        }

        public List<TransactionSearchInvDTO> TransactionSearchInv(TransactionSearchInvDTO dto, int pageNo, int pageSize, out int rowCount,
            out decimal PaidAmountSum, out decimal AdjustmentAmountSum, out decimal TotalAmountSum, out decimal TotalVAT)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                var transactions = repository.TransactionSearchInv(dto.ToEntity(), pageNo, pageSize, out rowCount, out PaidAmountSum, out AdjustmentAmountSum,
                    out TotalAmountSum, out TotalVAT).ToDTOs();

                //if (transactions != null)
                //    foreach (var trans in transactions)
                //    {
                //        if (string.Equals(trans.ServiceOrProductName, "PRODUCT LIST", StringComparison.InvariantCultureIgnoreCase))
                //        {
                //            trans.ProductDtos = repository.GetProductListByTransId(trans.Transaction_Id).ToDTOs();
                //            foreach (var prod in trans.ProductDtos)
                //            {
                //                prod.VatInvoiceNumber = trans.VAT_INV_NUM;
                //                prod.IsPrintable = true;
                //            }
                //        }
                //    }
                return transactions;
            }
        }

        /// <summary>
        /// F137 - Gets the customer billing information.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="invoiceNumber">The invoice number.</param>
        /// <returns></returns>
        public CustomerBillingDTO GetCustomerBillingInfo(int customerId, string invoiceNumber)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetCustomerBillingInfo(customerId, invoiceNumber).ToDTO();
            }
        }

        /// <summary>
        /// F138 - Gets the customer un billed information.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        public List<CustomerUnBilledDTO> GetCustomerUnBilledInfo(int customerId, string VATInvoiceNum, int pageNo, int pageSize, out int rowCount,
            out decimal PaidAmountSum, out decimal AdjustmentAmountSum, out decimal TotalAmountSum, out decimal TotalVatAmount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                var transactions = repository.GetCustomerUnBilledInfo(customerId, VATInvoiceNum, pageNo, pageSize, out rowCount, out PaidAmountSum
                    , out AdjustmentAmountSum, out TotalAmountSum, out TotalVatAmount).ToDTOs();
                return transactions;
            }
        }

        /// <summary>
        /// F139 - Gets the hr employee data.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException">asd</exception>
        public EmployeeHRDTO GetHREmployeeData(int employeeNumber)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetHREmployeeData(employeeNumber).ToDTO();
            }
        }

        /// <summary>
        /// F140 - Determines whether [is employee card already issued] [the specified employee identifier].
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        public int IsEmployeeCardAlreadyIssued(int employeeID, int customer_id, out string cardSerialNo)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.IsEmployeeCardAlreadyIssued(employeeID, customer_id, out cardSerialNo);
            }
        }

        /// <summary>
        /// F141 - Updates the identity card information.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public int UpdateIdentityCardInfo(EmployeeIdentityCardDTO dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.UpdateIdentityCardInfo(dto.ToEntity());
            }
        }

        /// <summary>
        /// F147 - Gets the customer billing dates.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        public List<CustomerBillingDateDTO> GetCustomerBillingDates(int customerId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetCustomerBillingDates(customerId).ToDTOs();
            }
        }

        /// <summary>
        /// F148 - Gets the customer billing period.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        public List<CustomerBillingPeriodDTO> GetCustomerBillingPeriod(int customerId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetCustomerBillingPeriod(customerId).ToDTOs();
            }
        }

        /// <summary>
        /// F149 - Searches the customer billing.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        public List<CustomerBillingSearchDTO> SearchCustomerBilling(CustomerBillingSearchDTO dto, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.SearchCustomerBilling(dto.ToEntity(), pageNo, pageSize, out rowCount).ToDTOs();
            }
        }

        //F189
        public List<CustomerStatusDTO> GetAllCustomerStatusByID(int customerId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                var data = repository.GetAllCustomerStatusByID(customerId);
                return data.ToDTOs();
            }
        }

        //F194
        public CustomerTransactionDTO GetTransactionSummary(int customerID, int? beneficiaryID, DateTime? fromDate, DateTime? toDate)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                decimal? TRANSACTION_AMOUNT;
                decimal? ADJUSTMENT;
                decimal? TOTAL_AMOUNT;
                var repository = new CustomerRepository(unitOfWork);
                repository.GetTransactionSummary(customerID, beneficiaryID, fromDate, toDate, out TRANSACTION_AMOUNT, out ADJUSTMENT, out TOTAL_AMOUNT);
                return new CustomerTransactionDTO { TransactionAmount = TRANSACTION_AMOUNT, Adjustment = ADJUSTMENT, TotalAmount = TOTAL_AMOUNT };
            }
        }

        public CustomerTransactionDTO GetTransactionSummaryInv(int customerID, int? beneficiaryID, DateTime? fromDate, DateTime? toDate, int invoiceID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                decimal? TRANSACTION_AMOUNT;
                decimal? ADJUSTMENT;
                decimal? TOTAL_AMOUNT;
                var repository = new CustomerRepository(unitOfWork);
                repository.GetTransactionSummaryInv(customerID, beneficiaryID, fromDate, toDate, invoiceID, out TRANSACTION_AMOUNT, out ADJUSTMENT, out TOTAL_AMOUNT);
                return new CustomerTransactionDTO { TransactionAmount = TRANSACTION_AMOUNT, Adjustment = ADJUSTMENT, TotalAmount = TOTAL_AMOUNT };
            }
        }

        /// <summary>
        /// F200
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        public string GetCustomerCodeByID(int customerID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetCustomerCodeByID(customerID);
            }
        }

        //F203
        public List<ProductDTO> GetAllProductForDifferentialPricing(int customerID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetAllProductForDifferentialPricing(customerID).ToDTOs();
            }
        }

        //F204
        public List<UpliftDiscountDTO> GetAllUpliftDiscountsForProduct(int productID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetAllUpliftDiscountsForProduct(productID).ToDTOs();
            }
        }

        public CustomerReceiptPreferenceDTO GetCustomerReceiptPreference(int customerID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetCustomerReceiptPreference(customerID).ToDTO();
            }
        }

        public List<CardCenterDTO> GetAllCardCentres()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new Repository<CARD_CENTER>(unitOfWork);
                var data = repository.ExecuteStoredProcedure("GetAllCardCentres");
                return data.ToDTOs();
            }
        }

        public List<CardCenterDTO> GetAllCardCentresForIdentity()
        {
            using (var unitofWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitofWork);
                return repository.GetAllCardCentresForIdentity().ToDTOs();
            }
        }

        public List<CardCenterDTO> GetAllCardCentresForNonIdentity()
        {
            using (var unitofWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitofWork);
                return repository.GetAllCardCentresForNonIdentity().ToDTOs();
            }
        }

        //F215
        public bool DeleteCustomerDriverCard(int paymentTokenID, int driverCardTokenID, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.DeleteCustomerDriverCard(paymentTokenID, driverCardTokenID, UserID, LastUpdatedDate, LocationId);
            }
        }

        //F216
        public List<MappedDriverDTO> GetAllCustomerDriverCardForToken(int paymentTokenID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetAllCustomerDriverCardForToken(paymentTokenID).ToDTOs();
            }
        }

        //218
        public bool HasModulePrivilege(string userName, int moduleID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.HasModulePrivilege(userName, moduleID);
            }
        }

        //219
        public bool HasPagePrivilege(string userName, int pageID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.HasPagePrivilege(userName, pageID);
            }
        }

        //220
        public bool HasFunctionPrivilege(string userName, int functionID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.HasFunctionPrivilege(userName, functionID);
            }
        }

        //F224
        public bool SubmitEmailRequest(EmailDTO dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.SubmitEmailRequest(dto.ToEntity(), (int)dto.LanguageID);
            }
        }

        //F225
        //public NotificationMessageDto GetNotificationMessageByCode1(string NotificationMsgCode)
        //{
        //    var client = new NotificationsService.NotificationsServiceClient();
        //    var data = client.GetNotificationMessageById(int.Parse(NotificationMsgCode));
        //    NotificationMessageDto dto = new NotificationMessageDto();
        //    if (data != null)
        //    {
        //        dto.MessageCode = data.MessageCode;
        //        dto.MessageBody = data.MessageBody;
        //        dto.ArMessageBody = data.ArMessageBody;
        //        dto.MessageSubject = data.MessageSubject;
        //        dto.ArMessageSubject = data.ArMessageSubject;
        //        dto.MessageType = data.MessageType;
        //    }
        //    return dto;
        //}

        //F226
        public int GetMinimumAccountActivationBalance()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetMinimumAccountActivationBalance();
            }
        }

        //

        //F279
        public bool AddCustomerInvoicePreference(int CustomerID, int InvoiceTypeID, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.AddCustomerInvoicePreference(CustomerID, InvoiceTypeID, UserID, LastUpdatedDate, LocationId);
            }
        }

        //F280
        public bool DeleteCustomerInvoicePreference(int Customer_ID, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.DeleteCustomerInvoicePreference(Customer_ID, UserID, LastUpdatedDate, LocationId);
            }
        }

        //F281
        public CustomerRefundDTO GetCustomerRefundData(string Customer_CODE)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetCustomerRefundData(Customer_CODE).ToDTO();
            }
        }

        //F282
        public bool RefundCustomer(int Customer_ID, string docRef, string Remarks, BaseDTO Audit, decimal RefundAmount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.RefundCustomer(Customer_ID, docRef, Remarks, Audit.ToEntity(), RefundAmount);
            }
        }


        #region workFlow
        public string GetRequestCode(int requestID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetRequestCode(requestID);
            }
        }
        public List<RequestCustomerContactsDTO> RequestCustomerContact(int CustomerId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.RequestCustomerContact(CustomerId).ToDTOs();
            }
        }
        public List<RequestContactDTO> GetrequestCustomerContactHistory(int CustomerId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetrequestCustomerContactHistory(CustomerId).ToDTOs();
            }
        }

        public List<RequestCustomerContactsDTO> RequestCustomerContacHistMapping(int CustomerID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.RequestCustomerContacHistMapping(CustomerID).ToRDTOs();
            }
        }
        public int GetpreviousWorkflowHistoryInstance(int InstanceID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetpreviousWorkflowHistoryInstance(InstanceID);
            }
        }

        //700
        public int CreateWorkflowInstance(int RequestID, int RequestTypeID, int CurrentUserID, int Location_id)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.CreateWorkflowInstance(RequestID, RequestTypeID, CurrentUserID, Location_id);
            }
        }
        //701
        public List<PropertyDTO> GetAllRequestTypes()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetAllRequestTypes().ToDTOs();
            }
        }
        //F702
        public List<PropertyDTO> GetAllRequestStatus()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetAllRequestStatus().ToDTOs();
            }
        }
        //F703
        public List<SearchRQSTRequestResultDTO> SearchAgentRequest(SearchRqstRequestDTO searchdto, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.SearchAgentRequest(searchdto.ToEntity(), pageNo, pageSize, out rowCount).ToDTOs();
            }
        }
        //F704
        public List<SearchRQSTRequestResultDTO> SearchApproverRequest(SearchRqstRequestDTO searchdto, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.SearchApproverRequest(searchdto.ToEntity(), pageNo, pageSize, out rowCount).ToDTOs();
            }
        }
        public List<SearchRQSTRequestResultDTO> SearchFinalApproverRequest(SearchRqstRequestDTO searchdto, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.SearchFinalApproverRequest(searchdto.ToEntity(), pageNo, pageSize, out rowCount).ToDTOs();
            }
        }

        public List<SearchPendingRequestResultDTO> SearchPendingRequest(SearchRqstRequestDTO searchdto, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.SearchPendingRequest(searchdto.ToEntity(), pageNo, pageSize, out rowCount).ToDTOs();
            }
        }
        public List<SearchEscalatedRequestResultDTO> SearchEscalatedRequest(SearchRqstRequestDTO searchdto, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.SearchEscalatedRequest(searchdto.ToEntity(), pageNo, pageSize, out rowCount).ToDTOs();
            }
        }
        public int ProcessEscalationRequest(int WorkFlowInstanceID, int RequestId, string Comments, int CurrentUserid, int LocationID, int? EscalatedUserTo, int? EscalteRoleId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.ProcessEscalationRequest(WorkFlowInstanceID, RequestId, Comments, CurrentUserid, LocationID, EscalatedUserTo, EscalteRoleId);
            }
        }
        //F705
        public List<SearchRQSTRequestResultDTO> SearchRequestHistory(SearchRqstRequestDTO searchdto, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.SearchRequestHistory(searchdto.ToEntity(), pageNo, pageSize, out rowCount).ToDTOs();
            }
        }
        //F706
        public RequestWorkflowHistoryDTO ViewRequestWorkflowHistory(int RequestID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.ViewRequestWorkflowHistory(RequestID).ToDTO();
            }
        }
        //F707
        public bool UpdateRequestStatus(int RequestID, int RequestStatusID, string CustomerCode, string Remarks, int userID, int LocationID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.UpdateRequestStatus(RequestID, RequestStatusID, CustomerCode, Remarks, userID, LocationID);
            }
        }
        //F708
        public RequestCustomerDTO ViewAccountRequest(int RequestID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.ViewAccountRequest(RequestID).ToDTO();
            }
        }

        //709
        public RequestWorkOrderDTO ViewWorkOrderRequest(int RequestID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.ViewWorkOrderRequest(RequestID).ToDTO();
            }
        }
        //F710
        public RequestPersonalizationDTO ViewPersonalizationIssueRequest(int RequestID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.ViewPersonalizationIssueRequest(RequestID).ToDTO();
            }
        }
        //F711
        public RequestAccountClosureDTO ViewAccountClosureRequest(int RequestID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.ViewAccountClosureRequest(RequestID).ToDTO();
            }
        }
        //F712
        public List<RequestDocumentDTO> GetRequestDocuments(int RequestTypeID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetRequestDocuments(RequestTypeID).ToDTOs();
            }
        }
        //F713
        public List<RQSTAttachementDTO> ViewAllRequestUploadedAttachments(int requestID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.ViewAllRequestUploadedAttachments(requestID).ToDTOs();
            }
        }
        //F714
        public RQSTAttachementDTO ViewRequestUploadedAttachmentByID(int AttachmentID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.ViewRequestUploadedAttachmentByID(AttachmentID).ToDTO();
            }
        }
        public bool UploadAttachment(List<CustomerAttachmentDTO> entity)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                foreach (var item in entity)
                    repository.UploadAttachment(item.ToEntity());
                return true;
            }
        }
        //F715
        public bool UploadRequestAttachment(List<RQSTAttachmentDTO> entity)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                foreach (var item in entity)
                    repository.UploadRequestAttachment(item.ToRQSTEntity());

                return true;
            }
        }
        //716
        public int GetLastWorkFlowInstanceID(int RequestId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetLastWorkFlowInstanceID(RequestId);
            }
        }
        //717
        public int InitiateRequestWorkflow(int WorkFlowInstanceID, int? AssignedUserID, int? AssignedRoleID, int ActionID, string Comments, int CurrentUserid, int LocationID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.InitiateRequestWorkflow(WorkFlowInstanceID, AssignedUserID, AssignedRoleID, ActionID, Comments, CurrentUserid, LocationID);
            }
        }
        //718
        public int ProcessWorkFlowStep(int WorkFlowInstanceID, int? AssignedUserID, int? AssignedRoleID, int ActionID, string Comments, int CurrentUserid, int LocationID, out int IsApprovalComplete)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.ProcessWorkFlowStep(WorkFlowInstanceID, AssignedUserID, AssignedRoleID, ActionID, Comments, CurrentUserid, LocationID, out IsApprovalComplete);
            }
        }
        //F719
        public List<SearchTokenIssuanceResultDTO> SearchTokenIssuance(SearchTokenIssuanceDTO entity, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.SearchTokenIssuance(entity.ToEntity(), pageNo, pageSize, out rowCount).ToDTOs();
            }
        }
        //F720
        public bool AddAccountRequestWFHistory(RequestWFHistoryCustomerDTO DTO)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                // return repository.AddAccountRequestWFHistory(entity.ToEntity());

                if (DTO.BasicAddress != null)
                {
                    if (DTO.BasicAddressID != null) DTO.BasicAddressID = (int)DTO.BasicAddressID;
                    DTO.BasicAddressID = repository.AddRequestCustomerAddressHistory(DTO.BasicAddress.ToEEntity());
                }
                if (DTO.BillingAddress != null)
                {
                    if (DTO.BillingAddressID != null) DTO.BillingAddressID = (int)DTO.BillingAddressID;
                    DTO.BillingAddressID = repository.AddRequestCustomerAddressHistory(DTO.BillingAddress.ToEEntity());
                }
                if (DTO.ShippingAddress != null)
                {
                    if (DTO.ShippingAddressID != null) DTO.ShippingAddressID = (int)DTO.ShippingAddressID;
                    DTO.ShippingAddressID = repository.AddRequestCustomerAddressHistory(DTO.ShippingAddress.ToEEntity());
                }
                if (DTO.AccountManager != null)
                {
                    DTO.AccountManagerID = repository.AddRequestAccountManager(DTO.AccountManager.ToEntity());
                }

                int CustomerID = repository.AddAccountRequestWFHistory(DTO.ToEntity());

                if (DTO.customerContact != null)
                {
                    foreach (var contact in DTO.customerContact)
                    {
                        int ContactTypeID = (int)contact.Contact.ContactTypeID;
                        int ContactID = repository.AddRequestCustomerContactHistory(contact.Contact.ToEERntity(), CustomerID, ContactTypeID, 1);
                        if (ContactTypeID == 0)
                            DTO.OperationalContactID = ContactID;
                        if (ContactTypeID == 1)
                            DTO.FinancialContactID = ContactID;
                    }
                }
                if (CustomerID > -1)
                    return true;
                else return false;

            }
        }
        //F721
        public bool AddWorkOrderRequestWFHistory(RequestWFHistoryWorkOrderDTO entity)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.AddWorkOrderRequestWFHistory(entity.ToEntity());
            }
        }
        //F722
        public bool AddPersonalizationRequestWFHistory(RequestWFHistoryPersonalizationDTO entity)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.AddPersonalizationRequestWFHistory(entity.ToEntity());
            }
        }
        //F723
        public bool UploadRequestWFHistoryAttachment(List<RequestWFHistoryAttachmentDTO> entity)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                foreach (var item in entity)
                {
                    repository.UploadRequestWFHistoryAttachment(item.ToEntity());
                }
                return true;
            }
        }
        //F724
        public bool RemoveRequestWFHistoryAttachment(List<RequestWFHistoryAttachmentDTO> entity)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                foreach (var item in entity)
                {
                    repository.RemoveRequestWFHistoryAttachment(item.ToEntity());
                }
                return true;
            }
        }
        //F725
        public RequestWFHistoryCustomerDTO ViewAccountRequestWFHistory(int WFInstanceID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.ViewAccountRequestWFHistory(WFInstanceID).ToDTO();
            }
        }
        //F726
        public RequestWFHistoryWorkOrderDTO ViewWorkOrderRequestWFHistory(int WFInstanceID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.ViewWorkOrderRequestWFHistory(WFInstanceID).ToDTO();
            }
        }
        //F727
        public RequestWFHistoryPersonalizationDTO ViewPersonalizationIssueRequestWFHistory(int WFInstanceID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.ViewPersonalizationIssueRequestWFHistory(WFInstanceID).ToDTO();
            }
        }

        //F728
        public List<RequestWFHistoryAttachmentDTO> ViewAllRequestWFHistoryUploadedAttachments(int WFInstanceID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.ViewAllRequestWFHistoryUploadedAttachments(WFInstanceID).ToDTOs();
            }
        }
        //F729
        public RequestWFHistoryAttachmentDTO ViewRequestWFHistoryUploadedAttachmentByID(int AttachmentID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.ViewRequestWFHistoryUploadedAttachmentByID(AttachmentID).ToDTO();
            }
        }
        //F730
        public bool IsFinalApproverStep(int RequestID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.IsFinalApproverStep(RequestID);
            }
        }
        //F731
        public int GetpreviousWorkFlowInstanceID(int CurrentWorkFlowInstanceID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetpreviousWorkFlowInstanceID(CurrentWorkFlowInstanceID);
            }

        }
        //F732
        public int GenerateAccountClosureRequest(int CustomerID, int UserID, DateTime LastUpdatedDate, int LocationID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GenerateAccountClosureRequest(CustomerID, UserID, LastUpdatedDate, LocationID);
            }
        }
        public int AddCreditDebitRQST(int CustomerID, int p_PAYMENT_TYPE_ID, decimal p_TRANSACTION_AMOUNT, int p_PAYMENT_METHOD_ID, string p_REMARKS, int UserID, int LocationID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.AddCreditDebitRQST(CustomerID, p_PAYMENT_TYPE_ID, p_TRANSACTION_AMOUNT, p_PAYMENT_METHOD_ID, p_REMARKS, UserID, LocationID);
            }
        }
        public int AddRefundRQST(int CustomerID, int p_PAYMENT_TYPE_ID, decimal p_TRANSACTION_AMOUNT, int p_PAYMENT_METHOD_ID, string p_REMARKS, int UserID, int LocationID, int RefundTypeID, string paymentDOCRef, string BankName, string AccountHolderName, string AccountNumber, string IBANNumber, int? CountryId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.AddRefundRQST(CustomerID, p_PAYMENT_TYPE_ID, p_TRANSACTION_AMOUNT, p_PAYMENT_METHOD_ID, p_REMARKS, UserID, LocationID, RefundTypeID, paymentDOCRef, BankName, AccountHolderName, AccountNumber, IBANNumber, CountryId);
            }
        }
        public int UpdateRefundRQST(int RequestID, string p_REMARKS, int UserID, int LocationID, decimal TransactionAmount, int RefundTypeID, string paymentDOCRef, string BankName, string AccountHolderName, string AccountNumber, string IBANNumber, int? CountryId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.UpdateRefundRQST(RequestID, p_REMARKS, UserID, LocationID, TransactionAmount, RefundTypeID, paymentDOCRef, BankName, AccountHolderName, AccountNumber, IBANNumber, CountryId);
            }
        }
        public int AddVoucherRQST(int CustomerID, DateTime p_VALIDITY_START_DATE, DateTime p_VALIDITY_END_DATE, int? p_VALIDITY_TYPE_ID, int? p_VOUCHER_TYPE_ID,
            decimal? p_AMOUNT, string p_REMARKS, decimal? p_IS_NOTIFIED, decimal? p_IS_LOYALTY_VOUCHER, decimal? p_IS_ACTIVE, int UserID, int LocationID,
            string p_ALLOWEDPRODUCTIDS, int p_QUANTITY)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.AddVoucherRQST(CustomerID, p_VALIDITY_START_DATE, p_VALIDITY_END_DATE, p_VALIDITY_TYPE_ID, p_VOUCHER_TYPE_ID,
                p_AMOUNT, p_REMARKS, p_IS_NOTIFIED, p_IS_LOYALTY_VOUCHER, p_IS_ACTIVE, UserID, LocationID, p_ALLOWEDPRODUCTIDS, p_QUANTITY);
            }
        }
        public List<WorkFlowHistoryDTO> GetWorkFlowHistory(int RequestID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetWorkFlowHistory(RequestID).ToDTOs();
            }
        }
        public int AddNewAccountRequest(RequestCustomerDTO DTO)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                int requestId = -1;

                if (DTO.RequestID == null)
                {
                    if (
                        ValidateAccountCreationRequest(DTO.Request.REQUEST_TYPE_ID ?? -1, null, DTO.NationalID,
                            DTO.FinancialAccountNo) != 1)
                        return -1;

                    requestId = CreateRequest(DTO.Request);
                    DTO.RequestID = requestId;
                }
                else
                {
                    if (
                ValidateAccountCreationRequest(DTO.Request.REQUEST_TYPE_ID ?? -1, DTO.Request.REQUEST_ID, DTO.NationalID,
                    DTO.FinancialAccountNo) != 1)
                        return -1;
                }
                if (DTO.customerContact != null && DTO.CustomerTypeID == 1) //LOKI- For individual Mobile NO should be unique
                {
                    foreach (var contact in DTO.customerContact)
                    {
                        ValidateDuplicateMobileNumber(contact.Contact.Mobile, DTO.RequestID);
                    }
                }
                requestId = DTO.RequestID ?? -1;
                if (DTO.BasicAddress != null)
                {
                    if (DTO.BasicAddressId != null) DTO.BasicAddressId = (int)DTO.BasicAddressId;
                    DTO.BasicAddressId = repository.AddRequestCustomerAddress(DTO.BasicAddress.ToEEntity());
                }
                if (DTO.BillingAddress != null)
                {
                    if (DTO.BillingAddressId != null) DTO.BillingAddressId = (int)DTO.BillingAddressId;
                    DTO.BillingAddressId = repository.AddRequestCustomerAddress(DTO.BillingAddress.ToEEntity());
                }
                if (DTO.ShippingAddress != null)
                {
                    if (DTO.ShippingAddressId != null) DTO.ShippingAddressId = (int)DTO.ShippingAddressId;
                    DTO.ShippingAddressId = repository.AddRequestCustomerAddress(DTO.ShippingAddress.ToEEntity());
                }
                if (DTO.AccountManager != null)
                {
                    DTO.AccountManagerID = repository.AddRequestAccountManager(DTO.AccountManager.ToEntity());
                }

                int customerId = repository.AddNewAccountRequest(DTO.ToEntity());

                if (DTO.customerContact != null)
                {
                    foreach (var contact in DTO.customerContact)
                    {
                        int contactId = repository.AddRequestCustomerContact(contact.Contact.ToEEntity(), customerId, contact.ContactTypeID, 1);
                        if (contact.ContactTypeID == 0 || contact.ContactTypeID == 2)
                            DTO.OperationalContactID = contactId;
                        if (contact.ContactTypeID == 1)
                            DTO.FinancialContactID = contactId;
                    }
                }
                return requestId;

            }
        }

        public List<PropertyDTO> GetAvailableCustomerContatcType(int customerId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetAvailableCustomerContatcType(customerId).ToDTOs();
            }
        }
        public int AddWorkOrderRequest(RequestWorkOrderDTO dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                int requestId = -1;

                if (ValidateRequest(dto.Request.REQUEST_TYPE_ID ?? -1, dto.RequestId, dto.Request.CUSTOMER_ID, dto.Request.BENEFICIARY_ID, dto.Request.TOKEN_ID, null) != 1)
                    return -1;

                if (dto.Request != null)
                {
                    requestId = CreateRequest(dto.Request);
                    dto.RequestId = requestId;
                }
                repository.AddWorkOrderRequest(dto.ToEntity());
                dto.RequestId = requestId;
                return requestId;
            }
        }
        public int CreatePersonalizationRequest(RequestPersonalizationDTO dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                int requestId = -1;
                if (ValidateRequest(dto.Request.REQUEST_TYPE_ID ?? -1, dto.RequestId, dto.Request.CUSTOMER_ID, dto.Request.BENEFICIARY_ID, dto.Request.TOKEN_ID, null) != 1)
                    return -1;

                if (dto.Request != null)
                {
                    requestId = CreateRequest(dto.Request);
                    dto.RequestId = requestId;
                }
                repository.CreatePersonalizationRequest(dto.ToEntity());
                return requestId;
            }
        }
        public int CreateRequest(RequestDTO dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.CreateRequest(dto.ToEntity());
            }
        }
        public int AddRequestAccountManager(RequestAccountManagerDTO dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.AddRequestAccountManager(dto.ToEntity());
            }
        }
        public RequestAccountManagerDTO GetRequestAccountManager(int AccountManagerID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetRequestAccountManager(AccountManagerID).ToDTO();
            }
        }
        public int AddRequestCustomerContact(RequestContactDTO dto, int customer_id, int ContactType, int contactid)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.AddRequestCustomerContact(dto.ToEEntity(), customer_id, ContactType, contactid);
            }
        }
        public int AddRequestCustomerAddress(RequestCustomerAddressDTO dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.AddRequestCustomerAddress(dto.ToEEntity());
            }
        }
        public int AddRequestCustomerAddressHistory(RequestCustomerAddressDTO dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.AddRequestCustomerAddressHistory(dto.ToEEntity());
            }
        }
        //F737
        public List<PropertyDTO> GetAllMonthlyVolumes()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetAllMonthlyVolumes().ToDTOs();
            }
        }
        public bool RevertWorkFlowStep(int wfInstanceId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.RevertWorkFlowStep(wfInstanceId);
            }
        }

        public bool CancelWorkOrder(int WorkOrderID, int LastLocationId, int LastUserID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.CancelWorkOrder(WorkOrderID, LastLocationId, LastUserID);
            }
        }

        public bool CancelPersonalizationOrder(int PersonalizaionOrderID, int LastLocationId, int LastUserID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.CancelPersonalizationOrder(PersonalizaionOrderID, LastLocationId, LastUserID);
            }
        }

        public OrderCancellationDTO GetDetailsForPersonalizationCancellation(int PersonalizationID, int pToekenID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetDetailsForPersonalizationCancellation(PersonalizationID, pToekenID).ToDTO();
            }
        }
        public OrderCancellationDTO GetDetailsForWorkOrderCancellation(int WorkOrderID, int pToekenID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetDetailsForWorkOrderCancellation(WorkOrderID, pToekenID).ToDTO();
            }
        }

        #endregion

        //F285
        public List<SearchRequestResultDTO> SearchRequest(SearchRequestDTO dto, int? ModuleID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.SearchRequest(dto.ToEntity(), ModuleID).ToDTOs();
            }
        }


        ////288
        //public RequestWorkOrderDTO ViewWorkOrderRequest(int RequestID)
        //{
        //    using (var unitOfWork = new UnitOfWork())
        //    {
        //        var repository = new CustomerRepository(unitOfWork);
        //        return repository.ViewWorkOrderRequest(RequestID).ToDTO();
        //    }
        //}

        ////F289
        //public RequestPersonalizationDTO ViewPersonalizationIssueRequest(int RequestID)
        //{
        //    using (var unitOfWork = new UnitOfWork())
        //    {
        //        var repository = new CustomerRepository(unitOfWork);
        //        return repository.ViewPersonalizationIssueRequest(RequestID).ToDTO();
        //    }
        //}


        ////F292
        //public List<RQSTAttachementDTO> ViewAllRequestUploadedAttachments(int requestID)
        //{
        //    using (var unitOfWork = new UnitOfWork())
        //    {
        //        var repository = new CustomerRepository(unitOfWork);
        //        return repository.ViewAllRequestUploadedAttachments(requestID).ToDTOs();
        //    }
        //}

        ////F293
        //public RQSTAttachementDTO ViewRequestUploadedAttachmentByID(int AttachmentID)
        //{
        //    using (var unitOfWork = new UnitOfWork())
        //    {
        //        var repository = new CustomerRepository(unitOfWork);
        //        return repository.ViewRequestUploadedAttachmentByID(AttachmentID).ToDTO();
        //    }
        //}

        ////F294
        //public bool UploadAttachment(List<CustomerAttachmentDTO> dtos)
        //{
        //    using (var unitOfWork = new UnitOfWork())
        //    {
        //        var repository = new CustomerRepository(unitOfWork);
        //        foreach (var item in dtos)
        //        {
        //            repository.UploadAttachment(item.ToEntity());
        //        }
        //        return true;

        //    }
        //}

        //F295
        public CustomerAttachmentDTO ViewCustomerAttachmentByID(int AttachmentID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.ViewCustomerAttachmentByID(AttachmentID).ToDTOC();
            }
        }

        //F296
        public List<CustomerAttachmentDTO> GetAllCustomerAttachments(int CustomerID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetAllCustomerAttachments(CustomerID).ToDTOCs();
            }
        }

        //


        //F304
        public bool IsRefundAllowedForCustomer(int customer_id)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.IsRefundAllowedForCustomer(customer_id);
            }
        }

        //305
        public int GetCustomerInvoicePreference(int customerID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetCustomerInvoicePreference(customerID);
            }
        }

        //306
        public bool AddTerminationPendingCustomer(int customerID, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.AddTerminationPendingCustomer(customerID, UserID, LastUpdatedDate, LocationId);
            }
        }

        //307
        public bool AddServiceTransaction(int ServiceID, int CustomerID, int? BeneficiaryID, int? TokenID, int UserId, int LastUpdatedUserID, DateTime LastUpdatedDate, int LastLocationID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.AddServiceTransaction(ServiceID, CustomerID, BeneficiaryID, TokenID, UserId, LastUpdatedUserID, LastUpdatedDate, LastLocationID);
            }
        }

        //308
        public List<FeeCustomerPaymentTransactionDTO> GetCreditDebitNoteHistory(int CustomerID, int PageID, int PageSize, out int RowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetCreditDebitNoteHistory(CustomerID, PageID, PageSize, out RowCount).ToDTOs();
            }
        }

        //309
        public string GetOrderNumber(int TokenID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetOrderNumber(TokenID);
            }
        }

        //310
        public List<ProductDTO> GetAllNonDieselProducts()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetAllNonDieselProducts().ToDTOs();
            }
        }

        //311
        public PropertyDTO GetCurrentCustomerStatus(int CustomerID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetCurrentCustomerStatus(CustomerID).ToDTO();
            }
        }

        //312
        public RequestServiceFeeDTO ViewServiceFeeRequest(int RequestID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.ViewServiceFeeRequest(RequestID).ToDTO();
            }
        }

        //313
        public bool UpdateServiceFee(ServiceFeeDTO entity)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.UpdateServiceFee(entity.ToEntity());
            }
        }

        //314
        public bool IsRenewalRequest(int TokenID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.IsRenewalRequest(TokenID);
            }
        }
        public CustomerReceiptPreferenceDTO GetRequestCustomerReceiptPreference(int customerID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetRequestCustomerReceiptPreference(customerID).ToDTO();
            }
        }

        public RequestCustomerAddressDTO GetRequestCustomerAddress(int addressID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetRequestCustomerAddress(addressID).ToDTO();
            }
        }
        public RequestCustomerAddressDTO GetRequestCustomerAddressHistory(int addressID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetRequestCustomerAddressHistory(addressID).ToDTO();
            }
        }

        public RequestCustomerAddressDTO GetCustomerAddress(int addressID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetCustomerAddress(addressID).ToDTO();
            }
        }

        public RequestDTO GetRequestById(int requestID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetRequestById(requestID).ToDTO();
            }
        }

        public List<RequestContactDTO> GetRequestCustomerContacts(int requestCustomerID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetRequestCustomerContacts(requestCustomerID).ToDTOs();
            }
        }

        public List<CustomerContactDTO> GetCustomerContacts(int CustomerID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetCustomerContacts(CustomerID).ToCDTOs();
            }
        }

        //F315
        public bool RemoveAttachment(CustomerAttachmentDTO dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.RemoveAttachment(dto.ToEntity());
            }
        }

        //F318
        public bool IsIDAlreadyRegistered(int Mode, int IDType, string IDNumber, int? CUSTOMERID, int? BeneficiaryID, out string pMessage)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.IsIDAlreadyRegistered(Mode, IDType, IDNumber, CUSTOMERID, BeneficiaryID, out pMessage);
            }
        }

        //F321
        public List<PropertyDTO> GetAllFamily()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetAllFamily().ToFDTOs();
            }
        }

        //F322
        public OpeningClosingBalanceDTO GetOpeningClosingBalance(int CustomerID, DateTime FromDate, DateTime ToDate)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                decimal? _openingBalance;
                decimal? _closingBalance;
                repository.GetOpeningClosingBalance(CustomerID, FromDate, ToDate, out _openingBalance, out _closingBalance);
                return new OpeningClosingBalanceDTO { OpeningBalance = _openingBalance, ClosingBalance = _closingBalance };
            }
        }

        //323
        public int GetDieselProductID()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetDieselProductID();
            }
        }

        public int ValidateRequest(int requesttypeid, int? requestId, int? customerId, int? beneficiaryId, int? tokenId, Int32? workflowinstanceid)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.ValidateRequest(requesttypeid, requestId, customerId, beneficiaryId, tokenId, workflowinstanceid);
            }
        }

        public int ValidateAccountCreationRequest(int requesttypeid, int? requestId, string pNationalId, string pFinancialAccountNo)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.ValidateAccountCreationRequest(requesttypeid, requestId, pNationalId, pFinancialAccountNo);
            }
        }

        //F324
        public int IsDieselRestricted(int tokenID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.IsDieselRestricted(tokenID);
            }
        }

        //F325
        public List<LocationDTO> GetAllCMSLocations()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetAllCMSLocations().ToDTOs();
            }
        }

        //F326
        public bool UpdateCeilingLimit(int CeilingLimitID, decimal LimitValue, int UserId, int LocationId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.UpdateCeilingLimit(CeilingLimitID, LimitValue, UserId, LocationId);
            }
        }


        public List<DictionaryDTO> GetGLCostCentre()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetGLCostCentre().ToDTOs();
            }
        }

        //F327
        public bool TerminateCustomer(int customerID, int UserId, int LocationID, out int RefundAmount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.TerminateCustomer(customerID, UserId, LocationID, out RefundAmount);
            }

        }

        public CeilingLimitDTO GetCeilingLimit()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetCeilingLimit().ToDTO();
            }
        }

        public DictionaryDTO GetYearByID(int yearID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetYearByID(yearID).ToDTO();
            }

        }

        public bool IsPremierAccessGranted(int userID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.IsPremierAccessGranted(userID);
            }
        }
        public bool IsUpdateVehicleInfoGranted(int userID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.IsUpdateVehicleInfoGranted(userID);
            }
        }
        public bool IsViewAuditGranted(int userID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.IsViewAuditGranted(userID);
            }
        }
        public NotificationMessageDto GetNotificationMessageByCode(string MessageCode)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetNotificationMessageByCode(MessageCode).ToDTO();
            }
        }

        public List<PaymentTypeDTO> GetCreditDebitPaymentTypes()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetCreditDebitPaymentTypes().ToDTOs();
            }
        }
        public bool DeleteCsutomerFromCMSOrRequest(int? CustomerId, int? RequestId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.DeleteCsutomerFromCMSOrRequest(CustomerId, RequestId);
            }
        }
        public int GetTerminationCutOffPeriod()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetTerminationCutOffPeriod();
            }
        }
        public List<IssuanceLocationLoadDto> GetCardCentreLoad(int cardCentreId, int preferredMonthId, int preferredYear)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetCardCentreLoad(cardCentreId, preferredMonthId, preferredYear).ToDtOs();
            }
        }
        public List<IssuanceLocationLoadDto> GetVehicleDepotLoad(int depotId, int preferredMonthId, int preferredYear)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetVehicleDepotLoad(depotId, preferredMonthId, preferredYear).ToDtOs();
            }
        }
        public bool IsCustomerCodeValid(string code)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.IsCustomerCodeValid(code);
            }
        }
        public bool EventLog(DateTime _DateTime, string source, int LogLevel, string Message, string DetailedMessage)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.EventLog(_DateTime, source, LogLevel, Message, DetailedMessage);
            }

        }
        private readonly DUC.CMS.CustomerService.DAL.Repository.FinanceId _finance = new DUC.CMS.CustomerService.DAL.Repository.FinanceId();
        public List<FinanceIdDTO> GetNonRegisteredERPAccounts()
        {

            return _finance.GetNonRegisteredERPAccounts().MapToListDto();
        }
        public List<FinanceIdDTO> GetNonRegisteredSIteIDForERPAccount(int financialID)
        {

            return _finance.GetNonRegisteredSIteIDForERPAccount(financialID).MapToListDto();
        }
        public List<FinanceIdDTO> GetRegisteredERPAccounts()
        {

            return _finance.GetRegisteredERPAccounts().MapToListDto();
        }
        public List<FinanceIdDTO> GetRegisteredSIteIDForERPAccount(int financialID)
        {

            return _finance.GetRegisteredSIteIDForERPAccount(financialID).MapToListDto();
        }
        public List<FinanceIdDTO> GetAllSIteIDForERPAccount(int? financialID)
        {
            return _finance.GetAllSIteIDForERPAccount(financialID).MapToListDto();
        }
        public bool IsRequestIDValidforAssignedUser(string RequestsIDs, int AssignedUserid, int Mode, out string InvalidIDsList)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                bool res = repository.IsRequestIDValidforAssignedUser(RequestsIDs, AssignedUserid, Mode, out InvalidIDsList);
                return res;
            }
        }
        public bool IsRequestPendingForCustomerOrToken(int customerId, int? TokenId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                bool res = repository.IsRequestPendingForCustomerOrToken(customerId, TokenId);
                return res;
            }
        }
        public bool TerminatePendingRequests(int customerId, int? TokenId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                bool res = repository.TerminatePendingRequests(customerId, TokenId);
                return res;
            }
        }
        public string GetFullNationality(string Code)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetFullNationality(Code);

            }

        }
        public List<CustomerQuotaDTO> GetCustomerQuota(int CustomerId, int? ProductId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetCustomerQuota(CustomerId, ProductId).ToDTOs();
            }
        }
        public CustomerQuotaDTO GetAccountQuotaByQuotaId(int QuotaId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetAccountQuotaByQuotaId(QuotaId).ToDTO();
            }
        }

        public int GetNationalityIDByName(string Name)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetNationalityIDByName(Name);
            }
        }
        public int GetEmployeeNoForSerial(string SerialNo)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetEmployeeNoForSerial(SerialNo);
            }

        }
        public bool IsTokenSerialAlreadyExist(int? TokenId, string TokenSerial, out string Remark)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.IsTokenSerialAlreadyExist(TokenId, TokenSerial, out Remark);
            }
        }
        public bool RenewKNPEmployeeCard(int tokenID, string newCardSerial, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.RenewKNPEmployeeCard(tokenID, newCardSerial, UserID, LastUpdatedDate, LocationId);
            }
        }

        public int SaveCustomerQuota(int? CustomerQuotaId, int custromerId, int productId, decimal Quota, int userId, int locationId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.SaveCustomerQuota(CustomerQuotaId, custromerId, productId, Quota, userId, locationId);
            }
        }
        public bool DeleteCustomerQuota(int customerId, int productId, int userId, int locationId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.DeleteCustomerQuota(customerId, productId, userId, locationId);
            }
        }
        public decimal GetCustomerQuotaConsumption(int customerId, int productId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetCustomerQuotaConsumption(customerId, productId);
            }
        }

        public bool UpdateBeneficiaryRestriction(BeneficiaryRestrictionInputDTO beneficiaryRestrictionDto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new BeneficiaryRepository(unitOfWork);
                return repository.UpdateBeneficiaryRestriction(beneficiaryRestrictionDto.ToEntity());
            }
        }

        public BeneficiaryRestrictionResultDTO GetBenenficiaryRestriction(int BeneficiaryId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new BeneficiaryRepository(unitOfWork);
                return repository.GetBenenficiaryRestriction(BeneficiaryId).ToDTO();
            }
        }

        public List<MonthDTO> GetAllMonths()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new BeneficiaryRepository(unitOfWork);
                return repository.GetAllMonths().ToDTOs();
            }
        }

        public DUC.CMS.Token.BLL.DTO.TokensToDeliverResultDTO SearchCustomerTokensReadyForDelivery(DUC.CMS.Token.BLL.DTO.SearchTokenToDeliverDTO dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                int totalCount = 0;
                var res = repository.SearchCustomerTokensReadyForDelivery(dto.MapToEntity(), out totalCount).MapToListDto();
                return new DUC.CMS.Token.BLL.DTO.TokensToDeliverResultDTO()
                {
                    Dtos = res,
                    TotalCount = totalCount
                };
            }
        }


        public bool IssueToken(int TokenID, string Serial, string SecondSerial, string ThirdSerial, int UserID, int LocationId, int Mode, int IsFeeWaivedOff)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                TokenRepository repository = new TokenRepository(unitOfWork);
                return repository.IssueToken(TokenID, Serial, SecondSerial, ThirdSerial, UserID, LocationId, Mode, IsFeeWaivedOff);
            }
        }

        public bool hasAddTokenUsedBalanceGranted(int UserID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                CustomerRepository repository = new CustomerRepository(unitOfWork);
                return repository.hasAddTokenUsedBalanceGranted(UserID);
            }
        }

        public bool IsZeroTransactionToken(int tokenId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                TokenRepository repository = new TokenRepository(unitOfWork);
                return repository.IsZeroTransactionToken(tokenId);
            }
        }

        public int SetTokenUsedAmount(int tokenId, decimal usedAmount, int UserID, int LocationId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                TokenRepository repository = new TokenRepository(unitOfWork);
                return repository.SetTokenUsedAmount(tokenId, usedAmount, UserID, LocationId);
            }
        }

        public List<PrintReceiptTransDTO> GetPrintReceiptTrans(PrintReceiptTransInputDTO dto, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                var accountTransactionsBalance = repository.GetAccountTransactionBalance(dto.CustomerId,
                dto.FromDate, dto.ToDate, dto.TransactionTypeId, dto.BeneficiaryNo, dto.BeneficiaryName, dto.TokenTypeId, dto.TokenSerial,
                    dto.VatInvoiceNumber, (dto.IsPremiumService.HasValue ? (dto.IsPremiumService.Value ? (short)1 : (short)0) : (short?)null), dto.ExemptionTypeId, dto.PageNo, dto.PageSize, out rowCount).ToDTOs();
                if (accountTransactionsBalance != null)
                    foreach (var trans in accountTransactionsBalance)
                    {
                        if (string.Equals(trans.TransactionType, "Debit (Station Transactions)", StringComparison.InvariantCultureIgnoreCase) && string.Equals(trans.ServiceOrProdName, "PRODUCT LIST", StringComparison.InvariantCultureIgnoreCase))
                        {
                            trans.ProductDtos = repository.GetProductListByTransId(trans.TransactionId).ToDTOs();
                            foreach (var prod in trans.ProductDtos)
                            {
                                prod.VatInvoiceNumber = trans.VatInvoiceNumber;
                                prod.IsPrintable = trans.IsPrintable == 1 ? true : false;
                            }
                        }
                    }
                return accountTransactionsBalance;
            }
        }

        public PrintReceiptDataDTO GetAccountReceiptData(int? CustomerId, int? TransactionId, int? PaymentTypeId, string TransactionType)
        {
            using (var UnitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(UnitOfWork);
                PrintReceiptDataDTO dto = repository.GetPrintReceiptData(CustomerId, TransactionId, PaymentTypeId, TransactionType).ToDTO();
                if (dto != null)
                    dto.ReceiptDetailsDTOs = repository.GetReceiptDetails(TransactionId).ToDTOs();
                return dto;
            }
        }

        public List<TransactionTypeDTO> GetAllTrxTypes()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetAllTrnsTypes().ToDTOs();

            }
        }

        public List<BillingFrequencyDTO> GetAllBillingFrequency()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetAllBillingFrequency().ToDTOs();

            }
        }

        public bool ISBeneficiaryCreationAllowed(int? CustomerId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.ISBeneficiaryCreationAllowed(CustomerId);

            }
        }

        public bool RestrictionGroupTransaction(Nullable<decimal> MaximumTransactionAmount,
            int? IsActive, Nullable<decimal> LastUpdatedUserId,
            Nullable<System.DateTime> LastUpdatedDate, Nullable<decimal> LastLocationID,
            int? IsDry, Nullable<decimal> ProductCategoryID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                bool res = repository.RestrictionGroupTransaction(MaximumTransactionAmount, IsActive,
                LastUpdatedUserId, LastUpdatedDate, LastLocationID, IsDry, ProductCategoryID);
                return res;
            }
        }

        public bool RestrictionGroupStation(int? RSGRPID, int? StationID,
            int? IsActive, int? LastUpdatedUserId,
           Nullable<System.DateTime> LastUpdatedDate, int? LastLocationID,
            int? IsDry)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                bool res = repository.RestrictionGroupStation(RSGRPID, StationID, IsActive,
                LastUpdatedUserId, LastUpdatedDate, LastLocationID, IsDry);
                return res;
            }
        }

        public bool RestrictionGroupAmount(int? RestrictionGroupID, int? TimeFrequencyID,
           Nullable<decimal> AllowedAmount, int? IsActive, int? LastUpdatedUserId,
           Nullable<System.DateTime> LastUpdatedDate, int? LastLocationID,
            int? IsDry, int? ProductCategoryID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                bool res = repository.RestrictionGroupAmount(RestrictionGroupID, TimeFrequencyID, AllowedAmount, IsActive,
                LastUpdatedUserId, LastUpdatedDate, LastLocationID, IsDry, ProductCategoryID);
                return res;
            }
        }

        public bool RestrictionGroupTransactionNo(int? RestrictionGroupID, int? NumberOfDays,
            int? NumberOfTransactions, int? TimeFrequencyID, int? IsActive,
            int? LastUpdatedUserId, Nullable<System.DateTime> LastUpdatedDate,
            int? LastLocationID, int? IsDry,
            int? ProductCategoryID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                bool res = repository.RestrictionGroupTransactionNo(RestrictionGroupID, NumberOfDays, NumberOfTransactions, TimeFrequencyID,
                IsActive, LastUpdatedUserId, LastUpdatedDate, LastLocationID, IsDry, ProductCategoryID);
                return res;
            }
        }

        public List<TransactionProductDTO> GetAllTransactionProducts()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetAllTransactionProducts().ToDTOs();
            }
        }

        public List<ProductCategoryDTO> GetAllProductCategories()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetAllProductCategories().ToDTOs();
            }
        }

        public List<CategoryDTO> ProductCategorySA()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.ProductCategorySA().ToDTOs();
            }
        }
        public int ISCompanyRegistrationIDUnique(int? CustomerID, int? RequestCustomerID, string CompanyID, out int Response)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.ISCompanyRegistrationIDUnique(CustomerID, RequestCustomerID, CompanyID, out Response);
            }

        }
        public void ValidateDuplicateMobileNumber(string mobileNumber, int? customerID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                repository.ValidateDuplicateMobileNumber(mobileNumber, customerID);
            }
        }

        public int GetBeneficiaryCount(int? CustomerId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetBeneficiaryCount(CustomerId);

            }
        }

        public List<FinanceIdDTO> GetNonRegisteredIndAccounts()
        {

            return _finance.GetNonRegisteredIndAccounts().MapToListDto();
        }
        public bool CheckNationalIDExistForIndPrepaid(string NationalID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.CheckNationalIDExistForIndPrepaid(NationalID);
            }
        }
        public List<PropertyDTO> GetAllCustomerTypes()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetAllCustomerTypes().ToCDTOs();
            }
        }

        public List<PropertyDTO> GetAllNotificationPreferences()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetAllNotificationPreferences().ToDTOs();
            }
        }

        public bool IsTransactionReversalGranted(int userID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.IsTransactionReversalGranted(userID);
            }
        }

        public bool Reverse_Transaction(bool isPayment, int transactionDetailID, DateTime reverseDate, int currentUserid, int locationID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.Reverse_Transaction(isPayment, transactionDetailID, reverseDate, currentUserid, locationID);
            }
        }

        public List<TransactionReversalDTO> SearchTransactionForReversal(TransactionReversalSearchDTO dto, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.SearchTransactionForReversal(dto.ToEntity(), pageNo, pageSize, out rowCount).ToDTOs().ToList();
            }
        }

        public List<TransactionReversalDTO> ViewReversedTransaction(bool isPayment, int transactionDetailID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.ViewReversedTransaction(isPayment, transactionDetailID).ToDTOs().ToList();
            }
        }


        public List<RefundTypeDTO> GetAllRefundTypes()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetAllRefundTypes().ToDTOs().ToList();
            }
        }
        public CustomerPaymentDTO GetTopUpDetailsByDocRef(string paymentDocRef, int? CustomerId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetTopUpDetailsByDocRef(paymentDocRef, CustomerId).MapToDTO();
            }
        }

        #region Reports
        public List<PropertyDTO> GeAllPersonalizationOrderType()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GeAllPersonalizationOrderType().ToDTOs();
            }
        }

        public List<PropertyDTO> GeAllPersonaliztionOrderStatus()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GeAllPersonaliztionOrderStatus().ToDTOs();
            }
        }

        public List<PropertyDTO> GeAllDepots()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GeAllDepots().ToDTOs();
            }
        }

        public List<PropertyDTO> GeAllWorkOrderTypes()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GeAllWorkOrderTypes().ToDTOs();
            }
        }

        public List<PropertyDTO> GetAllInvoiceStatus()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetAllInvoiceStatus().ToDTOs();
            }
        }

        public List<PropertyDTO> GetAllRefundMethods()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetAllRefundMethods().ToDTOs();
            }
        }

        public List<PropertyDTO> GetAllEPICallTypes()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetAllEPICallTypes().ToDTOs();
            }
        }

        public List<PropertyDTO> GetAllTransactionTypes()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetAllTransactionTypes().ToDTOs();
            }
        }
        public List<PropertyDTO> GetAllBeneficiaryGroups()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetAllBeneficiaryGroups().ToDTOs();
            }
        }
        public BillToDetailsDTO GetBillToDetails(string arcustomerno)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetBillToDetails(arcustomerno).ToDTO();
            }
        }
        #endregion
        public void GetCustomerAvailableCreditLimit(int CustomerId, out decimal availCreditLimit)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                repository.GetCustomerAvailableCreditLimit(CustomerId, out availCreditLimit);
            }
        }
        public bool IsCustomerPendingRefundRequestExists(int CustomerId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.IsCustomerPendingRefundRequestExists(CustomerId);
            }
        }
        public List<SearchVoucherTransactionDTO> SearchVoucherTransaction(int? StationID, int? ReceiptNo, DateTime? fromDate, DateTime? toDate, string VoucherSerialNo, string CustomerNo, int? VoucherID,
            string TransReferenceNo, string FinancialAccountName, string SiteName, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                var result = repository.SearchVoucherTransaction(StationID, ReceiptNo, fromDate, toDate, VoucherSerialNo, CustomerNo, VoucherID, TransReferenceNo,
                    FinancialAccountName, SiteName, pageNo, pageSize, out rowCount).ToDTOs();
                return result;
            }
        }

        public bool TransactionEXTVoucherMAPIU(string VoucherNo, string VoucherSerialNo, string VatInvoiceNo, int LastUpdatedUserID, int LastLocationID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.TransactionEXTVoucherMAPIU(VoucherNo, VoucherSerialNo, VatInvoiceNo, LastUpdatedUserID, LastLocationID);
            }
        }

        public List<VoucherTransactionMapDTO> ExternalVoucherTRX_AUDIT(DateTime? fromDate, DateTime? toDate, int? LastUpdatedUserID, int? LastLocationID, string OperationName,
          int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.ExternalVoucherTRX_AUDIT(fromDate, toDate, LastUpdatedUserID, LastLocationID, OperationName, pageNo, pageSize, out rowCount).ToDTOs();
            }
        }
        public List<ProductServiceBillingTypeDTO> GetProductServiceBillingType()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetProductServiceBillingType().ToDTOs();
            }
        }

        public List<ProductServiceBillingFrequencyDTO> GetProductServiceBillingFrequency(int? CustomerId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                return repository.GetProductServiceBillingFrequency(CustomerId).ToDTOs();
            }
        }
        public int UpdateProductServiceBillingFrequency(int? CustomerId, List<ProductServiceBillingFrequencyDTO> Dtos, int? LastLocationId, int? lastUpdateduser)
        {

            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CustomerRepository(unitOfWork);
                foreach (var dto in Dtos)
                {
                     repository.UpdateProductServiceBillingFrequency(dto.Id, CustomerId,dto.BillingTypeId,dto.BillingFrequencyId, LastLocationId,lastUpdateduser);
                }
                return 1;
            }
        }


    }
}