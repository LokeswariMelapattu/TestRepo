using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Objects;
using System.Transactions;

namespace DUC.CMS.CustomerService.DAL.Repository
{
    public class TokenRepository : Repository.Repository<TOKEN>
    {
        public TokenRepository(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        //F36      
        public List<TOKEN_STATUS_REASON> GetAllTokenStatusReasons(int statusID)
        {
            return _dbContext.Context.GetAllTokenStatusReasons(statusID).ToList();
        }

        //F39
        public List<TOKEN_STATUS> GetAllTokenStatus()
        {
            return _dbContext.Context.GetAllTokenStatus().ToList();
        }

        //F43        
        public List<VEHICLE_MAKE> GetAllVehicleMakes()
        {
            return _dbContext.Context.GetAllVehicleMakes().ToList();
        }

        //F51       
        public List<CTVehicleMakeModel> GetAllVehicleModels()
        {
            return _dbContext.Context.GetAllVehicleMakeModels().ToList();
        }

        //F
        public List<TOKEN_TYPE> GetCustomerTokenTypes()
        {
            return _dbContext.Context.GetCustomerTokenTypes().ToList();
        }

        public List<TOKEN_TYPE> GetAllTokenTypes()
        {
            return _dbContext.Context.GetAllTokenTypes().ToList();
        }



        //F111      
        public int UpdateTokenInfo(TOKEN entity, out string ErrorMessage)
        {
            var eRROR_MESSAGE = new ObjectParameter("eRROR_MESSAGE", typeof(string));
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            var p_TOKEN_ID = new ObjectParameter("p_TOKEN_ID", entity.TOKEN_ID);
            var p_CODE = new ObjectParameter("p_CODE", typeof(string));
            p_CODE.Value = entity.CODE;

            _dbContext.Context.UpdateTokenInfo(p_TOKEN_ID, p_CODE, entity.TOKEN_TYPE_ID, entity.EXPIRY_DATE, entity.RESTRICTION_GROUP_ID, entity.NUMBER_OF_ACTIVE_TAGS,
              entity.TOKEN_STATUS_ID, entity.TOKEN_STATUS_REASON_ID, entity.IS_STATUS_INHERITED, entity.WORK_ORDER_ID, entity.PERSONALIZATION_ORDER_ID,
              entity.SERIAL, entity.SECOND_SERIAL, entity.THIRD_SERIAL, entity.TOKEN_CHIP_NUMBER, entity.SECOND_TOKEN_CHIP_NUMBER, entity.IS_ACTIVE, entity.CUSTOMER_ID, entity.BENEFICIARY_ID,
              entity.NAME, entity.VEHICLE_INFO_ID, entity.CUSTOM_EXPIRY_YEARS, entity.IS_TRX_NOTIFY, eRROR_MESSAGE, entity.LAST_UPDATED_USER_ID, entity.LAST_UPDATED_DATE, entity.LAST_LOCATION_ID, p_RESULT
            );
            ErrorMessage = Convert.ToString(eRROR_MESSAGE.Value);
            if (Convert.ToInt32(p_RESULT.Value) == 0)
                return -1;
            return Convert.ToInt32(p_TOKEN_ID.Value);
        }

        //F112 -- not used
        //public List<CTRestrictionGroupInfo> GetAllRestrictionGroups()
        //{
        //    return _dbContext.Context.GetAllRestrictionGroups().ToList();
        //}

        //F113        
        public List<CTVehicleRegisterSearchResult> SearchVehicleRegister(int? makeID, int? modelID, int? year, int? CC, int? FUEL_INLET, int? FUEL_CAPACITY, int pageNo, int pageSize, out int rowCount)
        {
            var p_PAGE_NO = new ObjectParameter("p_PAGE_NO", typeof(decimal));
            p_PAGE_NO.Value = pageNo;
            var p_PAGE_SIZE = new ObjectParameter("p_PAGE_SIZE", typeof(decimal));
            p_PAGE_SIZE.Value = pageSize;
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.SearchVehicleRegister(null, makeID, modelID, year, null, CC, FUEL_INLET, FUEL_CAPACITY, null, null, null, p_PAGE_NO, p_PAGE_SIZE, p_ROW_COUNT).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }

        public CTGetVehicleInfo SearchTrafficVehicleInfo(int EmirateId, int ColorID, string PlateNO, int KindId)
        {
            var data = _dbContext.Context.GetVehicleInfo(EmirateId, ColorID, PlateNO, KindId).ToList();

            if (data != null & data.Count > 0)
                return data[0];

            return null;
        }

        //F115      
        public List<VEHICLE_TYPE> GetAllVehicleTypes()
        {
            return _dbContext.Context.GetAllVehicleTypes().ToList();
        }

        //F116      
        public List<VEHICLE_COLOR> GetVehiclePlateColors()
        {
            return _dbContext.Context.GetVehiclePlateColors().ToList();
        }

        //F117       
        public List<CTTokenRestrictionInfo> GetTokenRestrictionInfo(int tokenID)
        {
            return _dbContext.Context.GetTokenRestrictionInfo(tokenID).ToList();
        }

        //F118    
        public int UpdateTokenRestriction(CTTokenRestriction entity)
        {
            var p_STATUS = new ObjectParameter("p_STATUS", typeof(decimal));
            var p_RS_GROUP_ID = new ObjectParameter("p_RS_GROUP_ID", typeof(decimal));
            if (entity.RESTRICTIONGROUPID != null)
                p_RS_GROUP_ID.Value = entity.RESTRICTIONGROUPID;
            _dbContext.Context.UpdateTokenRestriction(entity.TOKENID, entity.TOKENTYPEID, p_RS_GROUP_ID, entity.CUSTOMERID, entity.BENEFICIARYID,
                entity.TOKENNAME, entity.RESTRICTIONGROUPNAME, entity.IS_SYSTEM_DEFINED_GROUP, entity.CONSECUTIVE_USAGE_RESTRICTION, entity.IS_RESTRICTED_IN_HOLIDAY,
                entity.IS_REQUIRE_ODOMETER_INPUT, entity.IS_REQUIRE_DRIVER_CARD, entity.CAN_BUY_DRY_STOCK, entity.CAN_USE_ADNOC_SERVICE, entity.LAST_UPDATED_USER_ID, entity.LAST_UPDATE_DATE,
                entity.RS_AMOUNT, entity.RS_PRODUCT, entity.RS_QUANTITY, entity.RS_STATION, entity.RS_TRANSNO, entity.RS_TRANS, entity.RS_WEEKDAY, entity.RS_TIME, entity.LastLocationID, p_STATUS);
            return Convert.ToInt32(p_RS_GROUP_ID.Value);
        }


        public bool IsZeroTransactionToken(int tokenId)
        {
            var P_RES = new ObjectParameter("P_RES", typeof(Int32));
            _dbContext.Context.IsZeroTransactionToken(tokenId, P_RES);

            if (P_RES != null && Convert.ToInt16(P_RES.Value) == 1)
            {
                return true;
            }
            return false;
        }


        public int SetTokenUsedAmount(int tokenId, decimal usedAmount, int UserID, int LocationId)
        {
            return _dbContext.Context.SetTokenUsedAmount(tokenId, usedAmount, UserID, LocationId);
        }

        public List<CTReceiptTransProduct> GetProductListByTransId(int? TransactionId)
        {
            return _dbContext.Context.GetProductListByTransId(TransactionId).ToList();
        }


        //F119
        public List<CTTokenSearch> SearchToken(CTTokenSearchInput entity, int pageNo, int pageSize, out int rowCount)
        {
            var p_PAGE_NO = new ObjectParameter("p_PAGE_NO", typeof(decimal));
            p_PAGE_NO.Value = pageNo;
            var p_PAGE_SIZE = new ObjectParameter("p_PAGE_SIZE", typeof(decimal));
            p_PAGE_SIZE.Value = pageSize;
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.SearchToken(entity.TOKEN_ID, entity.CODE, entity.TOKEN_NAME, entity.BENEFICIARY_ID, entity.RESTRICTION_GROUP_ID,
                entity.TOKEN_STATUS_ID, entity.TOKEN_TYPE_ID, entity.REGISTER_FROM_DATE, entity.REGISTER_TO_DATE, entity.SERIAL, entity.CUSTOMER_ID,
                entity.UserID, entity.EMPLOYEE_ID, entity.IdNumber, p_PAGE_NO, p_PAGE_SIZE, p_ROW_COUNT).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }

        //F119
        public List<CTCustomerTokenSearch> CustomerSearchToken(CTCustomerTokenSearchInput entity, int pageNo, int pageSize, out int rowCount)
        {
            var p_PAGE_NO = new ObjectParameter("p_PAGE_NO", typeof(decimal));
            p_PAGE_NO.Value = pageNo;
            var p_PAGE_SIZE = new ObjectParameter("p_PAGE_SIZE", typeof(decimal));
            p_PAGE_SIZE.Value = pageSize;
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.CustomerTokenSearch(entity.CUSTOMER_NAME, entity.CUSTOMER_CODE, entity.BENEFICIARY_NAME, entity.BENEFICIARY_CODE,
                entity.TOKEN_ID, entity.CODE, entity.TOKEN_NAME, entity.BENEFICIARY_ID, entity.RESTRICTION_GROUP_ID,
                entity.TOKEN_STATUS_ID, entity.TOKEN_TYPE_ID, entity.REGISTER_FROM_DATE, entity.REGISTER_TO_DATE, entity.SERIAL, entity.CUSTOMER_ID,
                entity.UserID, entity.EMPLOYEE_ID, entity.IdNumber, pageNo, pageSize, p_ROW_COUNT).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }

        //F120
        public TOKEN GetTokenInfo(int tokenId)
        {
            var data = _dbContext.Context.GetTokenInfo(tokenId).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }

        //F121
        public List<CTTokenStatusHistory> GetTokenStatusHistory(int tokenId, int pageNo, int pageSize, out int rowCount)
        {
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.GetTokenStatusHistory(tokenId, pageNo, pageSize, p_ROW_COUNT).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }

        //F122
        public bool UpdateTokenStatus(int tokenId, string tokenCode, int statusId, int? statusReasonId, CTBase Audit)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.UpdateTokenStatus(tokenId, tokenCode, statusId, statusReasonId, Audit.LastUserID, Audit.LastUpdateDate, Audit.LastLocationID, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        //F123    
        public int UpdateRestrictionGroupProfile(CTRestrictionGroup entity, CTBase Audit)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            var p_RS_GROUP_ID = new ObjectParameter("p_RS_GROUP_ID", entity.RESTRICTION_GROUP_ID);
            _dbContext.Context.UpdateRestrictionGroupProfile(p_RS_GROUP_ID, entity.RS_GRP_NAME, entity.RS_GRP_DESCRIPTION, entity.RS_GRP_IS_SYS_DEF_GRP,
                entity.CONSECUTIVE_USAGE_RESTRICTION, entity.IS_RESTRICTED_IN_HOLIDAY, entity.IS_REQUIRE_ODOMETER_INPUT, entity.IS_REQUIRE_DRIVER_CARD,
                entity.CAN_BUY_DRY_STOCK, entity.CAN_USE_ADNOC_SERVICE, entity.IS_ACTIVE, entity.RS_AMOUNT, entity.RS_PRODUCT, entity.RS_QUANTITY, entity.RS_STATION, entity.RS_TRANSNO,
                entity.RS_TRANS, entity.RS_WEEKDAY, entity.RS_TIME, entity.CUSTOMER_ID, Audit.LastUserID, Audit.LastUpdateDate, Audit.LastLocationID, p_RESULT);
            return Convert.ToInt32(p_RS_GROUP_ID.Value);
        }

        //F125
        public bool ChangeTokenBeneficiary(int tokenID, int newCustomerID, int newBeneficiaryID, int UserID, DateTime LastUpdatedDate, int LocationId, out int newTokenID)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            var p_NEW_TOKEN_ID = new ObjectParameter("p_NEW_TOKEN_ID", typeof(decimal));
            _dbContext.Context.ChangeTokenBeneficiary(tokenID, newCustomerID, newBeneficiaryID, p_NEW_TOKEN_ID, UserID, LastUpdatedDate, LocationId, p_RESULT);
            newTokenID = Convert.ToInt32(p_NEW_TOKEN_ID.Value);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        //F126
        public bool AddBatchTokenInfo(CTBatchToken entity, CTBase Audit, out string remarks, out string tokenCode, out int PersonalizationID)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            var p_STATUS_REMARK = new ObjectParameter("p_STATUS_REMARK", typeof(string));
            var p_TOKEN_CODE = new ObjectParameter("p_TOKEN_CODE", typeof(string));
            var p_PersonalizationID = new ObjectParameter("P_PERSONALIZATION_ORD_ID", entity.PersonalizationOrderID);

            _dbContext.Context.AddBatchTokenInfo(entity.CustomerID, entity.BeneficiaryID, entity.TokenName, p_TOKEN_CODE, entity.TokenTypeId,
                entity.ExpiryDate, entity.RestrictionGroupId, entity.TokenStatusId, entity.TokenStatusReasonId, entity.IsActive, entity.CardCentreID, entity.AppointmentDate,
                entity.ReasonID, entity.PersonalizationOrderStatusID, entity.PersonalizationOrderTypeID, entity.IdentificationTypeID, entity.IdentityNumber, p_STATUS_REMARK, p_PersonalizationID, Audit.LastUserID, Audit.LastUpdateDate, Audit.LastLocationID, p_RESULT);
            remarks = Convert.ToString(p_STATUS_REMARK.Value);
            tokenCode = Convert.ToString(p_TOKEN_CODE.Value);
            PersonalizationID = Convert.ToInt32(p_PersonalizationID.Value);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        //F142
        public bool AddPersonalizationRequest(CTPersonalization entity, CTBase Audit)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.AddPersonalizationRequest(entity.TOKEN_ID, entity.PERSONALIZATION_NUMBER, entity.PERSONALIZATION_STATUS_ID, entity.CARD_CENTER_ID,
                entity.APPOINTMENT_DATE_TIME, null, entity.PERSONALIZATION_ORDER_TYPE_ID, entity.PERSONALIZATION_REASON_ID, entity.IDENTIFICATION_TYPE_ID, entity.IDENTITY_NUMBER
                , Audit.LastUserID, Audit.LastUpdateDate, Audit.LastLocationID, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        //143  
        public bool AddWorkOrderRequest(CTWorkOrder entity)
        {
            var p_WORK_ORDER_ID = new ObjectParameter("p_WORK_ORDER_ID", entity.WORK_ORDER_ID);

            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.AddWorkOrderRequest(entity.TOKEN_ID, p_WORK_ORDER_ID, entity.WORK_ORDER_NUMBER, entity.WORK_ORDER_STATUS_ID, entity.WORK_ORDER_STATUS_REASON_ID, entity.VEHICLE_INFO_ID,
                entity.VEHICLE_DEPOT_ID, entity.APPOINTMENT_DATETIME, entity.WORK_ORDER_TYPE_ID, entity.LAST_UPDATED_USER_ID, entity.LAST_UPDATED_DATE,
                entity.RECIPIENT_TYPE_ID, entity.RECIPIENT_ID_NUMBER, entity.LastLocationID, p_RESULT, entity.APPOINTMENT_TILL_DATETIME);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        //F144
        public bool IsReplacementIssueRequest(int tokenID)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.IsReplacementIssueRequest(tokenID, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        //F145
        public bool ReplacePersonalizationOrderRequest(CTPersonalization entity, CTBase Audit)
        {
            var P_Result = new ObjectParameter("P_Result", typeof(decimal));
            _dbContext.Context.ReplacePersonalizationOrderRequest(entity.TOKEN_ID, entity.PERSONALIZATION_NUMBER, entity.PERSONALIZATION_STATUS_ID,
                entity.CARD_CENTER_ID, entity.APPOINTMENT_DATE_TIME, DateTime.Now, entity.PERSONALIZATION_ORDER_TYPE_ID, entity.PERSONALIZATION_REASON_ID,
                entity.IDENTIFICATION_TYPE_ID, entity.IDENTITY_NUMBER, Audit.LastUserID, Audit.LastUpdateDate, Audit.LastLocationID, P_Result);
            return Convert.ToBoolean(P_Result.Value);
        }

        //F146
        public bool ReplaceWorkOrderRequest(CTWorkOrder entity)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.ReplaceWorkOrderRequest(entity.TOKEN_ID, entity.WORK_ORDER_NUMBER, entity.WORK_ORDER_STATUS_ID, entity.VEHICLE_DEPOT_ID,
                entity.APPOINTMENT_DATETIME, entity.SERVICE_DATETIME, entity.WORK_ORDER_TYPE_ID, entity.WORK_ORDER_STATUS_REASON_ID, entity.RECIPIENT_TYPE_ID,
                entity.RECIPIENT_ID_NUMBER, entity.LAST_UPDATED_USER_ID, entity.LAST_UPDATED_DATE, entity.LastLocationID, p_RESULT, entity.APPOINTMENT_TILL_DATETIME);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        ///F154
        public int IsTokenReplacementPermitted(int tokenID, out string cardSerialNo)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            var p_Message = new ObjectParameter("p_Message", typeof(string));
            _dbContext.Context.IsTokenReplacementPermitted(tokenID, p_Message, p_RESULT);
            cardSerialNo = Convert.ToString(p_Message.Value);
            return Convert.ToInt32(p_RESULT.Value);
        }

        //F155
        public List<CTDictionary> GetAllCustomerBeneficiaryNames(int customerID)
        {
            return _dbContext.Context.GetAllCustomerBeneficiaryNames(customerID).ToList();
        }

        //F156
        public List<CTDictionary> GetAllRestrictionGroupNames(int? CustomerID)
        {
            return _dbContext.Context.GetAllRestrictionGroupNames(CustomerID).ToList();
        }

        //F159
        public List<DEPOT> GetAllVehicleDepot()
        {
            return _dbContext.Context.GetAllVehicleDepot().ToList();
        }

        //F160
        public List<CTRestrictionSummary> GetRestrictionSummary(int restrictionGroupID)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            return _dbContext.Context.GetRestrictionSummary(restrictionGroupID, p_RESULT).ToList();
        }

        //F161
        public List<TIME_FREQUENCY> GetAllTimeFrequency()
        {
            return _dbContext.Context.GetAllTimeFrequency().ToList();
        }

        //F162
        public List<VEHICLE_STATE> GetAllVehicleStates()
        {
            return _dbContext.Context.GetAllVehicleStates().ToList();
        }

        //F163
        public List<CTUnmappedTokenSearch> SearchUnmappedToken(string beneficiaryName, string tokenName, int customerID, int UserID, int pageNo, int pageSize, out int rowCount)
        {
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.SearchUnmappedToken(beneficiaryName, tokenName, customerID, UserID, pageNo, pageSize, p_ROW_COUNT).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }

        //F164
        public bool AddBatchTokenVehicleMap(CTBatchTokenVehicleMap entity)
        {
            _dbContext.Context.AddBatchTokenVehicleMap(entity.TokenID, entity.PlateNumber, entity.PlateColorID, entity.ColorID, entity.StateID, entity.ChassisNumber,
                entity.RegisterID, entity.TypeID, entity.LastUpdatedUser, entity.LastUpdateDate, entity.LastLocationID);
            return true;
        }

        //F165
        public bool IsTokenDeletionPermitted(int tokenID)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            var p_MESSAGE = new ObjectParameter("p_MESSAGE", typeof(string));
            _dbContext.Context.IsTokenDeletionPermitted(tokenID, p_RESULT, p_MESSAGE);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        //F166
        public bool IsBeneficiaryDeletionPermitted(int beneficiaryID)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            var p_MESSAGE = new ObjectParameter("p_MESSAGE", typeof(string));
            _dbContext.Context.IsBeneficiaryDeletionPermitted(beneficiaryID, p_RESULT, p_MESSAGE);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        //F167
        public bool DeleteToken(int tokenID, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            _dbContext.Context.DeleteToken(tokenID, UserID, LastUpdatedDate, LocationId);
            return true;
        }

        //F169
        public bool IsNewPINPermitted(string pinNo, int type, int customerID)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.IsNewPINPermitted(pinNo, type, customerID, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        //F171
        public List<CTProperty> GetAllStations()
        {
            return _dbContext.Context.GetAllStations().ToList();
        }

        //F172
        public List<CTProperty> GetAllStationGroups()
        {
            return _dbContext.Context.GetAllStationGroups().ToList();
        }

        //F173
        public List<CTProperty> GetAllUngroupedStations()
        {
            return _dbContext.Context.GetAllUngroupedStations().ToList();
        }

        //F174
        public List<CTProperty> GetStationByGroup(int groupID)
        {
            return _dbContext.Context.GetStationByGroup(groupID).ToList();
        }

        //F176
        public List<PERSONALIZATION_ORDER_REASON> GetAllPersonalizationReasons()
        {
            return _dbContext.Context.GetAllPersonalizationReasons().ToList();
        }

        //F177
        public List<WORK_ORDER_REASON> GetAllWorkOrderReasons()
        {
            return _dbContext.Context.GetAllWorkOrderReasons().ToList();
        }

        //F178
        public List<CTRestrictionGroupProfile> SearchRestrictionGroupProfile(string restrictionGroupName, int? customerID, int pageNo, int pageSize, out int rowCount)
        {
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.SearchRestrictionGroupProfile(restrictionGroupName, customerID, pageNo, pageSize, p_ROW_COUNT).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }


        public int GetTokenAmount(int tokenID, out decimal tokenAmount)
        {
            var p_ROW_COUNT = new ObjectParameter("P_USED_AMOUNT", typeof(decimal));
            var result = _dbContext.Context.GetTokenAmount(tokenID, p_ROW_COUNT);
            tokenAmount = Convert.ToDecimal(p_ROW_COUNT.Value);
            return result;
        }


        ////F179
        public CTRestrictionGroupProfile GetRestrictionGroupById(int restrictionGroupID)
        {
            var data = _dbContext.Context.GetRestrictionGroupById(restrictionGroupID).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }

        //F180
        public bool DeleteRestrictionGroupByID(int restrictionGroupID, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.DeleteRestrictionGroupByID(restrictionGroupID, UserID, LastUpdatedDate, LocationId, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        //F181
        public bool UpdateRestrictionSummary(string restrictionSummary, CTBase Audit)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.UpdateRestrictionSummary(restrictionSummary, Audit.LastUserID, Audit.LastUpdateDate, Audit.LastLocationID, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        //F182
        public CTPersonalizationOrder GetPersonalizationInfo(int personalizationOrderId)
        {
            var data = _dbContext.Context.GetPersonalizationInfo(personalizationOrderId).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }

        //F183
        public WORK_ORDER GetWorkOrderInfo(int workOrderID)
        {
            var data = _dbContext.Context.GetWorkOrderInfo(workOrderID).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }

        //F184
        public bool IsValidRechargeAmount(decimal amount, out string remarks)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            var p_ERROR_MESSAGE = new ObjectParameter("p_ERROR_MESSAGE", typeof(string));
            _dbContext.Context.IsValidRechargeAmount(amount, p_ERROR_MESSAGE, p_RESULT);
            remarks = Convert.ToString(p_ERROR_MESSAGE.Value);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        //F185
        public List<CTDriverCard> SearchDriverCard(CTDriverCardSearch entity, int pageNo, int pageSize, out int rowCount)
        {
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.SearchDriverCard(entity.TOKEN_ID, entity.TOKEN_NAME, entity.TOKEN_SERIAL, entity.TOKEN_CODE, entity.STATUS_ID,
                entity.REG_FROM_DATE, entity.REG_TO_DATE, entity.CUSTOMER_ID, pageNo, pageSize, p_ROW_COUNT).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }

        //F186
        public bool MapCustomerDriverCard(int paymentTokenID, int driverCardTokenID, CTBase Audit)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.MapCustomerDriverCard(paymentTokenID, driverCardTokenID, Audit.LastUserID, Audit.LastUpdateDate, Audit.LastLocationID, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        //F187
        public bool RenewEmirateID(int tokenID, string newCardSerial, DateTime ExpiryDate, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.RenewEmirateID(tokenID, newCardSerial, ExpiryDate, UserID, LastUpdatedDate, LocationId, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        //F188
        public List<PRODUCT> GetAllProductsForToken(int tokenID)
        {
            return _dbContext.Context.GetAllProductsForToken(tokenID).ToList();
        }

        //F191
        public List<TOKEN_STATUS> GetAllTokenStatusByID(int tokenId)
        {
            return _dbContext.Context.GetAllTokenStatusByID(tokenId).ToList();
        }

        //F195
        public int LoginUser(string userName)
        {
            var p_USERID = new ObjectParameter("p_USERID", typeof(decimal));
            _dbContext.Context.LoginUser(userName, p_USERID);
            return Convert.ToInt32(p_USERID.Value);
        }

        //F196
        public List<CTTokenSearch> SearchRestrictedToken(CTTokenSearchInput entity, int pageNo, int pageSize, out int rowCount)
        {
            var p_PAGE_NO = new ObjectParameter("p_PAGE_NO", typeof(decimal));
            p_PAGE_NO.Value = pageNo;
            var p_PAGE_SIZE = new ObjectParameter("p_PAGE_SIZE", typeof(decimal));
            p_PAGE_SIZE.Value = pageSize;
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.SearchRestrictedToken(entity.TOKEN_ID, entity.CODE, entity.TOKEN_NAME, entity.BENEFICIARY_ID, entity.RESTRICTION_GROUP_ID, entity.TOKEN_STATUS_ID,
                entity.TOKEN_TYPE_ID, entity.REGISTER_FROM_DATE, entity.REGISTER_TO_DATE, entity.SERIAL, entity.CUSTOMER_ID, p_PAGE_NO, p_PAGE_SIZE, p_ROW_COUNT, entity.CURRENT_TOKEN_ID).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }

        //F198
        public string GenerateDriverCardName(int CustomerID)
        {
            var p_DRIVER_NAME = new ObjectParameter("p_DRIVER_NAME", typeof(string));
            _dbContext.Context.GenerateDriverCardName(CustomerID, p_DRIVER_NAME);
            return Convert.ToString(p_DRIVER_NAME.Value);
        }

        //F199
        public string GenerateTokenName(int CustomerID, int BeneficiaryID, int TokenTypeID)
        {
            var p_TOKEN_NAME = new ObjectParameter("p_TOKEN_NAME", typeof(string));
            _dbContext.Context.GenerateTokenName(CustomerID, BeneficiaryID, TokenTypeID, p_TOKEN_NAME).ToString();
            return Convert.ToString(p_TOKEN_NAME.Value);
        }

        //F202
        public string GetTokenCodeByID(int TokenID)
        {
            var p_RESULT = new ObjectParameter("p_CODE", typeof(string));
            _dbContext.Context.GetTokenCodeByID(TokenID, p_RESULT);
            return Convert.ToString(p_RESULT.Value);
        }

        public List<CTTokenSearch> SearchNonTerminatedTokens(CTTokenSearchInput entity, int pageNo, int pageSize, out int rowCount)
        {
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.SearchNonTerminatedTokens(entity.TOKEN_ID, entity.TOKEN_NAME, entity.BENEFICIARY_ID, entity.RESTRICTION_GROUP_ID, entity.TOKEN_STATUS_ID,
                   entity.TOKEN_TYPE_ID, entity.REGISTER_FROM_DATE, entity.REGISTER_TO_DATE, entity.SERIAL, entity.CUSTOMER_ID, pageNo, pageSize, p_ROW_COUNT).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }

        //F210
        public bool IsEmirateIDAlreadyRegistered(string EmirateID)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.IsEmirateIDAlreadyRegistered(EmirateID, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }
        public bool IsKNPCCardAlreadyRegistered(string Serial)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.IsKNPCCardAlreadyRegistered(Serial, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        //F211
        public string AddBatchBeneficiary(CTBatchBeneficiary entity, CTBase audit, out string remarks, out int BeneficiaryId)
        {
            var p_BENEFICIARY_CODE = new ObjectParameter("p_BENEFICIARY_CODE", typeof(string));
            var p_STATUS_REMARK = new ObjectParameter("p_STATUS_REMARK", typeof(string));
            var P_BENEFICIARYID = new ObjectParameter("P_BENEFICIARY_ID", typeof(string));
            _dbContext.Context.AddBatchBeneficiary(p_BENEFICIARY_CODE, entity.CustomerID, entity.BeneficiaryName, entity.Mobile, entity.Email, entity.PIN, entity.IdentificationTypeID,
                entity.IdentificationID, entity.NationalityID, entity.BeneficiaryStatusID, entity.BeneficiaryStatusReasonID, entity.IsActive, entity.Gender, entity.DateOfBirth, audit.LastUserID, audit.LastUpdateDate, audit.LastLocationID, p_STATUS_REMARK, P_BENEFICIARYID);
            remarks = Convert.ToString(p_STATUS_REMARK.Value);
            BeneficiaryId = Convert.ToInt32(P_BENEFICIARYID.Value);
            return Convert.ToString(p_BENEFICIARY_CODE.Value);
        }

        //F212
        public List<CTName> GenerateBatchTokenName(int customerID, int tokenCount, int tokenTypeID)
        {
            return _dbContext.Context.GenerateBatchTokenName(customerID, tokenCount, tokenTypeID).ToList();
        }

        //F213
        public List<CTMapCustomer> MapSearch(CTMapSearch entity)
        {
            return _dbContext.Context.MapSearch(entity.RecordCount, entity.CustomerID, entity.BeneficiaryCode, entity.BeneficiaryName, entity.TokenCode, entity.TokenName).ToList();
        }

        //F213
        public List<CTMapCustomer> AccountMapSearch(CTMapSearch entity, int pageNo, int pageSize, out int rowCount)
        {
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.AccountMapSearch(entity.CustomerID, entity.BeneficiaryCode, entity.BeneficiaryName, entity.TokenCode, entity.TokenName, entity.UserID, pageNo, pageSize, p_ROW_COUNT).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }

        //F214
        public bool IsRestrictionGroupNameAlreadyExist(string restrictionGroupName, int? customerID)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.IsRestrictionGroupNameAlreadyExist(restrictionGroupName, customerID, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        //F217
        public List<CTDriverCard> SearchMappableDriverCard(CTDriverCardSearch entity, int pageNo, int pageSize, out int rowCount)
        {
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.SearchMappableDriverCard(entity.TOKEN_ID, entity.TOKEN_NAME, entity.TOKEN_SERIAL, entity.TOKEN_CODE, entity.REG_FROM_DATE, entity.REG_TO_DATE,
                        entity.CUSTOMER_ID, entity.CURRENT_TOKEN_ID, pageNo, pageSize, p_ROW_COUNT).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }

        //F221
        public bool IsRestrictionGroupAllowedForToken(int tokenTypeID, int restrictionGroupID, out string message)
        {
            var p_MESSAGE_CODE = new ObjectParameter("p_MESSAGE_CODE", typeof(decimal));
            var p_MESSAGE = new ObjectParameter("p_MESSAGE", typeof(string));
            _dbContext.Context.IsRestrictionGroupAllowedForToken(tokenTypeID, restrictionGroupID, p_MESSAGE_CODE, p_MESSAGE);
            message = Convert.ToString(p_MESSAGE.Value);
            if (Convert.ToInt32(p_MESSAGE_CODE.Value) == -1 || Convert.ToInt32(p_MESSAGE_CODE.Value) == 0)
                return false;
            return Convert.ToBoolean(p_MESSAGE_CODE.Value);
        }

        //F222
        public int[] GetPrivilegedPagesForModule(string userName, int moduleID)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            var data = _dbContext.Context.GetPrivilegedPagesForModule(userName, moduleID, p_RESULT).ToList();
            if (Convert.ToBoolean(p_RESULT.Value))
                return data.ConvertAll<int>(p => (int)p.PAGE_ID).ToArray();
            return null;
        }

        //F223
        public bool IsRestrictionGroupInUse(int RestrictionGroupID)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.IsRestrictionGroupInUse(RestrictionGroupID, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        //F226
        public List<TOKEN_STATUS> GetAllDriverCardStatus()
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            return _dbContext.Context.GETALLDRIVERCARDSTATUS().ToList();
        }

        //F228
        public List<CTDriverCard> SearchNonTerminatedDriverCard(CTDriverCardSearch entity, int pageNo, int pageSize, out int rowCount)
        {
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.SearchNonTerminatedDriverCard(entity.TOKEN_ID, entity.TOKEN_NAME, entity.TOKEN_SERIAL, entity.TOKEN_CODE, entity.STATUS_ID,
                entity.REG_FROM_DATE, entity.REG_TO_DATE, entity.CUSTOMER_ID, entity.CURRENT_TOKEN_ID, pageNo, pageSize, p_ROW_COUNT).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }

        //F229
        public int[] GetPrivilegedFunctionsForPage(string userName, int pageID)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            var data = _dbContext.Context.GetPrivilegedFunctionsForPage(userName, pageID, p_RESULT).ToList();
            if (Convert.ToBoolean(p_RESULT.Value))
                return data.ConvertAll<int>(p => (int)p.FUNCTION_ID).ToArray();
            return null;
        }

        public List<CTVehicleModel> GetVehicleModelsByMake(int makeID)
        {
            return _dbContext.Context.GetVehicleModelsByMake(makeID).ToList();
        }

        public int UpdateVehicleInfo(VEHICLE_INFO entity)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            var p_VEHICLE_INFO_ID = new ObjectParameter("p_VEHICLE_INFO_ID", entity.VEHICLE_INFO_ID);

            _dbContext.Context.UpdateVehicleInfo(p_VEHICLE_INFO_ID, entity.PLATE_NUMBER, entity.COLOR_ID, entity.PLATE_COLOUR_ID, entity.STATE_ID,
                entity.CHASSIS_NUMBER, entity.VEHICLE_REGISTER_ID, entity.VEHICLE_TYPE_ID, entity.LAST_UPDATED_USER_ID, entity.LAST_UPDATED_DATE, entity.LAST_LOCATION_ID, p_RESULT, entity.ENGINE_NUMBER);

            return Convert.ToInt32(p_VEHICLE_INFO_ID.Value);
        }

        public List<CTVehicleInfo> GetVehicleInfoByID(int vehicleInfoID)
        {
            return _dbContext.Context.GetVehicleInfoByID(vehicleInfoID).ToList();
        }

        public CTVehicleRegister GetVehicleRegisterByID(int vehicleRegisterID)
        {
            var data = _dbContext.Context.GetVehicleRegisterByID(vehicleRegisterID).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }

        public List<CTTokenAccountSearch> AccountTokenSearch(CTAccountTokenSearch entity, int pageNo, int pageSize, out int rowCount)
        {
            var p_PAGE_NO = new ObjectParameter("p_PAGE_NO", typeof(decimal));
            p_PAGE_NO.Value = pageNo;
            var p_PAGE_SIZE = new ObjectParameter("p_PAGE_SIZE", typeof(decimal));
            p_PAGE_SIZE.Value = pageSize;
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.AccountTokenSearch(entity.TokenCode, entity.TokenName, entity.TokenTypeID, entity.TokenSerial, entity.CustomerName,
                entity.BeneficiaryName, entity.TokenStatusID, entity.RestrictionGroupID, entity.RegisterFromDate, entity.RegisterToDate, entity.IDNumber,
                entity.VehicleNo, entity.EmployeeID, entity.UserId, p_PAGE_NO, p_PAGE_SIZE, p_ROW_COUNT).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }

        public List<TIME_FREQUENCY> GetTimeFrequencyByID(int timeFrequencyId)
        {
            return _dbContext.Context.GetTimeFrequencyByID(timeFrequencyId).ToList();
        }

        public List<RESTRICTION_GROUP_AMOUNT> GetRestrictionAmount(int restrictionGroupID)
        {
            var data = _dbContext.Context.GetRestrictionAmount(restrictionGroupID).ToList();
            return data;
        }

        public List<CTRestrictionGroupProduct> GetRestrictionProduct(int restrictionGroupID)
        {
            return _dbContext.Context.GetRestrictionProduct(restrictionGroupID).ToList();
        }

        public List<CTRestrictionGroupQuanity> GetRestrictionQuantity(int restrictionGroupID)
        {
            return _dbContext.Context.GetRestrictionQuantity(restrictionGroupID).ToList();
        }

        public List<CTRestrictionGroupStations> GetRestrictionStation(int restrictionGroupID)
        {
            return _dbContext.Context.GetRestrictionStation(restrictionGroupID).ToList();
        }

        public List<RESTRICTION_GROUP_TRANS_NO> GetRestrictionTransNo(int restrictionGroupID)
        {
            return _dbContext.Context.GetRestrictionTransNo(restrictionGroupID).ToList();
        }

        public List<CTRestrictionGroupTrans> GetRestrictionTransaction(int restrictionGroupID)
        {
            return _dbContext.Context.GetRestrictionTransaction(restrictionGroupID).ToList();
        }

        public List<CTRestrictionGroupWeekDay> GetRestrictionWeekDay(int restrictionGroupID)
        {
            return _dbContext.Context.GetRestrictionWeekDay(restrictionGroupID).ToList();
        }

        public List<CTRestrictionGroupTime> GetRestrictionGroupTime(int restrictionGroupID)
        {
            return _dbContext.Context.GetRestrictionGroupTime(restrictionGroupID).ToList();
        }


        //F297
        public bool IsRestrictionExistForBeneficiaryToken(int beneficiary_id)
        {
            var p_RESULT = new ObjectParameter("P_RESULT", typeof(Int32));
            _dbContext.Context.IsRestrictionExistForBeneficiaryToken(beneficiary_id, p_RESULT);

            if (p_RESULT != null)
                return Convert.ToBoolean(p_RESULT.Value);
            return false;
        }

        //F298
        public bool RemoveRestrictionForBeneficiaryToken(int beneficiary_id, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            _dbContext.Context.RemoveRestrictionForBeneficiaryToken(beneficiary_id, UserID, LastUpdatedDate, LocationId);
            return true;
        }

        //F299     
        public List<CTSearchTokenToDeliverResult> SearchTokensReadyForDelivery(CTSearchTokenToDeliver entity, out int totalCount)
        {
            var totalCountParameter = new ObjectParameter("P_TOTAL_COUNT", typeof(Int32));
            var res = _dbContext.Context.SearchTokensReadyForDelivery(entity.TokenCode, entity.TokenName, entity.TokenTypeID, entity.BeneficiaryID, entity.BeneficiaryName,
                entity.TokenSerial, entity.CustomerID, entity.PageNumber, entity.PageSize, totalCountParameter).ToList();
            totalCount = Convert.ToInt32(totalCountParameter.Value);
            return res;
        }

        //F300
        public bool UpdateTokenDeliveredStatus(int token_id, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            var P_RESULT = new ObjectParameter("P_RESULT", typeof(Int32));
            _dbContext.Context.UpdateTokenDeliveredStatus(token_id, UserID, LastUpdatedDate, LocationId, P_RESULT);
            if (P_RESULT != null)
                return Convert.ToBoolean(P_RESULT.Value);
            return false;
        }

        //F301
        public List<TOKEN_TYPE> GetAllPersonalizationTokenTypes()
        {
            return _dbContext.Context.GetAllPersonalizationTokenTypes().ToList();
        }

        //F302
        public bool IsTokenRestrictionExistForCustomerTokens(int P_Customer_ID, int? BenenficiaryId)
        {
            var P_RESULT = new ObjectParameter("p_result", typeof(Int32));
            _dbContext.Context.IsTokenRestrictionExistForCustomerTokens(P_Customer_ID, BenenficiaryId, P_RESULT);
            if (P_RESULT != null)
                return Convert.ToBoolean(P_RESULT.Value);
            return false;
        }

        //F303
        public bool RemoveRestrictionForCustomerToken(int customer_id, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            _dbContext.Context.RemoveRestrictionForCustomerToken(customer_id, UserID, LastUpdatedDate, LocationId);
            return true;
        }

        //F316
        public CURRENCY GetCurrency()
        {
            var data = _dbContext.Context.GetCurrency().ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }

        //F317
        public List<CTDictionary> GetAllActiveBeneficiaryNames(int customerID)
        {
            return _dbContext.Context.GetAllActiveBeneficiaryNames(customerID).ToList();
        }

        //F319
        public bool IsVehicleChassisAlreadyRegistered(string ChassisNumber, int? TokenID, out string TokenCode)
        {
            var p_RESULT = new ObjectParameter("P_RESULT", typeof(Int32));
            var p_TokenCode = new ObjectParameter("P_CODE", typeof(string));
            _dbContext.Context.IsVehicleChassisAlreadyRegistered(ChassisNumber, TokenID, p_TokenCode, p_RESULT);
            TokenCode = Convert.ToString(p_TokenCode.Value);
            if (p_RESULT != null)
                return Convert.ToBoolean(p_RESULT.Value);
            return false;
        }

        //F320
        public bool IsVehicleDetailsAlreadyRegistered(string PlateNumber, int PlateColorID, int VehicleEmirateID, int VehicleTypeID, int? TokenID, int TokenTypeID, out string TokenCode)
        {
            var p_RESULT = new ObjectParameter("P_RESULT", typeof(Int32));
            var p_TokenCode = new ObjectParameter("P_CODE", typeof(string));
            _dbContext.Context.IsVehicleDetailsAlreadyRegistered(PlateNumber, PlateColorID, VehicleEmirateID, VehicleTypeID, TokenID, p_TokenCode, p_RESULT, TokenTypeID);
            TokenCode = Convert.ToString(p_TokenCode.Value);
            if (p_RESULT != null)
                return Convert.ToBoolean(p_RESULT.Value);
            return false;
        }

        //F319
        public bool IsVehicleChassisAlreadyRegistered(string ChassisNumber)
        {
            throw new NotImplementedException();
        }

        //F320
        public bool IsVehicleDetailsAlreadyRegistered(string PlateNumber, int PlateColorID, int VehicleEmirateID, int VehicleTypeID)
        {
            throw new NotImplementedException();
        }

        //F323
        public List<PERSONALIZATION_ORDER_TYPE> GetAllPersonalizationOrderTypes()
        {
            return _dbContext.Context.GetAllPersonalizationOrderTypes().ToList();
        }

        public List<WORK_ORDER_TYPE> GetAllWorkOrderTypes()
        {
            return _dbContext.Context.GetAllWorkOrderTypes().ToList();
        }

        public List<WORK_ORDER_STATUS> GetAllWorkOrderStatus()
        {
            return _dbContext.Context.GetAllWorkOrderStatus().ToList();
        }

        public List<PERSONALIZATION_ORDER_STATUS> GetAllPersonalizationOrderStatus()
        {
            return _dbContext.Context.GetAllPersonalizationOrderStatus().ToList();
        }

        public bool AddServiceTransaction(int ServiceID, int? CustomerID, int? BeneficiaryID, int? TokenID, int? UserId, int? LastUpdatedUserID, DateTime? LastUpdatedDate, int? LastLocationID)
        {
            var p_result = new ObjectParameter("P_RESULT", typeof(decimal));
            _dbContext.Context.AddServiceTransaction(ServiceID, CustomerID, BeneficiaryID, TokenID, LastLocationID, UserId, LastUpdatedUserID, LastUpdatedDate, LastLocationID, p_result);
            if (p_result != null)
                return Convert.ToBoolean(p_result.Value);
            return false;
        }

        public bool IsBalanceSufficientForBatchTokenPersonalization(int? customer_id, int batchCount)
        {
            var pResult = new ObjectParameter("P_RESULT", typeof(int));
            _dbContext.Context.IsBalanceSufficientForBatchTokenPersonalization(customer_id, batchCount, pResult);
            return Convert.ToBoolean(pResult.Value);
        }

        //F331
        public bool IsTokenBelongingToBatch(int tokenId)
        {
            var pResult = new ObjectParameter("P_RESULT", typeof(decimal));
            _dbContext.Context.IsTokenBelongingToBatch(tokenId, pResult);
            return Convert.ToBoolean(pResult.Value);
            // return false;
        }

        public List<CARD_CENTER> GetAllCardCentresForIdentity()
        {
            return _dbContext.Context.GetAllCardCentresForIdentity().ToList();
        }

        public List<CARD_CENTER> GetAllCardCentresForNonIdentity()
        {
            return _dbContext.Context.GetAllCardCentresForNonIdentity().ToList();
        }

        public List<CTProperty> GetVehicleColorBySourceID(int sourceId)
        {
            return _dbContext.Context.GetVehicleColorBySourceID(sourceId).ToList();
        }

        public List<CTProperty> GetVehicleKindBySourceAndColor(int sourceId, int Colorid)
        {
            return _dbContext.Context.GetVehicleKindBySourceAndColor(sourceId, Colorid).ToList();
        }

        public int UpdateVehicleRegister(VEHICLE_REGISTER VehicleRegister)
        {
            var pVehicleRegisterId = VehicleRegister.VEHICLE_REGISTER_ID < 0 ? new ObjectParameter("P_VEHICLE_REGISTER_ID", typeof(decimal)) :
                new ObjectParameter("P_VEHICLE_REGISTER_ID", VehicleRegister.VEHICLE_REGISTER_ID);
            _dbContext.Context.UpdateVehicleRegister(pVehicleRegisterId, VehicleRegister.MODEL_ID, VehicleRegister.MAKE_ID, VehicleRegister.YEAR, VehicleRegister.INVENTORY_UNIT_TYPE_ID, VehicleRegister.CC, VehicleRegister.FUEL_INLET
                , VehicleRegister.FUEL_CAPACITY, 1, VehicleRegister.LAST_UPDATED_USER_ID, VehicleRegister.LAST_UPDATED_DATE, VehicleRegister.LAST_LOCATION_ID);
            return Convert.ToInt32(pVehicleRegisterId.Value.ToString());
        }

        public List<TOKEN> GetBatchTokenInfo(int PersonalizationID)
        {
            return _dbContext.Context.GetBatchTokenInfo(PersonalizationID).ToList();
        }

        public int SearchVehicleRegisterByName(string MakeDesc, string ModelDesc, int? yearId, int? CC)
        {
            var pVehicleRegisterId = new ObjectParameter("V_VEHICLE_REGISTER_ID", typeof(decimal));
            _dbContext.Context.SearchVehicleRegisterByName(MakeDesc, ModelDesc, yearId, CC, pVehicleRegisterId);
            return Convert.ToInt32(pVehicleRegisterId.Value.ToString());

        }

        public bool IsTokenCustomExpiryApplied(int TokenId)
        {
            var pIsApplied = new ObjectParameter("P_IS_APPLIED", typeof(decimal));
            _dbContext.Context.IsTokenCustomExpiryApplied(TokenId, pIsApplied);
            return Convert.ToBoolean(pIsApplied.Value);

        }

        public List<STATION> GetAllStationsWithCoordinates()
        {
            return _dbContext.Context.GetAllStationsWithCoordinates().ToList();
        }


        public bool IssueToken(int TokenID, string Serial, string SecondSerial,string ThirdSerial, int UserID, int LocationId, int Mode, int IsFeeWaivedOff)
        {
            _dbContext.Context.IssueToken(TokenID, Serial, SecondSerial, ThirdSerial, UserID, LocationId, Convert.ToInt16(Mode), null);
            return true;
        }
        public VEHICLE_INFO_DUMMY GetDummyVehicleInfo(string vehicleTypeCode, string vehicleNumber)
        {
            return _dbContext.Context.VEHICLE_INFO_DUMMY.SingleOrDefault(x => x.TYPE_CODE == vehicleTypeCode && x.PLATE_NUMBER == vehicleNumber && x.IS_ACTIVE == 1);

        }
        public int SaveMOIVehicleRegister(CTVehicleRegisterSearchResult dto, int UserID, int LocationId)
        {
            var pVehicleRegisterId = new ObjectParameter("p_VEHICLE_REGISTER_ID", typeof(decimal));
            var p_Result = new ObjectParameter("p_Result", typeof(decimal));
            decimal? cc = null;
            decimal? YEAR = null;
            decimal? FUEL_INLET = null;
            if (!string.IsNullOrEmpty(dto.YEAR))
                YEAR = Convert.ToInt64(dto.YEAR);
            if (!string.IsNullOrEmpty(dto.FUEL_INLET))
                FUEL_INLET = Convert.ToInt64(dto.FUEL_INLET);
            if (!string.IsNullOrEmpty(dto.CC))
                cc = Convert.ToInt64(dto.CC);
            _dbContext.Context.SaveMOIVehicleRegister(pVehicleRegisterId, null, dto.MAKE_NAME_EN, dto.MAKE_NAME_AR, null, dto.MODEL_NAME_EN, dto.MODEL_NAME_AR,
            YEAR, cc, FUEL_INLET, dto.FUEL_CAPACITY, 1, UserID, DateTime.Now, LocationId, p_Result);
            if (Convert.ToInt32(p_Result.Value) == 1)
                return Convert.ToInt32(pVehicleRegisterId.Value);
            else
                return -1;
        }
        public bool IsVehicleChassisAlreadyExists(string ChassisNumber, int? TokenID, int TokenTypeID, out string TokenCode)
        {
            var p_RESULT = new ObjectParameter("P_RESULT", typeof(Int32));
            var p_TokenCode = new ObjectParameter("P_CODE", typeof(string));
            _dbContext.Context.IsVehicleChassisAlreadyExists(ChassisNumber, TokenID, TokenTypeID, p_TokenCode, p_RESULT);
            TokenCode = Convert.ToString(p_TokenCode.Value);
            if (p_RESULT != null)
                return Convert.ToBoolean(p_RESULT.Value);
            return false;
        }
        public List<CTConsumedAmountResult> GetConsumedAmount(int restrictionGroupID)
        {
            var data = _dbContext.Context.GetConsumedAmount(restrictionGroupID).ToList();
            return data;
        }
        public List<CTConsumedQuantityResult> GetConsumedQuantiy(int restrictionGroupID)
        {
            var data = _dbContext.Context.GetConsumedQuantiy(restrictionGroupID).ToList();
            return data;
        }
        public List<CTConsumedTransNoResult> GetConsumedTransNo(int restrictionGroupID)
        {
            var data = _dbContext.Context.GetConsumedTransNo(restrictionGroupID).ToList();
            return data;
        }

        public int AddBatchTokenDetails(TOKEN entity, CTTokenRestriction restriction, VEHICLE_INFO vehicleInfo, CTBase Audit, out string remarks, out string tokenCode)
        {
            using (var transactionScope = new TransactionScope())
            {
                var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
                var eRROR_MESSAGE = new ObjectParameter("eRROR_MESSAGE", typeof(string));
                var p_TOKEN_ID = new ObjectParameter("p_TOKEN_ID", entity.TOKEN_ID);
                var p_CODE = new ObjectParameter("p_CODE", typeof(string));
                p_CODE.Value = entity.CODE;
                var p_VEHICLE_INFO_ID = new ObjectParameter("p_VEHICLE_INFO_ID", typeof(decimal));
                _dbContext.Context.UpdateVehicleInfo(p_VEHICLE_INFO_ID, vehicleInfo.PLATE_NUMBER, vehicleInfo.COLOR_ID, vehicleInfo.PLATE_COLOUR_ID, vehicleInfo.STATE_ID,
                   vehicleInfo.CHASSIS_NUMBER, vehicleInfo.VEHICLE_REGISTER_ID, vehicleInfo.VEHICLE_TYPE_ID, entity.LAST_UPDATED_USER_ID, entity.LAST_UPDATED_DATE, entity.LAST_LOCATION_ID, p_RESULT, vehicleInfo.ENGINE_NUMBER);
                if (p_VEHICLE_INFO_ID.Value != DBNull.Value)
                    entity.VEHICLE_INFO_ID = Convert.ToInt32(p_VEHICLE_INFO_ID.Value);
                _dbContext.Context.UpdateTokenInfo(p_TOKEN_ID, p_CODE, entity.TOKEN_TYPE_ID, entity.EXPIRY_DATE, entity.RESTRICTION_GROUP_ID, entity.NUMBER_OF_ACTIVE_TAGS,
               entity.TOKEN_STATUS_ID, entity.TOKEN_STATUS_REASON_ID, entity.IS_STATUS_INHERITED, entity.WORK_ORDER_ID, entity.PERSONALIZATION_ORDER_ID,
               entity.SERIAL, entity.SECOND_SERIAL, entity.THIRD_SERIAL, entity.TOKEN_CHIP_NUMBER, entity.SECOND_TOKEN_CHIP_NUMBER, entity.IS_ACTIVE, entity.CUSTOMER_ID, entity.BENEFICIARY_ID,
               entity.NAME, entity.VEHICLE_INFO_ID, entity.CUSTOM_EXPIRY_YEARS, entity.IS_TRX_NOTIFY, eRROR_MESSAGE, entity.LAST_UPDATED_USER_ID, entity.LAST_UPDATED_DATE, entity.LAST_LOCATION_ID, p_RESULT
               );
                remarks = Convert.ToString(eRROR_MESSAGE.Value);
                tokenCode = null;
                if (Convert.ToInt32(p_RESULT.Value) <= 0)
                    return -1;
                var tokenId = Convert.ToInt32(p_TOKEN_ID.Value);
                if (restriction != null)
                {

                    var p_STATUS = new ObjectParameter("p_STATUS", typeof(decimal));
                    var p_RS_GROUP_ID = new ObjectParameter("p_RS_GROUP_ID", typeof(decimal));
                    if (restriction.RESTRICTIONGROUPID != null)
                        p_RS_GROUP_ID.Value = restriction.RESTRICTIONGROUPID;
                    _dbContext.Context.UpdateTokenRestriction(tokenId, entity.TOKEN_TYPE_ID, p_RS_GROUP_ID, entity.CUSTOMER_ID, entity.BENEFICIARY_ID,
                        entity.NAME, restriction.RESTRICTIONGROUPNAME, restriction.IS_SYSTEM_DEFINED_GROUP, restriction.CONSECUTIVE_USAGE_RESTRICTION, restriction.IS_RESTRICTED_IN_HOLIDAY,
                        restriction.IS_REQUIRE_ODOMETER_INPUT, restriction.IS_REQUIRE_DRIVER_CARD, restriction.CAN_BUY_DRY_STOCK, restriction.CAN_USE_ADNOC_SERVICE, entity.LAST_UPDATED_USER_ID, entity.LAST_UPDATED_DATE,
                        restriction.RS_AMOUNT, restriction.RS_PRODUCT, restriction.RS_QUANTITY, restriction.RS_STATION, restriction.RS_TRANSNO, restriction.RS_TRANS, restriction.RS_WEEKDAY, restriction.RS_TIME, entity.LAST_LOCATION_ID, p_STATUS);

                }
                tokenCode = Convert.ToString(p_CODE.Value);
                transactionScope.Complete();
                return tokenId;
            }
        }


    }

}
