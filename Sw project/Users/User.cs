using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Text.RegularExpressions;
namespace Sw_project.Users
{
    public class User
    {
        public int Id;
        public string Email;
        public string Password;
        public string UserName;
        public string Role ;
        public DateTime CREATED_AT;
        public char is_banned;
        public User()
            { }
        public User( string Email, string Password, string UserName)
        {
            this.Email = Email;
            this.Password = Password;
            this.UserName = UserName;

        }
        public User( string Email, string Password, string UserName, int Id, string Role, DateTime CREATED_AT, char is_banned) : this( Email, Password, UserName)
        {
            this.Role = Role;
            this.Id =Id;
            this.CREATED_AT = CREATED_AT;
            this.is_banned = is_banned;
        }
            
    }

    internal class UserOP:ordbCon
    {
       public bool is_banned(int id)
        {
         
            string s = "";
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = this.conn;
            cmd.CommandText = "SELECT BAN FROM Users WHERE USER_ID = :U_id";
            cmd.Parameters.Add("U_id", OracleDbType.Int32).Value = id;

            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
               s= reader[0].ToString();
            }
            if(s.Equals("Y"))
                return true;
            else return false;
        }
        public User GetUserByID(int ID)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = this.conn;
            cmd.CommandText = "get_user";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("id_in", ID);
            cmd.Parameters.Add("USER_out", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("PASS_out", OracleDbType.Varchar2, 255).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("EMAIL_out", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("ROLE_TYPE_out", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("CREATED_AT_out", OracleDbType.Date).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("BAN_out", OracleDbType.Char, 1).Direction = ParameterDirection.Output;

            try
            {
                MessageBox.Show($"Attempting to get user with ID: {ID}");
                cmd.ExecuteNonQuery();
                string username = cmd.Parameters["USER_out"].Value.ToString();
                string password = cmd.Parameters["PASS_out"].Value.ToString();
                string email = cmd.Parameters["EMAIL_out"].Value.ToString();
                string role = cmd.Parameters["ROLE_TYPE_out"].Value.ToString();
                DateTime CREATED_AT = ((Oracle.DataAccess.Types.OracleDate)cmd.Parameters["CREATED_AT_out"].Value).Value;
                char is_banned = ((Oracle.DataAccess.Types.OracleString)cmd.Parameters["BAN_out"].Value).Value[0];
                User user1 = new User(email,password,username, ID, role,CREATED_AT,is_banned);
                return user1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in GetUserByID: {ex.Message}");
                return null;
            }
        }



        public User SignIn(string Email, string Password)
        {
            int id;
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = this.conn;
            cmd.CommandText = "sign_in";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("email_in", Email);
            cmd.Parameters.Add("pass_in", Password);
            cmd.Parameters.Add("id_out", OracleDbType.Int32, ParameterDirection.Output);
           
            try
            {
                cmd.ExecuteNonQuery();
                string idValue = cmd.Parameters["id_out"].Value?.ToString();
                if (string.IsNullOrEmpty(idValue))
                {
                    return null;
                }
                id = Convert.ToInt32(idValue);
                return GetUserByID(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during sign in: {ex.Message}");
                Console.WriteLine("Error occurred: " + ex.Message);
                return null;
            }
        }

        public int register(User newUser)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(newUser.Email, emailPattern))
            {
                MessageBox.Show("Invalid email format. Please use *****@.***");
                return -3; 
            }

            OracleCommand command = new OracleCommand();
            try
            { 
                command.Connection = this.conn;
                command.CommandText = "SELECT COUNT(*) FROM Users WHERE Email = :Email";
                command.CommandType = CommandType.Text;
                command.Parameters.Add("Email", newUser.Email);
                int count = Convert.ToInt32(command.ExecuteScalar());
                if (count > 0)
                {
                    MessageBox.Show("This email is already registered.");
                    return -2; 
                }
                newUser.Role = "USER";
                command.CommandText = "INSERT INTO Users (User_name, Email, Pass, ROLE_TYPE) VALUES (:User_name, :Email, :Pass, :Role_type)";
                command.Parameters.Clear();
                command.Parameters.Add("User_name", newUser.UserName);
                command.Parameters.Add("Email", newUser.Email);
                command.Parameters.Add("Pass", newUser.Password);
                command.Parameters.Add("ROLE_TYPE", newUser.Role);
                int affectedRows = command.ExecuteNonQuery();
                if (affectedRows == 0)
                    return -1;
                command.CommandText = "SELECT User_ID FROM Users WHERE Email = :Email";
                command.CommandType = CommandType.Text;
                command.Parameters.Clear();
                command.Parameters.Add("Email", newUser.Email);
                OracleDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    return -1;
                }
                reader.Read();
                newUser.Id = Convert.ToInt32(reader[0]);
                return newUser.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }
    }


}

