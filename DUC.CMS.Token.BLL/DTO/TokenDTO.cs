using System;
using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class TokenDTO : BaseDTO
    {
        [DataMember]
        public int? TokenID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public int TokenTypeID { get; set; }

        [DataMember]
        public DateTime? ExpiryDate { get; set; }

        [DataMember]
        public Nullable<int> RestrictionGroupID { get; set; }

        [DataMember]
        public Nullable<int> NoOfActiveTags { get; set; }

        [DataMember]
        public Nullable<int> TokenStatusID { get; set; }

        [DataMember]
        public Nullable<int> TokenStatusReasonID { get; set; }

        [DataMember]
        public bool IsStatusInherited { get; set; }

        [DataMember]
        public Nullable<int> WorkOrderID { get; set; }

        [DataMember]
        public Nullable<int> PersonalizationOrderID { get; set; }

        [DataMember]
        public string Serial { get; set; }

        [DataMember]
        public string SecondSerial { get; set; }

        [DataMember]
        public string ThirdSerial { get; set; }

        [DataMember]
        public string TokenChipNo { get; set; }

        [DataMember]
        public string SecondTokenChipNo { get; set; }

        [DataMember]
        public Nullable<int> VehicleInfoID { get; set; }

        private VehicleInfoDTO _VehicleInfo = null;

        public Lazy<VehicleInfoDTO> _VehicleInfoDTO = null;

        [DataMember]
        public VehicleInfoDTO VehicleInfoDTO
        {
            get
            {
                if (_VehicleInfoDTO == null)
                {
                    if (_VehicleInfo != null)
                    {
                        return this._VehicleInfo;
                    }
                    return null;
                }
                else
                {
                    return _VehicleInfoDTO.Value;
                }
            }
            set
            {
                this._VehicleInfo = value;
            }
        }

        [DataMember]
        public Nullable<int> CustomerID { get; set; }

        [DataMember]
        public Nullable<int> BeneficiaryID { get; set; }

        [DataMember]
        public DateTime? RegistrationDate { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
    
        [DataMember]
        public int? CustomExpiryYears { get; set; }

        [DataMember]
        public bool IsTransactionNotification { get; set; }

        [DataMember]
        public bool IsFeeWaivedOff { get; set; }

    }
}
