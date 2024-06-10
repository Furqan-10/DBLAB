using ProjectDLL.BL;
using ProjectDLL.DLInterfaces;
using ProjectDLL.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDLL.DL.DB
{

    public class UserDB: IUserDL
    {
        private string connectionString;

        public UserDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public UserDB() { } 

        public void SignUp(string username, string password, string role)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (string.IsNullOrEmpty(username))
                {
                    throw new ArgumentException("Username cannot be empty.");
                }

                if (string.IsNullOrEmpty(password))
                {
                    throw new ArgumentException("Password cannot be empty.");
                }


                if (string.IsNullOrEmpty(role) || (role.ToLower() != "admin" && role.ToLower() != "customer"))
                {
                    throw new ArgumentException("Invalid user role.");
                }

                if (IsUsernameTaken(connection, username))
                {
                    throw new InvalidOperationException("Username is already taken. Please choose a different username.");
                }

                string query = "INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, @Role)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Role", role);
                    command.ExecuteNonQuery();
                }
            }
        }
        public string SignIn(string username, string password)
        {
     
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Username and password are required.");
            }

            string query = "SELECT Role FROM Users WHERE Username = @Username AND Password = @Password";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    var role = command.ExecuteScalar();
                    return role != null ? role.ToString() : null;
                }
            }
        }

        public bool IsUsernameTaken(SqlConnection connection, string username)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        public bool ChangePassword(string username, string newPassword)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();


                string query = "UPDATE Users SET Password = @NewPassword WHERE Username = @Username";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NewPassword", newPassword);
                    command.Parameters.AddWithValue("@Username", username);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; 
                }
            }
        }




    }
}
