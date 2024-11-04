using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Data;
using System.Configuration;

namespace TrafficData.DAL
{
    public class TrafficData
    {

        public CTData SearchTrafficVehicleInfo( CTData entity)
        {
            CTData Result = new CTData();
           //string conString = "Data Source=ADNOCR3; User ID=CMS; Password=cmsunlock1";
           string conString = ConfigurationSettings.AppSettings["TrafficConnection"];
           conString = DUC.Utilities.CryptoEngine.CryptoEngine.Decrypt(conString, true);
            
            using (OracleConnection objConn = new OracleConnection(conString))
            {
                string spName = ConfigurationSettings.AppSettings["spName"]; //"vep049";
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = objConn;
                objCmd.CommandText = spName;
                objCmd.CommandType = CommandType.StoredProcedure;

                #region DeclareInputParameter

                OracleParameter i_tcfno = objCmd.Parameters.Add("i_tcfno", OracleType.Number); i_tcfno.Direction = ParameterDirection.InputOutput; i_tcfno.Value = entity.i_tcfno;
                OracleParameter i_pno = objCmd.Parameters.Add("i_pno", OracleType.Number); i_pno.Direction = ParameterDirection.InputOutput; i_pno.Value = entity.i_pno;
                OracleParameter i_porg_no = objCmd.Parameters.Add("i_porg_no", OracleType.Number); i_porg_no.Direction = ParameterDirection.InputOutput; i_porg_no.Value = entity.i_porg_no;
                OracleParameter i_pcolor_code = objCmd.Parameters.Add("i_pcolor_code", OracleType.Number); i_pcolor_code.Direction = ParameterDirection.InputOutput; i_pcolor_code.Value = entity.i_pcolor_code;
                OracleParameter i_pkind_code = objCmd.Parameters.Add("i_pkind_code", OracleType.Number); i_pkind_code.Direction = ParameterDirection.InputOutput; i_pkind_code.Value = entity.i_pkind_code;
                OracleParameter i_ptype_code = objCmd.Parameters.Add("i_ptype_code", OracleType.Number); i_ptype_code.Direction = ParameterDirection.InputOutput; i_ptype_code.Value = entity.i_ptype_code;
                OracleParameter i_psource_code = objCmd.Parameters.Add("i_psource_code", OracleType.Number); i_psource_code.Direction = ParameterDirection.InputOutput; i_psource_code.Value = entity.i_psource_code;
                OracleParameter i_chassis_no = objCmd.Parameters.Add("i_chassis_no", OracleType.VarChar, 400); i_chassis_no.Direction = ParameterDirection.InputOutput; i_chassis_no.Value = entity.i_chassis_no;
                OracleParameter i_user_IPAddress = objCmd.Parameters.Add("i_user_IPAddress", OracleType.VarChar, 400); i_user_IPAddress.Direction = ParameterDirection.InputOutput; i_user_IPAddress.Value = entity.i_user_IPAddress;
                OracleParameter i_user_code = objCmd.Parameters.Add("i_user_code", OracleType.VarChar, 400); i_user_code.Direction = ParameterDirection.InputOutput; i_user_code.Value = entity.i_user_code;
                OracleParameter i_appl_name = objCmd.Parameters.Add("i_appl_name", OracleType.VarChar, 400); i_appl_name.Direction = ParameterDirection.InputOutput; i_appl_name.Value = entity.i_appl_name;
                OracleParameter o_owner_tcfno = objCmd.Parameters.Add("o_owner_tcfno", OracleType.Number); o_owner_tcfno.Direction = ParameterDirection.InputOutput; o_owner_tcfno.Value = Convert.ToInt32(entity.o_owner_tcfno);
                OracleParameter o_owner_name = objCmd.Parameters.Add("o_owner_name", OracleType.VarChar, 400); o_owner_name.Direction = ParameterDirection.InputOutput; o_owner_name.Value = entity.o_owner_name;
                OracleParameter o_owner_name_Ar = objCmd.Parameters.Add("o_owner_name_Ar", OracleType.VarChar, 400); o_owner_name_Ar.Direction = ParameterDirection.InputOutput; o_owner_name_Ar.Value = entity.o_owner_name_Ar;
                OracleParameter o_color_code = objCmd.Parameters.Add("o_color_code", OracleType.Number); o_color_code.Direction = ParameterDirection.InputOutput; o_color_code.Value = entity.o_color_code;
                OracleParameter o_color_desc_ar = objCmd.Parameters.Add("o_color_desc_ar", OracleType.VarChar, 400); o_color_desc_ar.Direction = ParameterDirection.InputOutput; o_color_desc_ar.Value = entity.o_color_desc_ar;
                OracleParameter o_color_desc = objCmd.Parameters.Add("o_color_desc", OracleType.VarChar, 400); o_color_desc.Direction = ParameterDirection.InputOutput; o_color_desc.Value = entity.o_color_desc;
                OracleParameter o_type_code = objCmd.Parameters.Add("o_type_code", OracleType.Number); o_type_code.Direction = ParameterDirection.InputOutput; o_type_code.Value = entity.o_type_code;
                OracleParameter o_type_desc_ar = objCmd.Parameters.Add("o_type_desc_ar", OracleType.VarChar, 400); o_type_desc_ar.Direction = ParameterDirection.InputOutput; o_type_desc_ar.Value = entity.o_type_desc_ar;
                OracleParameter o_type_desc = objCmd.Parameters.Add("o_type_desc", OracleType.VarChar, 400); o_type_desc.Direction = ParameterDirection.InputOutput; o_type_desc.Value = entity.o_type_desc;
                OracleParameter o_nat_code = objCmd.Parameters.Add("o_nat_code", OracleType.Number); o_nat_code.Direction = ParameterDirection.InputOutput; o_nat_code.Value = entity.o_nat_code;
                OracleParameter o_nat_desc_ar = objCmd.Parameters.Add("o_nat_desc_ar", OracleType.VarChar, 400); o_nat_desc_ar.Direction = ParameterDirection.InputOutput; o_nat_desc_ar.Value = entity.o_nat_desc_ar;
                OracleParameter o_nat_desc = objCmd.Parameters.Add("o_nat_desc", OracleType.VarChar, 400); o_nat_desc.Direction = ParameterDirection.InputOutput; o_nat_desc.Value = entity.o_nat_desc;
                OracleParameter o_year = objCmd.Parameters.Add("o_year", OracleType.Number); o_year.Direction = ParameterDirection.InputOutput; o_year.Value = entity.o_year;
                OracleParameter o_chairs = objCmd.Parameters.Add("o_chairs", OracleType.Number); o_chairs.Direction = ParameterDirection.InputOutput; o_chairs.Value = entity.o_chairs;
                OracleParameter o_make_code = objCmd.Parameters.Add("o_make_code", OracleType.Number); o_make_code.Direction = ParameterDirection.InputOutput; o_make_code.Value = entity.o_make_code;
                OracleParameter o_make_desc_ar = objCmd.Parameters.Add("o_make_desc_ar", OracleType.VarChar, 400); o_make_desc_ar.Direction = ParameterDirection.InputOutput; o_make_desc_ar.Value = entity.o_make_desc_ar;
                OracleParameter o_make_desc = objCmd.Parameters.Add("o_make_desc", OracleType.VarChar, 400); o_make_desc.Direction = ParameterDirection.InputOutput; o_make_desc.Value = entity.o_make_desc;
                OracleParameter o_model_code = objCmd.Parameters.Add("o_model_code", OracleType.Number); o_model_code.Direction = ParameterDirection.InputOutput; o_model_code.Value = entity.o_model_code;
                OracleParameter o_model_desc_ar = objCmd.Parameters.Add("o_model_desc_ar", OracleType.VarChar, 400); o_model_desc_ar.Direction = ParameterDirection.InputOutput; o_model_desc_ar.Value = entity.o_model_desc_ar;
                OracleParameter o_model_desc = objCmd.Parameters.Add("o_model_desc", OracleType.VarChar, 400); o_model_desc.Direction = ParameterDirection.InputOutput; o_model_desc.Value = entity.o_model_desc;
                OracleParameter o_kind_code = objCmd.Parameters.Add("o_kind_code", OracleType.Number); o_kind_code.Direction = ParameterDirection.InputOutput; o_kind_code.Value = entity.o_kind_code;
                OracleParameter o_kind_desc_ar = objCmd.Parameters.Add("o_kind_desc_ar", OracleType.VarChar, 400); o_kind_desc_ar.Direction = ParameterDirection.InputOutput; o_kind_desc_ar.Value = entity.o_kind_desc_ar;
                OracleParameter o_kind_desc = objCmd.Parameters.Add("o_kind_desc", OracleType.VarChar, 400); o_kind_desc.Direction = ParameterDirection.InputOutput; o_kind_desc.Value = entity.o_kind_desc;
                OracleParameter o_weight_empty = objCmd.Parameters.Add("o_weight_empty", OracleType.Number); o_weight_empty.Direction = ParameterDirection.InputOutput; o_weight_empty.Value = entity.o_weight_empty;
                OracleParameter o_weight_full = objCmd.Parameters.Add("o_weight_full", OracleType.Number); o_weight_full.Direction = ParameterDirection.InputOutput; o_weight_full.Value = entity.o_weight_full;
                OracleParameter o_reg_date = objCmd.Parameters.Add("o_reg_date", OracleType.DateTime); o_reg_date.Direction = ParameterDirection.InputOutput; o_reg_date.Value = entity.o_reg_date;
                OracleParameter o_reg_expiry_date = objCmd.Parameters.Add("o_reg_expiry_date", OracleType.DateTime); o_reg_expiry_date.Direction = ParameterDirection.InputOutput; o_reg_expiry_date.Value = entity.o_reg_expiry_date;
                OracleParameter o_engine_no = objCmd.Parameters.Add("o_engine_no", OracleType.VarChar, 400); o_engine_no.Direction = ParameterDirection.InputOutput; o_engine_no.Value = entity.o_engine_no;
                OracleParameter o_chassis_no = objCmd.Parameters.Add("o_chassis_no", OracleType.VarChar, 400); o_chassis_no.Direction = ParameterDirection.InputOutput; o_chassis_no.Value = entity.o_chassis_no;
                OracleParameter o_gear_code = objCmd.Parameters.Add("o_gear_code", OracleType.Number); o_gear_code.Direction = ParameterDirection.InputOutput; o_gear_code.Value = entity.o_gear_code;
                OracleParameter o_gear_desc_ar = objCmd.Parameters.Add("o_gear_desc_ar", OracleType.VarChar, 400); o_gear_desc_ar.Direction = ParameterDirection.InputOutput; o_gear_desc_ar.Value = entity.o_gear_desc_ar;
                OracleParameter o_gear_desc = objCmd.Parameters.Add("o_gear_desc", OracleType.VarChar, 400); o_gear_desc.Direction = ParameterDirection.InputOutput; o_gear_desc.Value = entity.o_gear_desc;
                OracleParameter o_fuel_code = objCmd.Parameters.Add("o_fuel_code", OracleType.Number); o_fuel_code.Direction = ParameterDirection.InputOutput; o_fuel_code.Value = entity.o_fuel_code;
                OracleParameter o_fuel_desc_ar = objCmd.Parameters.Add("o_fuel_desc_ar", OracleType.VarChar, 400); o_fuel_desc_ar.Direction = ParameterDirection.InputOutput; o_fuel_desc_ar.Value = entity.o_fuel_desc_ar;
                OracleParameter o_fuel_desc = objCmd.Parameters.Add("o_fuel_desc", OracleType.VarChar, 400); o_fuel_desc.Direction = ParameterDirection.InputOutput; o_fuel_desc.Value = entity.o_fuel_desc;
                OracleParameter o_weight_code = objCmd.Parameters.Add("o_weight_code", OracleType.Number); o_weight_code.Direction = ParameterDirection.InputOutput; o_weight_code.Value = entity.o_weight_code;
                OracleParameter o_weight_desc_ar = objCmd.Parameters.Add("o_weight_desc_ar", OracleType.VarChar, 400); o_weight_desc_ar.Direction = ParameterDirection.InputOutput; o_weight_desc_ar.Value = entity.o_weight_desc_ar;
                OracleParameter o_weight_desc = objCmd.Parameters.Add("o_weight_desc", OracleType.VarChar, 400); o_weight_desc.Direction = ParameterDirection.InputOutput; o_weight_desc.Value = entity.o_weight_desc;
                OracleParameter o_steering_code = objCmd.Parameters.Add("o_steering_code", OracleType.Number); o_steering_code.Direction = ParameterDirection.InputOutput; o_steering_code.Value = entity.o_steering_code;
                OracleParameter o_steering_desc_ar = objCmd.Parameters.Add("o_steering_desc_ar", OracleType.VarChar, 400); o_steering_desc_ar.Direction = ParameterDirection.InputOutput; o_steering_desc_ar.Value = entity.o_steering_desc_ar;
                OracleParameter o_steering_desc = objCmd.Parameters.Add("o_steering_desc", OracleType.VarChar, 400); o_steering_desc.Direction = ParameterDirection.InputOutput; o_steering_desc.Value = entity.o_steering_desc;
                OracleParameter o_cylinder = objCmd.Parameters.Add("o_cylinder", OracleType.Number); o_cylinder.Direction = ParameterDirection.InputOutput; o_cylinder.Value = entity.o_cylinder;
                OracleParameter o_axels_count = objCmd.Parameters.Add("o_axels_count", OracleType.Number); o_axels_count.Direction = ParameterDirection.InputOutput; o_axels_count.Value = entity.o_axels_count; ;
                OracleParameter o_door_count = objCmd.Parameters.Add("o_door_count", OracleType.Number); o_door_count.Direction = ParameterDirection.InputOutput; o_door_count.Value = entity.o_door_count;
                OracleParameter o_horse_power = objCmd.Parameters.Add("o_horse_power", OracleType.Number); o_horse_power.Direction = ParameterDirection.InputOutput; o_horse_power.Value = entity.o_horse_power;
                OracleParameter o_wheels_count = objCmd.Parameters.Add("o_wheels_count", OracleType.Number); o_wheels_count.Direction = ParameterDirection.InputOutput; o_wheels_count.Value = entity.o_wheels_count;
                OracleParameter o_reg_remarks = objCmd.Parameters.Add("o_reg_remarks", OracleType.VarChar, 400); o_reg_remarks.Direction = ParameterDirection.InputOutput; o_reg_remarks.Value = entity.o_reg_remarks;
                OracleParameter o_wanted = objCmd.Parameters.Add("o_wanted", OracleType.VarChar, 400); o_wanted.Direction = ParameterDirection.InputOutput; o_wanted.Value = entity.o_wanted;
                OracleParameter o_accident = objCmd.Parameters.Add("o_accident", OracleType.VarChar, 400); o_accident.Direction = ParameterDirection.InputOutput; o_accident.Value = entity.o_accident;
                OracleParameter o_fine_auh = objCmd.Parameters.Add("o_fine_auh", OracleType.VarChar, 400); o_fine_auh.Direction = ParameterDirection.InputOutput; o_fine_auh.Value = entity.o_fine_auh;
                OracleParameter o_fine_ne = objCmd.Parameters.Add("o_fine_ne", OracleType.VarChar, 400); o_fine_ne.Direction = ParameterDirection.InputOutput; o_fine_ne.Value = entity.o_fine_ne;
                OracleParameter o_fine_auh_amt = objCmd.Parameters.Add("o_fine_auh_amt", OracleType.Number); o_fine_auh_amt.Direction = ParameterDirection.InputOutput; o_fine_auh_amt.Value = entity.o_fine_auh_amt;
                OracleParameter o_fine_ne_amt = objCmd.Parameters.Add("o_fine_ne_amt", OracleType.Number); o_fine_ne_amt.Direction = ParameterDirection.InputOutput; o_fine_ne_amt.Value = entity.o_fine_ne_amt;
                OracleParameter o_cubic_capacity_cc = objCmd.Parameters.Add("o_cubic_capacity_cc", OracleType.Number); o_cubic_capacity_cc.Direction = ParameterDirection.InputOutput; o_cubic_capacity_cc.Value = entity.o_cubic_capacity_cc;
                OracleParameter o_mileage_count = objCmd.Parameters.Add("o_mileage_count", OracleType.Number); o_mileage_count.Direction = ParameterDirection.InputOutput; o_mileage_count.Value = entity.o_mileage_count;
                OracleParameter O_ERR_CODE = objCmd.Parameters.Add("O_ERR_CODE", OracleType.Number); O_ERR_CODE.Direction = ParameterDirection.InputOutput; O_ERR_CODE.Value = entity.O_ERR_CODE;
                OracleParameter O_ERR_MSG = objCmd.Parameters.Add("O_ERR_MSG", OracleType.VarChar, 400); O_ERR_MSG.Direction = ParameterDirection.InputOutput; O_ERR_MSG.Value = entity.O_ERR_MSG;

                #endregion

                objConn.Open();
                    objCmd.ExecuteNonQuery();
                #region GetOutputParameterValue

                    Result.i_tcfno = Convert.IsDBNull(objCmd.Parameters["i_tcfno"].Value) ? (Int64?)null : Convert.ToInt32(objCmd.Parameters["i_tcfno"].Value);
                    Result.i_pno = Convert.IsDBNull(objCmd.Parameters["i_pno"].Value) ? (int?)null : Convert.ToInt32(objCmd.Parameters["i_pno"].Value);
                    Result.i_porg_no = Convert.IsDBNull(objCmd.Parameters["i_porg_no"].Value) ? (int?)null : Convert.ToInt32(objCmd.Parameters["i_porg_no"].Value);
                    Result.i_pcolor_code = Convert.IsDBNull(objCmd.Parameters["i_pcolor_code"].Value) ? (int?)null : Convert.ToInt32(objCmd.Parameters["i_pcolor_code"].Value);
                    Result.i_pkind_code = Convert.IsDBNull(objCmd.Parameters["i_pkind_code"].Value) ? (int?)null : Convert.ToInt32(objCmd.Parameters["i_pkind_code"].Value);
                    Result.i_ptype_code = Convert.IsDBNull(objCmd.Parameters["i_ptype_code"].Value) ? (int?)null : Convert.ToInt32(objCmd.Parameters["i_ptype_code"].Value);
                    Result.i_psource_code = Convert.IsDBNull(objCmd.Parameters["i_psource_code"].Value) ? (int?)null : Convert.ToInt32(objCmd.Parameters["i_psource_code"].Value);
                Result.i_chassis_no = objCmd.Parameters["i_chassis_no"].Value.ToString(); 
                Result.i_user_IPAddress = objCmd.Parameters["i_user_IPAddress"].Value.ToString();
                Result.i_user_code = (objCmd.Parameters["i_user_code"].Value).ToString();
                Result.i_appl_name = (objCmd.Parameters["i_appl_name"].Value).ToString();
                Result.o_owner_tcfno = (objCmd.Parameters["o_owner_tcfno"].Value).ToString();
                    //Convert.IsDBNull(objCmd.Parameters["o_owner_tcfno"].Value) ? (int?)null : Convert.ToInt32(objCmd.Parameters["o_owner_tcfno"].Value);
                Result.o_owner_name = (objCmd.Parameters["o_owner_name"].Value).ToString();
                Result.o_owner_name_Ar = (objCmd.Parameters["o_owner_name_Ar"].Value).ToString();
                Result.o_color_code = Convert.IsDBNull(objCmd.Parameters["o_color_code"].Value) ? (int?)null : Convert.ToInt32(objCmd.Parameters["o_color_code"].Value);
                Result.o_color_desc_ar = (objCmd.Parameters["o_color_desc_ar"].Value).ToString();
                Result.o_color_desc = (objCmd.Parameters["o_color_desc"].Value).ToString();
                Result.o_type_code = Convert.IsDBNull(objCmd.Parameters["o_type_code"].Value) ? (int?)null : Convert.ToInt32(objCmd.Parameters["o_type_code"].Value);
                Result.o_type_desc_ar = (objCmd.Parameters["o_type_desc_ar"].Value).ToString();
                Result.o_type_desc = (objCmd.Parameters["o_type_desc"].Value).ToString();
                Result.o_nat_code = Convert.IsDBNull(objCmd.Parameters["o_nat_code"].Value) ? (int?)null : Convert.ToInt32(objCmd.Parameters["o_nat_code"].Value);
                Result.o_nat_desc_ar = (objCmd.Parameters["o_nat_desc_ar"].Value).ToString();
                Result.o_nat_desc = (objCmd.Parameters["o_nat_desc"].Value).ToString();
                Result.o_year = Convert.IsDBNull(objCmd.Parameters["o_year"].Value) ? (int?)null : Convert.ToInt32(objCmd.Parameters["o_year"].Value);
                Result.o_chairs = Convert.IsDBNull(objCmd.Parameters["o_chairs"].Value) ? (int?)null : Convert.ToInt32(objCmd.Parameters["o_chairs"].Value);
                Result.o_make_code = Convert.IsDBNull(objCmd.Parameters["o_make_code"].Value) ? (int?)null : Convert.ToInt32(objCmd.Parameters["o_make_code"].Value);
                Result.o_make_desc_ar = (objCmd.Parameters["o_make_desc_ar"].Value).ToString();
                Result.o_make_desc = (objCmd.Parameters["o_make_desc"].Value).ToString();
                Result.o_model_code = Convert.IsDBNull(objCmd.Parameters["o_model_code"].Value) ? (int?)null : Convert.ToInt32(objCmd.Parameters["o_model_code"].Value);
                Result.o_model_desc_ar = (objCmd.Parameters["o_model_desc_ar"].Value).ToString();
                Result.o_model_desc = (objCmd.Parameters["o_model_desc"].Value).ToString();
                Result.o_kind_code = Convert.IsDBNull(objCmd.Parameters["o_kind_code"].Value) ? (int?)null : Convert.ToInt32(objCmd.Parameters["o_kind_code"].Value);
                Result.o_kind_desc_ar = (objCmd.Parameters["o_kind_desc_ar"].Value).ToString();
                Result.o_kind_desc = (objCmd.Parameters["o_kind_desc"].Value).ToString();
                Result.o_weight_empty = Convert.IsDBNull(objCmd.Parameters["o_weight_empty"].Value) ? (int?)null : Convert.ToInt32(objCmd.Parameters["o_weight_empty"].Value);
                Result.o_weight_full = Convert.IsDBNull(objCmd.Parameters["o_weight_full"].Value) ? (int?)null : Convert.ToInt32(objCmd.Parameters["o_weight_full"].Value);
                Result.o_reg_date = Convert.IsDBNull(objCmd.Parameters["o_reg_date"].Value) ? (DateTime?)null : Convert.ToDateTime(objCmd.Parameters["o_reg_date"].Value);
                Result.o_reg_expiry_date = Convert.IsDBNull(objCmd.Parameters["o_reg_expiry_date"].Value) ? (DateTime?)null : Convert.ToDateTime(objCmd.Parameters["o_reg_expiry_date"].Value);
                Result.o_engine_no = (objCmd.Parameters["o_engine_no"].Value).ToString();
                Result.o_chassis_no = (objCmd.Parameters["o_chassis_no"].Value).ToString();
                Result.o_gear_code = Convert.IsDBNull(objCmd.Parameters["o_gear_code"].Value) ? (int?)null : Convert.ToInt32(objCmd.Parameters["o_gear_code"].Value);
                Result.o_gear_desc_ar = (objCmd.Parameters["o_gear_desc_ar"].Value).ToString();
                Result.o_gear_desc = (objCmd.Parameters["o_gear_desc"].Value).ToString();
                Result.o_fuel_code = Convert.IsDBNull(objCmd.Parameters["o_fuel_code"].Value) ? (int?)null : Convert.ToInt32(objCmd.Parameters["o_fuel_code"].Value);
                Result.o_fuel_desc_ar = (objCmd.Parameters["o_fuel_desc_ar"].Value).ToString();
                Result.o_fuel_desc = (objCmd.Parameters["o_fuel_desc"].Value).ToString();
                Result.o_weight_code = Convert.IsDBNull(objCmd.Parameters["o_weight_code"].Value) ? (int?)null : Convert.ToInt32(objCmd.Parameters["o_weight_code"].Value);
                Result.o_weight_desc_ar = (objCmd.Parameters["o_weight_desc_ar"].Value).ToString();
                Result.o_weight_desc = (objCmd.Parameters["o_weight_desc"].Value).ToString();
                Result.o_steering_code = Convert.IsDBNull(objCmd.Parameters["o_steering_code"].Value) ? (int?)null : Convert.ToInt32(objCmd.Parameters["o_steering_code"].Value);
                Result.o_steering_desc_ar = (objCmd.Parameters["o_steering_desc_ar"].Value).ToString();
                Result.o_steering_desc = (objCmd.Parameters["o_steering_desc"].Value).ToString();
                Result.o_cylinder = Convert.IsDBNull(objCmd.Parameters["o_cylinder"].Value) ? (int?)null : Convert.ToInt32(objCmd.Parameters["o_cylinder"].Value);
                Result.o_axels_count = Convert.IsDBNull(objCmd.Parameters["o_axels_count"].Value) ? (int?)null : Convert.ToInt32(objCmd.Parameters["o_axels_count"].Value);
                Result.o_door_count = Convert.IsDBNull(objCmd.Parameters["o_door_count"].Value) ? (int?)null : Convert.ToInt32(objCmd.Parameters["o_door_count"].Value);
                Result.o_horse_power = Convert.IsDBNull(objCmd.Parameters["o_horse_power"].Value) ? (int?)null : Convert.ToInt32(objCmd.Parameters["o_horse_power"].Value);
                Result.o_wheels_count = Convert.IsDBNull(objCmd.Parameters["o_wheels_count"].Value) ? (int?)null : Convert.ToInt32(objCmd.Parameters["o_wheels_count"].Value);
                Result.o_reg_remarks = (objCmd.Parameters["o_reg_remarks"].Value).ToString();
                Result.o_wanted = objCmd.Parameters["o_wanted"].Value.ToString();
                Result.o_accident = (objCmd.Parameters["o_accident"].Value).ToString();
                Result.o_fine_auh = (objCmd.Parameters["o_fine_auh"].Value).ToString();
                Result.o_fine_ne = (objCmd.Parameters["o_fine_ne"].Value).ToString();
                Result.o_fine_auh_amt = Convert.IsDBNull(objCmd.Parameters["o_fine_auh_amt"].Value) ? (int?)null : Convert.ToInt32(objCmd.Parameters["o_fine_auh_amt"].Value);
                Result.o_fine_ne_amt = Convert.IsDBNull(objCmd.Parameters["o_fine_ne_amt"].Value) ? (int?)null : Convert.ToInt32(objCmd.Parameters["o_fine_ne_amt"].Value);
                Result.o_cubic_capacity_cc = Convert.IsDBNull(objCmd.Parameters["o_cubic_capacity_cc"].Value) ? (int?)null : Convert.ToInt32(objCmd.Parameters["o_cubic_capacity_cc"].Value);
                Result.o_mileage_count = Convert.IsDBNull(objCmd.Parameters["o_mileage_count"].Value) ? (int?)null : Convert.ToInt32(objCmd.Parameters["o_mileage_count"].Value);
                Result.O_ERR_CODE = Convert.IsDBNull(objCmd.Parameters["O_ERR_CODE"].Value) ? (int?)null : Convert.ToInt32(objCmd.Parameters["O_ERR_CODE"].Value);
                Result.O_ERR_MSG = (objCmd.Parameters["O_ERR_MSG"].Value).ToString();

                //objConn.Close();
                return Result;

                
                #endregion
               
            }
        }


    }//class end
}
