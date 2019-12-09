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
    public class VaccinationService
    {
        string connectionString = "Server= DESKTOP-0VIESPO\\SQLEXPRESS; Database= VeteDB; Integrated Security=True;";

        public List<Vaccination> GetVaccinations()
        {
            List<Vaccination> vaccinations = new List<Vaccination>();

            using (SqlConnection con = new SqlConnection(connectionString))

            {
                SqlCommand cmd = new SqlCommand("Get_VaccineSchedules", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                //cmd.ExecuteNonQuery();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Vaccination vaccination = new Vaccination();
                    vaccination.Id = Convert.ToInt32(rdr["Id"]);
                    vaccination.Description = rdr["Description"].ToString();
                    vaccination.OwnerName = rdr["OwnerName"].ToString();
                    vaccination.Email = rdr["Email"].ToString();
                    vaccination.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]);
                    vaccination.IsEnded = Convert.ToBoolean(rdr["IsEnded"]);
                    vaccination.LastUpdatedDate = Convert.ToDateTime(rdr["LastUpdatedDate"]);
                    vaccination.OwnerId = Convert.ToInt32(rdr["OwnerId"]);
                    vaccination.UserId = Convert.ToInt32(rdr["CreatedUserId"]);
                    vaccinations.Add(vaccination);
                }
                con.Close();
            }
            return vaccinations;
        }

        public List<Vaccination> GetVaccinationByOwnerId(int OwnerId)
        {
            List<Vaccination> vaccinations = new List<Vaccination>();
            try
            {
                Vaccination vaccination = new Vaccination();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("Get_VaccineSchedulesByOwnerId", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@OwnerId", OwnerId);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        vaccination.Id = Convert.ToInt32(rdr["Id"]);
                        vaccination.Description = rdr["Description"].ToString();
                        vaccination.OwnerId = Convert.ToInt32(rdr["OwnerId"]);
                        vaccination.UserId = Convert.ToInt32(rdr["CreatedUserId"]);
                        vaccination.LastUpdatedUserId = Convert.ToInt32(rdr["LastUpdatedUserId"]);
                        vaccination.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]);
                        vaccination.LastUpdatedDate = Convert.ToDateTime(rdr["LastUpdatedDate"]);
                        vaccination.IsEnded = Convert.ToBoolean(rdr["IsEnded"]);
                        vaccinations.Add(vaccination);
                    }
                    con.Close();
                }

                return vaccinations;
            }
            catch (Exception x)
            {
                return null;
            }
        }


        public bool AddVaccinations(Vaccination vaccinations)
        {
            bool cookie = true;

            using (SqlConnection con = new SqlConnection(connectionString))

            {
                SqlCommand cmd = new SqlCommand("Insert_VaccineSchedule", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@OwnerId", vaccinations.OwnerId);
                cmd.Parameters.AddWithValue("@UserId", vaccinations.UserId);
                cmd.Parameters.AddWithValue("@Description", vaccinations.Description);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return cookie;
        }

        public bool UpdateVaccination(Vaccination vaccination)
        {
            bool result = false;
            List<Vaccination> vaccinations = new List<Vaccination>();

            using (SqlConnection con = new SqlConnection(connectionString))

            {
                SqlCommand cmd = new SqlCommand("Update_VaccineSchedule", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VaccinationId", vaccination.Id);
                cmd.Parameters.AddWithValue("@IsEnded", vaccination.IsEnded);
                cmd.Parameters.AddWithValue("@OwnerId", vaccination.OwnerId);
                cmd.Parameters.AddWithValue("@Description", vaccination.Description);
                cmd.Parameters.AddWithValue("@UserId", vaccination.UserId);
                con.Open();
                //cmd.ExecuteNonQuery();
                SqlDataReader rdr = cmd.ExecuteReader();
                con.Close();
            }
            return result;
        }

        public bool DeleteVaccination(int Id)
        {
            bool cookie = true;

            using (SqlConnection con = new SqlConnection(connectionString))

            {
                SqlCommand cmd = new SqlCommand("Delete_VaccineSchedule", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VaccinationId", Id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return cookie;
        }
    }
}
