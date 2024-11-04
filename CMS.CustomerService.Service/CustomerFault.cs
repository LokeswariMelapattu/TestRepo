using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.Service
{
    [DataContract]
    public class CustomerFault
    {
        public CustomerFault(string errorCode, string msg)
        {
            ErrorCode = errorCode;
            Message = msg;
        }

        [DataMember]
        public string ErrorCode { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}