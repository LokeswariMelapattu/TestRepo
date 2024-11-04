using DUC.CMS.CustomerService.DAL.DataExtensions;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;

namespace DUC.CMS.CustomerService.DAL.Repository
{
    public class BeneficiaryRepository : Repository.Repository<BENEFICIARY>
    {
        public BeneficiaryRepository(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        //F35
        public List<BENEFICIARY_STATUS> GetAllBeneficiaryStatus()
        {
            return _dbContext.Context.GetAllBeneficiaryStatus().ToList();
        }

        //F36
        public List<BENEFICIARY_STATUS_REASON> GetAllBeneficiaryStatusReasons(int statusID)
        {
            return _dbContext.Context.GetBeneficiaryStatusReasonsByID(statusID).ToList();
        }

        //109
        public List<CTBeneficiaryStatusHistory> GetBeneficiaryStatusHistory(int beneficiaryID)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            return _dbContext.Context.GetBeneficiaryStatusHistory(beneficiaryID, p_RESULT).ToList();
        }

        //F110
        public bool UpdateBeneficiaryStatus(int beneficiaryID, string beneficiaryCode, int statusID, int? statusReasonID, CTBase Audit)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.UpdateBeneficiaryStatus(beneficiaryID, beneficiaryCode, statusID, statusReasonID, Audit.LastUserID, Audit.LastUpdateDate, Audit.LastLocationID, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        public List<ADDRESS> GetAddressDetails(int addressID)
        {
            return _dbContext.Context.GetAddressByID(addressID).ToList();
        }

        public List<AREA> GetAreaByID(int areaId)
        {
            return _dbContext.Context.GetAreaByID(areaId).ToList();
        }

        //F98
        public List<CTCustomerBeneficiaryResult> SearchBeneficiaries(CTCustomerBeneficiary beneficiary, int pageNo, int pageSize, out int rowCount)
        {
            var p_PAGE_NO = new ObjectParameter("p_PAGE_NO", typeof(decimal));
            p_PAGE_NO.Value = pageNo;
            var p_PAGE_SIZE = new ObjectParameter("p_PAGE_SIZE", typeof(decimal));
            p_PAGE_SIZE.Value = pageSize;
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var data = _dbContext.Context.SearchBeneficiaries(beneficiary.BENEFICIARY_ID, beneficiary.BENEFICIARY_CODE, beneficiary.CUSTOMER_ID, beneficiary.CUSTOMER_CODE,
                beneficiary.BENEFICIARY_NAME, beneficiary.MOBILE, beneficiary.STATUS_ID, beneficiary.STATUS_NAME, beneficiary.NATIONAL_ID, beneficiary.NATIONALILTY_ID,
                beneficiary.NATIONALITY_NAME, beneficiary.REGISTRATION_DATE, beneficiary.REGISTER_FROM_DATE, beneficiary.REGISTER_TO_DATE, beneficiary.CUSTOMER_GROUP,
                beneficiary.IS_VIP, beneficiary.UserID, beneficiary.EmployeeID, beneficiary.IdNumber, p_PAGE_NO, p_PAGE_SIZE, p_ROW_COUNT, beneficiary.TokenCode,beneficiary.CustomerName).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            return data;
        }

        //F104
        public int UpdateBeneficiaryInfo(CTBeneficiaryInfo entity)
        {
            var isInCreationMode = entity.BeneficiaryEntity.BENEFICIARY_ID <= 0;
            var p_BENEFICIARY_ID = new ObjectParameter("p_BENEFICIARY_ID", entity.BeneficiaryEntity.BENEFICIARY_ID);
            var p_CODE = new ObjectParameter("p_CODE", typeof(string));
            p_CODE.Value = entity.BeneficiaryEntity.CODE;

            _dbContext.Context.UpdateBeneficiaryInfo(p_BENEFICIARY_ID, p_CODE, entity.BeneficiaryEntity.CUSTOMER_ID, entity.BeneficiaryEntity.EMPLOYEE_ID, entity.BeneficiaryEntity.ADDRESS_ID, entity.BeneficiaryEntity.NAME, entity.BeneficiaryEntity.MOBILE,
                entity.BeneficiaryEntity.EMAIL, entity.BeneficiaryEntity.PIN, entity.BeneficiaryEntity.LANGUAGE_ID, entity.BeneficiaryEntity.IDENTIFICATION_TYPE_ID, entity.BeneficiaryEntity.NATIONAL_ID, entity.BeneficiaryEntity.NATIONALILTY_ID,
                entity.BeneficiaryEntity.NOTIFICATION_CHANNEL_ID, entity.BeneficiaryEntity.NOTIFICATION_LANGUAGE_ID, entity.BeneficiaryEntity.FAMILY_ID, entity.BeneficiaryEntity.GROUP_ID, entity.BeneficiaryEntity.BENEFICIARY_STATUS_ID
             , entity.BeneficiaryEntity.BENEFICIARY_STATUS_REASON_ID, entity.BeneficiaryEntity.IS_STATUS_INHERITED, entity.BeneficiaryEntity.IS_DISABILITY, entity.BeneficiaryEntity.LAST_UPDATED_USER_ID, entity.BeneficiaryEntity.LAST_UPDATED_DATE,
             entity.BeneficiaryEntity.REGISTRATION_DATE, entity.BeneficiaryEntity.IS_VIP, entity.BeneficiaryEntity.IS_ACTIVE, entity.BeneficiaryEntity.GENDER, entity.BeneficiaryEntity.IS_CUSTOMER_DEFAULT, entity.BeneficiaryEntity.DATEOFBIRTH,
             entity.BeneficiaryEntity.LAST_LOCATION_ID);

            var returnedBeneficiaryId = Convert.ToInt32(p_BENEFICIARY_ID.Value);

            UpdateBeneficiaryRestriction(new CTBeneficiaryRestrictionInput()
            {
                BeneficiaryId = returnedBeneficiaryId,
                AllowedAmount = entity.RestrictionAllowedAmount,
                TimeFrequencyId = entity.RestrictionTimeFrequencyId,
                LastLocationId = (int?)entity.BeneficiaryEntity.LAST_LOCATION_ID,
                LastUpdatedUserId = entity.BeneficiaryEntity.LAST_UPDATED_USER_ID
            });

            return returnedBeneficiaryId;
        }

        //F105
        public bool UpdateBeneficiaryPIN(int beneficiaryID, string beneficiaryCode, string pinNo, CTBase Audit)
        {
            //decode
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.UpdateBeneficiaryPIN(beneficiaryID, beneficiaryCode, pinNo, Audit.LastUserID, Audit.LastUpdateDate, Audit.LastLocationID, p_RESULT);
            return Convert.ToBoolean(p_RESULT.Value);
        }

        //F108
        public CTBeneficiaryInfo GetBeneficiaryInfo(int beneficiaryID)
        {
            var ctBeneficiaryBasicInfo = new CTBeneficiaryInfo();
            ctBeneficiaryBasicInfo.BeneficiaryEntity = _dbContext.Context.GetBeneficiaryInfo(beneficiaryID).FirstOrDefault();
            if (ctBeneficiaryBasicInfo.BeneficiaryEntity != null)
            {
                var restrictions = GetBenenficiaryRestriction(ctBeneficiaryBasicInfo.BeneficiaryEntity.BENEFICIARY_ID);
                if (restrictions != null)
                {
                    ctBeneficiaryBasicInfo.RestrictionAllowedAmount = restrictions.ALLOWED_AMOUNT;
                    ctBeneficiaryBasicInfo.RestrictionTimeFrequencyId = restrictions.TIME_FREQUENCY_ID;
                }
            }
            return ctBeneficiaryBasicInfo;
        }

        //F135
        public List<CTTransactionSearch> GetBeneficiaryTransaction(CTTransactionSearch entity, int pageNo, int pageSize, out int rowCount,
            out decimal PaidAmountSum, out decimal AdjustmentAmountSum, out decimal TotalAmountSum, out decimal PaidVATSum)
        {
            var p_ROW_COUNT = new ObjectParameter("p_ROW_COUNT", typeof(decimal));
            var p_ROW_SUM_TOTAL = new ObjectParameter("p_ROW_SUM_TOTAL", typeof(decimal));
            var p_ROW_SUM_ADJ = new ObjectParameter("p_ROW_SUM_ADJ", typeof(decimal));
            var p_ROW_SUM_PAID = new ObjectParameter("p_ROW_SUM_PAID", typeof(decimal));
            var p_ROW_SUM_VAT = new ObjectParameter("p_ROW_SUM_VAT", typeof(decimal));
            var data = _dbContext.Context.GetBeneficiaryTransaction(entity.BENEFICIARY_ID, entity.BENEFICIARY_CODE, entity.CUSTOMER_ID, entity.BENEFICIARY_NAME, entity.TRANS_FROM_DATE, entity.TRANS_TO_DATE,
                    entity.TOKEN_TYPE_ID, entity.TOKEN_TYPE, entity.STATION_ID, entity.PRODUCT_ID, entity.SERIAL, entity.GROUP_ID, entity.TRANSACTION_AMOUNT, entity.TRANSACTION_ADJUSTMENT,
                    entity.TRANSACTION_PAID_AMOUNT,entity.VAT_INV_NUM, pageNo, pageSize, p_ROW_COUNT, p_ROW_SUM_TOTAL, p_ROW_SUM_ADJ, p_ROW_SUM_PAID, p_ROW_SUM_VAT).ToList();
            rowCount = Convert.ToInt32(p_ROW_COUNT.Value);
            PaidAmountSum = Convert.ToDecimal(p_ROW_SUM_PAID.Value);
            AdjustmentAmountSum = Convert.ToDecimal(p_ROW_SUM_ADJ.Value);
            TotalAmountSum = Convert.ToDecimal(p_ROW_SUM_TOTAL.Value);
            PaidVATSum = Convert.ToDecimal(p_ROW_SUM_VAT.Value);
            return data;
        }

        //F168
        public bool DeleteBeneficiary(int beneficiaryID, CTBase Audit)
        {
            var p_RESULT = new ObjectParameter("p_RESULT", typeof(decimal));
            _dbContext.Context.DeleteBeneficiary(beneficiaryID, Audit.LastUserID, Audit.LastUpdateDate, Audit.LastLocationID, p_RESULT);
            return true;
        }

        //F190
        public List<BENEFICIARY_STATUS> GetAllBeneficiaryStatusByID(int beneficiaryID)
        {
            return _dbContext.Context.GetAllBeneficiaryStatusByID(beneficiaryID).ToList();
        }

        //F201
        public string GetBeneficiaryCodeByID(int BeneficiaryID)
        {
            var p_RESULT = new ObjectParameter("p_CODE", typeof(string));
            _dbContext.Context.GetBeneficiaryCodeByID(BeneficiaryID, p_RESULT);
            return Convert.ToString(p_RESULT.Value);
        }

        public List<CITY> GetCityByID(int cityId)
        {
            return _dbContext.Context.GetCityByID(cityId).ToList();
        }

        public List<COUNTRY> GetCountryByID(int countryId)
        {
            return _dbContext.Context.GetCountryByID(countryId).ToList();
        }

        public int SaveAddress(ADDRESS entity)
        {
            var p_ADDRESS_ID = new ObjectParameter("p_ADDRESS_ID", entity.ADDRESS_ID);
            this._dbContext.Context.UpdateAddress(p_ADDRESS_ID, entity.AREA_ID, entity.CITY_ID, entity.COUNTRY_ID, entity.POST_CODE, entity.DETAILED_ADDRESS,
                entity.IS_ACTIVE, entity.PHONE_NUMBER, entity.FAX, entity.LAST_UPDATED_USER_ID, entity.LAST_UPDATED_DATE, entity.LAST_LOCATION_ID);
            if (p_ADDRESS_ID != null)
            {
                return (int)((decimal)p_ADDRESS_ID.Value);
            }
            throw new Exception("Error while inserting address");
        }

        public CTBeneficiaryReceiptPreference GetBeneficiaryReceiptPreference(int beneficiaryID)
        {
            var data = _dbContext.Context.GetBeneficiaryReceiptPreference(beneficiaryID).ToList();
            if (data != null & data.Count > 0)
                return data[0];
            return null;
        }

        public bool UpdateBeneficiaryReceiptPreference(CTBeneficiaryReceiptPreference entity, int? UserID, DateTime? LastUpdatedDate, int? LocationId)
        {
            _dbContext.Context.UpdateBeneficiaryReceiptPreference(entity.BENEFICIARY_ID, entity.RECEIPT_TYPE_ID, UserID, LastUpdatedDate, LocationId);
            return true;
        }

        public bool DeleteBeneficiaryReceiptPreference(int beneficiaryID, int? UserID, DateTime? LastUpdatedDate, int? LocationId)
        {
            _dbContext.Context.DeleteBeneficiaryReceiptPreference(beneficiaryID, UserID, LastUpdatedDate, LocationId);
            return true;
        }

        public bool UpdateBeneficiaryRestriction(CTBeneficiaryRestrictionInput beneficiaryRestriction)
        {
            var pResult = new ObjectParameter("P_RESULT", typeof(int));
            _dbContext.Context.UpdateBeneficiaryRestriction(beneficiaryRestriction.BeneficiaryId, beneficiaryRestriction.TimeFrequencyId, beneficiaryRestriction.AllowedAmount,
                beneficiaryRestriction.LastUpdatedUserId, beneficiaryRestriction.LastLocationId, pResult);
            return (pResult.Value != null) ? Convert.ToBoolean(pResult.Value) : false;
        }

        public CTBeneficiaryRestrictionResult GetBenenficiaryRestriction(int BeneficiaryId)
        {
            return _dbContext.Context.GetBeneficiaryRestriction(BeneficiaryId).FirstOrDefault();
        }

        public List<CTMonth> GetAllMonths()
        {
            return _dbContext.Context.GetAllMonths().ToList();
        }

        public bool ValidateTokenRestriction(int TokenId, decimal? DailyAmountLimit, decimal? WeeklyAmountLimit, decimal? MonthlyAmountLimit, decimal? YearlyAmountLimit)
        {
            var isValidParameter = new ObjectParameter("P_IS_VALID", typeof(decimal));
            _dbContext.Context.ValidateTokenRestriction(TokenId, DailyAmountLimit, WeeklyAmountLimit, MonthlyAmountLimit, YearlyAmountLimit, isValidParameter);
            return (isValidParameter.Value != null) ? Convert.ToBoolean(isValidParameter.Value) : false;
        }
    }
}
