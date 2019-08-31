using BackEnd.Models;
using BackEnd.Models.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Service
{
    public class DoctorService
    {
        string connectionString = "Server= DESKTOP-0VIESPO\\SQLEXPRESS; Database= VeteDB; Integrated Security=True;";
        public Cookie AddDoctor(Doctor owner)
        {
            Cookie cookie = new Cookie();
            try
            {

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("Insert_AppUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserType", 1);
                    cmd.Parameters.AddWithValue("@FirstName", owner.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", owner.LastName);
                    cmd.Parameters.AddWithValue("@Email", owner.Email);
                    cmd.Parameters.AddWithValue("@ContactNo", owner.ContactNo);
                    cmd.Parameters.AddWithValue("@Address", owner.Address);
                    cmd.Parameters.AddWithValue("@Title", owner.Title);
                    cmd.Parameters.AddWithValue("@Experience", owner.Experience);
                    cmd.Parameters.AddWithValue("@Dob", owner.Dob);
                    cmd.Parameters.AddWithValue("@PassWord", owner.PassWord);
                    con.Open();
                    //cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        cookie.RegNo = rdr["RegNo"].ToString();
                        cookie.UserId = Convert.ToInt32(rdr["UserId"]);
                        cookie.Type = Convert.ToInt32(rdr["Type"]);
                        cookie.Pass = rdr["Pass"].ToString();
                        cookie.isSuccess = true;
                    }
                    con.Close();
                }
                return cookie;
            }
            catch (Exception x)
            {
                cookie.isSuccess = false;
                return cookie;
            }
        }


        public Doctor GetDoctor(int Id)
        {
            try
            {
                Doctor doctor = new Doctor();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("Select_Doctor", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserId", Id);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        doctor.Id = Convert.ToInt32(rdr["Id"]);
                        doctor.FirstName = rdr["FirstName"].ToString();
                        doctor.LastName = rdr["LastName"].ToString();
                        doctor.Sex = Convert.ToInt32(rdr["Sex"]);
                        //doctor.Title = Convert.ToInt32(rdr["Title"]);
                        doctor.Email = rdr["Email"].ToString();
                        doctor.ContactNo = rdr["ContactNo"].ToString();
                        doctor.Address = rdr["Address"].ToString();
                        doctor.Dob = rdr["Dob"].ToString();
                        doctor.Qualification = rdr["Qualification"].ToString();
                        doctor.Experience = rdr["Experience"].ToString();
                    }
                    con.Close();
                }
                return doctor;
            }
            catch (Exception x)
            {
                return null;
            }
        }


        public Cookie Login(Login login)
        {
            Cookie cookie = new Cookie();
            try
            {

                using (SqlConnection con = new SqlConnection(connectionString))

                {
                    SqlCommand cmd = new SqlCommand("Get_Login", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserType", 1);
                    cmd.Parameters.AddWithValue("@RegNo", login.RegNo.ToUpper());
                    cmd.Parameters.AddWithValue("@PassWord", login.PassWord);
                    con.Open();
                    //cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        cookie.RegNo = rdr["RegNo"].ToString();
                        cookie.UserId = Convert.ToInt32(rdr["UserId"]);
                        cookie.Type = Convert.ToInt32(rdr["Type"]);
                        cookie.Pass = rdr["PassWord"].ToString();
                        cookie.isSuccess = true;
                    }
                    con.Close();
                }
                return cookie;
            }
            catch (Exception x)
            {
                cookie.isSuccess = false;
                return cookie;
            }
        }

        public bool UpdateInfo(UpdateDoctor updateDoctor)
        {
            bool result = false;

            using (SqlConnection con = new SqlConnection(connectionString))

            {
                SqlCommand cmd = new SqlCommand("Update_DogInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", updateDoctor.UserId);
                cmd.Parameters.AddWithValue("@DogName", updateDoctor.DogName);
                cmd.Parameters.AddWithValue("@Vacination", updateDoctor.Vacination);
                cmd.Parameters.AddWithValue("@HRecord", updateDoctor.HRecord);
                con.Open();
                //cmd.ExecuteNonQuery();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    result = Convert.ToBoolean(rdr["Status"]);
                }
                con.Close();
            }
            return result;
        }

        public bool UpdatePassword(ChangePassword password)
        {
            bool result = false;

            using (SqlConnection con = new SqlConnection(connectionString))

            {
                SqlCommand cmd = new SqlCommand("Update_Password", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", password.Id);
                cmd.Parameters.AddWithValue("@OldPass", password.OldPass);
                cmd.Parameters.AddWithValue("@NewPass", password.NewPass);
                con.Open();
                //cmd.ExecuteNonQuery();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    result = Convert.ToBoolean(rdr["Status"]);
                }
                con.Close();
            }
            return result;
        }
    }
}
