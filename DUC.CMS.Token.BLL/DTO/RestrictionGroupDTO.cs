using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class RestrictionGroupDTO : BaseDTO
    {
        [DataMember]
        public int? CustomerID { get; set; }

        [DataMember]
        public int? RestrictionGroupID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool IsSystemDefinedRestrictionGroup { get; set; }

        [DataMember]
        public Nullable<int> ConsecutiveUsageRestriction { get; set; }

        [DataMember]
        public bool HolidayRestriction { get; set; }

        [DataMember]
        public bool RequireOdometerInput { get; set; }

        [DataMember]
        public bool RequireDriverCard { get; set; }

        [DataMember]
        public bool CanBuyDryStock { get; set; }

        [DataMember]
        public bool CanUseAdnocService { get; set; }


        public Lazy<List<ProductCategroryRestrictionDTO>> ProductCategoryRestrictionLazy { get; set; }
        private List<ProductCategroryRestrictionDTO> _productCategoryRestrictions;
        [DataMember]
        public List<ProductCategroryRestrictionDTO> ProductCategoryRestrictions
        {
            get
            {
                if (_productCategoryRestrictions == null && ProductCategoryRestrictionLazy != null)
                    _productCategoryRestrictions = ProductCategoryRestrictionLazy.Value;
                return _productCategoryRestrictions;
            }
            set
            {
                _productCategoryRestrictions = value;
            }
        }



        private List<RestrictionAmountDTO> _RestrictionAmount = null;

        public Lazy<List<RestrictionAmountDTO>> _RestrictionAmountDTO = null;

        [DataMember]
        public List<RestrictionAmountDTO> RestrictionAmountDTO
        {
            get
            {
                if (_RestrictionAmountDTO == null)
                {
                    if (_RestrictionAmount != null)
                    {
                        return this._RestrictionAmount;
                    }
                    return null;
                }
                else
                {
                    return _RestrictionAmountDTO.Value;
                }
            }
            set
            {
                this._RestrictionAmount = value;
            }
        }

        private List<RestrictionProductDTO> _RestrictionProduct = null;

        public Lazy<List<RestrictionProductDTO>> _RestrictionProductDTO = null;

        [DataMember]
        public List<RestrictionProductDTO> RestrictionProductDTO
        {
            get
            {
                if (_RestrictionProductDTO == null)
                {
                    if (_RestrictionProduct != null)
                    {
                        return this._RestrictionProduct;
                    }
                    return null;
                }
                else
                {
                    return _RestrictionProductDTO.Value;
                }
            }
            set
            {
                this._RestrictionProduct = value;
            }
        }

        private List<RestrictionQuantityDTO> _RestrictionQuantity = null;

        public Lazy<List<RestrictionQuantityDTO>> _RestrictionQuantityDTO = null;

        [DataMember]
        public List<RestrictionQuantityDTO> RestrictionQuantityDTO
        {
            get
            {
                if (_RestrictionQuantityDTO == null)
                {
                    if (_RestrictionQuantity != null)
                    {
                        return this._RestrictionQuantity;
                    }
                    return null;
                }
                else
                {
                    return _RestrictionQuantityDTO.Value;
                }
            }
            set
            {
                this._RestrictionQuantity = value;
            }
        }

        private List<RestrictionStationDTO> _RestrictionStation = null;

        public Lazy<List<RestrictionStationDTO>> _RestrictionStationDTO = null;

        [DataMember]
        public List<RestrictionStationDTO> RestrictionStationDTO
        {
            get
            {
                if (_RestrictionStationDTO == null)
                {
                    if (_RestrictionStation != null)
                    {
                        return this._RestrictionStation;
                    }
                    return null;
                }
                else
                {
                    return _RestrictionStationDTO.Value;
                }
            }
            set
            {
                this._RestrictionStation = value;
            }
        }

        private List<RestrictionTransNoDTO> _RestrictionTransNo = null;

        public Lazy<List<RestrictionTransNoDTO>> _RestrictionTransNoDTO = null;

        [DataMember]
        public List<RestrictionTransNoDTO> RestrictionTransNoDTO
        {
            get
            {
                if (_RestrictionTransNoDTO == null)
                {
                    if (_RestrictionTransNo != null)
                    {
                        return this._RestrictionTransNo;
                    }
                    return null;
                }
                else
                {
                    return _RestrictionTransNoDTO.Value;
                }
            }
            set
            {
                this._RestrictionTransNo = value;
            }
        }

        private List<RestrictionTransactionDTO> _RestrictionTransaction = null;

        public Lazy<List<RestrictionTransactionDTO>> _RestrictionTransactionDTO = null;

        [DataMember]
        public List<RestrictionTransactionDTO> RestrictionTransactionDTO
        {
            get
            {
                if (_RestrictionTransactionDTO == null)
                {
                    if (_RestrictionTransaction != null)
                    {
                        return this._RestrictionTransaction;
                    }
                    return null;
                }
                else
                {
                    return _RestrictionTransactionDTO.Value;
                }
            }
            set
            {
                this._RestrictionTransaction = value;
            }
        }

        private List<RestrictionWeekDayDTO> _RestrictionWeekDay = null;

        public Lazy<List<RestrictionWeekDayDTO>> _RestrictionWeekDayDTO = null;



        [DataMember]
        public List<RestrictionWeekDayDTO> RestrictionWeekDayDTO
        {
            get
            {
                if (_RestrictionWeekDayDTO == null)
                {
                    if (_RestrictionWeekDay != null)
                    {
                        return this._RestrictionWeekDay;
                    }
                    return null;
                }
                else
                {
                    return _RestrictionWeekDayDTO.Value;
                }
            }
            set
            {
                this._RestrictionWeekDay = value;
            }
        }


        private List<RestrictionGroupTimeDTO> _RestrictionGroupTime = null;

        public Lazy<List<RestrictionGroupTimeDTO>> _RestrictionGroupTimeDTO = null;
        [DataMember]
        public List<RestrictionGroupTimeDTO> RestrictionGroupTimeDTO
        {
            get
            {
                if (_RestrictionGroupTimeDTO == null)
                {
                    if (_RestrictionGroupTime != null)
                    {
                        return this._RestrictionGroupTime;
                    }
                    return null;
                }
                else
                {
                    return _RestrictionGroupTimeDTO.Value;
                }
            }
            set
            {
                this._RestrictionGroupTime = value;
            }
        }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public string RsAmount { get; set; }

        [DataMember]
        public string RsProduct { get; set; }

        [DataMember]
        public string RsQuantity { get; set; }

        [DataMember]
        public string RsTransNo { get; set; }

        [DataMember]
        public string RsTransaction { get; set; }

        [DataMember]
        public string RsStation { get; set; }

        [DataMember]
        public string RsWeekday { get; set; }

        [DataMember]
        public string RsTime { get; set; }
    }
}
