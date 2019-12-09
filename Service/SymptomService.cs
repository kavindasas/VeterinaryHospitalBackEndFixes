using BackEnd.Models;
using BackEnd.Models.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Service
{
    public class SymtomsService
    {
        string connectionString = "Server= DESKTOP-0VIESPO\\SQLEXPRESS; Database= VeteDB; Integrated Security=True;";

        public List<Symptoms> GetSymptoms()
        {
            List<Symptoms> symptoms = new List<Symptoms>();

            using (SqlConnection con = new SqlConnection(connectionString))

            {
                SqlCommand cmd = new SqlCommand("Get_Symptoms", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                //cmd.ExecuteNonQuery();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Symptoms symptom = new Symptoms();
                    symptom.Id = Convert.ToInt32(rdr["Id"]);
                    symptom.Description = rdr["Description"].ToString();
                    symptoms.Add(symptom);
                }
                con.Close();
            }
            return symptoms;
        }

        public List<String> GetDiseaseBySymptomIds(string Ids)
        {
            List<String> Diseases = new List<String>();
            try
            {
                String Disease = "";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("Get_DiseaseBySymptomIds", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Ids", Ids);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Disease = rdr["Description"].ToString();
                        Diseases.Add(Disease);
                    }
                    con.Close();
                }

                return Diseases;
            }
            catch (Exception x)
            {
                return null;
            }
        }
    }
}
