using System;
using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    public class PersonalizationOrderDTO:BaseDTO
    {
        [DataMember]
        public int PERSONALIZATION_ORDER_ID { get; set; }
        [DataMember]
        public string PERSONALIZATION_NUMBER { get; set; }
        [DataMember]
        public Nullable<int> PERSONALIZATION_STATUS_ID { get; set; }
        [DataMember]
        public Nullable<int> CARD_CENTER_ID { get; set; }
        [DataMember]
        public Nullable<int> PRINTER_ID { get; set; }
        [DataMember]
        public Nullable<System.DateTime> APPOINTMENT_DATE_TIME { get; set; }
        [DataMember]
        public Nullable<System.DateTime> ACTUAL_SERVICE_DATE_TIME { get; set; }
        [DataMember]
        public int PASSED_QUALITY_TEST { get; set; }
        [DataMember]
        public Nullable<int> PERSONALIZATION_ORDER_TYPE_ID { get; set; }
        [DataMember]
        public Nullable<int> PERSONALIZATION_REASON_ID { get; set; }
        [DataMember]
        public short IS_ACTIVE { get; set; }
        [DataMember]
        public string RecipientIDNumber { get; set; }

        [DataMember]
        public int? RecipientTypeID { get; set; }
    }
}
