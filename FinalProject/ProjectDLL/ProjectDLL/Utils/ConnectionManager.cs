using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDLL.Utils
{
    public  class ConnectionManager
        {
   
            public static string GetConnectionString()
            {
                return "Data Source=DESKTOP-RRLMQR8\\MSSQLSERVER01;Initial Catalog=ProjectOOP;Integrated Security=True";
            }
        }
}
