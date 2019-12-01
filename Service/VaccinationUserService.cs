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
        public bool AddMessage(MessageVM message)
        {
            bool cookie = true;

            using (SqlConnection con = new SqlConnection(connectionString))

            {
                SqlCommand cmd = new SqlCommand("Insert_Message", con);
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

                cmd.Parameters.AddWithValue("@UserType", 4);
                cmd.Parameters.AddWithValue("@RegNo", login.RegNo.ToUpper());
                //cmd.Parameters.AddWithValue("@PassWord", login.PassWord);
                var provider = new SHA1CryptoServiceProvider();
                var encoding = new UnicodeEncoding();
                cmd.Parameters.AddWithValue("@PassWord", provider.ComputeHash(encoding.GetBytes(login.PassWord)));
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

            using (SqlConnection con = new SqlConnection(connectionString))

            {
                SqlCommand cmd = new SqlCommand("Get_Messages", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                //cmd.ExecuteNonQuery();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MessageVM message = new MessageVM();
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

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();    

            using (SqlConnection con = new SqlConnection(connectionString))

            {
                SqlCommand cmd = new SqlCommand("Get_Users", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                //cmd.ExecuteNonQuery();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    User user = new User();
                    user.Id = Convert.ToInt32(rdr["Id"].ToString());
                    user.FirstName = rdr["FirstName"].ToString();
                    user.LastName = rdr["LastName"].ToString();
                    user.Email = rdr["Email"].ToString();
                    user.RegNo = rdr["RegNo"].ToString();
                    user.UserType = Convert.ToInt32(rdr["UserType"].ToString());
                    user.Type = rdr["Type"].ToString();
                    users.Add(user);
                }
                con.Close();
            }
            return users;
        }

        public List<User> SearchUsers(string Para)
        {
            List<User> users = new List<User>();

            using (SqlConnection con = new SqlConnection(connectionString))

            {
                SqlCommand cmd = new SqlCommand("Search_User", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Para", Para);
                con.Open();
                //cmd.ExecuteNonQuery();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    User user = new User();
                    user.Id = Convert.ToInt32(rdr["Id"].ToString());
                    user.FirstName = rdr["FirstName"].ToString();
                    user.LastName = rdr["LastName"].ToString();
                    user.Email = rdr["Email"].ToString();
                    user.RegNo = rdr["RegNo"].ToString();
                    user.UserType = Convert.ToInt32(rdr["UserType"].ToString());
                    user.Type = rdr["Type"].ToString();
                    users.Add(user);
                }
                con.Close();
            }
            return users;
        }

        public bool UpdatePassword(ChangePassword password)
        {
            bool result = false;

            using (SqlConnection con = new SqlConnection(connectionString))

            {
                SqlCommand cmd = new SqlCommand("Update_PassAdmin", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", password.Id);
                var provider = new SHA1CryptoServiceProvider();
                var encoding = new UnicodeEncoding();
                cmd.Parameters.AddWithValue("@NewPass", provider.ComputeHash(encoding.GetBytes(password.NewPass)));
                con.Open();
                //cmd.ExecuteNonQuery();
                SqlDataReader rdr = cmd.ExecuteReader();
                result = true;
                con.Close();
            }
            return result;
        }

        public bool AddDnt(Dnt dnt)
        {
            bool cookie = true;

            using (SqlConnection con = new SqlConnection(connectionString))

            {
                SqlCommand cmd = new SqlCommand("Insert_Dnt", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Url", dnt.Url);
                cmd.Parameters.AddWithValue("@Title", dnt.Title);
                cmd.Parameters.AddWithValue("@Description", dnt.Description);
                cmd.Parameters.AddWithValue("@Type", dnt.Type);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return cookie;
        }

        public List<Dnt> GetDnts()
        {
            List<Dnt> dnts = new List<Dnt>();

            using (SqlConnection con = new SqlConnection(connectionString))

            {
                SqlCommand cmd = new SqlCommand("Get_Dnts", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                //cmd.ExecuteNonQuery();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Dnt dnt = new Dnt();
                    dnt.Id = Convert.ToInt32(rdr["Id"].ToString());
                    dnt.Title = rdr["Title"].ToString();
                    dnt.Url = rdr["Url"].ToString();
                    dnt.Description = rdr["Description"].ToString();
                    dnt.Type = Convert.ToInt32(rdr["Type"].ToString());
                    dnt.TypeDesc = rdr["TypeDesc"].ToString();
                    dnts.Add(dnt);
                }
                con.Close();
            }
            return dnts;
        }

        public List<User> EditDnt(Dnt dnt)
        {
            List<User> users = new List<User>();

            using (SqlConnection con = new SqlConnection(connectionString))

            {
                SqlCommand cmd = new SqlCommand("Update_Dnt", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", dnt.Id);
                cmd.Parameters.AddWithValue("@Url", dnt.Url);
                cmd.Parameters.AddWithValue("@Title", dnt.Title);
                cmd.Parameters.AddWithValue("@Description", dnt.Description);
                cmd.Parameters.AddWithValue("@Type", dnt.Type);
                con.Open();
                //cmd.ExecuteNonQuery();
                SqlDataReader rdr = cmd.ExecuteReader();
                //while (rdr.Read())
                //{
                //    User user = new User();
                //    user.Id = Convert.ToInt32(rdr["Id"].ToString());
                //    user.FirstName = rdr["FirstName"].ToString();
                //    user.LastName = rdr["LastName"].ToString();
                //    user.Email = rdr["Email"].ToString();
                //    user.RegNo = rdr["RegNo"].ToString();
                //    user.UserType = Convert.ToInt32(rdr["UserType"].ToString());
                //    user.Type = rdr["Type"].ToString();
                //    users.Add(user);
                //}
                con.Close();
            }
            return users;
        }

        public bool DeleteDnt(int Id)
        {
            bool cookie = true;

            using (SqlConnection con = new SqlConnection(connectionString))

            {
                SqlCommand cmd = new SqlCommand("Delete_Dnt", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return cookie;
        }

        public bool AddDntType(DntType dnt)
        {
            bool cookie = true;

            using (SqlConnection con = new SqlConnection(connectionString))

            {
                SqlCommand cmd = new SqlCommand("Insert_DntType", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Description", dnt.Description);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return cookie;
        }

        public List<DntType> GetDntTypes()
        {
            List<DntType> dnts = new List<DntType>();

            using (SqlConnection con = new SqlConnection(connectionString))

            {
                SqlCommand cmd = new SqlCommand("Get_DntTypes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                //cmd.ExecuteNonQuery();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DntType dnt = new DntType();
                    dnt.Id = Convert.ToInt32(rdr["Id"].ToString());
                    dnt.Description = rdr["Description"].ToString();
                    dnts.Add(dnt);
                }
                con.Close();
            }
            return dnts;
        }

        public List<User> EditDntType(DntType dnt)
        {
            List<User> users = new List<User>();

            using (SqlConnection con = new SqlConnection(connectionString))

            {
                SqlCommand cmd = new SqlCommand("Update_DntType", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", dnt.Id);
                cmd.Parameters.AddWithValue("@Description", dnt.Description);
                con.Open();
                //cmd.ExecuteNonQuery();
                SqlDataReader rdr = cmd.ExecuteReader();
                //while (rdr.Read())
                //{
                //    User user = new User();
                //    user.Id = Convert.ToInt32(rdr["Id"].ToString());
                //    user.FirstName = rdr["FirstName"].ToString();
                //    user.LastName = rdr["LastName"].ToString();
                //    user.Email = rdr["Email"].ToString();
                //    user.RegNo = rdr["RegNo"].ToString();
                //    user.UserType = Convert.ToInt32(rdr["UserType"].ToString());
                //    user.Type = rdr["Type"].ToString();
                //    users.Add(user);
                //}
                con.Close();
            }
            return users;
        }

        public bool DeleteDntTyp(int Id)
        {
            bool cookie = true;

            using (SqlConnection con = new SqlConnection(connectionString))

            {
                SqlCommand cmd = new SqlCommand("Delete_DntType", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return cookie;
        }

        public bool DeleteUser(int Id)
        {
            bool cookie = true;

            using (SqlConnection con = new SqlConnection(connectionString))

            {
                SqlCommand cmd = new SqlCommand("Delete_User", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return cookie;
        }
    }
}
