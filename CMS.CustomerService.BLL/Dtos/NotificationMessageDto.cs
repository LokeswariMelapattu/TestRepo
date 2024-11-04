using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    public class NotificationMessageDto : BaseDTO
    {
        [DataMember]
        public string MessageCode { get; set; }

        [DataMember]
        public string MessageBody { get; set; }

        [DataMember]
        public string ArMessageBody { get; set; }

        [DataMember]
        public string MessageSubject { get; set; }

        [DataMember]
        public string ArMessageSubject { get; set; }

        [DataMember]
        public Int16 MessageType { get; set; }
    }
}
