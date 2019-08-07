﻿using BackEnd.Models;
using BackEnd.Models.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Service
{
    public class StaffService
    {
        string connectionString = "Server= DESKTOP-0VIESPO\\SQLEXPRESS; Database= VeteDB; Integrated Security=True;";
        public Cookie AddStaff(Staff owner)
        {
            Cookie cookie = new Cookie();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("Insert_AppUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserType", 2);
                    cmd.Parameters.AddWithValue("@FirstName", owner.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", owner.LastName);
                    cmd.Parameters.AddWithValue("@Email", owner.Email);
                    cmd.Parameters.AddWithValue("@ContactNo", owner.ContactNo);
                    cmd.Parameters.AddWithValue("@Address", owner.Address);
                    cmd.Parameters.AddWithValue("@Qualification", owner.Qualification);
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
                    }
                    con.Close();
                }
                return cookie;
        }


        public Owner GetStaff(int Id)
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

        public Cookie UpdateInfo(UpdateDogInfo updateStaffInfo)
        {
            Cookie cookie = new Cookie();

                using (SqlConnection con = new SqlConnection(connectionString))

                {
                    SqlCommand cmd = new SqlCommand("Update_DogInfo", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserId", updateStaffInfo.UserId);
                    cmd.Parameters.AddWithValue("@DogName", updateStaffInfo.DogName);
                    cmd.Parameters.AddWithValue("@Vacination", updateStaffInfo.Vacination);
                    cmd.Parameters.AddWithValue("@HRecord", updateStaffInfo.HRecord);
                    con.Open();
                    //cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        cookie.isSuccess = Convert.ToBoolean(rdr["Status"]);
                    }
                    con.Close();
                }
                return cookie;
            
        }
    }
}
