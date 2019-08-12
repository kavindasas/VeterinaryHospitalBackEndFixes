﻿using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Service
{
    public class UserService
    {
        string connectionString = "Server= DESKTOP-0VIESPO\\SQLEXPRESS; Database= VeteDB; Integrated Security=True;";
        public bool AddMessage(MessageVM message)
        {
            bool cookie = true;

            using (SqlConnection con = new SqlConnection(connectionString))

            {
                SqlCommand cmd = new SqlCommand("Get_Login", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", message.Name);
                cmd.Parameters.AddWithValue("@Email", message.Email);
                cmd.Parameters.AddWithValue("@Subject", message.Subject);
                cmd.Parameters.AddWithValue("@Message", message.Message);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return cookie;
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

        public List<MessageVM> GetMessages()
        {
            List<MessageVM> messages = new List<MessageVM>();
            MessageVM message = new MessageVM();

            using (SqlConnection con = new SqlConnection(connectionString))

            {
                SqlCommand cmd = new SqlCommand("Get_Login", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                //cmd.ExecuteNonQuery();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    message.Email = rdr["Email"].ToString();
                    message.Name = rdr["Name"].ToString();
                    message.Subject = rdr["Subject"].ToString();
                    message.Message = rdr["Message"].ToString();
                    messages.Add(message);
                }
                con.Close();
            }
            return messages;
        }
    }
}