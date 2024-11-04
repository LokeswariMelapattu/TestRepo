using System.Collections.Generic;
using DUC.CMS.Beneficiary.BLL.DTO;
using DUC.CMS.Beneficiary.BLL.Mappers;
using DUC.CMS.CustomerService.DAL.Repository;

namespace DUC.CMS.Beneficiary.BLL
{
    public class BeneficiaryAppService
    {
        ///F35
        /// <summary>
        /// Get all beneficiary status
        /// </summary>
        /// <returns></returns>
        public List<StatusDTO> GetAllBeneficiaryStatus()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new BeneficiaryRepository(unitOfWork);
                return repository.GetAllBeneficiaryStatus().ToDTOs();
            }
        }

        ///F36
        /// <summary>
        /// Get all beneficiary status reasons
        /// </summary>
        /// <returns></returns>
        public List<StatusReasonDTO> GetAllBeneficiaryStatusReasons(int statusID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new BeneficiaryRepository(unitOfWork);
                return repository.GetAllBeneficiaryStatusReasons(statusID).ToDTOs();
            }
        }

        ///F98
        /// <summary>
        /// Gets all the beneficiaries with details based on search criteria
        /// </summary>
        /// <param name="beneficiarySearchDTO"></param>
        /// <returns></returns>
        public List<BeneficiarySearchDTO> SearchBeneficiaries(BeneficiarySearchDTO beneficiarySearchDTO, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new BeneficiaryRepository(unitOfWork);
                return repository.SearchBeneficiaries(beneficiarySearchDTO.ToEntity(),pageNo, pageSize, out rowCount).ToDTOs();
            }

        }

        ///F104
        /// <summary>
        /// If the beneficiary ID is present in DTO, this is an update operation. 
        /// Else add the information of the beneficiary and returns the newly created beneficiary ID
        /// </summary>
        /// <param name="BeneficiaryDTO"></param>
        /// <returns></returns>
        public int UpdateBeneficiaryInfo(BeneficiaryDTO dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new BeneficiaryRepository(unitOfWork);
                var entity = dto.ToCTEntity();
                if (entity.BeneficiaryEntity.ADDRESS != null)
                {
                    if (entity.BeneficiaryEntity.ADDRESS_ID != null) entity.BeneficiaryEntity.ADDRESS.ADDRESS_ID = (int)entity.BeneficiaryEntity.ADDRESS_ID;
                    entity.BeneficiaryEntity.ADDRESS_ID = repository.SaveAddress(entity.BeneficiaryEntity.ADDRESS);
                }

                var beneficiaryId = repository.UpdateBeneficiaryInfo(entity);

                if (dto.BeneficiaryReceiptPreferenceDTO != null)
                {
                    if (dto.BeneficiaryReceiptPreferenceDTO.ReceiptTypeId == 3)//None
                    {
                        repository.DeleteBeneficiaryReceiptPreference(beneficiaryId,dto.LastUpdateUser,dto.LastUpdateDate,dto.LocationID);
                    }
                    else
                    {
                        dto.BeneficiaryReceiptPreferenceDTO.BeneficiaryId = beneficiaryId;
                        repository.UpdateBeneficiaryReceiptPreference(dto.BeneficiaryReceiptPreferenceDTO.ToEntity(), dto.LastUpdateUser, dto.LastUpdateDate, dto.LocationID);
                    }
                }
                return beneficiaryId;
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
        public bool UpdateBeneficiaryPIN(int beneficiaryID,string beneficiaryCode, string pinNo,BaseDTO Audit)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new BeneficiaryRepository(unitOfWork);
                return repository.UpdateBeneficiaryPIN(beneficiaryID,beneficiaryCode, pinNo,Audit.ToEntity());
            }
        }

        ///F108
        /// <summary>
        /// Get the beneficiary details for the selected beneficiary
        /// </summary>
        /// <param name="beneficiaryID"></param>
        /// <returns></returns>
        public BeneficiaryDTO GetBeneficiaryInfo(int beneficiaryID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new BeneficiaryRepository(unitOfWork);
                return repository.GetBeneficiaryInfo(beneficiaryID).ToDTO();
            }
        }

        ///F109
        /// <summary>
        /// Gets all the beneficiary status history details for the selected beneficiary
        /// </summary>
        /// <param name="beneficiaryID"></param>
        /// <returns></returns>
        public List<BeneficiaryStatusHistoryDTO> GetBeneficiaryStatusHistory(int beneficiaryID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new BeneficiaryRepository(unitOfWork);
                return repository.GetBeneficiaryStatusHistory(beneficiaryID).ToDTOs();
            }
        }

        ///F110
        /// <summary>
        /// Updates the beneficiary status and status reason information
        /// </summary>
        /// <param name="beneficiaryStatusDTO"></param>
        /// <returns></returns>
        public bool UpdateBeneficiaryStatus(BeneficiaryStatusDTO dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new BeneficiaryRepository(unitOfWork);
                BaseDTO Audit = new BaseDTO { LastUpdateDate=dto.LastUpdateDate , LastUpdateUser = dto.LastUpdateUser,LocationID = dto.LocationID};
                return repository.UpdateBeneficiaryStatus(dto.BeneficiaryID,dto.BeneficiaryCode, dto.StatusID, dto.StatusReasonID,Audit.ToEntity());
            }
        }

        ///F135
        /// <summary>
        /// Gets  the beneficiary transaction details based on search criteria
        /// </summary>
        /// <param name="transactionSearchDTO"></param>
        /// <returns></returns>
        public List<TransactionSearchDTO> GetBeneficiaryTransaction(TransactionSearchDTO dto, int pageNo, int pageSize, out int rowCount, 
            out decimal PaidAmountSum, out decimal AdjustmentAmountSum, out decimal TotalAmountSum, out decimal PaidVATSum)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new BeneficiaryRepository(unitOfWork);
                return repository.GetBeneficiaryTransaction(dto.ToEntity(), pageNo, pageSize, out rowCount, out PaidAmountSum, 
                    out AdjustmentAmountSum, out TotalAmountSum, out PaidVATSum).ToDTOs();
            }
        }

        //F168
        /// <summary>
        /// Update the beneficiary record with isactive to 0
        /// </summary>
        /// <param name="beneficiaryID"></param>
        /// <returns></returns>
        public bool DeleteBeneficiary(int beneficiaryID,BaseDTO Audit)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new BeneficiaryRepository(unitOfWork);
                return repository.DeleteBeneficiary(beneficiaryID,Audit.ToEntity());
            }
        }

        //F190
        public List<StatusDTO> GetAllBeneficiaryStatusByID(int beneficiaryId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new BeneficiaryRepository(unitOfWork);
                return repository.GetAllBeneficiaryStatusByID(beneficiaryId).ToDTOs();
            }
        }

        //201
        public string GetBeneficiaryCodeByID(int BeneficiaryID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new BeneficiaryRepository(unitOfWork);
                return repository.GetBeneficiaryCodeByID(BeneficiaryID);
            }
        }

        public BeneficiaryReceiptPreferenceDTO GetBeneficiaryReceiptPreference(int beneficiaryID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new BeneficiaryRepository(unitOfWork);
                return repository.GetBeneficiaryReceiptPreference(beneficiaryID).ToDTO();
            }
        }

        public AreaDTO GetAreaByID(int areaId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new BeneficiaryRepository(unitOfWork);
                var data = repository.GetAreaByID(areaId);
                if (data != null && data.Count > 0)
                    return data[0].ToDTO();
                else
                    return null;
            }
        }

        public CityDTO GetCityByID(int cityId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new BeneficiaryRepository(unitOfWork);
                var data = repository.GetCityByID(cityId);
                if (data != null && data.Count > 0)
                    return data[0].ToDTO();
                else
                    return null;
            }
        }

        public CountryDTO GetCountryByID(int countryId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new BeneficiaryRepository(unitOfWork);
                var data = repository.GetCountryByID(countryId);
                if (data != null && data.Count > 0)
                    return data[0].ToDTO();
                else
                    return null;
            }
        }

        public AddressDTO GetAddressDetails(int addressID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new BeneficiaryRepository(unitOfWork);
                var data = repository.GetAddressDetails(addressID);
                if (data != null && data.Count > 0)
                    return data[0].ToDTO();
                else
                    return null;
            }
        }

        public bool ValidateTokenRestriction(int TokenId, decimal? DailyAmountLimit, decimal? WeeklyAmountLimit, decimal? MonthlyAmountLimit, decimal? YearlyAmountLimit)
        {
            return true;
            //using (var unitOfWork = new UnitOfWork())
            //{
            //    var repository = new BeneficiaryRepository(unitOfWork);
            //    return repository.ValidateTokenRestriction(TokenId, DailyAmountLimit, WeeklyAmountLimit, MonthlyAmountLimit, YearlyAmountLimit);
            //}
        }
    }
}
