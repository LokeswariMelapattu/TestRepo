using System;
using System.Runtime.Serialization;

namespace DUC.CMS.Token.BLL.DTO
{
    [DataContract]
    public class TrafficvehicleSearchResultDTO 
    {
        [DataMember] public int? i_tcfno { get; set; }
        [DataMember] public int? i_pno { get; set; }
        [DataMember] public int? i_porg_no { get; set; }
        [DataMember] public int? i_pcolor_code { get; set; }
        [DataMember] public int? i_pkind_code { get; set; }
        [DataMember] public int? i_ptype_code { get; set; }
        [DataMember] public int? i_psource_code { get; set; }
        [DataMember] public string i_chassis_no { get; set; }
        [DataMember] public string i_user_IPAddress { get; set; }
        [DataMember] public string i_user_code { get; set; }
        [DataMember] public string i_appl_name { get; set; }
        [DataMember] public int? o_owner_tcfno { get; set; }
        [DataMember] public string o_owner_name { get; set; }
        [DataMember] public string o_owner_name_Ar { get; set; }
        [DataMember] public int? o_color_code { get; set; }
        [DataMember] public string o_color_desc_ar { get; set; }
        [DataMember] public string o_color_desc { get; set; }
        [DataMember] public int? o_type_code { get; set; }
        [DataMember] public string o_type_desc_ar { get; set; }
        [DataMember] public string o_type_desc { get; set; }
        [DataMember] public int? o_nat_code { get; set; }
        [DataMember] public string o_nat_desc_ar { get; set; }
        [DataMember] public string o_nat_desc { get; set; }
        [DataMember] public int? o_year { get; set; }
        [DataMember] public int? o_chairs { get; set; }
        [DataMember] public int? o_make_code { get; set; }
        [DataMember] public string o_make_desc_ar { get; set; }
        [DataMember] public string o_make_desc { get; set; }
        [DataMember] public int? o_model_code { get; set; }
        [DataMember] public string o_model_desc_ar { get; set; }
        [DataMember] public string o_model_desc { get; set; }
        [DataMember] public int? o_kind_code { get; set; }
        [DataMember] public string o_kind_desc_ar { get; set; }
        [DataMember] public string o_kind_desc { get; set; }
        [DataMember] public int? o_weight_empty { get; set; }
        [DataMember] public int? o_weight_full { get; set; }
        [DataMember] public DateTime? o_reg_date { get; set; }
        [DataMember] public DateTime? o_reg_expiry_date { get; set; }
        [DataMember] public string o_engine_no { get; set; }
        [DataMember] public string o_chassis_no { get; set; }
        [DataMember] public int? o_gear_code { get; set; }
        [DataMember] public string o_gear_desc_ar { get; set; }
        [DataMember] public string o_gear_desc { get; set; }
        [DataMember] public int? o_fuel_code { get; set; }
        [DataMember] public string o_fuel_desc_ar { get; set; }
        [DataMember] public string o_fuel_desc { get; set; }
        [DataMember] public int? o_weight_code { get; set; }
        [DataMember] public string o_weight_desc_ar { get; set; }
        [DataMember] public string o_weight_desc { get; set; }
        [DataMember] public int? o_steering_code { get; set; }
        [DataMember] public string o_steering_desc_ar { get; set; }
        [DataMember] public string o_steering_desc { get; set; }
        [DataMember] public int? o_cylinder { get; set; }
        [DataMember] public int? o_axis_count { get; set; }
        [DataMember] public int? o_door_count { get; set; }
        [DataMember] public int? o_horse_power { get; set; }
        [DataMember] public int? o_wheels_count { get; set; }
        [DataMember] public string o_reg_remarks { get; set; }
        [DataMember] public string o_wanted { get; set; }
        [DataMember] public string o_accident { get; set; }
        [DataMember] public string o_fine_auh { get; set; }
        [DataMember] public string o_fine_ne { get; set; }
        [DataMember] public int? o_fine_auh_amt { get; set; }
        [DataMember] public int? o_fine_ne_amt { get; set; }
        [DataMember] public int? o_cubic_capacity_cc { get; set; }
        [DataMember] public int? o_mileage_count { get; set; }
        [DataMember] public int? O_ERR_CODE { get; set; }
        [DataMember] public string O_ERR_MSG { get; set; }
    }
}
