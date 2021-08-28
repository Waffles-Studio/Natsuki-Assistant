using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Common.Cache;

namespace DataAccese
{
    public class UserDao:ConnectionToSq
    {

        public void editPorfile(int id, string userName, string password, string name, string LastName, string mail)
        {
            using (var conection = GetConnection())
            {
                conection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conection;
                    command.CommandText = "update Users set loginName=@userName, Password=@pass, FirstName=@name, LastName=@LastName, Email=@mail where UserId=@id";
                    command.Parameters.AddWithValue("@userName", userName);
                    command.Parameters.AddWithValue("@pass", password);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("mail", mail);
                    command.Parameters.AddWithValue("@id",id);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }

            }
        }


        public bool Login(string user, string pass)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select *from Users where LoginName=@user and Password=@pass";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserLoginCache.IdUser = reader.GetInt32(0);
                            UserLoginCache.LoginName = reader.GetString(1);
                            UserLoginCache.password = reader.GetString(2);
                            UserLoginCache.FirtsName = reader.GetString(3);
                            UserLoginCache.LastName = reader.GetString(4);
                            UserLoginCache.Position = reader.GetString(5);
                            UserLoginCache.Email = reader.GetString(6);

                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            
        }

        public string recoveryPassword(string userRequesting) 
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select *from Users where LoginName=@user or Email=@mail";
                    command.Parameters.AddWithValue("@user", userRequesting);
                    command.Parameters.AddWithValue("@mail", userRequesting);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read() == true)
                    {
                        string userName = reader.GetString(3) + " " + reader.GetString(4);
                        string userMail = reader.GetString(6);
                        string accountPassword = reader.GetString(2);

                        var mailService = new MailServices.SystemSuportMail();
                        mailService.sendMail(
                            subject: "Password request",
                            body: "Hello, " + userName + "\nYou asked for the clarification of your password.\n" +
                            "Your current password is: " + accountPassword +
                            "\nWe recommend that you request the change of your password immediately for security.",
                            recipientMail: new List<string> { userMail}
                            );
                        return ("Hello, " + userName + "\n You asked for the clarification of your password.\n" +
                            "Please check your email: " + userMail+
                            "\n We recommend that you request the change of your password immediately for security.");
                    }
                    else
                    {
                        return "Sorry, you do not have an account with this username or email";
                    }
                }
            }
        }
    }
}
