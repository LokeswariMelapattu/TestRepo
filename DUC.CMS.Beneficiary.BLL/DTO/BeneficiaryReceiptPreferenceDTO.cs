using System;
using System.Runtime.Serialization;

namespace DUC.CMS.Beneficiary.BLL.DTO
{
    [DataContract()]
    public partial class BeneficiaryReceiptPreferenceDTO : BaseDTO
    {
        [DataMember()]
        public Int32? BeneficiaryId { get; set; }

        [DataMember()]
        public Int32? ReceiptTypeId { get; set; }

    }
}
