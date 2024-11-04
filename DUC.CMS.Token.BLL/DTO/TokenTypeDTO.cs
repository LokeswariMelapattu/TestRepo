using System;
using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class TokenTypeDTO:BaseDTO
    {
        [DataMember()]
        public Int32 TOKEN_TYPE_ID { get; set; }

        [DataMember()]
        public String EN_NAME { get; set; }

        [DataMember()]
        public Int16 IS_ACTIVE { get; set; }

        [DataMember()]
        public String DESCRIPTION { get; set; }

        [DataMember()]
        public String AR_NAME { get; set; }

    }
}
