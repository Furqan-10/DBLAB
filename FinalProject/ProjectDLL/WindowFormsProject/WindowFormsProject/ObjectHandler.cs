using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDLL.DL.DB;
using ProjectDLL.DL.FH;
using ProjectDLL.DLInterfaces;
using ProjectDLL.Utils;

namespace WindowFormsProject
{
    internal class ObjectHandler
    {
       
        private static IUserDL userDL=new UserDB(ConnectionManager.GetConnectionString());
        private static IProductDL productDL=new ProductDB(ConnectionManager.GetConnectionString());
        private static IProducts getSource=new ProductDB(ConnectionManager.GetConnectionString());
        public static IUserDL getUserDL()
        {
            return userDL;
        }

        public static IProductDL getProductDL()
        {
          return productDL;
        }

        public static IProducts GetSource()
        {
            return getSource;
        }
    }
}
