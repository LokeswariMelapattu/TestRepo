/*
//------------------------------------------------------------------------------
// Author - Diyar United Company
// Dated  - 21 July 2014
// Project- CMS Customer Service
//------------------------------------------------------------------------------
*/
//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2014-07-21 - 07:20:35
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DUC.CMS.CustomerService.BLL.Dtos
{
    [DataContract()]
    public partial class VEHICLE_STATEDto : BaseDTO
    {
        [DataMember()]
        public Int32 VEHICLE_STATE_ID { get; set; }

        [DataMember()]
        public String EN_STATE { get; set; }

        [DataMember()]
        public Int16 IS_ACTIVE { get; set; }

        [DataMember()]
        public String AR_STATE { get; set; }

        [DataMember()]
        public List<Int32> VEHICLE_INFO_VEHICLE_INFO_ID { get; set; }
    }
}