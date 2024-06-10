using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectMID
{
    internal class ConnectionString
    {

        public string Connection = "Data Source=DESKTOP-RRLMQR8\\MSSQLSERVER01;Initial Catalog=ProjectB;Integrated Security=True";

        public string GetConnection()
        {
            return Connection;
        }
    }
}
