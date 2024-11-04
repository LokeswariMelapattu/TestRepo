using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial class SMSMessageDTO : BaseDTO
    {
        [DataMember()]
        public Int32? MessageId { get; set; }

        [DataMember()]
        public String MessageBody { get; set; }

        [DataMember()]
        public String MobileNumber { get; set; }

        [DataMember()]
        public bool IsSent { get; set; }

        [DataMember()]
        public Nullable<Int32> CustomerId { get; set; }

        [DataMember()]
        public Nullable<Int32> BeneficiaryId { get; set; }

        [DataMember()]
        public Nullable<DateTime> MessageDateTime { get; set; }

        [DataMember()]
        public Int32 LanguageId { get; set; }

    }
}
