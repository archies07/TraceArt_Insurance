using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace TraceArt_Insurance.Models
{
    public class UserDBContext
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public List<Bikeinsurance> GetBikeinsurances()
        {
            List<Bikeinsurance> InsuranceList = new List<Bikeinsurance>();
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spGetInsurance", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Bikeinsurance BI = new Bikeinsurance();
                BI.PolicyNo = Convert.ToInt32(dr.GetValue(0).ToString());
                BI.Name = dr.GetValue(1).ToString();
                BI.Email = dr.GetValue(2).ToString();
                BI.RegistrationNo = dr.GetValue(3).ToString();
                BI.SelectPlan = dr.GetValue(4).ToString();
                BI.SelectPlanTenure = dr.GetValue(5).ToString();
                InsuranceList.Add(BI);
            }
            conn.Close();

            return InsuranceList;
        }
        public bool Insert(Bikeinsurance insurance)
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spInsert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", insurance.Name);
            cmd.Parameters.AddWithValue("@Email", insurance.Email);
            cmd.Parameters.AddWithValue("@RegistrationNo", insurance.RegistrationNo);
            cmd.Parameters.AddWithValue("@Selectplan", insurance.SelectPlan);
            cmd.Parameters.AddWithValue("@SelectPlanTenure", insurance.SelectPlanTenure);

            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();

            if (i > 0)
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