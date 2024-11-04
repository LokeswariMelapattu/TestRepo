
using System;
using System.ServiceModel;
using System.Configuration;
using System.Collections.Generic;
using System.Data.Metadata.Edm;
using DUC.CMS.CustomerService.BLL;
using DUC.CMS.CustomerService.BLL.Dtos;
using DUC.CMS.CustomerService.EventLogger.Interfaces;
using System.Runtime.Serialization;
using DUC.CMS.CustomerService.BLL.DTO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DUC.CMS.CustomerService.Service
{
    #region Enumerations

    public enum FuelInlet
    {
        Single = 0,
        Dual = 1,
        Triple = 2
    }


    public enum WorkFlowAction
    {
        Pending = 0,
        Accepted = 1,
        Rejected = 2
    }
    public enum Approverlevel
    {
        Initial = 0,

        Final = 1,
        Management = 2
    }
    public enum WorkFlowStatus
    {
        Submitted = 0,
        Initiated = 1,
        Inprogress = 2,
        Completed = 3
    }
    public enum NotificationLanguages
    {
        Arabic = 0,
        English = 1
    }

    public enum NotificationPreferences
    {
        SMS = 0,
        Email = 1
    }

    public enum ReceiptTypes
    {
        SMS = 0,
        Printed = 1,
        Both = 2
    }

    public enum InvoiceTypes
    {
        Online = 0,
        Posted = 1,
        Both = 2
    }

    public enum PaymentType
    {
        InvoiceParialPayment = 0,
        InvoicePayment = 1,
        TopUp = 2,
        Refund = 3,
        ServiceFee = 4,
        CreditNote = 5,
        DebitNote = 6
    }

    public enum PaymentMethod
    {
        Cash = 0,
        CreditCard = 1,
        PLC = 2,
        VehicleTag = 3,
        EmiratesID = 4,
        MobileApp = 5,
        creditDebit = 6
    }

    public enum TokenType
    {
        PLC = 0,
        VehicleTag = 1,
        EmiratesID = 2,
        MobileApp = 3,
        DriverCard = 4,
        IdentityCard = 5,
        KNPCEmployeeCard = 6,
        VehiclePlate = 8
    }

    public enum CustomerStatus
    {
        PendingActivation = 0,
        Active = 1,
        Suspended = 2,
        Terminated = 3,
        PaymentSuspended = 4,
        SystemSuspended = 5
    }

    public enum BeneficiaryStatus
    {
        PendingActivation = 0,
        Active = 1,
        Suspended = 2,
        Terminated = 3,
        PaymentSuspended = 4,
        SystemSuspended = 5
    }
    public enum ContactType
    {
        Operational = 0,
        Financial = 1,
        Both = 2
    }

    public enum TokenStatus
    {
        Created = 0,
        AppointmentScheduled = 2,
        PrintedOrInstalled = 3,
        QCPassed = 4,
        ReadyForDelivery = 5,
        PaymentSuspended = 6,
        PendingActivation = 7,
        Active = 8,
        Suspended = 9,
        Terminated = 10,
        AutoSuspended = 11,
        SystemSuspended = 12,
        Expired = 13
    }

    public enum ProductCategory
    {
        Fuelling = 0,
        CStore = 1,
        CarWash = 2,
        Lube = 3,
        Accessories = 4,
        LPG = 5
    }

    [DataContract]
    public enum Modules
    {
        [EnumMember]
        Inventory = 0,
        [EnumMember]
        SystemSettings = 1,
        [EnumMember]
        SystemSecurity = 2,
        [EnumMember]
        AccountMasterData = 3,
        [EnumMember]
        ManageAccounts = 4,
        [EnumMember]
        CPS = 5,
        [EnumMember]
        Notifications = 6,
        [EnumMember]
        Reports = 7,
        [EnumMember]
        TagDepot = 8,
        [EnumMember]
        RequestManagement = 9,
        [EnumMember]
        DifferentialPricing = 10,
        [EnumMember]
        PreprintedVoucher = 11,
        [EnumMember]
        Loyalty = 12,
        [EnumMember]
        Migration = 13
    }

    [DataContract]
    [Flags]
    public enum Pages
    {
        [EnumMember]
        Locations = 0,
        [EnumMember]
        SearchUnitMovement = 1,
        [EnumMember]
        MoveUnits = 2,
        [EnumMember]
        ReceiveFromVendor = 3,
        [EnumMember]
        ReturnToVendor = 4,
        [EnumMember]
        SearchUnitStatus = 5,
        [EnumMember]
        UnitDisposal = 6,
        [EnumMember]
        UnitTypes = 7,
        [EnumMember]
        UnitStatus = 8,
        [EnumMember]
        BeneficiaryStatusReason = 9,
        [EnumMember]
        CustomerStatusReason = 10,
        [EnumMember]
        Families = 11,
        [EnumMember]
        RechargeSettings = 12,
        [EnumMember]
        Services = 13,
        [EnumMember]
        TokenStatusReason = 14,
        [EnumMember]
        VehicleMakes = 15,
        [EnumMember]
        VehicleModels = 16,
        [EnumMember]
        VehicleRegister = 17,
        [EnumMember]
        DifferentialPricingSettings = 18,
        [EnumMember]
        Currency = 19,
        [EnumMember]
        Holiday = 20,
        [EnumMember]
        SystemGroupRestrictionSearch = 21,
        [EnumMember]
        SystemRestrictionGroup = 22,
        [EnumMember]
        ManageRole = 23,
        [EnumMember]
        RoleFunctionsMapping = 24,
        [EnumMember]
        RoleUsers = 25,
        [EnumMember]
        Users = 26,
        [EnumMember]
        AccountMasterAccountSearch = 29,
        [EnumMember]
        CustomerAccountType = 30,
        [EnumMember]
        CorporatePostPaidCreate = 31,
        [EnumMember]
        CorporatePrePaidCreate = 32,
        [EnumMember]
        IndividualAccountCreate = 33,
        [EnumMember]
        CorporatePostPaidEditView = 34,
        [EnumMember]
        CorporatePrePaidEditView = 35,
        [EnumMember]
        IndividualAccountEditView = 36,
        [EnumMember]
        AccountSearch = 37,
        [EnumMember]
        AccountExplorer = 38,
        [EnumMember]
        CorporatePostPaidPreferences = 39,
        [EnumMember]
        DifferentialPricingManagment = 40,
        [EnumMember]
        BeneficiaryGroups = 41,
        [EnumMember]
        AccountStatus = 42,
        [EnumMember]
        CustomerPinReset = 43,
        [EnumMember]
        DriverCard = 44,
        [EnumMember]
        DriverCardStatus = 45,
        [EnumMember]
        PostpaidAccountBalanceEnquiry = 46,
        [EnumMember]
        PostpaidBillingSearch = 47,
        [EnumMember]
        BeneficiarySearch = 48,
        [EnumMember]
        Beneficiary = 49,
        [EnumMember]
        BeneficiaryBasicInfo = 50,
        [EnumMember]
        BeneficiaryStatus = 52,
        [EnumMember]
        BeneficiaryPinReset = 53,
        [EnumMember]
        BatchGenerationBeneficiary = 54,
        [EnumMember]
        BatchGenerationToken = 55,
        [EnumMember]
        BatchMapVehicleTag = 56,
        [EnumMember]
        IndividualAccountPreference = 57,
        [EnumMember]
        PrepaidAccountBalanceEnquiry = 58,
        [EnumMember]
        PrepaidAccountPayment = 59,
        [EnumMember]
        DifferentialPricingSearch = 60,
        [EnumMember]
        IdentityCard = 61,
        [EnumMember]
        ADNOCIdentityCardStatusManagementPage = 62,
        [EnumMember]
        CorporatePrepaidPreferences = 63,
        [EnumMember]
        TokenSearchPage = 64,
        [EnumMember]
        NewToken = 65,
        [EnumMember]
        SystemPages = 66,
        [EnumMember]
        SystemModules = 67,
        [EnumMember]
        AccountReports = 68,
        [EnumMember]
        AccountTransaction = 69,
        [EnumMember]
        BeneficiaryTransaction = 70,
        [EnumMember]
        BeneficiaryPreferences = 71,
        [EnumMember]
        Personalization = 72,
        [EnumMember]
        PostpaidBilledDetails = 73,
        [EnumMember]
        TokenStatus = 74,
        [EnumMember]
        TokenIssuance = 75,
        [EnumMember]
        ConfigurationsNotifications = 76,
        [EnumMember]
        EmailNotification = 77,
        [EnumMember]
        EmailNotificationSearch = 78,
        [EnumMember]
        MessageGroup = 79,
        [EnumMember]
        NotificationMessageManagement = 80,
        [EnumMember]
        SmsNotification = 81,
        [EnumMember]
        SmsNotificationSearch = 82,
        [EnumMember]
        CustomerRestrictionGroupSearch = 83,
        [EnumMember]
        CustomerRestrictionGroup = 84,
        [EnumMember]
        TokenRestrictionGroupSearch = 85,
        [EnumMember]
        TokenProfile = 86,
        [EnumMember]
        ChangeTokenBeneficiary = 87,
        [EnumMember]
        PostpaidUnbilledDetails = 88,
        [EnumMember]
        UpdateToken = 89,
        [EnumMember]
        InvoicegenerationReport = 90,
        [EnumMember]
        PrinterQueue = 93,
        [EnumMember]
        ManagePrinter = 95,
        [EnumMember]
        SearchOrders = 96,
        [EnumMember]
        RegisterTokenDelivery = 98,
        [EnumMember]
        RequestManagementSearchRequest = 99,
        [EnumMember]
        RequestForIndividualAccountCreation = 100,
        [EnumMember]
        RequestForCorporatePrepaidAccountCreation102,
        [EnumMember]
        RequestForIndividualAccountClousre = 104,
        [EnumMember]
        RequestForCorporatePrepaidAccountClosure = 105,
        [EnumMember]
        RequestForCorporatePostpaiddAccountClosure = 106,
        [EnumMember]
        PrepaidRefund = 108,
        [EnumMember]
        IndividualRefund = 109,
        [EnumMember]
        DocumentManagement = 110,
        [EnumMember]
        OrderDetails = 111,
        [EnumMember]
        RequestForCorporatePostpaidAccountCreation = 117,
        [EnumMember]
        MasterDataSearchRequest = 118,
        [EnumMember]
        CreditDebit = 121,
        [EnumMember]
        RequestDocument = 122,
        [EnumMember]
        PersonalizationOrders = 123,
        [EnumMember]
        QualityAssurance = 124,
        [EnumMember]
        CeilingLimit = 125,
        [EnumMember]
        WorkOrders = 126,
        [EnumMember]
        TagInstallation = 127,
        [EnumMember]
        TagReplacement = 128,
        [EnumMember]
        TagRemoval = 129,
        [EnumMember]
        DepotQualityAssurance = 130,
        [EnumMember]
        DepotSearchOrder = 131,
        [EnumMember]
        DepotOrderDetails = 132,
        [EnumMember]
        WorkFlowSettings = 133,
        [EnumMember]
        SendUnits = 134,
        [EnumMember]
        NewRequest = 135,
        [EnumMember]
        CreateCorporatePostpaidRequest = 136,
        [EnumMember]
        CreateCorporatePrepaidRequest = 137,
        [EnumMember]
        CreateIndividualPrepaidRequest = 138,
        [EnumMember]
        TokenIssuanceRequest = 139,
        [EnumMember]
        AccountClosureRequest = 140,
        [EnumMember]
        SearchAgentRequest = 141,
        [EnumMember]
        SearchApproverRequest = 142,
        [EnumMember]
        TrackRequestHistory = 143,
        [EnumMember]
        DifferentialPricingRuleSearch = 144,
        [EnumMember]
        DifferentialPricingRuleType = 145,
        [EnumMember]
        OnlineAppliedDifferentialPricingRuleCreate = 146,
        [EnumMember]
        OnlineAppliedDifferentialPricingRuleEdit = 147,
        [EnumMember]
        EomAppliedDifferentialPricingRuleCreate = 148,
        [EnumMember]
        EomAppliedDifferentialPricingRuleEdit = 149,
        [EnumMember]
        MapTokentoRule = 150,
        [EnumMember]
        RequestForPersonalization = 151,
        [EnumMember]
        RequestForWorkOrder = 152,
        [EnumMember]
        BatchBeneficiaryStatus = 153,
        [EnumMember]
        BatchTokenStatus = 154,
        [EnumMember]
        TagRenewal = 155,
        [EnumMember]
        ReportLostToken = 156,
        [EnumMember]
        GlobalSettings = 157,
        [EnumMember]
        Area = 158,
        [EnumMember]
        City = 159,
        [EnumMember]
        BeneficiaryReports = 160,
        [EnumMember]
        TokenReports = 161,
        [EnumMember]
        TransactionLogReports = 162,
        [EnumMember]
        CardCenterReports = 163,
        [EnumMember]
        TagInstallationReports = 164,
        [EnumMember]
        InventoryReports = 165,
        [EnumMember]
        SearchEVoucher = 166,
        [EnumMember]
        SearchPreprintedVoucher = 167,
        [EnumMember]
        BatchPreprintedVoucher = 168,
        [EnumMember]
        EVoucherSettings = 169,
        [EnumMember]
        RequestReports = 170,
        [EnumMember]
        AccountQuota = 171,
        [EnumMember]
        EarningFormula = 172,
        [EnumMember]
        RedemptionFormula = 173,
        [EnumMember]
        SearchAccounts = 174,
        [EnumMember]
        SubscribeAccounts = 175,
        [EnumMember]
        UnsubscribeAccounts = 176,
        [EnumMember]
        SelectAccount = 177,
        [EnumMember]
        PointTransactions = 178,
        [EnumMember]
        RedeemPoints = 179,
        [EnumMember]
        VoucherHistory = 180,
        [EnumMember]
        GlobalTokenDelivery = 181,
        [EnumMember]
        AccountTokenSearch = 182,
        [EnumMember]
        VATSettings = 207,
        [EnumMember]
        TransactionReceipt = 206,
        [EnumMember]
        SearchReceiptTransactions = 205,
        [EnumMember]
        BatchPreprintedVoucherPostPaidCustomer = 208,
        [EnumMember]
        CreditDebitRequest = 213,
        [EnumMember]
        PreprintedVoucherRequest = 214,
        [EnumMember]
        SearchPreprintedVoucherPostPaidCustomer = 209,
        [EnumMember]
        PreprintedVoucherInfo = 210,
        [EnumMember]
        SearchPendingRequest = 211,
        [EnumMember]
        SearchEscalatedRequest = 212,
        [EnumMember]
        RefundRequest = 215,
        [EnumMember]
        IndividualPostPaidCreate = 216,
        [EnumMember]
        IndividualPostPaidEditView = 217,
        [EnumMember]
        IndividualPostPaidPreferences = 218,
        [EnumMember]
        AccountMigrationAccountSearch = 219,
        [EnumMember]
        AccountMigrationReport = 220,
        [EnumMember]
        VehicleInfoMigration = 221,
        [EnumMember]
        CustomReports = 222,
        [EnumMember]
        TransactionReversal = 224,
        [EnumMember]
        Station = 225,
        [EnumMember]
        ProductServiceBilling = 226,
        [EnumMember]
        CustomerProductServiceBilling = 227,
        [EnumMember]
        CreateIndividualPostpaidRequest = 228,
        [EnumMember]
        WhatsAppNotification = 229,
        [EnumMember]
        WhatsAppNotificationSearch = 230,
        [EnumMember]
        ExternalVoucher = 231,

    }

    [DataContract]
    public enum Functions
    {
        [EnumMember]
        SearchExistingAccount = 0,
        [EnumMember]
        AddNewAccount = 1,
        [EnumMember]
        EditExistingAccount = 2,
        [EnumMember]
        ReadCorporatePrepaidAccountBasicInfo = 3,
        [EnumMember]
        UpdateCorporatePrepaidAccountBasicInfo = 4,
        [EnumMember]
        ReadCorporatePrepaidAccountContactInfo = 5,
        [EnumMember]
        UpdateCorporatePrepaidAccountContactInfo = 6,
        [EnumMember]
        ReadIndividualAccountBasicInfo = 7,
        [EnumMember]
        UpdateIndividualAccountBasicInfo = 8,
        [EnumMember]
        ReadIndividualAccountContactInfo = 9,
        [EnumMember]
        UpdateIndividualAccountContactInfo = 10,
        [EnumMember]
        ReadCorpratePostpaidBasicInfo = 11,
        [EnumMember]
        UpdateCorporatePostpaidBasicInfo = 12,
        [EnumMember]
        ReadCorporatePostPaidBillingInfo = 13,
        [EnumMember]
        UpdateCorporatePostPaidBillingInfo = 14,
        [EnumMember]
        ReadCorporatePostpaidAccountContactInfo = 15,
        [EnumMember]
        UpdateCorporatePostPaidAccountContactInfo = 17,
        [EnumMember]
        getPostpaidAccountInfoFromAR = 18,
        [EnumMember]
        AddNewPostPaidAccountBasicInfo = 19,
        [EnumMember]
        AddNewPostpaidAccountBillingInfo = 22,
        [EnumMember]
        AddNewPostpaidAccountContactInfo = 23,
        [EnumMember]
        AddNewCorporatePrePaidAccount = 24,
        [EnumMember]
        AddNewCorporatePrepaidContactInfo = 25,
        [EnumMember]
        AddNewIndividualAccountBasicInfo = 26,
        [EnumMember]
        AddNewIndividualAccountContactInfo = 27,
        [EnumMember]
        SearchAccountExplorer = 30,
        [EnumMember]
        UpdateBeneficiaryBasicInfo = 31,
        [EnumMember]
        ReadBeneficiaryBasicInfo = 32,
        [EnumMember]
        ReadBeneficiaryPreferences = 33,
        [EnumMember]
        UpdateBeneficiaryPreferences = 34,
        [EnumMember]
        ReadBeneficiaryStatusLog = 35,
        [EnumMember]
        UpdateBeneficiaryStatus = 36,
        [EnumMember]
        GenerateBeneficiaryPin = 37,
        [EnumMember]
        AddNewBeneficiaryBasicInfo = 38,
        [EnumMember]
        AddNewBeneficiaryPreferences = 39,
        [EnumMember]
        SearchBeneficiary = 40,
        [EnumMember]
        AddNewBeneficiary = 41,
        [EnumMember]
        UpdateBeneficiary = 42,
        [EnumMember]
        DeleteBeneficiary = 43,
        [EnumMember]
        SearchToken = 44,
        [EnumMember]
        AddNewToken = 45,
        [EnumMember]
        EditToken = 46,
        [EnumMember]
        DeleteToken = 47,
        [EnumMember]
        ReadTokenBasicInfo = 48,
        [EnumMember]
        UpdateTokenBasicInfo = 49,
        [EnumMember]
        AddNewTokenBasicInfo = 50,
        [EnumMember]
        SearchTokenRestriction = 51,
        [EnumMember]
        ReadCustomerRestriction = 52,
        [EnumMember]
        ReadEmiratesID = 53,
        [EnumMember]
        SearchPostpaidAccountBalance = 54,
        [EnumMember]
        TokenReadRestrictionSummary = 58,
        [EnumMember]
        TokenEnableDisableTransactionRestriction = 59,
        [EnumMember]
        AddNewBeneficiaryStatusReason = 100,
        [EnumMember]
        SearchBeneficiaryStatusReasons = 101,
        [EnumMember]
        EditBeneficiaryStatusReasons = 102,
        [EnumMember]
        DeleteBeneficiaryStatusReason = 103,
        [EnumMember]
        AddNewCustomerStatusReason = 105,
        [EnumMember]
        EditCustomerStatusReason = 107,
        [EnumMember]
        DeleteCustomerStatusReason = 108,
        [EnumMember]
        SearchCustomerStatusReason = 109,
        [EnumMember]
        AddNewFamily = 110,
        [EnumMember]
        SearchFamily = 111,
        [EnumMember]
        EditFamily = 112,
        [EnumMember]
        DeleteFamily = 113,
        [EnumMember]
        UpdateRechargeSettings = 114,
        [EnumMember]
        ReadRechargeSettingsLog = 115,
        [EnumMember]
        SearchServices = 116,
        [EnumMember]
        EditServices = 117,
        [EnumMember]
        AddNewTokenStatusReason = 118,
        [EnumMember]
        SearchTokenStatusReason = 119,
        [EnumMember]
        EditTokenStatusReason = 120,
        [EnumMember]
        DeleteTokenStatusReason = 121,
        [EnumMember]
        AddNewVehicleMake = 122,
        [EnumMember]
        SearchVehicleMake = 123,
        [EnumMember]
        EditVehicleMake = 124,
        [EnumMember]
        DeleteVehicleMake = 125,
        [EnumMember]
        AddNewVehicleModel = 126,
        [EnumMember]
        SearchVehicleModel = 127,
        [EnumMember]
        EditVehicleModel = 128,
        [EnumMember]
        DeleteVehicleModel = 129,
        [EnumMember]
        AddNewVehicleRegister = 130,
        [EnumMember]
        SearchVehicleRegister = 131,
        [EnumMember]
        EditVehicleRegister = 132,
        [EnumMember]
        DeleteVehicleRegister = 133,
        [EnumMember]
        AddNewProductUpliftDiscount = 134,
        [EnumMember]
        SearchProductUpliftDiscount = 135,
        [EnumMember]
        EditProductUpliftDiscount = 136,
        [EnumMember]
        DeleteProductUpliftDiscount = 137,
        [EnumMember]
        UpdateSystemCurrency = 138,
        [EnumMember]
        AddNewHoliday = 139,
        [EnumMember]
        SearchHolidays = 140,
        [EnumMember]
        EditHolidays = 141,
        [EnumMember]
        DeleteHoliday = 142,
        [EnumMember]
        SearchTokenRestrictionGroup = 143,
        [EnumMember]
        AddNewTokenRestrictionGroup = 144,
        [EnumMember]
        EditTokenRestrictionGroup = 145,
        [EnumMember]
        DeleteTokenRestrictionGroup = 146,
        [EnumMember]
        UpdateRestrictionGroupInformation = 148,
        [EnumMember]
        ReadTokenTransactionRestriction = 149,
        [EnumMember]
        ReadTokenNoOfAllowedTransactionRestriction = 150,
        [EnumMember]
        UpdateTokenTransactionRestriction = 151,
        [EnumMember]
        ReadTokenAmountRestriction = 152,
        [EnumMember]
        UpdateTokenAmountRestriction = 153,
        [EnumMember]
        ReadTokenProductRestriction = 154,
        [EnumMember]
        ReadTokenQuantityRestriction = 155,
        [EnumMember]
        UpdateTokenProductRestriction = 156,
        [EnumMember]
        ReadTokenStationRestriction = 157,
        [EnumMember]
        UpdateTokenStationRestriction = 158,
        [EnumMember]
        ReadTokenOtherRestriction = 159,
        [EnumMember]
        UpdateTokenOtherRestriction = 160,
        [EnumMember]
        UpdateTokenRestrictionGroup = 161,
        [EnumMember]
        ShowAlldiffrentialPricingRules = 162,
        [EnumMember]
        TokenEnableDisableAmountRestriction = 163,
        [EnumMember]
        TokenEnableDisableProductQuantityRestriction = 164,
        [EnumMember]
        TokenEnableDisableStationRestriction = 165,
        [EnumMember]
        TokenEnableDisableOtherRestriction = 166,
        [EnumMember]
        GetIndividualCustomerRefundInfo = 167,
        [EnumMember]
        RefundIndividualCustomer = 168,
        [EnumMember]
        FromRestrictionGroup = 169,
        [EnumMember]
        CopyFromAnotherToken = 170,
        [EnumMember]
        CustomRestrictionGroup = 171,
        [EnumMember]
        AddNewSystemRestrictionGroup = 172,
        [EnumMember]
        UpdateSystemRestrictionGroupSummary = 173,
        [EnumMember]
        ReadSystemRestrictionGroupInformation = 174,
        [EnumMember]
        UpdateSystemRestrictionGroupInformation = 175,
        [EnumMember]
        ReadSystemTransactionRestriction = 176,
        [EnumMember]
        UpdateSystemTransactionRestriction = 178,
        [EnumMember]
        ReadSystemNoOfAllowedTransactionRestriction = 179,
        [EnumMember]
        ReadSystemAmountRestriction = 180,
        [EnumMember]
        UpdateSystemAmountRestriction = 181,
        [EnumMember]
        ReadSystemProductRestriction = 182,
        [EnumMember]
        UpdateSystemProductRestriction = 183,
        [EnumMember]
        ReadSystemQuantityRestriction = 184,
        [EnumMember]
        ReadSystemStationRestriction = 185,
        [EnumMember]
        UpdateSystemStationRestriction = 186,
        [EnumMember]
        ReadSystemOtherRestriction = 187,
        [EnumMember]
        UpdateSystemOtherRestriction = 188,
        [EnumMember]
        SearchSystemRestrictionGroup = 189,
        [EnumMember]
        EditSystemRestrictionGroup = 190,
        [EnumMember]
        DeleteSystemRestrictionGroup = 191,
        [EnumMember]
        SetDieselQuota = 192,
        [EnumMember]
        CopyFromTemplate = 193,
        [EnumMember]
        SystemEnableDisableTransactionRestriction = 194,
        [EnumMember]
        SystemEnableDisableAmountRestriction = 195,
        [EnumMember]
        SystemEnableDisableProductQuantityRestriction = 196,
        [EnumMember]
        SystemEnableDisableStationRestriction = 197,
        [EnumMember]
        SystemEnableDisableOtherRestriction = 198,
        [EnumMember]
        UpdateRestrictionGroup = 199,
        [EnumMember]
        AddNewRole = 200,
        [EnumMember]
        SearchRoles = 201,
        [EnumMember]
        EditRole = 202,
        [EnumMember]
        DeleteRole = 203,
        [EnumMember]
        UpdateRolePermissions = 204,
        [EnumMember]
        SearchRoleUsers = 205,
        [EnumMember]
        UpdateRoleUsers = 206,
        [EnumMember]
        ReadUsersFromActiveDirectory = 207,
        [EnumMember]
        AddUserRoles = 208,
        [EnumMember]
        SearchUsers = 209,
        [EnumMember]
        EditUserRoles = 210,
        [EnumMember]
        DeleteUserRoles = 211,
        [EnumMember]
        ReadRoleFunctionMapping = 212,
        [EnumMember]
        readRoles = 213,
        [EnumMember]
        ReadRolesUsers = 214,
        [EnumMember]
        ReadSystemRestrictionGroupSummary = 216,
        [EnumMember]
        SearchScheduledOrders = 218,
        [EnumMember]
        AddOrdersToPrinterQueue = 219,
        [EnumMember]
        PrintOrdersInPrinterQueue = 220,
        [EnumMember]
        ShowPrinterQueue = 221,
        [EnumMember]
        ReprintOrdersInErrorQueue = 222,
        [EnumMember]
        CancelJobInErrorQueue = 223,
        [EnumMember]
        ShowErrorQueue = 224,
        [EnumMember]
        ReadCardData = 225,
        [EnumMember]
        SetQualityAssuranceResult = 226,
        [EnumMember]
        SearchOrders = 227,
        [EnumMember]
        DeletePrinter = 228,
        [EnumMember]
        ShowAllPrinters = 229,
        [EnumMember]
        AddNewLocation = 300,
        [EnumMember]
        SearchLocation = 301,
        [EnumMember]
        EditLocation = 302,
        [EnumMember]
        DeleteLocation = 303,
        [EnumMember]
        MoveUnit = 304,
        [EnumMember]
        ReceiveFromVendor = 305,
        [EnumMember]
        ReturnToVendor = 307,
        [EnumMember]
        StatusSearch = 308,
        [EnumMember]
        RegisterUnitDisposal = 309,
        [EnumMember]
        UpdateUnitStatus = 310,
        [EnumMember]
        ReadUnitStatusHistory = 311,
        [EnumMember]
        AddNewUnitType = 312,
        [EnumMember]
        SearchUnitType = 313,
        [EnumMember]
        EditUnitType = 314,
        [EnumMember]
        DeleteUnitType = 315,
        [EnumMember]
        SearchInventoryLocation = 316,
        [EnumMember]
        SearchDriverCard = 323,
        [EnumMember]
        ViewCardCentreTransactionSummaryReport = 347,
        [EnumMember]
        ViewCardCentreTransactionDetailsReport = 348,
        [EnumMember]
        ViewCardCentreQCFailedOrdersReport = 349,
        [EnumMember]
        ViewCardCentreCardsstockLevelSummaryReport = 350,
        [EnumMember]
        ViewCardCentreCardsStockLevelDetailsReport = 351,
        [EnumMember]
        ViewDuePersonalizationOrderReport = 352,
        [EnumMember]
        ViewPlannedPersonalizationOrdersReport = 353,
        [EnumMember]
        ViewTagInstallationCenterTransactionSummaryReport = 354,
        [EnumMember]
        ViewTagInstallationCenterTransactionDetailsReport = 355,
        [EnumMember]
        ViewTagInstallationCenterQCFailedordersReport = 356,
        [EnumMember]
        ViewTagInstallationCenterTagsStockLevelSummaryReport = 357,
        [EnumMember]
        ViewTagInstallationCenterTagsStockLevelDetails = 358,
        [EnumMember]
        ViewDueWorkOrdersReport = 359,
        [EnumMember]
        ViewPlannedWorkOrdersReport = 360,
        [EnumMember]
        ViewPremiumCustomerInformation = 361,
        [EnumMember]
        ViewTransactionAuditReport = 362,
        [EnumMember]
        ViewAccountInformationAuditReport = 363,
        [EnumMember]
        ViewAccountBalanceReport = 364,
        [EnumMember]
        ViewAccountRefundTransactionsReport = 365,
        [EnumMember]
        ViewOfflineTransactionReport = 366,
        [EnumMember]
        ViewStatementofAccountSummaryReport = 367,
        [EnumMember]
        ViewStatementofAccountDetailsReport = 368,
        [EnumMember]
        SearchScheduledWorkOrders = 369,
        [EnumMember]
        InstallTag = 370,
        [EnumMember]
        ViewInstallationWorkOrderData = 371,
        [EnumMember]
        ReplaceTag = 372,
        [EnumMember]
        RemoveTag = 374,
        [EnumMember]
        DepotReadCardData = 376,
        [EnumMember]
        DepotSetQualityAssuranceResult = 377,
        [EnumMember]
        DepotSearchOrders = 378,
        [EnumMember]
        DepotViewOrderDetails = 379,
        [EnumMember]
        ViewAccountTopUpTransactionReport = 380,
        [EnumMember]
        ViewServiceFeeReport = 381,
        [EnumMember]
        ViewCardCenterFinancialTransactionReport = 382,
        [EnumMember]
        RenewTag = 383,
        [EnumMember]
        ViewRenewalWorkOrderData = 384,
        [EnumMember]
        ViewRemovalWorkOrderData = 385,
        [EnumMember]
        ViewReplacementWorkOrderData = 386,
        [EnumMember]
        SearchLostTokens = 387,
        [EnumMember]
        CanReportLostToken = 388,
        [EnumMember]
        ViewRequestSummaryReports = 389,
        [EnumMember]
        ViewBeneficiaryGroupsConsumptionReport = 390,
        [EnumMember]
        AddAccountQuotaInfo = 390,
        [EnumMember]
        SearchAccountQuotaInfo = 391,
        [EnumMember]
        DeleteAccountQuotaInfo = 392,
        [EnumMember]
        EditAccountQuotaInfo = 393,
        [EnumMember]
        ReadIndividualAccountPreferences = 439,
        [EnumMember]
        UpdateIndividualAccountPreferences = 440,
        [EnumMember]
        ReadAccountStatusLog = 408,
        [EnumMember]
        UpdateAccountStatus = 407,
        [EnumMember]
        GenerateAccountPin = 409,
        [EnumMember]
        GenerateNewDriverCard = 410,
        [EnumMember]
        UpdateDriverCard = 412,
        [EnumMember]
        ReadDriverCardLog = 413,
        [EnumMember]
        UpdateDriverCardStatus = 414,
        [EnumMember]
        SearchPrepaidAccountBalance = 450,
        [EnumMember]
        SavePrepaidAccountPayment = 451,
        [EnumMember]
        ReadPrepaidAccountPayment = 452,
        [EnumMember]
        UpdateWorkFlowSettings = 453,
        [EnumMember]
        AddPersonalization = 934,
        [EnumMember]
        AddNotificationConfiguration = 939,
        [EnumMember]
        UpdateNotificationConfiguration = 940,
        [EnumMember]
        SearchNotificationConfiguration = 941,
        [EnumMember]
        DeleteNotificationConfiguration = 942,
        [EnumMember]
        AddMessageGroup = 945,
        [EnumMember]
        UpdateMessageGroup = 946,
        [EnumMember]
        SearchMessageGroup = 947,
        [EnumMember]
        DeleteMessageGroup = 948,
        [EnumMember]
        SearchAccounts = 960,
        [EnumMember]
        EditAccount = 962,
        [EnumMember]
        SearchNewTokenBeneficiary = 958,
        [EnumMember]
        ChangeTokenBeneficiary = 959,
        [EnumMember]
        ReadPostpaidAccountPreferences = 401,
        [EnumMember]
        UpdatePostPaidAccountPreferences = 400,
        [EnumMember]
        assignUpliftDiscountToProduct = 402,
        [EnumMember]
        AddNewCustomerGroup = 403,
        [EnumMember]
        SearchCustomerGroup = 404,
        [EnumMember]
        EditCustomerGroup = 405,
        [EnumMember]
        DeleteCustomerGroup = 406,
        [EnumMember]
        ReadIdentityCardStatusLog = 604,
        [EnumMember]
        SearchPostpaidBilling = 605,
        [EnumMember]
        ReadExistingCustomerRestrictionGroupSummary = 419,
        [EnumMember]
        UpdateExistingCustomerRestrictionGroupSummary = 234,
        [EnumMember]
        AddNewDocument = 235,
        [EnumMember]
        ReadDocument = 236,
        [EnumMember]
        EditDocument = 237,
        [EnumMember]
        DeleteDocument = 238,
        [EnumMember]
        ReadRequestedDocument = 239,
        [EnumMember]
        AddRequestedDocument = 240,
        [EnumMember]
        ViewOrderDetails = 241,
        [EnumMember]
        ReadPostpaidBillingDetails = 242,
        [EnumMember]
        ReadTokenSummaryRestriction = 243,
        [EnumMember]
        UpdateTokenSummaryRestriction = 244,
        [EnumMember]
        AddRestrictionGroup = 245,
        [EnumMember]
        AddRestrictionGroupInfo = 246,
        [EnumMember]
        AddTransactionRestriction = 247,
        [EnumMember]
        AddAmountRestriction = 248,
        [EnumMember]
        AddProductQuantityRestriction = 249,
        [EnumMember]
        AddStationRestriction = 250,
        [EnumMember]
        AddOtherRestriction = 251,
        [EnumMember]
        AccountMasterSearchAccount = 252,

        [EnumMember]
        SearchExistingEVoucher = 253,
        [EnumMember]
        TerminateEVoucher = 254,
        [EnumMember]
        ViewEVoucherTransactionDetails = 255,
        [EnumMember]
        SearchExistingPreprintedVoucher = 256,
        [EnumMember]
        TerminatePreprintedVoucher = 257,
        [EnumMember]
        ViewPreprintedVoucherTransactionDetails = 258,
        [EnumMember]
        GeneratePreprintedVouchers = 259,
        [EnumMember]
        SavePreprintedVouchers = 260,
        [EnumMember]
        UpdateEVoucherSettings = 261,
        [EnumMember]
        AddCorporatePrepaidQuotaInformation = 262,
        [EnumMember]
        SearchCorporatePrepaidQuotaInformation = 263,
        [EnumMember]
        EditCorporatePrepaidQuotaInformation = 264,
        [EnumMember]
        DeleteCorporatePrepaidQuotaInformation = 265,
        [EnumMember]
        AddIndividualPrepaidQuotaInformation = 270,
        [EnumMember]
        SearchIndividualPrepaidQuotaInformation = 271,
        [EnumMember]
        EditIndividualPrepaidQuotaInformation = 272,
        [EnumMember]
        DeleteIndividualPrepaidQuotaInformation = 273,
        [EnumMember]
        AddCorporatePostPaidQuotaInformation = 274,
        [EnumMember]
        SearchCorporatePostPaidQuotaInformation = 275,
        [EnumMember]
        EditCorporatePostPaidQuotaInformation = 276,
        [EnumMember]
        DeleteCorporatePostPaidQuotaInformation = 277,
        [EnumMember]
        ViewCustomerInvoiceReport = 278,
        [EnumMember]
        ReadExistingCustomerRestrictionGroupInfo = 421,
        [EnumMember]
        UpdateExistingCustomerRestrictionGroupInfo = 422,
        [EnumMember]
        ReadExistingCustomerTransactionRestriction = 423,
        [EnumMember]
        ReadExistingCustomerNoOfAllowedTransactionRestriction = 424,
        [EnumMember]
        UpdateExistingCustomerTransactionRestriction = 425,
        [EnumMember]
        ReadExistingCustomerAmountRestriction = 426,
        [EnumMember]
        UpdateExistingCustomerAmountRestriction = 427,
        [EnumMember]
        ReadExistingCustomerProductRestrictionGroup = 428,
        [EnumMember]
        ReadExistingCustomerQuantityRestriction = 429,
        [EnumMember]
        UpdateExistingCustomerRestrictionGroupProduct = 430,
        [EnumMember]
        ReadExistingCustomerStationRestriction = 431,
        [EnumMember]
        ReadExistingCustomerOtherRestrictions = 433,
        [EnumMember]
        ReadCustomerRestrictionGroups = 436,
        [EnumMember]
        ReadTokenRestrictionGroups = 435,
        [EnumMember]
        CopyRestricitionGroupFromTemplate = 437,
        [EnumMember]
        AddNewCustomerRestrictionGroup = 416,
        [EnumMember]
        ReadPrepaidAccountPreferences = 441,
        [EnumMember]
        UpdatePrepaidAccountPreferences = 442,
        [EnumMember]
        GenerateBeneficiaryRows = 610,
        [EnumMember]
        SaveGeneratedBeneficiaries = 611,
        [EnumMember]
        GenerateTokenRows = 612,
        [EnumMember]
        SaveGeneratedTokens = 613,
        [EnumMember]
        SaveVehicleRegister = 614,
        [EnumMember]
        CustomerEnableDisableTransactionRestriction = 700,
        [EnumMember]
        CustomerEnableDisableAmountRestriction = 701,
        [EnumMember]
        CustomerEnableDisableProductQuantityRestriction = 702,
        [EnumMember]
        CustomerEnableDisableStationRestriction = 703,
        [EnumMember]
        CustomerEnableDisableOtherRestriction = 704,
        [EnumMember]
        SearchCustomerRestrictionGroup = 415,
        [EnumMember]
        EditCustomerRestrictionGroup = 417,
        [EnumMember]
        DeleteCustomerRestrictionGroup = 418,
        [EnumMember]
        ReadCorporatePostPaidInformation = 600,
        [EnumMember]
        UpdateCorporatePostPaidIdentityCard = 601,
        [EnumMember]
        UpdateIdentityCardStatus = 603,
        [EnumMember]
        SearchEmployeeInfo = 602,
        [EnumMember]
        ExecuteVehicleAssignedDriverReport = 705,
        [EnumMember]
        ExecuteFamiliesReport = 706,
        [EnumMember]
        ExecuteDriverAssignedVehiclesReport = 707,
        [EnumMember]
        ExecuteCustomerStatusHistoryReport = 708,
        [EnumMember]
        ExecuteCustomerDriverTokensReport = 709,
        [EnumMember]
        ExecuteCustomerBasicInformationReport = 710,
        [EnumMember]
        ExecuteCustomerAccountManagerReport = 711,
        [EnumMember]
        ExecuteBeneficiaryBasicInformationReport = 712,
        [EnumMember]
        ExecuteCustomerBeneficiariesReport = 713,
        [EnumMember]
        ExecuteTokenBasicInfoReport = 714,
        [EnumMember]
        ExecuteTokenStatusReport = 715,
        [EnumMember]
        ExecuteTokenVehicleInformationReport = 716,
        [EnumMember]
        ExecuteBeneficiaryStatusReport = 717,
        [EnumMember]
        ExecuteVIPBeneficiaryInfoReport = 718,
        [EnumMember]
        ExecuteDisabledBeneficiaryInfoReport = 719,
        [EnumMember]
        ExecuteTokenRestrictionReport = 720,
        [EnumMember]
        ExecuteCustomerContactsReport = 721,
        [EnumMember]
        ExecuteStocktakingReport = 722,
        [EnumMember]
        ExecuteCustomersTransactionsDetailsBothReport = 723,
        [EnumMember]
        ExecuteStationsTransactionsReport = 724,
        [EnumMember]
        ExecuteStationsproductTransactionDetailsReport = 725,
        [EnumMember]
        ExecuteCustomerInvoiceDetailsReport = 726,
        [EnumMember]
        ExecuteInvoicegenerationReport = 727,
        [EnumMember]
        UpdateEarningFormula = 728,
        [EnumMember]
        UpdateRedemptionFormula = 729,
        [EnumMember]
        SubscribeAccountsToLoyaltyProgram = 730,
        [EnumMember]
        UnSubscribeAccountsFromLoyaltyProgram = 731,
        [EnumMember]
        ViewAccount = 732,
        [EnumMember]
        SubscribeAccount = 733,
        [EnumMember]
        SubscribeAccountSearch = 734,
        [EnumMember]
        UnSubscribeAccount = 735,
        [EnumMember]
        UnSubscribeAccountSearch = 736,
        [EnumMember]
        LoyaltySearchAccounts = 737,
        [EnumMember]
        SelectAccount = 738,
        [EnumMember]
        SearchPointTransactions = 739,
        [EnumMember]
        RedeemPoints = 740,
        [EnumMember]
        SearchVoucherHistory = 741,
        [EnumMember]
        ExecuteCustomerTokenReport = 742,
        [EnumMember]
        AddNEwModule = 900,
        [EnumMember]
        UpdateNewModule = 902,
        [EnumMember]
        DeleteModule = 901,
        [EnumMember]
        AddNewPage = 904,
        [EnumMember]
        UpdateNewPage = 905,
        [EnumMember]
        DeleteNewPage = 906,
        [EnumMember]
        ShowAccountExplorer = 907,
        [EnumMember]
        SearchCustomerTransaction = 931,
        [EnumMember]
        SearchBeneficiaryTransaction = 932,
        [EnumMember]
        ViewEPICallLogReport = 454,
        [EnumMember]
        SendUnit = 455,
        [EnumMember]
        ViewInventoryStockLevelDetailsReport = 456,
        [EnumMember]
        ViewInventoryStockLevelSummaryReport = 457,
        [EnumMember]
        VehicleAssignedDriverReport = 908,
        [EnumMember]
        FamiliesReport = 909,
        [EnumMember]
        DriverAssignedVehiclesReport = 910,
        [EnumMember]
        CustomerStatusHistoryReport = 911,
        [EnumMember]
        CustomerDriverTokensReport = 912,
        [EnumMember]
        CustomerBasicInformationReport = 913,
        [EnumMember]
        CustomerAccountManagerReport = 914,
        [EnumMember]
        BeneficiaryBasicInformationReport = 915,
        [EnumMember]
        CustomerBeneficiariesReport = 916,
        [EnumMember]
        TokenBasicInfoReport = 917,
        [EnumMember]
        TokenStatusReport = 918,
        [EnumMember]
        TokenVehicleInformationReport = 919,
        [EnumMember]
        BeneficiaryStatusReport = 920,
        [EnumMember]
        VIPBeneficiaryInfoReport = 921,
        [EnumMember]
        DisabledBeneficiaryInfoReport = 922,
        [EnumMember]
        TokenRestrictionReport = 923,
        [EnumMember]
        CustomerContactsReport = 924,
        [EnumMember]
        StocktakingReport = 925,
        [EnumMember]
        CustomersTransactionsDetailsBothReport = 926,
        [EnumMember]
        StationsTransactionsReport = 927,
        [EnumMember]
        StationsproductTransactionDetailsReport = 928,
        [EnumMember]
        CustomerInvoiceDetailsReport = 929,
        [EnumMember]
        InvoicegenerationReport = 930,
        [EnumMember]
        CustomerTokenReport = 931,
        [EnumMember]
        ReadBillingDetails = 935,
        [EnumMember]
        UpdateTokenStatus = 936,
        [EnumMember]
        ReadTokenStatusLogHistory = 937,
        [EnumMember]
        IssueToken = 938,
        [EnumMember]
        AddEmailNotification = 943,
        [EnumMember]
        SearchEmailNotification = 944,
        [EnumMember]
        AddMessage = 949,
        [EnumMember]
        UpdateMessage = 950,
        [EnumMember]
        SearchMessage = 951,
        [EnumMember]
        DeleteMessage = 952,
        [EnumMember]
        ReadMessageDetails = 953,
        [EnumMember]
        AddSmsNotification = 954,
        [EnumMember]
        SearchSmsNotification = 955,
        [EnumMember]
        ReadSmsDetails = 956,
        [EnumMember]
        ReadLastBilledDate = 957,
        [EnumMember]
        SearchADUser = 964,
        [EnumMember]
        ReadRestrictionGroupInformation = 965,
        [EnumMember]
        UpdateVehicleMake = 966,
        [EnumMember]
        UpdateVehicleRegister = 967,
        [EnumMember]
        ReadUnbilledData = 963,
        [EnumMember]
        SearchCardPersonalizationOrders = 60,
        [EnumMember]
        ShowAllCardPersonalizationOrders = 62,
        [EnumMember]
        AddToPrinterQueue = 61,
        [EnumMember]
        GetCardInfoBySerial = 69,
        [EnumMember]
        SavePersonalizationOrder = 70,
        [EnumMember]
        AddNewPrinter = 71,
        [EnumMember]
        UpdateExistingPrinter = 74,
        [EnumMember]
        SearchRegisterTokenDelivery = 80,
        [EnumMember]
        SaveRegisterdDelivery = 81,
        [EnumMember]
        SearchRequests = 86,
        [EnumMember]
        ViewRequests = 87,
        [EnumMember]
        ApproveRequests = 88,
        [EnumMember]
        RejectRequests = 89,
        [EnumMember]
        ReadIndividualAccountCreationInfo = 91,
        [EnumMember]
        ApproveWorkOrderRequest = 92,
        [EnumMember]
        ReadWorkOrderRequest = 90,
        [EnumMember]
        RejectWorkOrderRequest = 97,
        [EnumMember]
        ReadCorporatePrepaidCreationRequestInfo = 93,
        [EnumMember]
        ReadPersonalizationRequest = 94,
        [EnumMember]
        ApprovePersonalizationRequest = 95,
        [EnumMember]
        ReadIndividualRequestClosureInfo = 98,
        [EnumMember]
        ReadCorporatePrepaidClosureRequestInfo = 99,
        [EnumMember]
        ReadCorporatePostpaidClosureRequestInfo = 317,
        [EnumMember]
        GetPrepaidCustomerRefundInfo = 319,
        [EnumMember]
        RefundPrepaidCustomer = 320,
        [EnumMember]
        GetEmployeeInfo = 321,
        [EnumMember]
        SearchVehicle = 322,
        [EnumMember]
        MapDriverCard = 324,
        [EnumMember]
        DeleteMappedDriverCard = 325,
        [EnumMember]
        ReadCorporatePostpaidCreationRequestInfo = 328,
        [EnumMember]
        ApprovedIndividualAccountCreationInfo = 329,
        [EnumMember]
        ApprovedCorporatePrepaidCreationRequestInfo = 330,
        [EnumMember]
        ApprovedCorporatePostpaidCreationRequestInfo = 331,
        [EnumMember]
        ApprovedCorporatePrepaidClosureRequestInfo = 332,
        [EnumMember]
        ApprovedIndividualRequestClosureInfo = 334,
        [EnumMember]
        ApprovedCorporatePostpaidClosureRequestInfo = 335,
        [EnumMember]
        RejectIndividualAccountCreationInfo = 336,
        [EnumMember]
        RejectCorporatePrepaidCreationRequestInfo = 337,
        [EnumMember]
        RejectCorporatePostpaidCreationRequestInfo = 338,
        [EnumMember]
        RejectCorporatePrepaidClosureRequestInfo = 339,
        [EnumMember]
        RejectIndividualRequestClosureInfo = 340,
        [EnumMember]
        RejectCorporatePostpaidClosureRequestInfo = 341,
        [EnumMember]
        ApproveServiceFeeRequest = 342,
        [EnumMember]
        RejectServiceFeeRequest = 343,
        [EnumMember]
        ReadServiceFeeRequest = 344,
        [EnumMember]
        SaveCreditDebitNote = 345,
        [EnumMember]
        ReadCreditDebitNote = 346,
        [EnumMember]
        UpdateExistingCustomerStationRestriction = 230,
        [EnumMember]
        UpdateExistingCustomerOtherRestriction = 231,
        [EnumMember]
        ReadAccountExplorer = 232,
        [EnumMember]
        UpdateGlobalSettings = 458,
        [EnumMember]
        AddCity = 459,
        [EnumMember]
        UpdateCity = 460,
        [EnumMember]
        DeleteCity = 461,
        [EnumMember]
        SearchCity = 462,
        [EnumMember]
        AddArea = 463,
        [EnumMember]
        UpdateArea = 464,
        [EnumMember]
        DeleteArea = 465,
        [EnumMember]
        SearchArea = 466,
        [EnumMember]
        SaveRegisterdDeliveryGlobal = 467,
        [EnumMember]
        SearchRegisterTokenDeliveryGlobal = 468,
        [EnumMember]
        PrepaidAccountCreationRequest = 500,
        [EnumMember]
        PostpaidAccountCreationRequest = 501,
        [EnumMember]
        IndividualAccountCreationRequest = 502,
        [EnumMember]
        TokenIssuanceRequest = 503,
        [EnumMember]
        AccountClosureRequest = 504,
        [EnumMember]
        ReadPostpaidInfoFromAr = 505,
        [EnumMember]
        ViewPostpaidBasicInfo = 506,
        [EnumMember]
        AddPostpaidAccountBasicInfo = 507,
        [EnumMember]
        AddPostpaidAccountBillingInfo = 508,
        [EnumMember]
        AddPostpaidAccountContactInfo = 509,
        [EnumMember]
        AddCorporatePrepaidAccountBasicInfo = 510,
        [EnumMember]
        AddCorporatePrepaidAccountContactInfo = 511,
        [EnumMember]
        AddIndividualPrepaidAccountBasicInfo = 512,
        [EnumMember]
        AddIndividualPrepaidAccountContactInfo = 513,
        [EnumMember]
        SearchIssuedToken = 514,
        [EnumMember]
        EditTokenIssuance = 515,
        [EnumMember]
        AddWorkOrderRequest = 516,
        [EnumMember]
        AddPersonalizationRequest = 517,
        [EnumMember]
        SearchExisitngAccount = 518,
        [EnumMember]
        ViewExisitngAccount = 519,
        [EnumMember]
        AddAccountClosureRequest = 520,
        [EnumMember]
        SearchAgentRequest = 521,
        [EnumMember]
        ViewRequest = 522,
        [EnumMember]
        ViewHistory = 524,
        [EnumMember]
        ViewRequestDetails = 525,
        [EnumMember]
        ViewWorkOrderRequest = 528,
        [EnumMember]
        AcceptWorkOrderRequest = 529,
        [EnumMember]
        ViewIndividualPrepaidBasicInfo = 531,
        [EnumMember]
        ViewIndividualPrepaidContactInfo = 532,
        [EnumMember]
        AcceptIndividualPrepaidAccountCreationRequest = 533,
        [EnumMember]
        RejectIndividualPrepaidAccountCreationRequest = 534,
        [EnumMember]
        ViewCorporatePrepaidBasicInfo = 535,
        [EnumMember]
        ViewCorporatePrepaidContactInfo = 536,
        [EnumMember]
        AcceptCorporatePrepaidAccountCreationRequest = 537,
        [EnumMember]
        RejectCorporatePrepaidAccountCreationRequest = 538,
        [EnumMember]
        ViewPostPaidBillingInfo = 539,
        [EnumMember]
        ViewPostPaidContactInfo = 541,
        [EnumMember]
        UpdatePostpaidInfoFromAr = 542,
        [EnumMember]
        AcceptCorporatePostpaidAccountCreationRequest = 543,
        [EnumMember]
        RejectCorporatePostpaidAccountCreationRequest = 544,
        [EnumMember]
        ViewAccountClosureRequest = 545,
        [EnumMember]
        AcceptAccountClosureRequest = 546,
        [EnumMember]
        RejectAccountClosureRequest = 547,
        [EnumMember]
        ViewPersonalizationRequest = 548,
        [EnumMember]
        AcceptPersonalizationRequest = 549,
        [EnumMember]
        RejectPersonalizationRequest = 550,
        [EnumMember]
        SearchAproverRequest = 551,
        [EnumMember]
        ViewInitialApproveRequest = 552,
        [EnumMember]
        ViewFinalApproveRequest = 553,
        [EnumMember]
        AcceptInitialApprove = 554,
        [EnumMember]
        RejectInitialApprove = 555,
        [EnumMember]
        AcceptFinalApprove = 558,
        [EnumMember]
        RejectFinalApprove = 559,
        [EnumMember]
        SearchRequestHistory = 570,
        [EnumMember]
        SearchDifferentialPricingRule = 615,
        [EnumMember]
        AddDifferentialPricingRule = 616,
        [EnumMember]
        EditDifferentialPricingRule = 617,
        [EnumMember]
        DeleteDifferentialPricingRule = 618,
        [EnumMember]
        AddDifferentialPricingRuleType = 619,
        [EnumMember]
        AddMoreProduct = 620,
        [EnumMember]
        SetProductRule = 621,
        [EnumMember]
        DeleteProductRule = 622,
        [EnumMember]
        SetAccountSegment = 623,
        [EnumMember]
        SetBeneficiarySegment = 624,
        [EnumMember]
        SetTokenSegment = 625,
        [EnumMember]
        AddOnlineAppliedDifferentialPricingRule = 626,
        [EnumMember]
        UpdateOnlineAppliedDifferentialPricingRule = 633,
        [EnumMember]
        AddEomAppliedDifferentialPricingRule = 638,
        [EnumMember]
        UpdateEomAppliedDifferentialPricingRule = 643,
        [EnumMember]
        SearchRule = 644,
        [EnumMember]
        ViewProductRule = 645,
        [EnumMember]
        ViewAccountSegment = 646,
        [EnumMember]
        ViewBeneficiarySegment = 647,
        [EnumMember]
        ViewTokenSegment = 648,
        [EnumMember]
        ViewOnlineDifferentialPricingRule = 649,
        [EnumMember]
        ViewEomDifferentialPricingRule = 650,
        [EnumMember]
        UpdateCeilingLimit = 233,
        [EnumMember]
        ApproveInitialAccountClosureRequest = 571,
        [EnumMember]
        ApproveInitialCorporatePostpaidAccountCreationRequest = 572,
        [EnumMember]
        ApproveInitialCorporatePrepaidAccountCreationRequest = 573,
        [EnumMember]
        ApproveInitialIndividualPrepaidAccountCreationRequest = 574,
        [EnumMember]
        ApproveInitialPersonalizationRequest = 575,
        [EnumMember]
        ApproveInitialWorkOrderRequest = 576,
        [EnumMember]
        RejectInitialAccountClosureRequest = 577,
        [EnumMember]
        RejectInitialCorporatePostpaidAccountCreationRequest = 578,
        [EnumMember]
        RejectInitialCorporatePrepaidAccountCreationRequest = 579,
        [EnumMember]
        RejectInitialIndividualPrepaidAccountCreationRequest = 580,
        [EnumMember]
        RejectInitialPersonalizationRequest = 581,
        [EnumMember]
        RejectInitialWorkOrderRequest = 582,
        [EnumMember]
        ApproveFinalAccountClosureRequest = 583,
        [EnumMember]
        ApproveFinalCorporatePostpaidAccountCreationRequest = 584,
        [EnumMember]
        ApproveFinalCorporatePrepaidAccountCreationRequest = 585,
        [EnumMember]
        ApproveFinalIndividualPrepaidAccountCreationRequest = 586,
        [EnumMember]
        ApproveFinalPersonalizationRequest = 587,
        [EnumMember]
        ApproveFinalWorkOrderRequest = 588,
        [EnumMember]
        RejectFinalAccountClosureRequest = 589,
        [EnumMember]
        RejectFinalCorporatePostpaidAccountCreationRequest = 590,
        [EnumMember]
        RejectFinalCorporatePrepaidAccountCreationRequest = 591,
        [EnumMember]
        RejectFinalIndividualPrepaidAccountCreationRequest = 592,
        [EnumMember]
        RejectFinalPersonalizationRequest = 593,
        [EnumMember]
        RejectFinalWorkOrderRequest = 594,
        [EnumMember]
        ViewInitialAccountClosureRequest = 651,
        [EnumMember]
        ViewInitialCorporatePostpaidAccountCreationRequest = 652,
        [EnumMember]
        ViewInitialCorporatePrepaidAccountCreationRequest = 653,
        [EnumMember]
        ViewInitialIndividualPrepaidAccountCreationRequest = 654,
        [EnumMember]
        ViewInitialPersonalizationRequest = 655,
        [EnumMember]
        ViewInitialWorkOrderRequest = 656,
        [EnumMember]
        ViewFinalAccountClosureRequest = 657,
        [EnumMember]
        ViewFinalCorporatePostpaidAccountCreationRequest = 658,
        [EnumMember]
        ViewFinalCorporatePrepaidAccountCreationRequest = 659,
        [EnumMember]
        ViewFinalIndividualPrepaidAccountCreationRequest = 660,
        [EnumMember]
        ViewFinalPersonalizationRequest = 661,
        [EnumMember]
        ViewFinalWorkOrderRequest = 662,
        [EnumMember]
        ViewFinalRequestDetails = 663,
        [EnumMember]
        ViewInitialRequestDetails = 664,
        [EnumMember]
        ViewFinalHistory = 665,
        [EnumMember]
        ViewInitialHistory = 666,
        [EnumMember]
        SearchFinalAproverRequest = 667,
        [EnumMember]
        SearchInitialAproverRequest = 668,
        [EnumMember]
        ViewInitialIndividualPrepaidBasicinfo = 669,
        [EnumMember]
        ViewFinalIndividualPrepaidBasicInfo = 671,
        [EnumMember]
        ViewInitialCorporatePostpaidBasicInfo = 673,
        [EnumMember]
        ViewInitialCorporatePostpaidContactInfo = 674,
        [EnumMember]
        ViewFinalCorporatePostpaidBasicInfo = 675,
        [EnumMember]
        ViewFinalCorporatePostpaidContactInfo = 676,
        [EnumMember]
        ViewInitialIndividualPrepaidContactInfo = 683,
        [EnumMember]
        ViewFinalCorporatePrepaidBasicInfo = 684,
        [EnumMember]
        ViewFinalIndividualPrepaidContactInfo = 685,
        [EnumMember]
        ViewInitialCorporatePrepaidBasicInfo = 686,
        [EnumMember]
        ViewInitialCorporatePostpaidBillingInfo = 687,
        [EnumMember]
        ViewFinalCorporatePostpaidBillingInfo = 688,
        [EnumMember]
        ViewInitialCorporatePrepaidContactInfo = 689,
        [EnumMember]
        ViewFinalCorporatePrepaidContactInfo = 690,
        [EnumMember]
        CancelJobInPrinterQueue = 699,

        [EnumMember]
        AccountTokenSearch = 968,
        [EnumMember]
        AccountTokenEdit = 969,
        [EnumMember]
        AccountTokenDelete = 970,
        [EnumMember]
        SearchReceiptTransactions = 971,
        [EnumMember]
        PrintReceiptTransaction = 972,
        [EnumMember]
        EditVATService = 973,
        [EnumMember]
        ViewVATService = 974,
        [EnumMember]
        ViewRestrictionGroupHistoryReport = 975,
        [EnumMember]
        ViewWOQODPreprintedVoucherTransactions = 20,
        [EnumMember]
        SearchExistingPreprintedVoucherPostPaidCustomer = 976,
        [EnumMember]
        TerminatePreprintedVoucherPostPaidCustomer = 977,
        [EnumMember]
        ViewPreprintedVoucherTransactionDetailsPostPaidCustomer = 978,
        [EnumMember]
        GeneratePreprintedVouchersPostPaidCustomer = 979,
        [EnumMember]
        SavePreprintedVouchersPostPaidCustomer = 980,
        [EnumMember]
        ViewPreprintedVoucherInfo = 981,
        [EnumMember]
        SearchPendingRequest = 982,
        [EnumMember]
        EscalateAccountClosureRequest = 983,
        [EnumMember]
        EscalateCorporatePostpaidAccountCreationRequest = 984,
        [EnumMember]
        EscalateCorporatePrepaidAccountCreationRequest = 985,
        [EnumMember]
        EscalateIndividualPrepaidAccountCreationRequest = 986,
        [EnumMember]
        EscalatePersonalizationRequest = 987,
        [EnumMember]
        EscalateWorkOrderRequest = 988,
        [EnumMember]
        ApproveManagementAccountClosureRequest = 989,
        [EnumMember]
        ApproveManagementCorporatePostpaidAccountCreationRequest = 990,
        [EnumMember]
        ApproveManagementCorporatePrepaidAccountCreationRequest = 991,
        [EnumMember]
        ApproveManagementIndividualPrepaidAccountCreationRequest = 992,
        [EnumMember]
        ApproveManagementPersonalizationRequest = 993,
        [EnumMember]
        ApproveManagementWorkOrderRequest = 994,
        [EnumMember]
        RejectManagementAccountClosureRequest = 995,
        [EnumMember]
        RejectManagementCorporatePostpaidAccountCreationRequest = 996,
        [EnumMember]
        RejectManagementCorporatePrepaidAccountCreationRequest = 997,
        [EnumMember]
        RejectManagementIndividualPrepaidAccountCreationRequest = 998,
        [EnumMember]
        RejectManagementPersonalizationRequest = 999,
        [EnumMember]
        RejectManagementWorkOrderRequest = 1000,
        [EnumMember]
        SearchManagementAproverRequest = 1001,
        [EnumMember]
        ViewManagementAccountClosureRequest = 1002,
        [EnumMember]
        ViewManagementCorporatePostpaidBasicInfo = 1003,
        [EnumMember]
        ViewManagementCorporatePostpaidBillingInfo = 1004,
        [EnumMember]
        ViewManagementCorporatePostpaidContactInfo = 1005,
        [EnumMember]
        ViewManagementCorporatePrepaidBasicInfo = 1006,
        [EnumMember]
        ViewManagementCorporatePrepaidContactInfo = 1007,
        [EnumMember]
        ViewManagementHistory = 1008,
        [EnumMember]
        ViewManagementIndividualPrepaidBasicInfo = 1009,
        [EnumMember]
        ViewManagementIndividualPrepaidContactInfo = 1010,
        [EnumMember]
        ViewManagementPersonalizationRequest = 1011,
        [EnumMember]
        ViewManagementRequestDetails = 1012,
        [EnumMember]
        ViewManagementWorkOrderRequest = 1013,
        [EnumMember]
        CreditDebitRequestSearchAccount = 1014,
        [EnumMember]
        SaveCreditDebitRequest = 1016,
        [EnumMember]
        SavePreprintedVoucherRequest = 1018,
        [EnumMember]
        EscalatePreprintedVoucherRequest = 1019,
        [EnumMember]
        EscalateCredtiDebitRequest = 1020,
        [EnumMember]
        EscalateRefundRequest = 1021,
        [EnumMember]
        ApproveManagementPreprintedVoucherRequest = 1022,
        [EnumMember]
        ApproveManagementCredtiDebitRequest = 1023,
        [EnumMember]
        ApproveManagementRefundRequest = 1024,
        [EnumMember]
        RejectManagementPreprintedVoucherRequest = 1025,
        [EnumMember]
        RejectManagementCredtiDebitRequest = 1026,
        [EnumMember]
        RejectManagementRefundRequest = 1027,
        [EnumMember]
        ViewManagementPreprintedVoucherRequest = 1028,
        [EnumMember]
        ViewManagementCredtiDebitRequest = 1029,
        [EnumMember]
        ViewManagementRefundRequest = 1030,
        [EnumMember]
        ViewPreprintedVoucherRequest = 1031,
        [EnumMember]
        ViewDebitCreditRequest = 1032,
        [EnumMember]
        ViewRefundRequest = 1033,
        [EnumMember]
        AcceptCreditDebitRequest = 1034,
        [EnumMember]
        RejectCreditDebitRequest = 1035,
        [EnumMember]
        ViewInitialCreditDebitRequest = 1036,
        [EnumMember]
        ApproveInitialCreditDebitRequest = 1037,
        [EnumMember]
        RejectInitialCreditDebitRequest = 1038,
        [EnumMember]
        ViewFinalCreditDebitRequest = 1039,
        [EnumMember]
        ApproveFinalCreditDebitRequest = 1040,
        [EnumMember]
        RejectFinalCreditDebitRequest = 1041,

        [EnumMember]
        AcceptPreprintedVoucherRequest = 1042,
        [EnumMember]
        RejectPreprintedVoucherRequest = 1043,
        [EnumMember]
        ViewInitialPreprintedVoucherRequest = 1044,
        [EnumMember]
        ApproveInitialPreprintedVoucherRequest = 1045,
        [EnumMember]
        RejectInitialPreprintedVoucherRequest = 1046,
        [EnumMember]
        ViewFinalPreprintedVoucherRequest = 1047,
        [EnumMember]
        ApproveFinalPreprintedVoucherRequest = 1048,
        [EnumMember]
        RejectFinalPreprintedVoucherRequest = 1049,

        [EnumMember]
        AcceptRefundRequest = 1050,
        [EnumMember]
        RejectRefundRequest = 1051,
        [EnumMember]
        ViewInitialRefundRequest = 1052,
        [EnumMember]
        ApproveInitialRefundRequest = 1053,
        [EnumMember]
        RejectInitialRefundRequest = 1054,
        [EnumMember]
        ViewFinalRefundRequest = 1055,
        [EnumMember]
        ApproveFinalRefundRequest = 1056,
        [EnumMember]
        RejectFinalRefundRequest = 1057,
        [EnumMember]
        RefundRequestSearchAccount = 1058,

        [EnumMember]
        ReadIndividualPostpaidInfoFromAR = 1059,
        [EnumMember]
        AddNewIndividualPostpaidAccountBasicInfo = 1060,
        [EnumMember]
        AddNewIndividualPostpaidAccountBillingInfo = 1061,
        [EnumMember]
        AddNewIndividualPostpaidAccountContactInfo = 1062,
        [EnumMember]
        ReadIndividualPostpaidBasicInfo = 1063,
        [EnumMember]
        UpdateIndividualPostpaidBasicInfo = 1064,
        [EnumMember]
        ReadIndividualPostPaidBillingInfo = 1065,
        [EnumMember]
        UpdateIndividualPostpaidBillingInfo = 1066,
        [EnumMember]
        ReadIndividualPostpaidAccountContactInfo = 1067,
        [EnumMember]
        UpdateIndividualPostPaidAccountContactInfo = 1068,
        [EnumMember]
        UpdateIndividualPostpaidPreferences = 1069,
        [EnumMember]
        ViewIndividualPostpaidPreferences = 1070,

        [EnumMember]
        AcceptIndividualPostpaidRequest = 1071,
        [EnumMember]
        RejectIndividualPostpaidRequest = 1072,
        [EnumMember]
        ViewInitialIndividualPostpaidRequest = 1073,
        [EnumMember]
        ApproveInitialIndividualPostpaidRequest = 1074,
        [EnumMember]
        RejectInitialIndividualPostpaidRequest = 1075,
        [EnumMember]
        ViewFinalIndividualPostpaidRequest = 1076,
        [EnumMember]
        ApproveFinalIndividualPostpaidRequest = 1077,
        [EnumMember]
        RejectFinalIndividualPostpaidRequest = 1078,
        [EnumMember]
        MigrateAccount = 1079,
        [EnumMember]
        SearchAccount = 1080,
        [EnumMember]
        ViewAccountMigrationReport = 1081,
        [EnumMember]
        MigrateVehicleInfo = 1082,
        [EnumMember]
        ViewRFIDTagInstallationReport = 1083,
        [EnumMember]
        ViewCorporateCustomerVehicleListReport = 1084,
        [EnumMember]
        ViewTagSummaryConsumptionByWeekReport = 1085,
        [EnumMember]
        ViewTagUnderAndOutOfWarrantyReport = 1086,
        [EnumMember]
        ViewVehicleLimitOverRunReport = 1087,
        [EnumMember]
        ViewWalletBalanceReport = 1088,
        [EnumMember]
        ViewCustomerWiseCreditReport = 1089,
        [EnumMember]
        ViewCustomerWiseNegativeCreditReport = 1090,
        [EnumMember]
        ViewPrepaidUsingMobileReport = 1091,
        [EnumMember]
        ViewShiftedTokensReport = 1092,
        [EnumMember]
        SearchTransactionReversal = 1093,
        [EnumMember]
        ViewReversedTransaction = 1094,
        [EnumMember]
        ReverseTransaction = 1095,
        [EnumMember]
        AddStation = 1096,
        [EnumMember]
        UpdateStation = 1097,
        [EnumMember]
        SearchStation = 1098,
        [EnumMember]
        ViewProductBillingFrequency = 1099,
        [EnumMember]
        ViewServiceBillingFrequency = 1100,
        [EnumMember]
        UpdateProductBillingFrequency = 1101,
        [EnumMember]
        UpdateServiceBillingFrequency = 1102,
        [EnumMember]
        ViewPrepaidCustomerInactiveReport = 1103,
        [EnumMember]
        ViewPrepaidCustomerActiveReport = 1104,
        [EnumMember]
        ViewPrepaidCustomerEnrolledVSActiveReport = 1105,
        [EnumMember]
        ViewPrepaidCustomerEnrolledVSInactiveReport = 1106,
        [EnumMember]
        ViewVehiclePlateChangeHistoryReport = 1107,
        [EnumMember]
        EscalateIndividualPostPaidAccountRequest = 1108,
        [EnumMember]
        AddRefundRequest = 1109,
        [EnumMember]
        ViewManagementIndividualPostpaidBasicInfo = 1110,
        [EnumMember]
        ViewManagementIndividualPostpaidBillingInfo = 1111,
        [EnumMember]
        ViewManagementIndividualPostpaidContactInfo = 1112,
        [EnumMember]
        RejectManagementIndividualPostpaidRequest = 1113,
        [EnumMember]
        ApproveManagementIndividualPostpaidRequest = 1114,
        [EnumMember]
        CreditDebitNoteRequest = 1115,
        [EnumMember]
        PreprintedVoucherRequest = 1116,
        [EnumMember]
        RefundRequest = 1117,
        [EnumMember]
        IndividualPostPaidAccountCreationRequest = 1118,
        [EnumMember]
        AddWhatsAppNotification = 1119,
        [EnumMember]
        SearchWhatsAppNotification = 1120,
        [EnumMember]
        UpdateExternalVoucher = 1123,
        [EnumMember]
        SaveExternalVoucher = 1122,
        [EnumMember]
        SearchExternalVoucher = 1121,
        [EnumMember]
        ViewConsolidatedInvoiceReportforVoucherReport =1125
    };

    public enum RequestTypes
    {
        WorkOrderRemovalRequest = 10,
        NewIndividualCustomerRequest = 0,
        NewPrepaidCorporateCustomerRequest = 1,
        NewPostpaidCorporateCustomerRequest = 2,
        AccountClosureRequest = 3,
        NewCardPersonalizationRequest = 4,
        CardPersonalizationReplacementRequest = 5,
        CardPersonalizationRenewalRequest = 6,
        NewWorkOrderRequest = 7,
        WorkOrderReplacementRequest = 8,
        WorkOrderRenewalRequest = 9,
        CreditDebitNoteRequest = 12,
        PreprintedVoucherRequest = 11,
        RefundRequest = 13,
        NewIndividualPostpaidCustomerRequest = 14
    };

    public enum RequestStatus
    {
        Pending = 0,
        Processing = 1,
        Approved = 2,
        Rejected = 3,
        Expired = 4
    };

    public enum ServiceNames
    {
        AccountCreation = 0,
        PremierCustomer = 1,
        AccountActivation = 2,
        AccountSuspension = 3,
        AccountReactivation = 4,
        AccountSettlement = 5,
        AccountTermination = 6,
        AccountPINReset = 7,
        AccountPayment = 8,
        AccountBalanceEnquiry = 9,
        AccountPreferenceSetting = 10,
        BeneficiaryGroupCreation = 11,
        BeneficiaryCreation = 12,
        BeneficiaryActivation = 13,
        BeneficiarySuspension = 14,
        BeneficiaryReactivation = 15,
        BeneficiaryTermination = 16,
        BenefiicaryPreferenceSetting = 17,
        BeneficiaryPINReset = 18,
        BeneficiaryBatchCreation = 19,
        BeneficiaryGroupUpdate = 20,
        CreateCardProfile = 21,
        CardPersonalization = 22,
        CardDelivery = 23,
        UpdateCardProfile = 24,
        CardActivation = 25,
        CardSuspension = 26,
        CardReactivation = 27,
        CardTermination = 28,
        CardRenewalRequest = 29,
        CardReplacementRequest = 30,
        BatchCardProfileCreation = 31,
        BatchCardPersonalization = 32,
        BatchVehicleTagProfileCreation = 33,
        MapVehicleTag = 34,
        CreateEmiratesIDProfile = 35,
        EmirateIDActivation = 36,
        UpdateEmirateIDProfile = 37,
        EmirateIDSuspension = 38,
        EmirateIDReactivation = 39,
        EmirateIDReplacementRenewal = 40,
        EmirateIDTermination = 41,
        CreateTagProfilewithVehicleDetailsandTagsassignment = 42,
        TagInstallationWorkOrderRequest = 43,
        UpdateTagProfile = 44,
        TagActivation = 45,
        TagSuspension = 46,
        TagReactivation = 47,
        TagRenewalRequest = 48,
        TagReplacementRequest = 49,
        BatchTagProfileCreation = 50,
        IdentityTokenCreation = 51,
        IdentityCardPersonalization = 52,
        IdentityTokenDelivery = 53,
        IdentityTokenActivation = 54,
        IdentityTokenSuspension = 55,
        IdentityTokenReactivation = 56,
        IdentityTokenTermination = 57,
        IdentityCardRenewal = 58,
        IdentityCardReplacement = 59,
        DriverTokenCreation = 60,
        DriverTokenPersonalization = 61,
        DriverTokenDelivery = 62,
        DriverTokenActivation = 63,
        DriverTokenSuspension = 64,
        DriverTokenReactivation = 65,
        DriverTokenTermination = 66,
        DriverTokenRenewal = 67,
        DriverTokenReplacement = 68,
        ApplyDifferentialPricing = 69,
        SendSMS = 70,
        SendEmail = 71,
        ApplyTokenRestriction = 72,
        ChangeTokenOwner = 73,
        TagRemovalRequest = 74

    };

    #endregion

    public class CustomerService : ICustomerService
    {
        #region Private Members

        /// <summary>
        /// Appservice Object declaration
        /// </summary>
        private CustomerAppService _appService;

        /// <summary>
        /// The logger
        /// </summary>
        private ILoggerFacade _logger;
        private ILoggerFacade _uiLogger;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryService"/> class.
        /// </summary>
        public CustomerService()
        {
            _appService = new CustomerAppService();
            _logger = new EventLogger.EventLogger(ConfigurationManager.AppSettings["ApplicationName"]);
            _uiLogger = new EventLogger.EventLogger(ConfigurationManager.AppSettings["UILayer"]);
        }

        #endregion

        #region Customer

        //F001
        public List<PropertyDTO> GetAllEmirates(int countryID)
        {
            try
            {
                return _appService.GetAllEmirates(countryID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F001
        public List<CityDTO> GetAllEmirates()
        {
            try
            {
                return _appService.GetAllEmirates();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F002
        public List<AreaDTO> GetAllAreas(int emirateID)
        {
            try
            {
                return _appService.GetAllAreas(emirateID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F002
        public List<AreaDTO> GetAllAreas()
        {
            try
            {
                return _appService.GetAllAreas();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F003
        public List<NationalityDTO> GetAllNationality()
        {
            try
            {
                return _appService.GetAllNationality();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F004
        public List<IdentificationTypeDTO> GetIdentitificationTypes()
        {
            try
            {
                return _appService.GetIdentitificationTypes();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F005
        public List<CardCenterDTO> GetAllCardCentres()
        {
            try
            {
                return _appService.GetAllCardCentres();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }


        public List<CardCenterDTO> GetAllCardCentresForIdentity()
        {
            try
            {
                return _appService.GetAllCardCentresForIdentity();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public List<CardCenterDTO> GetAllCardCentresForNonIdentity()
        {
            try
            {
                return _appService.GetAllCardCentresForNonIdentity();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }


        //F31
        public List<CustomerStatusDTO> GetAllCustomerStatus()
        {
            try
            {
                return _appService.GetAllCustomerStatus();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F32
        public List<StatusReasonDTO> GetAllCustomerStatusReasons(int statusID)
        {
            try
            {
                return _appService.GetAllCustomerStatusReasons(statusID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F86
        public CustomerARDTO GetCustomerInformation(string financialAccountNumber)
        {
            try
            {
                return _appService.GetCustomerInformation(financialAccountNumber);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F87
        public int UpdateCustomerInfo(CustomerDTO customerDto)
        {
            try
            {
                if (customerDto.AccountTypeID == 0)
                {
                    if (customerDto.NotificationThreshold >= customerDto.SuspensionThreshold)
                        //throw new ValidationException(Resources.PostPaidMessge);
                        throw new ValidationException(GetNotificationMessageByCode("service-PostPaidMessge").MessageBody);
                }
                else if (customerDto.AccountTypeID == 1)
                {
                    if (customerDto.NotificationThreshold <= customerDto.SuspensionThreshold)
                        //throw new ValidationException(Resources.PrePaidMessage);
                        throw new ValidationException(GetNotificationMessageByCode("service-PrePaidMessage").MessageBody);
                }
                return _appService.UpdateCustomerInfo(customerDto);
            }
            catch (ValidationException e)
            {
                throw this.CustomException(e.Message);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public int UpdateCustomerInformation(CustomerDTO customerDto, List<CustomerAttachmentDTO> CustomerAttachments)
        {
            int CustomerID;
            try
            {
                if (customerDto.CustomerID >= 0) //update
                {
                    if (customerDto.AccountTypeID == 0)
                    {
                        if (customerDto.NotificationThreshold >= customerDto.SuspensionThreshold)
                            //throw new ValidationException(Resources.PostPaidMessge);
                            throw new ValidationException(GetNotificationMessageByCode("service-PostPaidMessge").MessageBody);
                    }
                    else if (customerDto.AccountTypeID == 1)
                    {
                        if (customerDto.NotificationThreshold <= customerDto.SuspensionThreshold)
                            //throw new ValidationException(Resources.PrePaidMessage);
                            throw new ValidationException(GetNotificationMessageByCode("service-PrePaidMessage").MessageBody);
                    }
                    try
                    {
                        CustomerID = _appService.UpdateCustomerInfo(customerDto);
                    }
                    catch (Exception ex)
                    {
                        throw this.HandleException(ex);
                    }
                    try
                    {
                        if (CustomerAttachments.Count > 0)
                        {
                            for (int i = 0; i < CustomerAttachments.Count; i++)
                                CustomerAttachments[i].CustomerID = CustomerID;

                            _appService.UploadAttachment(CustomerAttachments);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw this.HandleException(ex);
                    }
                }
                else //new account
                {
                    if (customerDto.AccountTypeID == 0)
                    {
                        if (customerDto.NotificationThreshold >= customerDto.SuspensionThreshold)
                            throw new ValidationException(GetNotificationMessageByCode("service-PostPaidMessge").MessageBody);
                    }
                    else if (customerDto.AccountTypeID == 1)
                    {
                        if (customerDto.NotificationThreshold <= customerDto.SuspensionThreshold)
                            throw new ValidationException(GetNotificationMessageByCode("service-PrePaidMessage").MessageBody);
                    }
                    try
                    {
                        CustomerID = _appService.UpdateCustomerInfo(customerDto);
                    }
                    catch (Exception ex)
                    {
                        throw this.HandleException(ex);
                    }
                    try
                    {
                        if (CustomerAttachments.Count > 0)
                        {
                            for (int i = 0; i < CustomerAttachments.Count; i++)
                                CustomerAttachments[i].CustomerID = CustomerID;

                            _appService.UploadAttachment(CustomerAttachments);
                        }
                    }
                    catch (Exception ex)
                    {
                        _appService.DeleteCsutomerFromCMSOrRequest(CustomerID, null);
                        throw this.HandleException(ex);
                    }
                }
                return CustomerID;
            }
            catch (ValidationException e)
            {
                throw this.CustomException(e.Message);
            }
        }

        //F88
        public List<CustomerClassificationDTO> GetCustomerClassification()
        {
            try
            {
                return _appService.GetCustomerClassification();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F89
        //public List<ProductDTO> GetAllProduct()
        //{
        //    try
        //    {
        //        var res = _appService.GetAllProduct();
        //        return res;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw this.HandleException(ex);
        //    }
        //}
        public List<ProductDTO> GetAllProduct(int? productCategoryID)
        {
            try
            {
                return _appService.GetAllProduct(productCategoryID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F90
        public bool UpdateUpliftDiscountProduct(int customerID, int UpliftID, BaseDTO Audit)
        {
            try
            {
                return _appService.UpdateUpliftDiscountProduct(customerID, UpliftID, Audit);
            }
            catch (ValidationException e)
            {
                throw this.CustomException(e.Message);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public int GetPushNotification(int BenificaryId)
        {
            try
            {
                return _appService.GetPushNotification(BenificaryId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public bool UpdatePushNotification(int BenificaryId, int isPushEnabled, int UserID, int LocationId)
        {
            try
            {
                return _appService.UpdatePushNotification(BenificaryId, isPushEnabled, UserID, LocationId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F91
        public List<UpliftDiscountDTO> GetAllUpliftDiscountProducts(int customerID)
        {
            try
            {
                return _appService.GetAllUpliftDiscountProducts(customerID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F92
        public List<CustomerGroupDTO> GetAllCustomerGroups(int customerID, string groupName)
        {
            try
            {
                return _appService.GetAllCustomerGroups(customerID, groupName);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }


        //F93
        public bool UpdateCustomerGroup(CustomerGroupDTO dto)
        {
            try
            {
                return _appService.UpdateCustomerGroup(dto);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //94
        public bool IsCustomerGroupInUse(int customerId, int customerGroupId)
        {
            try
            {
                return _appService.IsCustomerGroupInUse(customerId, customerGroupId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F95
        public bool DeleteCustomerGroup(CustomerGroupDTO dto)
        {
            try
            {
                return _appService.DeleteCustomerGroup(dto);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F96
        public List<CustomerSearchDTO> SearchCustomerInfo(CustomerSearchDTO dto, int pageNo, int pageSize, out int rowCount)
        {
            try
            {
                return _appService.SearchCustomerInfo(dto, pageNo, pageSize, out rowCount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public List<CustomerSearchDTO> SearchCustomerForClosure(CustomerSearchDTO dto, int pageNo, int pageSize, out int rowCount)
        {
            try
            {
                return _appService.SearchCustomerForClosure(dto, pageNo, pageSize, out rowCount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public List<CustomerSearchDTO> SearchCustomerforPayment(CustomerSearchDTO dto, int pageNo, int pageSize, int IsRefund, out int rowCount)
        {
            try
            {
                return _appService.SearchCustomerforPayment(dto, pageNo, pageSize, IsRefund, out rowCount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public DebitCreditRequestDTO ViewCreditDebitRequest(int P_REQUESTID)
        {
            try
            {
                return _appService.ViewCreditDebitRequest(P_REQUESTID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public RefundRequestDTO ViewRefundRequest(int P_REQUESTID)
        {
            try
            {
                return _appService.ViewRefundRequest(P_REQUESTID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public VoucherRequestDTO ViewVoucherRequest(int P_REQUESTID)
        {
            try
            {
                return _appService.ViewVoucherRequest(P_REQUESTID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F97
        public List<CustomerAccountTypeDTO> GetAllAccountTypes()
        {
            try
            {
                return _appService.GetAllAccountTypes();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F99
        public bool UpdateBeneficiaryGroupInfo(List<CustomerBeneficiaryGroupDTO> dto)
        {
            try
            {
                return _appService.UpdateBeneficiaryGroupInfo(dto);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F100
        public List<CustomerStatusHistoryDTO> GetCustomerStatusHistory(int customerId)
        {
            try
            {
                return _appService.GetCustomerStatusHistory(customerId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F101
        public bool UpdateCustomerStatus(CustomerStatusDTO dto)
        {
            try
            {
                if (dto.FromDate == null || dto.ToDate == null)
                    //throw new ValidationException(Resources.UpdateCustomerStatusDateValidationMessage);
                    throw new ValidationException(GetNotificationMessageByCode("service-StatusDateVldtion").MessageBody);
                else if (dto.ToDate.Subtract(dto.FromDate).Days > 180)
                    //throw new ValidationException(Resources.UpdateCustomerStatusDateRangeMessage);
                    throw new ValidationException(GetNotificationMessageByCode("service-StatusDateRange").MessageBody);
                return _appService.UpdateCustomerStatus(dto);
            }
            catch (ValidationException e)
            {
                throw this.CustomException(e.Message);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F102
        public bool UpdateCustomerPIN(int customerId, int contactTypeId, string PIN, BaseDTO Audit)
        {
            try
            {
                if (!new DUC.CMS.Token.BLL.TokenAppService().IsNewPINPermitted(PIN, contactTypeId, customerId))
                    //throw new ValidationException(Resources.UpdatePINMessage);
                    throw new ValidationException(GetNotificationMessageByCode("service-UpdatePINMessage").MessageBody);
                return _appService.UpdateCustomerPIN(customerId, contactTypeId, PIN, Audit);
            }
            catch (ValidationException e)
            {
                throw this.CustomException(e.Message);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F103
        public bool SubmitSMSRequest(SMSMessageDTO dto)
        {
            try
            {
                return _appService.SubmitSMSRequest(dto);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F124
        public List<CustomerBeneficiarySearchDTO> SearchCustomerBeneficiary(CustomerBeneficiarySearchDTO dto, int pageNo, int pageSize, out int rowCount)
        {
            try
            {
                return _appService.SearchCustomerBeneficiary(dto, pageNo, pageSize, out rowCount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F128
        public List<PaymentMethodDTO> GetAllPaymentMethods()
        {
            try
            {
                return _appService.GetAllPaymentMethods();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F129
        public bool AddPayment(CustomerPaymentTransactionDTO dto)
        {

            try
            {
                if ((dto.PaymentTypeID == (int)PaymentType.DebitNote || dto.PaymentTypeID == (int)PaymentType.CreditNote) && dto.Amount == 0)
                    //throw new ValidationException(Resources.RechargeAmountValidationMessage);
                    throw new ValidationException(GetNotificationMessageByCode("service-RechargeAmount").MessageBody);

                if ((dto.PaymentTypeID != (int)PaymentType.CreditNote && dto.PaymentTypeID != (int)PaymentType.DebitNote && dto.PaymentTypeID != (int)PaymentType.Refund))
                //if ((dto.PaymentTypeID != (int)PaymentType.CreditNote && dto.PaymentTypeID != (int)PaymentType.DebitNote))
                {
                    if (dto.Amount == null || !IsValidRechargeAmount((decimal)dto.Amount))
                        //throw new ValidationException(Resources.RechargeAmountValidationMessage);
                        throw new ValidationException(GetNotificationMessageByCode("service-RechargeAmount").MessageBody);
                }
                else if (dto.Amount == null)
                    //throw new ValidationException(Resources.RechargeAmountValidationMessage);
                    throw new ValidationException(GetNotificationMessageByCode("service-RechargeAmount").MessageBody);

                return _appService.AddPayment(dto);
            }
            catch (ValidationException e)
            {
                throw this.CustomException(e.Message);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F130
        public List<CustomerPaymentDTO> GetPaymentHistory(int customerId, int pageNo, int pageSize, out int rowCount)
        {
            try
            {
                return _appService.GetPaymentHistory(customerId, pageNo, pageSize, out rowCount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public CustomerPaymentDTO GetCustomerPaymentByPaymentID(int PaymentID)
        {
            try
            {
                return _appService.GetCustomerPaymentByPaymentID(PaymentID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F131
        public CustomerBalanceDTO GetCustomerBalance(int customerId)
        {
            try
            {
                return _appService.GetCustomerBalance(customerId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F132
        public DateTime? GetMinCutomerTransactionDate(int customerId)
        {
            try
            {
                return _appService.GetMinCutomerTransactionDate(customerId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F133
        public List<AccountBalanceDTO> GetAccountBalance(int customerId, DateTime FromDate, DateTime ToDate, int pageNo, int pageSize, out int rowCount)
        {
            try
            {
                return _appService.GetAccountBalance(customerId, FromDate, ToDate, pageNo, pageSize, out rowCount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F134
        public List<TransactionSearchDTO> GetCustomerTransactions(TransactionSearchDTO dto, int pageNo, int pageSize, out int rowCount, out decimal PaidAmountSum, out decimal AdjustmentAmountSum, out decimal TotalAmountSum, out decimal PaidVATSum)
        {
            try
            {
                return _appService.GetCustomerTransactions(dto, pageNo, pageSize, out rowCount, out PaidAmountSum, out AdjustmentAmountSum, out TotalAmountSum, out PaidVATSum);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F134
        public List<TransactionSearchInvDTO> TransactionSearchInv(TransactionSearchInvDTO dto, int pageNo, int pageSize, out int rowCount,
            out decimal PaidAmountSum, out decimal AdjustmentAmountSum, out decimal TotalAmountSum, out decimal TotalVAT)
        {
            try
            {
                return _appService.TransactionSearchInv(dto, pageNo, pageSize, out rowCount, out PaidAmountSum, out AdjustmentAmountSum, out TotalAmountSum, out TotalVAT);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }


        //F137
        public CustomerBillingDTO GetCustomerBillingInfo(int customerId, string invoiceNumber)
        {
            try
            {
                return _appService.GetCustomerBillingInfo(customerId, invoiceNumber);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F138
        public List<CustomerUnBilledDTO> GetCustomerUnBilledInfo(int customerId, string VATInvoiceNum, int pageNo, int pageSize, out int rowCount,
            out decimal PaidAmountSum, out decimal AdjustmentAmountSum, out decimal TotalAmountSum, out decimal TotalVatAmount)
        {
            try
            {
                return _appService.GetCustomerUnBilledInfo(customerId, VATInvoiceNum, pageNo, pageSize, out rowCount, out PaidAmountSum, out AdjustmentAmountSum, out TotalAmountSum, out TotalVatAmount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F139
        public EmployeeHRDTO GetHREmployeeData(int employeeNumber)
        {
            try
            {
                return _appService.GetHREmployeeData(employeeNumber);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F140
        public int IsEmployeeCardAlreadyIssued(int employeeID, int CustomerID, out string cardSerialNo)
        {
            try
            {
                return _appService.IsEmployeeCardAlreadyIssued(employeeID, CustomerID, out cardSerialNo);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F141
        public int UpdateIdentityCardInfo(EmployeeIdentityCardDTO dto)
        {
            try
            {
                return _appService.UpdateIdentityCardInfo(dto);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F147
        public List<CustomerBillingDateDTO> GetCustomerBillingDates(int customerId)
        {
            try
            {
                return _appService.GetCustomerBillingDates(customerId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F148
        public List<CustomerBillingPeriodDTO> GetCustomerBillingPeriod(int customerId)
        {
            try
            {
                return _appService.GetCustomerBillingPeriod(customerId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F149
        public List<CustomerBillingSearchDTO> SearchCustomerBilling(CustomerBillingSearchDTO searchCriteria, int pageNo, int pageSize, out int rowCount)
        {
            try
            {
                return _appService.SearchCustomerBilling(searchCriteria, pageNo, pageSize, out rowCount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F157    -- this function is discarded to be used in system sitting only
        //public List<UpliftDiscountDTO> GetUpliftDiscountProductById(int customerID, int productID)
        //{
        //    try
        //    {
        //        return _appService.GetUpliftDiscountProductById(customerID, productID);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw this.HandleException(ex);
        //    }
        //}

        //F158

        public List<CustomerGroupDTO> GetCustomerGroupById(int groupID)
        {
            try
            {
                return _appService.GetCustomerGroupById(groupID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F170
        public bool DeleteUpliftDiscountProduct(int customerID, int UpliftID, BaseDTO Audit)
        {
            try
            {
                return _appService.DeleteUpliftDiscountProduct(customerID, UpliftID, Audit);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F175
        public CustomerDTO GetCustomerInfo(int customerID)
        {
            try
            {
                return _appService.GetCustomerInfo(customerID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F184
        public IdentityCardDTO GetIdentityCardInfo(int employeeNumber, int CustomerID)
        {
            try
            {
                return _appService.GetIdentityCardInfo(employeeNumber, CustomerID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F189
        public List<CustomerStatusDTO> GetAllCustomerStatusByID(int customerID)
        {
            try
            {
                return _appService.GetAllCustomerStatusByID(customerID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F194
        public CustomerTransactionDTO GetTransactionSummary(int customerID, int? beneficiaryID, DateTime? fromDate, DateTime? toDate)
        {
            try
            {
                return _appService.GetTransactionSummary(customerID, beneficiaryID, fromDate, toDate);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public CustomerTransactionDTO GetTransactionSummaryInv(int customerID, int invoiceID, int? beneficiaryID, DateTime? fromDate, DateTime? toDate)
        {
            try
            {
                return _appService.GetTransactionSummaryInv(customerID, beneficiaryID, fromDate, toDate, invoiceID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }


        //F197
        public List<CustomerAccountTypeDTO> GetAllCustomerAccountTypes()
        {
            try
            {
                return _appService.GetAllCustomerAccountTypes();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F203
        public List<DUC.CMS.CustomerService.BLL.Dtos.ProductDTO> GetAllProductForDifferentialPricing(int customerID)
        {
            try
            {
                return _appService.GetAllProductForDifferentialPricing(customerID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F204
        public List<UpliftDiscountDTO> GetAllUpliftDiscountsForProduct(int productID)
        {
            try
            {
                return _appService.GetAllUpliftDiscountsForProduct(productID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F215
        public bool DeleteCustomerDriverCard(int paymentTokenID, int driverCardTokenID, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            try
            {
                return _appService.DeleteCustomerDriverCard(paymentTokenID, driverCardTokenID, UserID, LastUpdatedDate, LocationId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F216
        public List<MappedDriverDTO> GetAllCustomerDriverCardForToken(int PaymentTokenID)
        {
            try
            {
                return _appService.GetAllCustomerDriverCardForToken(PaymentTokenID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F218
        public bool HasModulePrivilege(string userName, Modules module)
        {
            try
            {
                return _appService.HasModulePrivilege(userName, (int)module);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F219
        public bool HasPagePrivilege(string userName, Pages page)
        {
            try
            {
                return _appService.HasPagePrivilege(userName, (int)page);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F220
        public bool HasFunctionPrivilege(string userName, Functions function)
        {
            try
            {
                return _appService.HasFunctionPrivilege(userName, (int)function);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F224
        public bool SubmitEmailRequest(EmailDTO dto)
        {
            try
            {
                return _appService.SubmitEmailRequest(dto);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F225
        //public NotificationMessageDto GetNotificationMessageByCode1(string NotificationMsgCode)
        //{
        //    try
        //    {
        //        return _appService.GetNotificationMessageByCode1(NotificationMsgCode);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw this.HandleException(ex);
        //    }
        //}

        //F226
        public int GetMinimumAccountActivationBalance()
        {
            try
            {
                return _appService.GetMinimumAccountActivationBalance();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F229
        public Functions[] GetPrivilegedFunctionsForPage(string UserName, int PageID)
        {
            try
            {
                var data = new DUC.CMS.Token.BLL.TokenAppService().GetPrivilegedFunctionsForPage(UserName, PageID);
                return (Functions[])(object)data;
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F279
        public bool AddCustomerInvoicePreference(int CustomerID, int InvoiceTypeID, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            try
            {
                return _appService.AddCustomerInvoicePreference(CustomerID, InvoiceTypeID, UserID, LastUpdatedDate, LocationId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F280
        public bool DeleteCustomerInvoicePreference(int Customer_ID, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            try
            {
                return _appService.DeleteCustomerInvoicePreference(Customer_ID, UserID, LastUpdatedDate, LocationId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F281
        public CustomerRefundDTO GetCustomerRefundData(string Customer_CODE)
        {
            try
            {
                return _appService.GetCustomerRefundData(Customer_CODE);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F282
        public bool RefundCustomer(int Customer_ID, string docRef, string Remarks, BaseDTO Audit, decimal RefundAmount)
        {
            try
            {
                return _appService.RefundCustomer(Customer_ID, docRef, Remarks, Audit, RefundAmount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F285
        public List<SearchRequestResultDTO> SearchRequest(SearchRequestDTO dto, int? ModuleID)
        {
            try
            {
                return _appService.SearchRequest(dto, ModuleID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }



        //F296
        public List<CustomerAttachmentDTO> GetAllCustomerAttachments(int CustomerID)
        {
            try
            {
                return _appService.GetAllCustomerAttachments(CustomerID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //

        //f304
        public bool IsRefundAllowedForCustomer(int customer_id)
        {
            try
            {
                return _appService.IsRefundAllowedForCustomer(customer_id);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //305
        public int GetCustomerInvoicePreference(int customerID)
        {
            try
            {
                return _appService.GetCustomerInvoicePreference(customerID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //306
        public bool AddTerminationPendingCustomer(int customerID, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            try
            {
                return _appService.AddTerminationPendingCustomer(customerID, UserID, LastUpdatedDate, LocationId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //307
        public bool AddServiceTransaction(int ServiceID, int CustomerID, int? BeneficiaryID, int? TokenID, int UserId, int LastUpdatedUserID, DateTime LastUpdatedDate, int LastLocationID)
        {
            try
            {
                return _appService.AddServiceTransaction(ServiceID, CustomerID, BeneficiaryID, TokenID, UserId, LastUpdatedUserID, LastUpdatedDate, LastLocationID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //308
        public List<FeeCustomerPaymentTransactionDTO> GetCreditDebitNoteHistory(int CustomerID, int PageID, int PageSize, out int RowCount)
        {
            try
            {
                return _appService.GetCreditDebitNoteHistory(CustomerID, PageID, PageSize, out RowCount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //309
        public string GetOrderNumber(int TokenID)
        {
            try
            {
                return _appService.GetOrderNumber(TokenID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //310
        public List<ProductDTO> GetAllNonDieselProducts()
        {
            try
            {
                return _appService.GetAllNonDieselProducts();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //311
        public PropertyDTO GetCurrentCustomerStatus(int CustomerID)
        {
            try
            {
                return _appService.GetCurrentCustomerStatus(CustomerID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //312
        public RequestServiceFeeDTO ViewServiceFeeRequest(int RequestID)
        {
            try
            {
                return _appService.ViewServiceFeeRequest(RequestID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //313
        public bool UpdateServiceFee(ServiceFeeDTO entity)
        {
            try
            {
                return _appService.UpdateServiceFee(entity);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //314
        public bool IsRenewalRequest(int TokenID)
        {
            try
            {
                return _appService.IsRenewalRequest(TokenID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F315
        public bool RemoveAttachment(CustomerAttachmentDTO dto)
        {
            try
            {
                return _appService.RemoveAttachment(dto);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F318
        public bool IsIDAlreadyRegistered(int Mode, int IDType, string IDNumber, int? CUSTOMERID, int? BeneficiaryID, out string pMessage)
        {
            try
            {
                return _appService.IsIDAlreadyRegistered(Mode, IDType, IDNumber, CUSTOMERID, BeneficiaryID, out pMessage);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F321
        public List<PropertyDTO> GetAllFamily()
        {
            try
            {
                return _appService.GetAllFamily();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F322
        public OpeningClosingBalanceDTO GetOpeningClosingBalance(int CustomerID, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                return _appService.GetOpeningClosingBalance(CustomerID, FromDate, ToDate);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F324
        public int IsDieselRestricted(int tokenID)
        {
            try
            {
                return _appService.IsDieselRestricted(tokenID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F325
        public List<LocationDTO> GetAllCMSLocations()
        {
            try
            {
                return _appService.GetAllCMSLocations();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }

        }

        //F326
        public bool UpdateCeilingLimit(int CeilingLimitID, decimal LimitValue, int UserId, int LocationId)
        {
            try
            {
                return _appService.UpdateCeilingLimit(CeilingLimitID, LimitValue, UserId, LocationId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public List<DictionaryDTO> GetAllGLCostCentre()
        {
            try
            {
                return _appService.GetGLCostCentre();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //327
        public bool TerminateCustomer(int customerID, int UserId, int LocationID, out int RefundAmount)
        {
            try
            {
                return _appService.TerminateCustomer(customerID, UserId, LocationID, out RefundAmount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }


        public CeilingLimitDTO GetCeilingLimit()
        {
            try
            {
                return _appService.GetCeilingLimit();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public DictionaryDTO GetYearByID(int yearID)
        {
            try
            {
                return _appService.GetYearByID(yearID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }

        }

        public bool IsPremierAccessGranted(int userID)
        {
            try
            {
                return _appService.IsPremierAccessGranted(userID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public bool IsUpdateVehicleInfoGranted(int userID)
        {
            try
            {
                return _appService.IsUpdateVehicleInfoGranted(userID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public bool IsViewAuditGranted(int userID)
        {
            try
            {
                return _appService.IsViewAuditGranted(userID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public NotificationMessageDto GetNotificationMessageByCode(string MessageCode)
        {
            try
            {
                return _appService.GetNotificationMessageByCode(MessageCode);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public List<PaymentTypeDTO> GetCreditDebitPaymentTypes()
        {
            try
            {
                return _appService.GetCreditDebitPaymentTypes();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }

        }

        public int GetTerminationCutOffPeriod()
        {
            try
            {
                return _appService.GetTerminationCutOffPeriod();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public bool IsCustomerCodeValid(string code)
        {
            try
            {
                return _appService.IsCustomerCodeValid(code);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        #endregion

        #region Beneficiary

        ///F35
        /// <summary>
        /// Get all beneficiary status
        /// </summary>
        /// <returns></returns>
        public List<Beneficiary.BLL.DTO.StatusDTO> GetAllBeneficiaryStatus()
        {
            try
            {
                return new DUC.CMS.Beneficiary.BLL.BeneficiaryAppService().GetAllBeneficiaryStatus();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F36
        /// <summary>
        /// Get all beneficiary status reason
        /// </summary>
        /// <returns></returns>
        public List<Beneficiary.BLL.DTO.StatusReasonDTO> GetAllBeneficiaryStatusReasons(int statusID)
        {
            try
            {
                return new DUC.CMS.Beneficiary.BLL.BeneficiaryAppService().GetAllBeneficiaryStatusReasons(statusID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public List<DUC.CMS.Token.BLL.DTO.TokenSearchDTO> AccountSearchToken(DUC.CMS.Token.BLL.DTO.AccountTokenSearchDTO tokenSearchDTO, int pageNo, int pageSize, out int rowCount)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().AccountTokenSearch(tokenSearchDTO, pageNo, pageSize, out rowCount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F98
        /// <summary>
        /// Gets all the beneficiaries with details based on search criteria
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<DUC.CMS.Beneficiary.BLL.DTO.BeneficiarySearchDTO> SearchBeneficiaries(DUC.CMS.Beneficiary.BLL.DTO.BeneficiarySearchDTO dto, int pageNo, int pageSize, out int rowCount)
        {
            try
            {
                return new DUC.CMS.Beneficiary.BLL.BeneficiaryAppService().SearchBeneficiaries(dto, pageNo, pageSize, out rowCount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F104
        /// <summary>
        /// If the beneficiary ID is present in DTO, this is an update operation. 
        /// Else add the information of the beneficiary and returns the newly created beneficiary ID
        /// </summary>
        /// <param name="BeneficiaryDTO"></param>
        /// <returns></returns>
        public int UpdateBeneficiaryInfo(DUC.CMS.Beneficiary.BLL.DTO.BeneficiaryDTO BeneficiaryDTO)
        {
            try
            {
                return new DUC.CMS.Beneficiary.BLL.BeneficiaryAppService().UpdateBeneficiaryInfo(BeneficiaryDTO);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F105
        /// <summary>
        /// Updates the customer with the newly generated PIN
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="beneficiaryID"></param>
        /// <param name="pinNo"></param>
        /// <returns></returns>
        public bool UpdateBeneficiaryPIN(int customerID, int beneficiaryID, string beneficiaryCode, string pinNo, Beneficiary.BLL.DTO.BaseDTO Audit)
        {
            try
            {
                if (!new DUC.CMS.Token.BLL.TokenAppService().IsNewPINPermitted(pinNo, 2, customerID))
                    //throw new ValidationException(Resources.UpdatePINMessage);
                    throw new ValidationException(GetNotificationMessageByCode("service-UpdatePINMessage").MessageBody);
                return new DUC.CMS.Beneficiary.BLL.BeneficiaryAppService().UpdateBeneficiaryPIN(beneficiaryID, beneficiaryCode, pinNo, Audit);
            }
            catch (ValidationException e)
            {
                throw this.CustomException(e.Message);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F108
        /// <summary>
        /// Get the beneficiary details for the selected beneficiary
        /// </summary>
        /// <param name="beneficiaryID"></param>
        /// <returns></returns>
        public DUC.CMS.Beneficiary.BLL.DTO.BeneficiaryDTO GetBeneficiaryInfo(int beneficiaryID)
        {
            try
            {
                return new DUC.CMS.Beneficiary.BLL.BeneficiaryAppService().GetBeneficiaryInfo(beneficiaryID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F109
        /// <summary>
        /// Gets all the beneficiary status history details for the selected beneficiary
        /// </summary>
        /// <param name="beneficiaryID"></param>
        /// <returns></returns>
        public List<DUC.CMS.Beneficiary.BLL.DTO.BeneficiaryStatusHistoryDTO> GetBeneficiaryStatusHistory(int beneficiaryID)
        {
            try
            {
                return new DUC.CMS.Beneficiary.BLL.BeneficiaryAppService().GetBeneficiaryStatusHistory(beneficiaryID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F110
        /// <summary>
        /// Updates the beneficiary status and status reason information
        /// </summary>
        /// <param name="beneficiaryStatusDTO"></param>
        /// <returns></returns>
        public bool UpdateBeneficiaryStatus(DUC.CMS.Beneficiary.BLL.DTO.BeneficiaryStatusDTO beneficiaryStatusDTO)
        {
            try
            {
                return new DUC.CMS.Beneficiary.BLL.BeneficiaryAppService().UpdateBeneficiaryStatus(beneficiaryStatusDTO);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F135
        /// <summary>
        /// Gets  the beneficiary transaction details based on search criteria
        /// </summary>
        /// <param name="transactionSearchDTO"></param>
        /// <returns></returns>
        public List<DUC.CMS.Beneficiary.BLL.DTO.TransactionSearchDTO> GetBeneficiaryTransaction(DUC.CMS.Beneficiary.BLL.DTO.TransactionSearchDTO transactionSearchDTO,
            int pageNo, int pageSize, out int rowCount, out decimal PaidAmountSum, out decimal AdjustmentAmountSum, out decimal TotalAmountSum, out decimal PaidVATSum)
        {
            try
            {
                return new DUC.CMS.Beneficiary.BLL.BeneficiaryAppService().GetBeneficiaryTransaction(transactionSearchDTO, pageNo, pageSize, out rowCount,
                    out PaidAmountSum, out AdjustmentAmountSum, out TotalAmountSum, out PaidVATSum);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F190
        public List<Beneficiary.BLL.DTO.StatusDTO> GetAllBeneficiaryStatusByID(int beneficiaryID)
        {
            try
            {
                return new DUC.CMS.Beneficiary.BLL.BeneficiaryAppService().GetAllBeneficiaryStatusByID(beneficiaryID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public bool ValidateTokenRestriction(int TokenId, decimal? DailyAmountLimit, decimal? WeeklyAmountLimit, decimal? MonthlyAmountLimit, decimal? YearlyAmountLimit)
        {
            try
            {
                return new DUC.CMS.Beneficiary.BLL.BeneficiaryAppService().ValidateTokenRestriction(TokenId, DailyAmountLimit, WeeklyAmountLimit, MonthlyAmountLimit, YearlyAmountLimit);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        #endregion

        #region Token

        ///F36
        /// <summary>
        /// Get all token status reason
        /// </summary>
        /// <returns></returns>
        public List<DUC.CMS.Token.BLL.DTO.StatusReasonDTO> GetAllTokenStatusReasons(int statusID)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetAllTokenStatusReasons(statusID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F39
        /// <summary>
        /// Get all token status
        /// </summary>
        /// <returns></returns>
        public List<DUC.CMS.Token.BLL.DTO.StatusDTO> GetAllTokenStatus()
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetAllTokenStatus();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F43
        /// <summary>
        /// Get all vehicle make
        /// </summary>
        /// <returns></returns>
        public List<DUC.CMS.Token.BLL.DTO.VehicleMakeDTO> GetAllVehicleMakes()
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetAllVehicleMakes();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F51
        /// <summary>
        /// Get all vehicle models
        /// </summary>
        /// <returns></returns>
        public List<DUC.CMS.Token.BLL.DTO.VehicleMakeModelDTO> GetAllVehicleModels()
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetAllVehicleModels();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F
        /// <summary>
        /// Get all Customer TokenTypes
        /// </summary>
        /// <returns></returns>
        public List<DUC.CMS.Token.BLL.DTO.PropertyDTO> GetCustomerTokenTypes()
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetCustomerTokenTypes();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public List<DUC.CMS.Token.BLL.DTO.PropertyDTO> GetAllTokenTypes()
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetAllTokenTypes();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F111
        /// <summary>
        /// If tokenID is present in DTO then insert else update
        /// If the Token Type is Vehicle Tag, the vehicle information will be added to the VehicelInfo table
        /// </summary>
        /// <param name="tokenDTO"></param>
        /// <returns>Token ID</returns>
        public int UpdateTokenInfo(DUC.CMS.Token.BLL.DTO.TokenDTO tokenDTO)
        {
            try
            {
                string ErrorMessage = string.Empty;
                if (tokenDTO.TokenTypeID == (int)TokenType.EmiratesID && tokenDTO.Serial == null)
                {
                    //throw new ValidationException(Resources.UpdateTokenInfoEmirateIDMessage);
                    throw new ValidationException(GetNotificationMessageByCode("service-EmirateIDInfo").MessageBody);
                }
                else if (tokenDTO.TokenTypeID == (int)TokenType.DriverCard && tokenDTO.RestrictionGroupID != null)
                {
                    // throw new ValidationException(Resources.UpdateTokenInfoDriverCardMessage);
                    throw new ValidationException(GetNotificationMessageByCode("service-DriverCardInfo").MessageBody);
                }
                else if (tokenDTO.TokenTypeID == (int)TokenType.VehicleTag && tokenDTO.VehicleInfoDTO == null)
                {
                    //throw new ValidationException(Resources.UpdateTokenInfoVehicleTagMessage);
                    throw new ValidationException(GetNotificationMessageByCode("service-VehicleTagInfo").MessageBody);
                }
                else if (tokenDTO.TokenTypeID == (int)TokenType.VehiclePlate && tokenDTO.VehicleInfoDTO == null)
                {
                    //throw new ValidationException(Resources.UpdateTokenInfoVehicleTagMessage);
                    throw new ValidationException(GetNotificationMessageByCode("service-VehicleTagInfo").MessageBody);
                }
                var result = new DUC.CMS.Token.BLL.TokenAppService().UpdateTokenInfo(tokenDTO, out ErrorMessage);
                if (string.IsNullOrEmpty(ErrorMessage))
                    return result;
                throw new ValidationException(ErrorMessage);
            }
            catch (ValidationException e)
            {
                throw this.CustomException(e.Message);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F113
        /// <summary>
        /// Get a list of vehicle register details based on the search criteria
        /// </summary>
        /// <param name="makeID">Vehicle make ID</param>
        /// <param name="modelID">Vehicle model ID</param>
        /// <param name="year">Year</param>
        /// <returns></returns>
        public List<DUC.CMS.Token.BLL.DTO.VehicleRegisterSearchResultDTO> SearchVehicleRegister(int? makeID, int? modelID, int? year, int? CC, int? FUEL_INLET, int? FUEL_CAPACITY, int pageNo, int pageSize, out int rowCount)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().SearchVehicleRegister(makeID, modelID, year, CC, FUEL_INLET, FUEL_CAPACITY, pageNo, pageSize, out rowCount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F115
        /// <summary>
        /// Get all vehicle types
        /// </summary>
        /// <returns></returns>
        public List<DUC.CMS.Token.BLL.DTO.VehicleTypesDTO> GetVehicleTypes()
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetAllVehicleTypes();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F116
        /// <summary>
        /// Get all vehicle plate colors
        /// </summary>
        /// <returns></returns>
        public List<DUC.CMS.Token.BLL.DTO.VehiclePlateColorDTO> GetVehiclePlateColors()
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetVehiclePlateColors();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F117
        /// <summary>
        /// Get the token restriction details for the selected token
        /// </summary>
        /// <param name="tokenID"></param>
        /// <returns></returns>
        public List<DUC.CMS.Token.BLL.DTO.TokenRestrictionDTO> GetTokenRestrictionInfo(int tokenID)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetTokenRestrictionInfo(tokenID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F118
        /// <summary>
        /// Updates the token restriction details
        /// </summary>
        /// <param name="tokenRestrictionDTO"></param>
        /// <returns></returns>
        public int UpdateTokenRestriction(DUC.CMS.Token.BLL.DTO.TokenRestrictionDTO tokenRestrictionDTO)
        {
            try
            {
                if (tokenRestrictionDTO.TokenTypeID != 1 && (tokenRestrictionDTO.RequireOdometerInput || tokenRestrictionDTO.RequireDriverCard))
                {

                    //throw new ValidationException(Resources.UpdateTokenRestriction);
                    throw new ValidationException(GetNotificationMessageByCode("service-TokenRestriction").MessageBody);
                }

                return new DUC.CMS.Token.BLL.TokenAppService().UpdateTokenRestriction(tokenRestrictionDTO);


                /* var tokenAppService = new DUC.CMS.Token.BLL.TokenAppService();
                 var beneficiaryAppService = new DUC.CMS.Beneficiary.BLL.BeneficiaryAppService();
                 decimal? dailyLimit = null, weeklyLimit = null, monthlyLimit = null, yearlyLimit = null;
                 if (!string.IsNullOrEmpty(tokenRestrictionDTO.RsAmount))
                 {

                 }

                 if (tokenRestrictionDTO.TokenTypeID != 1 && (tokenRestrictionDTO.RequireOdometerInput || tokenRestrictionDTO.RequireDriverCard))
                 {

                     //throw new ValidationException(Resources.UpdateTokenRestriction);
                     throw new ValidationException(GetNotificationMessageByCode("service-TokenRestriction").MessageBody);
                 }

                 foreach (var rsAmount in tokenRestrictionDTO.RestrictionAmountDTO)
                 {
                     if (rsAmount.AllowedAmount != null && rsAmount.TimeFrequencyID == 0) //Daily
                         dailyLimit = rsAmount.AllowedAmount;
                     else if (rsAmount.AllowedAmount != null && rsAmount.TimeFrequencyID == 1) //Weekly
                         weeklyLimit = rsAmount.AllowedAmount;
                     else if (rsAmount.AllowedAmount != null && rsAmount.TimeFrequencyID == 3) //Monthly
                         monthlyLimit = rsAmount.AllowedAmount;
                     else if (rsAmount.AllowedAmount != null && rsAmount.TimeFrequencyID == 4) //Yearly
                         yearlyLimit = rsAmount.AllowedAmount;
                 }

                 if (!beneficiaryAppService.ValidateTokenRestriction(tokenRestrictionDTO.TokenID.Value, dailyLimit, weeklyLimit, monthlyLimit, yearlyLimit))
                 {

                     //throw new ValidationException(Resources.UpdateTokenRestriction);
                     throw new ValidationException("20003:Token restriction amount limit should be smaller than beneficiary restriction amount limit.");
                 }

                 return tokenAppService.UpdateTokenRestriction(tokenRestrictionDTO);
                 */
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F119
        /// <summary>
        /// Gets all the tokens based on the search criteria
        /// </summary>
        /// <param name="tokenSearchDTO"></param>
        /// <returns></returns>
        public List<DUC.CMS.Token.BLL.DTO.TokenSearchDTO> SearchToken(DUC.CMS.Token.BLL.DTO.TokenSearchDTO tokenSearchDTO, int pageNo, int pageSize, out int rowCount)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().SearchToken(tokenSearchDTO, pageNo, pageSize, out rowCount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public List<DUC.CMS.Token.BLL.DTO.CustomerTokenSearchDTO> CustomerSearchToken(DUC.CMS.Token.BLL.DTO.CustomerTokenSearchDTO tokenSearchDTO, int pageNo, int pageSize, out int rowCount)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().CustomerSearchToken(tokenSearchDTO, pageNo, pageSize, out rowCount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F120
        /// <summary>
        /// Get the token details for the selected token
        /// </summary>
        /// <param name="tokenID"></param>
        /// <returns></returns>
        public DUC.CMS.Token.BLL.DTO.TokenDTO GetTokenInfo(int tokenID)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetTokenInfo(tokenID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public List<DUC.CMS.Token.BLL.DTO.TokenDTO> GetBatchTokenInfo(int personalizationID)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetBatchTokenInfo(personalizationID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F121
        /// <summary>
        /// Gets all the token status history details for the selected token
        /// </summary>
        /// <param name="tokenID"></param>
        /// <returns></returns>
        public List<DUC.CMS.Token.BLL.DTO.TokenStatusHistoryDTO> GetTokenStatusHistory(int tokenID, int pageNo, int pageSize, out int rowCount)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetTokenStatusHistory(tokenID, pageNo, pageSize, out rowCount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F122
        /// <summary>
        /// Updates the token status and status reason information
        /// </summary>
        /// <param name="tokenStatusDTO"></param>
        /// <returns></returns>
        public bool UpdateTokenStatus(DUC.CMS.Token.BLL.DTO.TokenStatusDTO tokenStatusDTO)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().UpdateTokenStatus(tokenStatusDTO);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F123
        /// <summary>
        /// Updates the restriction group details
        /// </summary>
        /// <param name="restrictionGroupDTO"></param>
        /// <returns></returns>
        public int UpdateRestrictionGroupProfile(DUC.CMS.Token.BLL.DTO.RestrictionGroupDTO restrictionGroupDTO)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().UpdateRestrictionGroupProfile(restrictionGroupDTO);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F125
        /// <summary>
        /// Creates a new token ID with the old token’s serial numbers and the new beneficiary ID in the Token table. 
        /// Create an entry in ShiftedTokens table with the old token and new token details. 
        /// Updates the old token status to De-Coupled. The new token will be in Active status
        /// </summary>
        /// <param name="tokenID"></param>
        /// <param name="newCustomerID"></param>
        /// <param name="newBeneficiaryID"></param>
        /// <returns></returns>
        public bool ChangeTokenBeneficiary(int tokenID, int newCustomerID, int newBeneficiaryID, int UserID, DateTime LastUpdatedDate, int LocationId, out int newTokenID)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().ChangeTokenBeneficiary(tokenID, newCustomerID, newBeneficiaryID, UserID, LastUpdatedDate, LocationId, out newTokenID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F126
        /// <summary>
        /// Add the information of the all the tokens in the batch; 
        /// If the Token Type is Vehicle Tag, the vehicle information will be added to the VehicelInfo table.
        /// </summary>
        /// <param name="tokenDTO"></param>
        /// <returns></returns>
        public List<DUC.CMS.Token.BLL.DTO.BatchTokenDTO> AddBatchTokenInfo(List<DUC.CMS.Token.BLL.DTO.BatchTokenDTO> tokenDTO)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().AddBatchTokenInfo(tokenDTO);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F127
        /// <summary>
        /// Add the batch token restriction. This will be a restriction group name
        /// </summary>
        /// <param name="tokenRestrictionDTO"></param>
        /// <returns></returns>
        public bool AddBatchTokenRestriction(List<DUC.CMS.Token.BLL.DTO.TokenRestrictionDTO> tokenRestrictionDTO)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().AddBatchTokenRestriction(tokenRestrictionDTO);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F142
        /// <summary>
        /// Add the issue request details to PERSONALIZATION_ORDER table with status as ‘Active’ 
        /// and updates the Token table with the order id. 
        /// </summary>
        /// <param name="issueTokenDTO"></param>
        /// <returns></returns>
        public bool AddPersonalizationRequest(DUC.CMS.Token.BLL.DTO.IssueTokenDTO issueTokenDTO)
        {
            try
            {
                if (issueTokenDTO.AppointmentDate == null || issueTokenDTO.CardCentreID == null)
                    throw new ValidationException(GetNotificationMessageByCode("OperationFailed").MessageBody);
                else
                    return new DUC.CMS.Token.BLL.TokenAppService().AddPersonalizationRequest(issueTokenDTO);
            }
            catch (ValidationException e)
            {
                throw this.CustomException(e.Message);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F143
        /// <summary>
        /// Add the issue request details to WORK_ORDER table with status as ‘Active’ and updates the Token table with the order id.
        /// </summary>
        /// <param name="issueTokenDTO"></param>
        /// <returns></returns>
        public bool AddWorkOrderRequest(DUC.CMS.Token.BLL.DTO.WorkOrderDTO workOrderDTO)
        {
            try
            {
                if (workOrderDTO.AppointDateTime == null || workOrderDTO.VehicleDepotID == null)
                    throw new ValidationException(GetNotificationMessageByCode("OperationFailed").MessageBody);
                else
                    return new DUC.CMS.Token.BLL.TokenAppService().AddWorkOrderRequest(workOrderDTO);
            }
            catch (ValidationException e)
            {
                throw this.CustomException(e.Message);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F144
        /// <summary>
        /// Checks if the token has been issued already and returns true; otherwise false
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="beneficiaryID"></param>
        /// <param name="tokenID"></param>
        /// <returns></returns>
        public bool IsReplacementIssueRequest(int tokenID)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().IsReplacementIssueRequest(tokenID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F145
        /// <summary>
        /// Changes the status of the old personalization order ID to ‘Cancelled’. 
        /// Add the new issue request details to PERSONALIZATION_ORDER table with status as ‘Pending’ 
        /// and updates the Token table with the new personalization order id.
        /// </summary>
        /// <param name="issueTokenDTO"></param>
        /// <returns></returns>
        public bool ReplacePersonalizationOrderRequest(DUC.CMS.Token.BLL.DTO.IssueTokenDTO dto)
        {
            try
            {
                if (dto.AppointmentDate == null || dto.CardCentreID == null)
                    throw new ValidationException(GetNotificationMessageByCode("OperationFailed").MessageBody);
                else
                    return new DUC.CMS.Token.BLL.TokenAppService().ReplacePersonalizationOrderRequest(dto);
            }
            catch (ValidationException e)
            {
                throw this.CustomException(e.Message);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F146
        /// <summary>
        /// Changes the status of the old work order ID to ‘cancelled’. 
        /// Add the new issue request details to WORK_ORDER table with status as ‘Active’ and 
        /// updates the Token table with the new work order id.
        /// </summary>
        /// <param name="issueTokenDTO"></param>
        /// <returns></returns>
        public bool ReplaceWorkOrderRequest(DUC.CMS.Token.BLL.DTO.WorkOrderDTO dto)
        {
            try
            {
                if (dto.AppointDateTime == null || dto.VehicleDepotID == null)
                    throw new ValidationException(GetNotificationMessageByCode("OperationFailed").MessageBody);
                else
                    return new DUC.CMS.Token.BLL.TokenAppService().ReplaceWorkOrderRequest(dto);
            }
            catch (ValidationException e)
            {
                throw this.CustomException(e.Message);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F154
        /// <summary>
        /// Checks if the token Id exist in token table and 
        /// ensures token replacement operation is permitted based on the current status of the token.
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public int IsTokenReplacementPermitted(int tokenID, out string cardSerialNo)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().IsTokenReplacementPermitted(tokenID, out cardSerialNo);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F155
        /// <summary>
        /// Get beneficiary names of a customer
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public List<DUC.CMS.Token.BLL.DTO.DictionaryDTO> GetAllCustomerBeneficiaryNames(int customerID)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetAllCustomerBeneficiaryNames(customerID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F156
        /// <summary>
        /// Get restriction group names
        /// </summary>
        /// <returns></returns>
        public List<DUC.CMS.Token.BLL.DTO.DictionaryDTO> GetAllRestrictionGroupNames(int? CustomerID)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetAllRestrictionGroupNames(CustomerID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F159
        /// <summary>
        /// Gets all the vehicle depots
        /// </summary>
        /// <returns></returns>
        public List<DUC.CMS.Token.BLL.DTO.VehicleDepotDTO> GetAllVehicleDepot()
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetAllVehicleDepot();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F160
        /// <summary>
        /// Gets all the restriction summary for the specific token
        /// </summary>
        /// <returns></returns>
        public List<DUC.CMS.Token.BLL.DTO.RestrictionSummaryDTO> GetRestrictionSummary(int restrictionGroupID)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetRestrictionSummary(restrictionGroupID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F161
        /// <summary>
        /// Gets all the time frequency from the lookup
        /// </summary>
        /// <returns></returns>
        public List<DUC.CMS.Token.BLL.DTO.TimeFrequencyDTO> GetAllTimeFrequency()
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetAllTimeFrequency();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F162
        /// <summary>
        /// Gets all the vehicle states from the lookup
        /// </summary>
        /// <returns></returns>
        public List<DUC.CMS.Token.BLL.DTO.VehicleStateDTO> GetAllVehicleStates()
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetAllVehicleStates();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F163
        /// <summary>
        /// Search the token table for unmapped tokens 
        /// </summary>
        /// <returns></returns>
        public List<DUC.CMS.Token.BLL.DTO.UnmappedTokenSearchDTO> SearchUnmappedToken(string beneficiaryName, string tokenName, int customerID, int UserID, int pageNo, int pageSize, out int rowCount)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().SearchUnmappedToken(beneficiaryName, tokenName, customerID, UserID, pageNo, pageSize, out rowCount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F164
        /// <summary>
        /// Add a vehicle info entry with the selected vehicle register id. Map the vehicle info to the selected token ; 
        /// Create a work order request
        /// </summary>
        /// <returns></returns>
        public bool AddBatchTokenVehicleMap(DUC.CMS.Token.BLL.DTO.BatchTokenVehicleMapDTO dto)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().AddBatchTokenVehicleMap(dto);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F165
        /// <summary>
        /// Checks if the token is in the status where deletion can be performed 
        /// </summary>
        /// <returns></returns>
        public bool IsTokenDeletionPermitted(int tokenID)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().IsTokenDeletionPermitted(tokenID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F166
        /// <summary>
        /// Checks if the beneficiary is in the status where deletion can be performed 
        /// </summary>
        /// <returns></returns>
        public bool IsBeneficiaryDeletionPermitted(int beneficiaryID)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().IsBeneficiaryDeletionPermitted(beneficiaryID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F167
        /// <summary>
        /// Checks if the beneficiary is in the status where deletion can be performed 
        /// </summary>
        /// <returns></returns>
        public bool DeleteToken(int tokenID, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            try
            {
                if (!new DUC.CMS.Token.BLL.TokenAppService().IsTokenDeletionPermitted(tokenID))
                    //throw new ValidationException(Resources.DeleteTokenValidationMessage);
                    throw new ValidationException(GetNotificationMessageByCode("service-DeleteToken").MessageBody);
                return new DUC.CMS.Token.BLL.TokenAppService().DeleteToken(tokenID, UserID, LastUpdatedDate, LocationId);
            }
            catch (ValidationException e)
            {
                throw this.CustomException(e.Message);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F168
        /// <summary>
        /// Update the beneficiary record with isactive   to 0
        /// </summary>
        /// <returns></returns>
        public bool DeleteBeneficiary(int beneficiaryID, DUC.CMS.Beneficiary.BLL.DTO.BaseDTO Audit)
        {
            try
            {
                if (!new DUC.CMS.Token.BLL.TokenAppService().IsBeneficiaryDeletionPermitted(beneficiaryID))
                    //throw new ValidationException(Resources.DeleteBeneficiaryValidationMessage);
                    throw new ValidationException(GetNotificationMessageByCode("service-DeleteBeneficiary").MessageBody);
                return new DUC.CMS.Beneficiary.BLL.BeneficiaryAppService().DeleteBeneficiary(beneficiaryID, Audit);
            }
            catch (ValidationException e)
            {
                throw this.CustomException(e.Message);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F169
        /// <summary>
        /// Checks if the newly generated PIN is there in the PIN log for the recent 5 records.
        /// </summary>
        /// <returns></returns>
        public bool IsNewPINPermitted(string pin, int type, int customerID)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().IsNewPINPermitted(pin, type, customerID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F171
        public List<DUC.CMS.Token.BLL.DTO.PropertyDTO> GetAllStations()
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetAllStations();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F172
        public List<DUC.CMS.Token.BLL.DTO.PropertyDTO> GetAllStationGroups()
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetAllStationGroups();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F173
        public List<DUC.CMS.Token.BLL.DTO.PropertyDTO> GetAllUngroupedStations()
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetAllUngroupedStations();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //174
        public List<DUC.CMS.Token.BLL.DTO.PropertyDTO> GetStationByGroup(int groupID)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetStationByGroup(groupID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F176
        public List<DUC.CMS.Token.BLL.DTO.PropertyDTO> GetAllPersonalizationReasons()
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetAllPersonalizationReasons();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F177
        public List<DUC.CMS.Token.BLL.DTO.PropertyDTO> GetAllWorkOrderReasons()
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetAllWorkOrderReasons();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }


        public decimal GetTokenAmount(int TokenId)
        {
            try
            {
                decimal tokenAmount;
                var objTokenAppService = new DUC.CMS.Token.BLL.TokenAppService();
                objTokenAppService.GetTokenAmount(TokenId, out tokenAmount);
                return tokenAmount;
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F178
        public List<DUC.CMS.Token.BLL.DTO.RestrictionGroupDTO> SearchRestrictionGroupProfile(string restrictionGroupName, int? customerID, int pageNo, int pageSize, out int rowCount)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().SearchRestrictionGroupProfile(restrictionGroupName, customerID, pageNo, pageSize, out rowCount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F179
        public DUC.CMS.Token.BLL.DTO.RestrictionGroupDTO GetRestrictionGroupById(int restrictionGroupID)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetRestrictionGroupById(restrictionGroupID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F180
        public bool DeleteRestrictionGroupByID(int restrictionGroupID, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().DeleteRestrictionGroupByID(restrictionGroupID, UserID, LastUpdatedDate, LocationId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F181      
        public bool UpdateRestrictionSummary(List<DUC.CMS.Token.BLL.DTO.RestrictionSummaryDTO> dto)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().UpdateRestrictionSummary(dto);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F182     
        public DUC.CMS.Token.BLL.DTO.PersonalizationOrderDTO GetPersonalizationInfo(int personalizationOrderID)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetPersonalizationInfo(personalizationOrderID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F183     
        public DUC.CMS.Token.BLL.DTO.WorkOrderDTO GetWorkOrderInfo(int workOrderID)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetWorkOrderInfo(workOrderID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F184
        public bool IsValidRechargeAmount(decimal rechargeAmount)
        {
            try
            {
                string _remarks = string.Empty;
                var result = new DUC.CMS.Token.BLL.TokenAppService().IsValidRechargeAmount(rechargeAmount, out _remarks);
                if (!result)
                    throw new ValidationException(_remarks);
                else
                    return result;
            }
            catch (ValidationException e)
            {
                throw this.CustomException(e.Message);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F185
        public List<Token.BLL.DTO.DriverCardDTO> SearchDriverCard(Token.BLL.DTO.DriverCardSearchDTO dto, int pageNo, int pageSize, out int rowCount)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().SearchDriverCard(dto, pageNo, pageSize, out rowCount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F186
        public bool MapCustomerDriverCard(int paymentTokenID, List<Token.BLL.DTO.DriverCardDTO> DriversList)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().MapCustomerDriverCard(paymentTokenID, DriversList);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F187
        public bool RenewEmirateID(int tokenID, string newCardSerial, DateTime ExpiryDate, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().RenewEmirateID(tokenID, newCardSerial, ExpiryDate, UserID, LastUpdatedDate, LocationId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F188
        public List<Token.BLL.DTO.ProductDTO> GetAllProductsForToken(int tokenID)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetAllProductsForToken(tokenID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F191
        public List<DUC.CMS.Token.BLL.DTO.StatusDTO> GetAllTokenStatusByID(int tokenID)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetAllTokenStatusByID(tokenID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F192
        public List<DUC.CMS.Token.BLL.DTO.TokenSearchDTO> SearchNonTerminatedTokens(DUC.CMS.Token.BLL.DTO.TokenSearchDTO tokenSearchDTO, int pageNo, int pageSize, out int rowCount)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().SearchNonTerminatedTokens(tokenSearchDTO, pageNo, pageSize, out rowCount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F195
        public int LoginUser(string userName)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().LoginUser(userName);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F196
        public List<DUC.CMS.Token.BLL.DTO.TokenSearchDTO> SearchRestrictedToken(DUC.CMS.Token.BLL.DTO.TokenSearchDTO dto, int pageNo, int pageSize, out int rowCount)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().SearchRestrictedToken(dto, pageNo, pageSize, out rowCount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F198
        public string GenerateDriverCardName(int CustomerID)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GenerateDriverCardName(CustomerID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F199
        public string GenerateTokenName(int CustomerID, int BeneficiaryID, int TokenTypeID)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GenerateTokenName(CustomerID, BeneficiaryID, TokenTypeID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F200
        public string GetCustomerCodeByID(int CustomerID)
        {
            try
            {
                return _appService.GetCustomerCodeByID(CustomerID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F201
        public string GetBeneficiaryCodeByID(int BeneficiaryID)
        {
            try
            {
                return new DUC.CMS.Beneficiary.BLL.BeneficiaryAppService().GetBeneficiaryCodeByID(BeneficiaryID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F202
        public string GetTokenCodeByID(int TokenID)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetTokenCodeByID(TokenID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F210
        public bool IsEmirateIDAlreadyRegistered(string emirateID)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().IsEmirateIDAlreadyRegistered(emirateID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public bool IsKNPCCardAlreadyRegistered(string Serial)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().IsKNPCCardAlreadyRegistered(Serial);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F211
        public List<Token.BLL.DTO.BatchBeneficiaryDTO> AddBatchBeneficiary(List<Token.BLL.DTO.BatchBeneficiaryDTO> dtos)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().AddBatchBeneficiary(dtos);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F212
        public string[] GenerateBatchTokenName(int customerID, int tokenCount, int tokenTypeID)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GenerateBatchTokenName(customerID, tokenCount, tokenTypeID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F213
        public DUC.CMS.Token.BLL.DTO.MapCustomerDTO MapSearch(DUC.CMS.Token.BLL.DTO.MapSearchDTO dto)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().MapSearch(dto);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F213
        public DUC.CMS.Token.BLL.DTO.MapCustomerDTO AccountMapSearch(DUC.CMS.Token.BLL.DTO.AccountMapSearchDTO dto, int pageNo, int pageSize, out int rowCount)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().AccountMapSearch(dto, pageNo, pageSize, out rowCount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //214
        public bool IsRestrictionGroupNameAlreadyExist(string RestrictionGroupName, int? CustomerID)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().IsRestrictionGroupNameAlreadyExist(RestrictionGroupName, CustomerID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //217
        public List<Token.BLL.DTO.DriverCardDTO> SearchMappableDriverCard(Token.BLL.DTO.DriverCardSearchDTO dto, int pageNo, int pageSize, out int rowCount)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().SearchMappableDriverCard(dto, pageNo, pageSize, out rowCount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F221
        public bool IsRestrictionGroupAllowedForToken(int TokenTypeID, int RestrictionGroupID, out string Message)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().IsRestrictionGroupAllowedForToken(TokenTypeID, RestrictionGroupID, out Message);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F222
        public Pages[] GetPrivilegedPagesForModule(string UserName, Modules module)
        {
            try
            {
                var data = new DUC.CMS.Token.BLL.TokenAppService().GetPrivilegedPagesForModule(UserName, (int)module);
                return (Pages[])(object)data;
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F223
        public bool IsRestrictionGroupInUse(int RestrictionGroupID)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().IsRestrictionGroupInUse(RestrictionGroupID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F227
        public List<DUC.CMS.Token.BLL.DTO.StatusDTO> GetAllDriverCardStatus()
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetAllDriverCardStatus();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F228
        public List<DUC.CMS.Token.BLL.DTO.DriverCardDTO> SearchNonTerminatedDriverCard(DUC.CMS.Token.BLL.DTO.DriverCardSearchDTO dto, int pageNo, int pageSize, out int rowCount)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().SearchNonTerminatedDriverCard(dto, pageNo, pageSize, out rowCount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public List<DUC.CMS.Token.BLL.DTO.VehicleModelDTO> GetVehicleModelsByMake(int makeID)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetVehicleModelsByMake(makeID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public DUC.CMS.Token.BLL.DTO.VehicleInfoDTO GetVehicleInfoByID(int vehicleInfoID)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetVehicleInfoByID(vehicleInfoID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public DUC.CMS.Token.BLL.DTO.TimeFrequencyDTO GetTimeFrequencyByID(int timeFrequencyId)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetTimeFrequencyByID(timeFrequencyId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public int UpdateVehicleInfo(DUC.CMS.Token.BLL.DTO.VehicleInfoDTO entity)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().UpdateVehicleInfo(entity);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }


        //F297
        public bool IsRestrictionExistForBeneficiaryToken(int beneficiary_id)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().IsRestrictionExistForBeneficiaryToken(beneficiary_id);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //F298
        public bool RemoveRestrictionForBeneficiaryToken(int beneficiary_id, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().RemoveRestrictionForBeneficiaryToken(beneficiary_id, UserID, LastUpdatedDate, LocationId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F299
        public List<DUC.CMS.Token.BLL.DTO.TokenToDeliverDTO> SearchTokensReadyForDelivery(DUC.CMS.Token.BLL.DTO.SearchTokenToDeliverDTO dto, out int totalCount)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().SearchTokensReadyForDelivery(dto, out totalCount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //F300
        public bool UpdateTokenDeliveredStatus(int token_id, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().UpdateTokenDeliveredStatus(token_id, UserID, LastUpdatedDate, LocationId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //F301
        public List<DUC.CMS.Token.BLL.DTO.TokenTypeDTO> GetAllPersonalizationTokenTypes()
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetAllPersonalizationTokenTypes();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F302
        public bool IsTokenRestrictionExistForCustomerTokens(int customer_id, int? BenenficiaryId)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().IsTokenRestrictionExistForCustomerTokens(customer_id, BenenficiaryId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F303
        public bool RemoveRestrictionForCustomerToken(int customer_id, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().RemoveRestrictionForCustomerToken(customer_id, UserID, LastUpdatedDate, LocationId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F316
        public DUC.CMS.Token.BLL.DTO.CurrencyDTO GetCurrency()
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetCurrency();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F317
        public List<DUC.CMS.Token.BLL.DTO.DictionaryDTO> GetAllActiveBeneficiaryNames(int customerID)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetAllActiveBeneficiaryNames(customerID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F319
        public bool IsVehicleChassisAlreadyRegistered(string ChassisNumber, int? TokenID, out string TokenCode)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().IsVehicleChassisAlreadyRegistered(ChassisNumber, TokenID, out TokenCode);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F320
        public bool IsVehicleDetailsAlreadyRegistered(string PlateNumber, int PlateColorID, int VehicleEmirateID, int VehicleTypeID, int? TokenID, int TokenTypeID, out string TokenCode)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().IsVehicleDetailsAlreadyRegistered(PlateNumber, PlateColorID, VehicleEmirateID, VehicleTypeID, TokenID, TokenTypeID, out TokenCode);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F319
        public bool IsVehicleChassisAlreadyRegistered(string ChassisNumber)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().IsVehicleChassisAlreadyRegistered(ChassisNumber);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F320
        public bool IsVehicleDetailsAlreadyRegistered(string PlateNumber, int PlateColorID, int VehicleEmirateID, int VehicleTypeID)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().IsVehicleDetailsAlreadyRegistered(PlateNumber, PlateColorID, VehicleEmirateID, VehicleTypeID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F323
        public List<DUC.CMS.Token.BLL.DTO.PersonalizationOrderTypesDTO> GetAllPersonalizationOrderTypes()
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetAllPersonalizationOrderTypes();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public int GetDieselProductID()
        {
            try
            {
                return _appService.GetDieselProductID();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public List<DUC.CMS.Token.BLL.DTO.WorkOrderTypeDTO> GetAllWorkOrderTypes()
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetAllWorkOrderTypes();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public List<DUC.CMS.Token.BLL.DTO.WorkOrderStatusDTO> GetAllWorkOrderStatus()
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetAllWorkOrderStatus();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public List<DUC.CMS.Token.BLL.DTO.PersonalizationOrderStatusDTO> GetAllPersonalizationOrderStatus()
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetAllPersonalizationOrderStatus();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //F331
        public bool IsTokenBelongingToBatch(int tokenId)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().IsTokenBelongingToBatch(tokenId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        #endregion

        #region workFlow
        public RequestDTO GetRequestById(int requestID)
        {
            try
            {
                return _appService.GetRequestById(requestID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public string GetRequestCode(int requestID)
        {
            try
            {
                return _appService.GetRequestCode(requestID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //700
        public int CreateWorkflowInstance(int RequestID, int RequestTypeID, int CurrentUserID, int Location_id)
        {
            try
            {
                return _appService.CreateWorkflowInstance(RequestID, RequestTypeID, CurrentUserID, Location_id);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //701
        public List<PropertyDTO> GetAllRequestTypes()
        {
            try
            {
                return _appService.GetAllRequestTypes();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //F702
        public List<PropertyDTO> GetAllRequestStatus()
        {
            try
            {
                return _appService.GetAllRequestStatus();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //F703
        public List<SearchRQSTRequestResultDTO> SearchAgentRequest(SearchRqstRequestDTO searchdto, int pageNo, int pageSize, out int rowCount)
        {
            try
            {
                return _appService.SearchAgentRequest(searchdto, pageNo, pageSize, out rowCount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //F704
        public List<SearchRQSTRequestResultDTO> SearchApproverRequest(SearchRqstRequestDTO searchdto, int ApprovalLevel, int pageNo, int pageSize, out int rowCount)
        {
            try
            {
                if (ApprovalLevel == 0)
                    return _appService.SearchApproverRequest(searchdto, pageNo, pageSize, out rowCount);
                else
                    return _appService.SearchFinalApproverRequest(searchdto, pageNo, pageSize, out rowCount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //F705
        public List<SearchRQSTRequestResultDTO> SearchRequestHistory(SearchRqstRequestDTO searchdto, int pageNo, int pageSize, out int rowCount)
        {
            try
            {
                return _appService.SearchRequestHistory(searchdto, pageNo, pageSize, out rowCount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //F706
        public RequestWorkflowHistoryDTO ViewRequestWorkflowHistory(int RequestID)
        {
            try
            {
                return _appService.ViewRequestWorkflowHistory(RequestID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        //F707
        public bool UpdateRequestStatus(int RequestID, int RequestStatusID, string CustomerCode, string Remarks, int UserID, int LocationID)
        {
            try
            {
                return _appService.UpdateRequestStatus(RequestID, RequestStatusID, CustomerCode, Remarks, UserID, LocationID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //F708
        public RequestCustomerDTO ViewAccountRequest(int RequestID)
        {
            try
            {
                return _appService.ViewAccountRequest(RequestID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //709
        public RequestWorkOrderDTO ViewWorkOrderRequest(int RequestID)
        {
            try
            {
                return _appService.ViewWorkOrderRequest(RequestID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //F710
        public RequestPersonalizationDTO ViewPersonalizationIssueRequest(int RequestID)
        {
            try
            {
                return _appService.ViewPersonalizationIssueRequest(RequestID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //F711
        public RequestAccountClosureDTO ViewAccountClosureRequest(int RequestID)
        {
            try
            {
                return _appService.ViewAccountClosureRequest(RequestID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //F712
        public List<RequestDocumentDTO> GetRequestDocuments(int RequestTypeID)
        {
            try
            {
                return _appService.GetRequestDocuments(RequestTypeID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //F713
        public List<RQSTAttachementDTO> ViewAllRequestUploadedAttachments(int requestID)
        {
            try
            {
                return _appService.ViewAllRequestUploadedAttachments(requestID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //F714
        public RQSTAttachementDTO ViewRequestUploadedAttachmentByID(int AttachmentID)
        {
            try
            {
                return _appService.ViewRequestUploadedAttachmentByID(AttachmentID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public bool UploadAttachment(List<CustomerAttachmentDTO> entity)
        {
            try
            {
                return _appService.UploadAttachment(entity);
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
                return false;
            }
        }
        //F715
        public bool UploadRequestAttachment(List<RQSTAttachmentDTO> entity)
        {
            try
            {
                return _appService.UploadRequestAttachment(entity);
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
                return false;
            }
        }
        //716
        public int GetLastWorkFlowInstanceID(int RequestId)
        {
            try
            {
                return _appService.GetLastWorkFlowInstanceID(RequestId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //717
        public int InitiateRequestWorkflow(int WorkFlowInstanceID, int? AssignedUserID, int? AssignedRoleID, int ActionID, string Comments, int CurrentUserid, int LocationID)
        {
            try
            {
                return _appService.InitiateRequestWorkflow(WorkFlowInstanceID, AssignedUserID, AssignedRoleID, ActionID, Comments, CurrentUserid, LocationID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //718
        public int ProcessWorkFlowStep(int WorkFlowInstanceID, int? AssignedUserID, int? AssignedRoleID, int ActionID, string Comments, int CurrentUserid, int LocationID, out int IsApprovalComplete)
        {
            try
            {
                return _appService.ProcessWorkFlowStep(WorkFlowInstanceID, AssignedUserID, AssignedRoleID, ActionID, Comments, CurrentUserid, LocationID, out IsApprovalComplete);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //F719
        public List<SearchTokenIssuanceResultDTO> SearchTokenIssuance(SearchTokenIssuanceDTO entity, int pageNo, int pageSize, out int rowCount)
        {
            try
            {
                return _appService.SearchTokenIssuance(entity, pageNo, pageSize, out rowCount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //F720
        public bool AddAccountRequestWFHistory(RequestWFHistoryCustomerDTO dto)
        {
            try
            {
                return _appService.AddAccountRequestWFHistory(dto);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //F721
        public bool AddWorkOrderRequestWFHistory(RequestWFHistoryWorkOrderDTO dto)
        {
            try
            {
                return _appService.AddWorkOrderRequestWFHistory(dto);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //F722
        public bool AddPersonalizationRequestWFHistory(RequestWFHistoryPersonalizationDTO dto)
        {
            try
            {
                return _appService.AddPersonalizationRequestWFHistory(dto);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //F723
        public bool UploadRequestWFHistoryAttachment(List<RequestWFHistoryAttachmentDTO> dto)
        {
            try
            {
                return _appService.UploadRequestWFHistoryAttachment(dto);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //F724
        //List<RequestWFHistoryAttachmentDTO>
        public bool RemoveRequestWFHistoryAttachment(List<RequestWFHistoryAttachmentDTO> dto)
        {
            try
            {
                return _appService.RemoveRequestWFHistoryAttachment(dto);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //F725
        public RequestWFHistoryCustomerDTO ViewAccountRequestWFHistory(int WFInstanceID)
        {
            try
            {
                return _appService.ViewAccountRequestWFHistory(WFInstanceID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //F726
        public RequestWFHistoryWorkOrderDTO ViewWorkOrderRequestWFHistory(int WFInstanceID)
        {
            try
            {
                return _appService.ViewWorkOrderRequestWFHistory(WFInstanceID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //F727
        public RequestWFHistoryPersonalizationDTO ViewPersonalizationIssueRequestWFHistory(int WFInstanceID)
        {
            try
            {
                return _appService.ViewPersonalizationIssueRequestWFHistory(WFInstanceID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //F728
        public List<RequestWFHistoryAttachmentDTO> ViewAllRequestWFHistoryUploadedAttachments(int WFInstanceID)
        {
            try
            {
                return _appService.ViewAllRequestWFHistoryUploadedAttachments(WFInstanceID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //F729
        public RequestWFHistoryAttachmentDTO ViewRequestWFHistoryUploadedAttachmentByID(int AttachmentID)
        {
            try
            {
                return _appService.ViewRequestWFHistoryUploadedAttachmentByID(AttachmentID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //F730
        public bool IsFinalApproverStep(int RequestID)
        {
            try
            {
                return _appService.IsFinalApproverStep(RequestID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        //F731
        public int GetpreviousWorkFlowInstanceID(int CurrentWorkFlowInstanceID)
        {
            try
            {
                return _appService.GetpreviousWorkFlowInstanceID(CurrentWorkFlowInstanceID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }

        }
        //F732
        public int GenerateAccountClosureRequest(int CustomerID, int UserID, DateTime LastUpdatedDate, int LocationID)
        {
            try
            {
                return _appService.GenerateAccountClosureRequest(CustomerID, UserID, LastUpdatedDate, LocationID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public int AddCreditDebitRQST(int CustomerID, int p_PAYMENT_TYPE_ID, decimal p_TRANSACTION_AMOUNT, int p_PAYMENT_METHOD_ID, string p_REMARKS, int UserID, int LocationID)
        {
            try
            {
                return _appService.AddCreditDebitRQST(CustomerID, p_PAYMENT_TYPE_ID, p_TRANSACTION_AMOUNT, p_PAYMENT_METHOD_ID, p_REMARKS, UserID, LocationID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public int AddRefundRQST(int CustomerID, int p_PAYMENT_TYPE_ID, decimal p_TRANSACTION_AMOUNT, int p_PAYMENT_METHOD_ID, string p_REMARKS, int UserID, int LocationID, int RefundTypeID, string paymentDOCRef, string BankName, string AccountHolderName, string AccountNumber, string IBANNumber, int? CountryId)
        {
            try
            {
                return _appService.AddRefundRQST(CustomerID, p_PAYMENT_TYPE_ID, p_TRANSACTION_AMOUNT, p_PAYMENT_METHOD_ID, p_REMARKS, UserID, LocationID, RefundTypeID, paymentDOCRef, BankName, AccountHolderName, AccountNumber, IBANNumber, CountryId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public int UpdateRefundRQST(int RequestID, string p_REMARKS, int UserID, int LocationID, decimal TransactionAmount, int RefundTypeID, string paymentDOCRef, string BankName, string AccountHolderName, string AccountNumber, string IBANNumber, int? CountryId)
        {
            try
            {
                return _appService.UpdateRefundRQST(RequestID, p_REMARKS, UserID, LocationID, TransactionAmount, RefundTypeID, paymentDOCRef, BankName, AccountHolderName, AccountNumber, IBANNumber, CountryId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public int AddVoucherRQST(int CustomerID, DateTime p_VALIDITY_START_DATE, DateTime p_VALIDITY_END_DATE, int? p_VALIDITY_TYPE_ID, int? p_VOUCHER_TYPE_ID,
            decimal? p_AMOUNT, string p_REMARKS, decimal? p_IS_NOTIFIED, decimal? p_IS_LOYALTY_VOUCHER, decimal? p_IS_ACTIVE, int UserID, int LocationID,
            string p_ALLOWEDPRODUCTIDS, int p_QUANTITY)
        {
            try
            {
                return _appService.AddVoucherRQST(CustomerID, p_VALIDITY_START_DATE, p_VALIDITY_END_DATE, p_VALIDITY_TYPE_ID, p_VOUCHER_TYPE_ID,
                p_AMOUNT, p_REMARKS, p_IS_NOTIFIED, p_IS_LOYALTY_VOUCHER, p_IS_ACTIVE, UserID, LocationID, p_ALLOWEDPRODUCTIDS, p_QUANTITY);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public int CreateAccountRequest(RequestCustomerDTO DTO)
        {
            try
            {
                return _appService.AddNewAccountRequest(DTO);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public int CreateNewAccountRequest(RequestCustomerDTO DTO, List<RQSTAttachmentDTO> CustomerAttachments)
        {
            int RequestID = -1;
            try
            {
                if (DTO.RequestID >= 0) //update
                {
                    RequestID = _appService.AddNewAccountRequest(DTO);

                    try
                    {
                        if (CustomerAttachments.Count > 0)
                        {
                            for (int i = 0; i < CustomerAttachments.Count; i++)
                                CustomerAttachments[i].RequestID = RequestID;
                            _appService.UploadRequestAttachment(CustomerAttachments);

                        }
                    }
                    catch (Exception ex)
                    {
                        throw this.HandleException(ex);
                    }
                }
                else
                {
                    RequestID = _appService.AddNewAccountRequest(DTO);
                    try
                    {
                        if (CustomerAttachments.Count > 0)
                        {
                            for (int i = 0; i < CustomerAttachments.Count; i++)
                                CustomerAttachments[i].RequestID = RequestID;

                            _appService.UploadRequestAttachment(CustomerAttachments);
                        }
                    }
                    catch (Exception ex)
                    {
                        _appService.DeleteCsutomerFromCMSOrRequest(null, RequestID);
                        throw this.HandleException(ex);
                    }
                }
                return RequestID;
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public List<PropertyDTO> GetAvailableCustomerContatcType(int customerId)
        {
            try
            {
                return _appService.GetAvailableCustomerContatcType(customerId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public int CreateWorkOrderRequest(RequestWorkOrderDTO dto)
        {
            try
            {
                return _appService.AddWorkOrderRequest(dto);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public int CreatePersonalizationRequest(RequestPersonalizationDTO dto)
        {
            try
            {
                return _appService.CreatePersonalizationRequest(dto);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public List<PropertyDTO> GetAllMonthlyVolumes()
        {
            try
            {
                return _appService.GetAllMonthlyVolumes();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public int GetpreviousWorkflowHistoryInstance(int InstanceID)
        {
            try
            {
                return _appService.GetpreviousWorkflowHistoryInstance(InstanceID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public bool RevertWorkFlowStep(int wfInstanceId)
        {
            try
            {
                return _appService.RevertWorkFlowStep(wfInstanceId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public bool CancelWorkOrder(int WorkOrderID, int LastLocationId, int LastUserID)
        {
            try
            {
                return _appService.CancelWorkOrder(WorkOrderID, LastLocationId, LastUserID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public bool CancelPersonalizationOrder(int PersonalizaionOrderID, int LastLocationId, int LastUserID)
        {
            try
            {
                return _appService.CancelPersonalizationOrder(PersonalizaionOrderID, LastLocationId, LastUserID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public OrderCancellationDTO GetDetailsForPersonalizationCancellation(int PersonalizationID, int pToekenID)
        {
            try
            {
                return _appService.GetDetailsForPersonalizationCancellation(PersonalizationID, pToekenID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public OrderCancellationDTO GetDetailsForWorkOrderCancellation(int WorkOrderID, int pToekenID)
        {
            try
            {
                return _appService.GetDetailsForWorkOrderCancellation(WorkOrderID, pToekenID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public bool IsRequestIDValidforAssignedUser(List<int> RequestsIDs, int AssignedUserid, int Mode, out List<int> InvalidIdsList)
        {
            try
            {
                string ListIds = string.Empty;
                string RequestsIDsstr = string.Empty;

                foreach (var item in RequestsIDs)
                {
                    RequestsIDsstr = item.ToString() + "," + RequestsIDsstr;
                }
                bool res = _appService.IsRequestIDValidforAssignedUser(RequestsIDsstr, AssignedUserid, Mode, out ListIds);
                if (ListIds.Count() > 0)
                {
                    ListIds = ListIds.TrimEnd(',');
                    InvalidIdsList = ListIds.Split(',').Select(int.Parse).ToList();
                }
                else
                    InvalidIdsList = null;

                return res;

            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public bool IsRequestPendingForCustomerOrToken(int customerId, int? TokenId)
        {
            try
            {
                return _appService.IsRequestPendingForCustomerOrToken(customerId, TokenId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public bool TerminatePendingRequests(int customerId, int? TokenId)
        {
            try
            {
                return _appService.TerminatePendingRequests(customerId, TokenId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        #endregion


        public List<PropertyDTO> GetAllNotificationPreferences()
        {
            try
            {
                return _appService.GetAllNotificationPreferences();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public CustomerAttachmentDTO ViewCustomerAttachmentByID(int AttachmentID)
        {
            try
            {
                return _appService.ViewCustomerAttachmentByID(AttachmentID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public List<IssuanceLocationLoadDto> GetCardCentreLoad(int cardCentreId, int preferredMonthId, int preferredYear)
        {
            try
            {
                return _appService.GetCardCentreLoad(cardCentreId, preferredMonthId, preferredYear);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public List<IssuanceLocationLoadDto> GetVehicleDepotLoad(int depotId, int preferredMonthId, int preferredYear)
        {
            try
            {
                return _appService.GetVehicleDepotLoad(depotId, preferredMonthId, preferredYear);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public List<DUC.CMS.Token.BLL.DTO.PropertyDTO> GetVehicleColorBySourceID(int sourceId)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetVehicleColorBySourceID(sourceId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public bool IsTokenCustomExpiryApplied(int TokenId)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().IsTokenCustomExpiryApplied(TokenId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public List<DUC.CMS.Token.BLL.DTO.PropertyDTO> GetVehicleKindBySourceAndColor(int sourceId, int Colorid)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetVehicleKindBySourceAndColor(sourceId, Colorid);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public DUC.CMS.Token.BLL.DTO.GetVehicleInfoDTO SearchTrafficVehicleInfo(int EmirateId, int ColorID, string PlateNO, int KindId, int? tokenID)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().SearchTrafficVehicleInfo(EmirateId, ColorID, PlateNO, KindId, tokenID);
            }
            catch (Exception ex)
            {
                throw this.HandleTrafficException(ex);
            }
        }
        public string GetFullNationality(string Code)
        {
            try
            {
                return _appService.GetFullNationality(Code);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public List<DUC.CMS.Token.BLL.DTO.StationDTO> GetAllStationsWithCoordinates()
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetAllStationsWithCoordinates();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public List<CustomerQuotaDTO> GetCustomerQuota(int CustomerId, int? ProductId)
        {
            try
            {
                return _appService.GetCustomerQuota(CustomerId, ProductId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public CustomerQuotaDTO GetAccountQuotaByQuotaId(int QuotaId)
        {
            try
            {
                return _appService.GetAccountQuotaByQuotaId(QuotaId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public int GetNationalityIDByName(string Name)
        {
            try
            {
                return _appService.GetNationalityIDByName(Name);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public int GetEmployeeNoForSerial(string SerialNo)
        {
            try
            {
                return _appService.GetEmployeeNoForSerial(SerialNo);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public bool IsTokenSerialAlreadyExist(int? TokenId, string TokenSerial, out string Remark)
        {
            try
            {
                return _appService.IsTokenSerialAlreadyExist(TokenId, TokenSerial, out Remark);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public bool RenewKNPEmployeeCard(int tokenID, string newCardSerial, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            try
            {
                return _appService.RenewKNPEmployeeCard(tokenID, newCardSerial, UserID, LastUpdatedDate, LocationId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public int SaveCustomerQuota(int? CustomerQuotaId, int custromerId, int productId, decimal Quota, int userId, int locationId)
        {
            try
            {
                return _appService.SaveCustomerQuota(CustomerQuotaId, custromerId, productId, Quota, userId, locationId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public bool DeleteCustomerQuota(int customerId, int productId, int userId, int locationId)
        {
            try
            {
                return _appService.DeleteCustomerQuota(customerId, productId, userId, locationId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public decimal GetCustomerQuotaConsumption(int customerId, int productId)
        {
            try
            {
                return _appService.GetCustomerQuotaConsumption(customerId, productId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public bool UpdateBeneficiaryRestriction(BeneficiaryRestrictionInputDTO beneficiaryRestrictionDto)
        {
            try
            {
                return _appService.UpdateBeneficiaryRestriction(beneficiaryRestrictionDto);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public BeneficiaryRestrictionResultDTO GetBenenficiaryRestriction(int BeneficiaryId)
        {
            try
            {
                return _appService.GetBenenficiaryRestriction(BeneficiaryId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public List<MonthDTO> GetAllMonths()
        {
            try
            {
                return _appService.GetAllMonths();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public DUC.CMS.Token.BLL.DTO.TokensToDeliverResultDTO SearchCustomerTokensReadyForDelivery(DUC.CMS.Token.BLL.DTO.SearchTokenToDeliverDTO dto)
        {
            try
            {
                return _appService.SearchCustomerTokensReadyForDelivery(dto);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public bool IssueToken(int TokenID, string Serial, string SecondSerial, string ThirdSerial, int UserID, int LocationId, int Mode, int IsFeeWaivedOff)
        {
            try
            {
                return _appService.IssueToken(TokenID, Serial, SecondSerial, ThirdSerial, UserID, LocationId, Mode, IsFeeWaivedOff);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }


        public bool hasAddTokenUsedBalanceGranted(int UserID)
        {
            try
            {
                return _appService.hasAddTokenUsedBalanceGranted(UserID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }


        public bool IsZeroTransactionToken(int tokenId)
        {
            try
            {
                return _appService.IsZeroTransactionToken(tokenId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }


        public int SetTokenUsedAmount(UsedTokenAmountDTO usedTokenAmountDTO)
        {
            try
            {
                return _appService.SetTokenUsedAmount(usedTokenAmountDTO.tokenId, usedTokenAmountDTO.usedAmount, usedTokenAmountDTO.LastUpdatedUserId.Value, usedTokenAmountDTO.LastUpdatedLocationID.Value);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public List<PrintReceiptTransDTO> GetPrintReceiptTrans(PrintReceiptTransInputDTO dto, out int rowCount)
        {
            try
            {
                return _appService.GetPrintReceiptTrans(dto, out rowCount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }


        public PrintReceiptDataDTO GetAccountReceiptData(int? CustomerId, int? TransactionId, int? PaymentTypeId, string TransactionType)
        {
            try
            {
                return _appService.GetAccountReceiptData(CustomerId, TransactionId, PaymentTypeId, TransactionType);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public List<TransactionTypeDTO> GetAllTrxTypes()
        {
            try
            {
                return _appService.GetAllTrxTypes();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public List<BillingFrequencyDTO> GetAllBillingFrequency()
        {
            try
            {
                return _appService.GetAllBillingFrequency();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public bool ISBeneficiaryCreationAllowed(int? CustomerId)
        {
            try
            {
                return _appService.ISBeneficiaryCreationAllowed(CustomerId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public bool RestrictionGroupTransaction(Nullable<decimal> MaximumTransactionAmount,
           int? IsActive, int? LastUpdatedUserId,
           Nullable<System.DateTime> LastUpdatedDate, int? LastLocationID,
           int? IsDry, int? ProductCategoryID)
        {
            try
            {
                return _appService.RestrictionGroupTransaction(MaximumTransactionAmount, IsActive,
                LastUpdatedUserId, LastUpdatedDate, LastLocationID, IsDry, ProductCategoryID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public bool RestrictionGroupStation(int? RSGRPID, int? StationID,
            int? IsActive, int? LastUpdatedUserId,
           Nullable<System.DateTime> LastUpdatedDate, int? LastLocationID,
            int? IsDry)
        {
            try
            {
                return _appService.RestrictionGroupStation(RSGRPID, StationID, IsActive,
                LastUpdatedUserId, LastUpdatedDate, LastLocationID, IsDry);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public bool RestrictionGroupAmount(int? RestrictionGroupID, int? TimeFrequencyID,
          Nullable<decimal> AllowedAmount, int? IsActive, int? LastUpdatedUserId,
          Nullable<System.DateTime> LastUpdatedDate, int? LastLocationID,
           int? IsDry, int? ProductCategoryID)
        {
            try
            {
                return _appService.RestrictionGroupAmount(RestrictionGroupID, TimeFrequencyID, AllowedAmount, IsActive,
                LastUpdatedUserId, LastUpdatedDate, LastLocationID, IsDry, ProductCategoryID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public bool RestrictionGroupTransactionNo(int? RestrictionGroupID, int? NumberOfDays,
            int? NumberOfTransactions, int? TimeFrequencyID, int? IsActive,
            int? LastUpdatedUserId, Nullable<System.DateTime> LastUpdatedDate,
            int? LastLocationID, int? IsDry,
            int? ProductCategoryID)
        {
            try
            {
                return _appService.RestrictionGroupTransactionNo(RestrictionGroupID, NumberOfDays, NumberOfTransactions, TimeFrequencyID,
                IsActive, LastUpdatedUserId, LastUpdatedDate, LastLocationID, IsDry, ProductCategoryID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public List<TransactionProductDTO> GetAllTransactionProducts()
        {
            try
            {
                return _appService.GetAllTransactionProducts();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public List<ProductCategoryDTO> GetAllProductCategories()
        {
            try
            {
                var data = _appService.GetAllProductCategories();
                return data;
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public List<CategoryDTO> ProductCategorySA()
        {
            try
            {
                return _appService.ProductCategorySA();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public List<SearchPendingRequestResultDTO> SearchPendingRequest(SearchRqstRequestDTO searchdto, int pageNo, int pageSize, out int rowCount)
        {
            try
            {
                return _appService.SearchPendingRequest(searchdto, pageNo, pageSize, out rowCount);

            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public List<SearchEscalatedRequestResultDTO> SearchEscalatedRequest(SearchRqstRequestDTO searchdto, int pageNo, int pageSize, out int rowCount)
        {
            try
            {
                return _appService.SearchEscalatedRequest(searchdto, pageNo, pageSize, out rowCount);

            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public int ProcessEscalationRequest(int WorkFlowInstanceID, int RequestId, string Comments, int CurrentUserid, int LocationID, int? EscalatedUserTo, int? EscalteRoleId)
        {
            try
            {
                return _appService.ProcessEscalationRequest(WorkFlowInstanceID, RequestId, Comments, CurrentUserid, LocationID, EscalatedUserTo, EscalteRoleId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public int ISCompanyRegistrationIDUnique(int? CustomerID, int? RequestCustomerID, string CompanyID, out int Response)
        {
            try
            {
                return _appService.ISCompanyRegistrationIDUnique(CustomerID, RequestCustomerID, CompanyID, out Response);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public void ValidateDuplicateMobileNumber(string mobileNumber, int? customerID)
        {
            try
            {
                _appService.ValidateDuplicateMobileNumber(mobileNumber, customerID);
            }
            catch (Exception ex)
            {
                throw HandleException(ex);
            }
        }

        public int GetBeneficiaryCount(int? CustomerId)
        {
            try
            {
                return _appService.GetBeneficiaryCount(CustomerId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public DUC.CMS.Token.BLL.DTO.VehicleDummyInfoDTO GetDummyVehicleInfo(string vehicleTypeCode, string plateNumber)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetDummyVehicleInfo(vehicleTypeCode, plateNumber);
            }
            catch (Exception ex)
            {
                throw this.HandleTrafficException(ex);
            }
        }
        public int SaveMOIVehicleRegister(DUC.CMS.Token.BLL.DTO.VehicleRegisterSearchResultDTO dto, int UserId, int LocationId)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().SaveMOIVehicleRegister(dto, UserId, LocationId);
            }
            catch (Exception ex)
            {
                throw this.HandleTrafficException(ex);
            }
        }
        public bool IsVehicleChassisAlreadyExists(string ChassisNumber, int? TokenID, int TokenTypeID, out string TokenCode)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().IsVehicleChassisAlreadyExist(ChassisNumber, TokenID, TokenTypeID, out TokenCode);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public List<DUC.CMS.Token.BLL.DTO.ConsumedAmountResultDTO> GetConsumedAmount(int restrictionGroupID)
        {
            try
            {
                return new DUC.CMS.Token.BLL.TokenAppService().GetConsumedAmount(restrictionGroupID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public bool CheckNationalIDExistForIndPrepaid(string NationalID)
        {
            try
            {
                return _appService.CheckNationalIDExistForIndPrepaid(NationalID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public bool IsTransactionReversalGranted(int userID)
        {
            try
            {
                return _appService.IsTransactionReversalGranted(userID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public List<TransactionReversalDTO> SearchTransactionForReversal(TransactionReversalSearchDTO dto, int pageNo, int pageSize, out int rowCount)
        {
            try
            {
                return _appService.SearchTransactionForReversal(dto, pageNo, pageSize, out rowCount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public bool Reverse_Transaction(bool isPayment, int transactionDetailID, DateTime reverseDate, int currentUserid, int locationID)
        {
            try
            {
                return _appService.Reverse_Transaction(isPayment, transactionDetailID, reverseDate, currentUserid, locationID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public List<TransactionReversalDTO> ViewReversedTransaction(bool isPayment, int transactionDetailID)
        {
            try
            {
                return _appService.ViewReversedTransaction(isPayment, transactionDetailID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public List<RefundTypeDTO> GetAllRefundTypes()
        {
            try
            {
                return _appService.GetAllRefundTypes();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public CustomerPaymentDTO GetTopUpDetailsByDocRef(string paymentDocRef, int? CustomerId)
        {
            try
            {
                return _appService.GetTopUpDetailsByDocRef(paymentDocRef, CustomerId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        #region Logging
        public bool LogException(string Message, string StackTrace, string InnerException)
        {

            _uiLogger.Log(string.Format("Message: {0}, Stack Trace: {1}, Inner Exception: {2}", Message, StackTrace, InnerException),
                    EventLogger.Enumerations.LoggerEventType.Error);
            return true;
        }

        public bool LogDetailedException(string Message, string StackTrace, string InnerException, string pagename, string functionname, int? customerid, int? beneficiaryId, int? tokenID)
        {
            string ExceptionMessage = string.Empty;

            if (pagename != null)
                ExceptionMessage += "Page Name:" + pagename;

            if (functionname != null)
                ExceptionMessage += " Function Name:" + functionname;

            if (customerid != null)
                ExceptionMessage += " Customer ID:" + customerid;

            if (beneficiaryId != null)
                ExceptionMessage += " Beneficiary ID:" + beneficiaryId;

            if (tokenID != null)
                ExceptionMessage += " Token ID:" + tokenID;

            _uiLogger.Log(string.Format("ExceptionMessage: {0}, Message: {1}, Stack Trace: {2}, Inner Exception: {3}", ExceptionMessage, Message, StackTrace, InnerException),
                    EventLogger.Enumerations.LoggerEventType.Error);
            return true;
        }

        #endregion

        #region Private Methods


        private FaultException<CustomerFault> HandleTrafficException(Exception ex)
        {
            try
            {
                var messageToLog = string.Format("Message: {0}, Stack Trace: {1}, Inner Exception: {2}", ex.Message, ex.StackTrace, ex.InnerException != null ? ex.InnerException.ToString() : string.Empty);
                _logger.Log(messageToLog, EventLogger.Enumerations.LoggerEventType.Error);

                var erroMessage = string.Format("Error Message - {0}", ex.Message);
                var errCode = string.Empty;

                string spName = ConfigurationSettings.AppSettings["spName"];
                //   if (ex.Message.Contains(spName.ToUpper()))
                {
                    string ErrorMessage = ConfigurationSettings.AppSettings["ErrorMessage"];

                    errCode = spName;
                    erroMessage = ErrorMessage;
                }

                if (ex.InnerException != null)
                {
                    erroMessage = string.Format("{0} , Detailed Exception = {1}", erroMessage, ex.InnerException.Message);
                }
                //if (ex.InnerException != null && ex.InnerException.Message.Contains("20001"))
                //{
                //    errCode = ex.InnerException.Message.Substring(ex.InnerException.Message.IndexOf("20001:") + 6, ex.InnerException.Message.IndexOf("\nORA") - 10);
                //    errCode = errCode.Substring(0, errCode.IndexOf("|"));
                //    erroMessage = errCode;
                //}



                return new FaultException<CustomerFault>(new CustomerFault(errCode, erroMessage), new FaultReason(ex.Message));
            }
            catch (Exception ex1)
            {
                return new FaultException<CustomerFault>(new CustomerFault("-1", "-1"), new FaultReason(ex1.Message));
            }
        }

        /// <summary>
        /// Handles the excpetion.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private FaultException<CustomerFault> HandleException(Exception ex)
        {
            try
            {
                var messageToLog = string.Format("Message: {0}, Stack Trace: {1}, Inner Exception: {2}", ex.Message, ex.StackTrace, ex.InnerException != null ? ex.InnerException.ToString() : string.Empty);
                _logger.Log(messageToLog, EventLogger.Enumerations.LoggerEventType.Error);

                var erroMessage = string.Format("Error Message - {0}", ex.Message);
                var errCode = string.Empty;

                string spName = ConfigurationSettings.AppSettings["spName"];
                if (ex.Message.Contains(spName.ToUpper()))
                {
                    string ErrorMessage = ConfigurationSettings.AppSettings["ErrorMessage"];

                    errCode = spName;
                    erroMessage = ErrorMessage;
                }

                if (ex.InnerException != null)
                {
                    erroMessage = string.Format("{0} , Detailed Exception = {1}", erroMessage, ex.InnerException.Message);
                }
                if (ex.InnerException != null && ex.InnerException.Message.Contains("20001"))
                {
                    if (ex.InnerException.Message.Contains("ORA-20001") && ex.InnerException.Message.Contains("(ErrorCode:"))
                    {
                        var mesg = ex.InnerException.Message;
                        // use regex to extract error code and message;                       
                        var groups = Regex.Match(mesg, @"^ORA-20001:(\s\(ErrorCode:\s<(\d{1,})>\))?\s(.{1,})\n", RegexOptions.IgnoreCase).Groups;
                        // atleast 4 matches is required
                        if (groups.Count >= 4)
                        {
                            errCode = "20001";
                            erroMessage = groups[3].Value.Trim();
                            if (erroMessage.Contains("|"))
                                erroMessage = erroMessage.Remove(erroMessage.IndexOf("|"));
                        }
                    }
                    else
                    {
                        errCode = ex.InnerException.Message.Substring(ex.InnerException.Message.IndexOf("20001:") + 6, ex.InnerException.Message.IndexOf("\nORA") - 10);
                        errCode = (errCode.Contains("|")) ? errCode.Substring(0, errCode.IndexOf("|")) : errCode;
                        erroMessage = errCode;
                    }
                }



                return new FaultException<CustomerFault>(new CustomerFault(errCode, erroMessage), new FaultReason(ex.Message));
            }
            catch (Exception ex1)
            {
                return new FaultException<CustomerFault>(new CustomerFault("-1", "-1"), new FaultReason(ex1.Message));
            }
        }

        private FaultException<CustomerFault> CustomException(string Message)
        {
            return new FaultException<CustomerFault>(new CustomerFault(Message, Message), new FaultReason(Message));
        }

        public class ValidationException : System.Exception
        {
            public ValidationException(string msg)
                : base(msg)
            {
            }
        }

        #endregion

        #region DummyMethodForEnumeration

        public void DummyEnumerationMethod(NotificationLanguages notificationLanguages, NotificationPreferences notificationPreferences, ReceiptTypes receiptTypes,
            InvoiceTypes invoiceTypes, PaymentType paymentType, PaymentMethod PaymentMethod, TokenType tokenType, CustomerStatus cusStatus,
            BeneficiaryStatus benStatus, TokenStatus tokenStatus, Modules modules, Pages pages, Functions functions, RequestTypes requestType,
            RequestStatus requestStatus, ServiceNames ServiceNames, WorkFlowAction WorkFlowAction, WorkFlowStatus WorkFlowstatus, Approverlevel Approverlevel,
            ContactType contactType, FuelInlet _FuelInlet, ProductCategory productCategory)
        {
        }

        #endregion

        #region

        public List<FinanceIdDTO> GetNonRegisteredERPAccounts()
        {
            try
            {

                return _appService.GetNonRegisteredERPAccounts();
            }
            catch (Exception ex)
            {
                throw HandleException(ex);
            }
        }
        public List<FinanceIdDTO> GetNonRegisteredSIteIDForERPAccount(int FinancialID)
        {
            try
            {

                return _appService.GetNonRegisteredSIteIDForERPAccount(FinancialID);
            }
            catch (Exception ex)
            {
                throw HandleException(ex);
            }
        }
        public List<FinanceIdDTO> GetRegisteredSIteIDForERPAccount(int FinancialID)
        {
            try
            {

                return _appService.GetRegisteredSIteIDForERPAccount(FinancialID);
            }
            catch (Exception ex)
            {
                throw HandleException(ex);
            }
        }
        public List<FinanceIdDTO> GetAllSIteIDForERPAccount(int? FinancialID)
        {
            try
            {

                return _appService.GetAllSIteIDForERPAccount(FinancialID);
            }
            catch (Exception ex)
            {
                throw HandleException(ex);
            }
        }
        public List<FinanceIdDTO> GetRegisteredERPAccounts()
        {
            try
            {

                return _appService.GetRegisteredERPAccounts();
            }
            catch (Exception ex)
            {
                throw HandleException(ex);
            }
        }

        public List<FinanceIdDTO> GetNonRegisteredIndAccounts()
        {
            try
            {

                return _appService.GetNonRegisteredIndAccounts();
            }
            catch (Exception ex)
            {
                throw HandleException(ex);
            }
        }

        #endregion

        #region Reports
        public List<PropertyDTO> GetAllPersonalizationOrderType()
        {
            try
            {
                return _appService.GeAllPersonalizationOrderType();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public List<PropertyDTO> GetAllPersonaliztionOrderStatus()
        {
            try
            {
                return _appService.GeAllPersonaliztionOrderStatus();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public List<PropertyDTO> GetAllDepots()
        {
            try
            {
                return _appService.GeAllDepots();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public List<PropertyDTO> GetAllWorkOrdersTypes()
        {
            try
            {

                return _appService.GeAllWorkOrderTypes();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public List<PropertyDTO> GetAllInvoiceStatus()
        {
            try
            {
                return _appService.GetAllInvoiceStatus();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public List<PropertyDTO> GetAllRefundMethods()
        {
            try
            {
                return _appService.GetAllRefundMethods();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public List<PropertyDTO> GetAllEPICallTypes()
        {
            try
            {
                return _appService.GetAllEPICallTypes();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public List<PropertyDTO> GetAllTransactionTypes()
        {
            try
            {
                return _appService.GetAllTransactionTypes();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public List<PropertyDTO> GetAllBeneficiaryGroups()
        {
            try
            {
                return _appService.GetAllBeneficiaryGroups();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public BillToDetailsDTO GetBillToDetails(string arcustomerno)
        {
            try
            {
                return _appService.GetBillToDetails(arcustomerno);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        #endregion

        #region EXTERNALVOUCHER

        public List<SearchVoucherTransactionDTO> SearchVoucherTransaction(int? StationID, int? ReceiptNo, DateTime? fromDate, DateTime? toDate, string VoucherSerialNo, string CustomerNo, int? VoucherID,
            string TransReferenceNo, string FinancialAccountName, string SiteName, int pageNo, int pageSize, out int rowCount)
        {
            try
            {
                return _appService.SearchVoucherTransaction(StationID, ReceiptNo, fromDate, toDate, VoucherSerialNo, CustomerNo, VoucherID, TransReferenceNo,
                    FinancialAccountName, SiteName, pageNo, pageSize, out rowCount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public bool TransactionEXTVoucherMAPIU(string VoucherNo, string VoucherSerialNo, string VatInvoiceNo, int LastUpdatedUserID, int LastLocationID)
        {
            try
            {
                return _appService.TransactionEXTVoucherMAPIU(VoucherNo, VoucherSerialNo, VatInvoiceNo, LastUpdatedUserID, LastLocationID);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public List<VoucherTransactionMapDTO> ExternalVoucherTRX_AUDIT(string OperationName, Nullable<DateTime> fromDate, Nullable<DateTime> toDate, int? LastUpdatedUserID, int? LastLocationID,
         int pageNo, int pageSize, out int rowCount)
        {
            try
            {
                return _appService.ExternalVoucherTRX_AUDIT(fromDate, toDate, LastUpdatedUserID, LastLocationID, OperationName, pageNo, pageSize, out rowCount);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }


        #endregion
        public decimal GetCustomerAvailableCreditLimit(int CustomerId)
        {
            try
            {
                _appService.GetCustomerAvailableCreditLimit(CustomerId, out decimal availCreditLimit);
                return availCreditLimit;
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public bool IsCustomerPendingRefundRequestExists(int CustomerId)
        {
            try
            {
                return _appService.IsCustomerPendingRefundRequestExists(CustomerId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        ///F126
        /// <summary>
        /// Add the information of the all the tokens in the batch; 
        /// If the Token Type is Vehicle Tag, the vehicle information will be added to the VehicelInfo table.
        /// </summary>
        /// <param name="tokenDTO"></param>
        /// <returns></returns>
        public List<Token.BLL.DTO.BatchTokenDTODetails> AddBatchTokenDetails(int CustomerId, List<Token.BLL.DTO.BatchTokenDTODetails> batchTokenDTOs)
        {
            // return new DUC.CMS.Token.BLL.TokenAppService().AddBatchTokenInfo(tokenDTO[0].tokenDTO);

            string strErrMsg;
            try
            {

                CustomerDTO customer = GetCustomerInfo(CustomerId);
                var locations = GetAllVehicleDepot();
                int tokenIndex = 0;
                var batchTokenDTOList = batchTokenDTOs.ToList();
                int LastLocationId = -1;
                foreach (var batchTokenDtoDetails in batchTokenDTOList)
                {
                    try
                    {
                        LastLocationId = batchTokenDtoDetails.LastUpdatedLocationID ?? -1;
                        var tokenDto = new Token.BLL.DTO.TokenDTO();
                        tokenDto.CustomerID = batchTokenDtoDetails.CustomerID;
                        tokenDto.BeneficiaryID = batchTokenDtoDetails.BeneficiaryID;
                        tokenDto.Name = batchTokenDtoDetails.TokenName;
                        tokenDto.TokenTypeID = batchTokenDtoDetails.TokenTypeId.Value;
                        tokenDto.TokenStatusID = batchTokenDtoDetails.TokenStatusId;
                        tokenDto.IsActive = batchTokenDtoDetails.IsActive;
                        tokenDto.RestrictionGroupID = batchTokenDtoDetails.RestrictionGroupId;
                        tokenDto.VehicleInfoDTO = new Token.BLL.DTO.VehicleInfoDTO()
                        {
                            ChassisNumber = batchTokenDtoDetails.VehicleInfoDto.ChassisNumber,
                            ColorID = batchTokenDtoDetails.VehicleInfoDto.ColorID,
                            ColorName = batchTokenDtoDetails.VehicleInfoDto.ColorName,
                            PlateColorID = batchTokenDtoDetails.VehicleInfoDto.PlateColorID,
                            PlateNumber = batchTokenDtoDetails.VehicleInfoDto.PlateNumber,
                            StateID = batchTokenDtoDetails.VehicleInfoDto.StateID,
                            StateName = batchTokenDtoDetails.VehicleInfoDto.StateName,
                            VehicleInfoID = batchTokenDtoDetails.VehicleInfoDto.VehicleInfoID,
                            VehicleRegisterDTO = batchTokenDtoDetails.VehicleInfoDto.VehicleRegisterDTO,
                            VehicleRegisterID = batchTokenDtoDetails.VehicleInfoDto.VehicleRegisterID,
                            VehicleTypeID = batchTokenDtoDetails.VehicleInfoDto.VehicleTypeID,
                            VehicleTypeName = batchTokenDtoDetails.VehicleInfoDto.VehicleTypeName,
                            EngineNumber = batchTokenDtoDetails.VehicleInfoDto.EngineNumber,
                        };

                        batchTokenDtoDetails.IsVehicleRegisterOrPermitNumberError = true;
                        if (LastLocationId != -1)
                            tokenDto.LastUpdatedLocationID = LastLocationId; // Added by m.nada
                        tokenDto.LastUpdatedDate = DateTime.Now;
                        tokenDto.LastUpdatedUserId = batchTokenDtoDetails.LastUpdatedUserId;
                        ///////////////////////////////////////////////////
                        if (tokenDto.VehicleInfoDTO != null)
                        {
                            tokenDto.VehicleInfoDTO.ColorID = Convert.ToInt32(tokenDto.VehicleInfoDTO.PlateColorID);
                        }
                        batchTokenDtoDetails.TokenDto = tokenDto;

                        var copyTokenId = 0;
                        if (batchTokenDtoDetails.CopyTokenId.HasValue)
                        {
                            if (batchTokenDtoDetails.CopyTokenId > 0)
                            {
                                copyTokenId = Convert.ToInt32(batchTokenDtoDetails.CopyTokenId);
                                //  PrepareRestrictionInfoWhenCopy(batchTokenDtoDetails.TokenDto, batchTokenDtoDetails.CopyTokenId.Value, LastLocationId, batchTokenDTOs.LastUpdatedUserID ?? -1);
                            }

                            var copyTokenInfo = GetTokenInfo(copyTokenId);
                            if (copyTokenInfo != null)
                            {
                                Token.BLL.DTO.RestrictionGroupDTO restrictionGroupInfo =
                                    GetRestrictionGroupById(Convert.ToInt32(copyTokenInfo.RestrictionGroupID));
                                if (restrictionGroupInfo != null)
                                {
                                    var tokenRestrictionDto = new Token.BLL.DTO.TokenRestrictionDTO();

                                    tokenRestrictionDto.IsActive = true;
                                    tokenRestrictionDto.IsSystemDefinedRestrictionGroup = true;
                                    tokenRestrictionDto.ProductCategoryRestrictions = restrictionGroupInfo.ProductCategoryRestrictions;
                                    foreach (var productRestriction in tokenRestrictionDto.ProductCategoryRestrictions)
                                    {

                                        if (productRestriction.RestrictionTransNoDTO != null)
                                        {
                                            foreach (var item in productRestriction.RestrictionTransNoDTO)
                                            {
                                                item.RestrictionGroupID = 0;
                                            }
                                        }
                                        if (productRestriction.RestrictionTransactionDTO != null)
                                        {
                                            foreach (var item in productRestriction.RestrictionTransactionDTO)
                                            {
                                                item.RestrictionGroupID = 0;
                                            }
                                        }
                                        if (productRestriction.RestrictionAmountDTO != null)
                                        {
                                            foreach (var item in productRestriction.RestrictionAmountDTO)
                                            {
                                                item.RestrictionGroupID = 0;
                                                item.TimeFrequencyDTO = null;
                                            }
                                        }
                                        if (productRestriction.RestrictionProductDTO != null)
                                        {
                                            foreach (var item in productRestriction.RestrictionProductDTO)
                                            {
                                                item.RestrictionGroupID = 0;
                                            }
                                        }

                                        if (productRestriction.RestrictionQuantityDTO != null)
                                        {
                                            foreach (var item in productRestriction.RestrictionQuantityDTO)
                                            {
                                                item.RestrictionGroupID = 0;
                                                item.TimeFrequencyDTO = null;
                                            }
                                        }
                                    }
                                    tokenRestrictionDto.RestrictionStationDTO = restrictionGroupInfo.RestrictionStationDTO;
                                    foreach (var item in tokenRestrictionDto.RestrictionStationDTO)
                                    {
                                        item.RestrictionGroupID = 0;
                                    }
                                    tokenRestrictionDto.CanBuyDryStock = restrictionGroupInfo.CanBuyDryStock;
                                    tokenRestrictionDto.CanUseAdnocService = restrictionGroupInfo.CanUseAdnocService;
                                    tokenRestrictionDto.ConsecutiveUsageRestriction = restrictionGroupInfo.ConsecutiveUsageRestriction;
                                    tokenRestrictionDto.HolidayRestriction = restrictionGroupInfo.HolidayRestriction;
                                    tokenRestrictionDto.RestrictionGroupTimeDTO = restrictionGroupInfo.RestrictionGroupTimeDTO;
                                    if (tokenRestrictionDto.TokenTypeID == Convert.ToInt32(TokenType.VehicleTag)
                                            || tokenRestrictionDto.TokenTypeID == Convert.ToInt32(TokenType.VehiclePlate))
                                    {
                                        tokenRestrictionDto.RequireDriverCard = restrictionGroupInfo.RequireDriverCard;
                                        tokenRestrictionDto.RequireOdometerInput = restrictionGroupInfo.RequireOdometerInput;
                                    }

                                    tokenRestrictionDto.RestrictionWeekDayDTO = restrictionGroupInfo.RestrictionWeekDayDTO;
                                    foreach (var item in tokenRestrictionDto.RestrictionWeekDayDTO)
                                    {
                                        item.RestrictionGroupID = 0;
                                    }
                                    batchTokenDtoDetails.TokenRestriction = tokenRestrictionDto;
                                }
                            }

                        }

                        if (batchTokenDtoDetails.TokenRestriction != null)
                        {
                            batchTokenDtoDetails.TokenRestriction = PrepareTokenRestriction(batchTokenDtoDetails.TokenRestriction);
                            batchTokenDtoDetails.TokenRestriction.LastUpdatedLocationID = batchTokenDtoDetails.LastUpdatedLocationID;
                            batchTokenDtoDetails.TokenRestriction.LastUpdatedUserId = batchTokenDtoDetails.LastUpdatedUserId;
                            batchTokenDtoDetails.TokenRestriction.LastUpdatedDate = batchTokenDtoDetails.LastUpdatedDate;
                        }


                        strErrMsg = "";
                        //    _logger.Log("Btach Token- Before"+ batchTokenDtoDetails.TokenName,EventLogger.Enumerations.LoggerEventType.Info);
                        var batchtoken = new DUC.CMS.Token.BLL.TokenAppService().AddBatchTokenDetails(batchTokenDtoDetails, out strErrMsg);
                        // _logger.Log("Btach Token- After" + batchTokenDtoDetails.TokenName, EventLogger.Enumerations.LoggerEventType.Info);

                        var tokenInfoAfterAdd = GetTokenInfo((int)batchtoken.TokenID);
                        batchTokenDtoDetails.TokenDto = tokenInfoAfterAdd;
                        batchTokenDtoDetails.TokenID = batchtoken.TokenID;
                        batchTokenDtoDetails.Status = batchtoken.Status;
                        batchTokenDtoDetails.StatusCode = batchtoken.StatusCode;
                        batchTokenDtoDetails.StatusRemark = batchtoken.StatusRemark;
                        batchTokenDtoDetails.TokenID = batchtoken.TokenID;
                        batchTokenDtoDetails.TokenCode = batchtoken.TokenCode;
                        tokenIndex++;
                    }
                    catch (Exception ex)
                    {
                        string msg = GetExceptionMsg(ex);
                        batchTokenDtoDetails.Status = false;
                        batchTokenDtoDetails.StatusRemark = !string.IsNullOrEmpty(msg)
                                ? msg
                                : "AnErrorOccurredDuringOperation";
                    }

                }

                return batchTokenDTOList;
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public DUC.CMS.Token.BLL.DTO.TokenRestrictionDTO PrepareTokenRestriction(DUC.CMS.Token.BLL.DTO.TokenRestrictionDTO dto)
        {
            try
            {
                string strAmount = "", strProduct = "", strQuantity = "", strTransNo = "", strTransaction = "";


                if (dto.ProductCategoryRestrictions != null)
                {
                    foreach (var productCategory in dto.ProductCategoryRestrictions)
                    {
                        if (productCategory.RestrictionAmountDTO != null)
                        {
                            foreach (var item in productCategory.RestrictionAmountDTO)
                            {
                                strAmount = strAmount + item.RestrictionGroupID + "," + item.TimeFrequencyID + "," + item.AllowedAmount + "," + Convert.ToInt16(item.IsActive) + "," + item.LastUpdatedUserId + "," + productCategory.ProductCategoryID + "|";
                            }
                        }

                        if (productCategory.RestrictionProductDTO != null)
                        {
                            foreach (var item in productCategory.RestrictionProductDTO)
                            {
                                strProduct = strProduct + item.RestrictionGroupID + "," + item.ProductID + "," + string.Empty + "," + string.Empty + "," + Convert.ToInt16(item.IsActive) + "," + item.LastUpdatedUserId + "|";
                            }
                        }

                        if (productCategory.RestrictionQuantityDTO != null)
                        {
                            foreach (var item in productCategory.RestrictionQuantityDTO)
                            {
                                strQuantity = strQuantity + item.RestrictionGroupID + "," + item.AllowedProductID + "," + item.TimeFrequencyID + "," + item.AllowedQuantity + "," + Convert.ToInt16(item.IsActive) + "," + item.LastUpdatedUserId + "," + productCategory.ProductCategoryID + "|";
                            }
                        }

                        if (productCategory.RestrictionTransNoDTO != null)
                        {
                            foreach (var item in productCategory.RestrictionTransNoDTO)
                            {
                                strTransNo = strTransNo + item.RestrictionGroupID + "," + item.NumberOfDays + "," + item.NumberOfTransactions + "," + item.TimeFrequencyID + "," + Convert.ToInt16(item.IsActive) + "," + item.LastUpdatedUserId + "," + productCategory.ProductCategoryID + "|";
                            }
                        }

                        if (productCategory.RestrictionTransactionDTO != null)
                        {
                            foreach (var item in productCategory.RestrictionTransactionDTO)
                            {
                                strTransaction = strTransaction + item.RestrictionGroupID + "," + item.MaxTransactionAmount + "," + Convert.ToInt16(item.IsActive) + "," + item.LastUpdatedUserId + "," + productCategory.ProductCategoryID + "|";
                            }
                        }
                    }
                }

                dto.RsAmount = strAmount;
                dto.RsProduct = strProduct;
                dto.RsQuantity = strQuantity;
                dto.RsTransNo = strTransNo;
                dto.RsTransaction = strTransaction;

                string strTemp = string.Empty;
                if (dto.RestrictionStationDTO != null)
                {
                    foreach (var item in dto.RestrictionStationDTO)
                    {
                        strTemp = strTemp + item.RestrictionGroupID + "," + item.StationID + "," + Convert.ToInt16(item.IsActive) + "," + item.LastUpdatedUserId + "|";
                    }
                    dto.RsStation = strTemp;
                    strTemp = string.Empty;
                }




                if (dto.RestrictionWeekDayDTO != null)
                {
                    foreach (var item in dto.RestrictionWeekDayDTO)
                    {
                        strTemp = strTemp + item.RestrictionGroupID + "," + item.WeekDayID + "," + Convert.ToInt16(item.IsActive) + "," + item.LastUpdatedUserId + "|";
                    }
                    dto.RsWeekday = strTemp;
                    strTemp = string.Empty;
                }

                if (dto.RestrictionGroupTimeDTO != null)
                {
                    foreach (var item in dto.RestrictionGroupTimeDTO)
                    {
                        strTemp = strTemp + item.RestrictionGroupID + "," + item.FromHour + "," + item.ToHour + "," + Convert.ToInt16(item.IsActive) + "," + item.LastUpdatedUserId + "," + item.LastUpdatedLocationID + "|";
                        //strTemp = strTemp + item.RestrictionGroupID + "," + item.FromHour + "," + item.ToHour + "|";
                    }
                    dto.RsTime = strTemp;
                    strTemp = string.Empty;
                }

                return dto;
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }
        public List<ProductServiceBillingTypeDTO> GetProductServiceBillingType()
        {
            try
            {
                return _appService.GetProductServiceBillingType();
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }



        public List<ProductServiceBillingFrequencyDTO> GetProductServiceBillingFrequency(int? CustomerId)
        {
            try
            {
                return _appService.GetProductServiceBillingFrequency(CustomerId);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        public int UpdateProductServiceBillingFrequency(int? CustomerId, List<ProductServiceBillingFrequencyDTO> Dtos, int? LastLocationId, int? lastUpdateduser)
        {

            try
            {
                return _appService.UpdateProductServiceBillingFrequency(CustomerId,Dtos, LastLocationId, lastUpdateduser);
            }
            catch (Exception ex)
            {
                throw this.HandleException(ex);
            }
        }

        private string GetExceptionMsg(Exception ex)
        {
            try
            {
                //var messageToLog = string.Format("Message: {0}, Stack Trace: {1}, Inner Exception: {2}", ex.Message, ex.StackTrace, ex.InnerException != null ? ex.InnerException.ToString() : string.Empty);
                try
                {
                    _logger.Log(ex.ToString(), EventLogger.Enumerations.LoggerEventType.Error);
                }
                catch { }

                // do not send actual .NET exception to UI
                var erroMessage = "An error occurred during operation"; //string.Format("Error Message - {0}", ex.Message);
                var errCode = "-1";
                var mesgCode = string.Empty;

                string spName = ConfigurationManager.AppSettings["spName"];
                if (ex.Message.Contains(spName.ToUpper()))
                {
                    string ErrorMessage = ConfigurationManager.AppSettings["ErrorMessage"];

                    errCode = spName;
                    erroMessage = ErrorMessage;
                }

                if (ex.InnerException != null)
                {
                    var mesg = ex.InnerException.Message;
                    if (ex.InnerException.Message.Contains("20001"))
                    {
                        // use regex to extract error code and message;                       
                        var groups = Regex.Match(mesg, @"^ORA-20001:(\s\(ErrorCode:\s<(\d{1,})>\))?\s(.{1,})\n", RegexOptions.IgnoreCase).Groups;
                        // atleast 4 matches is required
                        if (groups.Count >= 4)
                        {
                            errCode = "20001";
                            mesgCode = groups[2].Value.Trim();
                            erroMessage = groups[3].Value.Trim();
                            if (erroMessage.Contains("|"))
                                erroMessage = erroMessage.Remove(erroMessage.IndexOf("|"));
                        }
                    }
                    else if (ex.InnerException.Message.Contains("20002"))
                    {
                        // use regex to extract error code and message;                       
                        var groups = Regex.Match(mesg, @"^ORA-20002:\s(.{1,})\n", RegexOptions.IgnoreCase).Groups;
                        // atleast 2 matches is required
                        if (groups.Count >= 2)
                        {
                            errCode = "20002";
                            erroMessage = groups[1].Value.Trim();
                            if (erroMessage.Contains("|"))
                                erroMessage = erroMessage.Remove(erroMessage.IndexOf("|"));
                        }
                    }
                    else
                        erroMessage = string.Format("{0} , Detailed Exception = {1}", erroMessage, ex.InnerException.Message);
                }

                return erroMessage;
            }
            catch (Exception)
            {
                return ex.Message;
            }
        }
    }
}