using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDLL.DLInterfaces
{
    public interface IUserDL
    {
        bool ChangePassword(string username, string newPassword);

        bool IsUsernameTaken(SqlConnection connection, string username);

        string SignIn(string username, string password);

        void SignUp(string username, string password, string role);


    }
}
