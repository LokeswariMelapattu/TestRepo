﻿using System;
using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class RestrictionTransNoDTO : BaseDTO
    {
        [DataMember]
        public int RestrictionGroupID { get; set; }

        [DataMember]
        public int? NumberOfDays { get; set; }

        [DataMember]
        public Nullable<int> NumberOfTransactions { get; set; }

        [DataMember]
        public int TimeFrequencyID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public int ProductCategoryID { get; set; }

    }
}
