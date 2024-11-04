using System;
using System.ServiceModel;
using System.Collections.Generic;
using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.BLL.DTO;


namespace DUC.CMS.CustomerService.Service
{
    [ServiceContract]
    interface ICustomerService
    {
        #region Customer

        [OperationContract(Name = "GetAllEmiratesByCountryID")]
        [FaultContract(typeof(CustomerFault))]
        List<PropertyDTO> GetAllEmirates(int countryID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<PropertyDTO> GetAvailableCustomerContatcType(int customerId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<CityDTO> GetAllEmirates();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<AreaDTO> GetAllAreas();

        [OperationContract(Name = "GetAllAreasByCityID")]
        [FaultContract(typeof(CustomerFault))]
        List<AreaDTO> GetAllAreas(int emirateID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<NationalityDTO> GetAllNationality();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<IdentificationTypeDTO> GetIdentitificationTypes();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<CardCenterDTO> GetAllCardCentres();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<CardCenterDTO> GetAllCardCentresForIdentity();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<CardCenterDTO> GetAllCardCentresForNonIdentity();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<CustomerStatusDTO> GetAllCustomerStatus();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<StatusReasonDTO> GetAllCustomerStatusReasons(int statusID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        CustomerARDTO GetCustomerInformation(string financialAccountNumber);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int UpdateCustomerInfo(CustomerDTO customerDto);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int UpdateCustomerInformation(CustomerDTO customerDto, List<CustomerAttachmentDTO> CustomerAttachments);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<CustomerClassificationDTO> GetCustomerClassification();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<ProductDTO> GetAllProduct(int? productCategoryID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool UpdateUpliftDiscountProduct(int customerID, int UpliftID, BaseDTO Audit);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<UpliftDiscountDTO> GetAllUpliftDiscountProducts(int customerId);

        [OperationContract(Name = "GetAllCustomerGroupsForCustomer")]
        [FaultContract(typeof(CustomerFault))]
        List<CustomerGroupDTO> GetAllCustomerGroups(int customerId, string groupName);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool UpdateCustomerGroup(CustomerGroupDTO dto);

        [OperationContract]
        bool IsCustomerGroupInUse(int customerId, int customerGroupId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool DeleteCustomerGroup(CustomerGroupDTO dto);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<CustomerSearchDTO> SearchCustomerInfo(CustomerSearchDTO dto, int pageNo, int pageSize, out int rowCount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<CustomerSearchDTO> SearchCustomerForClosure(CustomerSearchDTO dto, int pageNo, int pageSize, out int rowCount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<CustomerSearchDTO> SearchCustomerforPayment(CustomerSearchDTO dto, int pageNo, int pageSize, int IsRefund, out int rowCount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        DebitCreditRequestDTO ViewCreditDebitRequest(int P_REQUESTID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        RefundRequestDTO ViewRefundRequest(int P_REQUESTID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        VoucherRequestDTO ViewVoucherRequest(int P_REQUESTID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<CustomerAccountTypeDTO> GetAllAccountTypes();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool UpdateBeneficiaryGroupInfo(List<CustomerBeneficiaryGroupDTO> dto);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<CustomerStatusHistoryDTO> GetCustomerStatusHistory(int customerId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool UpdateCustomerStatus(CustomerStatusDTO dto);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool UpdateCustomerPIN(int customerId, int contactTypeId, string PIN, BaseDTO Audit);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool SubmitSMSRequest(SMSMessageDTO dto);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<CustomerBeneficiarySearchDTO> SearchCustomerBeneficiary(CustomerBeneficiarySearchDTO dto, int pageNo, int pageSize, out int rowCount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<PaymentMethodDTO> GetAllPaymentMethods();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool AddPayment(CustomerPaymentTransactionDTO dto);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<CustomerPaymentDTO> GetPaymentHistory(int customerId, int pageNo, int pageSize, out int rowCount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        CustomerPaymentDTO GetCustomerPaymentByPaymentID(int PaymentID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        CustomerBalanceDTO GetCustomerBalance(int customerId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        DateTime? GetMinCutomerTransactionDate(int customerId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<AccountBalanceDTO> GetAccountBalance(int customerId, DateTime FromDate, DateTime ToDate, int pageNo, int pageSize, out int rowCount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<TransactionSearchDTO> GetCustomerTransactions(TransactionSearchDTO dto, int pageNo, int pageSize, out int rowCount, out decimal PaidAmountSum, out decimal AdjustmentAmountSum, out decimal TotalAmountSum, out decimal PaidVATSum);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<TransactionSearchInvDTO> TransactionSearchInv(TransactionSearchInvDTO dto, int pageNo, int pageSize, out int rowCount,
            out decimal PaidAmountSum, out decimal AdjustmentAmountSum, out decimal TotalAmountSum, out decimal TotalVAT);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        CustomerBillingDTO GetCustomerBillingInfo(int customerId, string invoiceNumber);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<CustomerUnBilledDTO> GetCustomerUnBilledInfo(int customerId, string VATInvoiceNum, int pageNo, int pageSize, out int rowCount,
            out decimal PaidAmountSum, out decimal AdjustmentAmountSum, out decimal TotalAmountSum, out decimal TotalVatAmount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        EmployeeHRDTO GetHREmployeeData(int employeeNumber);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int IsEmployeeCardAlreadyIssued(int employeeID, int CustomerID, out string cardSerialNo);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int UpdateIdentityCardInfo(EmployeeIdentityCardDTO dto);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<CustomerBillingDateDTO> GetCustomerBillingDates(int customerId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<CustomerBillingPeriodDTO> GetCustomerBillingPeriod(int customerId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<CustomerBillingSearchDTO> SearchCustomerBilling(CustomerBillingSearchDTO searchCriteria, int pageNo, int pageSize, out int rowCount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<CustomerGroupDTO> GetCustomerGroupById(int groupID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool DeleteUpliftDiscountProduct(int customerID, int UpliftID, BaseDTO Audit);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        CustomerDTO GetCustomerInfo(int customerID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        IdentityCardDTO GetIdentityCardInfo(int employeeNumber, int CustomerID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<CustomerStatusDTO> GetAllCustomerStatusByID(int customerID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        CustomerTransactionDTO GetTransactionSummary(int customerID, int? beneficiaryID, DateTime? fromDate, DateTime? toDate);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        CustomerTransactionDTO GetTransactionSummaryInv(int customerID, int invoiceID, int? beneficiaryID, DateTime? fromDate, DateTime? toDate);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<CustomerAccountTypeDTO> GetAllCustomerAccountTypes();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.CustomerService.BLL.Dtos.ProductDTO> GetAllProductForDifferentialPricing(int customerID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<UpliftDiscountDTO> GetAllUpliftDiscountsForProduct(int productID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool DeleteCustomerDriverCard(int paymentTokenID, int driverCardTokenID, int UserID, DateTime LastUpdatedDate, int LocationId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<MappedDriverDTO> GetAllCustomerDriverCardForToken(int PaymentTokenID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool HasModulePrivilege(string userName, Modules module);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool HasPagePrivilege(string userName, Pages page);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool HasFunctionPrivilege(string userName, Functions function);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool SubmitEmailRequest(EmailDTO dto);

        //[OperationContract]
        //[FaultContract(typeof(CustomerFault))]
        //NotificationMessageDto GetNotificationMessageByCode(string NotificationMsgCode);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int GetMinimumAccountActivationBalance();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        Functions[] GetPrivilegedFunctionsForPage(string UserName, int PageID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IsRefundAllowedForCustomer(int customer_id);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int GetCustomerInvoicePreference(int customerID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool AddCustomerInvoicePreference(int CustomerID, int InvoiceTypeID, int UserID, DateTime LastUpdatedDate, int LocationId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool DeleteCustomerInvoicePreference(int Customer_ID, int UserID, DateTime LastUpdatedDate, int LocationId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        CustomerRefundDTO GetCustomerRefundData(string Customer_CODE);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool RefundCustomer(int Customer_ID, string docRef, string Remarks, BaseDTO Audit, decimal RefundAmount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int CreateWorkflowInstance(int RequestID, int RequestTypeID, int CurrentUserID, int Location_id);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IsRequestIDValidforAssignedUser(List<int> RequestsIDs, int AssignedUserid, int Mode, out List<int> InvalidIdsList);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IsRequestPendingForCustomerOrToken(int customerId, int? TokenId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool TerminatePendingRequests(int customerId, int? TokenId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int GetpreviousWorkflowHistoryInstance(int InstanceID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool AddAccountRequestWFHistory(RequestWFHistoryCustomerDTO dto);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool AddWorkOrderRequestWFHistory(RequestWFHistoryWorkOrderDTO dto);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool AddPersonalizationRequestWFHistory(RequestWFHistoryPersonalizationDTO dto);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool UploadRequestWFHistoryAttachment(List<RequestWFHistoryAttachmentDTO> dto);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool RemoveRequestWFHistoryAttachment(List<RequestWFHistoryAttachmentDTO> dto);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        RequestWFHistoryCustomerDTO ViewAccountRequestWFHistory(int WFInstanceID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        RequestWFHistoryWorkOrderDTO ViewWorkOrderRequestWFHistory(int WFInstanceID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        RequestWFHistoryPersonalizationDTO ViewPersonalizationIssueRequestWFHistory(int WFInstanceID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<RequestWFHistoryAttachmentDTO> ViewAllRequestWFHistoryUploadedAttachments(int WFInstanceID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        RequestWFHistoryAttachmentDTO ViewRequestWFHistoryUploadedAttachmentByID(int AttachmentID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int CreateAccountRequest(RequestCustomerDTO DTO);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int CreateNewAccountRequest(RequestCustomerDTO DTO, List<RQSTAttachmentDTO> CustomerAttachments);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int CreateWorkOrderRequest(RequestWorkOrderDTO dto);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int CreatePersonalizationRequest(RequestPersonalizationDTO dto);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<PropertyDTO> GetAllRequestTypes();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<PropertyDTO> GetAllRequestStatus();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<PropertyDTO> GetAllMonthlyVolumes();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<SearchRQSTRequestResultDTO> SearchAgentRequest(SearchRqstRequestDTO searchdto, int pageNo, int pageSize, out int rowCount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<SearchRQSTRequestResultDTO> SearchApproverRequest(SearchRqstRequestDTO searchdto, int ApprovalLevel, int pageNo, int pageSize, out int rowCount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<SearchRQSTRequestResultDTO> SearchRequestHistory(SearchRqstRequestDTO searchdto, int pageNo, int pageSize, out int rowCount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int GetLastWorkFlowInstanceID(int RequestId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int InitiateRequestWorkflow(int WorkFlowInstanceID, int? AssignedUserID, int? AssignedRoleID, int ActionID, string Comments, int CurrentUserid, int LocationID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int ProcessWorkFlowStep(int WorkFlowInstanceID, int? AssignedUserID, int? AssignedRoleID, int ActionID, string Comments, int CurrentUserid, int LocationID, out int IsApprovalComplete);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool RevertWorkFlowStep(int wfInstanceId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<SearchTokenIssuanceResultDTO> SearchTokenIssuance(SearchTokenIssuanceDTO entity, int pageNo, int pageSize, out int rowCount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int GetpreviousWorkFlowInstanceID(int CurrentWorkFlowInstanceID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IsFinalApproverStep(int RequestID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int GenerateAccountClosureRequest(int CustomerID, int UserID, DateTime LastUpdatedDate, int LocationID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int AddCreditDebitRQST(int CustomerID, int p_PAYMENT_TYPE_ID, decimal p_TRANSACTION_AMOUNT, int p_PAYMENT_METHOD_ID, string p_REMARKS, int UserID, int LocationID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int AddRefundRQST(int CustomerID, int p_PAYMENT_TYPE_ID, decimal p_TRANSACTION_AMOUNT, int p_PAYMENT_METHOD_ID, string p_REMARKS, int UserID, int LocationID, int RefundTypeID, string paymentDOCRef, string BankName, string AccountHolderName, string AccountNumber, string IBANNumber, int? CountryId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int UpdateRefundRQST(int RequestID, string p_REMARKS, int UserID, int LocationID, decimal TransactionAmount, int RefundTypeID, string paymentDOCRef, string BankName, string AccountHolderName, string AccountNumber, string IBANNumber, int? CountryId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int AddVoucherRQST(int CustomerID, DateTime p_VALIDITY_START_DATE, DateTime p_VALIDITY_END_DATE, int? p_VALIDITY_TYPE_ID, int? p_VOUCHER_TYPE_ID,
            decimal? p_AMOUNT, string p_REMARKS, decimal? p_IS_NOTIFIED, decimal? p_IS_LOYALTY_VOUCHER, decimal? p_IS_ACTIVE, int UserID, int LocationID,
            string p_ALLOWEDPRODUCTIDS, int p_QUANTITY);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        RequestWorkflowHistoryDTO ViewRequestWorkflowHistory(int RequestID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<SearchRequestResultDTO> SearchRequest(SearchRequestDTO dto, int? ModuleID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool UpdateRequestStatus(int RequestID, int RequestStatusID, string CustomerCode, string Remarks, int UserID, int LocationID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        RequestCustomerDTO ViewAccountRequest(int RequestID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        string GetRequestCode(int requestID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        RequestDTO GetRequestById(int requestID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        RequestWorkOrderDTO ViewWorkOrderRequest(int RequestID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        RequestPersonalizationDTO ViewPersonalizationIssueRequest(int RequestID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        RequestAccountClosureDTO ViewAccountClosureRequest(int RequestID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<RequestDocumentDTO> GetRequestDocuments(int RequestTypeID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<RQSTAttachementDTO> ViewAllRequestUploadedAttachments(int requestID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        RQSTAttachementDTO ViewRequestUploadedAttachmentByID(int AttachmentID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool UploadAttachment(List<CustomerAttachmentDTO> entity);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool UploadRequestAttachment(List<RQSTAttachmentDTO> entity);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        CustomerAttachmentDTO ViewCustomerAttachmentByID(int AttachmentID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<CustomerAttachmentDTO> GetAllCustomerAttachments(int CustomerID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool AddTerminationPendingCustomer(int customerID, int UserID, DateTime LastUpdatedDate, int LocationId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool AddServiceTransaction(int ServiceID, int CustomerID, int? BeneficiaryID, int? TokenID, int UserId, int LastUpdatedUserID, DateTime LastUpdatedDate, int LastLocationID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<FeeCustomerPaymentTransactionDTO> GetCreditDebitNoteHistory(int CustomerID, int PageID, int PageSize, out int RowCount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        string GetOrderNumber(int TokenID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<ProductDTO> GetAllNonDieselProducts();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        PropertyDTO GetCurrentCustomerStatus(int CustomerID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        RequestServiceFeeDTO ViewServiceFeeRequest(int RequestID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool UpdateServiceFee(ServiceFeeDTO entity);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IsRenewalRequest(int TokenID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool RemoveAttachment(CustomerAttachmentDTO dto);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IsIDAlreadyRegistered(int Mode, int IDType, string IDNumber, int? CUSTOMERID, int? BeneficiaryID, out string pMessage);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<PropertyDTO> GetAllFamily();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        OpeningClosingBalanceDTO GetOpeningClosingBalance(int CustomerID, DateTime FromDate, DateTime ToDate);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<PaymentTypeDTO> GetCreditDebitPaymentTypes();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int GetDieselProductID();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int IsDieselRestricted(int tokenID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<LocationDTO> GetAllCMSLocations();

        //F326
        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool UpdateCeilingLimit(int CeilingLimitID, decimal LimitValue, int UserId, int LocationId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        CeilingLimitDTO GetCeilingLimit();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DictionaryDTO> GetAllGLCostCentre();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool TerminateCustomer(int customerID, int UserId, int LocationID, out int RefundAmount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        DictionaryDTO GetYearByID(int yearID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IsPremierAccessGranted(int userID);


        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IsUpdateVehicleInfoGranted(int userID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IsViewAuditGranted(int userID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        NotificationMessageDto GetNotificationMessageByCode(string MessageCode);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int GetTerminationCutOffPeriod();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IsCustomerCodeValid(string code);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool CancelWorkOrder(int WorkOrderID, int LastLocationId, int LastUserID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool CancelPersonalizationOrder(int PersonalizaionOrderID, int LastLocationId, int LastUserID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        OrderCancellationDTO GetDetailsForPersonalizationCancellation(int PersonalizationID, int pToekenID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        OrderCancellationDTO GetDetailsForWorkOrderCancellation(int WorkOrderID, int pToekenID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        string GetFullNationality(string Code);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<CustomerQuotaDTO> GetCustomerQuota(int CustomerId, int? ProductId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        CustomerQuotaDTO GetAccountQuotaByQuotaId(int QuotaId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int GetNationalityIDByName(string Name);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int GetEmployeeNoForSerial(string SerialNo);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IsTokenSerialAlreadyExist(int? TokenId, string TokenSerial, out string Remark);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool RenewKNPEmployeeCard(int tokenID, string newCardSerial, int UserID, DateTime LastUpdatedDate, int LocationId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int SaveCustomerQuota(int? CustomerQuotaId, int custromerId, int productId, decimal Quota, int userId, int locationId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool DeleteCustomerQuota(int customerId, int productId, int userId, int locationId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        decimal GetCustomerQuotaConsumption(int customerId, int productId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        DUC.CMS.Token.BLL.DTO.TokensToDeliverResultDTO SearchCustomerTokensReadyForDelivery(DUC.CMS.Token.BLL.DTO.SearchTokenToDeliverDTO dto);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool UpdatePushNotification(int BenificaryId, int isPushEnabled, int UserID, int LocationId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int GetPushNotification(int BenificaryId);
        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<PrintReceiptTransDTO> GetPrintReceiptTrans(PrintReceiptTransInputDTO dto, out int rowCount);


        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<TransactionTypeDTO> GetAllTrxTypes();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<BillingFrequencyDTO> GetAllBillingFrequency();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool ISBeneficiaryCreationAllowed(int? CustomerId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        PrintReceiptDataDTO GetAccountReceiptData(int? CustomerId, int? TransactionId, int? PaymentTypeId, string TransactionType);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool RestrictionGroupTransaction(Nullable<decimal> MaximumTransactionAmount,
           int? IsActive, int? LastUpdatedUserId,
           Nullable<System.DateTime> LastUpdatedDate, int? LastLocationID,
           int? IsDry, int? ProductCategoryID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool RestrictionGroupStation(int? RSGRPID, int? StationID,
            int? IsActive, int? LastUpdatedUserId,
           Nullable<System.DateTime> LastUpdatedDate, int? LastLocationID,
            int? IsDry);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool RestrictionGroupAmount(int? RestrictionGroupID, int? TimeFrequencyID,
          Nullable<decimal> AllowedAmount, int? IsActive, int? LastUpdatedUserId,
          Nullable<System.DateTime> LastUpdatedDate, int? LastLocationID,
           int? IsDry, int? ProductCategoryID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool RestrictionGroupTransactionNo(int? RestrictionGroupID, int? NumberOfDays,
            int? NumberOfTransactions, int? TimeFrequencyID, int? IsActive,
            int? LastUpdatedUserId, Nullable<System.DateTime> LastUpdatedDate,
            int? LastLocationID, int? IsDry,
            int? ProductCategoryID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<TransactionProductDTO> GetAllTransactionProducts();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<ProductCategoryDTO> GetAllProductCategories();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<CategoryDTO> ProductCategorySA();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<SearchPendingRequestResultDTO> SearchPendingRequest(SearchRqstRequestDTO searchdto, int pageNo, int pageSize, out int rowCount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<SearchEscalatedRequestResultDTO> SearchEscalatedRequest(SearchRqstRequestDTO searchdto, int pageNo, int pageSize, out int rowCount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int ProcessEscalationRequest(int WorkFlowInstanceID, int RequestId, string Comments, int CurrentUserid, int LocationID, int? EscalatedUserTo, int? EscalteRoleId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int ISCompanyRegistrationIDUnique(int? CustomerID, int? RequestCustomerID, string CompanyID, out int Response);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        BillToDetailsDTO GetBillToDetails(string arcustomerNo);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        void ValidateDuplicateMobileNumber(string mobileNumber, int? customerID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int GetBeneficiaryCount(int? CustomerId);
        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        DUC.CMS.Token.BLL.DTO.VehicleDummyInfoDTO GetDummyVehicleInfo(string vehicleTypeCode, string plateNumber);
        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int SaveMOIVehicleRegister(DUC.CMS.Token.BLL.DTO.VehicleRegisterSearchResultDTO dto, int UserId, int LocationId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool CheckNationalIDExistForIndPrepaid(string NationalID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IsTransactionReversalGranted(int userID);

        /// <summary>
        /// Search for all for the transaction which can be reversed
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<TransactionReversalDTO> SearchTransactionForReversal(TransactionReversalSearchDTO dto, int pageNo, int pageSize, out int rowCount);


        /// <summary>
        /// Check whether the given transaction can be reversed or not
        /// </summary>
        /// <param name="transactionDetailID"></param>
        /// <param name="currentUserid"></param>
        /// <param name="locationID"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool Reverse_Transaction(bool isPayment, int transactionDetailID, DateTime reverseDate, int currentUserid, int locationID);

        /// <summary>
        /// Get the list of all reversed transaction
        /// </summary>
        /// <param name="transactionDetailID"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<TransactionReversalDTO> ViewReversedTransaction(bool isPayment, int transactionDetailID);

        #endregion

        #region Beneficiary

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Beneficiary.BLL.DTO.StatusDTO> GetAllBeneficiaryStatus();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Beneficiary.BLL.DTO.StatusDTO> GetAllBeneficiaryStatusByID(int beneficiaryID);

        [OperationContract]
        List<DUC.CMS.Beneficiary.BLL.DTO.StatusReasonDTO> GetAllBeneficiaryStatusReasons(int statusID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Beneficiary.BLL.DTO.BeneficiarySearchDTO> SearchBeneficiaries(DUC.CMS.Beneficiary.BLL.DTO.BeneficiarySearchDTO dto, int pageNo, int pageSize, out int rowCount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int UpdateBeneficiaryInfo(DUC.CMS.Beneficiary.BLL.DTO.BeneficiaryDTO BeneficiaryDTO);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool UpdateBeneficiaryPIN(int customerID, int beneficiaryID, string beneficiaryCode, string pinNo, Beneficiary.BLL.DTO.BaseDTO Audit);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        DUC.CMS.Beneficiary.BLL.DTO.BeneficiaryDTO GetBeneficiaryInfo(int beneficiaryID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Beneficiary.BLL.DTO.BeneficiaryStatusHistoryDTO> GetBeneficiaryStatusHistory(int beneficiaryID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool UpdateBeneficiaryStatus(DUC.CMS.Beneficiary.BLL.DTO.BeneficiaryStatusDTO beneficiaryStatusDTO);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Beneficiary.BLL.DTO.TransactionSearchDTO> GetBeneficiaryTransaction(DUC.CMS.Beneficiary.BLL.DTO.TransactionSearchDTO transactionSearchDTO, int pageNo, int pageSize, out int rowCount, out decimal PaidAmountSum, out decimal AdjustmentAmountSum, out decimal TotalAmountSum, out decimal PaidVATSum);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool UpdateBeneficiaryRestriction(BeneficiaryRestrictionInputDTO beneficiaryRestrictionDto);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        BeneficiaryRestrictionResultDTO GetBenenficiaryRestriction(int BeneficiaryId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<MonthDTO> GetAllMonths();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool ValidateTokenRestriction(int TokenId, decimal? DailyAmountLimit, decimal? WeeklyAmountLimit, decimal? MonthlyAmountLimit, decimal? YearlyAmountLimit);

        #endregion

        #region Token

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.PropertyDTO> GetVehicleColorBySourceID(int sourceId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.StationDTO> GetAllStationsWithCoordinates();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.PropertyDTO> GetVehicleKindBySourceAndColor(int sourceId, int Colorid);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<IssuanceLocationLoadDto> GetCardCentreLoad(int cardCentreId, int preferredMonthId, int preferredYear);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<IssuanceLocationLoadDto> GetVehicleDepotLoad(int depotId, int preferredMonthId, int preferredYear);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.StatusReasonDTO> GetAllTokenStatusReasons(int statusID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.StatusDTO> GetAllTokenStatus();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.StatusDTO> GetAllTokenStatusByID(int tokenID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.VehicleMakeDTO> GetAllVehicleMakes();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.VehicleMakeModelDTO> GetAllVehicleModels();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.PropertyDTO> GetAllTokenTypes();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.PropertyDTO> GetCustomerTokenTypes();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        DUC.CMS.Token.BLL.DTO.GetVehicleInfoDTO SearchTrafficVehicleInfo(int EmirateId, int ColorID, string PlateNO, int KindId, int? tokenID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int UpdateTokenInfo(DUC.CMS.Token.BLL.DTO.TokenDTO tokenDTO);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.VehicleRegisterSearchResultDTO> SearchVehicleRegister(int? makeID, int? modelID, int? year, int? CC, int? FUEL_INLET, int? FUEL_CAPACITY, int pageNo, int pageSize, out int rowCount);

        [OperationContract]
        List<DUC.CMS.Token.BLL.DTO.VehicleTypesDTO> GetVehicleTypes();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.VehiclePlateColorDTO> GetVehiclePlateColors();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.TokenRestrictionDTO> GetTokenRestrictionInfo(int tokenID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int UpdateTokenRestriction(DUC.CMS.Token.BLL.DTO.TokenRestrictionDTO tokenRestrictionDTO);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.TokenSearchDTO> SearchToken(DUC.CMS.Token.BLL.DTO.TokenSearchDTO tokenSearchDTO, int pageNo, int pageSize, out int rowCount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.CustomerTokenSearchDTO> CustomerSearchToken(DUC.CMS.Token.BLL.DTO.CustomerTokenSearchDTO tokenSearchDTO, int pageNo, int pageSize, out int rowCount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        DUC.CMS.Token.BLL.DTO.TokenDTO GetTokenInfo(int tokenID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.TokenDTO> GetBatchTokenInfo(int personalizationID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.TokenStatusHistoryDTO> GetTokenStatusHistory(int tokenID, int pageNo, int pageSize, out int rowCount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool UpdateTokenStatus(DUC.CMS.Token.BLL.DTO.TokenStatusDTO tokenStatusDTO);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int UpdateRestrictionGroupProfile(DUC.CMS.Token.BLL.DTO.RestrictionGroupDTO restrictionGroupDTO);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool ChangeTokenBeneficiary(int tokenID, int newCustomerID, int newBeneficiaryID, int UserID, DateTime LastUpdatedDate, int LocationId, out int newTokenID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.BatchTokenDTO> AddBatchTokenInfo(List<DUC.CMS.Token.BLL.DTO.BatchTokenDTO> tokenDTO);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool AddBatchTokenRestriction(List<DUC.CMS.Token.BLL.DTO.TokenRestrictionDTO> tokenRestrictionDTO);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool AddPersonalizationRequest(DUC.CMS.Token.BLL.DTO.IssueTokenDTO issueTokenDTO);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool AddWorkOrderRequest(DUC.CMS.Token.BLL.DTO.WorkOrderDTO workOrderDTO);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IsReplacementIssueRequest(int tokenID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool ReplacePersonalizationOrderRequest(DUC.CMS.Token.BLL.DTO.IssueTokenDTO issueTokenDTO);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool ReplaceWorkOrderRequest(DUC.CMS.Token.BLL.DTO.WorkOrderDTO workOrderDTO);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int IsTokenReplacementPermitted(int tokenID, out string cardSerialNo);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.DictionaryDTO> GetAllCustomerBeneficiaryNames(int customerID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.DictionaryDTO> GetAllRestrictionGroupNames(int? CustomerID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.VehicleDepotDTO> GetAllVehicleDepot();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.RestrictionSummaryDTO> GetRestrictionSummary(int restrictionGroupID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.TimeFrequencyDTO> GetAllTimeFrequency();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.VehicleStateDTO> GetAllVehicleStates();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.UnmappedTokenSearchDTO> SearchUnmappedToken(string beneficiaryName, string tokenName, int customerID, int UserID, int pageNo, int pageSize, out int rowCount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool AddBatchTokenVehicleMap(DUC.CMS.Token.BLL.DTO.BatchTokenVehicleMapDTO dto);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IsTokenDeletionPermitted(int tokenID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IsBeneficiaryDeletionPermitted(int beneficiaryID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool DeleteToken(int tokenID, int UserID, DateTime LastUpdatedDate, int LocationId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool DeleteBeneficiary(int beneficiaryID, DUC.CMS.Beneficiary.BLL.DTO.BaseDTO Audit);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IsNewPINPermitted(string pin, int type, int customerID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.PropertyDTO> GetAllStations();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.PropertyDTO> GetAllStationGroups();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.PropertyDTO> GetAllUngroupedStations();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.PropertyDTO> GetStationByGroup(int groupID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.PropertyDTO> GetAllPersonalizationReasons();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.PropertyDTO> GetAllWorkOrderReasons();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.RestrictionGroupDTO> SearchRestrictionGroupProfile(string restrictionGroupName, int? customerID, int pageNo, int pageSize, out int rowCount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        DUC.CMS.Token.BLL.DTO.RestrictionGroupDTO GetRestrictionGroupById(int restrictionGroupID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool DeleteRestrictionGroupByID(int restrictionGroupID, int UserID, DateTime LastUpdatedDate, int LocationId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool UpdateRestrictionSummary(List<DUC.CMS.Token.BLL.DTO.RestrictionSummaryDTO> dto);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        DUC.CMS.Token.BLL.DTO.PersonalizationOrderDTO GetPersonalizationInfo(int personalizationOrderID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        DUC.CMS.Token.BLL.DTO.WorkOrderDTO GetWorkOrderInfo(int workOrderID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IsValidRechargeAmount(decimal rechargeAmount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.DriverCardDTO> SearchDriverCard(DUC.CMS.Token.BLL.DTO.DriverCardSearchDTO dto, int pageNo, int pageSize, out int rowCount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool MapCustomerDriverCard(int paymentTokenID, List<Token.BLL.DTO.DriverCardDTO> DriversList);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool RenewEmirateID(int tokenID, string newCardSerial, DateTime ExpiryDate, int UserID, DateTime LastUpdatedDate, int LocationId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<Token.BLL.DTO.ProductDTO> GetAllProductsForToken(int tokenID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.TokenSearchDTO> SearchNonTerminatedTokens(DUC.CMS.Token.BLL.DTO.TokenSearchDTO tokenSearchDTO, int pageNo, int pageSize, out int rowCount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int LoginUser(string userName);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.TokenSearchDTO> SearchRestrictedToken(DUC.CMS.Token.BLL.DTO.TokenSearchDTO dto, int pageNo, int pageSize, out int rowCount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        string GenerateDriverCardName(int CustomerID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        string GenerateTokenName(int CustomerID, int BeneficiaryID, int TokenTypeID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        string GetCustomerCodeByID(int CustomerID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        string GetBeneficiaryCodeByID(int BeneficiaryID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        string GetTokenCodeByID(int TokenID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IsEmirateIDAlreadyRegistered(string emirateID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IsKNPCCardAlreadyRegistered(string Serial);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.BatchBeneficiaryDTO> AddBatchBeneficiary(List<DUC.CMS.Token.BLL.DTO.BatchBeneficiaryDTO> dtos);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        string[] GenerateBatchTokenName(int customerID, int tokenCount, int tokenTypeID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        DUC.CMS.Token.BLL.DTO.MapCustomerDTO MapSearch(DUC.CMS.Token.BLL.DTO.MapSearchDTO dto);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        DUC.CMS.Token.BLL.DTO.MapCustomerDTO AccountMapSearch(DUC.CMS.Token.BLL.DTO.AccountMapSearchDTO dto, int pageNo, int pageSize, out int rowCount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.TokenSearchDTO> AccountSearchToken(DUC.CMS.Token.BLL.DTO.AccountTokenSearchDTO tokenSearchDTO, int pageNo, int pageSize, out int rowCount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IsRestrictionGroupNameAlreadyExist(string RestrictionGroupName, int? CustomerID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.DriverCardDTO> SearchMappableDriverCard(DUC.CMS.Token.BLL.DTO.DriverCardSearchDTO dto, int pageNo, int pageSize, out int rowCount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IsRestrictionGroupAllowedForToken(int TokenTypeID, int RestrictionGroupID, out string Message);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        Pages[] GetPrivilegedPagesForModule(string UserName, Modules module);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IsRestrictionGroupInUse(int RestrictionGroupID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.StatusDTO> GetAllDriverCardStatus();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.DriverCardDTO> SearchNonTerminatedDriverCard(DUC.CMS.Token.BLL.DTO.DriverCardSearchDTO dto, int pageNo, int pageSize, out int rowCount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.VehicleModelDTO> GetVehicleModelsByMake(int makeID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        DUC.CMS.Token.BLL.DTO.VehicleInfoDTO GetVehicleInfoByID(int vehicleInfoID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        DUC.CMS.Token.BLL.DTO.TimeFrequencyDTO GetTimeFrequencyByID(int timeFrequencyId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int UpdateVehicleInfo(DUC.CMS.Token.BLL.DTO.VehicleInfoDTO entity);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IsRestrictionExistForBeneficiaryToken(int beneficiary_id);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool RemoveRestrictionForBeneficiaryToken(int beneficiary_id, int UserID, DateTime LastUpdatedDate, int LocationId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool UpdateTokenDeliveredStatus(int token_id, int UserID, DateTime LastUpdatedDate, int LocationId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.TokenTypeDTO> GetAllPersonalizationTokenTypes();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool RemoveRestrictionForCustomerToken(int customer_id, int UserID, DateTime LastUpdatedDate, int LocationId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        DUC.CMS.Token.BLL.DTO.CurrencyDTO GetCurrency();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IsTokenRestrictionExistForCustomerTokens(int customer_id, int? BenenficiaryId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.TokenToDeliverDTO> SearchTokensReadyForDelivery(DUC.CMS.Token.BLL.DTO.SearchTokenToDeliverDTO dto, out int totalCount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.WorkOrderTypeDTO> GetAllWorkOrderTypes();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.WorkOrderStatusDTO> GetAllWorkOrderStatus();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.PersonalizationOrderStatusDTO> GetAllPersonalizationOrderStatus();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.DictionaryDTO> GetAllActiveBeneficiaryNames(int customerID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IsVehicleChassisAlreadyRegistered(string ChassisNumber, int? TokenID, out string TokenCode);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IsVehicleDetailsAlreadyRegistered(string PlateNumber, int PlateColorID, int VehicleEmirateID, int VehicleTypeID, int? TokenID, int TokenTypeID, out string TokenCode);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.PersonalizationOrderTypesDTO> GetAllPersonalizationOrderTypes();

        //F331
        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IsTokenBelongingToBatch(int tokenId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IsTokenCustomExpiryApplied(int TokenId);



        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int SetTokenUsedAmount(UsedTokenAmountDTO usedTokenAmountDTO);


        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IsZeroTransactionToken(int tokenId);



        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool hasAddTokenUsedBalanceGranted(int UserID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        decimal GetTokenAmount(int TokenId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IsVehicleChassisAlreadyExists(string ChassisNumber, int? TokenID, int TokenTypeID, out string TokenCode);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<DUC.CMS.Token.BLL.DTO.ConsumedAmountResultDTO> GetConsumedAmount(int restrictionGroupID);
        #endregion

        #region Logging

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool LogException(string Message, string StackTrace, string InnerException);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool LogDetailedException(string Message, string StackTrace, string InnerException, string pagename, string functionname, int? customerid, int? beneficiaryId, int? tokenID);
        #endregion

        #region DummyMethodForEnumeration

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        void DummyEnumerationMethod(NotificationLanguages notificationLanguages, NotificationPreferences notificationPreferences, ReceiptTypes receiptTypes,
            InvoiceTypes invoiceTypes, PaymentType paymentType, PaymentMethod PaymentMethod, TokenType tokenType, CustomerStatus cusStatus,
            BeneficiaryStatus benStatus, TokenStatus tokenStatus, Modules modules, Pages pages, Functions functions, RequestTypes requestType,
            RequestStatus requestStatus, ServiceNames ServiceNames, WorkFlowAction WorkFlowAction, WorkFlowStatus WorkFlowstatus, Approverlevel Approverlevel,
            ContactType contactType, FuelInlet _FuelInlet, ProductCategory productCategory);

        #endregion

        #region ERP



        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<FinanceIdDTO> GetNonRegisteredERPAccounts();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<FinanceIdDTO> GetRegisteredERPAccounts();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<FinanceIdDTO> GetAllSIteIDForERPAccount(int? FinancialID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<FinanceIdDTO> GetNonRegisteredSIteIDForERPAccount(int FinancialID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<FinanceIdDTO> GetRegisteredSIteIDForERPAccount(int FinancialID);


        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IssueToken(int TokenID, string Serial, string SecondSerial, string ThirdSerial, int UserID, int LocationId, int Mode, int IsFeeWaivedOff);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<FinanceIdDTO> GetNonRegisteredIndAccounts();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<RefundTypeDTO> GetAllRefundTypes();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        CustomerPaymentDTO GetTopUpDetailsByDocRef(string paymentDocRef, int? CustomerId);

        #endregion

        #region Reports
        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<PropertyDTO> GetAllPersonalizationOrderType();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<PropertyDTO> GetAllPersonaliztionOrderStatus();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<PropertyDTO> GetAllDepots();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<PropertyDTO> GetAllWorkOrdersTypes();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<PropertyDTO> GetAllInvoiceStatus();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<PropertyDTO> GetAllRefundMethods();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<PropertyDTO> GetAllEPICallTypes();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<PropertyDTO> GetAllTransactionTypes();

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<PropertyDTO> GetAllBeneficiaryGroups();
        #endregion

        #region EXTERNALVOUCHER

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<SearchVoucherTransactionDTO> SearchVoucherTransaction(int? StationID, int? ReceiptNo, DateTime? fromDate, DateTime? toDate, string VoucherSerialNo,
            string CustomerNo, int? VoucherID, string TransReferenceNo, string FinancialAccountName, string SiteName, int pageNo, int pageSize, out int rowCount);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool TransactionEXTVoucherMAPIU(string VoucherNo, string VoucherSerialNo, string VatInvoiceNo, int LastUpdatedUserID, int LastLocationID);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<VoucherTransactionMapDTO> ExternalVoucherTRX_AUDIT(string OperationName, Nullable<DateTime> fromDate, Nullable<DateTime> toDate, int? LastUpdatedUserID, int? LastLocationID,
         int pageNo, int pageSize, out int rowCount);

        #endregion

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<PropertyDTO> GetAllNotificationPreferences();
        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        decimal GetCustomerAvailableCreditLimit(int CustomerId);
        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        bool IsCustomerPendingRefundRequestExists(int CustomerId);
        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<Token.BLL.DTO.BatchTokenDTODetails> AddBatchTokenDetails(int CustomerId, List<Token.BLL.DTO.BatchTokenDTODetails> batchTokenDTOs);
        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<ProductServiceBillingTypeDTO> GetProductServiceBillingType();



        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        List<ProductServiceBillingFrequencyDTO> GetProductServiceBillingFrequency(int? CustomerId);

        [OperationContract]
        [FaultContract(typeof(CustomerFault))]
        int UpdateProductServiceBillingFrequency(int? CustomerId, List<ProductServiceBillingFrequencyDTO> Dtos, int? LastLocationId, int? lastUpdateduser);
    }

}
