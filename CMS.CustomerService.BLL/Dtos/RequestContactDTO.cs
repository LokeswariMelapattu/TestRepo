using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial class RequestContactDTO : BaseDTO
    {
        [DataMember()]
        public Int32? ContactID { get; set; }

        [DataMember()]
        public String Name { get; set; }

        [DataMember()]
        public String Mobile { get; set; }

        [DataMember()]
        public String Phone { get; set; }

        [DataMember()]
        public String Email { get; set; }

        [DataMember()]
        public String Fax { get; set; }

        [DataMember()]
        public String Code { get; set; }

        [DataMember()]
        public Int32? NotificationLanguageID { get; set; }

        [DataMember()]
        public int? NotificationChannelID { get; set; }

        [DataMember()]
        public int? LastUpdatedUserID { get; set; }
        [DataMember()]
        public int? ContactTypeID { get; set; }

        [DataMember()]
        public string PIN { get; set; }

    }
}
