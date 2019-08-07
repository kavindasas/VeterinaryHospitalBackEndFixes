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
    public class OwnerService
    {
        string connectionString = "Server= DESKTOP-0VIESPO\\SQLEXPRESS; Database= VeteDB; Integrated Security=True;";
        public Cookie AddOwner(Owner owner)
        {
            Cookie cookie = new Cookie();
            try
            {
                
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("Insert_AppUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserType", 3);
                    cmd.Parameters.AddWithValue("@FirstName", owner.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", owner.LastName);
                    cmd.Parameters.AddWithValue("@Email", owner.Email);
                    cmd.Parameters.AddWithValue("@ContactNo", owner.ContactNo);
                    cmd.Parameters.AddWithValue("@Address", owner.Address);
                    cmd.Parameters.AddWithValue("@DogName", owner.DogName);
                    cmd.Parameters.AddWithValue("@DogType", owner.DogType);
                    cmd.Parameters.AddWithValue("@DogAge", owner.DogAge);
                    cmd.Parameters.AddWithValue("@DogDob", owner.DogDob);
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
            } catch (Exception x)
            {
                cookie.isSuccess = false;
                return cookie;
            }
        }


        public Owner GetOwner(int Id)
        {
            try
            {
                Owner owner = new Owner();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("Select_DogOwner", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserId", Id);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        owner.Id = Convert.ToInt32(rdr["Id"]);
                        owner.FirstName = rdr["FirstName"].ToString();
                        owner.LastName = rdr["LastName"].ToString();
                        owner.Sex = Convert.ToInt32(rdr["Sex"]);
                        owner.Email = rdr["Email"].ToString();
                        owner.ContactNo = rdr["ContactNo"].ToString();
                        owner.Address = rdr["Address"].ToString();
                        owner.DogName = rdr["DogName"].ToString();
                        owner.DogType = rdr["DogType"].ToString();
                        owner.DogAge = Convert.ToInt32(rdr["DogAge"]);
                        owner.DogDob = rdr["DogDob"].ToString();
                        owner.Vacination = rdr["Vacination"].ToString();
                        owner.HRecord = rdr["HRecord"].ToString();
                    }
                    con.Close();
                }
                return owner;
            }
            catch (Exception x)
            {
                return null;
            }
        }


        public Cookie Login(Login login)
        {
            Cookie cookie = new Cookie();

                using (SqlConnection con = new SqlConnection(connectionString))
                
{
                    SqlCommand cmd = new SqlCommand("Get_Login", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserType", 3);
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
                    }
                    con.Close();
                }
                return cookie;
        }

        public bool UpdateInfo(UpdateDogInfo updateDogInfo)
        {
            bool result = false;

                using (SqlConnection con = new SqlConnection(connectionString))

                {
                    SqlCommand cmd = new SqlCommand("Update_DogInfo", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserId", updateDogInfo.UserId);
                    cmd.Parameters.AddWithValue("@DogName", updateDogInfo.DogName);
                    cmd.Parameters.AddWithValue("@Vacination", updateDogInfo.Vacination);
                    cmd.Parameters.AddWithValue("@HRecord", updateDogInfo.HRecord);
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
