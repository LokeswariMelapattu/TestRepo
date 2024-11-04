using System;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial class ContactDTO : BaseDTO
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
        public Nullable<Int32> NotificationLanguageID { get; set; }

        [DataMember()]
        public Nullable<Int32> NotificationChannelID { get; set; }

        [DataMember()]
        public Nullable<Int32> LastUpdatedUserID { get; set; }

        [DataMember()]
        public String PIN { get; set; }

        [DataMember()]
        public string Code { get; set; }
    }
}
