using System;
using DUC.CMS.Token.BLL.DTO;
using DUC.CMS.Token.BLL.Mappers;
using System.Collections.Generic;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.CustomerService.DAL.Repository;

namespace DUC.CMS.Token.BLL
{
    public class TokenAppService
    {
        ///F36
        /// <summary>
        /// Get all token status reason
        /// </summary>
        /// <returns></returns>
        public List<StatusReasonDTO> GetAllTokenStatusReasons(int statusID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetAllTokenStatusReasons(statusID).ToDTOs();
            }
        }

        //F39
        /// <summary>
        /// Get all token status
        /// </summary>
        /// <returns></returns>
        public List<StatusDTO> GetAllTokenStatus()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetAllTokenStatus().ToDTOs();
            }
        }

        ///F43
        /// <summary>
        /// Get all vehicle make
        /// </summary>
        /// <returns></returns>
        public List<VehicleMakeDTO> GetAllVehicleMakes()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetAllVehicleMakes().ToDTOs();
            }
        }

        ///F51
        /// <summary>
        /// Get all vehicle models
        /// </summary>
        /// <returns></returns>
        public List<VehicleMakeModelDTO> GetAllVehicleModels()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetAllVehicleModels().ToDTOs();
            }
        }

        ///
        /// <summary>
        /// Get all token types
        /// </summary>
        /// <returns></returns>
        ///  
        public List<PropertyDTO> GetAllTokenTypes()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetAllTokenTypes().ToTTDTOs();
            }
        }

        public List<PropertyDTO> GetCustomerTokenTypes()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetCustomerTokenTypes().ToTTDTOs();
            }
        }

        ///F111
        /// <summary>
        /// If tokenID is present in DTO then insert else update
        /// If the Token Type is Vehicle Tag, the vehicle information will be added to the VehicelInfo table
        /// </summary>
        /// <param name="tokenDTO"></param>
        /// <returns></returns>
        public int UpdateTokenInfo(TokenDTO tokenDTO, out string ErrorMessage)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                //need to check Token Type is Vehicle Tag
                if (tokenDTO.TokenTypeID == 1 || tokenDTO.TokenTypeID == 8)
                {
                    tokenDTO.VehicleInfoID = repository.UpdateVehicleInfo(tokenDTO.VehicleInfoDTO.ToEntity());
                }
                return repository.UpdateTokenInfo(tokenDTO.ToEntity(), out ErrorMessage);
            }
        }

        ///F112
        /// <summary>
        /// Gets all the restriction groups which are not system defined   -- not used
        /// </summary>
        /// <returns></returns>
        //public List<RestrictionGroupDTO> GetAllRestrictionGroups()
        //{
        //    using (var unitOfWork = new UnitOfWork())
        //    {
        //        var repository = new TokenRepository(unitOfWork);

        //        return repository.GetAllRestrictionGroups().ToCDTOs();
        //    }
        //}

        ///F113
        /// <summary>
        /// Get a list of vehicle register details based on the search criteria
        /// </summary>
        /// <param name="makeID">Vehicle make ID</param>
        /// <param name="modelID">Vehicle model ID</param>
        /// <param name="year">Year</param>
        /// <returns></returns>

        public List<VehicleRegisterSearchResultDTO> SearchVehicleRegister(int? makeID, int? modelID, int? year, int? CC, int? FUEL_INLET, int? FUEL_CAPACITY, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.SearchVehicleRegister(makeID, modelID, year, CC, FUEL_INLET, FUEL_CAPACITY, pageNo, pageSize, out rowCount).ToDTOs();
            }
        }

        ///F115
        /// <summary>
        /// Get all vehicle types
        /// </summary>
        /// <returns></returns>
        public List<VehicleTypesDTO> GetAllVehicleTypes()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetAllVehicleTypes().ToDTOs();
            }
        }

        ///F116
        /// <summary>
        /// Get all vehicle plate colors
        /// </summary>
        /// <returns></returns>
        public List<VehiclePlateColorDTO> GetVehiclePlateColors()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetVehiclePlateColors().ToDTOs();
            }
        }

        ///F117
        /// <summary>
        /// Get the token restriction details for the selected token
        /// </summary>
        /// <param name="tokenID"></param>
        /// <returns></returns>
        public List<TokenRestrictionDTO> GetTokenRestrictionInfo(int tokenID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetTokenRestrictionInfo(tokenID).ToCDTOs();
            }
        }

        ///F118
        /// <summary>
        /// Updates the token restriction details
        /// </summary>
        /// <param name="tokenRestrictionDTO"></param>
        /// <returns></returns>
        public int UpdateTokenRestriction(TokenRestrictionDTO dto)
        {
            #region Old

            //using (var unitOfWork = new UnitOfWork())
            //{
            //    var repository = new TokenRepository(unitOfWork);
            //    //string strTemp = string.Empty;

            //    string strAmount = "", strProduct = "", strQuantity = "", strTransNo = "", strTransaction = "";

            //    if (dto.ProductCategoryRestrictions != null)
            //    {
            //        foreach (var productCategory in dto.ProductCategoryRestrictions)
            //        {
            //            if (productCategory.RestrictionAmountDTO != null)
            //            {
            //                foreach (var item in productCategory.RestrictionAmountDTO)
            //                {
            //                    strAmount = strAmount + item.RestrictionGroupID + "," + item.TimeFrequencyID + "," + item.AllowedAmount + "," + Convert.ToInt16(item.IsActive) + "," + item.LastUpdatedUserId + "," + productCategory.ProductCategoryID + "|";
            //                }
            //            }

            //            if (productCategory.RestrictionProductDTO != null)
            //            {
            //                foreach (var item in productCategory.RestrictionProductDTO)
            //                {
            //                    strProduct = strProduct + item.RestrictionGroupID + "," + item.ProductID + "," + string.Empty + "," + string.Empty + "," + Convert.ToInt16(item.IsActive) + "," + item.LastUpdatedUserId + "|";
            //                }
            //            }

            //            if (productCategory.RestrictionQuantityDTO != null)
            //            {
            //                foreach (var item in productCategory.RestrictionQuantityDTO)
            //                {
            //                    strQuantity = strQuantity + item.RestrictionGroupID + "," + item.AllowedProductID + "," + item.TimeFrequencyID + "," + item.AllowedQuantity + "," + Convert.ToInt16(item.IsActive) + "," + item.LastUpdatedUserId + "," + productCategory.ProductCategoryID + "|";
            //                }
            //            }

            //            if (productCategory.RestrictionTransNoDTO != null)
            //            {
            //                foreach (var item in productCategory.RestrictionTransNoDTO)
            //                {
            //                    strTransNo = strTransNo + item.RestrictionGroupID + "," + item.NumberOfDays + "," + item.NumberOfTransactions + "," + item.TimeFrequencyID + "," + Convert.ToInt16(item.IsActive) + "," + item.LastUpdatedUserId + "," + productCategory.ProductCategoryID + "|";
            //                }
            //            }

            //            if (productCategory.RestrictionTransactionDTO != null)
            //            {
            //                foreach (var item in productCategory.RestrictionTransactionDTO)
            //                {
            //                    strTransaction = strTransaction + item.RestrictionGroupID + "," + item.MaxTransactionAmount + "," + Convert.ToInt16(item.IsActive) + "," + item.LastUpdatedUserId + "," + productCategory.ProductCategoryID + "|";
            //                }
            //            }
            //        }
            //    }

            //    dto.RsAmount = strAmount;
            //    dto.RsProduct = strProduct;
            //    dto.RsQuantity = strQuantity;
            //    dto.RsTransNo = strTransNo;
            //    dto.RsTransaction = strTransaction;

            //    string strTemp = string.Empty;



            //    if (dto.RestrictionAmountDTO != null)
            //    {
            //        foreach (var item in dto.RestrictionAmountDTO)
            //        {
            //            strTemp = strTemp + item.RestrictionGroupID + "," + item.TimeFrequencyID + "," + item.AllowedAmount + "," + Convert.ToInt16(item.IsActive) + "," + item.LastUpdatedUserId + "|";
            //        }
            //        dto.RsAmount = strTemp;
            //        strTemp = string.Empty;
            //    }

            //    if (dto.RestrictionProductDTO != null)
            //    {
            //        foreach (var item in dto.RestrictionProductDTO)
            //        {
            //            strTemp = strTemp + item.RestrictionGroupID + "," + item.ProductID + "," + string.Empty + "," + string.Empty + "," + Convert.ToInt16(item.IsActive) + "," + item.LastUpdatedUserId + "|";
            //        }
            //        dto.RsProduct = strTemp;
            //        strTemp = string.Empty;
            //    }

            //    if (dto.RestrictionQuantityDTO != null)
            //    {
            //        foreach (var item in dto.RestrictionQuantityDTO)
            //        {
            //            strTemp = strTemp + item.RestrictionGroupID + "," + item.AllowedProductID + "," + item.TimeFrequencyID + "," + item.AllowedQuantity + "," + Convert.ToInt16(item.IsActive) + "," + item.LastUpdatedUserId + "|";
            //        }
            //        dto.RsQuantity = strTemp;
            //        strTemp = string.Empty;
            //    }

            //    if (dto.RestrictionStationDTO != null)
            //    {
            //        foreach (var item in dto.RestrictionStationDTO)
            //        {
            //            strTemp = strTemp + item.RestrictionGroupID + "," + item.StationID + "," + Convert.ToInt16(item.IsActive) + "," + item.LastUpdatedUserId + "|";
            //        }
            //        dto.RsStation = strTemp;
            //        strTemp = string.Empty;
            //    }



            //    if (dto.RestrictionWeekDayDTO != null)
            //    {
            //        foreach (var item in dto.RestrictionWeekDayDTO)
            //        {
            //            strTemp = strTemp + item.RestrictionGroupID + "," + item.WeekDayID + "," + Convert.ToInt16(item.IsActive) + "," + item.LastUpdatedUserId + "|";
            //        }
            //        dto.RsWeekday = strTemp;
            //        strTemp = string.Empty;
            //    }

            //    return repository.UpdateTokenRestriction(dto.ToEntity());


            //  }
            #endregion

            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
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

                return repository.UpdateTokenRestriction(dto.ToEntity());
            }
        }

        ///F119
        /// <summary>
        /// Gets all the tokens based on the search criteria
        /// </summary>
        /// <param name="tokenSearchDTO"></param>
        /// <returns></returns>
        public List<TokenSearchDTO> SearchToken(TokenSearchDTO dto, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.SearchToken(dto.ToEntity(), pageNo, pageSize, out rowCount).ToDTOs();
            }
        }

        public List<CustomerTokenSearchDTO> CustomerSearchToken(CustomerTokenSearchDTO dto, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.CustomerSearchToken(dto.ToEntity(), pageNo, pageSize, out rowCount).ToDTOs();
            }
        }

        ///F120
        /// <summary>
        /// Get the token details for the selected token
        /// </summary>
        /// <param name="tokenID"></param>
        /// <returns></returns>
        public TokenDTO GetTokenInfo(int tokenID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetTokenInfo(tokenID).ToDTO();
            }
        }

        public List<TokenDTO> GetBatchTokenInfo(int personalizationID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetBatchTokenInfo(personalizationID).ToDTOs();
            }
        }

        ///F121
        /// <summary>
        /// Gets all the token status history details for the selected token
        /// </summary>
        /// <param name="tokenID"></param>
        /// <returns></returns>
        public List<TokenStatusHistoryDTO> GetTokenStatusHistory(int tokenID, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetTokenStatusHistory(tokenID, pageNo, pageSize, out rowCount).ToDTOs();
            }
        }

        ///F122
        /// <summary>
        /// Updates the token status and status reason information
        /// </summary>
        /// <param name="tokenStatusDTO"></param>
        /// <returns></returns>
        public bool UpdateTokenStatus(TokenStatusDTO dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                BaseDTO Audit = new BaseDTO { LastUpdatedDate = dto.LastUpdatedDate, LastUpdatedUserId = dto.LastUpdatedUserId, LastUpdatedLocationID = dto.LastUpdatedLocationID };
                var repository = new TokenRepository(unitOfWork);
                return repository.UpdateTokenStatus(dto.TokenID, dto.TokenCODE, dto.StatusID, dto.StatusReasonID, Audit.ToEntity());
            }
        }

        ///F123
        /// <summary>
        /// Updates the restriction group details
        /// </summary>
        /// <param name="restrictionGroupDTO"></param>
        /// <returns></returns>
        public int UpdateRestrictionGroupProfile(RestrictionGroupDTO dto)
        {
            #region Old

            //using (var unitOfWork = new UnitOfWork())
            //{
            //    var repository = new TokenRepository(unitOfWork);
            //    string strTemp = string.Empty;

            //    if (dto.RestrictionAmountDTO != null)
            //    {
            //        foreach (var item in dto.RestrictionAmountDTO)
            //        {
            //            strTemp = strTemp + item.RestrictionGroupID + "," + item.TimeFrequencyID + "," + item.AllowedAmount + "," + Convert.ToInt16(item.IsActive) + "," + item.LastUpdatedUserId + "|";
            //        }
            //        dto.RsAmount = strTemp;
            //        strTemp = string.Empty;
            //    }

            //    if (dto.RestrictionProductDTO != null)
            //    {
            //        foreach (var item in dto.RestrictionProductDTO)
            //        {
            //            strTemp = strTemp + item.RestrictionGroupID + "," + item.ProductID + "," + string.Empty + "," + string.Empty + "," + Convert.ToInt16(item.IsActive) + "," + item.LastUpdatedUserId + "|";
            //        }
            //        dto.RsProduct = strTemp;
            //        strTemp = string.Empty;
            //    }

            //    if (dto.RestrictionQuantityDTO != null)
            //    {
            //        foreach (var item in dto.RestrictionQuantityDTO)
            //        {
            //            strTemp = strTemp + item.RestrictionGroupID + "," + item.AllowedProductID + "," + item.TimeFrequencyID + "," + item.AllowedQuantity + "," + Convert.ToInt16(item.IsActive) + "," + item.LastUpdatedUserId + "|";
            //        }
            //        dto.RsQuantity = strTemp;
            //        strTemp = string.Empty;
            //    }

            //    if (dto.RestrictionStationDTO != null)
            //    {
            //        foreach (var item in dto.RestrictionStationDTO)
            //        {
            //            strTemp = strTemp + item.RestrictionGroupID + "," + item.StationID + "," + Convert.ToInt16(item.IsActive) + "," + item.LastUpdatedUserId + "|";
            //        }
            //        dto.RsStation = strTemp;
            //        strTemp = string.Empty;
            //    }

            //    if (dto.RestrictionTransNoDTO != null)
            //    {
            //        foreach (var item in dto.RestrictionTransNoDTO)
            //        {
            //            strTemp = strTemp + item.RestrictionGroupID + "," + item.NumberOfDays + "," + item.NumberOfTransactions + "," + item.TimeFrequencyID + "," + Convert.ToInt16(item.IsActive) + "," + item.LastUpdatedUserId + "|";
            //        }
            //        dto.RsTransNo = strTemp;
            //        strTemp = string.Empty;
            //    }

            //    if (dto.RestrictionTransactionDTO != null)
            //    {
            //        foreach (var item in dto.RestrictionTransactionDTO)
            //        {
            //            strTemp = strTemp + item.RestrictionGroupID + "," + item.MaxTransactionAmount + "," + Convert.ToInt16(item.IsActive) + "," + item.LastUpdatedUserId + "|";
            //        }
            //        dto.RsTransaction = strTemp;
            //        strTemp = string.Empty;
            //    }

            //    if (dto.RestrictionWeekDayDTO != null)
            //    {
            //        foreach (var item in dto.RestrictionWeekDayDTO)
            //        {
            //            strTemp = strTemp + item.RestrictionGroupID + "," + item.WeekDayID + "," + Convert.ToInt16(item.IsActive) + "," + item.LastUpdatedUserId + "|";
            //        }
            //        dto.RsWeekday = strTemp;
            //        strTemp = string.Empty;
            //    }

            //    if (dto.RestrictionGroupTimeDTO != null)
            //    {
            //        foreach (var item in dto.RestrictionGroupTimeDTO)
            //        {
            //            strTemp = strTemp + item.RestrictionGroupID + "," + item.FromHour + "," + item.ToHour + "," + Convert.ToInt16(item.IsActive) + "," + item.LastUpdatedUserId + "," + item.LastUpdatedLocationID + "|";
            //            //strTemp = strTemp + item.RestrictionGroupID + "," + item.FromHour + "," + item.ToHour + "|";
            //        }
            //        dto.RsTime = strTemp;
            //        strTemp = string.Empty;
            //    }

            //    BaseDTO Audit = new BaseDTO { LastUpdatedDate = dto.LastUpdatedDate, LastUpdatedUserId = dto.LastUpdatedUserId, LastUpdatedLocationID = dto.LastUpdatedLocationID };
            //    return repository.UpdateRestrictionGroupProfile(dto.ToEntity(), Audit.ToEntity());
            //}

            #endregion

            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
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


                BaseDTO Audit = new BaseDTO { LastUpdatedDate = dto.LastUpdatedDate, LastUpdatedUserId = dto.LastUpdatedUserId, LastUpdatedLocationID = dto.LastUpdatedLocationID };
                return repository.UpdateRestrictionGroupProfile(dto.ToEntity(), Audit.ToEntity());
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
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.ChangeTokenBeneficiary(tokenID, newCustomerID, newBeneficiaryID, UserID, LastUpdatedDate, LocationId, out newTokenID);
            }
        }

        ///F126
        /// <summary>
        /// Add the token information and the restriction group id details to token table. 
        /// Create a personalization request if the token type is card. 
        /// </summary>
        /// <param name="tokenDTO"></param>
        /// <returns></returns>
        public List<BatchTokenDTO> AddBatchTokenInfo(List<BatchTokenDTO> dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                string remarks = string.Empty;
                string tokenCode = string.Empty;
                int personalizationID = -1;

                bool res = repository.IsBalanceSufficientForBatchTokenPersonalization(dto[0].CustomerID, dto.Count);
                //AddServiceTransaction(32, dto[0].CustomerID, dto[0].BeneficiaryID, dto[0].TokenID, dto[0].LastUpdatedUserId, dto[0].LastUpdatedUserId, dto[0].LastUpdatedDate, dto[0].LastUpdatedLocationID);
                if (res)
                {
                    foreach (var item in dto)
                    {
                        BaseDTO Audit = new BaseDTO { LastUpdatedDate = item.LastUpdatedDate, LastUpdatedUserId = item.LastUpdatedUserId, LastUpdatedLocationID = item.LastUpdatedLocationID };
                        item.PersonalizationOrderID = personalizationID;
                        item.Status = repository.AddBatchTokenInfo(item.ToEntity(), Audit.ToEntity(), out remarks, out tokenCode, out personalizationID);
                        item.StatusRemark = remarks;
                        item.TokenCode = tokenCode;

                    }
                    dto[0].PersonalizationOrderID = personalizationID;
                    return dto;
                }
                else return null;
            }

        }

        ///F127
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokenRestrictionDTO"></param>
        /// <returns></returns>
        public bool AddBatchTokenRestriction(List<TokenRestrictionDTO> dto)
        {
            foreach (var item in dto)
            {
                UpdateTokenRestriction(item);
            }
            return true;
        }

        ///F142
        /// <summary>
        /// Add the issue request details to PERSONALIZATION_ORDER table with status as ‘Active’ 
        /// and updates the Token table with the order id. 
        /// </summary>
        /// <param name="issueTokenDTO"></param>
        /// <returns></returns>
        public bool AddPersonalizationRequest(IssueTokenDTO dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                BaseDTO Audit = new BaseDTO { LastUpdatedDate = dto.LastUpdatedDate, LastUpdatedUserId = dto.LastUpdatedUserId, LastUpdatedLocationID = dto.LastUpdatedLocationID };
                var repository = new TokenRepository(unitOfWork);
                return repository.AddPersonalizationRequest(dto.ToEntity(), Audit.ToEntity());
            }
        }

        ///F143
        /// <summary>
        /// Add the issue request details to WORK_ORDER table with status as ‘Active’ and updates the Token table with the order id.
        /// </summary>
        /// <param name="issueTokenDTO"></param>
        /// <returns></returns>
        public bool AddWorkOrderRequest(WorkOrderDTO dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.AddWorkOrderRequest(dto.ToEntity());
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
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.IsReplacementIssueRequest(tokenID);
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
        public bool ReplacePersonalizationOrderRequest(IssueTokenDTO dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                BaseDTO Audit = new BaseDTO { LastUpdatedDate = dto.LastUpdatedDate, LastUpdatedUserId = dto.LastUpdatedUserId, LastUpdatedLocationID = dto.LastUpdatedLocationID };
                var repository = new TokenRepository(unitOfWork);
                return repository.ReplacePersonalizationOrderRequest(dto.ToEntity(), Audit.ToEntity());
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
        public bool ReplaceWorkOrderRequest(WorkOrderDTO dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.ReplaceWorkOrderRequest(dto.ToEntity());
            }
        }

        ///F154
        /// <summary>
        /// Checks if the token Id exist in token table and ensures 
        /// token replacement operation is permitted based on the current status of the token.
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public int IsTokenReplacementPermitted(int tokenID, out string cardSerialNo)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.IsTokenReplacementPermitted(tokenID, out cardSerialNo);
            }
        }

        ///F155
        /// <summary>
        /// Get beneficiary names of a customer
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public List<DictionaryDTO> GetAllCustomerBeneficiaryNames(int customerID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetAllCustomerBeneficiaryNames(customerID).ToDTOs();
            }
        }

        ///F156
        /// <summary>
        /// Get restriction group names
        /// </summary>
        /// <returns></returns>
        public List<DictionaryDTO> GetAllRestrictionGroupNames(int? CustomerID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetAllRestrictionGroupNames(CustomerID).ToDTOs();
            }
        }

        ///F159
        /// <summary>
        /// Gets all the vehicle depots
        /// </summary>
        /// <returns></returns>
        public List<VehicleDepotDTO> GetAllVehicleDepot()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetAllVehicleDepot().ToDTOs();
            }
        }

        ///F160
        /// <summary>
        /// Gets all the restriction summary for the specific token
        /// </summary>
        /// <param name="tokenID"></param>
        /// <returns></returns>
        public List<RestrictionSummaryDTO> GetRestrictionSummary(int restrictionGroupID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetRestrictionSummary(restrictionGroupID).ToDTOs();
            }
        }

        //F161
        /// <summary>
        /// Gets all the time frequency from the lookup
        /// </summary>
        /// <returns></returns>
        public List<TimeFrequencyDTO> GetAllTimeFrequency()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetAllTimeFrequency().ToDTOs();
            }
        }

        //F162
        /// <summary>
        /// Gets all the vehicle states from the lookup
        /// </summary>
        /// <returns></returns>
        public List<VehicleStateDTO> GetAllVehicleStates()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetAllVehicleStates().ToDTOs();
            }
        }

        //F163
        /// <summary>
        /// Search the token table for unmapped tokens 
        /// </summary>
        /// <param name="beneficiaryName"></param>
        /// <param name="tokenName"></param>
        /// <returns></returns>
        public List<UnmappedTokenSearchDTO> SearchUnmappedToken(string beneficiaryName, string tokenName, int customerID, int UserID, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.SearchUnmappedToken(beneficiaryName, tokenName, customerID, UserID, pageNo, pageSize, out rowCount).ToDTOs();
            }
        }

        //F164
        /// <summary>
        /// Add a vehicle info entry with the selected vehicle register id. Map the vehicle info to the selected token ; 
        /// Create a work order request
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool AddBatchTokenVehicleMap(BatchTokenVehicleMapDTO dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.AddBatchTokenVehicleMap(dto.ToEntity());
            }
        }

        //F165
        /// <summary>
        /// Checks if the token is in the status where deletion can be performed 
        /// </summary>
        /// <param name="tokenID"></param>
        /// <returns></returns>
        public bool IsTokenDeletionPermitted(int tokenID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.IsTokenDeletionPermitted(tokenID);
            }
        }

        //F166
        /// <summary>
        /// Checks if the beneficiary is in the status where deletion can be performed 
        /// </summary>
        /// <param name="beneficiaryID"></param>
        /// <returns></returns>
        public bool IsBeneficiaryDeletionPermitted(int beneficiaryID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.IsBeneficiaryDeletionPermitted(beneficiaryID);
            }
        }

        //F167
        /// <summary>
        /// Updates the token record with isactive to 0 
        /// </summary>
        /// <param name="tokenID"></param>
        /// <returns></returns>
        public bool DeleteToken(int tokenID, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.DeleteToken(tokenID, UserID, LastUpdatedDate, LocationId);
            }
        }

        //F169
        /// <summary>
        /// Checks if the newly generated PIN is there in the PIN log for the recent 5 records.
        /// </summary>
        /// <param name="pinNo"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool IsNewPINPermitted(string pinNo, int type, int customerID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.IsNewPINPermitted(pinNo, type, customerID);
            }
        }

        //F171
        /// <summary>
        /// Get all stations
        /// </summary>
        /// <returns></returns>
        public List<PropertyDTO> GetAllStations()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetAllStations().ToDTOs();
            }
        }

        //F172
        /// <summary>
        /// Get all station groups
        /// </summary>
        /// <returns></returns>
        public List<PropertyDTO> GetAllStationGroups()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetAllStationGroups().ToDTOs();
            }
        }

        //F173
        /// <summary>
        /// Get all stations with groupid is null
        /// </summary>
        /// <returns></returns>
        public List<PropertyDTO> GetAllUngroupedStations()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetAllUngroupedStations().ToDTOs();
            }
        }

        //F174
        /// <summary>
        /// Get all station belongs to a group
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public List<PropertyDTO> GetStationByGroup(int groupID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetStationByGroup(groupID).ToDTOs();
            }
        }

        //F176
        /// <summary>
        /// Get all personalization requests
        /// </summary>
        /// <returns></returns>
        public List<PropertyDTO> GetAllPersonalizationReasons()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetAllPersonalizationReasons().ToPODTOs();
            }
        }

        //F177
        /// <summary>
        /// Get all work order reasons
        /// </summary>
        /// <returns></returns>
        public List<PropertyDTO> GetAllWorkOrderReasons()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetAllWorkOrderReasons().ToWODTOs();
            }
        }



        public int GetTokenAmount(int tokenID, out decimal tokenAmount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetTokenAmount(tokenID, out tokenAmount);
            }
        }

        //F178
        /// <summary>
        /// Gets the restriction group matching the criteria
        /// </summary>
        /// <param name="restrictionGroupName"></param>
        /// <returns></returns>
        public List<RestrictionGroupDTO> SearchRestrictionGroupProfile(string restrictionGroupName, int? customerID, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.SearchRestrictionGroupProfile(restrictionGroupName, customerID, pageNo, pageSize, out rowCount).ToPDTOs();
            }
        }

        //F179
        /// <summary>
        /// Gets the restriction group for the selected ID
        /// </summary>
        /// <param name="restrictionGroupID"></param>
        /// <returns></returns>
        public RestrictionGroupDTO GetRestrictionGroupById(int restrictionGroupID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                var data = repository.GetRestrictionGroupById(restrictionGroupID).ToPSDTO();
                return data;
            }
        }

        //F180
        /// <summary>
        /// Updates the  inactive =0 for the restriction group 
        /// </summary>
        /// <param name="restrictionGroupID"></param>
        /// <returns></returns>
        public bool DeleteRestrictionGroupByID(int restrictionGroupID, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.DeleteRestrictionGroupByID(restrictionGroupID, UserID, LastUpdatedDate, LocationId);
            }
        }

        //F181
        /// <summary>
        /// Update restriction summary
        /// </summary>
        /// <returns></returns>
        public bool UpdateRestrictionSummary(List<RestrictionSummaryDTO> dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                string resctrictionSummary = string.Empty;
                if (dto != null && dto.Count > 0)
                {
                    BaseDTO Audit = null;
                    foreach (var item in dto)
                    {
                        resctrictionSummary = resctrictionSummary + item.RestrictionGroupID + "," + item.ID + "," + Convert.ToInt16(item.IsActive) + "|";
                        Audit = new BaseDTO { LastUpdatedDate = item.LastUpdatedDate, LastUpdatedUserId = item.LastUpdatedUserId, LastUpdatedLocationID = item.LastUpdatedLocationID };
                    }

                    repository.UpdateRestrictionSummary(resctrictionSummary, Audit.ToEntity());
                    return true;
                }
                return false;
            }
        }

        //F182
        /// <summary>
        /// Gets the personalized info for the specific id
        /// </summary>
        /// <param name="personalizationOrderId"></param>
        /// <returns></returns>
        public PersonalizationOrderDTO GetPersonalizationInfo(int personalizationOrderID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetPersonalizationInfo(personalizationOrderID).ToDTO();
            }
        }

        //F183
        /// <summary>
        /// Gets the work order info for the specific id
        /// </summary>
        /// <param name="workOrderID"></param>
        /// <returns></returns>
        public WorkOrderDTO GetWorkOrderInfo(int workOrderID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                var data = repository.GetWorkOrderInfo(workOrderID).ToDTO();
                return data;
            }
        }

        //F184
        /// <summary>
        /// Checks if the recharge amount is within the recharge limits
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool IsValidRechargeAmount(decimal amount, out string remarks)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.IsValidRechargeAmount(amount, out remarks);
            }
        }

        //F185
        /// <summary>
        /// Gets all the driver card for the customer based on search criteria.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<DriverCardDTO> SearchDriverCard(DriverCardSearchDTO dto, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.SearchDriverCard(dto.ToEntity(), pageNo, pageSize, out rowCount).ToDTOs();
            }
        }

        //F186
        /// <summary>
        /// Maps the driver card to the customer after ensuring the token status allows this operation.
        /// </summary>
        /// <param name="vehicleInfoID"></param>
        /// <returns></returns>
        public bool MapCustomerDriverCard(int paymentTokenID, List<Token.BLL.DTO.DriverCardDTO> DriversList)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                foreach (var item in DriversList)
                {
                    BaseDTO Audit = new BaseDTO { LastUpdatedDate = item.LastUpdatedDate, LastUpdatedUserId = item.LastUpdatedUserId, LastUpdatedLocationID = item.LastUpdatedLocationID };
                    repository.MapCustomerDriverCard(paymentTokenID, item.TokenID.Value, Audit.ToEntity());
                }
                return true;
            }
        }

        //F187
        /// <summary>
        /// Updates the Token table with the new card serial
        /// </summary>
        /// <param name="tokenID"></param>
        /// <param name="newCardSerial"></param>
        /// <returns></returns>
        public bool RenewEmirateID(int tokenID, string newCardSerial, DateTime ExpiryDate, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.RenewEmirateID(tokenID, newCardSerial, ExpiryDate, UserID, LastUpdatedDate, LocationId);
            }
        }

        public List<ProductDTO> GetAllProductsForToken(int tokenID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetAllProductsForToken(tokenID).ToDTOs();
            }
        }

        //F191
        public List<StatusDTO> GetAllTokenStatusByID(int tokenId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetAllTokenStatusByID(tokenId).ToDTOs();
            }
        }

        public List<TokenSearchDTO> SearchNonTerminatedTokens(TokenSearchDTO dto, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.SearchNonTerminatedTokens(dto.ToEntity(), pageNo, pageSize, out rowCount).ToDTOs();
            }
        }

        //F195
        public int LoginUser(string userName)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.LoginUser(userName);
            }
        }

        //F196
        public List<TokenSearchDTO> SearchRestrictedToken(TokenSearchDTO dto, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.SearchRestrictedToken(dto.ToEntity(), pageNo, pageSize, out rowCount).ToDTOs();
            }
        }

        //F198
        public string GenerateDriverCardName(int CustomerID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GenerateDriverCardName(CustomerID);
            }
        }

        //F199
        public string GenerateTokenName(int CustomerID, int BeneficiaryID, int TokenTypeID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GenerateTokenName(CustomerID, BeneficiaryID, TokenTypeID);
            }
        }

        //202
        public string GetTokenCodeByID(int TokenID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetTokenCodeByID(TokenID);
            }
        }

        //F210
        public bool IsEmirateIDAlreadyRegistered(string emirateID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.IsEmirateIDAlreadyRegistered(emirateID);
            }
        }
        public bool IsKNPCCardAlreadyRegistered(string Serial)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.IsKNPCCardAlreadyRegistered(Serial);
            }
        }

        //F211
        public List<BatchBeneficiaryDTO> AddBatchBeneficiary(List<BatchBeneficiaryDTO> dtos)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                string remarks = string.Empty;
                int BeneficiaryId = -1;
                foreach (var item in dtos)
                {
                    BaseDTO Audit = new BaseDTO { LastUpdatedDate = item.LastUpdatedDate, LastUpdatedUserId = item.LastUpdatedUserId, LastUpdatedLocationID = item.LastUpdatedLocationID };
                    remarks = string.Empty;
                    item.BeneficiaryCode = repository.AddBatchBeneficiary(item.ToEntity(), Audit.ToEntity(), out remarks, out BeneficiaryId);
                    item.StatusRemark = remarks;
                    item.BeneficiaryID = BeneficiaryId;
                }
                return dtos;
            }
        }

        //F212
        public string[] GenerateBatchTokenName(int customerID, int tokenCount, int tokenTypeID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                var data = repository.GenerateBatchTokenName(customerID, tokenCount, tokenTypeID);
                return data.ConvertAll<string>(p => p.token_name).ToArray();
            }
        }

        //F213
        public MapCustomerDTO MapSearch(MapSearchDTO dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                var data = repository.MapSearch(dto.ToEntity());
                MapCustomerDTO result = null;

                if (data != null && data.Count > 0)
                {
                    result = new MapCustomerDTO();
                    result.CustomerID = data[0].CUSTOMER_ID;
                    result.CustomerCode = data[0].CUSTOMER_CODE;
                    result.CustomerName = data[0].CUSTOMER_NAME;
                    result.CustomerStatusID = data[0].STATUS_ID;
                    result.CustomerStatus = data[0].CUSTOMER_STATUS;
                    result.CustomerStatusAr = data[0].CUSTOMER_STATUS_AR;
                    result.CustomerTypeID = data[0].CUSTOMER_TYPE_ID;
                    result.CustomerType = data[0].CUSTOMER_TYPE_NAME;
                    result.CustomerTypeAr = data[0].CUSTOMER_TYPE_NAME_AR;

                    int? tempBenID = null;
                    int recCount = 0;
                    List<MapBeneficiaryDTO> benList = new List<MapBeneficiaryDTO>();
                    List<MapTokenDTO> tokList = new List<MapTokenDTO>();
                    MapBeneficiaryDTO benDTO = new MapBeneficiaryDTO();
                    MapTokenDTO tokDTO;

                    foreach (var item in data)
                    {
                        if (item.BENEFICIARY_ID != null)
                        {
                            if (tempBenID != item.BENEFICIARY_ID)
                            {
                                if (benDTO.BeneficiaryID != null)
                                {
                                    benList.Add(benDTO);
                                    result.Beneficiary = benList;
                                    tokList = new List<MapTokenDTO>();
                                }
                                tempBenID = item.BENEFICIARY_ID;
                                benDTO = new MapBeneficiaryDTO();
                                benDTO.CustomerID = item.CUSTOMER_ID;
                                benDTO.BeneficiaryID = item.BENEFICIARY_ID;
                                benDTO.BeneficiaryCode = item.BENEFICIARY_CODE;
                                benDTO.BeneficiaryName = item.BENEFICIARY_NAME;
                                benDTO.BeneficiaryStatusID = item.BENEFICIARY_STATUS_ID;
                                benDTO.BeneficiaryStatus = item.BENEFICIARY_STATUS;
                                benDTO.BeneficiaryStatusAr = item.BENEFICIARY_STATUS_AR;
                            }
                            if (item.TOKEN_ID != null)
                            {
                                tokDTO = new MapTokenDTO();
                                tokDTO.BeneficiaryID = item.BENEFICIARY_ID;
                                tokDTO.TokenID = item.TOKEN_ID;
                                tokDTO.TokenName = item.TOKEN_NAME;
                                tokDTO.TokenCode = item.TOKEN_CODE;
                                tokDTO.TokenStatusID = item.TOKEN_STATUS_ID;
                                tokDTO.TokenStatus = item.TOKEN_STATUS;
                                tokDTO.TokenStatusAr = item.TOKEN_STATUS_AR;
                                tokDTO.TokenTypeID = item.TOKEN_TYPE_ID;
                                tokDTO.TokenType = item.TOKEN_TYPE_NAME;
                                tokDTO.TokenTypeAr = item.TOKEN_TYPE_NAME_AR;
                                tokList.Add(tokDTO);
                                benDTO.Token = tokList;
                            }
                            if (recCount == data.Count - 1)
                            {
                                if (benDTO.BeneficiaryID != null)
                                {
                                    benList.Add(benDTO);
                                    result.Beneficiary = benList;
                                }
                            }
                            recCount++;
                        }
                    }
                }
                return result;
            }
        }

        public List<TokenSearchDTO> AccountTokenSearch(AccountTokenSearchDTO dto, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.AccountTokenSearch(dto.ToAEntity(), pageNo, pageSize, out rowCount).ToADTOs();
            }
        }

        public MapCustomerDTO AccountMapSearch(AccountMapSearchDTO dto, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                var data = repository.AccountMapSearch(dto.ToEntity(), pageNo, pageSize, out rowCount);
                MapCustomerDTO result = null;

                if (data != null && data.Count > 0)
                {
                    result = new MapCustomerDTO();
                    result.CustomerID = data[0].CUSTOMER_ID;
                    result.CustomerCode = data[0].CUSTOMER_CODE;
                    result.CustomerName = data[0].CUSTOMER_NAME;
                    result.CustomerStatusID = data[0].STATUS_ID;
                    result.CustomerStatus = data[0].CUSTOMER_STATUS;
                    result.CustomerStatusAr = data[0].CUSTOMER_STATUS_AR;
                    result.CustomerTypeID = data[0].CUSTOMER_TYPE_ID;
                    result.CustomerType = data[0].CUSTOMER_TYPE_NAME;
                    result.CustomerTypeAr = data[0].CUSTOMER_TYPE_NAME_AR;

                    int? tempBenID = null;
                    int recCount = 0;
                    List<MapBeneficiaryDTO> benList = new List<MapBeneficiaryDTO>();
                    List<MapTokenDTO> tokList = new List<MapTokenDTO>();
                    MapBeneficiaryDTO benDTO = new MapBeneficiaryDTO();
                    MapTokenDTO tokDTO;

                    foreach (var item in data)
                    {
                        if (item.BENEFICIARY_ID != null)
                        {
                            if (tempBenID != item.BENEFICIARY_ID)
                            {
                                if (benDTO.BeneficiaryID != null)
                                {
                                    benList.Add(benDTO);
                                    result.Beneficiary = benList;
                                    tokList = new List<MapTokenDTO>();
                                }
                                tempBenID = item.BENEFICIARY_ID;
                                benDTO = new MapBeneficiaryDTO();
                                benDTO.CustomerID = item.CUSTOMER_ID;
                                benDTO.BeneficiaryID = item.BENEFICIARY_ID;
                                benDTO.BeneficiaryCode = item.BENEFICIARY_CODE;
                                benDTO.BeneficiaryName = item.BENEFICIARY_NAME;
                                benDTO.BeneficiaryStatusID = item.BENEFICIARY_STATUS_ID;
                                benDTO.BeneficiaryStatus = item.BENEFICIARY_STATUS;
                                benDTO.IsDefaultBeneficiary = item.IS_DEFAULT_BENEFICIARY;
                            }
                            if (item.TOKEN_ID != null)
                            {
                                tokDTO = new MapTokenDTO();
                                tokDTO.BeneficiaryID = item.BENEFICIARY_ID;
                                tokDTO.TokenID = item.TOKEN_ID;
                                tokDTO.TokenName = item.TOKEN_NAME;
                                tokDTO.TokenCode = item.TOKEN_CODE;
                                tokDTO.TokenStatusID = item.TOKEN_STATUS_ID;
                                tokDTO.TokenStatus = item.TOKEN_STATUS;
                                tokDTO.TokenStatusAr = item.TOKEN_STATUS_AR;
                                tokDTO.TokenTypeID = item.TOKEN_TYPE_ID;
                                tokDTO.TokenType = item.TOKEN_TYPE_NAME;
                                tokDTO.TokenTypeAr = item.TOKEN_TYPE_NAME_AR;
                                tokList.Add(tokDTO);
                                benDTO.Token = tokList;
                            }
                            if (recCount == data.Count - 1)
                            {
                                if (benDTO.BeneficiaryID != null)
                                {
                                    benList.Add(benDTO);
                                    result.Beneficiary = benList;
                                }
                            }
                            recCount++;
                        }
                    }
                }
                return result;
            }
        }

        //F214
        public bool IsRestrictionGroupNameAlreadyExist(string restrictionGroupName, int? customerID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.IsRestrictionGroupNameAlreadyExist(restrictionGroupName, customerID);
            }
        }

        //F217
        public List<DriverCardDTO> SearchMappableDriverCard(DriverCardSearchDTO dto, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.SearchMappableDriverCard(dto.ToEntity(), pageNo, pageSize, out rowCount).ToDTOs();
            }
        }

        //F221
        public bool IsRestrictionGroupAllowedForToken(int tokenTypeID, int restrictionGroupID, out string message)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.IsRestrictionGroupAllowedForToken(tokenTypeID, restrictionGroupID, out message);
            }
        }

        //F222
        public int[] GetPrivilegedPagesForModule(string userName, int moduleID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetPrivilegedPagesForModule(userName, moduleID);
            }
        }

        //F223
        public bool IsRestrictionGroupInUse(int RestrictionGroupID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.IsRestrictionGroupInUse(RestrictionGroupID);
            }
        }

        //F226
        public List<StatusDTO> GetAllDriverCardStatus()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetAllDriverCardStatus().ToDTOs();
            }
        }

        //F228
        public List<DriverCardDTO> SearchNonTerminatedDriverCard(DriverCardSearchDTO dto, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.SearchNonTerminatedDriverCard(dto.ToEntity(), pageNo, pageSize, out rowCount).ToDTOs();
            }
        }

        //F229
        public int[] GetPrivilegedFunctionsForPage(string userName, int pageID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetPrivilegedFunctionsForPage(userName, pageID);
            }
        }

        public List<VehicleModelDTO> GetVehicleModelsByMake(int makeId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetVehicleModelsByMake(makeId).ToDTOs();
            }
        }

        public VehicleInfoDTO GetVehicleInfoByID(int vehicleInfoID)
        {

            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                var data = repository.GetVehicleInfoByID(vehicleInfoID).ToList();
                if (data != null && data.Count > 0)
                    return data[0].ToDTO();
                else
                    return null;
            }
        }

        public VehicleRegisterDTO GetVehicleRegisterByID(int vehicleRegisterID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetVehicleRegisterByID(vehicleRegisterID).ToDTO();
            }
        }

        public TimeFrequencyDTO GetTimeFrequencyByID(int timeFrequencyId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                var data = repository.GetTimeFrequencyByID(timeFrequencyId).ToList();
                if (data != null && data.Count > 0)
                    return data[0].ToDTO();
                else
                    return null;
            }
        }

        public int UpdateVehicleInfo(VehicleInfoDTO dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);

                return repository.UpdateVehicleInfo(dto.ToEntity());
            }
        }

        public int UpdateVehicleRegister(VehicleRegister dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);

                return repository.UpdateVehicleRegister(dto.ToCTEntity());
            }
        }

        public List<RestrictionAmountDTO> GetRestrictionAmount(int restrictionGroupID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                var data = repository.GetRestrictionAmount(restrictionGroupID).ToDTOs();
                return data;
            }
        }

        public List<RestrictionProductDTO> GetRestrictionProduct(int restrictionGroupID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetRestrictionProduct(restrictionGroupID).ToDTOs();
            }
        }

        public List<RestrictionQuantityDTO> GetRestrictionQuantity(int restrictionGroupID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetRestrictionQuantity(restrictionGroupID).ToDTOs();
            }
        }

        public List<RestrictionStationDTO> GetRestrictionStation(int restrictionGroupID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetRestrictionStation(restrictionGroupID).ToDTOs();
            }
        }

        public List<RestrictionTransNoDTO> GetRestrictionTransNo(int restrictionGroupID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetRestrictionTransNo(restrictionGroupID).ToDTOs();
            }
        }

        public List<RestrictionTransactionDTO> GetRestrictionTransaction(int restrictionGroupID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetRestrictionTransaction(restrictionGroupID).ToDTOs();
            }
        }

        public List<RestrictionWeekDayDTO> GetRestrictionWeekDay(int restrictionGroupID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetRestrictionWeekDay(restrictionGroupID).ToDTOs();
            }
        }

        public List<RestrictionGroupTimeDTO> GetRestrictionGroupTime(int restrictionGroupID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetRestrictionGroupTime(restrictionGroupID).ToDTOs();
            }
        }

        //F297
        public bool IsRestrictionExistForBeneficiaryToken(int beneficiary_id)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.IsRestrictionExistForBeneficiaryToken(beneficiary_id);
            }
        }

        //F298
        public bool RemoveRestrictionForBeneficiaryToken(int beneficiary_id, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            using (var unitofWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitofWork);
                return repository.RemoveRestrictionForBeneficiaryToken(beneficiary_id, UserID, LastUpdatedDate, LocationId);
            }
        }

        //F299
        public List<TokenToDeliverDTO> SearchTokensReadyForDelivery(SearchTokenToDeliverDTO dto, out int totalCount)
        {
            using (var unitofWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitofWork);
                return repository.SearchTokensReadyForDelivery(dto.MapToEntity(), out totalCount).MapToListDto();
            }
        }

        //F300
        public bool UpdateTokenDeliveredStatus(int token_id, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            using (var unitofWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitofWork);
                return repository.UpdateTokenDeliveredStatus(token_id, UserID, LastUpdatedDate, LocationId);
            }
        }

        //F301
        public List<TokenTypeDTO> GetAllPersonalizationTokenTypes()
        {
            using (var unitofWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitofWork);
                return repository.GetAllPersonalizationTokenTypes().ToDTOs();
            }
        }

        //F302
        public bool IsTokenRestrictionExistForCustomerTokens(int customer_id, int? BenenficiaryId)
        {
            using (var unitofWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitofWork);
                return repository.IsTokenRestrictionExistForCustomerTokens(customer_id, BenenficiaryId);
            }
        }

        //F303
        public bool RemoveRestrictionForCustomerToken(int customer_id, int UserID, DateTime LastUpdatedDate, int LocationId)
        {
            using (var unitofWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitofWork);
                return repository.RemoveRestrictionForCustomerToken(customer_id, UserID, LastUpdatedDate, LocationId);
            }
        }

        //F316
        public CurrencyDTO GetCurrency()
        {
            using (var unitofWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitofWork);
                var data = repository.GetCurrency();
                return new CurrencyDTO { CurrencyName = data.EN_CURRANCY_NAME, DecimalPlaces = (int)data.SUBCURRENCYNOOFFRACTIONS };
            }
        }

        //F317
        public List<DictionaryDTO> GetAllActiveBeneficiaryNames(int customerID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetAllActiveBeneficiaryNames(customerID).ToDTOs();
            }
        }

        //F319
        public bool IsVehicleChassisAlreadyRegistered(string ChassisNumber, int? TokenID, out string TokenCode)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.IsVehicleChassisAlreadyRegistered(ChassisNumber, TokenID, out TokenCode);
            }
        }

        //F320
        public bool IsVehicleDetailsAlreadyRegistered(string PlateNumber, int PlateColorID, int VehicleEmirateID, int VehicleTypeID, int? TokenID, int TokenTypeID, out string TokenCode)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.IsVehicleDetailsAlreadyRegistered(PlateNumber, PlateColorID, VehicleEmirateID, VehicleTypeID, TokenID, TokenTypeID, out TokenCode);
            }
        }

        //F319
        public bool IsVehicleChassisAlreadyRegistered(string ChassisNumber)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.IsVehicleChassisAlreadyRegistered(ChassisNumber);
            }
        }

        //F320
        public bool IsVehicleDetailsAlreadyRegistered(string PlateNumber, int PlateColorID, int VehicleEmirateID, int VehicleTypeID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.IsVehicleDetailsAlreadyRegistered(PlateNumber, PlateColorID, VehicleEmirateID, VehicleTypeID);
            }
        }

        //F323
        public List<PersonalizationOrderTypesDTO> GetAllPersonalizationOrderTypes()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetAllPersonalizationOrderTypes().ToDTOs();
            }
        }

        public List<WorkOrderTypeDTO> GetAllWorkOrderTypes()
        {
            using (var unitofWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitofWork);
                return repository.GetAllWorkOrderTypes().ToDTOs();
            }
        }

        public List<WorkOrderStatusDTO> GetAllWorkOrderStatus()
        {
            using (var unitofWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitofWork);
                return repository.GetAllWorkOrderStatus().ToDTOs();
            }
        }

        public List<PersonalizationOrderStatusDTO> GetAllPersonalizationOrderStatus()
        {
            using (var unitofWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitofWork);
                return repository.GetAllPersonalizationOrderStatus().ToDTOs();
            }
        }
        //F331
        public bool IsTokenBelongingToBatch(int tokenId)
        {
            using (var unitofWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitofWork);
                return repository.IsTokenBelongingToBatch(tokenId);
            }
        }

        public List<PropertyDTO> GetVehicleColorBySourceID(int sourceId)
        {
            using (var unitofWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitofWork);
                return repository.GetVehicleColorBySourceID(sourceId).ToDTOs();
            }
        }

        public List<PropertyDTO> GetVehicleKindBySourceAndColor(int sourceId, int Colorid)
        {
            using (var unitofWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitofWork);
                return repository.GetVehicleKindBySourceAndColor(sourceId, Colorid).ToDTOs();
            }
        }

        public int SearchVehicleRegisterByName(string MakeDesc, string ModelDesc, int? yearId, int? CC)
        {
            using (var unitofWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitofWork);
                return repository.SearchVehicleRegisterByName(MakeDesc, ModelDesc, yearId, CC);
            }
        }

        public GetVehicleInfoDTO SearchTrafficVehicleInfo(int EmirateId, int ColorID, string PlateNO, int KindId, int? tokenID)
        {
            var objTraffic = new TrafficData.DAL.TrafficData();
            int VehicleRegisterId;
            TrafficvehicleSearchDTO entity = new TrafficvehicleSearchDTO();

            entity.i_pno = Convert.ToInt64(PlateNO);
            entity.i_psource_code = EmirateId;
            entity.i_pkind_code = KindId;
            entity.i_pcolor_code = ColorID;
            entity.i_tcfno = 0;
            //entity.i_pno = 18026;
            //entity.i_psource_code = 2;
            //entity.i_pkind_code = 1;
            //entity.i_pcolor_code = 23;
            entity.i_appl_name = "TestUser";
            entity.i_chassis_no = string.Empty;
            entity.i_ptype_code = 1;
            entity.i_user_code = "CSPUSER";
            entity.i_user_IPAddress = "127.0.0.1";
            entity.i_porg_no = 0;
            var ResultDto = objTraffic.SearchTrafficVehicleInfo(entity.ToEntity()).ToDTO();

            if (tokenID == null)
            {
                VehicleRegisterId = SearchVehicleRegisterByName(ResultDto.MakeName, ResultDto.ModelName, Convert.ToInt32(ResultDto.Year), ResultDto.CC);
            }
            else
            {
                var tokendto = GetTokenInfo((int)tokenID);
                VehicleRegisterId = tokendto.VehicleInfoDTO != null ? (int)tokendto.VehicleInfoDTO.VehicleRegisterID :
                    SearchVehicleRegisterByName(ResultDto.MakeName, ResultDto.ModelName, Convert.ToInt32(ResultDto.Year), ResultDto.CC);
            }
            if (VehicleRegisterId > -1)
            {
                var VehicleInof = GetVehicleRegisterByID(VehicleRegisterId);
                ResultDto.MakeId = VehicleInof.MakeID;
                ResultDto.ModelId = VehicleInof.ModelID;
                ResultDto.YearId = VehicleInof.Year;

                return ResultDto;
            }
            else return null;
        }

        public List<StationDTO> GetAllStationsWithCoordinates()
        {
            using (var unitofWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitofWork);
                return repository.GetAllStationsWithCoordinates().ToDTOs();
            }
        }

        public bool IsTokenCustomExpiryApplied(int TokenId)
        {
            using (var unitofWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitofWork);
                return repository.IsTokenCustomExpiryApplied(TokenId);
            }
        }

        public VehicleDummyInfoDTO GetDummyVehicleInfo(string vehicleTypeCode, string plateNumber)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.GetDummyVehicleInfo(vehicleTypeCode, plateNumber).ToMDTO();
            }

        }
        public int SaveMOIVehicleRegister(VehicleRegisterSearchResultDTO dto, int UserID, int LocationId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.SaveMOIVehicleRegister(dto.ToEntity(), UserID, LocationId);
            }

        }
        public bool IsVehicleChassisAlreadyExist(string ChassisNumber, int? TokenID, int TokenTypeID, out string TokenCode)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                return repository.IsVehicleChassisAlreadyExists(ChassisNumber, TokenID, TokenTypeID, out TokenCode);
            }
        }
        public List<ConsumedAmountResultDTO> GetConsumedAmount(int restrictionGroupID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                var data = repository.GetConsumedAmount(restrictionGroupID).ToDTOs();
                return data;
            }
        }
        public List<ConsumedQuantityResultDTO> GetConsumedQuantiy(int restrictionGroupID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                var data = repository.GetConsumedQuantiy(restrictionGroupID).ToDTOs();
                return data;
            }
        }

        public List<ConsumedTransNoResultDTO> GetConsumedTransNo(int restrictionGroupID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                var data = repository.GetConsumedTransNo(restrictionGroupID).ToDTOs();
                return data;
            }
        }
        ///F126
        /// <summary>
        /// Add the token information and the restriction group id details to token table. 
        /// Create a personalization request if the token type is card. 
        /// </summary>
        /// <param name="tokenDTO"></param>
        /// <returns></returns>
        public List<BatchTokenDTO> AddBatchTokenDetails(List<BatchTokenDTO> dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                string remarks = string.Empty;
                string tokenCode = string.Empty;
                int personalizationID = -1;

                bool res = repository.IsBalanceSufficientForBatchTokenPersonalization(dto[0].CustomerID, dto.Count);
                //AddServiceTransaction(32, dto[0].CustomerID, dto[0].BeneficiaryID, dto[0].TokenID, dto[0].LastUpdatedUserId, dto[0].LastUpdatedUserId, dto[0].LastUpdatedDate, dto[0].LastUpdatedLocationID);
                if (res)
                {
                    foreach (var item in dto)
                    {
                        BaseDTO Audit = new BaseDTO { LastUpdatedDate = item.LastUpdatedDate, LastUpdatedUserId = item.LastUpdatedUserId, LastUpdatedLocationID = item.LastUpdatedLocationID };
                        item.PersonalizationOrderID = personalizationID;
                        item.Status = repository.AddBatchTokenInfo(item.ToEntity(), Audit.ToEntity(), out remarks, out tokenCode, out personalizationID);
                        item.StatusRemark = remarks;
                        item.TokenCode = tokenCode;

                    }
                    dto[0].PersonalizationOrderID = personalizationID;
                    return dto;
                }
                else return null;
            }

        }

        public BatchTokenDTODetails AddBatchTokenDetails(BatchTokenDTODetails dto, out string errorMessage)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new TokenRepository(unitOfWork);
                string remarks = string.Empty;
                string tokenCode = string.Empty;
                int personalizationID = -1;

                BaseDTO Audit = new BaseDTO { LastUpdatedDate = dto.LastUpdatedDate, LastUpdatedUserId = dto.LastUpdatedUserId, LastUpdatedLocationID = dto.LastUpdatedLocationID };
                dto.PersonalizationOrderID = personalizationID;
                dto.VehicleInfoDto.VehicleRegisterID = SaveMOIVehicleRegister(new Token.BLL.DTO.VehicleRegisterSearchResultDTO()
                {
                    MakeNameEn = dto.VehicleInfoDto.VehicleRegisterDTO.MakeNameEn,
                    MakeNameAr = dto.VehicleInfoDto.VehicleRegisterDTO.MakeNameAr,
                    ModelNameEn = dto.VehicleInfoDto.VehicleRegisterDTO.ModelNameEn,
                    ModelNameAr = dto.VehicleInfoDto.VehicleRegisterDTO.ModelNameAr,
                    IsActive = true,
                    FuelInlet = dto.VehicleInfoDto.VehicleRegisterDTO.FuelInlet.ToString(),
                    FuelCapacity = dto.VehicleInfoDto.VehicleRegisterDTO.FuelCapacity,
                    Cc = dto.VehicleInfoDto.VehicleRegisterDTO.Cc.ToString(),
                    Year = dto.VehicleInfoDto.VehicleRegisterDTO.Year.ToString()
                }, (int)dto.LastUpdatedUserId, (int)dto.LastUpdatedLocationID);
                var TokenID = repository.AddBatchTokenDetails(dto.ToEntity(), dto.TokenRestriction.ToEntity(), dto.VehicleInfoDto.ToEntity(), Audit.ToEntity(), out remarks, out tokenCode);
                if (TokenID > 0)
                {
                    dto.TokenID = TokenID;
                    dto.TokenCode = tokenCode;
                    dto.Status = true;
                }
                dto.StatusRemark = remarks;
                errorMessage = remarks;
                return dto;

            }

        }

    }
}
