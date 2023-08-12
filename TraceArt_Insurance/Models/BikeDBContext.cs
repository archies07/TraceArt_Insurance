using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace TraceArt_Insurance.Models
{
    public class BikeDBContext
    {
        string cs = ConfigurationManager.ConnectionStrings["TraceArt"].ConnectionString;

        //public list<bike_detailsmodel> getbike_details()
        //{
        //    list<bike_detailsmodel> bike_detailslist = new list<bike_detailsmodel>();

        //    sqlconnection conn = new sqlconnection(cs);
        //    sqlcommand cmd = new sqlcommand("sp_insert", conn);
        //    cmd.commandtype = commandtype.storedprocedure;
        //    cmd.parameters.addwithvalue("@");
        //    return bike_detailslist;
        //}
        public bool AddBikeDetails(BIke_DetailsModel bike_Details)
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("sp_insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BikeName", bike_Details.BikeName);
            cmd.Parameters.AddWithValue("@RegistrationNo", bike_Details.RegistrationNo);
            conn.Open();
            int i =cmd.ExecuteNonQuery();
            conn.Close();

            if(i>0) 
            {
                return true;
            }
           else 
            {
                return false; 
            }
        }
    }
}