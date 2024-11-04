using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficData.DAL
{
    public partial class CTData
    {
        public Nullable<Int64> i_tcfno { get; set; }
        public Nullable<Int64> i_pno { get; set; }
        public Nullable<int> i_porg_no { get; set; }
        public Nullable<int> i_pcolor_code { get; set; }
        public Nullable<int> i_pkind_code { get; set; }
        public Nullable<int> i_ptype_code { get; set; }
        public Nullable<int> i_psource_code { get; set; }
        public string i_chassis_no { get; set; }
        public string i_user_IPAddress { get; set; }
        public string i_user_code { get; set; }
        public string i_appl_name { get; set; }
        public string o_owner_tcfno { get; set; }
        public string o_owner_name { get; set; }
        public string o_owner_name_Ar { get; set; }
        public Nullable<int> o_color_code { get; set; }
        public string o_color_desc_ar { get; set; }
        public string o_color_desc { get; set; }
        public Nullable<int> o_type_code { get; set; }
        public string o_type_desc_ar { get; set; }
        public string o_type_desc { get; set; }
        public Nullable<int> o_nat_code { get; set; }
        public string o_nat_desc_ar { get; set; }
        public string o_nat_desc { get; set; }
        public Nullable<int> o_year { get; set; }
        public Nullable<int> o_chairs { get; set; }
        public Nullable<int> o_make_code { get; set; }
        public string o_make_desc_ar { get; set; }
        public string o_make_desc { get; set; }
        public Nullable<int> o_model_code { get; set; }
        public string o_model_desc_ar { get; set; }
        public string o_model_desc { get; set; }
        public Nullable<int> o_kind_code { get; set; }
        public string o_kind_desc_ar { get; set; }
        public string o_kind_desc { get; set; }
        public Nullable<int> o_weight_empty { get; set; }
        public Nullable<int> o_weight_full { get; set; }
        public Nullable<System.DateTime> o_reg_date { get; set; }
        public Nullable<System.DateTime> o_reg_expiry_date { get; set; }
        public string o_engine_no { get; set; }
        public string o_chassis_no { get; set; }
        public Nullable<int> o_gear_code { get; set; }
        public string o_gear_desc_ar { get; set; }
        public string o_gear_desc { get; set; }
        public Nullable<int> o_fuel_code { get; set; }
        public string o_fuel_desc_ar { get; set; }
        public string o_fuel_desc { get; set; }
        public Nullable<int> o_weight_code { get; set; }
        public string o_weight_desc_ar { get; set; }
        public string o_weight_desc { get; set; }
        public Nullable<int> o_steering_code { get; set; }
        public string o_steering_desc_ar { get; set; }
        public string o_steering_desc { get; set; }
        public Nullable<int> o_cylinder { get; set; }
        public Nullable<int> o_axels_count { get; set; }
        public Nullable<int> o_door_count { get; set; }
        public Nullable<int> o_horse_power { get; set; }
        public Nullable<int> o_wheels_count { get; set; }
        public string o_reg_remarks { get; set; }
        public string o_wanted { get; set; }
        public string o_accident { get; set; }
        public string o_fine_auh { get; set; }
        public string o_fine_ne { get; set; }
        public Nullable<int> o_fine_auh_amt { get; set; }
        public Nullable<int> o_fine_ne_amt { get; set; }
        public Nullable<int> o_cubic_capacity_cc { get; set; }
        public Nullable<int> o_mileage_count { get; set; }
        public Nullable<int> O_ERR_CODE { get; set; }
        public string O_ERR_MSG { get; set; }


    }
}
